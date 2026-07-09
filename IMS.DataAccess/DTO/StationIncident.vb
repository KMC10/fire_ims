Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
      TableMap("StationIncident")> _
    Public Class StationIncident


        Private _StationIncidentID As Integer = 0

        <PrimaryKey()> _
        <DataType("int")> _
                Public Property StationIncidentID() As Integer
            Get
                Return _StationIncidentID
            End Get
            Set(ByVal Value As Integer)
                _StationIncidentID = Value
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

        Private _IsPrimaryStation As Boolean = False

        <DataType("bit")> _
        Public Property IsPrimaryStation() As Boolean
            Get
                Return _IsPrimaryStation
            End Get
            Set(ByVal Value As Boolean)
                _IsPrimaryStation = Value
            End Set
        End Property

    End Class

End Namespace