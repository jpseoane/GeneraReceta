Public Class Nuevoafiliado
    Inherits System.Web.UI.Page

    Dim afiDao As AfiliadoDAO
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Page.IsPostBack Then
            If Request.QueryString("id") <> "" Then
                Dim afiliado As Afiliado = afiDao.Obtenerafiliado(Request.QueryString("id"))
                Me.txtNombre.Value = afiliado.Nombre
                Me.txtApellido.Value = ""
                Me.txtFechaNac.Value = ""
                Me.txtNumAfi.Value = ""
                Me.txtOficina.Value = ""
            End If
        End If
        txtFechaNac.Attributes("margin") = "0px !important;"
        txtFechaNac.Attributes("border-radius") = "0.25rem;"
    End Sub

    Protected Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Dim afiliadoNuevo As New Afiliado(Me.txtNombre.Value, Me.txtApellido.Value, Me.txtOficina.Value, Me.txtNumAfi.Value, Me.txtFechaNac.Value)

        Me.txtEdad.Value = afiliadoNuevo.Edad
        Dim afiDao As New AfiliadoDAO

        MensajeAfiliado.Visible = True
        Dim mensaje As String = afiDao.Guardar(afiliadoNuevo)

        If mensaje = "" Then
            Me.MensajeAfiliado.Attributes.Add("class", "alert alert-success")
            MensajeAfiliado.InnerText = "Afiliado cargado exitosamente"
        Else
            Me.MensajeAfiliado.Attributes.Add("class", "alert alert-warning")
            MensajeAfiliado.InnerText = "Error en la carga. Detalle del error: " & mensaje
        End If

      
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        MensajeAfiliado.Visible = False
        Me.txtNombre.Value = ""
        Me.txtApellido.Value = ""
        Me.txtFechaNac.Value = ""
        Me.txtNumAfi.Value = ""
        Me.txtOficina.Value = ""
    End Sub


End Class
