Public Class ItemRecetaDAO
    Private cxItemReceta As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
    Private OleComItemReceta As New OleDb.OleDbCommand("", cxItemReceta)
    Private QryItemReceta As New OleDb.OleDbCommand("", cxItemReceta)
    Private medDao As New MedicamentoDAO
    Private Function obtenerItemReceta(ByVal id As Integer) As ItemReceta
        Dim OleDRItemReceta As OleDb.OleDbDataReader = Nothing
        Dim itemReceta As New ItemReceta
        Try
            Dim SdrItemReceta As OleDb.OleDbDataReader = Nothing

            QryItemReceta.CommandText = ""
            QryItemReceta.CommandText += "SELECT [id] ,[receta_id] ,[medicamento_id] ,[cantidad], isnull([fecha],01/01/2999) AS [fecha] FROM itemreceta Where id= " & id

            cxItemReceta.Open()
            OleDRItemReceta = QryItemReceta.ExecuteReader
            If OleDRItemReceta.HasRows Then
                OleDRItemReceta.Read()
                itemReceta.ID = OleDRItemReceta("id")
                itemReceta.RecetaId = OleDRItemReceta("receta_id")
                itemReceta.Medicamento.ID = OleDRItemReceta("medicamento_id")
                itemReceta.Cantidad = OleDRItemReceta("cantidad")
                itemReceta.Fecha = OleDRItemReceta("fecha")
            End If
            cxItemReceta.Close()
        Catch ex As OleDb.OleDbException
            itemReceta = Nothing
        Finally
            cxItemReceta.Close()
        End Try
        Return itemReceta
    End Function


    Public Function ExisteMedicamentoEnItemReceta(ByVal id As Integer) As Boolean
        Dim cxExiste As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
        Dim OleDRItemReceta As OleDb.OleDbDataReader = Nothing
        Dim dbComandItemReceta As New OleDb.OleDbCommand("", cxExiste)
        Dim existe As Boolean = False
        Try
            Dim SdrItemReceta As OleDb.OleDbDataReader = Nothing

            dbComandItemReceta.CommandText = ""
            dbComandItemReceta.CommandText += "SELECT receta_id FROM itemreceta Where medicamento_id= " & id

            cxExiste.Open()
            OleDRItemReceta = dbComandItemReceta.ExecuteReader
            If OleDRItemReceta.HasRows Then
                existe = True
            End If
            dbComandItemReceta = Nothing
            OleDRItemReceta = Nothing
            cxExiste.Close()
        Catch ex As OleDb.OleDbException
            existe = True
        Finally
            cxExiste.Close()
        End Try
        Return existe
    End Function


    Public Function Actualizar(ByVal ItemReceta As ItemReceta) As Boolean
        Dim TransOk As Boolean = True
        Try
            cxItemReceta.Open()
            OleComItemReceta.CommandText = " UPDATE [itemreceta] SET "
            OleComItemReceta.CommandText += "[receta_id] = '" & ItemReceta.RecetaId & "'"
            OleComItemReceta.CommandText += ",[medicamento_id] = '" & ItemReceta.Medicamento.ID & "'"

            OleComItemReceta.CommandText += ",[cantidad] = " & ItemReceta.Cantidad & ""

            If Not (ItemReceta.Fecha.Year = 2999 Or ItemReceta.Fecha.Year = 1) Then
                OleComItemReceta.CommandText += ",[fecha_nacimiento] = '" & ItemReceta.Fecha.ToString("dd/MM/yyyy HH:mm") & "'"
            End If

            OleComItemReceta.CommandText += " WHERE ID = " & ItemReceta.ID

            OleComItemReceta.ExecuteNonQuery()
            cxItemReceta.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxItemReceta.Close()
        End Try
        Return TransOk
    End Function
    Public Function Borrar(ByVal id As Integer) As Boolean
        Dim TransOk As Boolean = True
        Try
            cxItemReceta.Open()
            OleComItemReceta.CommandText = " DELETE [itemreceta] WHERE ID = " & id
            OleComItemReceta.ExecuteNonQuery()
            cxItemReceta.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxItemReceta.Close()
        End Try
        Return TransOk
    End Function


    Public Function BorrarXRecetaId(ByVal id As Integer) As Boolean
        Dim TransOk As Boolean = True
        Try
            cxItemReceta.Open()
            OleComItemReceta.CommandText = " DELETE [itemreceta] WHERE receta_id = " & id
            OleComItemReceta.ExecuteNonQuery()
            cxItemReceta.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxItemReceta.Close()
        End Try
        Return TransOk
    End Function


    Public Function ObtenerListado() As List(Of ItemReceta)
        Dim OleDRitemReceta As OleDb.OleDbDataReader = Nothing
        Dim lstitemReceta As New List(Of ItemReceta)
        Dim TransOk As Boolean = True
        Try
            Dim qrySelect As String = ""
            qrySelect = " SELECT [id] ,[receta_id] ,[medicamento_id] ,[cantidad], isnull([fecha],01/01/2999) AS [fecha] FROM itemreceta"
            QryItemReceta.CommandText = qrySelect
            cxItemReceta.Open()
            OleDRitemReceta = QryItemReceta.ExecuteReader
            If OleDRitemReceta.HasRows Then
                While OleDRitemReceta.Read()
                    Dim medicamento As New Medicamento
                    medicamento = medDao.ObtenerMedicamento(OleDRitemReceta("medicamento_id"))
                    Dim itemReceta As New ItemReceta(OleDRitemReceta("id"), OleDRitemReceta("receta_id"), medicamento, OleDRitemReceta("cantidad"), OleDRitemReceta("fecha"))
                    lstitemReceta.Add(itemReceta)
                End While
            End If
            cxItemReceta.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxItemReceta.Close()
        End Try
        Return lstitemReceta
    End Function

    Public Function ObtenerListadoXidReceta(ByVal idReceta As Integer) As List(Of ItemReceta)
        Dim OleDRitemReceta As OleDb.OleDbDataReader = Nothing
        Dim lstitemReceta As New List(Of ItemReceta)
        Dim TransOk As Boolean = True
        Try
            Dim qrySelect As String = ""
            qrySelect = " SELECT [id] ,[receta_id] ,[medicamento_id] ,[cantidad], isnull([fecha],01/01/2999) AS [fecha] FROM itemreceta Where receta_id=" & idReceta
            QryItemReceta.CommandText = qrySelect
            cxItemReceta.Open()
            OleDRitemReceta = QryItemReceta.ExecuteReader
            If OleDRitemReceta.HasRows Then
                While OleDRitemReceta.Read()
                    Dim medicamento As New Medicamento
                    medicamento = medDao.ObtenerMedicamento(OleDRitemReceta("medicamento_id"))
                    Dim itemReceta As New ItemReceta(OleDRitemReceta("id"), OleDRitemReceta("receta_id"), medicamento, OleDRitemReceta("cantidad"), OleDRitemReceta("fecha"))
                    lstitemReceta.Add(itemReceta)
                End While
            End If
            cxItemReceta.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxItemReceta.Close()
        End Try
        Return lstitemReceta
    End Function
End Class
