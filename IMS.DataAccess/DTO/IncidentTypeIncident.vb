Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
      TableMap("IncidentTypeIncident")> _
    Public Class IncidentTypeIncident

        Private _IncidentTypeIncidentID As Integer = 0

        <PrimaryKey()> _
        <DataType("int")> _
        Public Property IncidentTypeIncidentID() As Integer
            Get
                Return _IncidentTypeIncidentID
            End Get
            Set(ByVal Value As Integer)
                _IncidentTypeIncidentID = Value
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

        Private _IncidentTypeID As Integer = 0

        <DataType("int")> _
        Public Property IncidentTypeID() As Integer
            Get
                Return _IncidentTypeID
            End Get
            Set(ByVal Value As Integer)
                _IncidentTypeID = Value
            End Set
        End Property


    End Class


End Namespace