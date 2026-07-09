
Imports IMS.Lib
Imports System.Globalization
Imports System.Reflection
Imports System.ComponentModel
Imports Infragistics.Win

Public Class frmAddResolvedIncident
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private _incidentID As Integer
    Private _IsUpdate As Boolean = False
    Private mOccurrenceBook As New IMSService.OccurrenceBook

    '@list for report extension

    '#1: Fire Persons Rescued
    Private _lstGFPersonRescued As New List(Of IMSService.PersonsRescuedAndEscaping)
    Private _lstGFPersonRescuedEdited As New List(Of Integer)
    Private _lstGFPersonRescuedDeleted As New List(Of IMSService.PersonsRescuedAndEscaping)
    Private _selectedIndexOfGridGFPersonRescued As Integer
    Private _isUpdateGFPersonRescued As Boolean = False
    '#2: Fire Casualties
    Private _lstFireCasualties As New List(Of IMSService.Casualities)
    Private _lstFireCasualtiesEdited As New List(Of Integer)
    Private _lstFireCasualtiesDeleted As New List(Of IMSService.Casualities)
    Private _selectedIndexOfGridFireCasualties As Integer
    Private _isUpdateFireCasualties As Boolean = False
    '#3: Fire Persons Rescued
    Private _lstSPSPersonRescued As New List(Of IMSService.PersonsRescuedAndEscaping)
    Private _lstSPSPersonRescuedEdited As New List(Of Integer)
    Private _lstSPSPersonRescuedDeleted As New List(Of IMSService.PersonsRescuedAndEscaping)
    Private _selectedIndexOfGridSPSPersonRescued As Integer
    Private _isUpdateSPSPersonRescued As Boolean = False
    '#4: SPS Casualties
    Private _lstSPSCasualties As New List(Of IMSService.Casualities)
    Private _lstSPSCasualtiesEdited As New List(Of Integer)
    Private _lstSPSCasualtiesDeleted As New List(Of IMSService.Casualities)
    Private _selectedIndexOfGridSPSCasualties As Integer
    Private _isUpdateSPSCasualties As Boolean = False

#End Region

#Region "Events"
    Public Event UpdateIncident()
#End Region

