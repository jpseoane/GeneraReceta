Public Class MedicamentoDAO
    Private cxMedicamento As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
    Private OleComMedicamento As New OleDb.OleDbCommand("", cxMedicamento)
    Private QryMedicamento As New OleDb.OleDbCommand("", cxMedicamento)
    Public Function Guardar(ByVal medicamento As Medicamento) As Boolean
        Dim TransOk As Boolean = True
        Try
            Dim estado As String = cxMedicamento.State
            cxMedicamento.Open()
            OleComMedicamento.CommandText = " INSERT INTO [Medicamento] ([descripcion],[dosis],[cantporcaja],[fecha_entrada],[droga],[laboratorio]) "
            OleComMedicamento.CommandText += " VALUES('" & medicamento.Descripcion & "','" & medicamento.Dosis & "'," & medicamento.Cantporcaja & ",'" & Date.Now.ToString("dd/MM/yyyy HH:mm") & "',"
            OleComMedicamento.CommandText += " '" & medicamento.Droga & "','" & medicamento.Laboratorio & "') "
            OleComMedicamento.ExecuteNonQuery()
            cxMedicamento.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxMedicamento.Close()
        End Try
        Return TransOk
    End Function
    Public Function Actualizar(ByVal Medicamento As Medicamento) As Boolean
        Dim TransOk As Boolean = True
        Try

            cxMedicamento.Open()
            OleComMedicamento.CommandText = " UPDATE [Medicamento] SET "
            OleComMedicamento.CommandText += "[descripcion] = '" & Medicamento.Descripcion & "'"
            OleComMedicamento.CommandText += ",[dosis] = '" & Medicamento.Dosis & "'"

            If Not Medicamento.Cantporcaja = 0 Then
                OleComMedicamento.CommandText += ",[cantporcaja] = " & Medicamento.Cantporcaja & ""
            Else
                OleComMedicamento.CommandText += ",[cantporcaja] = NULL "
            End If

            If Not (Medicamento.FechaBaja.Year = 2999 Or Medicamento.FechaBaja.Year = 1) Then
                OleComMedicamento.CommandText += ",[FechaBaja] = '" & Medicamento.FechaBaja.ToString("dd/MM/yyyy HH:mm") & "'"
            End If

            If Not Medicamento.Droga = "" Then
                OleComMedicamento.CommandText += ",[Droga] = '" & Medicamento.Droga & "'"
            Else
                OleComMedicamento.CommandText += ",[Droga] = NULL "
            End If

            If Not Medicamento.Laboratorio = "" Then
                OleComMedicamento.CommandText += ",[Laboratorio] = '" & Medicamento.Laboratorio & "'"
            Else
                OleComMedicamento.CommandText += ",[Laboratorio] = NULL "
            End If

            OleComMedicamento.CommandText += " WHERE ID = " & Medicamento.ID
            OleComMedicamento.ExecuteNonQuery()
            cxMedicamento.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxMedicamento.Close()
        End Try
        Return TransOk
    End Function
    Public Function Borrar(ByVal id As Integer) As Boolean
        Dim TransOk As Boolean = True
        Try
            Dim estado As String = cxMedicamento.State
            cxMedicamento.Open()
            OleComMedicamento.CommandText = " DELETE [Medicamento] WHERE ID = " & id
            OleComMedicamento.ExecuteNonQuery()
            cxMedicamento.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxMedicamento.Close()
        End Try
        Return TransOk
    End Function
    Public Function ObtenerMedicamento(id As Integer) As Medicamento
        Dim OleDRMedicamento As OleDb.OleDbDataReader = Nothing
        Dim Medicamento As New Medicamento

        Try
            Dim SdrDistUsu As OleDb.OleDbDataReader = Nothing
            Dim qrySelect As String = "SELECT [id],[descripcion],[dosis],[cantporcaja],fecha_entrada AS [fecha_entrada],ISNULL(fecha_baja, '1/1/2999') AS [fecha_baja],[droga],[laboratorio] FROM [Medicamento] WHERE ID=" & id
            QryMedicamento.CommandText = qrySelect
            cxMedicamento.Open()
            OleDRMedicamento = QryMedicamento.ExecuteReader
            If OleDRMedicamento.HasRows Then
                OleDRMedicamento.Read()
                Medicamento.ID = OleDRMedicamento("id")
                Medicamento.Descripcion = OleDRMedicamento("descripcion")
                Medicamento.Dosis = OleDRMedicamento("dosis")
                Medicamento.Cantporcaja = OleDRMedicamento("cantporcaja")
                Medicamento.FechaEntrada = OleDRMedicamento("fecha_entrada")
                Medicamento.FechaBaja = OleDRMedicamento("fecha_baja")
                Medicamento.Droga = OleDRMedicamento("droga")
                Medicamento.Laboratorio = OleDRMedicamento("laboratorio")
            Else
                Medicamento = Nothing
            End If
            cxMedicamento.Close()
        Catch ex As OleDb.OleDbException
            Medicamento = Nothing
        Finally
            cxMedicamento.Close()
        End Try
        Return Medicamento
    End Function
    Public Function ObtenerListado(Optional ByVal campoorden As String = "descripcion", Optional ByVal tipoorden As String = "asc") As List(Of Medicamento)
        Dim OleDRMedicamento As OleDb.OleDbDataReader = Nothing
        Dim selectMedicamento As String = ""
        Dim lstMedicamentos As New List(Of Medicamento)

        Dim TransOk As Boolean = True
        Try

            Dim qrySelect As String = ""

            qrySelect = " SELECT [id],[descripcion],[dosis],[cantporcaja], [fecha_entrada] AS fechaentrada,"
            qrySelect += " CONVERT(char(10), isnull([fecha_baja],01/01/1900), 103) AS [fecha_baja] ,[droga],[laboratorio]  "
            qrySelect += " FROM [Medicamento]"
            qrySelect += " ORDER BY " & campoorden & " " & tipoorden



            QryMedicamento.CommandText = qrySelect

            cxMedicamento.Open()
            OleDRMedicamento = QryMedicamento.ExecuteReader
            If OleDRMedicamento.HasRows Then
                While OleDRMedicamento.Read()
                    Dim itemMedicamento As New Medicamento(OleDRMedicamento("id"), OleDRMedicamento("descripcion"), OleDRMedicamento("dosis"), OleDRMedicamento("cantporcaja"), OleDRMedicamento("fechaentrada"), _
                                             OleDRMedicamento("fecha_baja"), OleDRMedicamento("droga"), OleDRMedicamento("laboratorio"))
                    lstMedicamentos.Add(itemMedicamento)
                End While
            End If
            cxMedicamento.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxMedicamento.Close()
        End Try
        Return lstMedicamentos
    End Function
End Class
