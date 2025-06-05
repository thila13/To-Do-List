<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="DP.Login" %>  

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Login.css" />
    <title>Login</title>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnLogin">
        <div id="loginBox">
            <label for="username">Username:</label>
            <asp:TextBox ID="txtUsername" runat="server" />

            <label for="password">Password:</label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" />

            <asp:HiddenField ID="hiddenLogin" runat="server" />
            <asp:Button ID="btnLogin" runat="server" Text="Log In" OnClick="btnLogin_Click" UseSubmitBehavior="false" />

            <asp:Label ID="lblError" runat="server" ForeColor="Red" />
        </div>
    </form>
</body>
</html>

