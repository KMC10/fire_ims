'Author                : Jafar Ulla
'Crated Date           : 7_8_2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Public Class PersonRescuedForReport

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

    Private _MethodOfRescue As String = String.Empty

    Public Property MethodOfRescue() As String
        Get
            Return _MethodOfRescue
        End Get
        Set(ByVal Value As String)
            _MethodOfRescue = Value
        End Set
    End Property

    Private _PersonEffectingRescue As String = String.Empty

    Public Property PersonEffectingRescue() As String
        Get
            Return _PersonEffectingRescue
        End Get
        Set(ByVal Value As String)
            _PersonEffectingRescue = Value
        End Set
    End Property

End Class

