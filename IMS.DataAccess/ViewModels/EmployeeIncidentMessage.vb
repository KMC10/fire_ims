Namespace ViewModels
    <Serializable()> _
    Public Class EmployeeIncidentMessage

        'EmployeeType
        Private _EmpTypeID As Integer = 0
        Public Property EmpTypeID() As Integer
            Get
                Return _EmpTypeID
            End Get
            Set(ByVal Value As Integer)
                _EmpTypeID = Value
            End Set
        End Property

        Private _EmpTypeDescription As String = String.Empty
        Public Property EmpTypeDescription() As String
            Get
                Return _EmpTypeDescription
            End Get
            Set(ByVal Value As String)
                _EmpTypeDescription = Value
            End Set
        End Property

        'Employee
        Private _EmployeeID As Integer = 0
        Public Property EmployeeID() As Integer
            Get
                Return _EmployeeID
            End Get
            Set(ByVal Value As Integer)
                _EmployeeID = Value
            End Set
        End Property

        Private _EmployeeName As String = String.Empty
        Public Property EmployeeName() As String
            Get
                Return _EmployeeName
            End Get
            Set(ByVal Value As String)
                _EmployeeName = Value
            End Set
        End Property

        'Incident Message
        Private _MessageID As Integer = 0
        Public Property MessageID() As Integer
            Get
                Return _MessageID
            End Get
            Set(ByVal Value As Integer)
                _MessageID = Value
            End Set
        End Property

        Private _IncidentID As Integer = 0
        Public Property IncidentID() As Integer
            Get
                Return _IncidentID
            End Get
            Set(ByVal Value As Integer)
                _IncidentID = Value
            End Set
        End Property

        Private _InsertionDate As Date = Now
        Public Property InsertionDate() As Date
            Get
                Return _InsertionDate
            End Get
            Set(ByVal Value As Date)
                _InsertionDate = Value
            End Set
        End Property

        Private _MessageText As String = String.Empty
        Public Property MessageText() As String
            Get
                Return _MessageText
            End Get
            Set(ByVal Value As String)
                _MessageText = Value
            End Set
        End Property
    End Class
End Namespace


