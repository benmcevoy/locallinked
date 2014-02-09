using System;
using System.Security;
using System.Web.Profile;
using System.Web.Security;

namespace LocalLinked.Umbraco.Profile
{
    public class MemberProfile : ProfileBase
    {
        public static MemberProfile GetUserProfile(string username)
        {
            return Create(username) as MemberProfile;
        }

        public static MemberProfile GetUserProfile()
        {
            var member = Membership.GetUser();

            if(member == null) throw new SecurityException("user not logged in");

            return Create(member.UserName) as MemberProfile;
        }

        private string GetValue(string propertyName)
        {
            var o = base.GetPropertyValue(propertyName);

            if (o == DBNull.Value)
            {
                return string.Empty;
            }

            return (string)o;
        }

        [SettingsAllowAnonymous(false)]
        public string FirstName
        {
            get { return GetValue("member_firstName"); }
            set { base.SetPropertyValue("member_firstName", value); }
        }

        [SettingsAllowAnonymous(false)]
        public string LastName
        {
            get { return GetValue("member_lastName"); }
            set { base.SetPropertyValue("member_lastName", value); }
        }

        [SettingsAllowAnonymous(false)]
        public string Location
        {
            get { return GetValue("member_location"); }
            set { base.SetPropertyValue("member_location", value); }
        }

        [SettingsAllowAnonymous(false)]
        public string Industry
        {
            get { return GetValue("member_industry"); }
            set { base.SetPropertyValue("member_industry", value); }
        }

        [SettingsAllowAnonymous(false)]
        public bool IsIncludedInInvitationList
        {
            get 
            {
                var o = base.GetPropertyValue("member_isIncludedInInvitationList");

                if (o == DBNull.Value)
                {
                    return false;
                }

                return (int)o == 1;
            }
            set 
            {
                var v = value ? 1 : 0;
                base.SetPropertyValue("member_isIncludedInInvitationList", v); 
            }
        }
    }
}
