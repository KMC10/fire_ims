Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("FireStationAppliance")> _
    Public Class FireStationAppliance

        Private _StationApplianceID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property StationApplianceID() As Integer
            Get
                Return _StationApplianceID
            End Get
            Set(ByVal Value As Integer)
                _StationApplianceID = Value
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

        Private _ApplianceID As Integer = 0

        <DataType("int")> _
        Public Property ApplianceID() As Integer
            Get
                Return _ApplianceID
            End Get
            Set(ByVal Value As Integer)
                _ApplianceID = Value
            End Set
        End Property

        Private _SerialNumber As String = String.Empty

        <DataType("nvarchar")> _
        Public Property SerialNumber() As String
            Get
                Return _SerialNumber
            End Get
            Set(ByVal Value As String)
                _SerialNumber = Value
            End Set
        End Property

        Private _Status As Integer = 0

        <DataType("int")> _
        Public Property Status() As Integer
            Get
                Return _Status
            End Get
            Set(ByVal Value As Integer)
                _Status = Value
            End Set
        End Property


    End Class


End Namespace
