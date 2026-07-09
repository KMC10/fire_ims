Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
    TableMap("PersonsRescuedAndEscaping")> _
    Public Class PersonsRescuedAndEscaping

        Private _RescuedID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property RescuedID() As Integer
            Get
                Return _RescuedID
            End Get
            Set(ByVal Value As Integer)
                _RescuedID = Value
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

        Private _IncidentCategoryID As Integer = 0

        <DataType("int")> _
        Public Property IncidentCategoryID() As Integer
            Get
                Return _IncidentCategoryID
            End Get
            Set(ByVal Value As Integer)
                _IncidentCategoryID = Value
            End Set
        End Property

        Private _Name As String = String.Empty

        <DataType("nvarchar")> _
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal Value As String)
                _Name = Value
            End Set
        End Property

        Private _Sex As Integer = 0

        <DataType("int")> _
        Public Property Sex() As Integer
            Get
                Return _Sex
            End Get
            Set(ByVal Value As Integer)
                _Sex = Value
            End Set
        End Property

        Private _Age As Integer = 0

        <DataType("int")> _
        Public Property Age() As Integer
            Get
                Return _Age
            End Get
            Set(ByVal Value As Integer)
                _Age = Value
            End Set
        End Property

        Private _Method As String = String.Empty

        <DataType("nvarchar")> _
        Public Property Method() As String
            Get
                Return _Method
            End Get
            Set(ByVal Value As String)
                _Method = Value
            End Set
        End Property

        Private _PersonEfectingRescue As String = String.Empty

        <DataType("nvarchar")> _
        Public Property PersonEfectingRescue() As String
            Get
                Return _PersonEfectingRescue
            End Get
            Set(ByVal Value As String)
                _PersonEfectingRescue = Value
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
