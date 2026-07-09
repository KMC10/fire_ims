Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Reflection

Public Module IMSEnum

    Public Class IMSEnums

        Public Enum UserRight
            SuperAdmin = 1
            SystemManager = 2
            CallCenterAgent = 3
            StationManager = 4
            StationStuff = 5
        End Enum

        Public Enum Station
            MBN = 1
            LOB = 2
            PPK = 3
            MNZ = 4
            MTS = 5
            STKI = 6
            NHL = 7
        End Enum

        Public Enum Status
            Active = 1
            Inactive = 2
            Deleted = 3
        End Enum

        Public Enum UserStatus
            Active = 1
            Inactive = 2
        End Enum

        Public Enum IsDeleted
            No = 0
            Yes = 1
        End Enum

        Public Enum IsPrimaryStation
            No = 0
            Yes = 1
        End Enum

        Public Enum IfFatal
            No = 0
            Yes = 1
        End Enum

        Public Enum IncidentStatus
            Undispatched = 1
            Dispatched = 2
            Resolved = 3
            Dispatching = 4
            Reopened = 5
        End Enum

        Public Enum ApplianceStatus
            Available = 1
            Dispatched = 2
            'Resolved = 3
            Revoked = 3
            Redispatched = 4
            BackAfterResolved = 5
            Parked = 6
        End Enum

        Public Enum RegisterStatus
            CheckedOut = 0
            CheckedIn = 1
            Parked = 2
        End Enum

        Public Enum CallType
            PartialCall = 0
            FullCall = 1
        End Enum

        'Public Enum UserAccessRight

        '    SuperAdmin = 1
        '    Admin = 2
        '    CallCenterAgent = 3
        '    StationSupervisor = 4

        'End Enum

        Public Enum ShiftTouchDays

            ShiftTouchSingleDay = 0
            ShiftTouchTwoDaysFirstPart = 1
            ShiftTouchTwoDaysSecondPart = 2

        End Enum

        Public Enum IncidentCategory

            Fire = 1
            SpecialService = 2
            FalseAlerm = 3
            StandBy = 4
            GrassFire = 5

        End Enum

        Public Enum Months
            January = 1
            February = 2
            March = 3
            April = 4
            May = 5
            June = 6
            July = 7
            August = 8
            September = 9
            October = 10
            November = 11
            December = 12
        End Enum

        Public Enum WeatherConditions

            <Description("Windy")> _
            Windy = 0
            <Description("Sunny")> _
            Sunny = 1
            <Description("Rainy")> _
            Rainy = 2

        End Enum


        Public Enum MethodOfExtinguishing

            <Description("fire beaters")> _
            FireBeaters = 0
            <Description("hose reel")> _
            HoseReel = 1

        End Enum


        Public Enum Sex

            <Description("Male")> _
            M = 1
            <Description("Female")> _
            F = 2
            <Description("Others")> _
            O = 3

        End Enum

        '<Extension()> _
        'Public Function GetDescription(ByVal currentEnum As [Enum]) As String

        '    Dim description As String = String.Empty
        '    Dim da As DescriptionAttribute

        '    Dim fi As FieldInfo = currentEnum.GetType.GetField(currentEnum.ToString)
        '    da = DirectCast(Attribute.GetCustomAttribute(fi, GetType(DescriptionAttribute)), DescriptionAttribute)
        '    If da IsNot Nothing Then
        '        description = da.Description
        '    Else
        '        description = currentEnum.ToString
        '    End If

        '    Return description

        'End Function



        'Public Enum NewsCategory
        '    <Description("News & Notices")> _
        '    NewsAndNotices = 1
        '    <Description("Loan Disbursements & Repayments")> _
        '    LoanDisbursementsAndRepayments = 2
        'End Enum

    End Class

End Module
