Imports System.Collections.Generic
Public Class Afiliado
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _nombre As String
    Public Property Nombre() As String
        Get
            Return _nombre
        End Get
        Set(ByVal value As String)
            _nombre = value
        End Set
    End Property

    Private _apellido As String
    Public Property Apellido() As String
        Get
            Return _apellido
        End Get
        Set(ByVal value As String)
            _apellido = value
        End Set
    End Property

    Private _oficina As String
    Public Property Oficina() As String
        Get
            Return _oficina
        End Get
        Set(ByVal value As String)
            _oficina = value
        End Set
    End Property

    Private _numeroAfiliado As String
    Public Property NumeroAfiliado() As String
        Get
            Return _numeroAfiliado
        End Get
        Set(ByVal value As String)
            _numeroAfiliado = value
        End Set
    End Property

    Private _fecha_alta As DateTime
    Public Property FechaAlta() As DateTime
        Get
            Return _fecha_alta
        End Get
        Set(ByVal value As DateTime)
            _fecha_alta = value
        End Set
    End Property

    Private _fecha_nacimiento As DateTime
    Public Property FechaNacimiento() As DateTime
        Get
            Return _fecha_nacimiento
        End Get
        Set(ByVal value As DateTime)
            _fecha_nacimiento = value
        End Set
    End Property


    Private _edad As Integer
    Public ReadOnly Property Edad() As Integer
        Get
            If Me.FechaNacimiento.Year <> 0 Then
                Dim now As DateTime = DateTime.Today
                _edad = DateTime.Today.Year - Me.FechaNacimiento.Year

                If (DateTime.Today < Me.FechaNacimiento.AddYears(Edad)) Then
                    _edad = _edad - 1
                    Return _edad
                Else
                    Return _edad
                End If
            Else
                Return 0
            End If
        End Get
    End Property



    Public Sub New()

    End Sub

    Public Sub Afiliado()

    End Sub



    Public Sub New(ByVal nombre As String, ByVal apellido As String, ByVal oficina As String, _
                    ByVal numeroAfiliado As String, ByVal fechaNacimiento As DateTime)

        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Oficina = oficina
        Me.NumeroAfiliado = numeroAfiliado
        Me.FechaAlta = Date.Now
        Me.FechaNacimiento = fechaNacimiento
    End Sub

    Public Sub New(ByVal id As Integer, ByVal nombre As String, ByVal apellido As String, ByVal oficina As String, _
                   ByVal numeroAfiliado As String, ByVal fechaAlta As DateTime, ByVal fechaNacimiento As DateTime)

        Me.ID = id
        Me.Nombre = nombre
        Me.Apellido = apellido
        Me.Oficina = oficina
        Me.NumeroAfiliado = numeroAfiliado
        Me.FechaAlta = fechaAlta
        Me.FechaNacimiento = fechaNacimiento
    End Sub
    'Private Sub ObtenerEdad()

    '    Dim diaMesNacimiento As String = Me.FechaNacimiento.Day + "/" + Me.FechaNacimiento.Month
    '    Dim diaMesActual As String = Date.Now.Day + "/" + Date.Now.Month

    '    If diaMesActual >= diaMesNacimiento Then
    '        Me.Edad = (Date.Now.Year - Me.FechaNacimiento.Year) + 1
    '    Else
    '        Me.Edad = (Date.Now.Year - Me.FechaNacimiento.Year)
    '    End If

    'End Sub

End Class
