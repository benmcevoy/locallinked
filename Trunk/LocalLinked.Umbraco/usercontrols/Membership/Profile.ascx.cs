using System;
using LocalLinked.Umbraco.Profile;
using LocalLinked.Umbraco.Services;

namespace LocalLinked.Umbraco.usercontrols.Membership
{
    public partial class Profile : System.Web.UI.UserControl
    {
        private readonly MembershipService _membershipService = new MembershipService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            var profile = _membershipService.GetMemberProfile();

            if (profile != null)
            {
                UserName.Text = profile.UserName;
                FirstName.Text = profile.FirstName;
                LastName.Text = profile.LastName;
                Location.Text = profile.Location;
                Industry.Text = profile.Industry;
                IsIncludedInInvitationList.Checked = profile.IsIncludedInInvitationList;
            }
        }

        protected void UpdateButton_Click(object sender, EventArgs e)
        {
            if (umbraco.library.IsLoggedOn())
            {
                _membershipService.UpdateMemberProfile(new MemberProfile
                {
                    FirstName = FirstName.Text,
                    LastName = LastName.Text,
                    Location = Location.Text,
                    Industry = Industry.Text,
                    IsIncludedInInvitationList = IsIncludedInInvitationList.Checked
                });
            }
        }
    }
}