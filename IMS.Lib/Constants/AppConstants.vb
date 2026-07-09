Partial Public Class IMSConstants


    Public NotInheritable Class AlertConstant
        Public Const SuccessMessage As String = "(IMS) Success Message"
        Public Const ErrorMessage As String = "(IMS) Error Message"
        Public Const WarningMessage As String = "(IMS) Warning Message"
        Public Const Information As String = "(IMS) Information"

        Public Const ImageCaptionSuccess As String = "success.ico"
        Public Const ImageCaptionError As String = "error.ico"
        Public Const ImageCaptionWarning As String = "warning.ico"
        Public Const ImageCaptionInformation As String = "information.ico"

        Public Const SoundCaptionSuccess As String = "success.wav"
        Public Const SoundCaptionError As String = "error.wav"
        Public Const SoundCaptionWarning As String = "warning.wav"
        Public Const SoundCaptionInformation As String = "information.wav"
    End Class

    Public NotInheritable Class AppConstants

        Public Const EmailValidation = "^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
        Public Shared LoggedinUserID As String = String.Empty
        Public Shared LoggedInUserName As String = String.Empty
        Public Shared LoggedInEmployeeName As String = String.Empty
        Public Shared LoggedInAccessRightName As String = String.Empty
        Public Shared LoggedInAccessRightID As Integer = 0
        Public Shared IsAdminUser As Boolean = False
        Public Shared LoginTime As DateTime = DateTime.MinValue
        Public Shared UserStationID As Integer = 0
        Public Shared UsersEmployeeID As Integer = 0
        'Public Shared lstUserPrevilize  As New List(Of 

        Public Const DateFormatForDefault As String = "yyyy'/'MM'/'dd"
        Public Const DateDefault As String = "1900/01/01"
        Public Const DateFormatToShow As String = "dd'-'MMM'-'yy"
        Public Const DateTimeFormatToShow As String = "dd'/'MM'/'yyyy hh:mm:ss"
        Public Const DateTimeWithTTFormatToShow As String = "dd'/'MM'/'yyyy hh:mm tt"
        Public Const DateFormatToQueryShort As String = "yyyy'/'MM'/'dd"
        Public Const DateFormatToQuery As String = "yyyy'/'MM'/'dd hh:mm:ss tt"

    End Class

    Public NotInheritable Class Settings

        Public Const GrassFireTypeCode As String = "G"
        Public Const SupperAdminID As Integer = 1
        Public Const DateTimeDefault As String = "1/1/1900"

        Public Const PathOfFireReport As String = "\Reports\crptFire.rpt"
        Public Const PathOfSecialServiceReport As String = "\Reports\crptSpecialService.rpt"
        Public Const PathOfFalseAlermReport As String = "\Reports\crptFalseAlarm.rpt"
        Public Const PathOfStandByReport As String = "\Reports\crptStandby.rpt"
        Public Const PathOfGrassFireReport As String = "\Reports\crptGrassFire.rpt"

        Public Const PathOf_SubReportPersonnelAttending As String = "rptSubPersonnel.rpt"
        Public Const PathOf_SubPersonnelShortWidth As String = "rptSubPersonnelShortWidth.rpt"
        Public Const PathOf_SubReportApplianceAttending As String = "subRptFireServiceAppliance.rpt"
        Public Const PathOf_SubRptFireServiceApplianceShortWidth As String = "subRptFireServiceApplianceShortWidth.rpt"

        Public Const PathOf_SubReportPersonRescued As String = "rptSubPersonsRescued.rpt"
        Public Const PathOf_SubReportCasualties As String = "rptSubCasualties.rpt"





        Public Const EndYear As String = "1900"


    End Class



End Class

