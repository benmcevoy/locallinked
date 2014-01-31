using System;
using System.Web;
using System.Web.Security;
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
            var user = Membership.GetUser(userName);

            if (user != null)
            {
                return MemberProfile.GetUserProfile(user.UserName);
            }

            return null;
        }

        /// <summary>
        /// Update current users MemberProfile or null if not found
        /// </summary>
        /// <param name="profile"></param>
        public void UpdateMemberProfile(string firstName, string lastName, string location, string industry, bool isIncludedInInvitationList)
        {
            UpdateMemberProfile(_context.User.Identity.Name, firstName, lastName, location, industry, isIncludedInInvitationList);
        }

        /// <summary>
        /// Update this users MemberProfile
        /// </summary>
        /// <remarks>
        /// TODO: not sure I like this method? IT's DRY but it does not add much
        /// </remarks>
        /// <param name="userName"></param>
        /// <param name="profile"></param>
        public void UpdateMemberProfile(string userName, string firstName, string lastName, string location, string industry, bool isIncludedInInvitationList)
        {
            var user = Membership.GetUser(userName);

            if (user != null)
            {
                var currentProfile = MemberProfile.GetUserProfile(user.UserName);

                currentProfile.FirstName = firstName;
                currentProfile.LastName = lastName;
                currentProfile.Location = location;
                currentProfile.Industry = industry;
                currentProfile.IsIncludedInInvitationList = isIncludedInInvitationList;

                currentProfile.Save();
            }
        }
    }
}