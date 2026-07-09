Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
    TableMap("ApplianceRegister")> _
    Public Class ApplianceRegister

        Private _ApplianceRegisterID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property ApplianceRegisterID() As Integer
            Get
                Return _ApplianceRegisterID
            End Get
            Set(ByVal Value As Integer)
                _ApplianceRegisterID = Value
            End Set
        End Property


        Private _ShiftID As Integer = 0

        <DataType("int")> _
        Public Property ShiftID() As Integer
            Get
                Return _ShiftID
            End Get
            Set(ByVal Value As Integer)
                _ShiftID = Value
            End Set
        End Property


        Private _StationID As Integer = 0

        <DataType("int")> _
        Public Property StationID() As Integer
            Get
                Return _StationID
            End Get
            Set(ByVal Value As Integer)
                _StationID = Value
            End Set
        End Property

        Private _StationApplianceID As Integer = 0

        <DataType("int")> _
        Public Property StationApplianceID() As Integer
            Get
                Return _StationApplianceID
            End Get
            Set(ByVal Value As Integer)
                _StationApplianceID = Value
            End Set
        End Property

        Private _RegisterStatus As Integer = 0

        <DataType("int")> _
        Public Property RegisterStatus() As Integer
            Get
                Return _RegisterStatus
            End Get
            Set(ByVal Value As Integer)
                _RegisterStatus = Value
            End Set
        End Property

        Private _IsCurrent As Boolean = False

        <DataType("bit")> _
        Public Property IsCurrent() As Boolean
            Get
                Return _IsCurrent
            End Get
            Set(ByVal Value As Boolean)
                _IsCurrent = Value
            End Set
        End Property

        Private _OnEvent As Boolean = False

        <DataType("bit")> _
        Public Property OnEvent() As Boolean
            Get
                Return _OnEvent
            End Get
            Set(ByVal Value As Boolean)
                _OnEvent = Value
            End Set
        End Property

        Private _IncidentID As Integer = 0

        <DataType("int")> _
        Public Property IncidentID() As Integer
            Get
                Return _IncidentID
            End Get
            Set(ByVal Value As Integer)
                _IncidentID = Value
            End Set
        End Property

        Private _Reason As String = String.Empty

        <DataType("nvarchar")> _
        Public Property Reason() As String
            Get
                Return _Reason
            End Get
            Set(ByVal Value As String)
                _Reason = Value
            End Set
        End Property

        Private _CapturedBy As Integer = 0

        <DataType("int")> _
        Public Property CapturedBy() As Integer
            Get
                Return _CapturedBy
            End Get
            Set(ByVal Value As Integer)
                _CapturedBy = Value
            End Set
        End Property

        Private _InsertionDate As Date = Now

        <DataType("datetime")> _
        Public Property InsertionDate() As Date
            Get
                Return _InsertionDate
            End Get
            Set(ByVal Value As Date)
                _InsertionDate = Value
            End Set
        End Property

        Private _ModificationDate As Date = Now

        <DataType("smalldatetime")> _
        Public Property ModificationDate() As Date
            Get
                Return _ModificationDate
            End Get
            Set(ByVal Value As Date)
                _ModificationDate = Value
            End Set
        End Property

    End Class

End Namespace

