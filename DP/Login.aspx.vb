Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports DP.PerdoruesitDataSetTableAdapters

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    End Sub

    ' SHA-256 Hash
    Private Function HashFunction(input As String) As String
        Using sha As SHA256 = SHA256.Create()
            Dim bytes = Encoding.UTF8.GetBytes(input)
            Dim hash = sha.ComputeHash(bytes)
            Return BitConverter.ToString(hash).Replace("-", "").ToLower()
        End Using
    End Function

    ' Login button click
    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim inputUsername As String = txtUsername.Text.Trim()
        Dim inputPassword As String = txtPassword.Text.Trim()

        If String.IsNullOrWhiteSpace(inputUsername) OrElse String.IsNullOrWhiteSpace(inputPassword) Then
            lblError.Text = "Please enter both username and password."
            Return
        End If

        Dim hashedPassword As String = HashFunction(inputPassword)

        Try
            ' Theret storedprocedure
            Dim adapter As New sp_LoginUserTableAdapter()
            Dim result As DataTable = adapter.GetDataLogin(inputUsername, hashedPassword)

            If result.Rows.Count > 0 Then
                Dim username As String = result.Rows(0)("Username").ToString().ToLower()
                Session("user") = username
                Session("Username") = username ' ✅ This is the fix
                Response.Redirect("Dashboard.aspx")
            Else
                lblError.Text = "Invalid username or password."
            End If

        Catch ex As Exception
            lblError.Text = "Error connecting to database."
        End Try
    End Sub

    Protected Sub btnSignup_Click(sender As Object, e As EventArgs) Handles btnSignup.Click
        Response.Redirect("Signup.aspx")
    End Sub

End Class
