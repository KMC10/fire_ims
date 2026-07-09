
'Author                : Jafar Ulla
'Crated Date           : 22_6_2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Public Class ApplianceAttending

    Private _ApplianceType As String = String.Empty

    Public Property ApplianceType() As String
        Get
            Return _ApplianceType
        End Get
        Set(ByVal Value As String)
            _ApplianceType = Value
        End Set
    End Property


    Private _ApplianceSerial As String = String.Empty

    Public Property ApplianceSerial() As String
        Get
            Return _ApplianceSerial
        End Get
        Set(ByVal Value As String)
            _ApplianceSerial = Value
        End Set
    End Property

    Private _Station As String = String.Empty

    Public Property Station() As String
        Get
            Return _Station
        End Get
        Set(ByVal Value As String)
            _Station = Value
        End Set
    End Property


    Private _TimeOfArrival As String = String.Empty

    Public Property TimeOfArrival() As String
        Get
            Return _TimeOfArrival
        End Get
        Set(ByVal Value As String)
            _TimeOfArrival = Value
        End Set
    End Property

End Class
