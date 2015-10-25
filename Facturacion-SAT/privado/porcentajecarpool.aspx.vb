﻿Imports Microsoft.VisualBasic
Imports System.Data
Imports MySql.Data.MySqlClient
Partial Class privado_porcentajecarpool
    Inherits System.Web.UI.Page
    Dim CodPage As Integer = 1008
    Dim datos As New datos()

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        infoMenu()
        If Not datos.acceso(Request.Cookies("UserSettings")("user"), CodPage) Then
            Response.Redirect("403")
        End If
    End Sub
    Sub infoMenu()
        If (Not Request.Cookies("UserSettings") Is Nothing) Then
            LblUsuario.Text = Request.Cookies("UserSettings")("user")
            LblUser.Text = Request.Cookies("UserSettings")("user")
            ImagenMenu.ImageUrl = "images/perfil/" & Request.Cookies("UserSettings")("Imagen")
            ImagenUsuario.ImageUrl = "images/perfil/" & Request.Cookies("UserSettings")("Imagen")
        Else
            Dim myCookie As HttpCookie
            myCookie = New HttpCookie("UserSettings")
            myCookie.Expires = DateTime.Now.AddDays(-1D)
            Response.Cookies.Add(myCookie)
            Response.Redirect("~/login")
        End If
    End Sub
End Class