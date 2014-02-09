using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using LocalLinked.Umbraco.Profile;
using LocalLinked.Umbraco.Services;

namespace LocalLinked.Umbraco.usercontrols.Membership
{
    public partial class Register : System.Web.UI.UserControl
    {
        private readonly MembershipService _membership = new MembershipService();

        protected void Page_Load(object sender, EventArgs e)
        {
            // is user is already logged on, redirect to home page (doesn't make sense to register when already logged in...)
            if (umbraco.library.IsLoggedOn())
            {
                Response.Redirect("~/");
            }
        }

        protected void OnCreatedUser(object sender, EventArgs e)
        {
            var createUserWizard = (CreateUserWizard)sender;
            var template = createUserWizard.CreateUserStep.ContentTemplateContainer;

            _membership.UpdateMemberProfile(createUserWizard.UserName, 
                new MemberProfile
                    {
                        FirstName = ((TextBox)template.FindControl("FirstName")).Text,
                        LastName = ((TextBox)template.FindControl("LastName")).Text,
                        Location = ((TextBox)template.FindControl("Location")).Text,
                        Industry = ((TextBox)template.FindControl("Industry")).Text,
                        IsIncludedInInvitationList = ((CheckBox)template.FindControl("IsIncludedInInvitationList")).Checked
                    });

            Roles.AddUserToRole(createUserWizard.UserName, MemberGroups.SiteMembers);

            // log them in
            FormsAuthentication.SetAuthCookie(createUserWizard.UserName, true);

            // TODO: what to do?
            Response.Redirect("~/");
        }
    }
}
