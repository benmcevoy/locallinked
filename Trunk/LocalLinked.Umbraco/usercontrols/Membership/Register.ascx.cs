using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Web.Profile;
using LocalLinked.Umbraco.Profile;
using Security = System.Web.Security;
using LocalLinked.Umbraco.Services;

namespace LocalLinked.Umbraco.usercontrols.Membership
{
    public partial class Register : System.Web.UI.UserControl
    {
        private MembershipService _membership = new MembershipService();

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
                    ((TextBox)template.FindControl("FirstName")).Text,
                    ((TextBox)template.FindControl("LastName")).Text,
                    ((TextBox)template.FindControl("Location")).Text,
                    ((TextBox)template.FindControl("Industry")).Text,
                    ((CheckBox)template.FindControl("IsIncludedInInvitationList")).Checked
                );
            
            Roles.AddUserToRole(createUserWizard.UserName, MemberGroups.SiteMembers);

            // log them in
            FormsAuthentication.SetAuthCookie(createUserWizard.UserName, true);

            // TODO: what to do?
            Response.Redirect("~/");
        }
    }
}
