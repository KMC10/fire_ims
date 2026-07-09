Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("DispatchLog")> _
    Public Class DispatchLog


        Private _DispatchLogID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property DispatchLogID() As Integer
            Get
                Return _DispatchLogID
            End Get
            Set(ByVal Value As Integer)
                _DispatchLogID = Value
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


        Private _AssignedApplianceStatus As Integer = 0

        <DataType("int")> _
        Public Property AssignedApplianceStatus() As Integer
            Get
                Return _AssignedApplianceStatus
            End Get
            Set(ByVal Value As Integer)
                _AssignedApplianceStatus = Value
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

        Private _TimeOfArrival As DateTime = Nothing

        <DataType("datetime")> _
        Public Property TimeOfArrival() As DateTime
            Get
                Return _TimeOfArrival
            End Get
            Set(ByVal Value As DateTime)
                _TimeOfArrival = Value
            End Set
        End Property

        Private _DispatchDate As DateTime = Now

        <DataType("datetime")> _
        Public Property DispatchDate() As DateTime
            Get
                Return _DispatchDate
            End Get
            Set(ByVal Value As DateTime)
                _DispatchDate = Value
            End Set
        End Property


        Private _CreatedBy As Integer = 0

        <DataType("int")> _
        Public Property CreatedBy() As Integer
            Get
                Return _CreatedBy
            End Get
            Set(ByVal Value As Integer)
                _CreatedBy = Value
            End Set
        End Property


    End Class


End Namespace