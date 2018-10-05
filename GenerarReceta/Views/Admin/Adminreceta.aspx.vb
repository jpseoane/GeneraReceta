
Public Class Adminreceta
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


    Private itemRecetaDao As New ItemRecetaDAO
    Private recetaDao As New RecetaDAO
    Private afiDao As New AfiliadoDAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            ddlAfiliado.DataSource = afiDao.ObtenerListado
            ddlAfiliado.DataBind()
            CargaGrid()
            If Request.QueryString("id") <> "" Then
                Dim receta As Receta = recetaDao.obtenerReceta(Request.QueryString("id"))
                Dim afiliado As Afiliado = afiDao.Obtenerafiliado(receta.AfiliadoID)
                'Afiliado
                Me.txtNombre.Value = afiliado.Nombre
                Me.txtApellido.Value = afiliado.Apellido
                Me.txtNumAfi.Value = afiliado.NumeroAfiliado
                Me.txtOficina.Value = afiliado.Oficina
                'Receta
                Me.txtFechaReceta.Value = receta.FechaActual
                Me.txtFechaAntReceta.Value = receta.FechaAnterior
                Me.txtObservacion.Text = receta.Observacion
                Me.txtCantTotal.Value = receta.CantidadTotal

                Me.txtFechaReceta.Value = receta.FechaActual.ToString("yyyy-MM-dd")

                If Not (receta.FechaAnterior.Year = 1 Or receta.FechaAnterior.Year = 2999) Then
                    Me.txtFechaAntReceta.Value = receta.FechaAnterior.ToString("yyyy-MM-dd")
                End If

                btnActualizar.Visible = True

                ddlAfiliado.SelectedValue = receta.AfiliadoID
                ddlAfiliado.DataBind()
                ddlTipoReceta.SelectedValue = receta.Tipo.Trim
                ddlTipoReceta.DataBind()
                divAfiliado.Visible = True
            End If
        End If
    End Sub



    Private Sub CargaGrid()
        Dim cxadmReceta As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
        Dim QryReceta As String = ""
        Dim dtRecetas As New DataTable
        Try
            QryReceta = ""
            QryReceta += " SELECT r.[id],[id_afiliado],a.apellido afiliado,[tipo],[cant_total] cantidadTotal,[observaciones] observacion,"
            QryReceta += " isnull([fecha_anterior],01/01/2999) AS [fechaanterior], fecha_actual as fechaactual FROM [receta] r "
            QryReceta += " INNER JOIN afiliado a ON r.id_afiliado=a.id "
            QryReceta += " ORDER BY " & CampoOrden & " " & TipoOrden

            Dim sbReceta As New OleDb.OleDbDataAdapter(QryReceta, cxadmReceta)
            sbReceta.Fill(dtRecetas)
            gvReceta.DataSource = dtRecetas
            gvReceta.DataBind()


        Catch ex As OleDb.OleDbException
            MensajeReceta.Visible = True
            Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
            MensajeReceta.InnerText = "Error al cargar la vista"
        Finally
            cxadmReceta.Close()
        End Try

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim receta As New Receta
        receta.ID = Request.QueryString("id")

        receta.FechaActual = Me.txtFechaReceta.Value
        receta.Observacion = Me.txtObservacion.Text
        receta.CantidadTotal = Me.txtCantTotal.Value

        receta.AfiliadoID = ddlAfiliado.SelectedValue
        receta.Tipo = ddlTipoReceta.SelectedValue


        If recetaDao.Actualizar(receta) Then
            Me.MensajeReceta.Attributes.Add("class", "alert alert-success")
            MensajeReceta.InnerText = "Receta actualizada exitosamente"
        Else
            Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
            MensajeReceta.InnerText = "Error en la actualizacion"
        End If
        MensajeReceta.Visible = True
        btnActualizar.Visible = False
    End Sub
    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        'Afiliado
        Me.txtNombre.Value = ""
        Me.txtApellido.Value = ""
        Me.txtNumAfi.Value = ""
        Me.txtOficina.Value = ""
        'Receta
        Me.txtFechaReceta.Value = ""
        Me.txtFechaAntReceta.Value = ""
        Me.txtObservacion.Text = ""
        Me.txtCantTotal.Value = ""
        btnActualizar.Visible = False
        MensajeReceta.Visible = False
        divAfiliado.Visible = False
    End Sub
    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        CargaGrid()
        limpiar()
    End Sub
    Protected Sub gvReceta_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvReceta.RowCommand
        Select Case e.CommandName
            Case "Editar"
                Response.Redirect("Adminreceta.aspx?id= " & Convert.ToInt32(e.CommandArgument))
            Case "Borrar"
                If recetaDao.BorrarRecetaconItems(Convert.ToInt32(e.CommandArgument)) Then
                    Me.MensajeReceta.Attributes.Add("class", "alert alert-success")
                    MensajeReceta.InnerText = "Receta eliminada exitosamente"
                Else
                    Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
                    MensajeReceta.InnerText = "Error al eliminar"
                End If
        End Select
    End Sub

    Protected Sub ddlAfiliado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAfiliado.SelectedIndexChanged
        Dim afiliado As New Afiliado
        afiliado = afiDao.Obtenerafiliado(ddlAfiliado.SelectedValue)
        Me.txtNombre.Value = afiliado.Nombre
        Me.txtApellido.Value = afiliado.Apellido
        Me.txtOficina.Value = afiliado.Oficina
        Me.txtNumAfi.Value = afiliado.NumeroAfiliado

    End Sub

    Protected Sub gvReceta_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvReceta.Sorting
        If TipoOrden = "asc" Then
            TipoOrden = "desc"
        Else
            TipoOrden = "asc"
        End If
        CampoOrden = e.SortExpression
        Me.gvReceta.PageIndex = 0
        CargaGrid()
    End Sub

    Protected Sub gvReceta_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvReceta.PageIndexChanging
        gvReceta.PageIndex = e.NewPageIndex
        CargaGrid()
    End Sub
End Class
