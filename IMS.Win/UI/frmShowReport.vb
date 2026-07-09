'Author                : Jafar Ulla
'Crated Date           : 20_6_2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization
Imports IMS.Win.IMSService
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Reflection
Imports System.ComponentModel
Imports Infragistics.Win

Public Class frmShowReport
    Inherits BaseForm

#Region "Member Variables"

    'Common
    Private incidentID As Integer = 0
    Private incidentCategory As Integer = 0

    Private totalNumberOfPersonalAttending As Integer = 0

    Private IsGrassFire As Boolean = False

    Private incidentType As Integer = 0
    Private referenceNO As String = String.Empty
    Private categoryReference As String = String.Empty
    Private station As String = String.Empty
    Private address As String = String.Empty

    Private _proxy As New IMSService.IMSServices

#End Region

#Region "Constructor"

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' For FIRE
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal incidentID As Integer, ByVal incidentCategory As Integer, ByVal isGrassFire As Boolean)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.incidentID = incidentID
        Me.incidentCategory = incidentCategory
        Me.IsGrassFire = isGrassFire

    End Sub

    ' ''' <summary>
    ' ''' For FIRE
    ' ''' </summary>
    ' ''' <param name="incidentID"></param>
    ' ''' <remarks></remarks>
    'Public Sub New(ByVal incidentID As Integer, ByVal referenceNumber As String, ByVal categoryReferenceNO As String, ByVal stationName As String, ByVal addressOfIncident As String)
    '    ' This call is required by the designer.
    '    InitializeComponent()

    '    ' Add any initialization after the InitializeComponent() call.
    '    Me.incidentID = incidentID
    '    Me.referenceNO = referenceNumber
    '    Me.categoryReference = categoryReferenceNO
    '    Me.station = stationName
    '    Me.address = addressOfIncident

    'End Sub


#End Region

