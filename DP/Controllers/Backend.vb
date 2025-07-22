Imports System.Data.SqlClient
Imports System.Web.Http
Imports System.Configuration
Imports DP.PerdoruesitDataSetTableAdapters



<RoutePrefix("api/Backend")>
Public Class BackendController
    Inherits ApiController

    Public Class Requests
        Public Property Useri As String
        Public Property Password As String
        Public Property UserID As Integer
    End Class

    <HttpPost>
    <Route("DeleteUser")>
    Public Function DeleteUser(req As Requests) As IHttpActionResult
        System.Diagnostics.Debug.WriteLine("DeleteUser called with ID: " & req.UserID)

        Try
            Dim adapter As New MerrPerrdoruesitTableAdapter()
            adapter.sp_DeleteUser(req.UserID)
            Return Ok()
        Catch ex As Exception
            Return InternalServerError(ex)
        End Try
    End Function


    <HttpGet>
    <Route("Perdoruesit")>
    Public Function GetPerdoruesit() As IHttpActionResult

        Dim adapter As New MerrPerrdoruesitTableAdapter()
        Dim dataTable As DataTable = adapter.GetDataPerdoruesit()

        Dim users As New List(Of Object)
        For Each row As DataRow In dataTable.Rows
            users.Add(New With {
            .UserID = row("UserID"),
            .Username = row("Username").ToString()
        })
        Next

        Return Ok(users)
    End Function

    <HttpGet>
    <Route("TestApi")>
    Public Function TestApi() As String
        Return "API is working!"
    End Function
End Class

