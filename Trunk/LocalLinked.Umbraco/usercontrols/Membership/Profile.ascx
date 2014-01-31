<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Profile.ascx.cs" Inherits="LocalLinked.Umbraco.usercontrols.Membership.Profile" %>

<fieldset>
    <div class="field">
        <label for="UserName">Email (User Name):</label>
        <asp:Label runat="server" ID="UserName" />
    </div>

<%--    
    <div class="field">
        <label for="Password">Password:</label>
        <asp:TextBox runat="server" TextMode="Password" ClientIDMode="Static" ID="Password" />
        <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" 
            ErrorMessage="Password is required" Display="Dynamic" />
    </div>
--%>

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

    <div>
        <asp:Button runat="server" CausesValidation="true" id="UpdateButton" Text="Update" onclick="UpdateButton_Click" />
    </div>
</fieldset>

<script type="text/javascript">
    $("#Location").autocomplete("/services/location.ashx");
    $("#Industry").autocomplete("/services/industry.ashx");
</script>