'Author                : Shah Jafar Ulla
'Crated Date           : 24/4/2014
'Last Modified by      : 
'Last Modifiation Date : 
'(C) CopyRight Nybsys.

Imports Infragistics.Win.UltraWinGrid
Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win
Imports System.Globalization

Public Class frmViewCurrentDispatchList
    Inherits BaseForm

#Region "Member"

    Dim _proxy As New IMSService.IMSServices
    Dim incidentID As Integer = 34

    Dim assignedApplianceID As Integer
    Dim gridCellIndex As Integer

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmViewCurrentDispatchList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            LoadApplianceDispatched()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grvCurrentDispatch_ClickCellButton(sender As Object, e As CellEventArgs) Handles grvCurrentDispatch.ClickCellButton
        Try

            assignedApplianceID = grvCurrentDispatch.Rows(e.Cell.Row.Index).Cells(0).Value

            'Re-dispatched Button Clicked
            If e.Cell.Column.Index = 5 Then

                gridCellIndex = 5

                Dim frm As frmRevokeReason = New frmRevokeReason(IMSConstants.Information.PleaseGiveAReasonForRedispatch)
                AddHandler frm.LoadReasonForSave, AddressOf UpdateCurrentDispatch
                AddHandler frm.LoadDoNothig, AddressOf DoNothig
                frm.ShowDialog()

            End If

            'Revoke Button Clicked
            If e.Cell.Column.Index = 6 Then

                gridCellIndex = 6

                Dim frm As frmRevokeReason = New frmRevokeReason(IMSConstants.Information.PleaseGiveAReasonForInvoking)
                AddHandler frm.LoadReasonForSave, AddressOf UpdateCurrentDispatch
                AddHandler frm.LoadDoNothig, AddressOf DoNothig
                frm.ShowDialog()

            End If



            'Dim assignedApplianceID As Integer = grvCurrentDispatch.Rows(e.Cell.Row.Index).Cells(0).Value
            'Dim objAssignedAppliance As AssignedAppliance = _proxy.GetAssignedApplianceByID(assignedApplianceID)

            ''Re-dispatched Button Clicked
            'If e.Cell.Column.Index = 5 Then

            '    'Before Re-dispatch - Check weather it assigned to other incident 
            '    If (objAssignedAppliance.AssignedApplianceStatus = IMSEnums.ApplianceStatus.Dispatched) Or (objAssignedAppliance.AssignedApplianceStatus = IMSEnums.ApplianceStatus.Redispatched) Then
            '        DisplayError(IMSConstants.ErrorMessage.ThisVehicleOccupiedOthers)
            '        Exit Sub
            '    End If

            '    objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Redispatched)
            'End If

            ''Revoke Button Clicked
            'If e.Cell.Column.Index = 6 Then
            '    objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Revoked)
            'End If

            'If _proxy.UpdateAssignedAppliance(objAssignedAppliance) > 0 Then

            '    If e.Cell.Column.Index = 5 Then
            '        DisplaySuccessfull(IMSConstants.SuccessMessageConstants.ReDispatchedSuccessfully)
            '    End If
            '    If e.Cell.Column.Index = 6 Then
            '        DisplaySuccessfull(IMSConstants.SuccessMessageConstants.RevokedSuccessfully)
            '    End If
            'Else

            '    If e.Cell.Column.Index = 5 Then
            '        DisplayError(IMSConstants.ErrorMessage.RedispathedFailed)
            '    End If
            '    If e.Cell.Column.Index = 6 Then
            '        DisplayError(IMSConstants.ErrorMessage.RevokedFailed)
            '    End If

            'End If

            'LoadApplianceDispatched()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grvCurrentDispatch_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grvCurrentDispatch.InitializeRow


        e.Row.Cells(4).Appearance.ForeColor = Color.White
        e.Row.Cells(4).Appearance.BackColor = Color.Gray

        If (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Dispatched)) Or (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Redispatched)) Then
            e.Row.Cells(5).Activation = Activation.Disabled
        End If

        If (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Revoked)) Or (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.BackAfterResolved)) Then
            e.Row.Cells(6).Activation = Activation.Disabled
        End If


    End Sub

#End Region