#Region "Constructors"

    Public Sub New()


        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        '_incidentID = 1
    End Sub

    Public Sub New(incidentID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _incidentID = incidentID


    End Sub

    Public Sub New(incidentID As Integer, ByVal IsViewed As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _incidentID = incidentID
        btnSave.Visible = False


    End Sub


#End Region

#Region "Private Methods"

    Private Sub SetFormData()

        Dim lstEmployee As List(Of IMSService.Employee) = New List(Of IMSService.Employee)

        Dim lstFireStationAppliance As List(Of IMSService.FireStationAppliance) = New List(Of IMSService.FireStationAppliance)
        Dim objIncident As IMSService.IncidentRegister = _proxy.GetIncidentRegisterByID(_incidentID)

        If Not IsNothing(objIncident) Then
            txtReferenceNo.Text = objIncident.ReferenceNo
            dtpReportDateTime.Value = DateTime.Now
            'dtpTimeOfArrival.Text = String.Empty
            dtpTimeOfCall.Value = objIncident.InsertionDate
        End If

        lstFireStationAppliance = CommonFunction.GetApplienceByIncidentID(_incidentID)
        If lstFireStationAppliance.Count > 0 Then
            Me.ViewApplience(lstFireStationAppliance)
        End If

        lstEmployee = CommonFunction.GetEmployeeByIncidentID(_incidentID)

        If lstEmployee.Count > 0 Then
            Me.ViewEmployee(lstEmployee)
        End If

        Me.LoadWeatherConditions()
        Me.LoadMethodOfExtingushing()

    End Sub

    ''' <summary>
    ''' Method to Load Fire Station. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFireStation()

        Dim dtIncidentType As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & "StationName ASC"

        With dtIncidentType.Columns
            .Add(IMSConstants.FieldConstants.StationID)
            .Add(IMSConstants.FieldConstants.StationName)
        End With

        For Each obj As IMSService.FireStation In _proxy.GetFilteredFireStation(strSQL)
            Dim row As DataRow = dtIncidentType.NewRow
            row(IMSConstants.FieldConstants.StationID) = obj.StationID
            row(IMSConstants.FieldConstants.StationName) = obj.StationName

            dtIncidentType.Rows.Add(row)
        Next

        Dim rows As DataRow = dtIncidentType.NewRow
        rows(IMSConstants.FieldConstants.StationID) = String.Empty
        rows(IMSConstants.FieldConstants.StationName) = String.Empty
        dtIncidentType.Rows.InsertAt(rows, 0)

        With Me.cmbReportedStation
            .DataSource = dtIncidentType
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

    End Sub

    Private Sub ViewApplience(lstFireStationAppliance As List(Of IMSService.FireStationAppliance))
        Dim tblApplience As DataTable = CreateApplienceTable()

        For Each obj As IMSService.FireStationAppliance In lstFireStationAppliance
            Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(obj.ApplianceID)
            Dim applienceCode As String = String.Empty

            If Not IsNothing(objApplience) Then
                applienceCode = objApplience.ApplianceCode
            End If

            Dim row As DataRow = tblApplience.NewRow
            row(IMSConstants.GridHeader.ApplianceCode) = applienceCode
            row(IMSConstants.GridHeader.SerialNumber) = obj.SerialNumber
            tblApplience.Rows.Add(row)
        Next
        gvVehicle.DataSource = tblApplience
        gvVehicle.DataBind()

    End Sub

    Private Sub ViewEmployee(lstEmployee As List(Of IMSService.Employee))
        Dim tblEmployee As DataTable = CreateEmployeeTable()

        For Each obj As IMSService.Employee In lstEmployee
            'Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(obj.ApplianceID)
            'Dim applienceCode As String = String.Empty



            Dim row As DataRow = tblEmployee.NewRow
            row(IMSConstants.GridHeader.EmployeeName) = obj.EmployeeName
            'row(IMSConstants.GridHeader.SerialNumber) = obj.SerialNumber
            tblEmployee.Rows.Add(row)
        Next
        gvEmployee.DataSource = tblEmployee
        gvEmployee.DataBind()

    End Sub

    Private Function CreateEmployeeTable() As DataTable

        Dim dtAppliance As New DataTable
        'dtAppliance.Columns.Add(IMSConstants.GridHeader.ApplianceCode)
        dtAppliance.Columns.Add(IMSConstants.GridHeader.EmployeeName)

        Return dtAppliance

    End Function

    Private Function CreateApplienceTable() As DataTable

        Dim dtAppliance As New DataTable
        dtAppliance.Columns.Add(IMSConstants.GridHeader.ApplianceCode)
        dtAppliance.Columns.Add(IMSConstants.GridHeader.SerialNumber)

        Return dtAppliance

    End Function

    Private Function UpdateResolved() As Integer
        Dim id As Integer = 0
        Me.SetData(mOccurrenceBook)
        Dim objOccurrenceBook As IMS.Win.IMSService.OccurrenceBook = mOccurrenceBook

        id = _proxy.UpdateOccurrenceBook(objOccurrenceBook)

        Return id
    End Function

    Private Function SaveResolved() As Integer
        Dim id As Integer = -1
        Dim objOccurrenceBook As IMS.Win.IMSService.OccurrenceBook = SetData()

        id = _proxy.InsertOccurrenceBook(objOccurrenceBook)

        Return id

    End Function

    Private Sub SetData(occurrenceBook As IMSService.OccurrenceBook)

        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd'/'MM'/'yyyy"), "dd'/'MM'/'yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With mOccurrenceBook
            .IncidentID = _incidentID
            .ReportedStationID = cmbReportedStation.Value
            .ReportDate = dtpReportDateTime.Value
            .TimeOfDiscovery = dtptimeOfDiscovery.Value
            .TimeOfCall = dtpTimeOfCall.Value
            '.TimeOfArrival = dtpTimeOfArrival.Value
            .TimeOfUnderControl = dtpTimeOfUnderControl.Value
            .DiscoveredBy = txtDiscoveredBy.Text.Trim()
            .MethodOfCalling = txtMethodOfCall.Text.Trim()
            .WeatherCondition = GetWeatherConditionFormField() ' Weather condition form enum
            .SupposedCauses = txtSupposedCauses.Text.Trim()
            .InvolvedPropertyFire = txtInvolvedPropertyFire.Text.Trim()
            .InvolvedPropertySpecialService = txtInvolvedPropertySpecial.Text.Trim()
            .WhereIncidentStarted = txtWhereFireStartedFire.Text.Trim()
            .WhereIncidentSpreadTo = txtWhereFireSpreadToFire.Text.Trim()
            .DescriptionOfDamageFire = txtDescriptionOfDamageFire.Text.Trim()
            .DescriptionOfDamageSpecialService = txtDescriptionOfDamageSpecial.Text.Trim()
            .ApproximateValueOfDamage = txtApproximateValueOfDamage.Text.Trim()
            .NameOfOccupierFire = txtNameOfOccupierFire.Text.Trim()
            .NameOfOccupierSpecialServices = txtNameOfOccupierSpecial.Text.Trim()
            .BusinessCarriedOnFire = txtBusinessCarriedOnFire.Text.Trim()
            .BusinessCarriedOnSpecialService = txtBusinessCarriedOnSpecial.Text.Trim()
            .FixedInstallation = txtDetailsOfFixedInstallation.Text.Trim()
            .EquipmentUsedByFireService = txtEquipmentUsedByFireService.Text.Trim()
            .ServicesRenderedByFireService = txtServiceRenderedBy.Text.Trim()
            .AnyCharges = txtAnyCharges.Text.Trim()
            .NatureOfFalseAlerm = txtNatureOfFalseAlerm.Text.Trim()
            .ReasonOfStandBy = txtReasonOfStandBy.Text.Trim()
            .RemarksFalseAlarm = txtRemarksFalseAlarm.Text.Trim()
            .RemarksStandby = txtRemarksStandBy.Text.Trim()
            .CapturedBy = 1
            .InsertionDate = currentDate
            .ModificationDate = currentDate

            .ParticularsOfContentsOfPropertyFire = txtParticularsOfContentsOfPropertyFire.Text.Trim()
            .ApproximateDamageGrassFire = txtApproximateDamageGrassFire.Text.Trim()
            .MethodOfextinguishing = GetMethodOfExtinguishingFormField() ' Method of Extinguishing
            .RemarksGrassFire = txtRemarksGrassFire.Text.Trim()

            .MethodOfextinguishingFire = GetMethodOfExtinguishingFireFormField() '(for FIRE) Get Method of extingushing.
            .RemarksFire = txtRemarksFire.Text.Trim()
            .RemarksSpecialService = txtRemarksSpecialService.Text.Trim()

            .ApplianceOtherThanFireServiceFire = txtApplianceOtherThanFireServiceFire.Text.Trim()
            .ApplianceOtherThanFireServiceSpecialService = txtApplianceOtherThanFireServiceSpecialService.Text.Trim()
            .ApplianceOtherThanFireServiceFalseAlerm = txtApplianceOtherThanFireServiceFalseAlerm.Text.Trim()

        End With

    End Sub

    Private Function SetData() As IMSService.OccurrenceBook

        Dim objOccurrenceBook As New IMSService.OccurrenceBook
        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString(IMSConstants.AppConstants.DateFormatToQueryShort), IMSConstants.AppConstants.DateFormatToQueryShort, CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With objOccurrenceBook
            .IncidentID = _incidentID
            .ReportedStationID = cmbReportedStation.Value
            .ReportDate = dtpReportDateTime.Value
            .TimeOfDiscovery = dtptimeOfDiscovery.Value
            .TimeOfCall = dtpTimeOfCall.Value
            .TimeOfArrival = currentDate
            .TimeOfUnderControl = dtpTimeOfUnderControl.Value
            .DiscoveredBy = txtDiscoveredBy.Text.Trim()
            .MethodOfCalling = txtMethodOfCall.Text.Trim()
            .WeatherCondition = GetWeatherConditionFormField() ' Weather condition form enum
            .SupposedCauses = txtSupposedCauses.Text.Trim()
            .InvolvedPropertyFire = txtInvolvedPropertyFire.Text.Trim()
            .InvolvedPropertySpecialService = txtInvolvedPropertySpecial.Text.Trim()
            .WhereIncidentStarted = txtWhereFireStartedFire.Text.Trim()
            .WhereIncidentSpreadTo = txtWhereFireSpreadToFire.Text.Trim()
            .DescriptionOfDamageFire = txtDescriptionOfDamageFire.Text.Trim()
            .DescriptionOfDamageSpecialService = txtDescriptionOfDamageSpecial.Text.Trim()
            .ApproximateValueOfDamage = Convert.ToDecimal(txtApproximateValueOfDamage.Value)
            .NameOfOccupierFire = txtNameOfOccupierFire.Text.Trim()
            .NameOfOccupierSpecialServices = txtNameOfOccupierSpecial.Text.Trim()
            .BusinessCarriedOnFire = txtBusinessCarriedOnFire.Text.Trim()
            .BusinessCarriedOnSpecialService = txtBusinessCarriedOnSpecial.Text.Trim()
            .FixedInstallation = txtDetailsOfFixedInstallation.Text.Trim()
            .EquipmentUsedByFireService = txtEquipmentUsedByFireService.Text.Trim()
            .ServicesRenderedByFireService = txtServiceRenderedBy.Text.Trim()
            .AnyCharges = Convert.ToDecimal(txtAnyCharges.Value)
            .NatureOfFalseAlerm = txtNatureOfFalseAlerm.Text.Trim()
            .ReasonOfStandBy = txtReasonOfStandBy.Text.Trim()
            .RemarksFalseAlarm = txtRemarksFalseAlarm.Text.Trim()
            .RemarksStandby = txtRemarksStandBy.Text.Trim()
            .CapturedBy = 1
            .InsertionDate = currentDate
            .ModificationDate = currentDate
            .ParticularsOfContentsOfPropertyFire = txtParticularsOfContentsOfPropertyFire.Text.Trim()
            .ApproximateDamageGrassFire = txtApproximateDamageGrassFire.Text.Trim()

            .MethodOfextinguishing = GetMethodOfExtinguishingFormField() ' Get Method of extingushing.
            .RemarksGrassFire = txtRemarksGrassFire.Text.Trim()

            .MethodOfextinguishingFire = GetMethodOfExtinguishingFireFormField() '(for FIRE) Get Method of extingushing.
            .RemarksFire = txtRemarksFire.Text.Trim()
            .RemarksSpecialService = txtRemarksSpecialService.Text.Trim()

            .ApplianceOtherThanFireServiceFire = txtApplianceOtherThanFireServiceFire.Text.Trim()
            .ApplianceOtherThanFireServiceSpecialService = txtApplianceOtherThanFireServiceSpecialService.Text.Trim()
            .ApplianceOtherThanFireServiceFalseAlerm = txtApplianceOtherThanFireServiceFalseAlerm.Text.Trim()

        End With

        Return objOccurrenceBook

    End Function

    Private Sub SetOccurrenceBookData(occurrenceBook As IMSService.OccurrenceBook)

        With occurrenceBook
            cmbReportedStation.Value = .ReportedStationID
            dtpReportDateTime.Value = .ReportDate
            dtptimeOfDiscovery.Value = .TimeOfDiscovery
            dtpTimeOfCall.Value = .TimeOfCall
            'dtpTimeOfArrival.Text = Now.ToString("dd/mm/yyyy")
            dtpTimeOfUnderControl.Value = .TimeOfUnderControl
            txtDiscoveredBy.Text = .DiscoveredBy
            txtMethodOfCall.Text = .MethodOfCalling
            SetCheckBoxListValue(.WeatherCondition, chkWeatherConditionList)  'Set Weather condition.
            'txtWeatherCondition.Text = .WeatherCondition
            txtSupposedCauses.Text = .SupposedCauses
            txtInvolvedPropertyFire.Text = .InvolvedPropertyFire
            txtInvolvedPropertySpecial.Text = .InvolvedPropertySpecialService
            txtWhereFireStartedFire.Text = .WhereIncidentStarted
            txtWhereFireSpreadToFire.Text = .WhereIncidentSpreadTo
            txtDescriptionOfDamageFire.Text = .DescriptionOfDamageFire
            txtDescriptionOfDamageSpecial.Text = .DescriptionOfDamageSpecialService
            txtApproximateValueOfDamage.Value = .ApproximateValueOfDamage
            txtNameOfOccupierFire.Text = .NameOfOccupierFire
            txtNameOfOccupierSpecial.Text = .NameOfOccupierSpecialServices
            txtBusinessCarriedOnFire.Text = .BusinessCarriedOnFire
            txtBusinessCarriedOnSpecial.Text = .BusinessCarriedOnSpecialService
            txtDetailsOfFixedInstallation.Text = .FixedInstallation
            txtEquipmentUsedByFireService.Text = .EquipmentUsedByFireService
            txtServiceRenderedBy.Text = .ServicesRenderedByFireService
            txtAnyCharges.Value = .AnyCharges
            txtNatureOfFalseAlerm.Text = .NatureOfFalseAlerm
            txtReasonOfStandBy.Text = .ReasonOfStandBy
            txtRemarksFalseAlarm.Text = .RemarksFalseAlarm
            txtRemarksStandBy.Text = .RemarksStandby

            txtParticularsOfContentsOfPropertyFire.Text = .ParticularsOfContentsOfPropertyFire
            txtApproximateDamageGrassFire.Text = .ApproximateDamageGrassFire
            'txtMethodOfextinguishing.Text = .MethodOfextinguishing
            SetCheckBoxListValue(.MethodOfextinguishing, chkMethodOfExtinguishing)  'Set Method of Extinguishing (For Grass Fire)
            SetCheckBoxListValue(.MethodOfextinguishingFire, chkMethodOfExtinguishingFire)  'Set Method of Extinguishing (For Fire)

            txtRemarksGrassFire.Text = .RemarksGrassFire
            txtRemarksFire.Text = .RemarksFire
            txtRemarksSpecialService.Text = .RemarksSpecialService

            txtApplianceOtherThanFireServiceFire.Text = .ApplianceOtherThanFireServiceFire
            txtApplianceOtherThanFireServiceSpecialService.Text = .ApplianceOtherThanFireServiceSpecialService
            txtApplianceOtherThanFireServiceFalseAlerm.Text = .ApplianceOtherThanFireServiceFalseAlerm

        End With

    End Sub

    ''' <summary>
    ''' Method to set Visibility of Tabs.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetTabVisibility()

        Dim lstIncidentTypeIncident As New List(Of IMSService.IncidentTypeIncident)
        Dim strSQL As String = String.Format("{0}={1}", IMSConstants.FieldConstants.IncidentID, _incidentID)

        Dim lstCategoryID As New List(Of Integer)

        For Each objCatagory As IMSService.IncidentCategory In _proxy.GetAllIncidentCategory()
            lstCategoryID.Add(objCatagory.CategoryID)
        Next

        lstIncidentTypeIncident = _proxy.GetFilteredIncidentTypeIncident(strSQL).Cast(Of IMSService.IncidentTypeIncident).ToList()

        If lstIncidentTypeIncident.Count > 0 Then

            For Each objIncidentTypeIncident As IMSService.IncidentTypeIncident In lstIncidentTypeIncident

                Dim objIncidentType As IMSService.IncidentType = _proxy.GetIncidentTypeByID(objIncidentTypeIncident.IncidentTypeID)
                ' Dim filter As String = String.Format("{0}<>{1}", IMSConstants.FieldConstants.IncidentTypeID, objIncidentTypeIncident.IncidentTypeID)

                If (lstCategoryID.Contains(objIncidentType.CategoryID)) Then
                    lstCategoryID.Remove(objIncidentType.CategoryID)
                End If

            Next
        End If

        For Each CategoryID As Integer In lstCategoryID

            ' tabControlIncident.Controls.RemoveAt(CategoryID - 1)

            Dim objCategory As IMSService.IncidentCategory = _proxy.GetIncidentCategoryByID(CategoryID)
            'If Not IsNothing(objCategory) Then

            '    'For i = 0 To tabControlIncident.Controls.Count - 1
            '    '    tabControlIncident.Controls.RemoveAt(i)
            '    'Next
            Dim tabIndex As Integer = 0
            For Each tbPage As TabPage In tabControlIncident.TabPages

                If tbPage.Text = objCategory.CategoryName Then
                    tabControlIncident.Controls.RemoveAt(tabIndex)
                    'tabControlIncident.Enabled = True
                    ' tbPage.Hide()

                End If
                tabIndex += 1
            Next
            'End If
        Next


        ''TODO: Tab viasible of ("Fire" and "Grass Fire")
        Dim lstOfGrassFireDecision As List(Of Boolean) = CommonFunction.IsGrassFireAndIsOthersFireTypes(_incidentID)
        If lstOfGrassFireDecision.Count > 0 Then
            If Not lstOfGrassFireDecision(0) Then
                tabControlIncident.Controls.RemoveAt(tabControlIncident.Controls.Count - 1)
            End If

            If lstOfGrassFireDecision.Count > 1 Then
                If lstOfGrassFireDecision(0) And Not lstOfGrassFireDecision(1) Then
                    tabControlIncident.Controls.RemoveAt(0)
                End If
            End If

        End If

    End Sub

    ''' <summary>
    ''' Method to Get Comma seperated Checked weather conditions
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetWeatherConditionFormField() As String

        Dim weatherConditionCommaSepareted As String = String.Empty

        'Get all checked Weather Conditions
        For Each item As Object In chkWeatherConditionList.CheckedItems
            If String.IsNullOrEmpty(weatherConditionCommaSepareted) Then
                weatherConditionCommaSepareted = DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)
            Else
                weatherConditionCommaSepareted += " , " + DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)
            End If
        Next

        Return weatherConditionCommaSepareted
    End Function

    ''' <summary>
    ''' Method to (For Gass Fire) Get Method of extingushings comma separated value.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMethodOfExtinguishingFormField() As String

        Dim methodOfExtinguishingCommaSepareted As String = String.Empty

        'Get all checked 
        For Each item As Object In chkMethodOfExtinguishing.CheckedItems
            If String.IsNullOrEmpty(methodOfExtinguishingCommaSepareted) Then
                methodOfExtinguishingCommaSepareted = DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)
            Else
                methodOfExtinguishingCommaSepareted += " , " + DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)
            End If
        Next

        Return methodOfExtinguishingCommaSepareted
    End Function

    ''' <summary>
    ''' Method to (For Fire) Get Method of extingushings comma separated value.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMethodOfExtinguishingFireFormField() As String

        Dim methodOfExtinguishingCommaSepareted As String = String.Empty

        'Get all checked 
        For Each item As Object In chkMethodOfExtinguishingFire.CheckedItems
            If String.IsNullOrEmpty(methodOfExtinguishingCommaSepareted) Then
                methodOfExtinguishingCommaSepareted = DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)
            Else
                methodOfExtinguishingCommaSepareted += " , " + DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)
            End If
        Next

        Return methodOfExtinguishingCommaSepareted
    End Function


    ''' <summary>
    ''' Method to Load Weather condition.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadWeatherConditions()

        Dim tblWeatherConditions As New DataTable

        With tblWeatherConditions
            .Columns.Add(IMSConstants.Common.Key)
            .Columns.Add(IMSConstants.Common.Value)
        End With


        For Each enumValue As Integer In [Enum].GetValues(GetType(IMSEnums.WeatherConditions))
            Dim display As String = GetDescription([Enum].Parse(GetType(IMSEnums.WeatherConditions), enumValue))
            Dim rows As DataRow = tblWeatherConditions.NewRow
            rows(IMSConstants.Common.Key) = enumValue
            rows(IMSConstants.Common.Value) = display
            tblWeatherConditions.Rows.Add(rows)
        Next

        With chkWeatherConditionList

            .DataSource = tblWeatherConditions
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .ClearSelected()

        End With

    End Sub

    ''' <summary>
    ''' Method to Load Method of Extingushing
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMethodOfExtingushing()

        Dim tblMethodOfExtingushing As New DataTable

        With tblMethodOfExtingushing
            .Columns.Add(IMSConstants.Common.Key)
            .Columns.Add(IMSConstants.Common.Value)
        End With


        For Each enumValue As Integer In [Enum].GetValues(GetType(IMSEnums.MethodOfExtinguishing))
            Dim display As String = GetDescription([Enum].Parse(GetType(IMSEnums.MethodOfExtinguishing), enumValue))
            Dim rows As DataRow = tblMethodOfExtingushing.NewRow
            rows(IMSConstants.Common.Key) = enumValue
            rows(IMSConstants.Common.Value) = display
            tblMethodOfExtingushing.Rows.Add(rows)
        Next

        'For Grass Fire
        With chkMethodOfExtinguishing
            .DataSource = tblMethodOfExtingushing
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .ClearSelected()
        End With

        'For FIRE
        With chkMethodOfExtinguishingFire
            .DataSource = tblMethodOfExtingushing
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .ClearSelected()
        End With

    End Sub


    Public Shared Function GetEnumValueFromDescription(ByVal enumDescription As String) As Integer

        For Each enumValue As Integer In [Enum].GetValues(GetType(IMSEnums.Sex))
            Dim display As String = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), enumValue))
            If enumDescription = display Then
                Return enumValue
            End If
        Next

        Return 0
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
    ''' Method to set select check box
    ''' </summary>
    ''' <param name="valueCommaSeparated"></param>
    ''' <param name="listBox"></param>
    ''' <remarks></remarks>
    Private Sub SetCheckBoxListValue(ByVal valueCommaSeparated As String, ByVal listBox As System.Windows.Forms.CheckedListBox)

        Dim lstString As List(Of String) = GetListFromCommaSeparatedValue(valueCommaSeparated)

        'Check Items

        For i = 0 To listBox.Items.Count - 1
            Dim item As Object = listBox.Items(i)
            Dim checkBoxValue As String = DirectCast(DirectCast(item, System.Data.DataRowView).Row.ItemArray(1), String)

            If lstString.Contains(checkBoxValue) Then
                listBox.SetItemCheckState(i, CheckState.Checked)
            End If
        Next

    End Sub

    ''' <summary>
    ''' Method to Get list of comma separated value.
    ''' </summary>
    ''' <param name="valueCommaSeparated"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetListFromCommaSeparatedValue(ByVal valueCommaSeparated As String) As List(Of String)

        Dim aryValue() As String
        Dim lstString As New List(Of String)

        aryValue = valueCommaSeparated.Split(",")

        For i = 0 To UBound(aryValue)
            lstString.Add(aryValue(i).Trim())
        Next

        Return lstString

    End Function

    ''' <summary>
    ''' Method to Load Sex drop down to all Four SEX combo.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSexDropDownFromEnum()

        Dim tblSex As New DataTable

        With tblSex
            .Columns.Add(IMSConstants.Common.Key)
            .Columns.Add(IMSConstants.Common.Value)
        End With

        For Each enumValue As Integer In [Enum].GetValues(GetType(IMSEnums.Sex))
            Dim display As String = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), enumValue))
            Dim rows As DataRow = tblSex.NewRow
            rows(IMSConstants.Common.Key) = enumValue
            rows(IMSConstants.Common.Value) = display
            tblSex.Rows.Add(rows)
        Next

        Dim row As DataRow = tblSex.NewRow
        row(IMSConstants.Common.Key) = String.Empty
        row(IMSConstants.Common.Value) = String.Empty
        tblSex.Rows.InsertAt(row, 0)

        'Bind all the Four Sex combos.
        With cmbGFirePersonRescuedSex
            .DataSource = tblSex
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .DataBind()
        End With

        With cmbFireCasultiesSex
            .DataSource = tblSex
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .DataBind()
        End With

        With cmbSPSPersonsRescuedSex
            .DataSource = tblSex
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .DataBind()
        End With

        With cmbSPSCasualtiesSex
            .DataSource = tblSex
            .ValueMember = IMSConstants.Common.Key
            .DisplayMember = IMSConstants.Common.Value
            .DataBind()
        End With

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmAddResolvedIncident_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            'tabFire.Hide()
            'tabControlIncident.Hide()
            'tabFalseAlarm.Hide()
            'tabSpecialService.Hide()
            'tabControlIncident.Controls.RemoveAt(1)
            Me.LoadFireStation()
            Me.SetFormData()
            Me.LoadSexDropDownFromEnum()
            Me.SetTabVisibility()

            Dim strSQL = IMSConstants.FieldConstants.IncidentID & "=" & _incidentID
            Dim lstOccurrenceBook As List(Of IMSService.OccurrenceBook) = _proxy.GetFilteredOccurrenceBook(strSQL).Cast(Of IMSService.OccurrenceBook).ToList()
            If lstOccurrenceBook.Count > 0 Then
                mOccurrenceBook = lstOccurrenceBook.FirstOrDefault()
                Me.SetOccurrenceBookData(mOccurrenceBook)

                'Persons Rescued / Casualties
                Me.SetFirePersonsRescuedInitialy()
                Me.SetFireCasualtiesInitialy()
                Me.SetSPSPersonsRescuedInitialy()
                Me.SetSPSCasualtiesInitialy()

                _IsUpdate = True
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If String.IsNullOrEmpty(cmbReportedStation.Value) Then
                DisplayWarning(IMSConstants.ErrorMessage.SelectStation)
                cmbReportedStation.Focus()
                Exit Sub
            End If

            Dim intActionResult As Integer = 0

            If Me._IsUpdate = True Then
                intActionResult = Me.UpdateResolved()
            Else
                intActionResult = Me.SaveResolved()
            End If

            ''TODO : Insert/Update/Delete (table: Person Rescued and Casualties)

            '@(1) - FOR Fire (Person Rescued)
            Me.SaveFirePersonRescued()

            '@(2) - FOR Fire (Casualties)
            Me.SaveFireCasualties()

            '@(3) - FOR SPS (Special Service) (Person Rescued)
            Me.SaveSPSPersonRescued()

            '@(4) - FOR SPS (Special Service) (Casualties)
            Me.SaveSPSCasualties()

            If intActionResult > 0 Then
                DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                RaiseEvent UpdateIncident()
                ' Me.Close()
            End If
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Fire Person Rescued"

    Private Sub btnGFirePersonRescuedAdd_Click(sender As Object, e As EventArgs) Handles btnGFirePersonRescuedAdd.Click
        Try

            If Not _isUpdateGFPersonRescued Then

                '' Add Mode
                Dim objGFPersonRescued As New IMSService.PersonsRescuedAndEscaping

                With objGFPersonRescued
                    .Name = txtGFirePersonRescuedName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbGFirePersonRescuedSex.Value) Then
                        .Sex = cmbGFirePersonRescuedSex.Value
                    Else
                        .Sex = 0
                    End If

                    .Age = txtGFirePersonRescuedAge.Text.Trim()
                    .Method = txtGFirePersonRescuedMethod.Text.Trim()
                    .PersonEfectingRescue = txtGFirePersonRescuedPersonEfectingRescue.Text.Trim()
                End With

                _lstGFPersonRescued.Add(objGFPersonRescued)

                LoadGridGFPersonRescued()
                ClearGFPersonRescuedFields()

            Else
                '' EDIT Mode

                With grvGFPersonRescued.Selected.Rows(0)
                    'If already exist at database record Updated, then keep track it for Updating it from database finally.
                    If CInt(.Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString()) > 0 Then
                        _lstGFPersonRescuedEdited.Add(CInt(.Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString()))
                    End If
                End With

                'Update data of the list
                With _lstGFPersonRescued(_selectedIndexOfGridGFPersonRescued)
                    .Name = txtGFirePersonRescuedName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbGFirePersonRescuedSex.Value) Then
                        .Sex = cmbGFirePersonRescuedSex.Value
                    Else
                        .Sex = 0
                    End If
                    .Age = txtGFirePersonRescuedAge.Text.Trim()
                    .Method = txtGFirePersonRescuedMethod.Text.Trim()
                    .PersonEfectingRescue = txtGFirePersonRescuedPersonEfectingRescue.Text.Trim()
                End With

                LoadGridGFPersonRescued()
                ClearGFPersonRescuedFields()
                grvGFPersonRescued.Selected.Rows.Clear()

            End If

            btnGFirePersonRescuedAdd.Text = IMSConstants.ButtonText.Add
            btnGFirePersonRescuedDelete.Enabled = False
            _isUpdateGFPersonRescued = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Method to Clear Grass Fire Persons Rescued Fields
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearGFPersonRescuedFields()

        txtGFirePersonRescuedName.Text = String.Empty
        cmbGFirePersonRescuedSex.Value = String.Empty
        txtGFirePersonRescuedAge.Text = 0
        txtGFirePersonRescuedMethod.Text = String.Empty
        txtGFirePersonRescuedPersonEfectingRescue.Text = String.Empty

    End Sub

    ''' <summary>
    ''' Method to Load Grass Fire Rescued Grid.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGridGFPersonRescued()

        Dim dtPersonRescued As DataTable = GetPersonRescuedTable(_lstGFPersonRescued)

        With grvGFPersonRescued
            .DataSource = dtPersonRescued
            .DataBind()
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
        End With

    End Sub

    ''' <summary>
    ''' Method to Create Table from List (Persons Rescued / Escap)
    ''' </summary>
    ''' <param name="lstGFPersonRescued"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPersonRescuedTable(ByVal lstGFPersonRescued As List(Of IMSService.PersonsRescuedAndEscaping)) As DataTable

        Dim dt As New DataTable

        dt.Columns.Add(IMSConstants.FieldConstants.RescuedID, GetType(Integer))
        dt.Columns.Add(IMSConstants.FieldConstants.IncidentID, GetType(Integer))
        dt.Columns.Add(IMSConstants.FieldConstants.IncidentTypeID, GetType(Integer))

        dt.Columns.Add(IMSConstants.GridHeader.Name, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.Sex, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.Age, GetType(Integer))
        dt.Columns.Add(IMSConstants.GridHeader.MethodOfRescueAndEscape, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.PersonEfectingRescue, GetType(String))

        If lstGFPersonRescued.Count > 0 Then

            For Each objPersonsRescued As IMSService.PersonsRescuedAndEscaping In lstGFPersonRescued

                Dim row As DataRow = dt.NewRow

                With objPersonsRescued
                    row(IMSConstants.FieldConstants.RescuedID) = .RescuedID
                    row(IMSConstants.FieldConstants.IncidentID) = .IncidentID
                    row(IMSConstants.FieldConstants.IncidentTypeID) = .IncidentCategoryID
                    row(IMSConstants.GridHeader.Name) = .Name
                    If .Sex > 0 Then
                        row(IMSConstants.GridHeader.Sex) = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), .Sex))
                    Else
                        row(IMSConstants.GridHeader.Sex) = String.Empty
                    End If

                    row(IMSConstants.GridHeader.Age) = .Age
                    row(IMSConstants.GridHeader.MethodOfRescueAndEscape) = .Method
                    row(IMSConstants.GridHeader.PersonEfectingRescue) = .PersonEfectingRescue
                End With

                dt.Rows.Add(row)
            Next
        End If

        Return dt

    End Function

    Private Sub grvGFPersonRescued_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles grvGFPersonRescued.ClickCell
        Try
            _selectedIndexOfGridGFPersonRescued = e.Cell.Row.Index
            _isUpdateGFPersonRescued = True

            With grvGFPersonRescued.Selected.Rows(0)
                txtGFirePersonRescuedName.Text = .Cells(IMSConstants.GridHeader.Name).Value.ToString()
                If Not String.IsNullOrEmpty(.Cells(IMSConstants.GridHeader.Sex).Value) Then
                    cmbGFirePersonRescuedSex.Value = GetEnumValueFromDescription(.Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                Else
                    cmbGFirePersonRescuedSex.Value = String.Empty
                End If

                txtGFirePersonRescuedAge.Text = .Cells(IMSConstants.GridHeader.Age).Value.ToString()
                txtGFirePersonRescuedMethod.Text = .Cells(IMSConstants.GridHeader.MethodOfRescueAndEscape).Value.ToString()
                txtGFirePersonRescuedPersonEfectingRescue.Text = .Cells(IMSConstants.GridHeader.PersonEfectingRescue).Value.ToString()
            End With

            _isUpdateGFPersonRescued = True
            btnGFirePersonRescuedAdd.Text = IMSConstants.ButtonText.Update
            btnGFirePersonRescuedDelete.Enabled = True

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnGFirePersonRescuedDelete_Click(sender As Object, e As EventArgs) Handles btnGFirePersonRescuedDelete.Click
        Try
                'If already exist at database record delete, then keep track it for delete it from database finally.
            If CInt(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString()) > 0 Then
                'TODO : Keep data for the deleting at final stage.
                'take data into object

                Dim objPRescued As New IMSService.PersonsRescuedAndEscaping
                With objPRescued
                    .RescuedID = CInt(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString())
                    .IncidentID = CInt(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentID).Value.ToString())
                    .IncidentCategoryID = CInt(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentTypeID).Value.ToString())
                    .Name = grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Name).Value.ToString()
                    'Get Sex from Grid Field (From Enum description)
                    If Not String.IsNullOrEmpty(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value) Then
                        cmbGFirePersonRescuedSex.Value = GetEnumValueFromDescription(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                    Else
                        cmbGFirePersonRescuedSex.Value = String.Empty
                    End If

                    .Age = CInt(grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Age).Value.ToString())
                    .Method = grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.MethodOfRescueAndEscape).Value.ToString()
                    .PersonEfectingRescue = grvGFPersonRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.PersonEfectingRescue).Value.ToString()
                    .IsDeleted = True
                End With

                _lstGFPersonRescuedDeleted.Add(objPRescued)
            End If

            'Now remove from list to remove show from grid
            _lstGFPersonRescued.RemoveAt(_selectedIndexOfGridGFPersonRescued)

            LoadGridGFPersonRescued()
            ClearGFPersonRescuedFields()
            grvGFPersonRescued.Selected.Rows.Clear()

            btnGFirePersonRescuedAdd.Text = IMSConstants.ButtonText.Add
            btnGFirePersonRescuedDelete.Enabled = False
            _isUpdateGFPersonRescued = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnGFirePersonRescuedRefresh_Click(sender As Object, e As EventArgs) Handles btnGFirePersonRescuedRefresh.Click
        Try
            ClearGFPersonRescuedFields()
            grvGFPersonRescued.Selected.Rows.Clear()
            btnGFirePersonRescuedAdd.Text = IMSConstants.ButtonText.Add
            btnGFirePersonRescuedDelete.Enabled = False
            _isUpdateGFPersonRescued = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Load Fire Persons Rescued Grid at form load time.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFirePersonsRescuedInitialy()

        'Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & " and " & _
        '    IMSConstants.FieldConstants.IncidentID & " = " & _incidentID & " and " & _
        '    IMSConstants.FieldConstants.IncidentCategoryID & " = " & CInt(IMSEnums.IncidentCategory.Fire)
        ' _lstGFPersonRescued = _proxy.GetFilteredPersonsRescuedAndEscaping(sql).Cast(Of IMSService.PersonsRescuedAndEscaping).ToList()

        _lstGFPersonRescued = CommonFunction.GetPersonRescuedByIncidentIDAndCategory(_incidentID, CInt(IMSEnums.IncidentCategory.Fire))

        LoadGridGFPersonRescued()

    End Sub

    ''' <summary>
    ''' Method to Save Fire Person Rescued Grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveFirePersonRescued()

        '@(1) - FOR Fire (Person Rescued)

        If _lstGFPersonRescued.Count > 0 Then

            For Each objPersonRescued As IMSService.PersonsRescuedAndEscaping In _lstGFPersonRescued

                If objPersonRescued.RescuedID = 0 Then

                    'TODO : # 1: (insert) This is a new entry and need to insert
                    objPersonRescued.IncidentCategoryID = CInt(IMSEnums.IncidentCategory.Fire)
                    objPersonRescued.IncidentID = _incidentID
                    _proxy.InsertPersonsRescuedAndEscaping(objPersonRescued)

                Else
                    'TODO : This is a Old entry and need to check for Delete or Update.
                    '# 2: (Updated)
                    If _lstGFPersonRescuedEdited.Contains(objPersonRescued.RescuedID) Then
                        _proxy.UpdatePersonsRescuedAndEscaping(objPersonRescued)
                        Continue For
                    End If

                End If

            Next

            ' # 3: (Deleted)
            If _lstGFPersonRescuedDeleted.Count > 0 Then
                For Each objPersonRescuedDeleted As IMSService.PersonsRescuedAndEscaping In _lstGFPersonRescuedDeleted
                    objPersonRescuedDeleted.IsDeleted = True
                    _proxy.UpdatePersonsRescuedAndEscaping(objPersonRescuedDeleted)
                Next
            End If

            SetFirePersonsRescuedInitialy()

        End If

    End Sub


#End Region

#Region "Fire Casualties"

    Private Sub btnFireCasualtiesAdd_Click(sender As Object, e As EventArgs) Handles btnFireCasualtiesAdd.Click
        Try

            If Not _isUpdateFireCasualties Then

                '' Add Mode 
                Dim objFireCasualties As New IMSService.Casualities

                With objFireCasualties
                    .Name = txtFireCasultiesName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbFireCasultiesSex.Value) Then
                        .Sex = cmbFireCasultiesSex.Value
                    Else
                        .Sex = 0
                    End If

                    .Age = txtFireCasultiesAge.Text.Trim()
                    .Address = txtFireCasultiesAddress.Text.Trim()
                    .NatureOfInjury = txtFireCasultiesNatureOfInjury.Text.Trim()
                    .IfFatal = chkFireCasualtiesIfFatal.Checked

                End With

                _lstFireCasualties.Add(objFireCasualties)

                LoadGridFireCasualties()
                ClearFireCasualtiesFields()

            Else
                '' EDIT Mode (Fire Casualties)

                With grvFireCasualties.Selected.Rows(0)
                    'If already exist at database record Updated, then keep track it for Updating it from database finally.
                    If CInt(.Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString()) > 0 Then
                        _lstFireCasualtiesEdited.Add(CInt(.Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString()))
                    End If
                End With

                'Update data of the list
                With _lstFireCasualties(_selectedIndexOfGridFireCasualties)
                    .Name = txtFireCasultiesName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbFireCasultiesSex.Value) Then
                        .Sex = cmbFireCasultiesSex.Value
                    Else
                        .Sex = 0
                    End If
                    .Age = txtFireCasultiesAge.Text.Trim()
                    .Address = txtFireCasultiesAddress.Text.Trim()
                    .NatureOfInjury = txtFireCasultiesNatureOfInjury.Text.Trim()
                    .IfFatal = chkFireCasualtiesIfFatal.Checked
                End With

                LoadGridFireCasualties()
                ClearFireCasualtiesFields()
                grvFireCasualties.Selected.Rows.Clear()

            End If

            btnFireCasualtiesAdd.Text = IMSConstants.ButtonText.Add
            btnFireCasualtiesDelete.Enabled = False
            _isUpdateFireCasualties = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    '''  Method to Load Fire Casualties Grid at form load time.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetFireCasualtiesInitialy()

        'Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & " and " & _
        '    IMSConstants.FieldConstants.IncidentID & " = " & _incidentID & " and " & _
        '    IMSConstants.FieldConstants.IncidentCategoryID & " = " & CInt(IMSEnums.IncidentCategory.Fire)

        '_lstFireCasualties = _proxy.GetFilteredCasualities(sql).Cast(Of IMSService.Casualities).ToList()

        _lstFireCasualties = CommonFunction.GetCasualtiesByIncidentIDAndCategory(_incidentID, CInt(IMSEnums.IncidentCategory.Fire))

        LoadGridFireCasualties()

    End Sub

    ''' <summary>
    '''  Method to Load Fire Casualties Grid .
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGridFireCasualties()

        Dim dtCasualties As DataTable = GetCasualtiesTable(_lstFireCasualties)

        With grvFireCasualties
            .DataSource = dtCasualties
            .DataBind()
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
        End With

    End Sub

    ''' <summary>
    ''' Method to Create Table for Fire Casualties Grid .
    ''' </summary>
    ''' <param name="lstFireCasualties"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCasualtiesTable(ByVal lstFireCasualties As List(Of IMSService.Casualities)) As DataTable

        Dim dt As New DataTable

        dt.Columns.Add(IMSConstants.FieldConstants.CasualitiesID, GetType(Integer))
        dt.Columns.Add(IMSConstants.FieldConstants.IncidentID, GetType(Integer))
        dt.Columns.Add(IMSConstants.FieldConstants.IncidentCategoryID, GetType(Integer))

        dt.Columns.Add(IMSConstants.GridHeader.Name, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.Sex, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.Age, GetType(Integer))
        dt.Columns.Add(IMSConstants.GridHeader.Address, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.NatureOfInjury, GetType(String))
        dt.Columns.Add(IMSConstants.GridHeader.IfFatal, GetType(String))

        If lstFireCasualties.Count > 0 Then

            For Each objPersonsRescued As IMSService.Casualities In lstFireCasualties

                Dim row As DataRow = dt.NewRow

                With objPersonsRescued
                    row(IMSConstants.FieldConstants.CasualitiesID) = .CasualitiesID
                    row(IMSConstants.FieldConstants.IncidentID) = .IncidentID
                    row(IMSConstants.FieldConstants.IncidentCategoryID) = .IncidentCategoryID
                    row(IMSConstants.GridHeader.Name) = .Name
                    If .Sex > 0 Then
                        row(IMSConstants.GridHeader.Sex) = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), .Sex))
                    Else
                        row(IMSConstants.GridHeader.Sex) = String.Empty
                    End If

                    row(IMSConstants.GridHeader.Age) = .Age
                    row(IMSConstants.GridHeader.Address) = .Address
                    row(IMSConstants.GridHeader.NatureOfInjury) = .NatureOfInjury
                    row(IMSConstants.GridHeader.IfFatal) = [Enum].GetName(GetType(IMSEnums.IfFatal), .IfFatal)

                End With

                dt.Rows.Add(row)
            Next
        End If

        Return dt
    End Function

    ''' <summary>
    ''' Method to Clear Fire Casualties Fields
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFireCasualtiesFields()

        txtFireCasultiesName.Text = String.Empty
        cmbFireCasultiesSex.Value = String.Empty
        txtFireCasultiesAge.Text = 0
        txtFireCasultiesAddress.Text = String.Empty
        txtFireCasultiesNatureOfInjury.Text = String.Empty
        chkFireCasualtiesIfFatal.Checked = False

    End Sub

    Private Sub btnFireCasualtiesDelete_Click(sender As Object, e As EventArgs) Handles btnFireCasualtiesDelete.Click
        Try
            'If already exist at database record delete, then keep track it for delete it from database finally.
            If CInt(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString()) > 0 Then
                'TODO : Keep data for the deleting at final stage.
                'take data into object

                Dim objFireCasualties As New IMSService.Casualities
                With objFireCasualties
                    .CasualitiesID = CInt(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString())
                    .IncidentID = CInt(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentID).Value.ToString())
                    .IncidentCategoryID = CInt(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentCategoryID).Value.ToString())
                    .Name = grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Name).Value.ToString()
                    'Get Sex from Grid Field (From Enum description)
                    If Not String.IsNullOrEmpty(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value) Then
                        cmbFireCasultiesSex.Value = GetEnumValueFromDescription(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                    Else
                        cmbFireCasultiesSex.Value = String.Empty
                    End If

                    .Age = CInt(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Age).Value.ToString())
                    .Address = grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Address).Value.ToString()
                    .NatureOfInjury = grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.NatureOfInjury).Value.ToString()
                    If DirectCast([Enum].Parse(GetType(IMSEnums.IfFatal), grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.IfFatal).Value.ToString()), Integer) = CInt(IMSEnums.IfFatal.Yes) Then
                        .IfFatal = True
                    Else
                        .IfFatal = False
                    End If

                    .IsDeleted = True
                End With

                _lstFireCasualtiesDeleted.Add(objFireCasualties)
            End If

            'Now remove from list to remove show from grid
            _lstFireCasualties.RemoveAt(_selectedIndexOfGridFireCasualties)

            LoadGridFireCasualties()
            ClearFireCasualtiesFields()
            grvFireCasualties.Selected.Rows.Clear()

            btnFireCasualtiesAdd.Text = IMSConstants.ButtonText.Add
            btnFireCasualtiesDelete.Enabled = False
            _isUpdateFireCasualties = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnFireCasualtiesRefresh_Click(sender As Object, e As EventArgs) Handles btnFireCasualtiesRefresh.Click
        Try
            ClearFireCasualtiesFields()
            grvFireCasualties.Selected.Rows.Clear()
            btnFireCasualtiesAdd.Text = IMSConstants.ButtonText.Add
            btnFireCasualtiesDelete.Enabled = False
            _isUpdateFireCasualties = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub grvFireCasualties_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles grvFireCasualties.ClickCell
        Try
            _selectedIndexOfGridFireCasualties = e.Cell.Row.Index
            _isUpdateFireCasualties = True

            With grvFireCasualties.Selected.Rows(0)
                txtFireCasultiesName.Text = .Cells(IMSConstants.GridHeader.Name).Value.ToString()
                If Not String.IsNullOrEmpty(.Cells(IMSConstants.GridHeader.Sex).Value) Then
                    cmbFireCasultiesSex.Value = GetEnumValueFromDescription(grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                Else
                    cmbFireCasultiesSex.Value = String.Empty
                End If

                txtFireCasultiesAge.Text = .Cells(IMSConstants.GridHeader.Age).Value.ToString()
                txtFireCasultiesAddress.Text = .Cells(IMSConstants.GridHeader.Address).Value.ToString()
                txtFireCasultiesNatureOfInjury.Text = .Cells(IMSConstants.GridHeader.NatureOfInjury).Value.ToString()
                If DirectCast([Enum].Parse(GetType(IMSEnums.IfFatal), grvFireCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.IfFatal).Value.ToString()), Integer) = CInt(IMSEnums.IfFatal.Yes) Then
                    chkFireCasualtiesIfFatal.Checked = True
                Else
                    chkFireCasualtiesIfFatal.Checked = False
                End If
            End With

            _isUpdateFireCasualties = True
            btnFireCasualtiesAdd.Text = IMSConstants.ButtonText.Update
            btnFireCasualtiesDelete.Enabled = True

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Save Fire Person Rescued Grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveFireCasualties()

        '@(2) - FOR Fire (Casualties)

        If _lstFireCasualties.Count > 0 Then

            For Each obj As IMSService.Casualities In _lstFireCasualties

                If obj.CasualitiesID = 0 Then

                    'TODO : # 1: (insert) This is a new entry and need to insert
                    obj.IncidentCategoryID = CInt(IMSEnums.IncidentCategory.Fire)
                    obj.IncidentID = _incidentID
                    _proxy.InsertCasualities(obj)

                Else
                    'TODO : This is a Old entry and need to check for Delete or Update.
                    '# 2: (Updated)
                    If _lstFireCasualtiesEdited.Contains(obj.CasualitiesID) Then
                        _proxy.UpdateCasualities(obj)
                        Continue For
                    End If

                End If

            Next

            ' # 3: (Deleted)
            If _lstFireCasualtiesDeleted.Count > 0 Then
                For Each obj As IMSService.Casualities In _lstFireCasualtiesDeleted
                    obj.IsDeleted = True
                    _proxy.UpdateCasualities(obj)
                Next
            End If

            SetFireCasualtiesInitialy()

        End If

    End Sub

