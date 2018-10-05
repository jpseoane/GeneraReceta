
Public Class Adminafiliado
    Inherits System.Web.UI.Page

    Private Property CampoOrden() As String
        Get
            If ViewState("CampoOrden") Is Nothing Or ViewState("CampoOrden") = "" Then
                Return "apellido"
            Else
                Return ViewState("CampoOrden")
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("CampoOrden") = Value
        End Set
    End Property

    Private Property TipoOrden() As String
        Get
            If ViewState("TipoOrden") Is Nothing Or ViewState("TipoOrden") = "" Then
                Return "desc"
            Else
                Return ViewState("TipoOrden")
            End If
        End Get
        Set(ByVal Value As String)
            ViewState("TipoOrden") = Value
        End Set
    End Property

    Private afiDao As New AfiliadoDAO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then

            If Request.QueryString("id") <> "" Then
                Dim afiliado As Afiliado = afiDao.Obtenerafiliado(Request.QueryString("id"))
                Me.txtNombre.Value = afiliado.Nombre
                Me.txtApellido.Value = afiliado.Apellido
                Me.txtFechaNac.Value = afiliado.FechaNacimiento.ToString("yyyy-MM-dd")
                Me.txtNumAfi.Value = afiliado.NumeroAfiliado
                Me.txtOficina.Value = afiliado.Oficina
                btnActualizar.Visible = True
            Else
                cargargrid()
            End If
        End If
        txtFechaNac.Attributes("margin") = "0px !important;"
        txtFechaNac.Attributes("border-radius") = "0.25rem;"
    End Sub

    Protected Sub gvAfiliados_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvAfiliados.RowCommand
        Select Case e.CommandName
            Case "Editar"
                Response.Redirect("Adminafiliado.aspx?id= " & Convert.ToInt32(e.CommandArgument))
            Case "Borrar"
                If afiDao.Borrar(Convert.ToInt32(e.CommandArgument)) Then
                    Me.MensajeAfiliado.Attributes.Add("class", "alert alert-success")
                    MensajeAfiliado.InnerText = "Afiliado eliminado exitosamente"
                Else
                    Me.MensajeAfiliado.Attributes.Add("class", "alert alert-warning")
                    MensajeAfiliado.InnerText = "Error al eliminar"
                End If
        End Select
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim afiliado As New Afiliado
        afiliado.ID = Request.QueryString("id")
        afiliado.Nombre = Me.txtNombre.Value
        afiliado.Apellido = Me.txtApellido.Value
        afiliado.FechaNacimiento = Me.txtFechaNac.Value
        afiliado.NumeroAfiliado = Me.txtNumAfi.Value
        afiliado.Oficina = Me.txtOficina.Value
        MensajeAfiliado.Visible = True

        If afiDao.Actualizar(afiliado) Then
            Me.MensajeAfiliado.Attributes.Add("class", "alert alert-success")
            MensajeAfiliado.InnerText = "Afiliado actualizado exitosamente"
        Else
            Me.MensajeAfiliado.Attributes.Add("class", "alert alert-warning")
            MensajeAfiliado.InnerText = "Error en la actualizacion"
        End If
        btnActualizar.Visible = False
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        btnActualizar.Visible = False
        MensajeAfiliado.Visible = False
        Me.txtNombre.Value = ""
        Me.txtApellido.Value = ""
        Me.txtFechaNac.Value = ""
        Me.txtNumAfi.Value = ""
        Me.txtOficina.Value = ""
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        cargargrid()
        limpiar()
    End Sub
    Private Sub cargargrid()
        gvAfiliados.DataSource = afiDao.ObtenerListado(CampoOrden, TipoOrden)
        gvAfiliados.DataBind()
    End Sub
    Protected Sub gvAfiliados_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvAfiliados.PageIndexChanging
        gvAfiliados.PageIndex = e.NewPageIndex
        cargargrid()
    End Sub

    Protected Sub gvAfiliados_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvAfiliados.Sorting
        If TipoOrden = "asc" Then
            TipoOrden = "desc"
        Else
            TipoOrden = "asc"
        End If
        CampoOrden = e.SortExpression
        Me.gvAfiliados.PageIndex = 0
        cargargrid()
    End Sub
End Class
