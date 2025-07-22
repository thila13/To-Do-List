Imports System.Security.Cryptography
Imports System.Text
Imports DP.PerdoruesitDataSetTableAdapters

Public Class Signup
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    ' Hash password  SHA-256
    Private Function HashPassword(input As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(input)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    Private Sub ShowMessage(message As String, isError As Boolean)
        lblError.Text = message
        lblError.ForeColor = If(isError, Drawing.Color.Red, Drawing.Color.Green)
    End Sub

    Protected Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then
            ShowMessage("Please fill in both fields.", True)
            Return
        End If

        Dim hashedPassword As String = HashPassword(password)

        Try
            Dim adapter As New MerrPerrdoruesitTableAdapter()
            adapter.sp_KrijoPerdorues(username, hashedPassword)

            Session("user") = username
            ShowMessage("E krijove ene nji, je bo si lepurat!", False)
            Response.Redirect("Login.aspx")

        Catch ex As Exception
            ShowMessage("Error creating user. Maybe username already exists?", True)
        End Try
    End Sub

    Protected Sub btnGoback_Click(sender As Object, e As EventArgs) Handles btnGoback.Click
        Response.Redirect("Login.aspx")
    End Sub
End Class
