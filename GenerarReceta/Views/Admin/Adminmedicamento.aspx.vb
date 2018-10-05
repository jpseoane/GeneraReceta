Public Class Adminmedicamento
    Inherits System.Web.UI.Page

    Private medDao As New MedicamentoDAO



    Private Property CampoOrden() As String
        Get
            If ViewState("CampoOrden") Is Nothing Or ViewState("CampoOrden") = "" Then
                Return "descripcion"
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


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("id") <> "" Then
                Dim medicamento As Medicamento = medDao.ObtenerMedicamento(Request.QueryString("id"))
                If Not medicamento Is Nothing Then
                    Me.txtDescripcion.Value = medicamento.Descripcion
                    Me.txtDosis.Value = medicamento.Dosis
                    Me.txtCantporcaja.Value = medicamento.Cantporcaja
                    Me.txtDroga.Value = medicamento.Droga
                    Me.txtLaboratorio.Value = medicamento.Laboratorio
                    btnActualizar.Visible = True
                Else
                    Response.Write("<script LANGUAGE='JavaScript' >alert('No se puede cargar el medicamento!')</script>")
                    CargarGrid()
                End If
            Else
                CargarGrid()
            End If
        End If
    End Sub
    Private Sub CargarGrid()
        gvMedicamento.DataSource = medDao.ObtenerListado(CampoOrden, TipoOrden)
        gvMedicamento.DataBind()
    End Sub
    Protected Sub gvmedicamentos_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvMedicamento.RowCommand
        Select Case e.CommandName
            Case "Editar"
                Response.Redirect("Adminmedicamento.aspx?id= " & Convert.ToInt32(e.CommandArgument))
            Case "Borrar"
                Dim itemDao As New ItemRecetaDAO
                MensajeMedicamento.Visible = True
                If Not itemDao.ExisteMedicamentoEnItemReceta(e.CommandArgument) Then
                    If medDao.Borrar(Convert.ToInt32(e.CommandArgument)) Then
                        Me.MensajeMedicamento.Attributes.Add("class", "alert alert-success")
                        MensajeMedicamento.InnerText = "medicamento eliminado exitosamente"
                    Else
                        Me.MensajeMedicamento.Attributes.Add("class", "alert alert-warning")
                        MensajeMedicamento.InnerText = "Error al eliminar"
                    End If
                Else
                    Me.MensajeMedicamento.Attributes.Add("class", "alert alert-warning")
                    MensajeMedicamento.InnerText = "El medicamento forma parte de una receta existente. No se puede eliminar"
                End If
                CargarGrid()
        End Select
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim medicamento As New medicamento
        medicamento.ID = Request.QueryString("id")
        medicamento.Descripcion = Me.txtDescripcion.Value
        medicamento.Dosis = Me.txtDosis.Value
        medicamento.Cantporcaja = Me.txtCantporcaja.Value
        medicamento.Droga = Me.txtDroga.Value
        medicamento.Laboratorio = Me.txtLaboratorio.Value
        MensajeMedicamento.Visible = True
        If medDao.Actualizar(medicamento) Then
            Me.MensajeMedicamento.Attributes.Add("class", "alert alert-success")
            MensajeMedicamento.InnerText = "medicamento actualizado exitosamente"
        Else
            Me.MensajeMedicamento.Attributes.Add("class", "alert alert-warning")
            MensajeMedicamento.InnerText = "Error en la actualizacion"
        End If
        btnActualizar.Visible = False
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        btnActualizar.Visible = False
        MensajeMedicamento.Visible = False

        Me.txtDescripcion.Value = ""
        Me.txtDosis.Value = ""
        Me.txtCantporcaja.Value = ""
        Me.txtDroga.Value = ""
        Me.txtLaboratorio.Value = ""

    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        gvMedicamento.DataSource = medDao.ObtenerListado()
        gvMedicamento.DataBind()
        limpiar()
    End Sub

    Protected Sub gvMedicamento_Sorting(sender As Object, e As GridViewSortEventArgs) Handles gvMedicamento.Sorting
        If TipoOrden = "asc" Then
            TipoOrden = "desc"
        Else
            TipoOrden = "asc"
        End If
        CampoOrden = e.SortExpression
        Me.gvMedicamento.PageIndex = 0
        CargarGrid()
    End Sub

    Protected Sub gvMedicamento_PageIndexChanging(sender As Object, e As GridViewPageEventArgs) Handles gvMedicamento.PageIndexChanging
        gvMedicamento.PageIndex = e.NewPageIndex
        CargarGrid()
    End Sub
End Class
