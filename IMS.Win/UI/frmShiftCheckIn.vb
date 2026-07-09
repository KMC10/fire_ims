'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 29-Apr-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports IMS.Win.IMSService


Public Class frmShiftCheckIn
    Inherits BaseForm

#Region "Member Variables"
    Private _proxy As New IMSService.IMSServices
#End Region

#Region "Constructor"

#End Region

#Region "Private Methods"

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


        With Me.cmbFireStation
            .DataSource = dtIncidentType
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

        With Me.cmbFireStationEmployee
            .DataSource = dtIncidentType
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Vehicle by station id.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub LoadVehicles(ByVal strStationID As String)

        Dim stationID As Integer = 0
        If Not String.IsNullOrEmpty(strStationID) Then
            stationID = CInt(strStationID)
        End If

        Dim dvAppliance As DataView
        Dim dtAppliance As New DataTable
        Dim filter As String = String.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'", IMSConstants.FieldConstants.StationID, stationID, IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnum.IMSEnums.RegisterStatus.CheckedIn), IMSConstants.FieldConstants.IsCurrent, 1)

        dtAppliance.Columns.Add(IMSConstants.FieldConstants.ApplianceID, GetType(Integer))
        dtAppliance.Columns.Add(IMSConstants.GridHeader.Code, GetType(String))
        dtAppliance.Columns.Add(IMSConstants.GridHeader.Serialno, GetType(String))

        For Each obj As IMSService.ApplianceRegister In _proxy.GetFilteredApplianceRegister(filter).Cast(Of IMSService.ApplianceRegister).ToList()

            Dim serialNumber As String = String.Empty
            Dim applienceCode As String = String.Empty
            Dim row As DataRow = dtAppliance.NewRow

            If Me.GetApplienceCodeByAssignedApplienceID(obj.StationApplianceID, applienceCode, serialNumber) Then
                row(IMSConstants.FieldConstants.ApplianceID) = obj.ApplianceRegisterID
                row(IMSConstants.GridHeader.Code) = applienceCode
                row(IMSConstants.GridHeader.Serialno) = serialNumber

                dtAppliance.Rows.Add(row)
            End If

        Next

        If dtAppliance.Rows.Count > 0 Then
            dvAppliance = New DataView(dtAppliance)
            dvAppliance.Sort = IMSConstants.GridHeader.Serialno & " ASC"
            dtAppliance = dvAppliance.ToTable()
        End If

        With Me.grvVehicles
            .DataSource = dtAppliance
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Method to get applience code By AssignedApplienceID
    ''' </summary>
    ''' <param name="applienceID"></param>
    ''' <param name="applienceCode"></param>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetApplienceCodeByAssignedApplienceID(ByVal applienceID As Integer, ByRef applienceCode As String, ByRef serialNumber As String) As Boolean

        Dim result As Boolean = False
        Dim objFireStationAppliance As IMSService.FireStationAppliance = _proxy.GetFireStationApplianceByID(applienceID)
        Dim fireStationApplienceID As Integer = -1

        If Not IsNothing(objFireStationAppliance) Then
            fireStationApplienceID = objFireStationAppliance.StationApplianceID

        End If

        If Not IsNothing(objFireStationAppliance) Then
            serialNumber = objFireStationAppliance.SerialNumber

            Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(objFireStationAppliance.ApplianceID)

            If Not IsNothing(objApplience) Then

                applienceCode = objApplience.ApplianceCode

                result = True

            End If

        End If

        Return result

    End Function

    ''' <summary>
    ''' Method to Load employee by StationId.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub LoadEmployee(ByVal stationID As Integer)

        Dim dtEmployee As New DataTable

        dtEmployee.Columns.Add(IMSConstants.FieldConstants.EmployeeRegisterID, GetType(Integer))
        dtEmployee.Columns.Add(IMSConstants.GridHeader.Code, GetType(String))
        dtEmployee.Columns.Add(IMSConstants.GridHeader.EmployeeName, GetType(String))

        'Dim dvEmployee As DataView
        'Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}' AND {4} Between '{5}' And '{6}' And {7} = '{8}'", IMSConstants.FieldConstants.StationID, stationID, IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnum.IMSEnums.RegisterStatus.CheckedIn), IMSConstants.FieldConstants.InsertionDate, GetFromDate(Now), GetToDate(Now), IMSConstants.FieldConstants.IsCurrent, 1)

        'For Each obj As IMSService.EmployeeRegister In _proxy.GetFilteredEmployeeRegister(filter).Cast(Of IMSService.EmployeeRegister).ToList()

        '    Dim objEmployee As IMSService.Employee = _proxy.GetEmployeeByID(obj.EmployeeID)
        '    If Not IsNothing(objEmployee) Then

        '        Dim row As DataRow = dtEmployee.NewRow
        '        row(IMSConstants.FieldConstants.EmployeeRegisterID) = obj.EmployeeRegisterID
        '        row(IMSConstants.GridHeader.Code) = objEmployee.EmployeeCode
        '        row(IMSConstants.GridHeader.EmployeeName) = objEmployee.EmployeeName
        '        dtEmployee.Rows.Add(row)
        '    End If

        'Next

        'If dtEmployee.Rows.Count > 0 Then
        '    dvEmployee = New DataView(dtEmployee)
        '    dvEmployee.Sort = IMSConstants.GridHeader.EmployeeName & " ASC"
        '    dtEmployee = dvEmployee.ToTable()
        'End If

        Dim row As DataRow

        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim shiftId As Integer = CommonFunction.GetShiftIDByStationIDAndTime(stationID, currentTime)
        Dim lstAvailableEmployee As List(Of Employee) = CommonFunction.GetAllCheckedInEmployeeStationAndShiftWise(stationID, shiftId)

        If lstAvailableEmployee.Count > 0 Then
            For Each objEmployee As Employee In lstAvailableEmployee

                row = dtEmployee.NewRow
                row(IMSConstants.FieldConstants.EmployeeRegisterID) = 0
                row(IMSConstants.GridHeader.Code) = objEmployee.EmployeeCode
                row(IMSConstants.GridHeader.EmployeeName) = objEmployee.EmployeeName
                dtEmployee.Rows.Add(row)

            Next
        End If

        With Me.grvEmoloyee
            .DataSource = dtEmployee
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

    End Sub

    ''' <summary>
    ''' Method to ApplienceCode By AssignedApplienceID
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub GetApplienceCodeByAssignedApplienceID(stationID As Integer)
        Me.cmbFireStationEmployee.Value = stationID
        Me.LoadEmployee(stationID)
    End Sub

    ''' <summary>
    ''' Method to Load ApplianceRegister By StationID
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub LoadApplianceRegisterByStation(stationID As Integer)
        Me.cmbFireStation.Value = stationID
        Me.LoadVehicles(stationID.ToString())
    End Sub

    ''' <summary>
    ''' Method to Load Shift By stationID
    ''' </summary>
    ''' <param name="stationId"></param>
    ''' <remarks></remarks>
    Private Sub LoadShift(stationId As Integer)

        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim shiftID As Integer = CommonFunction.GetShiftIDByStationIDAndTime(stationId, currentTime)
        If shiftID > 0 Then
            Dim objShift As IMSService.Shift = _proxy.GetShiftByID(shiftID)
            If Not IsNothing(objShift) Then
                lblCurrentShift.Text = objShift.ShiftName
            Else
                lblCurrentShift.Text = IMSConstants.Common.N_A
            End If
        Else
            lblCurrentShift.Text = IMSConstants.Common.N_A
        End If
    End Sub

    ''' <summary>
    ''' Method to Load Employee after event fired
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub LoadEmployeeByStation(stationID As Integer)
        Me.LoadEmployee(stationID)
        Me.cmbFireStationEmployee.Value = stationID
    End Sub

    Private Sub LoadEmployeeAndVehicleByStation(stationIDEmployee As Integer, stationIDVehicle As Integer)
        Me.LoadEmployee(stationIDEmployee)
        Me.cmbFireStationEmployee.Value = stationIDEmployee

        Me.cmbFireStation.Value = stationIDVehicle
        Me.LoadVehicles(stationIDVehicle.ToString())
    End Sub

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
    '    End If

    'End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmShiftCheckIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            Me.LoadFireStation()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnVehicleCheckIn_Click(sender As Object, e As EventArgs) Handles btnVehicleCheckIn.Click
        Try

            Dim frm As frmVehicleCheckInOut = New frmVehicleCheckInOut(True)
            AddHandler frm.LoadApplianceRegisterByStation, AddressOf LoadApplianceRegisterByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

    Private Sub btnVehicleCheckOut_Click(sender As Object, e As EventArgs) Handles btnVehicleCheckOut.Click
        Try

            Dim frm As frmVehicleCheckInOut = New frmVehicleCheckInOut(False)
            AddHandler frm.LoadApplianceRegisterByStation, AddressOf LoadApplianceRegisterByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

    Private Sub btnEmployeeCheckIn_Click(sender As Object, e As EventArgs) Handles btnEmployeeCheckIn.Click
        Try

            Dim frm As frmEmployeeCheckInOut = New frmEmployeeCheckInOut(True)
            AddHandler frm.LoadEmployeeByStation, AddressOf LoadEmployeeByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

    Private Sub btnEmployeeCheckOut_Click(sender As Object, e As EventArgs) Handles btnEmployeeCheckOut.Click
        Try

            Dim frm As frmEmployeeCheckInOut = New frmEmployeeCheckInOut(False)
            AddHandler frm.LoadEmployeeByStation, AddressOf LoadEmployeeByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

    Private Sub cmbFireStation_SelectionChanged(sender As Object, e As EventArgs) Handles cmbFireStation.SelectionChanged
        Try
            LoadVehicles(cmbFireStation.Value)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmbFireStationEmployee_SelectionChanged(sender As Object, e As EventArgs) Handles cmbFireStationEmployee.SelectionChanged
        Try
            Dim stationID As Integer = 0

            If Not String.IsNullOrEmpty(cmbFireStationEmployee.Text) Then
                stationID = cmbFireStationEmployee.Value
            End If
            Me.LoadShift(stationID)
            Me.LoadEmployee(stationID)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBulkCheckIn_Click(sender As Object, e As EventArgs) Handles btnBulkCheckIn.Click
        Try

            Dim frm As frmBulkCheckInOut = New frmBulkCheckInOut(True)
            AddHandler frm.LoadEmployeeByStation, AddressOf LoadEmployeeByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

    Private Sub btnBulkCheckOut_Click(sender As Object, e As EventArgs) Handles btnBulkCheckOut.Click
        Try

            Dim frm As frmBulkCheckInOut = New frmBulkCheckInOut(False)
            AddHandler frm.LoadEmployeeByStation, AddressOf LoadEmployeeByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

    Private Sub btnIncidentCheckIn_Click(sender As Object, e As EventArgs) Handles btnIncidentCheckIn.Click
        Try

            Dim frm As frmIncidentCheckIn = New frmIncidentCheckIn()
            AddHandler frm.LoadByStation, AddressOf LoadEmployeeAndVehicleByStation
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)

        End Try
    End Sub

#End Region

End Class