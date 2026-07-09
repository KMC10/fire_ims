Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema

Namespace DTO

    <Serializable(), _
    TableMap("Group")> _
    Public Class Group

        Private _GroupID As Integer = 0

        <DataType("int")> _
        Public Property GroupID() As Integer
            Get
                Return _GroupID
            End Get
            Set(ByVal Value As Integer)
                _GroupID = Value
            End Set
        End Property

        Private _GroupName As String = String.Empty

        <DataType("nvarchar")> _
        Public Property GroupName() As String
            Get
                Return _GroupName
            End Get
            Set(ByVal Value As String)
                _GroupName = Value
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
