'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 11-May-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization

Public Class frmEmployeeCheckInOut
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private _shiftId As Integer = 0
    Private _checkedIn As Boolean

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal checkedIn As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _checkedIn = checkedIn

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load Fire Station. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStation()

        Dim dtStation As DataTable = CommonFunction.GetTableForStationDropDown()

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
    ''' Method to load shift. 
    ''' </summary>
    ''' <param name="stationId"></param>
    ''' <remarks></remarks>
    Private Sub LoadShift(ByVal stationId As Integer)

        Dim currentTime As TimeSpan = Now.TimeOfDay()
        _shiftId = CommonFunction.GetShiftIDByStationIDAndTime(stationId, currentTime)

        If _shiftId > 0 Then
            Dim objShift As IMSService.Shift = _proxy.GetShiftByID(_shiftId)

            If Not IsNothing(objShift) Then
                lblShift.Text = objShift.ShiftName
            Else
                lblShift.Text = IMSConstants.Common.N_A
            End If
        Else
            lblShift.Text = IMSConstants.Common.N_A

        End If

    End Sub

    ''' <summary>
    ''' Method to check Is Employee checked in
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="employeeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsCheckedIn(ByVal stationID As Integer, ByVal employeeID As Integer) As Boolean

        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim shiftID As Integer = CommonFunction.GetShiftIDByStationIDAndTime(stationID, currentTime)
        Dim strSQL As String = IMSConstants.FieldConstants.EmployeeID & " = " & employeeID & " AND " & IMSConstants.FieldConstants.ShiftID & " = " & shiftID & " AND " & IMSConstants.FieldConstants.InsertionDate & " = '" & Now.Date.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & "' AND " & IMSConstants.FieldConstants.RegisterStatus & " = " & IMSEnums.RegisterStatus.CheckedIn & " AND " & IMSConstants.FieldConstants.IsCurrent & " ='1' "
        Dim lstEmployeeRegister As List(Of IMSService.EmployeeRegister) = _proxy.GetFilteredEmployeeRegister(strSQL).Cast(Of IMSService.EmployeeRegister).ToList()

        If lstEmployeeRegister.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to check Is Employee checked Out.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="employeeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsCheckedOut(ByVal stationID As Integer, ByVal employeeID As Integer) As Boolean

        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim shiftID As Integer = CommonFunction.GetShiftIDByStationIDAndTime(stationID, currentTime)
        Dim strSQL As String = IMSConstants.FieldConstants.EmployeeID & " = " & employeeID & " AND " & IMSConstants.FieldConstants.StationID & " = " & stationID & " AND " & IMSConstants.FieldConstants.ShiftID & " = " & shiftID & " AND " & IMSConstants.FieldConstants.InsertionDate & " = '" & Now.Date & "' AND " & IMSConstants.FieldConstants.RegisterStatus & " = " & IMSEnums.RegisterStatus.CheckedOut & " AND " & IMSConstants.FieldConstants.IsCurrent & " ='1' "
        Dim lstEmployeeRegister As List(Of IMSService.EmployeeRegister) = _proxy.GetFilteredEmployeeRegister(strSQL).Cast(Of IMSService.EmployeeRegister).ToList()

        If lstEmployeeRegister.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to set EmployeeRegister object
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetFormData() As IMS.Win.IMSService.EmployeeRegister

        Dim objEmployeeRegister As New IMS.Win.IMSService.EmployeeRegister
        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With objEmployeeRegister
            .ShiftID = _shiftId
            .StationID = cmbCheckInStation.Value
            .EmployeeID = cmbEmployee.Value
            .IsCurrent = True
            .OnEvent = False
            .Reason = txtReason.Text
            .InsertionDate = currentDate
            .ModificationDate = currentDate
        End With
        Return objEmployeeRegister

    End Function

    ''' <summary>
    ''' Method to set EmployeeRegister object by 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.EmployeeRegister

        Dim objEmployeeRegister As IMSService.EmployeeRegister = SetFormData()

        If _checkedIn = True Then
            If Me.IsCheckedIn(cmbCheckInStation.Value, cmbEmployee.Value) = False Then
            Else
                objEmployeeRegister.RegisterStatus = IMSEnums.RegisterStatus.CheckedOut
                _proxy.InsertEmployeeRegister(objEmployeeRegister)
            End If
            objEmployeeRegister.RegisterStatus = IMSEnums.RegisterStatus.CheckedIn
        Else
            If Me.IsCheckedOut(cmbCheckInStation.Value, cmbEmployee.Value) = False Then
                objEmployeeRegister.RegisterStatus = IMSEnums.RegisterStatus.CheckedOut
            Else
                DisplayInformation("Please Check In First")
                objEmployeeRegister = New IMSService.EmployeeRegister
            End If
        End If

        Return objEmployeeRegister

    End Function

    ''' <summary>
    ''' Methode to load employee
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployee(ByVal stationID As Integer)

        Dim lstEmployee As New List(Of IMSService.Employee)
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim stationShiftID = CommonFunction.GetShiftIDByStationIDAndTime(stationID, currentTime)

        If _checkedIn Then
            lstEmployee = CommonFunction.GetAllNotCheckedInEmployeeStationAndShiftWise(stationID, stationShiftID)
        Else
            lstEmployee = CommonFunction.GetAllCheckedInEmployeeStationAndShiftWise(stationID, stationShiftID)
        End If

        Dim objEmployee As IMSService.Employee = New IMSService.Employee()
        objEmployee.EmployeeID = 0
        objEmployee.EmployeeName = " "
        lstEmployee.Insert(0, objEmployee)

        With Me.cmbEmployee
            .DataSource = lstEmployee
            .ValueMember = IMSConstants.FieldConstants.EmployeeID
            .DisplayMember = IMSConstants.FieldConstants.EmployeeName
            .DataBind()
            '.Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to check validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        If cmbStationName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectEmployeeStation)
            cmbStationName.Focus()
            Return False
        End If

        If cmbEmployee.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectEmployee)
            cmbEmployee.Focus()
            Return False
        End If

        If cmbCheckInStation.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectCheckInStation)
            cmbCheckInStation.Focus()
            Return False
        End If

        If lblShift.Text = IMSConstants.Common.N_A Then
            DisplayWarning(IMSConstants.ErrorMessage.NoShiftFound)
            cmbCheckInStation.Focus()
            Return False
        End If


        Return True

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


