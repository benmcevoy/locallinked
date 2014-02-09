using System.Web;
using LocalLinked.Umbraco.Profile;

namespace LocalLinked.Umbraco.Services
{
    public class MembershipService
    {
        private readonly HttpContext _context;

        public MembershipService()
        {
            _context = HttpContext.Current;
        }

        /// <summary>
        /// Get current users MemberProfile
        /// </summary>
        /// <returns>MemberProfile or null if not found</returns>
        public MemberProfile GetMemberProfile()
        {
            if (umbraco.library.IsLoggedOn())
            {
                return GetMemberProfile(_context.User.Identity.Name);
            }

            return null;
        }

        /// <summary>
        /// Get this users MemberProfile or null if not found
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>MemberProfile or null if not found</returns>
        public MemberProfile GetMemberProfile(string userName)
        {
            var user = System.Web.Security.Membership.GetUser(userName);

            if (user != null)
            {
                return MemberProfile.GetUserProfile(user.UserName);
            }

            return null;
        }

        /// <summary>
        /// Update current users MemberProfile or null if not found
        /// </summary>
        public void UpdateMemberProfile(MemberProfile memberProfile)
        {
            UpdateMemberProfile(_context.User.Identity.Name, memberProfile);
        }

        /// <summary>
        /// Update this users MemberProfile
        /// </summary>
        public void UpdateMemberProfile(string userName, MemberProfile memberProfile)
        {
            var user = System.Web.Security.Membership.GetUser(userName);

            if (user != null)
            {
                var currentProfile = MemberProfile.GetUserProfile(user.UserName);

                currentProfile.FirstName = memberProfile.FirstName;
                currentProfile.LastName = memberProfile.LastName;
                currentProfile.Location = memberProfile.Location;
                currentProfile.Industry = memberProfile.Industry;
                currentProfile.IsIncludedInInvitationList = memberProfile.IsIncludedInInvitationList;

                currentProfile.Save();
            }
        }
    }
}