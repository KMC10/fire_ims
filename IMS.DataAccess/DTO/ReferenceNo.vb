Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
    TableMap("ReferenceNo")> _
    Public Class ReferenceNo

        Private _ReferenceNo As Integer = 0

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