Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("AssignedEmployee")> _
    Public Class AssignedEmployee


        Private _AssignedEmployeeID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property AssignedEmployeeID() As Integer
            Get
                Return _AssignedEmployeeID
            End Get
            Set(ByVal Value As Integer)
                _AssignedEmployeeID = Value
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


        Private _EmployeeID As Integer = 0

        <DataType("int")> _
        Public Property EmployeeID() As Integer
            Get
                Return _EmployeeID
            End Get
            Set(ByVal Value As Integer)
                _EmployeeID = Value
            End Set
        End Property


        Private _AssignedEmployeeStatus As Integer = 0

        <DataType("int")> _
        Public Property AssignedEmployeeStatus() As Integer
            Get
                Return _AssignedEmployeeStatus
            End Get
            Set(ByVal Value As Integer)
                _AssignedEmployeeStatus = Value
            End Set
        End Property


        Private _IsDeleted As Boolean = False

        <DataType("bit")> _
        Public Property IsDeleted() As Boolean
            Get
                Return _IsDeleted
            End Get
            Set(ByVal Value As Boolean)
                _IsDeleted = Value
            End Set
        End Property

    End Class

End Namespace