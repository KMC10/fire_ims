'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 11-May-2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization

Public Class frmVehicleCheckInOut
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private _shiftId As Integer = 0
    Private _iScheckedIn As Boolean

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(isCheckIn As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _iScheckedIn = isCheckIn

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load vehicle by stationID.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub LoadVehicle(ByVal stationID As Integer)

        Dim dtAppliance As New DataTable
        Dim lstFireStationApplience As New List(Of IMSService.FireStationAppliance)
        Dim lstApplianceID As New List(Of Integer)
        Dim strSQL As String = IMSConstants.FieldConstants.Status & "=" & IMSEnums.Status.Active & " AND " & IMSConstants.FieldConstants.StationID & "=" & stationID
        lstFireStationApplience = _proxy.GetFilteredFireStationAppliance(strSQL).Cast(Of IMSService.FireStationAppliance).ToList()

        With dtAppliance.Columns
            .Add(IMSConstants.FieldConstants.ApplianceID)
            .Add(IMSConstants.FieldConstants.ApplianceCode)
            .Add(IMSConstants.FieldConstants.SerialNumber)
        End With

        If lstFireStationApplience.Count > 0 Then
            For Each obj As IMSService.FireStationAppliance In lstFireStationApplience

                If Not lstApplianceID.Contains(obj.ApplianceID) Then

                    lstApplianceID.Add(obj.ApplianceID) ' Logic : To avoid dulicate.
                    Dim objAppliance As IMSService.Appliance = _proxy.GetApplianceByID(obj.ApplianceID)

                    Dim row As DataRow = dtAppliance.NewRow
                    row(IMSConstants.FieldConstants.ApplianceID) = objAppliance.ApplianceID
                    row(IMSConstants.FieldConstants.ApplianceCode) = objAppliance.ApplianceCode
                    row(IMSConstants.FieldConstants.SerialNumber) = obj.SerialNumber
                    dtAppliance.Rows.Add(row)

                End If

            Next
        End If

        Dim rows As DataRow = dtAppliance.NewRow
        rows(IMSConstants.FieldConstants.ApplianceID) = String.Empty
        rows(IMSConstants.FieldConstants.ApplianceCode) = String.Empty
        rows(IMSConstants.FieldConstants.SerialNumber) = String.Empty
        dtAppliance.Rows.InsertAt(rows, 0)

        With Me.cmbVehicleCode
            .DataSource = dtAppliance
            .ValueMember = IMSConstants.FieldConstants.ApplianceID
            .DisplayMember = IMSConstants.FieldConstants.ApplianceCode
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to load serial by stationId and ApplienceID
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="applienceId"></param>
    ''' <remarks></remarks>
    Private Sub LoadSerial(ByVal stationID As Integer, ByVal applienceId As Integer)

        'Dim dtAppliance As New DataTable
        ''Dim strSQL As String = IMSConstants.FieldConstants.Status & " = " & IMSEnums.Status.Active & _
        ''    " AND " & IMSConstants.FieldConstants.ApplianceID & " = '" & applienceId & "' AND " _
        ''    & IMSConstants.FieldConstants.StationID & " = '" & stationID & "' ORDER BY " & "SerialNumber ASC"

        'With dtAppliance.Columns
        '    .Add(IMSConstants.FieldConstants.StationApplianceID)
        '    .Add(IMSConstants.FieldConstants.SerialNumber)
        'End With

        'For Each obj As IMSService.FireStationAppliance In _proxy.GetFilteredFireStationAppliance(strSQL)
        '    Dim row As DataRow = dtAppliance.NewRow
        '    row(IMSConstants.FieldConstants.StationApplianceID) = obj.StationApplianceID
        '    row(IMSConstants.FieldConstants.SerialNumber) = obj.SerialNumber

        '    dtAppliance.Rows.Add(row)
        'Next

        'Dim rows As DataRow = dtAppliance.NewRow
        'rows(IMSConstants.FieldConstants.StationApplianceID) = String.Empty
        'rows(IMSConstants.FieldConstants.SerialNumber) = String.Empty
        'dtAppliance.Rows.InsertAt(rows, 0)

        Dim lstVehicle As New List(Of IMSService.FireStationAppliance)

        If _iScheckedIn Then
            lstVehicle = CommonFunction.GetAllNotCheckedInVehicleStationAndApplianceIDWise(stationID, applienceId)
        Else
            lstVehicle = CommonFunction.GetAllCheckedInApplianceStationAndApplianceIDWise(stationID, applienceId)
        End If

        Dim objVehicel As New IMSService.FireStationAppliance
        objVehicel.SerialNumber = " "
        objVehicel.StationApplianceID = 0
        lstVehicle.Insert(0, objVehicel)

        With Me.cmbSerials
            .DataSource = lstVehicle
            .ValueMember = IMSConstants.FieldConstants.StationApplianceID
            .DisplayMember = IMSConstants.FieldConstants.SerialNumber
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to load Station.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStation()

        Dim dtStation As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & "StationName ASC"

        With dtStation.Columns
            .Add(IMSConstants.FieldConstants.StationID)
            .Add(IMSConstants.FieldConstants.StationName)
        End With

        For Each obj As IMSService.FireStation In _proxy.GetFilteredFireStation(strSQL)
            Dim row As DataRow = dtStation.NewRow
            row(IMSConstants.FieldConstants.StationID) = obj.StationID
            row(IMSConstants.FieldConstants.StationName) = obj.StationName

            dtStation.Rows.Add(row)
        Next

        Dim rows As DataRow = dtStation.NewRow
        rows(IMSConstants.FieldConstants.StationID) = String.Empty
        rows(IMSConstants.FieldConstants.StationName) = String.Empty
        dtStation.Rows.InsertAt(rows, 0)

        With Me.cmbStationName
            .DataSource = dtStation
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

        With Me.cmbCheckInStation
            .DataSource = dtStation
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to check validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean
        If cmbStationName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectVehicleStation)
            cmbStationName.Focus()
            Return False
        End If

        If cmbVehicleCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectVehicleCode)
            cmbVehicleCode.Focus()
            Return False
        End If

        If cmbSerials.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectSerials)
            cmbSerials.Focus()
            Return False
        End If

        If cmbCheckInStation.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectCheckInStation)
            cmbCheckInStation.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to set form Data.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetFormData() As IMS.Win.IMSService.ApplianceRegister
        Dim objApplianceRegister As New IMS.Win.IMSService.ApplianceRegister
        Dim currentDate As DateTime
        Dim currentApplianceRegister As New IMSService.ApplianceRegister
        DateTime.TryParseExact(Date.Now.ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.AppConstants.DateFormatToQuery, CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With objApplianceRegister

            .ShiftID = _shiftId
            .StationID = cmbCheckInStation.Value
            .StationApplianceID = cmbSerials.Value
            .IsCurrent = True
            .OnEvent = False
            .Reason = txtReason.Text
            .InsertionDate = currentDate
            .ModificationDate = currentDate

            ''(at checkin event) Set the Incident ID if This vehicle is checked out for the incident
            currentApplianceRegister = CommonFunction.GetCurrentCheckOut(.StationApplianceID)
            If Not IsNothing(currentApplianceRegister) Then
                .IncidentID = currentApplianceRegister.IncidentID
                .Reason = IMSConstants.Common.BackFromIncident
            End If

        End With
        Return objApplianceRegister

    End Function

    ''' <summary>
    ''' Method to set data.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.ApplianceRegister

        Dim objApplianceRegister As IMSService.ApplianceRegister = SetFormData()

        If _iScheckedIn = True Then
            If Me.IsCheckedIn(cmbCheckInStation.Value, cmbSerials.Value) = False Then

            Else
                objApplianceRegister.RegisterStatus = IMSEnums.RegisterStatus.CheckedOut
                _proxy.InsertApplianceRegister(objApplianceRegister)
            End If
            objApplianceRegister.RegisterStatus = IMSEnums.RegisterStatus.CheckedIn
        Else
            If Me.IsCheckedOut(cmbCheckInStation.Value, cmbSerials.Value) = False Then
                objApplianceRegister.RegisterStatus = IMSEnums.RegisterStatus.CheckedOut
            Else
                DisplayInformation("Please Check In First")
                objApplianceRegister = New IMSService.ApplianceRegister
            End If
        End If

        Return objApplianceRegister

    End Function

    ''' <summary>
    ''' Method to check checked In.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="StationApplianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsCheckedIn(ByVal stationID As Integer, ByVal StationApplianceID As Integer) As Boolean

        Dim strSQL As String = IMSConstants.FieldConstants.StationID & " = " & stationID & " AND " & IMSConstants.FieldConstants.RegisterStatus & " = " & IMSEnums.RegisterStatus.CheckedIn & " AND " & IMSConstants.FieldConstants.IsCurrent & " ='1' "
        Dim lstApplianceRegister As List(Of IMSService.ApplianceRegister) = _proxy.GetFilteredApplianceRegister(strSQL).Cast(Of IMSService.ApplianceRegister).ToList()

        If lstApplianceRegister.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to check ckecked Out.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="StationApplianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsCheckedOut(ByVal stationID As Integer, ByVal StationApplianceID As Integer) As Boolean

        Dim strSQL As String = IMSConstants.FieldConstants.StationApplianceID & " = " & StationApplianceID & " AND " & IMSConstants.FieldConstants.StationID & " = " & stationID & " AND " & IMSConstants.FieldConstants.RegisterStatus & " = " & IMSEnums.RegisterStatus.CheckedOut & " AND " & IMSConstants.FieldConstants.IsCurrent & " ='1' "
        Dim lstApplianceRegister As List(Of IMSService.ApplianceRegister) = _proxy.GetFilteredApplianceRegister(strSQL).Cast(Of IMSService.ApplianceRegister).ToList()

        If lstApplianceRegister.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to Set Security.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSecurity()

        For Each objControl As Control In Me.Controls
            Me.RecurseControls(objControl)
        Next

    End Sub

    ''' <summary>
    ''' Method to recurcive function for enable disablecontrols.
    ''' </summary>
    ''' <param name="ctr"></param>
    ''' <remarks></remarks>
    Private Sub RecurseControls(ByVal ctr As Control)

        If ctr.HasChildren Then
            For Each objControl As Control In ctr.Controls
                RecurseControls(objControl)
            Next objControl
        Else
            If ctr.Name.Contains("btn") Then
                Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = ctr.Name And x.FrontEndParentID = Me.Name).FirstOrDefault()
                ctr.Enabled = Not IsNothing(objSavePrivilig)
            End If
            btnClose.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' method for reset all controll.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetallControll()
        Me.cmbStationName.Text = String.Empty
        Me.txtVehicleName.Text = String.Empty
        Me.cmbCheckInStation.Text = String.Empty
        Me.cmbVehicleCode.Text = String.Empty
        Me.cmbSerials.Text = String.Empty
        Me.txtReason.Text = String.Empty
    End Sub


