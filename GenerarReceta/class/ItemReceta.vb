Public Class ItemReceta
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _recetaId As Integer
    Public Property RecetaId As Integer
        Get
            Return _recetaId
        End Get
        Set(ByVal value As Integer)
            _recetaId = value
        End Set
    End Property

    'Private _medicamentoId As Integer
    'Public Property MedicamentoID As Integer
    '    Get
    '        Return _medicamentoId
    '    End Get
    '    Set(ByVal value As Integer)
    '        _medicamentoId = value
    '    End Set
    'End Property


    Private _medicamento As Medicamento
    Public Property Medicamento As Medicamento
        Get
            Return _medicamento
        End Get
        Set(ByVal value As Medicamento)
            _medicamento = value
        End Set
    End Property


    Private _cantidad As Integer
    Public Property Cantidad As Integer
        Get
            Return _cantidad
        End Get
        Set(ByVal value As Integer)
            _cantidad = value
        End Set
    End Property


    Private _fecha As DateTime
    Public Property Fecha As DateTime
        Get
            Return _fecha
        End Get
        Set(ByVal value As DateTime)
            _fecha = value
        End Set
    End Property


    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Integer, ByVal recetaid As Integer, ByVal medicamento As Medicamento, _
                     ByVal cantidad As Integer, ByVal fecha As DateTime)
        Me.ID = id
        Me.RecetaId = recetaid
        ' Me.MedicamentoID = medicamentoid
        Me.Medicamento = medicamento
        Me.Cantidad = cantidad
        Me.Fecha = fecha
    End Sub

End Class
