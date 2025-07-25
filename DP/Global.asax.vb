﻿Imports System.Web.Http
Imports System.Web.Mvc
Imports System.Web.Routing

Public Class Global_asax
    Inherits HttpApplication

    Sub Application_Start(sender As Object, e As EventArgs)
        ' Fires when the application is started
        AreaRegistration.RegisterAllAreas()
        GlobalConfiguration.Configure(AddressOf WebApiConfig.Register)
        RouteConfig.RegisterRoutes(RouteTable.Routes)
    End Sub

    Private Sub Global_asax_PostAuthenticateRequest(sender As Object, e As EventArgs) Handles Me.PostAuthenticateRequest
        System.Web.HttpContext.Current.SetSessionStateBehavior(
        SessionStateBehavior.Required)
    End Sub
End Class