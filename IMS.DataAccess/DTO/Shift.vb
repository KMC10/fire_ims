Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO

    <Serializable(), _
    TableMap("Shift")> _
    Public Class Shift

        Private _ShiftID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property ShiftID() As Integer
            Get
                Return _ShiftID
            End Get
            Set(ByVal Value As Integer)
                _ShiftID = Value
            End Set
        End Property


        Private _StationID As Integer = 0

        <DataType("int")> _
        Public Property StationID() As Integer
            Get
                Return _StationID
            End Get
            Set(ByVal Value As Integer)
                _StationID = Value
            End Set
        End Property


        Private _ShiftName As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ShiftName() As String
            Get
                Return _ShiftName
            End Get
            Set(ByVal Value As String)
                _ShiftName = Value
            End Set
        End Property

        Private _ShiftStartTime As String = String.Empty

        <DataType("datetime")> _
        Public Property ShiftStartTime() As String
            Get
                Return _ShiftStartTime
            End Get
            Set(ByVal Value As String)
                _ShiftStartTime = Value
            End Set
        End Property


        Private _ShiftEndTime As String = String.Empty

        <DataType("datetime")> _
        Public Property ShiftEndTime() As String
            Get
                Return _ShiftEndTime
            End Get
            Set(ByVal Value As String)
                _ShiftEndTime = Value
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


        Private _CapturedBy As Integer = 0

        <DataType("int")> _
        Public Property CapturedBy() As Integer
            Get
                Return _CapturedBy
            End Get
            Set(ByVal Value As Integer)
                _CapturedBy = Value
            End Set
        End Property

        Private _InsertionDate As Date = Now

        <DataType("datetime")> _
        Public Property InsertionDate() As Date
            Get
                Return _InsertionDate
            End Get
            Set(ByVal Value As Date)
                _InsertionDate = Value
            End Set
        End Property


        Private _ModificationDate As Date = Now

        <DataType("datetime")> _
        Public Property ModificationDate() As Date
            Get
                Return _ModificationDate
            End Get
            Set(ByVal Value As Date)
                _ModificationDate = Value
            End Set
        End Property


    End Class

End Namespace