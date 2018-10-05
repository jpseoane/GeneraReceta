Public Class Nuevomedicamento
    Inherits System.Web.UI.Page

    Dim medDao As MedicamentoDAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("id") <> "" Then
                Dim medicamento As medicamento = medDao.Obtenermedicamento(Request.QueryString("id"))
                Me.txtDescripcion.Value = medicamento.Descripcion
                Me.txtDosis.Value = medicamento.Dosis
                Me.txtCantidadxCaja.Value = medicamento.Cantporcaja
                Me.txtLaboratorio.Value = medicamento.Laboratorio
                Me.txtDroga.Value = medicamento.Droga
            End If
        End If
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim medicamentoNuevo As New Medicamento(Me.txtDescripcion.Value, Me.txtDosis.Value, Me.txtCantidadxCaja.Value, Me.txtDroga.Value, Me.txtLaboratorio.Value)

        Dim medicamentoDao As New medicamentoDAO
        Mensajemedicamento.Visible = True
        If medicamentoDao.Guardar(medicamentoNuevo) Then
            Me.Mensajemedicamento.Attributes.Add("class", "alert alert-success")
            Mensajemedicamento.InnerText = "medicamento cargado exitosamente"
        Else
            Me.Mensajemedicamento.Attributes.Add("class", "alert alert-warning")
            Mensajemedicamento.InnerText = "Error en la carga"
        End If

        ''***** FECHAS **************
        ''FECHA DE NOVEDAD
        'nuevaEntrada.FechaNov = Me.txtFecing.Text.Trim

        ''FECHA DE MOVIMIENTO
        'Dim dtFecha As DateTime = DateTime.Now
        'nuevaEntrada.FechaMov = dtFecha.ToString("dd/MM/yyyy")
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        Mensajemedicamento.Visible = False
        Me.txtDescripcion.Value = ""
        Me.txtDosis.Value = ""
        Me.txtCantidadxCaja.Value = ""
        Me.txtLaboratorio.Value = ""
        Me.txtDroga.Value = ""
    End Sub


End Class
