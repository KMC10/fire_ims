'Author                : Shah Jafar Ulla
'Crated Date           : 9/5/2014
'Last Modified by      : 
'Last Modifiation Date : 
'(C) CopyRight Nybsys.

Imports Infragistics.Win.UltraWinGrid
Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win
Imports System.Globalization

Public Class frmStationDashBoard
    Inherits BaseForm : Implements IMainForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private StationID As Integer = IMSConstants.AppConstants.UserStationID
    Private IsRed As Boolean = True
    Private secondCounter As Integer = 0

#End Region

#Region "User Defined Functions"

    ''' <summary>
    ''' Method to Load the Form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadForm()

        Dim lstIncidentAll As List(Of IncidentRegister) = CommonFunction.GetAllIncidentOfSpeficStation(StationID)

        Dim lstIncidentUndispatched As List(Of IncidentRegister) = lstIncidentAll.FindAll(Function(x) x.IncidentStatus = CInt(IMSEnums.IncidentStatus.Undispatched))

        Dim lstIncidentResolved As List(Of IncidentRegister) = lstIncidentAll.FindAll(Function(x) x.IncidentStatus = CInt(IMSEnums.IncidentStatus.Resolved))
        Dim lstIncidentDispatchedandUnderDispathed As List(Of IncidentRegister) = lstIncidentAll.FindAll(Function(x) x.IncidentStatus = CInt(IMSEnums.IncidentStatus.Dispatched))
        Dim lstIncidentUnderDispatched As List(Of IncidentRegister) = CommonFunction.GetAllIncidentUnderDispatchedStationWise(StationID)
        Dim numberOfFullyDispatchedIncidents As Integer = lstIncidentDispatchedandUnderDispathed.Count - lstIncidentUnderDispatched.Count

        lblNewAssignedInstances.Text = lstIncidentUndispatched.Count

        lblUndispatchedIncidents.Text = lstIncidentUndispatched.Count
        lblUnderDispatchedIncidents.Text = lstIncidentUnderDispatched.Count
        lblDispatchedIncidents.Text = numberOfFullyDispatchedIncidents
        lblResolvedIncidents.Text = lstIncidentResolved.Count

        ShowResolvedIncidentStationWise(lstIncidentResolved)
        ShowAvailableVehicle(StationID)
        ShowAvailableEmployee(StationID)

    End Sub

    ''' <summary>
    ''' Method to Show Resolved Incidents in Grid.
    ''' </summary>
    ''' <param name="lstIncidentResolved"></param>
    ''' <remarks></remarks>
    Private Sub ShowResolvedIncidentStationWise(lstIncidentResolved As List(Of IncidentRegister))

        Dim dtResolvedIncident As DataTable = GetResolvedIncidentTable(lstIncidentResolved)

        With grvResolvedIncidents
            .DataSource = dtResolvedIncident
            .DataBind()
            'Text center
            .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

    End Sub

    ''' <summary>
    ''' Method to Get Resolved Incident list to table mapped
    ''' </summary>
    ''' <param name="lstIncidentResolved"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetResolvedIncidentTable(lstIncidentResolved As List(Of IncidentRegister)) As DataTable

        Dim dtResolvedIncident As New DataTable
        Dim firstDipatcherTime As DateTime
        Dim lstOccurenceBook As New List(Of OccurrenceBook)
        Dim sql As String = String.Empty

        dtResolvedIncident.Columns.Add(IMSConstants.GridHeader.ReferenceNo, GetType(String))
        dtResolvedIncident.Columns.Add(IMSConstants.GridHeader.DispatchedTime, GetType(String))
        dtResolvedIncident.Columns.Add(IMSConstants.GridHeader.ResolvedTime, GetType(String))

        If lstIncidentResolved.Count > 0 Then

            For Each obj As IncidentRegister In lstIncidentResolved
                Dim row As DataRow = dtResolvedIncident.NewRow

                With obj
                    row(IMSConstants.GridHeader.ReferenceNo) = .ReferenceNo

                    'Get first dispatch from "Dispatched log"
                    firstDipatcherTime = CommonFunction.GetFirstDispatchTime(obj.IncidentID)

                    If Convert.ToDateTime("1/1/0001") = firstDipatcherTime Then
                        row(IMSConstants.GridHeader.DispatchedTime) = String.Empty
                    Else
                        row(IMSConstants.GridHeader.DispatchedTime) = firstDipatcherTime
                    End If

                    'Get Resolve time
                    sql = IMSConstants.FieldConstants.IncidentID & " = " & obj.IncidentID
                    lstOccurenceBook = _proxy.GetFilteredOccurrenceBook(sql).Cast(Of OccurrenceBook).ToList()
                    If lstOccurenceBook.Count > 0 Then
                        row(IMSConstants.GridHeader.ResolvedTime) = lstOccurenceBook(0).TimeOfUnderControl.ToString("dd/MM/yyyy HH:mm:ss")
                    Else
                        row(IMSConstants.GridHeader.ResolvedTime) = String.Empty
                    End If

                End With

                dtResolvedIncident.Rows.Add(row)
            Next

        End If

        Return dtResolvedIncident

    End Function

    ''' <summary>
    ''' Method to Show available vehicle in grid.
    ''' </summary>
    ''' <param name="StationID"></param>
    ''' <remarks></remarks>
    Private Sub ShowAvailableVehicle(StationID As Integer)

        Dim _proxy As New IMSService.IMSServices
        Dim dtAppliance As DataTable = CreateApplianceTable()
        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = CommonFunction.GetAllCheckedInApplianceStationWise(StationID)
        Dim lstCheckedInApplianceFiltered As List(Of FireStationAppliance)
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " <> " & CInt(IMSEnums.IsDeleted.Yes)
        Dim lstAppliance As List(Of Appliance) = _proxy.GetFilteredAppliance(sql).Cast(Of Appliance).ToList()
        Dim row As DataRow

        If lstAppliance.Count > 0 Then

            For Each obj As Appliance In lstAppliance

                row = dtAppliance.NewRow
                row(IMSConstants.GridHeader.VehicleCode) = obj.ApplianceCode
                lstCheckedInApplianceFiltered = lstCheckedInAppliance.FindAll(Function(x) x.ApplianceID = obj.ApplianceID)
                row(IMSConstants.GridHeader.AvailableQuantity) = lstCheckedInApplianceFiltered.Count.ToString("00")

                dtAppliance.Rows.Add(row)
            Next

            With grvAvailableVehicles
                .DataSource = dtAppliance
                .DataBind()
                'Text center
                .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
                .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
                .DisplayLayout.Override.ActiveCellAppearance.Reset()
                .DisplayLayout.Override.ActiveRowAppearance.Reset()
            End With

        End If

    End Sub

    ''' <summary>
    ''' Method to Get Appliance table created blank.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateApplianceTable() As DataTable

        Dim dtAppliance As New DataTable
        dtAppliance.Columns.Add(IMSConstants.GridHeader.VehicleCode, GetType(String))
        dtAppliance.Columns.Add(IMSConstants.GridHeader.AvailableQuantity, GetType(String))

        Return dtAppliance

    End Function

    ''' <summary>
    ''' Method to show available employee names in grid.
    ''' </summary>
    ''' <param name="StationID"></param>
    ''' <remarks></remarks>
    Private Sub ShowAvailableEmployee(StationID As Integer)

        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim shiftId As Integer = CommonFunction.GetShiftIDByStationIDAndTime(StationID, currentTime)
        Dim lstAvailableEmployee As List(Of Employee) = CommonFunction.GetAllCheckedInEmployeeStationAndShiftWise(StationID, shiftId)       '' shift ID get here.

        Dim dtEmployee As New DataTable
        dtEmployee.Columns.Add(IMSConstants.GridHeader.EmployeeName, GetType(String))

        If lstAvailableEmployee.Count > 0 Then

            For Each obj As Employee In lstAvailableEmployee
                Dim row As DataRow = dtEmployee.NewRow
                row(IMSConstants.GridHeader.EmployeeName) = obj.EmployeeName
                dtEmployee.Rows.Add(row)
            Next

        Else

            Dim row As DataRow = dtEmployee.NewRow
            row(IMSConstants.GridHeader.EmployeeName) = String.Empty
            dtEmployee.Rows.Add(row)

        End If

        With grvAvailableEmployees
            .DataSource = dtEmployee
            .DataBind()
            'Text center
            .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

    End Sub

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmStationDashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            LoadForm()
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
    Private Sub blinker_Tick(sender As Object, e As EventArgs) Handles blinker.Tick

        If IsRed Then
            pnlNewIncident.ForeColor = Color.Red
            IsRed = False
        Else
            pnlNewIncident.ForeColor = Color.Black
            IsRed = True
        End If

        secondCounter += 1

        If secondCounter > 100 Then
            LoadForm()
        End If

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnDispatch_Click(sender As Object, e As EventArgs) Handles btnDispatch.Click
        Try

            Dim tabForm As New frmIncidentRegister()
            Me.CallObject(tabForm)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

#Region "Interface Implementation"

    Private Function CheckObjects(ByVal ObjName As String) As Boolean Implements IMainForm.CheckObjects
        Dim BolFlag As Boolean
        'Dim obj As Form
        Dim i As Int16
        Try
            For i = 0 To IMS.Win.frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs.Count - 1
                If IMS.Win.frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Name = ObjName Then
                    BolFlag = True
                    IMS.Win.frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Activate()

                End If
            Next
        Catch ex As Exception
            BolFlag = False
        End Try

        Return BolFlag
    End Function

    Private Sub CallObject(ByVal Obj As Form) Implements IMainForm.CallObject
        If Not CheckObjects(Obj.Name) Then
            Obj.MdiParent = IMS.Win.frmMain ' Me.Parent
            Obj.AutoScrollMinSize = Obj.Size
            Obj.Show()
            Obj.AutoScroll = True
        End If
    End Sub

    Public Sub InitializeMain() Implements IMainForm.InitializeMain
        ' No need to implement here.
    End Sub

    Public Sub OnBeforeFormClosing(e As FormClosingEventArgs) Implements IMainForm.OnBeforeFormClosing
        '' No need to implement here.
    End Sub

#End Region

End Class