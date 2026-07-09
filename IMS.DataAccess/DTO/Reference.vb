Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
    TableMap("Reference")> _
    Public Class Reference

        Private _ReferenceID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property ReferenceID() As Integer
            Get
                Return _ReferenceID
            End Get
            Set(ByVal Value As Integer)
                _ReferenceID = Value
            End Set
        End Property

        Private _ReferenceYear As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ReferenceYear() As String
            Get
                Return _ReferenceYear
            End Get
            Set(ByVal Value As String)
                _ReferenceYear = Value
            End Set
        End Property

        Private _ReferenceNo As Integer = 0

        <DataType("int")> _
        Public Property ReferenceNo() As Integer
            Get
                Return _ReferenceNo
            End Get
            Set(ByVal Value As Integer)
                _ReferenceNo = Value
            End Set
        End Property

    End Class

End Namespace
