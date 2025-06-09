<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="DP.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" type="text/css" href="Content/Dashboard.css?v=6" />
    <script type="module" src="TypeScripts/log.js"></script>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnAddTask">
        
        <!-- NAVBAR -->
        <div id="navbar">
            <span id="navbar-title">Dashboard</span>
            <div id="navbar-buttons">
                <asp:Button ID="btnSignup" runat="server" Text="Sign Up" OnClick="btnSignup_Click" CssClass="nav-btn" UseSubmitBehavior="false" />
                <asp:Button ID="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click" CssClass="nav-btn" UseSubmitBehavior="false" />
            </div>
        </div>

        <!-- TO-DO SECTION -->
        <div id="todoSection">
            <h2>To-Do List</h2>

            <!-- Input row for task and due date -->
            <div class="task-input-row">
                <asp:TextBox ID="txtTask" runat="server" CssClass="task-input" placeholder="Enter a new task..."></asp:TextBox>
                <asp:TextBox ID="txtDueDate" runat="server" CssClass="task-date-picker" TextMode="Date"></asp:TextBox>
                <asp:Button ID="btnAddTask" runat="server" Text="Add Task" CssClass="add-task-btn" OnClick="btnAddTask_Click" />
            </div>

            <!-- Clear button -->
            <div class="clear-button-container">
                <asp:Button ID="btnClearTasks" runat="server" Text="Clear Tasks" CssClass="clear-btn" OnClick="btnClearTasks_Click" />
            </div>

            <!-- Repeater to list tasks -->
            <asp:Repeater ID="rptTasks" runat="server" OnItemCommand="rptTasks_ItemCommand">
                <ItemTemplate>
                    <div class="todo-item">
                        <span class="task-text"><%# Eval("Text") %></span>
                        <asp:Button runat="server" CommandArgument='<%# Container.ItemIndex %>' CommandName="Edit" Text="✏️" CssClass="todo-edit" />
                        <asp:Button runat="server" CommandArgument='<%# Container.ItemIndex %>' CommandName="Delete" Text="🗑️" CssClass="todo-delete" />
                        <asp:Button runat="server" CommandArgument='<%# Container.ItemIndex %>' CommandName="Complete" Text="✅" CssClass="todo-complete" />
                        <span class="task-date"><%# Eval("DueDate") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </form>
</body>
</html>