#Region "User Defined Methods"

    ''' <summary>
    ''' Method to load Current dispatched appliances for a specific incident.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadApplianceDispatched()

        Dim dtAssignedAppliance As New DataTable

        Dim sql As String = String.Format("{0} = {1} and {2} <> {3}", IMSConstants.FieldConstants.IncidentID, incidentID, IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes))
        Dim lstAssignedAppliance As List(Of AssignedAppliance) = _proxy.GetFilteredAssignedAppliance(sql).Cast(Of AssignedAppliance).ToList()

        If lstAssignedAppliance.Count > 0 Then

            dtAssignedAppliance = GetTableOfAssignedAppliance(lstAssignedAppliance)

            grvCurrentDispatch.DataSource = dtAssignedAppliance
            grvCurrentDispatch.DataBind()

        End If

    End Sub

    ''' <summary>
    ''' Method to Mapped Assigned Appliance List to Table.
    ''' </summary>
    ''' <param name="lstAssignedAppliance"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTableOfAssignedAppliance(lstAssignedAppliance As List(Of AssignedAppliance)) As DataTable
        Dim dtAssignedAppliance As DataTable = CreateEmptyAssignedApplianceTable()
        Dim row As DataRow
        Dim objAppliance As New Appliance
        Dim objFireStation As New FireStation
        Dim objFireStationAppliance As New FireStationAppliance

        If lstAssignedAppliance.Count > 0 Then

            For Each obj As AssignedAppliance In lstAssignedAppliance

                row = dtAssignedAppliance.NewRow

                With obj

                    row(IMSConstants.FieldConstants.FireStationApplianceID) = .AssignedApplianceID

                    ''Get Vehicle and Station.
                    objFireStationAppliance = _proxy.GetFireStationApplianceByID(.StationApplianceID)

                    If Not IsNothing(objFireStationAppliance) Then

                        '' Appliance Code
                        objAppliance = _proxy.GetApplianceByID(objFireStationAppliance.ApplianceID)
                        If Not IsNothing(objAppliance) Then
                            row(IMSConstants.ColumnHeader.VehicleCode) = objAppliance.ApplianceCode
                        End If
                        '' Station Name
                        objFireStation = _proxy.GetFireStationByID(objFireStationAppliance.StationID)
                        If Not IsNothing(objFireStation) Then
                            row(IMSConstants.ColumnHeader.StationName) = objFireStation.StationName
                        End If

                        row(IMSConstants.ColumnHeader.SerialNumber) = objFireStationAppliance.SerialNumber

                    End If

                    row(IMSConstants.ColumnHeader.ActionTaken) = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), .AssignedApplianceStatus)
                    row(IMSConstants.ColumnHeader.Redispatch) = IMSConstants.ColumnHeader.Redispatch
                    row(IMSConstants.Common.Revoke) = IMSConstants.Common.Revoke

                End With

                dtAssignedAppliance.Rows.Add(row)

            Next
        End If

        Return dtAssignedAppliance

    End Function

    ''' <summary>
    ''' Method to Create Empty Assigned Appliance Table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateEmptyAssignedApplianceTable() As DataTable

        Dim dtAssignedAppliance As New DataTable

        dtAssignedAppliance.Columns.Add(IMSConstants.FieldConstants.FireStationApplianceID, GetType(Integer))
        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.VehicleCode, GetType(String))
        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.StationName, GetType(String))
        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.SerialNumber, GetType(String))
        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.ActionTaken, GetType(String))
        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.Redispatch)
        dtAssignedAppliance.Columns.Add(IMSConstants.Common.Revoke)

        Return dtAssignedAppliance

    End Function

    ''' <summary>
    ''' Method to Update Current dispatch on event from reason form
    ''' </summary>
    ''' <param name="reason"></param>
    ''' <remarks></remarks>
    Private Sub UpdateCurrentDispatch(ByVal reason As String)

        Try

            'Dim assignedApplianceID As Integer = grvCurrentDispatch.Rows(e.Cell.Row.Index).Cells(0).Value
            Dim currentTime As Date
            Dim dispatchLog As New DispatchLog
            Dim objAssignedAppliance As AssignedAppliance = _proxy.GetAssignedApplianceByID(assignedApplianceID)

            'Re-dispatched Button Clicked
            If gridCellIndex = 5 Then

                'Before Re-dispatch - Check weather it assigned to other incident 
                If (objAssignedAppliance.AssignedApplianceStatus = IMSEnums.ApplianceStatus.Dispatched) Or (objAssignedAppliance.AssignedApplianceStatus = IMSEnums.ApplianceStatus.Redispatched) Then
                    DisplayError(IMSConstants.ErrorMessage.ThisVehicleOccupiedOthers)
                    Exit Sub
                End If

                objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Redispatched)
            End If

            'Revoke Button Clicked
            If gridCellIndex = 6 Then
                objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Revoked)
            End If

            If _proxy.UpdateAssignedAppliance(objAssignedAppliance) > 0 Then

                If gridCellIndex = 5 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.ReDispatchedSuccessfully)
                End If
                If gridCellIndex = 6 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.RevokedSuccessfully)
                End If
            Else

                If gridCellIndex = 5 Then
                    DisplayError(IMSConstants.ErrorMessage.RedispathedFailed)
                End If
                If gridCellIndex = 6 Then
                    DisplayError(IMSConstants.ErrorMessage.RevokedFailed)
                End If

            End If

            'Insert into Dispatch Log
            With dispatchLog
                .IncidentID = objAssignedAppliance.IncidentID
                .StationApplianceID = objAssignedAppliance.StationApplianceID
                .AssignedApplianceStatus = objAssignedAppliance.AssignedApplianceStatus
                .Reason = reason
                DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)
                .DispatchDate = currentTime
                .CreatedBy = IMSConstants.AppConstants.LoggedinUserID '36  'change it by logged in employee

            End With
            _proxy.InsertDispatchLog(dispatchLog)

            LoadApplianceDispatched()

            'Reset values
            assignedApplianceID = 0
            gridCellIndex = 0

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Method for do nothing
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DoNothig()
        ''Do no thing
    End Sub

#End Region


End Class