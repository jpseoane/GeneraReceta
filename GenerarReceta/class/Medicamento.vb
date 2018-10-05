<Serializable()> _
Public Class Medicamento

    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property

    Private _dosis As String
    Public Property Dosis() As String
        Get
            Return _dosis
        End Get
        Set(ByVal value As String)
            _dosis = value
        End Set
    End Property

    Private _cantporcaja As Integer
    Public Property Cantporcaja() As Integer
        Get
            Return _cantporcaja
        End Get
        Set(ByVal value As Integer)
            _cantporcaja = value
        End Set
    End Property

    Private _fecha_entrada As DateTime
    Public Property FechaEntrada() As DateTime
        Get
            Return _fecha_entrada
        End Get
        Set(ByVal value As DateTime)
            _fecha_entrada = value
        End Set
    End Property
    Private _fecha_baja As DateTime
    Public Property FechaBaja() As DateTime
        Get
            Return _fecha_baja
        End Get
        Set(ByVal value As DateTime)
            _fecha_baja = value
        End Set
    End Property

    Private _droga As String
    Public Property Droga() As String
        Get
            Return _droga
        End Get
        Set(ByVal value As String)
            _droga = value
        End Set
    End Property
    Private _laboratorio As String
    Public Property Laboratorio() As String
        Get
            Return _laboratorio
        End Get
        Set(ByVal value As String)
            _laboratorio = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal descripcion As String, ByVal dosis As String, ByVal cantporcaja As String, ByVal droga As String, ByVal laboratorio As String)
        Me.Descripcion = descripcion
        Me.Dosis = dosis
        Me.Cantporcaja = cantporcaja
        Me.FechaEntrada = FechaEntrada
        Me.FechaBaja = FechaBaja
        Me.Droga = droga
        Me.Laboratorio = laboratorio
    End Sub


    Public Sub New(ByVal id As Integer, ByVal descripcion As String, ByVal dosis As String, ByVal cantporcaja As String, ByVal fechaEntrada As DateTime _
                   , ByVal fechaBaja As DateTime, ByVal droga As String, ByVal laboratorio As String)
        Me.ID = id
        Me.Descripcion = descripcion
        Me.Dosis = Dosis
        Me.Cantporcaja = cantporcaja
        Me.FechaEntrada = fechaEntrada
        Me.FechaBaja = fechaBaja
        Me.Droga = droga
        Me.Laboratorio = laboratorio
    End Sub





End Class
