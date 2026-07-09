Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("Casualities")> _
    Public Class Casualities


        Private _CasualitiesID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property CasualitiesID() As Integer
            Get
                Return _CasualitiesID
            End Get
            Set(ByVal Value As Integer)
                _CasualitiesID = Value
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

        Private _Address As String = String.Empty

        <DataType("nvarchar")> _
        Public Property Address() As String
            Get
                Return _Address
            End Get
            Set(ByVal Value As String)
                _Address = Value
            End Set
        End Property

        Private _NatureOfInjury As String = String.Empty

        <DataType("nvarchar")> _
        Public Property NatureOfInjury() As String
            Get
                Return _NatureOfInjury
            End Get
            Set(ByVal Value As String)
                _NatureOfInjury = Value
            End Set
        End Property

        Private _IfFatal As Boolean = False

        <DataType("bit")> _
        Public Property IfFatal() As Boolean
            Get
                Return _IfFatal
            End Get
            Set(ByVal Value As Boolean)
                _IfFatal = Value
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