#Region "User Defined Methods"

    ''' <summary>
    ''' Method to get the path of report depending on category.
    ''' </summary>
    ''' <param name="incidentCategory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetReportPathDependingOnCategories(ByVal incidentCategory As Integer) As String

        Dim pathOfReport As String = String.Empty

        Select Case incidentCategory
            Case CInt(IMSEnums.IncidentCategory.Fire)
                If Me.IsGrassFire Then
                    pathOfReport = IMSConstants.Settings.PathOfGrassFireReport
                Else
                    pathOfReport = IMSConstants.Settings.PathOfFireReport
                End If

            Case CInt(IMSEnums.IncidentCategory.SpecialService)
                pathOfReport = IMSConstants.Settings.PathOfSecialServiceReport
            Case CInt(IMSEnums.IncidentCategory.FalseAlerm)
                pathOfReport = IMSConstants.Settings.PathOfFalseAlermReport
            Case CInt(IMSEnums.IncidentCategory.StandBy)
                pathOfReport = IMSConstants.Settings.PathOfStandByReport
            Case CInt(IMSEnums.IncidentCategory.GrassFire)
                pathOfReport = IMSConstants.Settings.PathOfGrassFireReport
            Case Else
                'String.Empty
                Exit Select
        End Select

        Return pathOfReport
    End Function

    ''' <summary>
    ''' Method to set Common header of the reports.
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="primaryStation"></param>
    ''' <param name="incidentRegister"></param>
    ''' <param name="lstIncidentTypes"></param>
    ''' <param name="stationNames"></param>
    ''' <remarks></remarks>
    Private Sub SetCommonLabels(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal primaryStation As IMSService.FireStation, incidentRegister As IMSService.IncidentRegister, lstIncidentTypes As List(Of IMSService.IncidentType), ByVal stationNames As String)

        Dim strTypeCodes As String = String.Empty

        Dim txtReferenceNo = CType(headerSection.ReportObjects("txtReferenceNo"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim txtCategoryReference = CType(headerSection.ReportObjects("txtCategoryReference"), CrystalDecisions.CrystalReports.Engine.TextObject)
        Dim txtStation = CType(headerSection.ReportObjects("txtStation"), CrystalDecisions.CrystalReports.Engine.TextObject)

        If Not IsNothing(txtReferenceNo) Then
            If Not IsNothing(primaryStation) Then
                txtReferenceNo.Text = primaryStation.StationLetter + "/" + incidentRegister.ReferenceNo
            Else
                txtReferenceNo.Text = incidentRegister.ReferenceNo
            End If
        End If

        If lstIncidentTypes.Count > 0 Then
            For Each obj As IMSService.IncidentType In lstIncidentTypes
                strTypeCodes += obj.IncidentTypeCode + " "
            Next
        End If

        If Not IsNothing(txtCategoryReference) Then
            txtCategoryReference.Text = strTypeCodes
        End If

        If Not IsNothing(txtStation) Then
            txtStation.Text = stationNames
        End If

    End Sub

    ''' <summary>
    ''' Method to set Fire Report data.
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <param name="IncidentRegister"></param>
    ''' <param name="applianceFirstArrivalTimeToIncident"></param>
    ''' <param name="applianceLastBackToStationTime"></param>
    ''' <remarks></remarks>
    Private Sub SetFireReport(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook, _
                              ByVal IncidentRegister As IncidentRegister)

        '(Category "Fire" )
        With objOccurrenceBook

            'If Not IsNothing(IncidentRegister) Then
            '    Dim txtAddressOfFire = CType(headerSection.ReportObjects("txtAddressOfFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
            '    If Not IsNothing(txtAddressOfFire) Then
            '        txtAddressOfFire.Text = IncidentRegister.Address
            '    End If
            'End If

            Dim txtSupposeCause = CType(headerSection.ReportObjects("txtSupposeCause"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtSupposeCause) Then
                txtSupposeCause.Text = .SupposedCauses
            End If

            Dim txtDescriptionOfPropertyInvolved = CType(headerSection.ReportObjects("txtDescriptionOfPropertyInvolved"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtDescriptionOfPropertyInvolved) Then
                txtDescriptionOfPropertyInvolved.Text = .InvolvedPropertyFire
            End If

            Dim txtParticularsOfContentsOfProperty = CType(headerSection.ReportObjects("txtParticularsOfContentsOfProperty"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtParticularsOfContentsOfProperty) Then
                txtParticularsOfContentsOfProperty.Text = .ParticularsOfContentsOfPropertyFire
            End If

            Dim txtWhereFireStarted = CType(headerSection.ReportObjects("txtWhereFireStarted"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtWhereFireStarted) Then
                txtWhereFireStarted.Text = .WhereIncidentStarted
            End If

            Dim txtWhereFireSpreadto = CType(headerSection.ReportObjects("txtWhereFireSpreadto"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtWhereFireSpreadto) Then
                txtWhereFireSpreadto.Text = .WhereIncidentSpreadTo
            End If

            Dim txtDescriptionOfDamage = CType(headerSection.ReportObjects("txtDescriptionOfDamage"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtDescriptionOfDamage) Then
                txtDescriptionOfDamage.Text = .DescriptionOfDamageFire
            End If

            Dim txtFixedInstallation = CType(headerSection.ReportObjects("txtFixedInstallation"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtFixedInstallation) Then
                txtFixedInstallation.Text = .FixedInstallation
            End If

            Dim txtApproximateValueOfDamage = CType(headerSection.ReportObjects("txtApproximateValueOfDamage"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtApproximateValueOfDamage) Then
                txtApproximateValueOfDamage.Text = .ApproximateValueOfDamage
            End If
        End With

    End Sub

    ''' <summary>
    ''' Method to Set Fire report second page.
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <param name="IncidentRegister"></param>
    ''' <param name="totalNumberOfPersonalAttending"></param>
    ''' <remarks></remarks>
    Private Sub SetFireReportSecondPage(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook, _
                              ByVal IncidentRegister As IncidentRegister, ByVal totalNumberOfPersonalAttending As Integer)

        '(Category "Fire" 2nd page )
        With objOccurrenceBook

            Dim txtMethodOfExtinguishingFire = CType(headerSection.ReportObjects("txtMethodOfExtinguishingFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtMethodOfExtinguishingFire) Then
                txtMethodOfExtinguishingFire.Text = .MethodOfextinguishingFire
            End If

            Dim txtTotalNumberOfPersonalAttending = CType(headerSection.ReportObjects("txtTotalNumberOfPersonalAttending"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtTotalNumberOfPersonalAttending) Then
                txtTotalNumberOfPersonalAttending.Text = CommonFunction.GetIntegerInWord(totalNumberOfPersonalAttending) + " (" + totalNumberOfPersonalAttending.ToString() + ") "
            End If

            Dim txtAppliancesAttendingOtherThanFireService = CType(headerSection.ReportObjects("txtAppliancesAttendingOtherThanFireService"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtAppliancesAttendingOtherThanFireService) Then
                txtAppliancesAttendingOtherThanFireService.Text = .ApplianceOtherThanFireServiceFire
            End If

            Dim txtRemarksFire = CType(headerSection.ReportObjects("txtRemarksFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtRemarksFire) Then
                txtRemarksFire.Text = .RemarksFire
            End If

            Dim txtReportDateFire = CType(headerSection.ReportObjects("txtReportDateFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtReportDateFire) Then
                txtReportDateFire.Text = .ReportDate.ToString("dd/mm/yyyy")
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to Set Special service report second page.
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <param name="IncidentRegister"></param>
    ''' <param name="totalNumberOfPersonalAttending"></param>
    ''' <remarks></remarks>
    Private Sub SetSpecialServiceReportSecondPage(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook, _
                              ByVal IncidentRegister As IncidentRegister, ByVal totalNumberOfPersonalAttending As Integer)

        '(Category "Fire" 2nd page )
        With objOccurrenceBook

            Dim txtTotalNumberOfPersonalAttending = CType(headerSection.ReportObjects("txtTotalNumberOfPersonalAttending"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtTotalNumberOfPersonalAttending) Then
                txtTotalNumberOfPersonalAttending.Text = CommonFunction.GetIntegerInWord(totalNumberOfPersonalAttending) + " (" + totalNumberOfPersonalAttending.ToString() + ") "
            End If

            Dim txtAppliancesAttendingOtherThanFireService = CType(headerSection.ReportObjects("txtAppliancesAttendingOtherThanFireService"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtAppliancesAttendingOtherThanFireService) Then
                txtAppliancesAttendingOtherThanFireService.Text = .ApplianceOtherThanFireServiceFire
            End If

            Dim txtRemarksFire = CType(headerSection.ReportObjects("txtRemarksFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtRemarksFire) Then
                txtRemarksFire.Text = .RemarksFire
            End If

            Dim txtReportDateFire = CType(headerSection.ReportObjects("txtReportDateFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtReportDateFire) Then
                txtReportDateFire.Text = .ReportDate.ToString("dd/mm/yyyy")
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to Set Common Fields for "Fire" and "Special Service"
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <param name="IncidentRegister"></param>
    ''' <param name="applianceFirstArrivalTimeToIncident"></param>
    ''' <param name="applianceLastBackToStationTime"></param>
    ''' <remarks></remarks>
    Private Sub SetCommonFireAndSpecialService(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook, _
                              ByVal IncidentRegister As IncidentRegister, ByVal applianceFirstArrivalTimeToIncident As DateTime, _
                              ByVal applianceLastBackToStationTime As DateTime)

        '(Common for Category "Fire" and "Special Service" )
        With objOccurrenceBook

            If Not IsNothing(objOccurrenceBook) Then

                Dim txtNameOfOccupier = CType(headerSection.ReportObjects("txtNameOfOccupier"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtNameOfOccupier) Then
                    txtNameOfOccupier.Text = .NameOfOccupierFire
                End If

                Dim txtTradeOfBusinessCarriedOn = CType(headerSection.ReportObjects("txtTradeOfBusinessCarriedOn"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTradeOfBusinessCarriedOn) Then
                    txtTradeOfBusinessCarriedOn.Text = .BusinessCarriedOnFire
                End If

                Dim txtTimeOfDiscovery = CType(headerSection.ReportObjects("txtTimeOfDiscovery"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTimeOfDiscovery) Then
                    txtTimeOfDiscovery.Text = .TimeOfDiscovery
                End If

                Dim txtTimeOfUnderControll = CType(headerSection.ReportObjects("txtTimeOfUnderControll"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTimeOfUnderControll) Then
                    txtTimeOfUnderControll.Text = .TimeOfUnderControl
                End If

                Dim txtDiscoveredBy = CType(headerSection.ReportObjects("txtDiscoveredBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtDiscoveredBy) Then
                    txtDiscoveredBy.Text = .DiscoveredBy
                End If

            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to Set All Common Fields for Four reports (But Grass fire)
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <param name="IncidentRegister"></param>
    ''' <param name="applianceFirstArrivalTimeToIncident"></param>
    ''' <param name="applianceLastBackToStationTime"></param>
    ''' <remarks></remarks>
    Private Sub SetCommonForFourReports(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook, _
                              ByVal IncidentRegister As IncidentRegister, ByVal applianceFirstArrivalTimeToIncident As DateTime, _
                              ByVal applianceLastBackToStationTime As DateTime)

        '(Common for Category "Fire" and "Special Service" )
        With objOccurrenceBook

            If Not IsDBNull(.TimeOfCall) Or Not String.IsNullOrEmpty(.TimeOfCall) Then
                Dim callDate As Date = .TimeOfCall
                Dim txtDateAndDayOfCall = CType(headerSection.ReportObjects("txtDateAndDayOfCall"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtDateAndDayOfCall) Then
                    txtDateAndDayOfCall.Text = callDate.ToString("dd/MM/yy") + " " + callDate.DayOfWeek.ToString()
                End If
            End If

            If Not IsNothing(IncidentRegister) Then
                Dim txtAddressOfFire = CType(headerSection.ReportObjects("txtAddressOfFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtAddressOfFire) Then
                    txtAddressOfFire.Text = IncidentRegister.Address
                End If
            End If

            If Not IsNothing(objOccurrenceBook) Then

                Dim txtMethodOfFireServiceCallling = CType(headerSection.ReportObjects("txtMethodOfFireServiceCallling"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtMethodOfFireServiceCallling) Then
                    txtMethodOfFireServiceCallling.Text = .MethodOfCalling
                End If

                Dim txtTimeOfCall = CType(headerSection.ReportObjects("txtTimeOfCall"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTimeOfCall) Then
                    txtTimeOfCall.Text = .TimeOfCall
                End If

                Dim txtWeatherCondition = CType(headerSection.ReportObjects("txtWeatherCondition"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtWeatherCondition) Then
                    txtWeatherCondition.Text = .WeatherCondition
                End If

            End If

            Dim txtTimeOfArrivalOfFS = CType(headerSection.ReportObjects("txtTimeOfArrivalOfFS"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtTimeOfArrivalOfFS) Then
                If Not applianceFirstArrivalTimeToIncident = DateTime.MinValue Then
                    txtTimeOfArrivalOfFS.Text = applianceFirstArrivalTimeToIncident
                Else
                    txtTimeOfArrivalOfFS.Text = IMSConstants.Common.N_A
                End If
            End If

            Dim txtLastApplianceBackToStationDate = CType(headerSection.ReportObjects("txtLastApplianceBackToStationDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtLastApplianceBackToStationDate) Then
                If Not applianceLastBackToStationTime = DateTime.MinValue Then
                    txtLastApplianceBackToStationDate.Text = applianceLastBackToStationTime.ToString("dd/MM/yy")
                Else
                    txtLastApplianceBackToStationDate.Text = IMSConstants.Common.N_A
                End If
            End If

            Dim txtLastApplianceBackToStationTime = CType(headerSection.ReportObjects("txtLastApplianceBackToStationTime"), CrystalDecisions.CrystalReports.Engine.TextObject)
            If Not IsNothing(txtLastApplianceBackToStationTime) Then
                If Not applianceLastBackToStationTime = DateTime.MinValue Then
                    txtLastApplianceBackToStationTime.Text = applianceLastBackToStationTime.ToString("HH:mm:ss")
                Else
                    txtLastApplianceBackToStationTime.Text = IMSConstants.Common.N_A
                End If
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to Set Others fields of Special Service
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <remarks></remarks>
    Private Sub SetSpecialServiceReport(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook)

        '(Others fields of "Special Service" )

        If Not IsNothing(objOccurrenceBook) Then
            With objOccurrenceBook

                Dim txtNatureAndCauseOfIncident = CType(headerSection.ReportObjects("txtNatureAndCauseOfIncident"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtNatureAndCauseOfIncident) Then
                    txtNatureAndCauseOfIncident.Text = .SupposedCauses
                End If

                Dim txtDescriptionOfPropertyInvolved = CType(headerSection.ReportObjects("txtDescriptionOfPropertyInvolved"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtDescriptionOfPropertyInvolved) Then
                    txtDescriptionOfPropertyInvolved.Text = .InvolvedPropertySpecialService
                End If

                Dim txtDescriptionOfDamage = CType(headerSection.ReportObjects("txtDescriptionOfDamage"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtDescriptionOfDamage) Then
                    txtDescriptionOfDamage.Text = .DescriptionOfDamageSpecialService
                End If

                Dim txtServiceRenderedByFireService = CType(headerSection.ReportObjects("txtServiceRenderedByFireService"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtServiceRenderedByFireService) Then
                    txtServiceRenderedByFireService.Text = .ServicesRenderedByFireService
                End If

                Dim TxtChargeE = CType(headerSection.ReportObjects("TxtChargeE"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(TxtChargeE) Then
                    TxtChargeE.Text = .AnyCharges
                End If

                'Involved appliance
                Dim txtEquipmentUsedByFireService = CType(headerSection.ReportObjects("txtEquipmentUsedByFireService"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtEquipmentUsedByFireService) Then
                    txtEquipmentUsedByFireService.Text = .EquipmentUsedByFireService '' Previous Logic: (take the serial number which where involved with this incident) - CommonFunction.GetCommaSeparatedApplienceByIncidentID(.IncidentID)
                End If

            End With
        End If
    End Sub

    ''' <summary>
    ''' Method to Set "False Alerm" Report
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <remarks></remarks>
    Private Sub SetFalseAlermReport(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook)

        '(Others fields of "Flase Alerm" )

        If Not IsNothing(objOccurrenceBook) Then
            With objOccurrenceBook

                Dim txtNatureOfFalseAlarm = CType(headerSection.ReportObjects("txtNatureOfFalseAlarm"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtNatureOfFalseAlarm) Then
                    txtNatureOfFalseAlarm.Text = .NatureOfFalseAlerm
                End If

                Dim txtTotalNumberOfPersonalAttending = CType(headerSection.ReportObjects("txtTotalNumberOfPersonalAttending"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTotalNumberOfPersonalAttending) Then
                    txtTotalNumberOfPersonalAttending.Text = CommonFunction.GetIntegerInWord(totalNumberOfPersonalAttending) + " (" + totalNumberOfPersonalAttending.ToString() + ") "
                End If

                Dim txtRemarksFalseAlerm = CType(headerSection.ReportObjects("txtRemarksFalseAlerm"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtRemarksFalseAlerm) Then
                    txtRemarksFalseAlerm.Text = .RemarksFalseAlarm
                End If

                Dim txtAppliancesAttendingOtherThanFireService = CType(headerSection.ReportObjects("txtAppliancesAttendingOtherThanFireService"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtAppliancesAttendingOtherThanFireService) Then
                    txtAppliancesAttendingOtherThanFireService.Text = .ApplianceOtherThanFireServiceFalseAlerm
                End If

                Dim txtReportDate = CType(headerSection.ReportObjects("txtReportDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtReportDate) Then
                    txtReportDate.Text = .ReportDate.ToString("dd/mm/yy")
                End If

            End With
        End If
    End Sub

    ''' <summary>
    ''' Method to Set "Stand By" Report
    ''' </summary>
    ''' <param name="headerSection"></param>
    ''' <param name="objOccurrenceBook"></param>
    ''' <remarks></remarks>
    Private Sub SetStandByReport(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook)

        '(Others fields of "Flase Alerm" )

        If Not IsNothing(objOccurrenceBook) Then
            With objOccurrenceBook


                Dim txtDeatilsOfCause = CType(headerSection.ReportObjects("txtDeatilsOfCause"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtDeatilsOfCause) Then
                    txtDeatilsOfCause.Text = .SupposedCauses
                End If

                Dim txtReasonForStandBy = CType(headerSection.ReportObjects("txtReasonForStandBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtReasonForStandBy) Then
                    txtReasonForStandBy.Text = .ReasonOfStandBy
                End If

                Dim txtTotalNumberOfPersonalAttending = CType(headerSection.ReportObjects("txtTotalNumberOfPersonalAttending"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTotalNumberOfPersonalAttending) Then
                    txtTotalNumberOfPersonalAttending.Text = CommonFunction.GetIntegerInWord(totalNumberOfPersonalAttending) + " (" + totalNumberOfPersonalAttending.ToString() + ") "
                End If

                Dim txtRemarks = CType(headerSection.ReportObjects("txtRemarks"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtRemarks) Then
                    txtRemarks.Text = .RemarksStandby
                End If

                Dim txtReportDate = CType(headerSection.ReportObjects("txtReportDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtReportDate) Then
                    txtReportDate.Text = .ReportDate.ToString("dd/mm/yy")
                End If

            End With
        End If
    End Sub


    Private Sub SetGrassFireReport(ByVal headerSection As CrystalDecisions.CrystalReports.Engine.Section, ByVal objOccurrenceBook As OccurrenceBook, ByVal incidentRegister As IncidentRegister)

        '(Others fields of "Grass Fire" )

        If Not IsNothing(objOccurrenceBook) Then
            With objOccurrenceBook

                If Not IsDBNull(.TimeOfCall) Or Not String.IsNullOrEmpty(.TimeOfCall) Then
                    Dim callDate As Date = .TimeOfCall
                    Dim txtDateAndDayOfCall = CType(headerSection.ReportObjects("txtDateAndDayOfCall"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtDateAndDayOfCall) Then
                        txtDateAndDayOfCall.Text = callDate.ToString("dd/MM/yy") + " " + callDate.DayOfWeek.ToString()
                    End If
                End If

                If Not IsNothing(IncidentRegister) Then
                    Dim txtCallersName = CType(headerSection.ReportObjects("txtCallersName"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtCallersName) Then
                        txtCallersName.Text = incidentRegister.CallerFullName
                    End If

                    Dim txtAddressOfFire = CType(headerSection.ReportObjects("txtAddressOfFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtAddressOfFire) Then
                        txtAddressOfFire.Text = incidentRegister.Address
                    End If
                End If

                If Not IsNothing(objOccurrenceBook) Then

                    Dim txtSupposedCause = CType(headerSection.ReportObjects("txtSupposedCause"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtSupposedCause) Then
                        txtSupposedCause.Text = .SupposedCauses
                    End If

                    Dim txtApproximateDamage = CType(headerSection.ReportObjects("txtApproximateDamage"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtApproximateDamage) Then
                        txtApproximateDamage.Text = .ApproximateDamageGrassFire
                    End If

                    Dim txtMethodOfExtinguishing = CType(headerSection.ReportObjects("txtMethodOfExtinguishing"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtMethodOfExtinguishing) Then
                        txtMethodOfExtinguishing.Text = .MethodOfextinguishing
                    End If

                    Dim txtTotalNumberOAttendingfPersonal = CType(headerSection.ReportObjects("txtTotalNumberOfPersonalAttending"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtTotalNumberOAttendingfPersonal) Then
                        txtTotalNumberOAttendingfPersonal.Text = CommonFunction.GetIntegerInWord(totalNumberOfPersonalAttending) + " (" + totalNumberOfPersonalAttending.ToString() + ") "
                    End If

                    Dim txtRemarksGrassFire = CType(headerSection.ReportObjects("txtRemarksGrassFire"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtRemarksGrassFire) Then
                        txtRemarksGrassFire.Text = .RemarksGrassFire
                    End If

                    Dim txtReportDateGrassFire = CType(headerSection.ReportObjects("txtReportDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtReportDateGrassFire) Then
                        txtReportDateGrassFire.Text = .ReportDate.ToString("dd/mm/yy")
                    End If

                    Dim txtResolveTime = CType(headerSection.ReportObjects("txtResolveTime"), CrystalDecisions.CrystalReports.Engine.TextObject)
                    If Not IsNothing(txtResolveTime) Then
                        txtResolveTime.Text = .TimeOfUnderControl
                    End If

                End If

                'Dim txtDeatilsOfCause = CType(headerSection.ReportObjects("txtDeatilsOfCause"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'If Not IsNothing(txtDeatilsOfCause) Then
                '    txtDeatilsOfCause.Text = .SupposedCauses
                'End If

                'Dim txtReasonForStandBy = CType(headerSection.ReportObjects("txtReasonForStandBy"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'If Not IsNothing(txtReasonForStandBy) Then
                '    txtReasonForStandBy.Text = .ReasonOfStandBy
                'End If

                'Dim txtTotalNumberOfPersonalAttending = CType(headerSection.ReportObjects("txtTotalNumberOfPersonalAttending"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'If Not IsNothing(txtTotalNumberOfPersonalAttending) Then
                '    txtTotalNumberOfPersonalAttending.Text = CommonFunction.GetIntegerInWord(totalNumberOfPersonalAttending) + " (" + totalNumberOfPersonalAttending.ToString() + ") "
                'End If

                'Dim txtRemarks = CType(headerSection.ReportObjects("txtRemarks"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'If Not IsNothing(txtRemarks) Then
                '    txtRemarks.Text = .RemarksStandby
                'End If

                'Dim txtReportDate = CType(headerSection.ReportObjects("txtReportDate"), CrystalDecisions.CrystalReports.Engine.TextObject)
                'If Not IsNothing(txtReportDate) Then
                '    txtReportDate.Text = .ReportDate.ToString("dd/mm/yy")
                'End If

            End With
        End If
    End Sub


    ''' <summary>
    ''' Method to Get Attending Appliance List
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAttendingApplianceList() As List(Of ApplianceAttending)

        Dim lstEmployee As New List(Of IMSService.Employee)
        Dim applienceCode As String = String.Empty
        Dim objDispatchLog As DispatchLog
        Dim lstApplianceAttending As New List(Of ApplianceAttending)
        Dim objApplianceAttending As ApplianceAttending


        Dim lstFireStationAppliance As List(Of IMSService.FireStationAppliance) = CommonFunction.GetApplienceByIncidentID(incidentID)
        If lstFireStationAppliance.Count > 0 Then

            For Each obj As IMSService.FireStationAppliance In lstFireStationAppliance

                objApplianceAttending = New ApplianceAttending
                With objApplianceAttending

                    .ApplianceSerial = obj.SerialNumber

                    Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(obj.ApplianceID)
                    If Not IsNothing(objApplience) Then
                        .ApplianceType = objApplience.ApplianceCode
                    End If

                    Dim objStation As IMSService.FireStation = _proxy.GetFireStationByID(obj.StationID)
                    If Not IsNothing(objStation) Then
                        .Station = objStation.StationName
                    End If

                    objDispatchLog = CommonFunction.GetFirstDispatchLogByIncidentIDAndStationApplianceID(incidentID, obj.StationApplianceID)
                    If Not IsNothing(objDispatchLog) Then

                        If objDispatchLog.TimeOfArrival <> Date.Parse(IMSConstants.Settings.DateTimeDefault) Then
                            .TimeOfArrival = objDispatchLog.TimeOfArrival.ToString()
                        End If
                    End If
                End With

                lstApplianceAttending.Add(objApplianceAttending)

            Next
        End If

        Return lstApplianceAttending

    End Function

    ''' <summary>
    ''' Method to Get Enum description.
    ''' </summary>
    ''' <param name="currentEnum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDescription(ByVal currentEnum As [Enum]) As String

        Dim description As String = String.Empty
        Dim da As DescriptionAttribute

        Dim fi As FieldInfo = currentEnum.GetType.GetField(currentEnum.ToString)
        da = DirectCast(Attribute.GetCustomAttribute(fi, GetType(DescriptionAttribute)), DescriptionAttribute)
        If da IsNot Nothing Then
            description = da.Description
        Else
            description = currentEnum.ToString
        End If

        Return description

    End Function

    ''' <summary>
    ''' Method to Get Person Rescued (For Report) By Incident ID and Incident Category
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="incidentCategory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPersonRescued(ByVal incidentID As Integer, ByVal incidentCategory As Integer) As List(Of PersonRescuedForReport)

        Dim lstPersonRescuedForReport As New List(Of PersonRescuedForReport)
        Dim objPersonRescuedForReport As New PersonRescuedForReport
        Dim lstPersonRescued As List(Of PersonsRescuedAndEscaping) = CommonFunction.GetPersonRescuedByIncidentIDAndCategory(incidentID, incidentCategory)

        If lstPersonRescued.Count > 0 Then
            'Craete new list for show at report.
            For Each objPersonRescued As PersonsRescuedAndEscaping In lstPersonRescued

                objPersonRescuedForReport = New PersonRescuedForReport

                With objPersonRescuedForReport

                    .Name = objPersonRescued.Name
                    .Age = objPersonRescued.Age
                    If objPersonRescued.Sex > 0 Then
                        .Sex = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), objPersonRescued.Sex))
                    Else
                        .Sex = String.Empty
                    End If
                    .MethodOfRescue = objPersonRescued.Method
                    .PersonEffectingRescue = objPersonRescued.PersonEfectingRescue

                End With

                lstPersonRescuedForReport.Add(objPersonRescuedForReport)

            Next
        End If

        Return lstPersonRescuedForReport

    End Function

    ''' <summary>
    ''' Method to Get Casualties (For Report) By Incident ID and Incident category.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="incidentCategory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCasualties(ByVal incidentID As Integer, ByVal incidentCategory As Integer) As List(Of CasualtiesForReport)

        Dim lstCasualtiesForReport As New List(Of CasualtiesForReport)
        Dim objCasualtiesForReport As New CasualtiesForReport
        Dim lstCasualties As List(Of Casualities) = CommonFunction.GetCasualtiesByIncidentIDAndCategory(incidentID, incidentCategory)

        If lstCasualties.Count > 0 Then
            'Craete new list for show at report.
            For Each obj As Casualities In lstCasualties

                objCasualtiesForReport = New CasualtiesForReport

                With objCasualtiesForReport

                    .Name = obj.Name
                    .Age = obj.Age
                    If obj.Sex > 0 Then
                        .Sex = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), obj.Sex))
                    Else
                        .Sex = String.Empty
                    End If
                    .Address = obj.Address
                    .NatureOfInjury = obj.NatureOfInjury
                    .IfFatal = [Enum].GetName(GetType(IMSEnums.IfFatal), obj.IfFatal)

                End With

                lstCasualtiesForReport.Add(objCasualtiesForReport)

            Next
        End If

        Return lstCasualtiesForReport

    End Function

    ''' <summary>
    ''' Method to Get All person attending at the incident.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAttendingPersonList() As List(Of PersonAttending)

        Dim lstPersonAttending As New List(Of PersonAttending)
        Dim objPersonAttending As PersonAttending
        Dim objStation As IMSService.FireStation

        Dim lstEmployee As List(Of Employee) = CommonFunction.GetEmployeeByIncidentID(incidentID)
        If lstEmployee.Count > 0 Then

            For Each obj As Employee In lstEmployee
                objPersonAttending = New PersonAttending()

                With objPersonAttending
                    .PersonName = obj.EmployeeName
                    .Rank = ""
                    objStation = _proxy.GetFireStationByID(obj.StationID)
                    If Not IsNothing(objStation) Then
                        .Station = objStation.StationName
                    End If
                End With
                lstPersonAttending.Add(objPersonAttending)
            Next
        End If

        Return lstPersonAttending

    End Function


#End Region

#Region "Event Handlers"

    Private Sub frmShowReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            Dim sql As String = String.Empty
            Dim lstOccurrenceBook As New List(Of IMSService.OccurrenceBook)
            Dim incidentRegister As New IMSService.IncidentRegister
            Dim occurrenceBook As New OccurrenceBook
            'Dim strTypeCodes As String = String.Empty

            'Get incident Register
            incidentRegister = _proxy.GetIncidentRegisterByID(incidentID)

            'get some informations
            Dim lstIncidentTypes As List(Of IMSService.IncidentType) = CommonFunction.GetIncidentTypesByCategoryAndIncidentID(incidentID, incidentCategory)
            Dim stationNames As String = CommonFunction.GetStationsInCommaSeparated(incidentID)
            Dim primaryStation As IMSService.FireStation = CommonFunction.GetPrimaryStationByIncidentID(incidentID)

            'Get Occurrence Book
            sql = IMSConstants.FieldConstants.IncidentID & " = " & incidentID.ToString()
            lstOccurrenceBook = _proxy.GetFilteredOccurrenceBook(sql).Cast(Of IMSService.OccurrenceBook).ToList()

            'Time of First Appliance Arrival time at Incident.
            Dim applianceFirstArrivalTimeToIncident As DateTime = CommonFunction.GetTimeOfFirstArrivalOfFireService(incidentID)

            'Time of Last Appliance Back to Station.
            Dim applianceLastBackToStationTime As DateTime = CommonFunction.GetTimeOfLastApplianceBackToStation(incidentID)

            If lstOccurrenceBook.Count > 0 Then

                Dim doc As ReportDocument = New ReportDocument()
                doc.Load(Application.StartupPath + GetReportPathDependingOnCategories(incidentCategory))

                ''(Section 1 - Header block)

                Dim headerSection = doc.ReportDefinition.Sections("Section1")
                If Not IsNothing(headerSection) Then
                    SetCommonLabels(headerSection, primaryStation, incidentRegister, lstIncidentTypes, stationNames)
                End If

                '(Section - 2. Description)
                'TODO: call depending on Incident Categories (Fire, Special service, stand by, False alerm)

                Select Case incidentCategory
                    Case CInt(IMSEnums.IncidentCategory.Fire) ''( 1 - Fire)

                        '' Grass Fire
                        If Me.IsGrassFire Then

                            Dim lstApplianceAttending As List(Of ApplianceAttending) = Me.GetAttendingApplianceList()
                            Dim lstPersonAttending As List(Of PersonAttending) = Me.GetAttendingPersonList()
                            totalNumberOfPersonalAttending = lstPersonAttending.Count

                            SetGrassFireReport(headerSection, lstOccurrenceBook(0), incidentRegister)

                            If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending)) Then
                                doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending).SetDataSource(lstApplianceAttending)
                            End If

                            If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending)) Then
                                doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending).SetDataSource(lstPersonAttending)
                            End If

                        Else
                            ''Other Fire
                            
                            SetCommonFireAndSpecialService(headerSection, lstOccurrenceBook(0), incidentRegister, applianceFirstArrivalTimeToIncident, applianceLastBackToStationTime)
                            SetCommonForFourReports(headerSection, lstOccurrenceBook(0), incidentRegister, applianceFirstArrivalTimeToIncident, applianceLastBackToStationTime)
                            SetFireReport(headerSection, lstOccurrenceBook(0), incidentRegister)
                            doc.SetDataSource(lstOccurrenceBook)

                            'Rescued and casualties (Sub Reports)
                            Dim lstPersonsRescuedForFireReport As List(Of PersonRescuedForReport) = Me.GetPersonRescued(Me.incidentID, IMSEnums.IncidentCategory.Fire)
                            Dim lstCasualtiesForFireReport As List(Of CasualtiesForReport) = Me.GetCasualties(Me.incidentID, IMSEnums.IncidentCategory.Fire)

                            If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonRescued)) Then
                                doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonRescued).SetDataSource(lstPersonsRescuedForFireReport)
                            End If
                            If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportCasualties)) Then
                                doc.Subreports(IMSConstants.Settings.PathOf_SubReportCasualties).SetDataSource(lstCasualtiesForFireReport)
                            End If

                            'Attending Appliance and Officer.
                            Dim lstApplianceAttending As List(Of ApplianceAttending) = GetAttendingApplianceList()
                            Dim lstPersonAttending As List(Of PersonAttending) = GetAttendingPersonList()
                            totalNumberOfPersonalAttending = lstPersonAttending.Count

                            If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending)) Then
                                doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending).SetDataSource(lstApplianceAttending)
                            End If
                            If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending)) Then
                                doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending).SetDataSource(lstPersonAttending)
                            End If

                            '2nd page fields

                            Me.SetFireReportSecondPage(headerSection, lstOccurrenceBook(0), incidentRegister, totalNumberOfPersonalAttending)

                        End If

                    Case CInt(IMSEnums.IncidentCategory.SpecialService) ''( 2 - Special Service)

                        SetCommonFireAndSpecialService(headerSection, lstOccurrenceBook(0), incidentRegister, applianceFirstArrivalTimeToIncident, applianceLastBackToStationTime)
                        SetCommonForFourReports(headerSection, lstOccurrenceBook(0), incidentRegister, applianceFirstArrivalTimeToIncident, applianceLastBackToStationTime)
                        SetSpecialServiceReport(headerSection, lstOccurrenceBook(0))

                        'Rescued and casualties
                        Dim lstPersonsRescuedForFireReport As List(Of PersonRescuedForReport) = Me.GetPersonRescued(Me.incidentID, IMSEnums.IncidentCategory.SpecialService)
                        Dim lstCasualtiesForFireReport As List(Of CasualtiesForReport) = Me.GetCasualties(Me.incidentID, IMSEnums.IncidentCategory.SpecialService)

                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonRescued)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonRescued).SetDataSource(lstPersonsRescuedForFireReport)
                        End If
                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportCasualties)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubReportCasualties).SetDataSource(lstCasualtiesForFireReport)
                        End If

                        'Attending Appliance and Officer.
                        Dim lstApplianceAttending As List(Of ApplianceAttending) = GetAttendingApplianceList()
                        Dim lstPersonAttending As List(Of PersonAttending) = GetAttendingPersonList()
                        totalNumberOfPersonalAttending = lstPersonAttending.Count

                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending).SetDataSource(lstApplianceAttending)
                        End If
                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending).SetDataSource(lstPersonAttending)
                        End If

                        '2nd page fields (special service)
                        Me.SetSpecialServiceReportSecondPage(headerSection, lstOccurrenceBook(0), incidentRegister, totalNumberOfPersonalAttending)


                    Case CInt(IMSEnums.IncidentCategory.FalseAlerm) ''( 3 - False Alerm)

                        Dim lstApplianceAttending As List(Of ApplianceAttending) = GetAttendingApplianceList()
                        Dim lstPersonAttending As List(Of PersonAttending) = GetAttendingPersonList()
                        totalNumberOfPersonalAttending = lstPersonAttending.Count

                        SetCommonForFourReports(headerSection, lstOccurrenceBook(0), incidentRegister, applianceFirstArrivalTimeToIncident, applianceLastBackToStationTime)
                        SetFalseAlermReport(headerSection, lstOccurrenceBook(0))

                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubRptFireServiceApplianceShortWidth)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubRptFireServiceApplianceShortWidth).SetDataSource(lstApplianceAttending)
                        End If
                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubPersonnelShortWidth)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubPersonnelShortWidth).SetDataSource(lstPersonAttending)
                        End If

                    Case CInt(IMSEnums.IncidentCategory.StandBy) ''( 4 - Stand By)

                        Dim lstApplianceAttending As List(Of ApplianceAttending) = GetAttendingApplianceList()
                        Dim lstPersonAttending As List(Of PersonAttending) = GetAttendingPersonList()
                        totalNumberOfPersonalAttending = lstPersonAttending.Count

                        SetCommonForFourReports(headerSection, lstOccurrenceBook(0), incidentRegister, applianceFirstArrivalTimeToIncident, applianceLastBackToStationTime)
                        SetStandByReport(headerSection, lstOccurrenceBook(0))

                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubReportApplianceAttending).SetDataSource(lstApplianceAttending)
                        End If
                        If Not IsNothing(doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending)) Then
                            doc.Subreports(IMSConstants.Settings.PathOf_SubReportPersonnelAttending).SetDataSource(lstPersonAttending)
                        End If

                    Case Else
                        'String.Empty
                        Exit Select

                End Select

                ''False Alerm

                reportViewer.ReportSource = doc
                reportViewer.Refresh()

            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

End Class