#End Region

#Region "Event"

    Public Event LoadApplianceRegisterByStation(ByVal stationID As Integer)

#End Region

#Region "Event Handlers"

    Private Sub frmVehicleCheckInOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            'Dim kk As DateTime = CommonFunction.GetTimeOfLastApplianceBackToStation(32)
            'Dim kkk As DateTime = CommonFunction.GetTimeOfFirstArrivalOfFireService(32)
            'Dim ll = CommonFunction.GetAllCategoriesForSpecificIncident(1)

            If _iScheckedIn = True Then
                Me.Text = "Vehicle Check In"
                lblStation.Text = "Check In Station :"
            Else
                Me.Text = "Vehicle Check Out"
                lblStation.Text = "Check Out Station :"
            End If
            ' Me.LoadVehicle()
            Me.LoadStation()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Me.IsValidate() = False Then Exit Sub

            Dim intActionResult As Integer = 0
            Dim objApplianceRegister As IMSService.ApplianceRegister = SetData()

            If (objApplianceRegister.StationApplianceID > 0) Then
                CommonFunction.UpdateIsTrueForApplianceRegister(objApplianceRegister.StationApplianceID)
                'CommonFunction.UpdateAssinedApplience(objApplianceRegister.StationApplianceID)
                CommonFunction.UpdateAssinedApplienceToAvailable(objApplianceRegister.StationApplianceID)
                intActionResult = _proxy.InsertApplianceRegister(objApplianceRegister)
            End If
            If intActionResult > 0 Then
                DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                'Me.Close()
                RaiseEvent LoadApplianceRegisterByStation(objApplianceRegister.StationID)
                ResetallControll()
            End If
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub cmbVehicleCode_SelectionChanged(sender As Object, e As EventArgs) Handles cmbVehicleCode.SelectionChanged
        Try
            If Not String.IsNullOrEmpty(cmbVehicleCode.Text) Then
                Dim dataTable As DataTable = cmbVehicleCode.DataSource
                Dim str As String = dataTable.Rows(cmbVehicleCode.SelectedIndex)(IMSConstants.FieldConstants.SerialNumber).ToString()
                Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(cmbVehicleCode.Value)
                If Not IsNothing(objApplience) Then
                    txtVehicleName.Text = objApplience.ApplianceName
                    Me.LoadSerial(cmbStationName.Value, cmbVehicleCode.Value)
                End If
            Else
                txtVehicleName.Text = String.Empty
                Me.LoadSerial(0, 0)
            End If
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbStationName_SelectionChanged(sender As Object, e As EventArgs) Handles cmbStationName.SelectionChanged
        Try
            Dim stationID As Integer = 0

            If Not String.IsNullOrEmpty(cmbStationName.Text) Then
                stationID = CInt(cmbStationName.Value)
            End If
            Me.LoadVehicle(stationID)
            Me.LoadSerial(0, 0)

            Me.txtVehicleName.Text = String.Empty
            Me.cmbVehicleCode.Text = String.Empty
            Me.cmbSerials.Text = String.Empty

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region


End Class