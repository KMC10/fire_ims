'Author                : Jafar Ulla
'Crated Date           : 7_8_2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Public Class CasualtiesForReport

    Private _Name As String = String.Empty

    Public Property Name() As String
        Get
            Return _Name
        End Get
        Set(ByVal Value As String)
            _Name = Value
        End Set
    End Property


    Private _Sex As String = String.Empty

    Public Property Sex() As String
        Get
            Return _Sex
        End Get
        Set(ByVal Value As String)
            _Sex = Value
        End Set
    End Property

    Private _Age As String = String.Empty

    Public Property Age() As String
        Get
            Return _Age
        End Get
        Set(ByVal Value As String)
            _Age = Value
        End Set
    End Property

    Private _Address As String = String.Empty

    Public Property Address() As String
        Get
            Return _Address
        End Get
        Set(ByVal Value As String)
            _Address = Value
        End Set
    End Property


    Private _NatureOfInjury As String = String.Empty

    Public Property NatureOfInjury() As String
        Get
            Return _NatureOfInjury
        End Get
        Set(ByVal Value As String)
            _NatureOfInjury = Value
        End Set
    End Property

    Private _IfFatal As String = String.Empty

    Public Property IfFatal() As String
        Get
            Return _IfFatal
        End Get
        Set(ByVal Value As String)
            _IfFatal = Value
        End Set
    End Property

End Class


