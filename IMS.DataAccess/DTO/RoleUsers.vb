Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("RoleUsers")> _
    Public Class RoleUsers

        Private _ID As Integer = 0

        <PrimaryKey()> _
        <DataType("int")> _
        Public Property ID() As Integer
            Get
                Return _ID
            End Get
            Set(ByVal Value As Integer)
                _ID = Value
            End Set
        End Property

        Private _RoleID As Integer = 0

        <DataType("int")> _
        Public Property RoleID() As Integer
            Get
                Return _RoleID
            End Get
            Set(ByVal Value As Integer)
                _RoleID = Value
            End Set
        End Property

        Private _UserID As String = String.Empty

        <DataType("nvarchar")> _
        Public Property UserID() As String
            Get
                Return _UserID
            End Get
            Set(ByVal Value As String)
                _UserID = Value
            End Set
        End Property

    End Class

End Namespace