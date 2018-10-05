Imports System.Data.SqlClient

Public Class ConsultaDao
    Private cxConsultaDao As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
    Private OleComConsultaDao As New OleDb.OleDbCommand("", cxConsultaDao)
    Private QryConsultaDao As New OleDb.OleDbCommand("", cxConsultaDao)
    Private medDao As New MedicamentoDAO
    Public Function obtenerDetalleRecetaXID(ByVal idReceta As Integer) As DataTable
        Dim cxdetalle As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
        Dim dTDetalleReceta As New DataTable

        Dim QRY As String = ""
        Try
            Dim qryHijos As String = ""

            QRY = ""

            QRY += " Select ir.[id]"
            QRY += " ,[receta_id]"
            QRY += " ,[medicamento_id]"
            QRY += " ,m.descripcion      "
            QRY += " ,m.dosis       "
            QRY += " ,ir.cantidad"
            QRY += " ,ir.fecha"
            QRY += " FROM [itemreceta] ir"
            QRY += " INNER JOIN  receta r "
            QRY += " ON ir.receta_id= r.id"
            QRY += " INNER JOIN  medicamento m "
            QRY += " ON ir.medicamento_id= m.id"
            QRY += " WHERE receta_id=" & idReceta

            Dim sqlDAdetReceta As New OleDb.OleDbDataAdapter(QRY, cxConsultaDao)

            sqlDAdetReceta.Fill(dTDetalleReceta)
            

        Catch ex As OleDb.OleDbException

        Finally
            cxdetalle.Close()
        End Try
        Return dTDetalleReceta
    End Function

End Class