#End Region

#Region "Event"

    Public Event LoadEmployeeByStation(ByVal stationID As Integer)

#End Region

#Region "Event Handlers"

    Private Sub frmEmployeeCheckInOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If _checkedIn = True Then
                Me.Text = "Employee Check In"
                lblStation.Text = "Check In Station :"
            Else
                Me.Text = "Employee Check Out"
                lblStation.Text = "Check Out Station :"
            End If
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
            Dim objEmployeeRegister As IMSService.EmployeeRegister = SetData()
            If (objEmployeeRegister.EmployeeID > 0) Then
                CommonFunction.UpdateIsTrueForEmployeeRegister(objEmployeeRegister.EmployeeID)
                'CommonFunction.UpdateEmployeeOccupied(objEmployeeRegister.EmployeeID)
                CommonFunction.UpdateEmployeeOccupiedToAvailable(objEmployeeRegister.EmployeeID)
                intActionResult = _proxy.InsertEmployeeRegister(objEmployeeRegister)
            End If
            If intActionResult > 0 Then
                DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                'Me.Close()
                RaiseEvent LoadEmployeeByStation(objEmployeeRegister.StationID)
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
            Dim stationId As Integer = 0
            If Not String.IsNullOrEmpty(cmbStationName.Text) Then
                stationId = Convert.ToInt32(cmbStationName.Value)
            End If

            'Me.LoadShift(stationId)
            Me.LoadEmployee(stationId)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub cmbCheckInStationName_SelectionChanged(sender As Object, e As EventArgs) Handles cmbCheckInStation.SelectionChanged
        Try
            Dim stationId As Integer = 0
            If Not String.IsNullOrEmpty(cmbCheckInStation.Text) Then
                stationId = Convert.ToInt32(cmbCheckInStation.Value)
            End If

            Me.LoadShift(stationId)
            ' Me.LoadEmployee(stationId)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

End Class