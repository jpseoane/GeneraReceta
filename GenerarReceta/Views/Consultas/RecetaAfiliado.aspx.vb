
Public Class RecetaAfiliado
    Inherits System.Web.UI.Page

    Private lista As New List(Of Medicamento)
    Public Property ListaMed() As List(Of Medicamento)
        Get
            If ViewState("ListaMed") <> "" Then
                Return ViewState("ListaMed")
            Else

                Return lista
            End If
        End Get
        Set(ByVal value As List(Of Medicamento))
            lista = value
            ViewState("lista") = lista
        End Set
    End Property

    Public Property RecetaSession As Receta
        Get
            Return Session("Receta")
        End Get
        Set(ByVal value As Receta)
            Session("Receta") = lista
        End Set
    End Property

    Dim afiDao As New AfiliadoDAO
    Dim medDao As New MedicamentoDAO
    Dim recDao As New RecetaDAO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            CargaGrid()
            ddlAfiliados.DataSource = afiDao.ObtenerListado()
            ddlAfiliados.DataBind()
        End If
    End Sub


    Private Sub CargaGrid()

        Dim cxadmReceta As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
        Dim QryReceta As New OleDb.OleDbCommand("", cxadmReceta)


        Try
            QryReceta.CommandText = ""
            QryReceta.CommandText += " SELECT r.[id] id,[id_afiliado],a.apellido afiliado,[tipo],[cant_total] cantidadTotal,[observaciones] observacion,"
            QryReceta.CommandText += " isnull([fecha_actual],01/01/2999) AS [fechaactual] ,"
            QryReceta.CommandText += " isnull([fecha_anterior],01/01/2999) AS [fechaanterior] FROM [receta] r "
            QryReceta.CommandText += " INNER JOIN afiliado a ON r.id_afiliado=a.id "

            cxadmReceta.Open()
            gvRecetas.DataSource = QryReceta.ExecuteReader
            gvRecetas.DataBind()
            cxadmReceta.Close()
        Catch ex As OleDb.OleDbException
            MensajeRecetaAfiliado.Visible = True
            Me.MensajeRecetaAfiliado.Attributes.Add("class", "alert alert-warning")
            MensajeRecetaAfiliado.InnerText = "Error al cargar la vista"
        Finally
            cxadmReceta.Close()
        End Try

    End Sub

    Public Function GetCompletionList(ByVal prefixText As String, ByVal count As Integer)
        Dim pacDao As New AfiliadoDAO

        Dim listAfiliados As List(Of Afiliado) = pacDao.ObtenerListado()
        Return listAfiliados
    End Function




    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        gvRecetas.DataSource = Nothing
        gvRecetas.DataBind()
        Me.txtNombre.Value = ""
        Me.txtApellido.Value = ""
    End Sub




    Protected Sub gvRecetas_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvRecetas.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.RowType <> DataControlRowType.Header And e.Row.RowType <> DataControlRowType.Pager Then

                Dim divExpander As New HtmlGenericControl
                divExpander = e.Row.FindControl("divExp")

                Dim gvDetalleReceta As New GridView
                gvDetalleReceta = e.Row.FindControl("gvDetalleReceta")


                Dim conDAO As New ConsultaDao

                gvDetalleReceta.DataSource = conDAO.obtenerDetalleRecetaXID(Me.gvRecetas.DataKeys(e.Row.RowIndex).Values("id"))

                gvDetalleReceta.DataBind()
                divExpander.Visible = True

            End If
        End If

    End Sub

    Protected Sub gvRecetas_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvRecetas.RowCommand
        Select Case e.CommandName
            Case "Repetir"
                Response.Redirect("../NuevaReceta.aspx?id= " & Convert.ToInt32(e.CommandArgument))
        End Select
    End Sub
End Class
