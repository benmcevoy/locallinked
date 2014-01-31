<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Register.ascx.cs" Inherits="LocalLinked.Umbraco.usercontrols.Membership.Register" %>
<asp:LoginView runat="server">
    <AnonymousTemplate>
        <asp:CreateUserWizard runat="server" LoginCreatedUser="True" DisableCreatedUser="false"
            RequireEmail="false" OnCreatedUser="OnCreatedUser">
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStepControl" runat="server">
                    <ContentTemplate>
                        <div class="field">
                            <label for="UserName">Email (User Name):</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="UserName" />
                            <asp:RegularExpressionValidator runat="server" ControlToValidate="UserName" ErrorMessage="Not a valid email"
                                Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="UserName" Display="Dynamic"
                                ErrorMessage="Email is required" />
                        </div>
                        <div class="field">
                            <label for="Password">Password:</label>
                            <asp:TextBox runat="server" TextMode="Password" ClientIDMode="Static" ID="Password" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" ErrorMessage="Password is required"
                                Display="Dynamic" />
                        </div>
                        <div class="field">
                            <label for="ConfirmPassword">Confirm Password:</label>
                            <asp:TextBox runat="server" TextMode="Password" ClientIDMode="Static" ID="ConfirmPassword" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="Password is required"
                                Display="Dynamic" />
                            <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password"
                                ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="The Password and Confirmation Password must match." />
                        </div>
                        <div class="field">
                            <label for="FirstName">First Name:</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="FirstName" />
                        </div>
                        <div class="field">
                            <label for="LastName">Last Name:</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="LastName" />
                        </div>
                        <div class="field">
                            <label for="Location">Location:</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="Location" />
                        </div>
                        <div class="field">
                            <label for="Industry">Industry:</label>
                            <asp:TextBox runat="server" ClientIDMode="Static" ID="Industry" />
                        </div>
                        <div class="field">
                            <label for="IsIncludedInInvitationList">Is Included In Invitation List:</label>
                            <asp:CheckBox runat="server" Checked="true" ClientIDMode="Static" ID="IsIncludedInInvitationList" />
                        </div>
                        <div class="field">
                            <%--this field must be here for the wizard to display any error messages--%>
                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </ContentTemplate>
                    <CustomNavigationTemplate>
                        <asp:Button runat="server" CausesValidation="true" Text="Register" CommandName="MoveNext" />
                    </CustomNavigationTemplate>
                </asp:CreateUserWizardStep>
            </WizardSteps>
        </asp:CreateUserWizard>
    </AnonymousTemplate>
</asp:LoginView>
<script type="text/javascript">
    $("#Location").autocomplete("/services/location.ashx");
    $("#Industry").autocomplete("/services/industry.ashx");
</script>
