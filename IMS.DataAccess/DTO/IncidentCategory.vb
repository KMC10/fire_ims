Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
    TableMap("IncidentCategory")> _
    Public Class IncidentCategory


        Private _CategoryID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property CategoryID() As Integer
            Get
                Return _CategoryID
            End Get
            Set(ByVal Value As Integer)
                _CategoryID = Value
            End Set
        End Property


        Private _CategoryName As String = String.Empty

        <DataType("nvarchar")> _
        Public Property CategoryName() As String
            Get
                Return _CategoryName
            End Get
            Set(ByVal Value As String)
                _CategoryName = Value
            End Set
        End Property


        Private _Status As Integer = 0

        <DataType("int")> _
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