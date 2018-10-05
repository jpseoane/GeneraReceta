<Serializable()> _
Public Class Receta
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property


    Private _afiliadoID As Integer
    Public Property AfiliadoID As Integer
        Get
            Return _afiliadoID
        End Get
        Set(ByVal value As Integer)
            _afiliadoID = value
        End Set
    End Property

    Private _tipo As String
    Public Property Tipo() As String
        Get
            Return _tipo
        End Get
        Set(ByVal value As String)
            _tipo = value
        End Set
    End Property

    Private _observacion As String
    Public Property Observacion() As String
        Get
            Return _observacion
        End Get
        Set(ByVal value As String)
            _observacion = value
        End Set
    End Property


    Private _cantidadTotal As Integer
    Public Property CantidadTotal() As Integer
        Get
            Return _cantidadTotal
        End Get
        Set(ByVal value As Integer)
            _cantidadTotal = value
        End Set
    End Property


    Private _fecha_actual As DateTime
    Public Property FechaActual() As DateTime
        Get
            Return _fecha_actual
        End Get
        Set(ByVal value As DateTime)
            _fecha_actual = value
        End Set
    End Property

    Private _fecha_anterior As DateTime
    Public Property FechaAnterior() As DateTime
        Get
            Return _fecha_anterior
        End Get
        Set(ByVal value As DateTime)
            _fecha_anterior = value
        End Set
    End Property

    Private _listItemReceta As List(Of ItemReceta)
    Public Property ListItemReceta() As List(Of ItemReceta)
        Get
            Return _listItemReceta
        End Get
        Set(ByVal value As List(Of ItemReceta))
            _listItemReceta = value
        End Set
    End Property


    Public Sub New()

    End Sub
    Public Sub New(ByVal id As Integer, ByVal afiliadoID As Integer, ByVal tipo As String, ByVal observacion As String, _
                    ByVal cantidadtotal As Integer, ByVal fechaActual As DateTime, ByVal fechaAnterior As DateTime)
        Me.ID = id
        Me.AfiliadoID = afiliadoID
        Me.Tipo = tipo
        Me.Observacion = observacion
        Me.CantidadTotal = cantidadtotal
        Me.FechaActual = fechaActual
        Me.FechaAnterior = fechaAnterior

    End Sub


End Class
