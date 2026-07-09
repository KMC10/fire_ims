Imports FrameworkX
Imports FrameworkX.ObjectSpace.Data.Schema
Namespace DTO


    <Serializable(), _
    TableMap("OccurrenceBook")> _
    Public Class OccurrenceBook


        Private _OccurrenceBookID As Integer = 0

        <PrimaryKey()> _
       <DataType("int")> _
        Public Property OccurrenceBookID() As Integer
            Get
                Return _OccurrenceBookID
            End Get
            Set(ByVal Value As Integer)
                _OccurrenceBookID = Value
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

        Private _ReportedStationID As Integer = 0

        <DataType("int")> _
        Public Property ReportedStationID() As Integer
            Get
                Return _ReportedStationID
            End Get
            Set(ByVal Value As Integer)
                _ReportedStationID = Value
            End Set
        End Property

        Private _ReportDate As Date = Now

        <DataType("datetime")> _
        Public Property ReportDate() As Date
            Get
                Return _ReportDate
            End Get
            Set(ByVal Value As Date)
                _ReportDate = Value
            End Set
        End Property

        Private _TimeOfDiscovery As Date = Now

        <DataType("datetime")> _
        Public Property TimeOfDiscovery() As Date
            Get
                Return _TimeOfDiscovery
            End Get
            Set(ByVal Value As Date)
                _TimeOfDiscovery = Value
            End Set
        End Property

        Private _TimeOfCall As Date = Now

        <DataType("datetime")> _
        Public Property TimeOfCall() As Date
            Get
                Return _TimeOfCall
            End Get
            Set(ByVal Value As Date)
                _TimeOfCall = Value
            End Set
        End Property

        Private _TimeOfArrival As Date = Now

        <DataType("datetime")> _
        Public Property TimeOfArrival() As Date
            Get
                Return _TimeOfArrival
            End Get
            Set(ByVal Value As Date)
                _TimeOfArrival = Value
            End Set
        End Property

        Private _TimeOfUnderControl As Date = Now

        <DataType("datetime")> _
        Public Property TimeOfUnderControl() As Date
            Get
                Return _TimeOfUnderControl
            End Get
            Set(ByVal Value As Date)
                _TimeOfUnderControl = Value
            End Set
        End Property

        Private _DiscoveredBy As String = String.Empty

        <DataType("nvarchar")> _
        Public Property DiscoveredBy() As String
            Get
                Return _DiscoveredBy
            End Get
            Set(ByVal Value As String)
                _DiscoveredBy = Value
            End Set
        End Property

        Private _WeatherCondition As String = String.Empty

        <DataType("nvarchar")> _
        Public Property WeatherCondition() As String
            Get
                Return _WeatherCondition
            End Get
            Set(ByVal Value As String)
                _WeatherCondition = Value
            End Set
        End Property

        Private _SupposedCauses As String = String.Empty

        <DataType("nvarchar")> _
        Public Property SupposedCauses() As String
            Get
                Return _SupposedCauses
            End Get
            Set(ByVal Value As String)
                _SupposedCauses = Value
            End Set
        End Property

        Private _InvolvedPropertyFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property InvolvedPropertyFire() As String
            Get
                Return _InvolvedPropertyFire
            End Get
            Set(ByVal Value As String)
                _InvolvedPropertyFire = Value
            End Set
        End Property

        Private _InvolvedPropertySpecialService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property InvolvedPropertySpecialService() As String
            Get
                Return _InvolvedPropertySpecialService
            End Get
            Set(ByVal Value As String)
                _InvolvedPropertySpecialService = Value
            End Set
        End Property

        Private _ParticularsOfContentsOfPropertyFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ParticularsOfContentsOfPropertyFire() As String
            Get
                Return _ParticularsOfContentsOfPropertyFire
            End Get
            Set(ByVal Value As String)
                _ParticularsOfContentsOfPropertyFire = Value
            End Set
        End Property


        Private _WhereIncidentStarted As String = String.Empty

        <DataType("nvarchar")> _
        Public Property WhereIncidentStarted() As String
            Get
                Return _WhereIncidentStarted
            End Get
            Set(ByVal Value As String)
                _WhereIncidentStarted = Value
            End Set
        End Property

        Private _WhereIncidentSpreadTo As String = String.Empty

        <DataType("nvarchar")> _
        Public Property WhereIncidentSpreadTo() As String
            Get
                Return _WhereIncidentSpreadTo
            End Get
            Set(ByVal Value As String)
                _WhereIncidentSpreadTo = Value
            End Set
        End Property

        Private _DescriptionOfDamageFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property DescriptionOfDamageFire() As String
            Get
                Return _DescriptionOfDamageFire
            End Get
            Set(ByVal Value As String)
                _DescriptionOfDamageFire = Value
            End Set
        End Property

        Private _DescriptionOfDamageSpecialService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property DescriptionOfDamageSpecialService() As String
            Get
                Return _DescriptionOfDamageSpecialService
            End Get
            Set(ByVal Value As String)
                _DescriptionOfDamageSpecialService = Value
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

        Private _ApproximateValueOfDamage As Decimal = 0

        <DataType("decimal")> _
        Public Property ApproximateValueOfDamage() As Decimal
            Get
                Return _ApproximateValueOfDamage
            End Get
            Set(ByVal Value As Decimal)
                _ApproximateValueOfDamage = Value
            End Set
        End Property

        Private _AnyCharges As Decimal = 0

        <DataType("decimal")> _
        Public Property AnyCharges() As Decimal
            Get
                Return _AnyCharges
            End Get
            Set(ByVal Value As Decimal)
                _AnyCharges = Value
            End Set
        End Property

        Private _InsertionDate As DateTime = Now

        <DataType("datetime")> _
        Public Property InsertionDate() As DateTime
            Get
                Return _InsertionDate
            End Get
            Set(ByVal Value As DateTime)
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

        Private _MethodOfCalling As String = String.Empty

        <DataType("nvarchar")> _
        Public Property MethodOfCalling() As String
            Get
                Return _MethodOfCalling
            End Get
            Set(ByVal Value As String)
                _MethodOfCalling = Value
            End Set
        End Property

        Private _NameOfOccupierFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property NameOfOccupierFire() As String
            Get
                Return _NameOfOccupierFire
            End Get
            Set(ByVal Value As String)
                _NameOfOccupierFire = Value
            End Set
        End Property

        Private _NameOfOccupierSpecialServices As String = String.Empty

        <DataType("nvarchar")> _
        Public Property NameOfOccupierSpecialServices() As String
            Get
                Return _NameOfOccupierSpecialServices
            End Get
            Set(ByVal Value As String)
                _NameOfOccupierSpecialServices = Value
            End Set
        End Property

        Private _BusinessCarriedOnFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property BusinessCarriedOnFire() As String
            Get
                Return _BusinessCarriedOnFire
            End Get
            Set(ByVal Value As String)
                _BusinessCarriedOnFire = Value
            End Set
        End Property

        Private _BusinessCarriedOnSpecialService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property BusinessCarriedOnSpecialService() As String
            Get
                Return _BusinessCarriedOnSpecialService
            End Get
            Set(ByVal Value As String)
                _BusinessCarriedOnSpecialService = Value
            End Set
        End Property

        Private _FixedInstallation As String = String.Empty

        <DataType("nvarchar")> _
        Public Property FixedInstallation() As String
            Get
                Return _FixedInstallation
            End Get
            Set(ByVal Value As String)
                _FixedInstallation = Value
            End Set
        End Property

        Private _EquipmentUsedByFireService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property EquipmentUsedByFireService() As String
            Get
                Return _EquipmentUsedByFireService
            End Get
            Set(ByVal Value As String)
                _EquipmentUsedByFireService = Value
            End Set
        End Property

        Private _ServicesRenderedByFireService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ServicesRenderedByFireService() As String
            Get
                Return _ServicesRenderedByFireService
            End Get
            Set(ByVal Value As String)
                _ServicesRenderedByFireService = Value
            End Set
        End Property

        Private _ApproximateDamageGrassFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ApproximateDamageGrassFire() As String
            Get
                Return _ApproximateDamageGrassFire
            End Get
            Set(ByVal Value As String)
                _ApproximateDamageGrassFire = Value
            End Set
        End Property

        Private _MethodOfextinguishingFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property MethodOfextinguishingFire() As String
            Get
                Return _MethodOfextinguishingFire
            End Get
            Set(ByVal Value As String)
                _MethodOfextinguishingFire = Value
            End Set
        End Property

        Private _MethodOfextinguishing As String = String.Empty

        <DataType("nvarchar")> _
        Public Property MethodOfextinguishing() As String
            Get
                Return _MethodOfextinguishing
            End Get
            Set(ByVal Value As String)
                _MethodOfextinguishing = Value
            End Set
        End Property

        Private _RemarksFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property RemarksFire() As String
            Get
                Return _RemarksFire
            End Get
            Set(ByVal Value As String)
                _RemarksFire = Value
            End Set
        End Property

        Private _RemarksSpecialService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property RemarksSpecialService() As String
            Get
                Return _RemarksSpecialService
            End Get
            Set(ByVal Value As String)
                _RemarksSpecialService = Value
            End Set
        End Property

        Private _RemarksGrassFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property RemarksGrassFire() As String
            Get
                Return _RemarksGrassFire
            End Get
            Set(ByVal Value As String)
                _RemarksGrassFire = Value
            End Set
        End Property

        Private _RemarksFalseAlarm As String = String.Empty

        <DataType("nvarchar")> _
        Public Property RemarksFalseAlarm() As String
            Get
                Return _RemarksFalseAlarm
            End Get
            Set(ByVal Value As String)
                _RemarksFalseAlarm = Value
            End Set
        End Property

        Private _RemarksStandby As String = String.Empty

        <DataType("nvarchar")> _
        Public Property RemarksStandby() As String
            Get
                Return _RemarksStandby
            End Get
            Set(ByVal Value As String)
                _RemarksStandby = Value
            End Set
        End Property

        Private _ApplianceOtherThanFireServiceFire As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ApplianceOtherThanFireServiceFire() As String
            Get
                Return _ApplianceOtherThanFireServiceFire
            End Get
            Set(ByVal Value As String)
                _ApplianceOtherThanFireServiceFire = Value
            End Set
        End Property

        Private _ApplianceOtherThanFireServiceSpecialService As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ApplianceOtherThanFireServiceSpecialService() As String
            Get
                Return _ApplianceOtherThanFireServiceSpecialService
            End Get
            Set(ByVal Value As String)
                _ApplianceOtherThanFireServiceSpecialService = Value
            End Set
        End Property

        Private _ApplianceOtherThanFireServiceFalseAlerm As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ApplianceOtherThanFireServiceFalseAlerm() As String
            Get
                Return _ApplianceOtherThanFireServiceFalseAlerm
            End Get
            Set(ByVal Value As String)
                _ApplianceOtherThanFireServiceFalseAlerm = Value
            End Set
        End Property

        Private _NatureOfFalseAlerm As String = String.Empty

        <DataType("nvarchar")> _
        Public Property NatureOfFalseAlerm() As String
            Get
                Return _NatureOfFalseAlerm
            End Get
            Set(ByVal Value As String)
                _NatureOfFalseAlerm = Value
            End Set
        End Property

        Private _ReasonOfStandBy As String = String.Empty

        <DataType("nvarchar")> _
        Public Property ReasonOfStandBy() As String
            Get
                Return _ReasonOfStandBy
            End Get
            Set(ByVal Value As String)
                _ReasonOfStandBy = Value
            End Set
        End Property

    End Class

End Namespace