    <%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="DP.Login" %>  

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Login.css" />
    <script type="module" src="TypeScripts/log.js"></script>
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnLogin">
        <div class="loginBox">

            <div class="header">
                <h1>Welcome</h1>
                <p>Log in to continue your jurney</p>
            </div>

            <div class="form-group">
                <label for="username">Username</label>
            </div>

            <div class="input-wrapper">
                <asp:TextBox ID="txtUsername" runat="server" />
            </div>

            <div class="form-group">
                <label for="password">Password</label>
            </div>
            <div class="input-wrapper">
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />
            </div>

            <asp:HiddenField ID="hiddenLogin" runat="server" />
            <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" UseSubmitBehavior="false" />

            <p>Dont have a account?</p>
            <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" CssClass="nav-btn" UseSubmitBehavior="false" />

            <asp:Label ID="lblError" runat="server" ForeColor="White" />
        </div>
    </form>
</body>
</html>

