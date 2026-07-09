
'Author                : Jafar Ulla
'Crated Date           : 22_6_2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Public Class PersonAttending

    Private _Station As String = String.Empty

    Public Property Station() As String
        Get
            Return _Station
        End Get
        Set(ByVal Value As String)
            _Station = Value
        End Set
    End Property


    Private _Rank As String = String.Empty

    Public Property Rank() As String
        Get
            Return _Rank
        End Get
        Set(ByVal Value As String)
            _Rank = Value
        End Set
    End Property

    Private _PersonName As String = String.Empty

    Public Property PersonName() As String
        Get
            Return _PersonName
        End Get
        Set(ByVal Value As String)
            _PersonName = Value
        End Set
    End Property

End Class
