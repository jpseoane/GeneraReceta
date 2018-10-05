Public Class Nuevoreceta
    Inherits System.Web.UI.Page

    Dim afiDao As New AfiliadoDAO
    Dim medDao As New MedicamentoDAO
    Dim recDao As New RecetaDAO

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            Dim lstAfiliados As List(Of Afiliado) = afiDao.ObtenerListado()
            Dim Afiselec As New Afiliado
            Afiselec.Apellido = "Seleccionar"
            Afiselec.ID = 0
            lstAfiliados.Add(Afiselec)

            ddlAfiliado.DataTextField = ("apellido")
            ddlAfiliado.DataValueField = ("id")
            ddlAfiliado.DataSource = lstAfiliados
            ddlAfiliado.DataBind()
            ddlAfiliado.SelectedValue = 0

            CargaComboMedicamentos()

            If Request.QueryString("id") <> "" Then
                Dim repetirReceta As Receta = recDao.obtenerReceta(Request.QueryString("id"))
                CargarAfiliado(afiDao.Obtenerafiliado(repetirReceta.AfiliadoID))
                agregar(recDao.obtenerItemsReceta(Request.QueryString("id")))
            End If
        End If
    End Sub
    Private Sub CargaComboMedicamentos()
        Dim lstMedicamentos As List(Of Medicamento) = medDao.ObtenerListado()
        Dim medicamento As New Medicamento
        medicamento.Descripcion = "Seleccionar"
        medicamento.ID = 0
        lstMedicamentos.Add(medicamento)

        ddlMedicamentos.DataTextField = ("descripcion")
        ddlMedicamentos.DataValueField = ("id")
        ddlMedicamentos.DataSource = lstMedicamentos
        ddlMedicamentos.DataBind()
        ddlMedicamentos.SelectedValue = 0
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        MensajeReceta.Visible = True
        GuardarReceta()
    End Sub
    Private Sub GuardarReceta()
        MensajeReceta.Visible = True
        Dim dt As New DataTable
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")


        If Not Session("datos") Is Nothing Then
            dt = Session("datos")
        End If

        If dt.Rows.Count > 0 Then
            Try
                Dim ListItemReceta As New List(Of ItemReceta)
                For Each row As DataRow In dt.Rows
                    If Not medDao.ObtenerMedicamento(row("id").ToString()) Is Nothing Then
                        Dim itemReceta As New ItemReceta
                        itemReceta.Medicamento = medDao.ObtenerMedicamento(row("id").ToString())
                        itemReceta.Cantidad = (row("cantidad").ToString())
                        ListItemReceta.Add(itemReceta)
                    Else
                        Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
                        MensajeReceta.InnerText = "Uno o varios medicamentos ya no existen en la BBDD. No se puede cargar la receta"
                        Exit Sub
                    End If
                Next

                Dim Receta As New Receta
                'ASIGNO AFILIADO A RECETA
                Receta.AfiliadoID = ddlAfiliado.SelectedValue
                Receta.Tipo = Me.ddlTipoReceta.SelectedValue
                Receta.Observacion = txtObservacion.Text

                If recDao.Guardar(Receta, ListItemReceta) Then
                    Me.MensajeReceta.Attributes.Add("class", "alert alert-success")
                    MensajeReceta.InnerText = "Receta cargado exitosamente"
                Else
                    Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
                    MensajeReceta.InnerText = "Error en la carga"
                End If

            Catch ex As Exception
                Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
                MensajeReceta.InnerText = "Error en la carga"
            Finally
                Session.Remove("datos")
                limpiar()
            End Try
        Else
            limpiar()
            Me.MensajeReceta.Attributes.Add("class", "alert alert-warning")
            MensajeReceta.InnerText = "Agregue medicamentos"
        End If
    End Sub
    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
    Private Sub limpiar()
        gvListMed.DataSource = Nothing
        gvListMed.DataBind()
        Me.txtNombre.Value = ""
        Me.txtApellido.Value = ""
    End Sub

    Protected Sub ddlAfiliado_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ddlAfiliado.SelectedIndexChanged
        CargarAfiliado(afiDao.Obtenerafiliado(ddlAfiliado.SelectedValue))
    End Sub
    Private Sub CargarAfiliado(ByVal afiliado As Afiliado)
        '    Dim receta As New Receta
        Me.txtNombre.Value = afiliado.Nombre
        Me.txtApellido.Value = afiliado.Apellido
        Me.txtOficina.Value = afiliado.Oficina
        Me.txtNumAfiliado.Value = afiliado.NumeroAfiliado
    End Sub

    Protected Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        agregar()
    End Sub

    Private Sub agregar(Optional ByVal list As List(Of ItemReceta) = Nothing)
        Dim itemreceta As New Receta

        Dim dt As New DataTable
        Dim dRow As DataRow
        dt.Columns.Add("id")
        dt.Columns.Add("descripcion")
        dt.Columns.Add("cantidad")
        If list Is Nothing Then
            If Not Session("datos") Is Nothing Then
                dt = Session("datos")
            End If

            dRow = dt.NewRow
            dRow("id") = ddlMedicamentos.SelectedValue
            dRow("descripcion") = ddlMedicamentos.SelectedItem.Text
            dRow("cantidad") = txtCantidad.Value
            dt.Rows.Add(dRow)
        Else
            For Each item As ItemReceta In list
                dRow = dt.NewRow
                dRow("id") = item.Medicamento.ID
                dRow("descripcion") = item.Medicamento.Descripcion
                dRow("cantidad") = item.Cantidad
                dt.Rows.Add(dRow)
            Next
            dt.AcceptChanges()
        End If
        Session("datos") = dt
        gvListMed.DataSource = dt
        gvListMed.DataBind()
        Me.ddlMedicamentos.ClearSelection()
    End Sub
    Protected Sub gvListMed_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles gvListMed.RowCommand
        Dim dt As New DataTable
        Dim rowEliminar As DataRow = Nothing

        If Not Session("datos") Is Nothing Then
            dt = Session("datos")
        End If

        For Each drow As DataRow In dt.Rows
            If drow("id") = Convert.ToInt32(e.CommandArgument) Then
                rowEliminar = drow
                Exit For
            End If
        Next
        dt.Rows.Remove(rowEliminar)
        dt.AcceptChanges()

        Session("datos") = dt

        gvListMed.DataSource = dt
        gvListMed.DataBind()

    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        CargaComboMedicamentos()
    End Sub

End Class
