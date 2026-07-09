Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("RolePrivileges")> _
    Public Class RolePrivileges

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

        Private _PrivilegeID As Integer = 0

        <DataType("int")> _
        Public Property PrivilegeID() As Integer
            Get
                Return _PrivilegeID
            End Get
            Set(ByVal Value As Integer)
                _PrivilegeID = Value
            End Set
        End Property

    End Class

End Namespace