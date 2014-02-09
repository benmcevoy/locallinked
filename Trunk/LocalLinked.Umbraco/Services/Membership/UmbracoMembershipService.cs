using System;
using System.Security;
using System.Web;
using System.Web.Profile;
using Security = System.Web.Security;
using LocalLinked.Umbraco.Profile;

namespace LocalLinked.Umbraco.Services.Membership
{
    public class UmbracoMembershipService : IMembershipService
    {
        private readonly HttpContext _currentContext;
        private readonly IAuthenticationTokenService _authenticationTokenService;

        public UmbracoMembershipService(HttpContext currentContext, IAuthenticationTokenService authenticationTokenService)
        {
            _currentContext = currentContext;
            _authenticationTokenService = authenticationTokenService;
        }

        public MemberProfile GetMemberProfile()
        {
            if (umbraco.library.IsLoggedOn())
            {
                return GetMemberProfile(_currentContext.User.Identity.Name);
            }

            throw new SecurityException("user not logged in");
        }

        public MemberProfile GetMemberProfile(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("userName");

            var member = Security.Membership.GetUser(userName);

            if (member != null)
            {
                return MemberProfile.GetUserProfile(userName);
            }

            throw new SecurityException("user not logged in");
        }

        public void UpdateMemberProfile(string userName, MemberProfile memberProfile)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("userName");
            if (memberProfile == null) throw new ArgumentNullException("memberProfile");

            var member = Security.Membership.GetUser(userName);

            if (member == null) throw new SecurityException();

            var currentProfile = MemberProfile.GetUserProfile(member.UserName);

            if (currentProfile == null) throw new SecurityException("no profile found for user");

            currentProfile.FirstName = memberProfile.FirstName;
            currentProfile.LastName = memberProfile.LastName;
            currentProfile.Location = memberProfile.Location;
            currentProfile.Industry = memberProfile.Industry;
            currentProfile.IsIncludedInInvitationList = memberProfile.IsIncludedInInvitationList;

            currentProfile.Save();
        }

        public IAuthenticationToken Login(string userName, string password, bool rememberMe)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException("password");
            if (!Security.Membership.ValidateUser(userName, password)) throw new SecurityException("unknown user");

            Security.FormsAuthentication.SetAuthCookie(userName, rememberMe);

            return _authenticationTokenService.Generate(userName);
        }

        public bool IsAuthenticated(string userName)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("userName");

            if (_currentContext.User == null) return false;

            // TODO: umbraco wraps Identity.IsAuthenticated, but also has side effect of logging the member (back) in 
            // is that what we want?
            //return _currentContext.User.Identity.IsAuthenticated;

            return umbraco.library.IsLoggedOn();
        }

        public void Register(string userName, string password, string roleName, MemberProfile memberProfile)
        {
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("userName");
            if (string.IsNullOrEmpty(userName)) throw new ArgumentNullException("password");
            if (memberProfile == null) throw new ArgumentNullException("memberProfile");

            // validate
            // TODO: valadate the memberprofile model
            // consider data annotations and validationrunner
            // see https://bitbucket.org/benmcevoy/webforms.framework/src/b71ea66b106ca47d1150f941fa875768393e26e4/Webforms.Framework/Validation/ValidationRunner.cs?at=default

            if (Security.Membership.GetUser(userName) != null)
            {
                throw new SecurityException("user name already registered");
            }

            // create user
            var user = Security.Membership.CreateUser(userName, password, memberProfile.UserName);

            // add to role
            Security.Roles.AddUserToRole(user.UserName, roleName);

            // create profile
            var profile = ProfileBase.Create(userName); 
            UpdateMemberProfile(userName, profile as MemberProfile);

            // log them in
            Security.FormsAuthentication.SetAuthCookie(user.UserName, true);
        }

        public string ResetPassword(string userName)
        {
            var user = Security.Membership.GetUser(userName);

            if (user == null) throw new SecurityException("unknown user");

            return user.ResetPassword();
        }
    }
}