Public Class AfiliadoDAO

    Private cxafiliado As New OleDb.OleDbConnection(ConfigurationManager.ConnectionStrings("cxLocalString").ConnectionString)
    Private OleComafiliado As New OleDb.OleDbCommand("", cxafiliado)
    Private Qryafiliado As New OleDb.OleDbCommand("", cxafiliado)

    Public Function Guardar(ByVal afiliado As Afiliado) As String
        'Dim TransOk As Boolean = True
        Dim TransOk As String = ""
        Try
            Dim estado As String = cxafiliado.State
            cxafiliado.Open()
            OleComafiliado.CommandText = " INSERT INTO [afiliado] ([nombre],[apellido],[edad],[oficina],[numero_afiliado],[fecha_alta],[fecha_nacimiento]) "
            OleComafiliado.CommandText += " VALUES('" & afiliado.Nombre & "','" & afiliado.Apellido & "'," & afiliado.Edad & ",'" & afiliado.Oficina & "',"
            OleComafiliado.CommandText += " '" & afiliado.NumeroAfiliado & "','" & Date.Now.ToString("dd/MM/yyyy HH:mm") & "','" & afiliado.FechaNacimiento.ToString("dd/MM/yyyy HH:mm") & "') "
            OleComafiliado.ExecuteNonQuery()
            cxafiliado.Close()
        Catch ex As OleDb.OleDbException
            TransOk = ex.Message
        Finally
            cxafiliado.Close()
        End Try
        Return TransOk
    End Function

    Public Function Actualizar(ByVal afiliado As Afiliado) As Boolean
        Dim TransOk As Boolean = True
        Try
            Dim estado As String = cxafiliado.State
            cxafiliado.Open()
            OleComafiliado.CommandText = " UPDATE [afiliado] SET "
            OleComafiliado.CommandText += "[nombre] = '" & afiliado.Nombre & "'"
            OleComafiliado.CommandText += ",[apellido] = '" & afiliado.Apellido & "'"

            If Not afiliado.Edad = 0 Then
                OleComafiliado.CommandText += ",[edad] = " & afiliado.Edad & ""
            Else
                OleComafiliado.CommandText += ",[edad] = NULL "
            End If
            If Not afiliado.Oficina = "" Then
                OleComafiliado.CommandText += ",[oficina] = '" & afiliado.Oficina & "'"
            Else
                OleComafiliado.CommandText += ",[oficina] = NULL "
            End If

            OleComafiliado.CommandText += ",[numero_afiliado] = '" & afiliado.NumeroAfiliado & "'"

            If Not (afiliado.FechaNacimiento.Year = 2999 Or afiliado.FechaNacimiento.Year = 1) Then
                OleComafiliado.CommandText += ",[fecha_nacimiento] = '" & afiliado.FechaNacimiento.ToString("dd/MM/yyyy HH:mm") & "'"
            Else
                OleComafiliado.CommandText += ",[fecha_nacimiento] = NULL "
            End If

            OleComafiliado.CommandText += " WHERE ID = " & afiliado.ID
            OleComafiliado.ExecuteNonQuery()
            cxafiliado.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxafiliado.Close()
        End Try
        Return TransOk
    End Function
    Public Function Borrar(ByVal id As Integer) As Boolean
        Dim TransOk As Boolean = True
        Try
            cxafiliado.Open()
            OleComafiliado.CommandText = " DELETE [afiliado] WHERE ID = " & id
            OleComafiliado.ExecuteNonQuery()
            cxafiliado.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxafiliado.Close()
        End Try
        Return TransOk
    End Function
    Public Function Obtenerafiliado(id As Integer) As Afiliado
        Dim OleDRafiliado As OleDb.OleDbDataReader = Nothing
        Dim afiliado As New Afiliado
        Try
            Dim SdrDistUsu As OleDb.OleDbDataReader = Nothing

            Qryafiliado.CommandText = ""
            Qryafiliado.CommandText += "SELECT [id] ,[nombre], [apellido], [edad], [oficina], [numero_afiliado], [fecha_alta], "
            Qryafiliado.CommandText += " CONVERT(char(10), isnull([fecha_nacimiento],01/01/2999), 103) AS [fecha_nacimiento] FROM [afiliado] WHERE ID=" & id

            cxafiliado.Open()
            OleDRafiliado = Qryafiliado.ExecuteReader
            If OleDRafiliado.HasRows Then
                OleDRafiliado.Read()
                afiliado.ID = OleDRafiliado("id")
                afiliado.Nombre = OleDRafiliado("nombre")
                afiliado.Apellido = OleDRafiliado("apellido")
                afiliado.Oficina = OleDRafiliado("oficina")
                afiliado.NumeroAfiliado = OleDRafiliado("numero_afiliado")
                afiliado.FechaAlta = OleDRafiliado("fecha_alta")
                afiliado.FechaNacimiento = OleDRafiliado("fecha_nacimiento")
            End If
            cxafiliado.Close()
        Catch ex As OleDb.OleDbException
            afiliado = Nothing
        Finally
            cxafiliado.Close()
        End Try
        Return afiliado
    End Function
    Public Function ObtenerListado(Optional camporoden As String = "apellido", Optional tipoorden As String = "desc") As List(Of Afiliado)
        Dim OleDRafiliado As OleDb.OleDbDataReader = Nothing
        Dim selectafiliado As String = ""
        Dim lstafiliados As New List(Of Afiliado)


        Dim TransOk As Boolean = True
        Try

            Dim qrySelect As String = ""

            qrySelect = "SELECT [id] ,[nombre], [apellido], [edad], [oficina], [numero_afiliado],"
            qrySelect += " [fecha_alta],  "
            qrySelect += " CONVERT(char(10), isnull([fecha_nacimiento],01/01/2999), 103) AS [fecha_nacimiento]"
            qrySelect += " FROM [afiliado]"
            qrySelect += " ORDER BY " & camporoden & " " & tipoorden


            Qryafiliado.CommandText = qrySelect

            cxafiliado.Open()
            OleDRafiliado = Qryafiliado.ExecuteReader
            If OleDRafiliado.HasRows Then
                While OleDRafiliado.Read()
                    Dim itemafiliado As New Afiliado(OleDRafiliado("id"), OleDRafiliado("nombre"), OleDRafiliado("apellido"), OleDRafiliado("oficina"), OleDRafiliado("numero_afiliado"), _
                                             OleDRafiliado("fecha_alta"), OleDRafiliado("fecha_nacimiento"))
                    lstafiliados.Add(itemafiliado)
                End While
            End If
            cxafiliado.Close()
        Catch ex As OleDb.OleDbException
            TransOk = False
        Finally
            cxafiliado.Close()
        End Try
        Return lstafiliados
    End Function

End Class
