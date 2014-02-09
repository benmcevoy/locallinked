using LocalLinked.Umbraco.Profile;

namespace LocalLinked.Umbraco.Services.Membership
{
    public interface IMembershipService
    {
        /// <summary>
        /// Get current users MemberProfile
        /// </summary>
        /// <returns>MemberProfile or null if not found</returns>
        MemberProfile GetMemberProfile();

        /// <summary>
        /// Get this users MemberProfile or null if not found
        /// </summary>
        /// <returns>MemberProfile or null if not found</returns>
        MemberProfile GetMemberProfile(string userName);

        void UpdateMemberProfile(string userName, MemberProfile memberProfile);

        IAuthenticationToken Login(string userName, string password, bool rememberMe);

        bool IsAuthenticated(string userName);

        void Register(string userName, string password, string roleName, MemberProfile memberProfile);

        string ResetPassword(string userName);
    }
}