#End Region

#Region "SPS (Special Service) Casualties"

    Private Sub btnSPSCasualtiesAdd_Click(sender As Object, e As EventArgs) Handles btnSPSCasualtiesAdd.Click
        Try

            If Not _isUpdateSPSCasualties Then

                '' Add Mode 
                Dim objSPSCasualties As New IMSService.Casualities

                With objSPSCasualties
                    .Name = txtSPSCasualtiesName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbSPSCasualtiesSex.Value) Then
                        .Sex = cmbSPSCasualtiesSex.Value
                    Else
                        .Sex = 0
                    End If

                    .Age = txtSPSCasualtiesAge.Text.Trim()
                    .Address = txtSPSCasualtiesAddress.Text.Trim()
                    .NatureOfInjury = txtSPSCasualtiesNatureOfInjury.Text.Trim()
                    .IfFatal = chkSPSCasualtiesIfFatal.Checked

                End With

                _lstSPSCasualties.Add(objSPSCasualties)

                LoadGridSPSCasualties()
                ClearSPSCasualtiesFields()

            Else
                '' EDIT Mode (Fire Casualties)

                With grvSPSCasualties.Selected.Rows(0)
                    'If already exist at database record Updated, then keep track it for Updating it from database finally.
                    If CInt(.Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString()) > 0 Then
                        _lstSPSCasualtiesEdited.Add(CInt(.Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString()))
                    End If
                End With

                'Update data of the list
                With _lstSPSCasualties(_selectedIndexOfGridSPSCasualties)
                    .Name = txtSPSCasualtiesName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbSPSCasualtiesSex.Value) Then
                        .Sex = cmbSPSCasualtiesSex.Value
                    Else
                        .Sex = 0
                    End If
                    .Age = txtSPSCasualtiesAge.Text.Trim()
                    .Address = txtSPSCasualtiesAddress.Text.Trim()
                    .NatureOfInjury = txtSPSCasualtiesNatureOfInjury.Text.Trim()
                    .IfFatal = chkSPSCasualtiesIfFatal.Checked
                End With

                LoadGridSPSCasualties()
                ClearSPSCasualtiesFields()
                grvSPSCasualties.Selected.Rows.Clear()

            End If

            btnSPSCasualtiesAdd.Text = IMSConstants.ButtonText.Add
            btnSPSCasualtiesDelete.Enabled = False
            _isUpdateSPSCasualties = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Load Special Service Casualties Grid at form load time.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSPSCasualtiesInitialy()

        'Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & " and " & _
        '    IMSConstants.FieldConstants.IncidentID & " = " & _incidentID & " and " & _
        '    IMSConstants.FieldConstants.IncidentCategoryID & " = " & CInt(IMSEnums.IncidentCategory.SpecialService)

        '_lstSPSCasualties = _proxy.GetFilteredCasualities(sql).Cast(Of IMSService.Casualities).ToList()

        _lstSPSCasualties = CommonFunction.GetCasualtiesByIncidentIDAndCategory(_incidentID, CInt(IMSEnums.IncidentCategory.SpecialService))

        LoadGridSPSCasualties()

    End Sub

    ''' <summary>
    ''' Method to Load Special Service Casualties Grid.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGridSPSCasualties()

        Dim dtCasualties As DataTable = GetCasualtiesTable(_lstSPSCasualties)

        With grvSPSCasualties
            .DataSource = dtCasualties
            .DataBind()
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
        End With

    End Sub

    ''' <summary>
    ''' Method to Clear Fire Casualties Fields
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearSPSCasualtiesFields()

        txtSPSCasualtiesName.Text = String.Empty
        cmbSPSCasualtiesSex.Value = String.Empty
        txtSPSCasualtiesAge.Text = 0
        txtSPSCasualtiesAddress.Text = String.Empty
        txtSPSCasualtiesNatureOfInjury.Text = String.Empty
        chkSPSCasualtiesIfFatal.Checked = False

    End Sub

    Private Sub btnSPSCasualtiesDelete_Click(sender As Object, e As EventArgs) Handles btnSPSCasualtiesDelete.Click
        Try
            'If already exist at database record delete, then keep track it for delete it from database finally.
            If CInt(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString()) > 0 Then
                'TODO : Keep data for the deleting at final stage.
                'take data into object

                Dim objSPSCasualties As New IMSService.Casualities
                With objSPSCasualties
                    .CasualitiesID = CInt(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.CasualitiesID).Value.ToString())
                    .IncidentID = CInt(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentID).Value.ToString())
                    .IncidentCategoryID = CInt(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentCategoryID).Value.ToString())
                    .Name = grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Name).Value.ToString()
                    'Get Sex from Grid Field (From Enum description)
                    If Not String.IsNullOrEmpty(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value) Then
                        cmbSPSCasualtiesSex.Value = GetEnumValueFromDescription(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                    Else
                        cmbSPSCasualtiesSex.Value = String.Empty
                    End If

                    .Age = CInt(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Age).Value.ToString())
                    .Address = grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Address).Value.ToString()
                    .NatureOfInjury = grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.NatureOfInjury).Value.ToString()
                    If DirectCast([Enum].Parse(GetType(IMSEnums.IfFatal), grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.IfFatal).Value.ToString()), Integer) = CInt(IMSEnums.IfFatal.Yes) Then
                        .IfFatal = True
                    Else
                        .IfFatal = False
                    End If

                    .IsDeleted = True
                End With

                _lstSPSCasualtiesDeleted.Add(objSPSCasualties)
            End If

            'Now remove from list to remove show from grid
            _lstSPSCasualties.RemoveAt(_selectedIndexOfGridSPSCasualties)

            LoadGridSPSCasualties()
            ClearSPSCasualtiesFields()
            grvSPSCasualties.Selected.Rows.Clear()

            btnSPSCasualtiesAdd.Text = IMSConstants.ButtonText.Add
            btnSPSCasualtiesDelete.Enabled = False
            _isUpdateSPSCasualties = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnSPSCasualtiesRefresh_Click(sender As Object, e As EventArgs) Handles btnSPSCasualtiesRefresh.Click
        Try
            ClearSPSCasualtiesFields()
            grvSPSCasualties.Selected.Rows.Clear()
            btnSPSCasualtiesAdd.Text = IMSConstants.ButtonText.Add
            btnSPSCasualtiesDelete.Enabled = False
            _isUpdateSPSCasualties = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub grvSPSCasualties_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles grvSPSCasualties.ClickCell
        Try
            _selectedIndexOfGridSPSCasualties = e.Cell.Row.Index
            _isUpdateSPSCasualties = True

            With grvSPSCasualties.Selected.Rows(0)
                txtSPSCasualtiesName.Text = .Cells(IMSConstants.GridHeader.Name).Value.ToString()
                If Not String.IsNullOrEmpty(.Cells(IMSConstants.GridHeader.Sex).Value) Then
                    cmbSPSCasualtiesSex.Value = GetEnumValueFromDescription(grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                Else
                    cmbSPSCasualtiesSex.Value = String.Empty
                End If

                txtSPSCasualtiesAge.Text = .Cells(IMSConstants.GridHeader.Age).Value.ToString()
                txtSPSCasualtiesAddress.Text = .Cells(IMSConstants.GridHeader.Address).Value.ToString()
                txtSPSCasualtiesNatureOfInjury.Text = .Cells(IMSConstants.GridHeader.NatureOfInjury).Value.ToString()
                If DirectCast([Enum].Parse(GetType(IMSEnums.IfFatal), grvSPSCasualties.Selected.Rows(0).Cells(IMSConstants.GridHeader.IfFatal).Value.ToString()), Integer) = CInt(IMSEnums.IfFatal.Yes) Then
                    chkSPSCasualtiesIfFatal.Checked = True
                Else
                    chkSPSCasualtiesIfFatal.Checked = False
                End If
            End With

            _isUpdateSPSCasualties = True
            btnSPSCasualtiesAdd.Text = IMSConstants.ButtonText.Update
            btnSPSCasualtiesDelete.Enabled = True

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Save Fire Person Rescued Grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveSPSCasualties()

        '@(3) - FOR SPS (Special Service) (Casualties)

        If _lstSPSCasualties.Count > 0 Then

            For Each obj As IMSService.Casualities In _lstSPSCasualties

                If obj.CasualitiesID = 0 Then

                    'TODO : # 1: (insert) This is a new entry and need to insert
                    obj.IncidentCategoryID = CInt(IMSEnums.IncidentCategory.SpecialService)
                    obj.IncidentID = _incidentID
                    _proxy.InsertCasualities(obj)

                Else
                    'TODO : This is a Old entry and need to check for Delete or Update.
                    '# 2: (Updated)
                    If _lstSPSCasualtiesEdited.Contains(obj.CasualitiesID) Then
                        _proxy.UpdateCasualities(obj)
                        Continue For
                    End If

                End If

            Next

            ' # 3: (Deleted)
            If _lstSPSCasualtiesDeleted.Count > 0 Then
                For Each obj As IMSService.Casualities In _lstSPSCasualtiesDeleted
                    obj.IsDeleted = True
                    _proxy.UpdateCasualities(obj)
                Next
            End If

            SetSPSCasualtiesInitialy()

        End If

    End Sub

#End Region

#Region "SPS (Special Service) Person Rescued"

    ''' <summary>
    ''' Method to Save SPS (Special Service) Person Rescued Grid
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SaveSPSPersonRescued()

        '@(4) - FOR SPS (Special Service) (Person Rescued)

        If _lstSPSPersonRescued.Count > 0 Then

            For Each objPersonRescued As IMSService.PersonsRescuedAndEscaping In _lstSPSPersonRescued

                If objPersonRescued.RescuedID = 0 Then

                    'TODO : # 1: (insert) This is a new entry and need to insert
                    objPersonRescued.IncidentCategoryID = CInt(IMSEnums.IncidentCategory.SpecialService)
                    objPersonRescued.IncidentID = _incidentID
                    _proxy.InsertPersonsRescuedAndEscaping(objPersonRescued)

                Else
                    'TODO : This is a Old entry and need to check for Delete or Update.
                    '# 2: (Updated)
                    If _lstSPSPersonRescuedEdited.Contains(objPersonRescued.RescuedID) Then
                        _proxy.UpdatePersonsRescuedAndEscaping(objPersonRescued)
                        Continue For
                    End If

                End If

            Next

            ' # 3: (Deleted)
            If _lstSPSPersonRescuedDeleted.Count > 0 Then
                For Each objPersonRescuedDeleted As IMSService.PersonsRescuedAndEscaping In _lstSPSPersonRescuedDeleted
                    objPersonRescuedDeleted.IsDeleted = True
                    _proxy.UpdatePersonsRescuedAndEscaping(objPersonRescuedDeleted)
                Next
            End If

            SetSPSPersonsRescuedInitialy()

        End If

    End Sub

    Private Sub btnSPSPersonsRescuedAdd_Click(sender As Object, e As EventArgs) Handles btnSPSPersonsRescuedAdd.Click
        Try

            If Not _isUpdateSPSPersonRescued Then

                '' Add Mode
                Dim objSPSPersonRescued As New IMSService.PersonsRescuedAndEscaping

                With objSPSPersonRescued
                    .Name = txtSPSPersonsRescuedName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbSPSPersonsRescuedSex.Value) Then
                        .Sex = cmbSPSPersonsRescuedSex.Value
                    Else
                        .Sex = 0
                    End If

                    .Age = txtSPSPersonsRescuedAge.Text.Trim()
                    .Method = txtSPSPersonsRescuedMethod.Text.Trim()
                    .PersonEfectingRescue = txtSPSPersonsRescuedPersonEfectingRescue.Text.Trim()
                End With

                _lstSPSPersonRescued.Add(objSPSPersonRescued)

                LoadGridSPSPersonRescued()
                ClearSPSPersonsRescuedFields()

            Else
                '' EDIT Mode

                With grvSPSPersonsRescued.Selected.Rows(0)
                    'If already exist at database record Updated, then keep track it for Updating it from database finally.
                    If CInt(.Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString()) > 0 Then
                        _lstSPSPersonRescuedEdited.Add(CInt(.Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString()))
                    End If
                End With

                'Update data of the list
                With _lstSPSPersonRescued(_selectedIndexOfGridSPSPersonRescued)
                    .Name = txtSPSPersonsRescuedName.Text.Trim()
                    If Not String.IsNullOrEmpty(cmbSPSPersonsRescuedSex.Value) Then
                        .Sex = cmbSPSPersonsRescuedSex.Value
                    Else
                        .Sex = 0
                    End If
                    .Age = txtSPSPersonsRescuedAge.Text.Trim()
                    .Method = txtSPSPersonsRescuedMethod.Text.Trim()
                    .PersonEfectingRescue = txtSPSPersonsRescuedPersonEfectingRescue.Text.Trim()
                End With

                LoadGridSPSPersonRescued()
                ClearSPSPersonsRescuedFields()
                grvSPSPersonsRescued.Selected.Rows.Clear()

            End If

            btnSPSPersonsRescuedAdd.Text = IMSConstants.ButtonText.Add
            btnSPSPersonsRescuedDelete.Enabled = False
            _isUpdateSPSPersonRescued = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Method to Clear Grass Fire Persons Rescued Fields
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearSPSPersonsRescuedFields()

        txtSPSPersonsRescuedName.Text = String.Empty
        cmbSPSPersonsRescuedSex.Value = String.Empty
        txtSPSPersonsRescuedAge.Text = 0
        txtSPSPersonsRescuedMethod.Text = String.Empty
        txtSPSPersonsRescuedPersonEfectingRescue.Text = String.Empty

    End Sub

    ''' <summary>
    ''' Method to Load Grass Fire Rescued Grid.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadGridSPSPersonRescued()

        Dim dtPersonRescued As DataTable = GetPersonRescuedTable(_lstSPSPersonRescued)
        With grvSPSPersonsRescued
            .DataSource = dtPersonRescued
            .DataBind()
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
        End With

    End Sub

    Private Sub grvSPSPersonsRescued_ClickCell(sender As Object, e As UltraWinGrid.ClickCellEventArgs) Handles grvSPSPersonsRescued.ClickCell
        Try
            _selectedIndexOfGridSPSPersonRescued = e.Cell.Row.Index
            _isUpdateSPSPersonRescued = True

            With grvSPSPersonsRescued.Selected.Rows(0)
                txtSPSPersonsRescuedName.Text = .Cells(IMSConstants.GridHeader.Name).Value.ToString()
                If Not String.IsNullOrEmpty(.Cells(IMSConstants.GridHeader.Sex).Value) Then
                    cmbSPSPersonsRescuedSex.Value = GetEnumValueFromDescription(.Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                Else
                    cmbSPSPersonsRescuedSex.Value = String.Empty
                End If

                txtSPSPersonsRescuedAge.Text = .Cells(IMSConstants.GridHeader.Age).Value.ToString()
                txtSPSPersonsRescuedMethod.Text = .Cells(IMSConstants.GridHeader.MethodOfRescueAndEscape).Value.ToString()
                txtSPSPersonsRescuedPersonEfectingRescue.Text = .Cells(IMSConstants.GridHeader.PersonEfectingRescue).Value.ToString()
            End With

            _isUpdateSPSPersonRescued = True
            btnSPSPersonsRescuedAdd.Text = IMSConstants.ButtonText.Update
            btnSPSPersonsRescuedDelete.Enabled = True

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnSPSPersonsRescuedDelete_Click(sender As Object, e As EventArgs) Handles btnSPSPersonsRescuedDelete.Click
        Try
            'If already exist at database record delete, then keep track it for delete it from database finally.
            If CInt(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString()) > 0 Then
                'TODO : Keep data for the deleting at final stage.
                'take data into object

                Dim objPRescued As New IMSService.PersonsRescuedAndEscaping
                With objPRescued
                    .RescuedID = CInt(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.RescuedID).Value.ToString())
                    .IncidentID = CInt(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentID).Value.ToString())
                    .IncidentCategoryID = CInt(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.FieldConstants.IncidentTypeID).Value.ToString())
                    .Name = grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Name).Value.ToString()
                    'Get Sex from Grid Field (From Enum description)
                    If Not String.IsNullOrEmpty(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value) Then
                        cmbSPSPersonsRescuedSex.Value = GetEnumValueFromDescription(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Sex).Value.ToString())
                    Else
                        cmbSPSPersonsRescuedSex.Value = String.Empty
                    End If

                    .Age = CInt(grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.Age).Value.ToString())
                    .Method = grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.MethodOfRescueAndEscape).Value.ToString()
                    .PersonEfectingRescue = grvSPSPersonsRescued.Selected.Rows(0).Cells(IMSConstants.GridHeader.PersonEfectingRescue).Value.ToString()
                    .IsDeleted = True
                End With

                _lstSPSPersonRescuedDeleted.Add(objPRescued)
            End If

            'Now remove from list to remove show from grid
            _lstSPSPersonRescued.RemoveAt(_selectedIndexOfGridSPSPersonRescued)

            LoadGridSPSPersonRescued()
            ClearSPSPersonsRescuedFields()
            grvSPSPersonsRescued.Selected.Rows.Clear()

            btnSPSPersonsRescuedAdd.Text = IMSConstants.ButtonText.Add
            btnSPSPersonsRescuedDelete.Enabled = False
            _isUpdateSPSPersonRescued = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnSPSPersonsRescuedRefresh_Click(sender As Object, e As EventArgs) Handles btnSPSPersonsRescuedRefresh.Click
        Try
            ClearSPSPersonsRescuedFields()
            grvSPSPersonsRescued.Selected.Rows.Clear()
            btnSPSPersonsRescuedAdd.Text = IMSConstants.ButtonText.Add
            btnSPSPersonsRescuedDelete.Enabled = False
            _isUpdateSPSPersonRescued = False

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Load Special Service Persons Rescued Grid at form load time.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSPSPersonsRescuedInitialy()

        'Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & " and " & _
        '    IMSConstants.FieldConstants.IncidentID & " = " & _incidentID & " and " & _
        '    IMSConstants.FieldConstants.IncidentCategoryID & " = " & CInt(IMSEnums.IncidentCategory.SpecialService)

        'Me._lstSPSPersonRescued = _proxy.GetFilteredPersonsRescuedAndEscaping(sql).Cast(Of IMSService.PersonsRescuedAndEscaping).ToList()

        Me._lstSPSPersonRescued = CommonFunction.GetPersonRescuedByIncidentIDAndCategory(_incidentID, CInt(IMSEnums.IncidentCategory.SpecialService))

        Me.LoadGridSPSPersonRescued()

    End Sub

#End Region

End Class