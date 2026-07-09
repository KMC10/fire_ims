Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO



    <Serializable(), _
    TableMap("Roles")> _
    Public Class Roles

        Private _RoleID As Integer = 0

        <PrimaryKey()> _
      <DataType("int")> _
        Public Property RoleID() As Integer
            Get
                Return _RoleID
            End Get
            Set(ByVal Value As Integer)
                _RoleID = Value
            End Set
        End Property

        Private _RoleName As Integer = 0

        <DataType("int")> _
        Public Property RoleName() As Integer
            Get
                Return _RoleName
            End Get
            Set(ByVal Value As Integer)
                _RoleName = Value
            End Set
        End Property

    End Class

End Namespace