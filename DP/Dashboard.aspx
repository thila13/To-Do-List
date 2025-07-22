<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="Dashboard.aspx.vb" Inherits="DP.Dashboard" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
    <link rel="stylesheet" type="text/css" href="Content/Dashboard.css?v=7" />
    <script type="text/javascript">
        var tasksFromServer = <%= Newtonsoft.Json.JsonConvert.SerializeObject(Session("Tasks")) %>;

    </script>
    <script src="TypeScripts/reminders.js?v=123"></script>
    <script src="TypeScripts/popup.js"></script>
</head>
<body>
    <form id="form1" runat="server" DefaultButton="btnAddTask">
        
        <!-- NAVBAR -->
        <div class="navbar">
            <h1>Dashboard</h1>
            <div id="navbar-buttons">
              <asp:Button class="btn" id="btnManageUsers" runat="server" Text="Manage Users" OnClientClick="showUserPopup(); return false;" Style="display: none;" />
                <asp:Button class="btn" id="btnLogout" runat="server" Text="Log Out" OnClick="btnLogout_Click"  UseSubmitBehavior="false" />
            </div>
        </div>

       
        <!-- TO-DO SECTION -->
        <div class="main-content">
            <div class="dashboard-container">
                <div class="dashboard-card">
            <h2 class="card-title">To-Do List</h2>

            <!-- Input row for task and due date -->
            <div class="task-form">
                <div class="form-row">
                    <asp:TextBox ID="txtTask" runat="server" CssClass="task-input" placeholder="Enter a new task..."></asp:TextBox>
                    <asp:TextBox ID="txtDueDate" runat="server" CssClass="date-input" TextMode="Date"></asp:TextBox>
                    <asp:Button ID="btnAddTask" runat="server" Text="Add Task" CssClass="btn btn-add" OnClick="btnAddTask_Click" />
                </div>
            </div>

            <!-- Clear button -->
                <asp:Button ID="btnClearTasks" runat="server" Text="Clear Tasks" CssClass="btn-clear" OnClick="btnClearTasks_Click" />
            
            <!-- Repeater to list tasks -->
            <asp:Repeater ID="rptTasks" runat="server" OnItemCommand="rptTasks_ItemCommand">
                <ItemTemplate>
                    <div class='task-list <%# Eval("CssClass") %>'>
                        <span class="task-text">
                            <%# Eval("Text") %>
                            <%# If(String.IsNullOrEmpty(Eval("CssClass").ToString()), "", " (" & Eval("CssClass") & ")") %>
                        </span>
                        <asp:Button runat="server" CommandArgument='<%# Container.ItemIndex %>' CommandName="Edit" Text="✏️" CssClass="todo-edit" />
                        <asp:Button runat="server" CommandArgument='<%# Container.ItemIndex %>' CommandName="Delete" Text="🗑️" CssClass="todo-delete" />
                        <asp:Button runat="server" CommandArgument='<%# Container.ItemIndex %>' CommandName="Complete" Text="✅" CssClass="todo-complete" />
                        <span class="task-date"><%# Eval("DueDate") %></span>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
                </div>
            </div>
        </div>

        <asp:Label ID="lblDebug" runat="server" ForeColor="Red" />


    </form>
     <!-- Popup Overlay -->
     <div id="userPopup" class="popup-overlay">
      <div class="popup">
          <div class="popup-header">
              <h3 class="popup-tile">manage users</h3>
              <div class="close-btn">
                <button onclick="closeUserPopup()">close</button>
              </div>
          </div>
          <div class="popup-content">
            <div id="userListContainer"></div>
          </div>
      </div>
    </div>
</body>
</html>
