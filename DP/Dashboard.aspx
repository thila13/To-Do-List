<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="DP.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="Content/Dashboard.css?v=4" />
        <script type="module" src="TypeScripts/log.js"></script>
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnSignup">
        <div id="navbar">
            <span id="navbar-title">Dashboard</span>
            <div id="navbar-buttons">
                <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" UseSubmitBehavior="false" />
                <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" UseSubmitBehavior="false" />
            </div>
        </div>
    </form>
</body>
</html>


