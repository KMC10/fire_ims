Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("Privileges")> _
    Public Class Privileges


        Private _PrivilegeID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property PrivilegeID() As Integer
            Get
                Return _PrivilegeID
            End Get
            Set(ByVal Value As Integer)
                _PrivilegeID = Value
            End Set
        End Property

        Private _PrivilegeType As Integer = 0

        <DataType("int")> _
        Public Property PrivilegeType() As Integer
            Get
                Return _PrivilegeType
            End Get
            Set(ByVal Value As Integer)
                _PrivilegeType = Value
            End Set
        End Property


        Private _FrontEndID As String = String.Empty

        <DataType("nvarchar")> _
        Public Property FrontEndID() As String
            Get
                Return _FrontEndID
            End Get
            Set(ByVal Value As String)
                _FrontEndID = Value
            End Set
        End Property

        Private _FrontEndParentID As String = String.Empty

        <DataType("nvarchar")> _
        Public Property FrontEndParentID() As String
            Get
                Return _FrontEndParentID
            End Get
            Set(ByVal Value As String)
                _FrontEndParentID = Value
            End Set
        End Property

    End Class

End Namespace