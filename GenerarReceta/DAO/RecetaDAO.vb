Public Class RecetaDAO
    Private cxReceta As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
    Private cxReceta2 As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
    Private OleComReceta As New OleDb.OleDbCommand("", cxReceta)
    Private QryReceta As New OleDb.OleDbCommand("", cxReceta)

    Public Function Guardar(ByVal receta As Receta, ByVal listaItemReceta As List(Of ItemReceta)) As Boolean
        Dim TransOk As Boolean = True
        Dim IdReceta As Integer = 0
        Dim fechaAnterior As DateTime
        Dim CantTotal As Integer = 0
        Try

            OleComReceta.CommandText = ""

            IdReceta = obtenerIDoReceta()

            For Each ItemReceta As ItemReceta In listaItemReceta
                OleComReceta.CommandText += " INSERT INTO [itemreceta]([medicamento_id],[receta_id],[cantidad],[fecha]) "
                OleComReceta.CommandText += " VALUES(" & ItemReceta.Medicamento.ID & "," & IdReceta & "," & ItemReceta.Cantidad & ",'" & Date.Now.ToString("dd/MM/yyyy HH:mm") & "')"
                CantTotal = ItemReceta.Cantidad + CantTotal
            Next

            fechaAnterior = obtenerFechaRecetaAnterior(receta.AfiliadoID)

            OleComReceta.CommandText += " INSERT INTO [receta]([id_afiliado] "
            If Not receta.Tipo = "" Then
                OleComReceta.CommandText += ",[tipo]"
            End If

            If Not receta.Observacion = "" Then
                OleComReceta.CommandText += ",[observaciones]"
            End If

            OleComReceta.CommandText += ",[cant_total],[fecha_actual],[fecha_anterior]) "

            'Id afiliado
            OleComReceta.CommandText += " VALUES(" & receta.AfiliadoID & ""

            'Tipo receta
            If Not receta.Tipo = "" Then
                OleComReceta.CommandText += ",'" & receta.Tipo & "'"
            End If

            'Observacion
            If Not receta.Observacion = "" Then
                OleComReceta.CommandText += ",'" & receta.Observacion & "' "
            End If

            'Cant total
            OleComReceta.CommandText += "," & CantTotal & ","

            'Fecha Actual Y Fecha Anterior
            If fechaAnterior.Year = 9999 Then
                OleComReceta.CommandText += " '" & Date.Now.ToString("dd/MM/yyyy HH:mm") & "','" & Date.Now.ToString("dd/MM/yyyy HH:mm") & "') "
            Else
                OleComReceta.CommandText += " '" & Date.Now.ToString("dd/MM/yyyy HH:mm") & "','" & fechaAnterior.ToString("dd/MM/yyyy HH:mm") & "') "
            End If


            cxReceta.Open()
            OleComReceta.ExecuteNonQuery()
            cxReceta.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxReceta.Close()
        End Try
        Return TransOk
    End Function
    Private Function obtenerIDoReceta() As Integer
        Dim IDReceta As Integer = 0
        Dim sdrReceta As OleDb.OleDbDataReader
        Dim sqlcmdRecetaID As New OleDb.OleDbCommand("Select isnull(max(id),0) + 1 as id from receta ", cxReceta2)

        cxReceta2.Open()
        sdrReceta = sqlcmdRecetaID.ExecuteReader
        If sdrReceta.HasRows Then
            sdrReceta.Read()

            IDReceta = sdrReceta("id")
        End If
        cxReceta2.Close()

        Return IDReceta
    End Function
    Private Function obtenerFechaRecetaAnterior(ByVal idafiliado As Integer) As DateTime
        Dim fechaAnterior As DateTime
        Dim sdrReceta As OleDb.OleDbDataReader
        Dim sqlcmdRecetaFecha As New OleDb.OleDbCommand("Select isnull(Max(fecha_anterior),'1/1/9999')   fecha_anterior from receta where id_afiliado=" & idafiliado, cxReceta2)

        cxReceta2.Open()
        sdrReceta = sqlcmdRecetaFecha.ExecuteReader
        If sdrReceta.HasRows Then
            sdrReceta.Read()
            fechaAnterior = sdrReceta("fecha_anterior")
        End If
        cxReceta2.Close()

        Return fechaAnterior
    End Function
    Public Function obtenerReceta(ByVal id As Integer) As Receta

        Dim OleDRReceta As OleDb.OleDbDataReader = Nothing
        Dim Receta As New Receta
        Try
            Dim SdrItemReceta As OleDb.OleDbDataReader = Nothing

            QryReceta.CommandText = ""
            QryReceta.CommandText += " SELECT [id],[id_afiliado],[tipo],[cant_total],isnull([observaciones], '') observaciones ,"
            QryReceta.CommandText += " isnull([fecha_actual],01/01/2999) AS [fecha_actual],"
            QryReceta.CommandText += " isnull([fecha_anterior],01/01/2999) AS [fecha_anterior] FROM [receta] Where id=" & id

            cxReceta.Open()
            OleDRReceta = QryReceta.ExecuteReader
            If OleDRReceta.HasRows Then
                OleDRReceta.Read()
                Receta.ID = OleDRReceta("id")
                Receta.AfiliadoID = OleDRReceta("id_afiliado")
                Receta.Tipo = OleDRReceta("tipo")
                Receta.CantidadTotal = OleDRReceta("cant_total")

                Receta.Observacion = OleDRReceta("observaciones")
                Receta.FechaActual = OleDRReceta("fecha_actual")
                Receta.FechaAnterior = OleDRReceta("fecha_anterior")
            End If
            cxReceta.Close()
        Catch ex As OleDb.OleDbException
            Receta = Nothing
        Finally
            cxReceta.Close()
        End Try
        Return Receta
    End Function
    Public Function Borrar(ByVal id As Integer) As Boolean
        Dim TransOk As Boolean = True
        Dim itemRecetaDao As New ItemRecetaDAO
        Try
            If itemRecetaDao.BorrarXRecetaId(id) Then
                cxReceta.Open()
                OleComReceta.CommandText = " DELETE [receta] WHERE ID = " & id
                OleComReceta.ExecuteNonQuery()
                cxReceta.Close()
            Else
                TransOk = False
            End If

        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxReceta.Close()
        End Try
        Return TransOk
    End Function
    Public Function BorrarRecetaconItems(ByVal id As Integer) As Boolean
        Dim TransOk As Boolean = True
        Dim itemRecetaDao As New ItemRecetaDAO
        Try
            If itemRecetaDao.BorrarXRecetaId(id) Then
                cxReceta.Open()
                OleComReceta.CommandText = " DELETE [receta] WHERE ID = " & id
                OleComReceta.ExecuteNonQuery()
                cxReceta.Close()
            Else
                TransOk = False
            End If

        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxReceta.Close()
        End Try
        Return TransOk
    End Function
    Public Function Actualizar(ByVal receta As Receta) As Boolean
        Dim TransOk As Boolean = True
        Try
            cxReceta.Open()
            OleComReceta.CommandText = " UPDATE [receta] SET "
            OleComReceta.CommandText += "[id_afiliado] = " & receta.AfiliadoID & ""
            OleComReceta.CommandText += ",[tipo] = '" & receta.Tipo & "'"
            OleComReceta.CommandText += ",[cant_total] = " & receta.CantidadTotal & ""
            If Not receta.Observacion = "" Then
                OleComReceta.CommandText += ",[observaciones] ='" & receta.Observacion & "'"
            Else
                OleComReceta.CommandText += ",[observaciones] =NULL "
            End If

            If Not (receta.FechaActual.Year = 2999 Or receta.FechaActual.Year = 1) Then
                OleComReceta.CommandText += ",[fecha_actual] = '" & receta.FechaActual.ToString("dd/MM/yyyy HH:mm") & "'"
            End If

            OleComReceta.CommandText += " WHERE ID = " & receta.ID

            OleComReceta.ExecuteNonQuery()
            cxReceta.Close()

        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxReceta.Close()
        End Try
        Return TransOk
    End Function

    Public Function obtenerItemsReceta(ByVal id As Integer) As List(Of ItemReceta)
        Dim lisItems As List(Of ItemReceta)
        Dim itemDao As New ItemRecetaDAO
        lisItems = itemDao.ObtenerListadoXidReceta(id)
        Return lisItems
    End Function

End Class
