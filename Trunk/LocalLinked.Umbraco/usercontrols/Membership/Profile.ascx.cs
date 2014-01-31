using System;
using System.Web;
using LocalLinked.Umbraco.Profile;
using LocalLinked.Umbraco.Services;

namespace LocalLinked.Umbraco.usercontrols.Membership
{
    public partial class Profile : System.Web.UI.UserControl
    {
        private MembershipService _membership = new MembershipService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        private void Bind()
        {
            var profile = _membership.GetMemberProfile();

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
                _membership.UpdateMemberProfile(
                        FirstName.Text,
                        LastName.Text,
                        Location.Text,
                        Industry.Text,
                        IsIncludedInInvitationList.Checked);
            }
        }
    }
}