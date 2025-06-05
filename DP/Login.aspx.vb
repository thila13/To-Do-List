Imports System.IO

Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim inputUsername As String = txtUsername.Text.Trim()
        Dim inputPassword As String = txtPassword.Text.Trim()

        Dim filePath As String = Server.MapPath("~/App_Data/users.txt")
        Dim isValidUser As Boolean = False

        ' Open the file and check credentials
        If File.Exists(filePath) Then
            For Each line As String In File.ReadLines(filePath)
                Dim parts() As String = line.Split(","c)
                If parts.Length = 2 Then
                    Dim fileUsername As String = parts(0).Trim()
                    Dim filePassword As String = parts(1).Trim()

                    If fileUsername = inputUsername AndAlso filePassword = inputPassword Then
                        isValidUser = True
                        Exit For
                    End If
                End If
            Next
        Else
            lblError.Text = "User database not found."
            Return
        End If

        If isValidUser Then
            Session("user") = inputUsername
            Response.Redirect("Dashboard.aspx")
        Else
            lblError.Text = "Invalid username or password."
        End If
    End Sub


End Class