Public Class cx

    Private StringConnection As String = ConfigurationManager.AppSettings("cxLocalString")

    Private cx2 As New OleDb.OleDbConnection(ConfigurationManager.AppSettings("cxLocalString"))


    Public Sub New()
        Try
            cx2.Open()


        Catch ex As Exception

        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
