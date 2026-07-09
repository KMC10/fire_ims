'Author                : Jafar Ulla
'Crated Date           : 07/07/2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization

Public Class frmBulkCheckInOut
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

#Region "Event"

    Public Event LoadEmployeeByStation(ByVal stationID As Integer)

#End Region

#Region "User Defined Methods"

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
    ''' Method to Load Employee Group
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployeeGroup()

        'Dim dtFireStation As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & IMSConstants.FieldConstants.GroupName & " ASC"
        Dim lstGroup As List(Of IMSService.Group) = _proxy.GetFilteredGroup(strSQL).Cast(Of IMSService.Group).ToList()

        Dim objGroup As New IMSService.Group
        objGroup.GroupID = 0
        objGroup.GroupName = " "
        lstGroup.Insert(0, objGroup)

        If lstGroup.Count > 0 Then

            With Me.cmbEmployeeGroup
                .DataSource = lstGroup
                .ValueMember = IMSConstants.FieldConstants.GroupID
                .DisplayMember = IMSConstants.FieldConstants.GroupName
                .DataBind()
            End With

        End If

    End Sub

    ''' <summary>
    ''' Method to Load Employee List
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployeeList()

        If Not String.IsNullOrEmpty(cmbStationName.Text.Trim()) And Not String.IsNullOrEmpty(cmbEmployeeGroup.Text.Trim()) Then

            If _shiftId > 0 Then

                Dim lstEmployee As New List(Of IMSService.Employee)

                If _checkedIn Then
                    lstEmployee = CommonFunction.GetAllNotCheckedInEmployeeGroupAndStationAndShiftWise(cmbEmployeeGroup.Value, cmbStationName.Value, _shiftId)
                Else
                    lstEmployee = CommonFunction.GetAllCheckedInEmployeeGroupAndStationAndShiftWise(cmbEmployeeGroup.Value, cmbStationName.Value, _shiftId)
                End If

                With chkEmployeeList
                    .DataSource = lstEmployee
                    .ValueMember = IMSConstants.FieldConstants.EmployeeID
                    .DisplayMember = IMSConstants.FieldConstants.EmployeeName
                    .ClearSelected()
                End With

                'Check all Items

                For i = 0 To chkEmployeeList.Items.Count - 1
                    Dim item As IMSService.Employee = chkEmployeeList.Items(i)
                    Me.chkEmployeeList.SetItemCheckState(i, CheckState.Checked)
                Next

            End If
        End If

    End Sub

    ''' <summary>
    ''' Method to Check in ( + additional works)
    ''' </summary>
    ''' <param name="objEmployeeRegister"></param>
    ''' <remarks></remarks>
    Private Sub DoCheckIn(ByVal objEmployeeRegister As IMSService.EmployeeRegister)

        CommonFunction.UpdateIsTrueForEmployeeRegister(objEmployeeRegister.EmployeeID)
        'CommonFunction.UpdateEmployeeOccupied(objEmployeeRegister.EmployeeID)
        CommonFunction.UpdateEmployeeOccupiedToAvailable(objEmployeeRegister.EmployeeID)
        _proxy.InsertEmployeeRegister(objEmployeeRegister)

    End Sub

    ''' <summary>
    ''' Method to Check Form validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        If String.IsNullOrEmpty(cmbStationName.Text) Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectEmployeeStation)
            cmbStationName.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(cmbEmployeeGroup.Text) Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectEmployeeGroup)
            cmbStationName.Focus()
            Return False
        End If

        If lblShift.Text = IMSConstants.Common.N_A Then
            DisplayWarning(IMSConstants.ErrorMessage.NoShiftFound)
            cmbStationName.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to Get Form data.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFormData() As IMS.Win.IMSService.EmployeeRegister

        Dim objEmployeeRegister As New IMS.Win.IMSService.EmployeeRegister
        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With objEmployeeRegister
            .ShiftID = _shiftId
            .StationID = cmbStationName.Value
            .EmployeeID = cmbEmployeeGroup.Value
            .IsCurrent = True
            .OnEvent = False
            .Reason = txtReason.Text.Trim()
            .InsertionDate = currentDate
            .ModificationDate = currentDate
        End With
        Return objEmployeeRegister

    End Function

#End Region

#Region "Event Handlers"

    Private Sub frmBulkCheckInOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If _checkedIn = True Then
                Me.Text = "Bulk/Group Check In"
            Else
                Me.Text = "Bulk/Group Check Out"
            End If

            Me.LoadStation()
            Me.LoadEmployeeGroup()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub cmbEmployeeGroup_SelectionChanged(sender As Object, e As EventArgs) Handles cmbEmployeeGroup.SelectionChanged

        Try

            Me.LoadEmployeeList()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub cmbStationName_SelectionChanged(sender As Object, e As EventArgs) Handles cmbStationName.SelectionChanged

        Try

            Dim stationId As Integer = 0
            If Not String.IsNullOrEmpty(cmbStationName.Text) Then
                stationId = Convert.ToInt32(cmbStationName.Value)
            End If
            Me.LoadShift(stationId)

            Me.LoadEmployeeList()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            If Me.IsValidate() = False Then Exit Sub

            Dim objEmployeeRegister As IMSService.EmployeeRegister = GetFormData()

            'Check In/Out all checked Employee
            For Each objEmployee As IMSService.Employee In chkEmployeeList.CheckedItems

                objEmployeeRegister.EmployeeID = objEmployee.EmployeeID
                If _checkedIn Then
                    objEmployeeRegister.RegisterStatus = CInt(IMSEnums.RegisterStatus.CheckedIn)
                Else
                    objEmployeeRegister.RegisterStatus = CInt(IMSEnums.RegisterStatus.CheckedOut)
                End If

                'If Check in make available status at "Assigned Employee"
                If _checkedIn Then
                    'CommonFunction.UpdateEmployeeOccupied(objEmployeeRegister.EmployeeID)
                    CommonFunction.UpdateEmployeeOccupiedToAvailable(objEmployeeRegister.EmployeeID)
                End If

                CommonFunction.UpdateIsTrueForEmployeeRegister(objEmployeeRegister.EmployeeID)
                _proxy.InsertEmployeeRegister(objEmployeeRegister)

            Next

            If _checkedIn Then
                DisplaySuccessfull(IMSConstants.SuccessMessageConstants.BulkCheckedInSuccessfull)
            Else
                DisplaySuccessfull(IMSConstants.SuccessMessageConstants.BulkCheckedOutSuccessfull)
            End If

            'Me.Close()
            RaiseEvent LoadEmployeeByStation(objEmployeeRegister.StationID)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

End Class

