Imports System.IO

Public Class Signup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Session("user") Is Nothing Then
            Response.Redirect("Login.aspx")
        End If
    End Sub

    Private Function UsernameExists(username As String, filePath As String) As Boolean
        If Not File.Exists(filePath) Then Return False

        Try
            Dim lines As String() = File.ReadAllLines(filePath)
            For Each line As String In lines
                Dim parts() As String = line.Split(","c)
                If parts.Length > 0 AndAlso parts(0).Equals(username, StringComparison.OrdinalIgnoreCase) Then
                    Return True
                End If
            Next
        Catch ex As Exception
            ' Optionally log the error or handle it
            ' For now, just return False so signup can proceed
            Return False
        End Try

        Return False
    End Function

    Private Sub ShowMessage(message As String, isError As Boolean)
        lblError.Text = message
        If isError Then
            lblError.ForeColor = System.Drawing.Color.Red
        Else
            lblError.ForeColor = System.Drawing.Color.Green
        End If
    End Sub

    Protected Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim filePath As String = Server.MapPath("~/App_Data/users.txt")

        If username = "" OrElse password = "" Then
            ShowMessage("Please fill in both fields.", True)
            Return
        End If

        If UsernameExists(username, filePath) Then
            ShowMessage("Username taken.", True)
            Return
        End If

        Try
            Using writer As New StreamWriter(filePath, True)
                writer.WriteLine(username & "," & password)
            End Using
        Catch ex As Exception
            ShowMessage("Error saving user. Try again later.", True)
            Return
        End Try

        ShowMessage("User signed up successfully!", False)

        Session("user") = username
        Response.Redirect("Dashboard.aspx")
    End Sub

    Protected Sub btnGoback_Click(sender As Object, e As EventArgs) Handles btnGoback.Click
        Response.Redirect("Dashboard.aspx")
    End Sub

End Class