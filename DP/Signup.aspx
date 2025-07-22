<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Signup.aspx.vb" Inherits="DP.Signup" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Signup.css" />
    <script type="module" src="TypeScripts/log.js"></script>
    <title>Sign Up</title>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnSignup">
        <div class="signupBox">
            <div class="header">
                <h1>Create a account</h1>
                <p>Join and manage tasks now</p>
            </div>

            <div class="form-group">
                <label for="username">Enter Username:</label>
            </div>
            <div class="input-wrapper">
                <asp:TextBox ID="txtUsername" runat="server" />
            </div>

            <div class="form-group">
                <label for="password">Enter Password:</label>
            </div>

            <div class="input-wrapper">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>

            <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" UseSubmitBehavior="false" />

            <asp:Label ID="lblError" runat="server" ForeColor="Red" />

            <asp:Button ID="btnGoback" runat="server" Text="Go back to Login" OnClick="btnGoback_Click" CausesValidation="false" UseSubmitBehavior="false" />
        </div>
    </form>
</body>
</html>

