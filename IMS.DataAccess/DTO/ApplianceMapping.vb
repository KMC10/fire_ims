
Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema

Namespace DTO


    <Serializable(), _
    TableMap("ApplianceMapping")> _
    Public Class ApplianceMapping

        Private _MappingID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property MappingID() As Integer
            Get
                Return _MappingID
            End Get
            Set(ByVal Value As Integer)
                _MappingID = Value
            End Set
        End Property

        Private _CategoryID As Integer = 0

        Public Property CategoryID() As Integer
            Get
                Return _CategoryID
            End Get
            Set(ByVal Value As Integer)
                _CategoryID = Value
            End Set
        End Property

        Private _IncidentTypeID As Integer = 0

        Public Property IncidentTypeID() As Integer
            Get
                Return _IncidentTypeID
            End Get
            Set(ByVal Value As Integer)
                _IncidentTypeID = Value
            End Set
        End Property

        Private _ApplianceID As Integer = 0

        Public Property ApplianceID() As Integer
            Get
                Return _ApplianceID
            End Get
            Set(ByVal Value As Integer)
                _ApplianceID = Value
            End Set
        End Property

        Private _Quantity As Integer = 0

        Public Property Quantity() As Integer
            Get
                Return _Quantity
            End Get
            Set(ByVal Value As Integer)
                _Quantity = Value
            End Set
        End Property

        Private _Status As Integer = 0

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
