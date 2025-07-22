Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web.Http
Imports System.Net.Http
Imports System.Web.Http.Routing

Public Module WebApiConfig
    Public Sub Register(ByVal config As HttpConfiguration)
        ' Web API configuration and services

        ' Web API routes
        config.MapHttpAttributeRoutes()



        config.Routes.MapHttpRoute(
            name:="DefaultApi",
            routeTemplate:="api/{controller}/{action}/{id}",
            defaults:=New With {.id = RouteParameter.Optional}
        )

        For Each route In config.Routes
            Debug.WriteLine("ROUTE: " & route.RouteTemplate)
        Next

    End Sub
End Module
