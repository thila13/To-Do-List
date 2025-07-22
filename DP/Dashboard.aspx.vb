Imports System.IO
Imports Newtonsoft.Json

Public Class TaskItem
    Public Property Text As String
    Public Property IsCompleted As Boolean
    Public Property DueDate As String
End Class

Partial Public Class Dashboard
    Inherits System.Web.UI.Page

    Protected WithEvents btnLogout As Button
    Protected WithEvents btnSignup As Button
    Protected WithEvents btnClearTasks As Button
    Protected WithEvents btnAddTask As Button
    Protected WithEvents txtTask As TextBox
    Protected WithEvents txtDueDate As TextBox
    Protected WithEvents rptTasks As Repeater

    Private ReadOnly Property TasksFilePath As String
        Get
            Dim username As String = Session("user").ToString()
            Return Server.MapPath($"~/App_Data/{username}_tasks.txt")
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim username As String = TryCast(Session("Username"), String)

            lblDebug.Text = "Logged in as: " & If(username, "(null)")

            If username = "admin" Then
                btnManageUsers.Style("display") = "inline-block"
            Else
                btnManageUsers.Style("display") = "none"
            End If
        End If
    End Sub



    Protected Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        SaveTasksToFile(CType(Session("Tasks"), List(Of TaskItem)))
        Session.Clear()
        Session.Abandon()
        Response.Redirect("Login.aspx")
    End Sub

    Protected Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Response.Redirect("Signup.aspx")
    End Sub

    Protected Sub btnClearTasks_Click(sender As Object, e As EventArgs) Handles btnClearTasks.Click
        Session("Tasks") = New List(Of TaskItem)()
        ViewState("EditIndex") = Nothing
        btnAddTask.Text = "Add Task"
        BindTasks()

        Try
            File.WriteAllText(TasksFilePath, "")
        Catch ex As Exception
            ' Optional: handle/log error
        End Try
    End Sub

    Protected Sub btnAddTask_Click(sender As Object, e As EventArgs) Handles btnAddTask.Click
        Dim tasks As List(Of TaskItem) = TryCast(Session("Tasks"), List(Of TaskItem))
        If tasks Is Nothing Then
            tasks = New List(Of TaskItem)()
        End If

        Dim newText As String = txtTask.Text.Trim()
        Dim dueDate As String = txtDueDate.Text.Trim()

        If Not String.IsNullOrEmpty(newText) Then
            If ViewState("EditIndex") IsNot Nothing Then
                Dim editIndex As Integer = CType(ViewState("EditIndex"), Integer)
                tasks(editIndex).Text = newText
                tasks(editIndex).DueDate = dueDate
                ViewState("EditIndex") = Nothing
                btnAddTask.Text = "Add Task"
            Else
                tasks.Add(New TaskItem With {
                .Text = newText,
                .IsCompleted = False,
                .DueDate = dueDate
            })
            End If
        End If

        txtTask.Text = ""
        txtDueDate.Text = ""
        Session("Tasks") = tasks
        BindTasks()
    End Sub


    Protected Sub rptTasks_ItemCommand(source As Object, e As RepeaterCommandEventArgs) Handles rptTasks.ItemCommand
        Dim tasks As List(Of TaskItem) = CType(Session("Tasks"), List(Of TaskItem))
        Dim index As Integer = Convert.ToInt32(e.CommandArgument)

        Select Case e.CommandName
            Case "Delete"
                tasks.RemoveAt(index)
                If ViewState("EditIndex") IsNot Nothing AndAlso CType(ViewState("EditIndex"), Integer) = index Then
                    ViewState("EditIndex") = Nothing
                    btnAddTask.Text = "Add Task"
                    txtTask.Text = ""
                    txtDueDate.Text = ""
                End If

            Case "Complete"
                tasks(index).IsCompleted = True

            Case "Edit"
                txtTask.Text = tasks(index).Text
                txtDueDate.Text = tasks(index).DueDate
                ViewState("EditIndex") = index
                btnAddTask.Text = "Update Task"
        End Select

        Session("Tasks") = tasks
        BindTasks()
    End Sub

    Private Sub BindTasks()
        Dim tasks As List(Of TaskItem) = CType(Session("Tasks"), List(Of TaskItem))
        rptTasks.DataSource = tasks.Select(Function(t)
                                               Dim cssClass As String = ""
                                               Dim parsedDate As Date

                                               ' Parse using ISO format (yyyy-MM-dd)
                                               If Date.TryParseExact(t.DueDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, Globalization.DateTimeStyles.None, parsedDate) Then
                                                   If parsedDate.Date < Date.Today Then
                                                       cssClass = "overdue"
                                                   ElseIf parsedDate.Date = Date.Today Then
                                                       cssClass = "due-today"
                                                   End If
                                               End If

                                               Return New With {
            .Text = If(t.IsCompleted, "✅ " & t.Text, t.Text),
            .DueDate = t.DueDate,
            .CssClass = cssClass
        }
                                           End Function).ToList()

        rptTasks.DataBind()
    End Sub



    Private Sub SaveTasksToFile(tasks As List(Of TaskItem))
        If tasks Is Nothing Then Return ' ← Add this line to skip saving if tasks is null

        Using writer As New StreamWriter(TasksFilePath, False)
            For Each task In tasks
                writer.WriteLine($"{task.Text}|{task.IsCompleted}|{task.DueDate}")
            Next
        End Using
    End Sub


    Private Function LoadTasksFromFile() As List(Of TaskItem)
        Dim tasks As New List(Of TaskItem)()
        If File.Exists(TasksFilePath) Then
            For Each line As String In File.ReadAllLines(TasksFilePath)
                Dim parts = line.Split("|"c)
                If parts.Length = 3 Then
                    tasks.Add(New TaskItem With {
                        .Text = parts(0),
                        .IsCompleted = Boolean.Parse(parts(1)),
                        .DueDate = parts(2)
                    })
                End If
            Next
        End If
        Return tasks
    End Function
End Class
