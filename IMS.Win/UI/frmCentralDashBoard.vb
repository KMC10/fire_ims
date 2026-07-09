'Author                : Md. khairuz-Zaman Ronny.
'Crated Date           : 16/5/2014
'Last Modified by      : Jafar Ulla
'Last Modifiation Date : 5/6/2014
'(C) CopyRight Nybsys.

Imports Infragistics.Win.UltraWinGrid
Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win
Imports System.Globalization

Public Class frmCentralDashBoard
    Inherits BaseForm


#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private secondCounter As Integer = 0
    Private _lstApplience As List(Of Appliance) = New List(Of Appliance)
    Private _lstStation As List(Of FireStation) = New List(Of FireStation)
    Private _lstEmployee As List(Of Employee) = New List(Of Employee)

#End Region

#Region "User Defined Functions"

    ''' <summary>
    ''' Method to Load System Dash Board.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadForm()

        Dim tblCurretntIncident As DataTable = CreateIncidentTable()
        Dim tblUndispatched As DataTable = CreateIncidentTable()
        Dim tblUnderDispatched As DataTable = CreateIncidentTable()
        Dim tblResolved As DataTable = CreateIncidentTable()

        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No)
        Dim lstFireStation As List(Of FireStation) = _proxy.GetFilteredFireStation(sql).Cast(Of FireStation).ToList()

        If lstFireStation.Count > 0 Then
            For Each objFireStation As FireStation In lstFireStation

                Dim lstIncidentUndispatched As List(Of IncidentRegister)
                Dim lstIncidentResolved As List(Of IncidentRegister)
                Dim lstIncidentDispatchedandUnderDispathed As List(Of IncidentRegister)
                Dim lstIncidentUnderDispatched As List(Of IncidentRegister)

                Dim numberOfFullyDispatchedIncidents As Integer
                Dim rowCurretntIncident As DataRow = tblCurretntIncident.NewRow
                Dim rowUndispatched As DataRow = tblUndispatched.NewRow
                Dim rowUnderDispatched As DataRow = tblUnderDispatched.NewRow
                Dim rowResolved As DataRow = tblResolved.NewRow

                Dim lstIncidentAll As List(Of IncidentRegister) = CommonFunction.GetAllIncidentOfSpeficStation(objFireStation.StationID)

                lstIncidentUndispatched = lstIncidentAll.FindAll(Function(x) x.IncidentStatus = CInt(IMSEnums.IncidentStatus.Undispatched))
                lstIncidentResolved = lstIncidentAll.FindAll(Function(x) x.IncidentStatus = CInt(IMSEnums.IncidentStatus.Resolved))
                lstIncidentDispatchedandUnderDispathed = lstIncidentAll.FindAll(Function(x) x.IncidentStatus = CInt(IMSEnums.IncidentStatus.Dispatched))
                lstIncidentUnderDispatched = CommonFunction.GetAllIncidentUnderDispatchedStationWise(objFireStation.StationID)
                numberOfFullyDispatchedIncidents = lstIncidentDispatchedandUnderDispathed.Count - lstIncidentUnderDispatched.Count

                rowCurretntIncident(IMSConstants.GridHeader.StationName) = objFireStation.StationName
                rowCurretntIncident(IMSConstants.GridHeader.Incident) = lstIncidentAll.Count
                tblCurretntIncident.Rows.Add(rowCurretntIncident)

                rowUndispatched(IMSConstants.GridHeader.StationName) = objFireStation.StationName
                rowUndispatched(IMSConstants.GridHeader.Incident) = lstIncidentUndispatched.Count
                tblUndispatched.Rows.Add(rowUndispatched)

                rowUnderDispatched(IMSConstants.GridHeader.StationName) = objFireStation.StationName
                rowUnderDispatched(IMSConstants.GridHeader.Incident) = lstIncidentUnderDispatched.Count
                tblUnderDispatched.Rows.Add(rowUnderDispatched)

                rowResolved(IMSConstants.GridHeader.StationName) = objFireStation.StationName
                rowResolved(IMSConstants.GridHeader.Incident) = lstIncidentResolved.Count
                tblResolved.Rows.Add(rowResolved)

            Next

        End If

        grvCurrentIncidents.DataSource = tblCurretntIncident
        gvUnDispatchIncidents.DataSource = tblUndispatched
        gvUnderDispatchedIncidents.DataSource = tblUnderDispatched
        gvResolvedIncidents.DataSource = tblResolved

    End Sub

    ''' <summary>
    ''' Method to create blank table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateIncidentTable() As DataTable

        Dim dtAppliance As New DataTable
        dtAppliance.Columns.Add(IMSConstants.GridHeader.StationName, GetType(String))
        dtAppliance.Columns.Add(IMSConstants.GridHeader.Incident, GetType(String))

        Return dtAppliance

    End Function

    Private Sub PopulateApplianceAndStationList()

        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No
        _lstApplience = _proxy.GetFilteredAppliance(strSQL).Cast(Of Appliance).ToList()
        _lstStation = _proxy.GetFilteredFireStation(strSQL).Cast(Of FireStation).ToList()
        _lstEmployee = _proxy.GetFilteredEmployee(strSQL).Cast(Of Employee).ToList()
    End Sub

    Private Sub LoadVehicles()

        Dim lstCheckedInAppliance As List(Of FireStationAppliance)
        Dim lstCheckedInApplianceFiltered As List(Of FireStationAppliance)

        Dim dtVehicles As New DataTable
        Dim lstAvailableVehicle As New List(Of Appliance)
        dtVehicles.Columns.Add(IMSConstants.GridHeader.StationName, GetType(String))
        For Each objApplience As Appliance In _lstApplience

            dtVehicles.Columns.Add(objApplience.ApplianceName, GetType(String))

        Next

        Dim row As DataRow

        For Each objStation As FireStation In _lstStation
            'Dim lstVailableApplience As List(Of Appliance) = 
            row = dtVehicles.NewRow
            row(IMSConstants.GridHeader.StationName) = objStation.StationName
            lstCheckedInAppliance = CommonFunction.GetAllCheckedInApplianceStationWise(objStation.StationID)

            For Each objAppliance As Appliance In _lstApplience
                lstCheckedInApplianceFiltered = lstCheckedInAppliance.FindAll(Function(x) x.ApplianceID = objAppliance.ApplianceID)
                row(objAppliance.ApplianceName) = lstCheckedInApplianceFiltered.Count
            Next

            dtVehicles.Rows.Add(row)
        Next

        gvVehicle.DataSource = dtVehicles
        gvVehicle.DataBind()

    End Sub

    Private Function GetAvailableVehicleByStationID(StationID As Integer) As List(Of Appliance)

        Dim _proxy As New IMSService.IMSServices
        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = CommonFunction.GetAllCheckedInApplianceStationWise(StationID)
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " <> " & CInt(IMSEnums.IsDeleted.Yes)
        Dim lstAppliance As List(Of Appliance) = _proxy.GetFilteredAppliance(sql).Cast(Of Appliance).ToList()

        Return lstAppliance

    End Function

    Private Sub LoadEmployee()

        Dim counter As Integer = 0
        Dim shiftId As Integer = -1
        Dim lstCheckedInEmployee As List(Of Employee)
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim row As DataRow
        Dim CurrentColumnCounter As Integer = 0
        Dim rowMaxCounter As Integer = 0

        Dim dtEmployee As New DataTable
        Dim lstAvailableVehicle As New List(Of Appliance)

        For Each objStation As FireStation In _lstStation

            dtEmployee.Columns.Add(objStation.StationName, GetType(String))

            shiftId = CommonFunction.GetShiftIDByStationIDAndTime(objStation.StationID, currentTime)

            lstCheckedInEmployee = CommonFunction.GetAllCheckedInEmployeeStationAndShiftWise(objStation.StationID, shiftId)

            For j = 0 To lstCheckedInEmployee.Count - 1

                If CurrentColumnCounter > 0 Then

                    If j + 1 > rowMaxCounter Then

                        rowMaxCounter = j + 1
                        row = dtEmployee.NewRow
                        row(objStation.StationName) = lstCheckedInEmployee(j).EmployeeName
                        dtEmployee.Rows.Add(row)
                    Else
                        dtEmployee.Rows(j)(objStation.StationName) = lstCheckedInEmployee(j).EmployeeName

                    End If

                Else
                    row = dtEmployee.NewRow
                    row(objStation.StationName) = lstCheckedInEmployee(j).EmployeeName
                    dtEmployee.Rows.Add(row)
                End If

            Next

            If lstCheckedInEmployee.Count > rowMaxCounter Then
                rowMaxCounter = lstCheckedInEmployee.Count
            End If
            CurrentColumnCounter = CurrentColumnCounter + 1

        Next

        gvEmployee.DataSource = dtEmployee
        gvEmployee.DataBind()

        'For Each a As UltraGridColumn In gvEmployee.DisplayLayout.Bands(0).Columns
        '    a.Header.Caption = " "

        'Next

        ' gvEmployee.DisplayLayout.Bands(0).Columns().Hea = True
    End Sub

    'Private Sub LoadEmployee()

    '    Dim counter As Integer = 0
    '    Dim shiftId As Integer = -1
    '    Dim lstCheckedInEmployee As List(Of Employee)
    '    Dim currentTime As TimeSpan = Now.TimeOfDay()

    '    Dim dtEmployee As New DataTable
    '    Dim lstAvailableVehicle As New List(Of Appliance)

    '    dtEmployee.Columns.Add(IMSConstants.GridHeader.StationName, GetType(String))
    '    'dtEmployee.Columns.Add(IMSConstants.GridHeader.StationName, GetType(String))
    '    For Each objStation As FireStation In _lstStation


    '        shiftId = CommonFunction.GetShiftIDByStationIDAndTime(objStation.StationID, currentTime)
    '        lstCheckedInEmployee = CommonFunction.GetAllCheckedInEmployeeStationAndShiftWise(objStation.StationID, shiftId)
    '        counter = Math.Max(lstCheckedInEmployee.Count, counter)
    '    Next

    '    For i = 1 To counter
    '        dtEmployee.Columns.Add(i, GetType(String))
    '    Next

    '    For Each objStation As FireStation In _lstStation

    '        Dim row As DataRow = dtEmployee.NewRow
    '        shiftId = CommonFunction.GetShiftIDByStationIDAndTime(objStation.StationID, currentTime)

    '        lstCheckedInEmployee = CommonFunction.GetAllCheckedInEmployeeStationAndShiftWise(objStation.StationID, shiftId)
    '        row(IMSConstants.GridHeader.StationName) = objStation.StationName

    '        For j = 0 To lstCheckedInEmployee.Count - 1
    '            row(j + 1) = lstCheckedInEmployee(j).EmployeeName
    '        Next

    '        dtEmployee.Rows.Add(row)

    '    Next


    '    gvEmployee.DataSource = dtEmployee
    '    gvEmployee.DataBind()

    '    'gvEmployee.DisplayLayout.Rows(0).Hidden = True

    '    For Each a As UltraGridColumn In gvEmployee.DisplayLayout.Bands(0).Columns
    '        a.Header.Caption = " "

    '    Next

    '    ' gvEmployee.DisplayLayout.Bands(0).Columns().Hea = True
    'End Sub

    ''' <summary>
    ''' Method to Load this page.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadInitialPage()

        LoadForm()
        PopulateApplianceAndStationList()
        LoadVehicles()
        LoadEmployee()

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub DashBoard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            LoadInitialPage()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub tRefresh_Tick(sender As Object, e As EventArgs) Handles tRefresh.Tick

        secondCounter += 1

        If secondCounter > 100 Then
            LoadInitialPage()
        End If

    End Sub

#End Region

End Class