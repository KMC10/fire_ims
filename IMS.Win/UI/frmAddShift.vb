'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 8-May-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization


Public Class frmAddShift
    Inherits BaseForm

#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mShift As New IMSService.Shift
    Private _proxy As New IMSService.IMSServices

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal shieftID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mShift = _proxy.GetShiftByID(shieftID)
        Me.Text = "Update Shift"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to Load fire station.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStation()

        Dim dtFireStation As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & "StationName ASC"

        With dtFireStation.Columns
            .Add(IMSConstants.FieldConstants.StationID)
            .Add(IMSConstants.FieldConstants.StationName)
        End With

        For Each obj As IMSService.FireStation In _proxy.GetFilteredFireStation(strSQL)
            Dim row As DataRow = dtFireStation.NewRow
            row(IMSConstants.FieldConstants.StationID) = obj.StationID
            row(IMSConstants.FieldConstants.StationName) = obj.StationName

            dtFireStation.Rows.Add(row)
        Next

        Dim rows As DataRow = dtFireStation.NewRow
        rows(IMSConstants.FieldConstants.StationID) = String.Empty
        rows(IMSConstants.FieldConstants.StationName) = String.Empty
        dtFireStation.Rows.InsertAt(rows, 0)


        With Me.cmbStation
            .DataSource = dtFireStation
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to set shift object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.Shift

        Dim objShift As New IMS.Win.IMSService.Shift
        Dim currentTime As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)

        With objShift
            .ShiftName = txtShiftName.Text.Trim()
            .StationID = cmbStation.Value
            .ShiftStartTime = dtpStartTime.Value.ToString("HH:mm:00")
            .ShiftEndTime = dtpEndTime.Value.ToString("HH:mm:00")
            .InsertionDate = currentTime
            .ModificationDate = currentTime
            .Status = CInt(IMSEnums.Status.Active)
        End With
        Return objShift

    End Function

    ''' <summary>
    ''' Method to set shift object by object.
    ''' </summary>
    ''' <param name="objFireStation"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objFireStation As IMS.Win.IMSService.Shift)
        Dim currentTime As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)


        With mShift
            .ShiftName = txtShiftName.Text.Trim()
            .StationID = cmbStation.Value
            .ShiftStartTime = dtpStartTime.Value.ToString("HH:mm:00")
            .ShiftEndTime = dtpEndTime.Value.ToString("HH:mm:00")
            .ModificationDate = currentTime

        End With

    End Sub

    ''' <summary>
    ''' Method to check from validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True
        Dim IsOverlap As Boolean = False
        Dim shiftIDWithStartTime As Integer = 0
        Dim shiftIDWithEndTime As Integer = 0

        If txtShiftName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeShiftName)
            txtShiftName.Focus()
            Return False
        End If

        If cmbStation.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectStation)
            cmbStation.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mShift.ShiftName = (txtShiftName.Text.Trim()) And mShift.StationID = (cmbStation.Value) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtShiftName.Text, cmbStation.Value) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateStationCode)
            Me.txtShiftName.Focus()
            Return False
        End If

        '(Check shift overlap) - Check with start and end time

        If Not (cmbStation.Value = String.Empty) And Not (dtpStartTime.Text = String.Empty) Then

            Dim startTime As TimeSpan = TimeSpan.Parse(dtpStartTime.Value.ToString("HH:mm:00")) ' TimeSpan.Parse(dtpStartTime.Text.ToString("HH:mm:ss"))
            Dim endTime As TimeSpan = TimeSpan.Parse(dtpEndTime.Value.ToString("HH:mm:00")) 'TimeSpan.Parse(dtpEndTime.Text)
            'Logic :: Taking One second minus from original End time (Because End time should be one second before the showing time)
            endTime = endTime - TimeSpan.Parse("00:00:01")

            shiftIDWithStartTime = CommonFunction.GetShiftIDByStationIDAndTime(cmbStation.Value, startTime)
            shiftIDWithEndTime = CommonFunction.GetShiftIDByStationIDAndTime(cmbStation.Value, endTime)

            If shiftIDWithStartTime > 0 Then
                If (IsUpdate = True) And (mShift.ShiftID = shiftIDWithStartTime) Then
                    IsOverlap = False
                Else
                    IsOverlap = True
                End If
            End If

            If IsOverlap = False Then
                If shiftIDWithEndTime > 0 Then
                    If (IsUpdate = True) And (mShift.ShiftID = shiftIDWithEndTime) Then
                        IsOverlap = False
                    Else
                        IsOverlap = True
                    End If
                End If
            End If

            If IsOverlap Then
                Me.DisplayWarning(IMSConstants.ErrorMessage.ShiftTimeOverlapWithOtherShift)
                Me.txtShiftName.Focus()
                Return False
            End If

        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to check duplicate shift.
    ''' </summary>
    ''' <param name="shiftName"></param>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal shiftName As String, ByVal stationID As Integer) As Boolean

        Dim filter As String = String.Format("{0}='{1}' and {2}='{3}' and {4}<>{5}", IMSConstants.FieldConstants.ShiftName, shiftName, IMSConstants.FieldConstants.StationID, stationID, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Deleted))
        Dim lstShift As List(Of IMS.Win.IMSService.Shift) = _proxy.GetFilteredShift(filter).Cast(Of IMS.Win.IMSService.Shift).ToList

        If lstShift.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to view form data.
    ''' </summary>
    ''' <param name="objShift"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objShift As IMS.Win.IMSService.Shift)

        With objShift
            txtShiftName.Text = .ShiftName
            cmbStation.Value = .StationID
            dtpStartTime.Value = Convert.ToDateTime(.ShiftStartTime)
            dtpEndTime.Value = Convert.ToDateTime(.ShiftEndTime)

            If .StationID = 0 Then
                cmbStation.Text = String.Empty
            End If

        End With


    End Sub

    ''' <summary>
    ''' Method to update Shift.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateShift() As Integer

        Dim id As Integer = -1
        Me.SetData(mShift)
        ' Dim objFireStation As IMS.Win.IMSService.FireStation = mFireStation

        id = _proxy.UpdateShift(mShift)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save Shift.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveShift() As Integer

        Dim id As Integer = -1
        Dim objShift As IMS.Win.IMSService.Shift = SetData()

        id = _proxy.InsertShift(objShift)

        Return id

    End Function

    ' ''' <summary>
    ' ''' Method to Set Security.
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub SetSecurity()



    '    For Each objControl As Control In Me.Controls
    '        Me.RecurseControls(objControl)
    '    Next

    'End Sub

    ' ''' <summary>
    ' ''' Method to recurcive function for enable disablecontrols.
    ' ''' </summary>
    ' ''' <param name="ctr"></param>
    ' ''' <remarks></remarks>
    'Private Sub RecurseControls(ByVal ctr As Control)

    '    If ctr.HasChildren Then
    '        For Each objControl As Control In ctr.Controls
    '            RecurseControls(objControl)
    '        Next objControl
    '    Else
    '        If ctr.Name.Contains("btn") Then
    '            Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = ctr.Name And x.FrontEndParentID = Me.Name).FirstOrDefault()
    '            ctr.Enabled = Not IsNothing(objSavePrivilig)
    '        End If

    '        'Enable all close button.
    '        btnClose.Enabled = True
    '    End If

    'End Sub

#End Region

#Region "Event"

    Public Event LoadShift()

#End Region

#Region "Event Handlers"

    Private Sub frmAddShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            Me.LoadStation()
            If mShift.ShiftID > 0 Then
                Me.ViewFormData(mShift)
            End If
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Dim intActionResult As Integer = 0

            If Me.IsValidate = False Then Exit Sub

            If Me.IsUpdate = True Then
                intActionResult = Me.UpdateShift()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadShift()
                    Me.Close()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)

                End If
            Else
                intActionResult = Me.SaveShift()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadShift()
                    ResetallControll()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)

                End If
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

    Private Sub ResetallControll()

        Me.txtShiftName.Text = String.Empty
        Me.cmbStation.Text = String.Empty
    End Sub

End Class