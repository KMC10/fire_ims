'Author                : Jafar Ulla
'Crated Date           : 24_6_2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Public Class MonthlyReport

    Private _IncidentCategory As String = String.Empty

    Public Property IncidentCategory() As String
        Get
            Return _IncidentCategory
        End Get
        Set(ByVal Value As String)
            _IncidentCategory = Value
        End Set
    End Property

    Private _IncidentTypeCode As String = String.Empty

    Public Property IncidentTypeCode() As String
        Get
            Return _IncidentTypeCode
        End Get
        Set(ByVal Value As String)
            _IncidentTypeCode = Value
        End Set
    End Property

    Private _IncidentTypeDescription As String = String.Empty

    Public Property IncidentTypeDescription() As String
        Get
            Return _IncidentTypeDescription
        End Get
        Set(ByVal Value As String)
            _IncidentTypeDescription = Value
        End Set
    End Property


    'Private _Station As String = String.Empty

    'Public Property Station() As String
    '    Get
    '        Return _Station
    '    End Get
    '    Set(ByVal Value As String)
    '        _Station = Value
    '    End Set
    'End Property


    Private _MBN As Integer = 0

    Public Property MBN() As Integer
        Get
            Return _MBN
        End Get
        Set(ByVal Value As Integer)
            _MBN = Value
        End Set
    End Property

    Private _LOB As Integer = 0

    Public Property LOB() As Integer
        Get
            Return _LOB
        End Get
        Set(ByVal Value As Integer)
            _LOB = Value
        End Set
    End Property

    Private _PPK As Integer = 0

    Public Property PPK() As Integer
        Get
            Return _PPK
        End Get
        Set(ByVal Value As Integer)
            _PPK = Value
        End Set
    End Property

    Private _MNZ As Integer = 0

    Public Property MNZ() As Integer
        Get
            Return _MNZ
        End Get
        Set(ByVal Value As Integer)
            _MNZ = Value
        End Set
    End Property

    Private _MTS As Integer = 0

    Public Property MTS() As Integer
        Get
            Return _MTS
        End Get
        Set(ByVal Value As Integer)
            _MTS = Value
        End Set
    End Property

    Private _STKI As Integer = 0

    Public Property STKI() As Integer
        Get
            Return _STKI
        End Get
        Set(ByVal Value As Integer)
            _STKI = Value
        End Set
    End Property

    Private _NHL As Integer = 0

    Public Property NHL() As Integer
        Get
            Return _NHL
        End Get
        Set(ByVal Value As Integer)
            _NHL = Value
        End Set
    End Property


    Private _IncidentCount As Integer = 0

    Public Property IncidentCount() As Integer
        Get
            Return _IncidentCount
        End Get
        Set(ByVal Value As Integer)
            _IncidentCount = Value
        End Set
    End Property

End Class
