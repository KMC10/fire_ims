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

Public Class frmDispatchVehicles
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private incidentID As Integer ' = 34
    Private referenceNo As String
    Private lstAvailableAppliance As New List(Of FireStationAppliance)
    Private lstCheckedInEmployee As New List(Of Employee)
    Private selectedTypeID As Integer = 0
    Private selectedShiftID As Integer = 1

    Private applianceID As Integer = 0
    Private vehicleCode As String = String.Empty
    Private requiredQuantity As Integer = 0

    Private lstApplianceMappedForIncident As New List(Of Integer) ''The list of Appliance Already Mapped for a specific Incident.

    'For Current Dispatch List
    Dim assignedApplianceID As Integer
    Dim gridCellIndex As Integer

    Private lstCmbVehicle As New List(Of String)


#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal intIncidentID As Integer, ByVal referenceNumber As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        incidentID = intIncidentID
        referenceNo = referenceNumber

    End Sub

#End Region

#Region "Event"

    Public Event LoadDispatchVehicleForm()

#End Region

#Region "User Defined Methods"

#Region "Common"

    ''' <summary>
    ''' Load all the Three Grids (Load whole page initially)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadAllThreePanels()

        LoadApplianceForSpecificIncidentType()
        HideSomeColumnGridDispatchVehicle()
        LoadCurrentDispatchList()
        LoadDispatchLog(incidentID)

    End Sub

#End Region

#Region "Dispatch Vehicle"


    ''' <summary>
    ''' Method to Load Appliance (Specific Incident Type)
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadApplianceForSpecificIncidentType()
        'Working Tables (Incidenttype, Appliance Mapping, Appliance)

        Dim dtVehicleForSpecificIncident As DataTable = GetVehicleForSpecificIncident()

        'If dtVehicleForSpecificIncident.Rows.Count > 0 Then

        With Me.grvApplianceForIncident
            .DataSource = dtVehicleForSpecificIncident
            .DataBind()
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Hidden = True
            .DisplayLayout.Bands(0).Columns(2).Hidden = True

            .DisplayLayout.Bands(0).Columns(7).Hidden = True
            .DisplayLayout.Bands(0).Columns(8).Hidden = True

            'text
            .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center

            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

        'End If

    End Sub

    ''' <summary>
    ''' Method to Create empty Vehicle For Incident.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateTableVehicleForIncident() As DataTable

        Dim dtVehicleForIncident As New DataTable

        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.MappingID, GetType(Integer))
        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.IncidentTypeID, GetType(Integer))
        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.ApplianceID, GetType(Integer))
        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.VehicleCode, GetType(String))
        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.VehicleName, GetType(String))
        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.RequiredQuantity, GetType(String))
        dtVehicleForIncident.Columns.Add(IMSConstants.FieldConstants.DispatchedQuantity, GetType(Integer))

        dtVehicleForIncident.Columns.Add(IMSConstants.Common.TypeID, GetType(Integer))
        dtVehicleForIncident.Columns.Add(IMSConstants.Common.Previous, GetType(String))

        Return dtVehicleForIncident

    End Function

    '    select * from AssignedAppliance
    'where IncidentID = 34 and StationApplianceID In (Select StationApplianceID from FireStationAppliance where ApplianceID = 13 )

    ''' <summary>
    ''' Mehtod to (Other vehicle) Create Table to show in Grid
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetOtherAssignedApplianceTable() As DataTable

        Dim dtVehicleForIncident As DataTable = CreateTableVehicleForIncident()
        Dim row As DataRow
        Dim appliance As New Appliance
        Dim stationAppliance As New FireStationAppliance
        Dim lstApplianceID As New List(Of Integer)

        '' Get Others Assigned Appliances for this INCIDENT
        Dim sql1 As String = IMSConstants.FieldConstants.IsDeleted & " <> " & CInt(IMSEnums.IsDeleted.Yes) & " and " & IMSConstants.FieldConstants.IncidentTypeID & " = 0 and " & IMSConstants.FieldConstants.IncidentID & " = " & incidentID.ToString()
        Dim lstAssignedApplianceOthers As List(Of AssignedAppliance) = _proxy.GetFilteredAssignedAppliance(sql1).Cast(Of AssignedAppliance).ToList()

        For Each obj As AssignedAppliance In lstAssignedApplianceOthers

            'Get Station Appliance
            stationAppliance = _proxy.GetFireStationApplianceByID(obj.StationApplianceID)

            If Not (lstApplianceID.Contains(stationAppliance.ApplianceID)) Then

                lstApplianceID.Add(stationAppliance.ApplianceID)

                If Not IsNothing(stationAppliance) Then

                    With obj
                        row = dtVehicleForIncident.NewRow
                        row(IMSConstants.FieldConstants.MappingID) = 0
                        row(IMSConstants.FieldConstants.IncidentTypeID) = 0

                        ''Get Station Appliance
                        'stationAppliance = _proxy.GetFireStationApplianceByID(.StationApplianceID)
                        'If Not IsNothing(stationAppliance) Then

                        'Get appliance descripton
                        appliance = _proxy.GetApplianceByID(stationAppliance.ApplianceID)
                        If Not IsNothing(appliance) Then
                            With appliance
                                row(IMSConstants.FieldConstants.ApplianceID) = .ApplianceID
                                row(IMSConstants.FieldConstants.VehicleCode) = .ApplianceCode
                                row(IMSConstants.FieldConstants.VehicleName) = .ApplianceName
                            End With
                        End If

                        row(IMSConstants.FieldConstants.RequiredQuantity) = String.Empty
                        row(IMSConstants.FieldConstants.DispatchedQuantity) = CommonFunction.GetDispatchedApplianceQuantityForThisIncident(incidentID, appliance.ApplianceID, 0)
                        row(IMSConstants.Common.TypeID) = 0
                        row(IMSConstants.Common.Previous) = "Yes"
                    End With

                    dtVehicleForIncident.Rows.Add(row)

                End If
            End If
        Next

        Return dtVehicleForIncident

    End Function

    ''' <summary>
    ''' Method to Get Vehicle Lists for Specific Incident
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetVehicleForSpecificIncident() As DataTable

        Dim dtMappedVehicleForSpecificIncident As DataTable = GetMappedAssignedApplianceTable()
        Dim dtOthersVehicleForSpecificIncident As DataTable = GetOtherAssignedApplianceTable()

        dtMappedVehicleForSpecificIncident.Merge(dtOthersVehicleForSpecificIncident)

        Return dtMappedVehicleForSpecificIncident

    End Function

    ''' <summary>
    ''' Method to get Mapped with Type - Assigned Appliance Table for Grid
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMappedAssignedApplianceTable() As DataTable

        Dim incidentTypeID As Integer = 0
        Dim lstApplianceMapping As New List(Of ApplianceMapping)
        Dim lstApplianceMappingForTypes As New List(Of ApplianceMapping)
        Dim objAppliance As New Appliance
        Dim sql As String
        Dim lstincidentTypeIncident As New List(Of IncidentTypeIncident)

        'Create table for Grid
        Dim dtVehicleForSpecificIncident As DataTable = CreateTableVehicleForIncident()

        ''Get Incident Type ID to show the Needed appliances for the specific incident type.
        'Dim objIncidentRegister As IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)

        ''Get all types
        sql = String.Format("{0} = {1}", IMSConstants.FieldConstants.IncidentID, incidentID)
        lstincidentTypeIncident = _proxy.GetFilteredIncidentTypeIncident(sql).Cast(Of IncidentTypeIncident).ToList()

        If lstincidentTypeIncident.Count > 0 Then

            For Each obj As IncidentTypeIncident In lstincidentTypeIncident

                If obj.IncidentTypeID > 0 Then

                    incidentTypeID = obj.IncidentTypeID

                    sql = String.Format("{0}={1} and {2} <> {3}", IMSConstants.FieldConstants.IncidentTypeID, incidentTypeID, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Deleted))
                    'Get all the Appliances Mapping with This Incident Type (ID).
                    lstApplianceMapping = _proxy.GetFilteredApplianceMapping(sql).Cast(Of ApplianceMapping).ToList()

                    'Get Appliance Descriptions and others
                    If lstApplianceMapping.Count > 0 Then
                        lstApplianceMappingForTypes.AddRange(lstApplianceMapping)
                    End If
                End If
            Next
        End If


        ''Create Table

        For Each objApplianceMapping As ApplianceMapping In lstApplianceMappingForTypes

            Dim row As DataRow = dtVehicleForSpecificIncident.NewRow

            objAppliance = _proxy.GetApplianceByID(objApplianceMapping.ApplianceID)

            If Not IsNothing(objAppliance) Then
                If objAppliance.IsDeleted <> IMSEnums.Status.Deleted Then

                    row(IMSConstants.FieldConstants.MappingID) = objApplianceMapping.MappingID
                    row(IMSConstants.FieldConstants.IncidentTypeID) = objApplianceMapping.IncidentTypeID

                    If objAppliance.ApplianceID > 0 Then
                        row(IMSConstants.FieldConstants.ApplianceID) = objAppliance.ApplianceID

                        'Keep for further use (Appliance mapped for Incident)
                        If Not lstApplianceMappedForIncident.Contains(objAppliance.ApplianceID) Then
                            lstApplianceMappedForIncident.Add(objAppliance.ApplianceID)
                        End If

                    Else
                        row(IMSConstants.FieldConstants.ApplianceID) = 0
                    End If

                    If Not String.IsNullOrEmpty(objAppliance.ApplianceCode) Then
                        row(IMSConstants.FieldConstants.VehicleCode) = objAppliance.ApplianceCode
                    Else
                        row(IMSConstants.FieldConstants.VehicleCode) = String.Empty
                    End If

                    If Not String.IsNullOrEmpty(objAppliance.ApplianceName) Then
                        row(IMSConstants.FieldConstants.VehicleName) = objAppliance.ApplianceName
                    Else
                        row(IMSConstants.FieldConstants.VehicleName) = String.Empty
                    End If

                    If objApplianceMapping.Quantity > 0 Then
                        row(IMSConstants.FieldConstants.RequiredQuantity) = objApplianceMapping.Quantity
                    End If

                    'Get Dispatched quantity
                    Dim dispatchedQty As Integer = CommonFunction.GetDispatchedApplianceQuantityForThisIncident(incidentID, objAppliance.ApplianceID, objApplianceMapping.IncidentTypeID)
                    If dispatchedQty > 0 Then
                        row(IMSConstants.FieldConstants.DispatchedQuantity) = dispatchedQty
                    Else
                        row(IMSConstants.FieldConstants.DispatchedQuantity) = 0
                    End If

                    row(IMSConstants.Common.TypeID) = objApplianceMapping.IncidentTypeID
                    row(IMSConstants.Common.Previous) = "Yes"

                End If
            End If

            dtVehicleForSpecificIncident.Rows.Add(row)
        Next

        Return dtVehicleForSpecificIncident

    End Function

    ''' <summary>
    ''' Method to Stataion wise Appliance.
    ''' </summary>
    ''' <param name="applianceID"></param>
    ''' <remarks></remarks>
    Private Sub LoadStationWiseApplianceWithApplianceID(ByVal applianceID As Integer, ByVal vehicleCode As String, ByVal requiredQuantity As Integer)

        'Dim lstAvailableAppliance As New List(Of FireStationAppliance)

        Dim dtCheckedInVehicle As DataTable = CreateCheckedInVehicleBlankTable()
        Dim dtstationWiseVehicle As New DataTable

        lblVehicleCode.Text = vehicleCode
        If requiredQuantity >= 0 Then
            lblRequiredQuantity.Text = requiredQuantity
        Else
            lblRequiredQuantity.Text = IMSConstants.Common.N_A
        End If

        '' For Employee Combo
        Dim b As New Infragistics.Win.UltraWinEditors.DropDownEditorButton 'Dropdown Editor Button
        b.Control = Me.grvMultiSelectGrid 'The Multi Select "Combo" 
        Me.uteForEmployeeGrid.ButtonsRight.Clear()
        Me.uteForEmployeeGrid.ButtonsRight.Add(b) 'add the button to the editor control

        '(1) Get All Fire Stations
        Dim sql As String = String.Format("{0} <> {1}", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes))
        Dim lstFireStation As List(Of FireStation) = _proxy.GetFilteredFireStation(sql).Cast(Of FireStation).ToList()

        If lstFireStation.Count > 0 Then

            '(2) Get All available Appliance (Station Wise)
            ' lstAvailableAppliance = CommonFunction.GetAllCheckedInSpecificAppliance(applianceID) ' this function is not working now as resource is available at checked in station.
            dtCheckedInVehicle = CommonFunction.GetCheckedInVehicleTable(applianceID, dtCheckedInVehicle)

            '(3) Get Mapped with Table for Grid (All station vs Available station)
            dtstationWiseVehicle = GetMappedAllStation(lstFireStation, dtCheckedInVehicle)

            '(4) Load At Grid (On row bound bind the Vehicle dropdown)
            If dtstationWiseVehicle.Rows.Count > 0 Then

                'grvStationApplianceForDispatch.DataSource = dtstationWiseVehicle
                'grvStationApplianceForDispatch.DataBind()
                'Me.grvStationApplianceForDispatch.DisplayLayout.Override.ActiveRowAppearance.Reset()

                With Me.grvStationApplianceForDispatch
                    .DataSource = dtstationWiseVehicle
                    .DataBind()
                    .DisplayLayout.Bands(0).Columns(0).Hidden = True
                    .DisplayLayout.Bands(0).Columns(6).Hidden = True
                    .DisplayLayout.Bands(0).Columns(7).Hidden = True

                    .DisplayLayout.Bands(0).Columns(5).Style = UltraWinGrid.ColumnStyle.Button
                    .DisplayLayout.Bands(0).Columns(5).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
                    .DisplayLayout.Bands(0).Columns(5).Width = 80

                    .DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D

                    ''TODO : User Access Right of Grid buttons (dispatch)
                    If Not CommonFunction.IsSuperAdmin Then

                        'NOTE: below check is not need; as who has this form access will 
                        ' get all button access.

                        'Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Dispatch And x.FrontEndParentID = Me.Name).FirstOrDefault()
                        'If IsNothing(objSavePrivilig) Then
                        '    .DisplayLayout.Bands(0).Columns(5).Hidden = True
                        'End If

                    End If

                    'text
                    .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
                    .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center

                    .DisplayLayout.Override.ActiveCellAppearance.Reset()
                    .DisplayLayout.Override.ActiveRowAppearance.Reset()
                End With

                ''For Vehicle Combo
                Me.grvStationApplianceForDispatch.DisplayLayout.Bands(0).Columns(3).EditorComponent = cmbVehicle

                ''For Employee Combo
                Me.grvStationApplianceForDispatch.DisplayLayout.Bands(0).Columns(4).EditorComponent = Me.uteForEmployeeGrid
            End If

        End If

    End Sub

    ''' <summary>
    ''' Method to Create Empty Station Wise Vehicle List Table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateStationWiseVehicleBlankTable() As DataTable

        Dim dtStationWiseVehicle As New DataTable

        dtStationWiseVehicle.Columns.Add(IMSConstants.FieldConstants.StationID, GetType(Integer))
        dtStationWiseVehicle.Columns.Add(IMSConstants.FieldConstants.StationName, GetType(String))
        'dtStationWiseVehicle.Columns.Add(IMSConstants.FieldConstants.StationCode, GetType(String))
        dtStationWiseVehicle.Columns.Add(IMSConstants.FieldConstants.AvailableQuantity, GetType(Integer))

        dtStationWiseVehicle.Columns.Add(IMSConstants.Common.Vehicle, GetType(String))
        dtStationWiseVehicle.Columns.Add(IMSConstants.Common.Employee, GetType(String))
        dtStationWiseVehicle.Columns.Add(IMSConstants.Common.Action, GetType(String))
        dtStationWiseVehicle.Columns.Add(IMSConstants.Common.EmployeeIDs, GetType(String))
        dtStationWiseVehicle.Columns.Add(IMSConstants.Common.EmployeeDuplicate, GetType(String))

        Return dtStationWiseVehicle

    End Function

    'Private Sub LoadDataAtGrid(lstFireStation As List(Of FireStation), ByVal applianceID As Integer)

    '    Dim lstAvailableApplianceFiltered As New List(Of FireStationAppliance)
    '    Dim dtstationWiseVehicle As DataTable = CreateStationWiseVehicleTable()

    '    'Get Available Fire station Appliance (With Appliance ID)
    '    Dim sql As String = String.Format("[{0}] <> {1} and {2} = {3} and {4} Not In (select {4} from {5} where ({6} = {7} or {6} = {8}) and {9} <> 1)", _
    '                IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Deleted), IMSConstants.FieldConstants.ApplianceID, applianceID, _
    '                IMSConstants.FieldConstants.StationApplianceID, IMSConstants.TableNames.AssignedAppliance, _
    '                IMSConstants.FieldConstants.AssignedApplianceStatus, IMSEnums.ApplianceStatus.Dispatched, IMSEnums.ApplianceStatus.Redispatched, _
    '                IMSConstants.FieldConstants.IsDeleted, IMSEnums.IsDeleted.Yes)


    '    Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()



    '    'Dim row As DataRow

    '    'For Each objFireStation As FireStation In lstFireStation

    '    '    row = dtstationWiseVehicle.NewRow
    '    '    row(IMSConstants.FieldConstants.StationID) = objFireStation.StationID
    '    '    row(IMSConstants.FieldConstants.StationName) = objFireStation.StationName
    '    '    row(IMSConstants.FieldConstants.StationCode) = objFireStation.StationCode
    '    '    ' Get Available Appliance Qty for a Station
    '    '    lstAvailableApplianceFiltered = lstAvailableAppliance.FindAll(Function(x) x.StationID = objFireStation.StationID)
    '    '    row(IMSConstants.FieldConstants.AvailableQuantity) = lstAvailableApplianceFiltered.Count

    '    '    dtstationWiseVehicle.Rows.Add(row)

    '    'Next



    'End Sub

    ''' <summary>
    ''' Method to Get all avalable appliance (Station wise)
    ''' </summary>
    ''' <param name="applianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAllAvailableAppliance(applianceID As Integer) As List(Of FireStationAppliance)

        'Get Available Fire station Appliance (With Appliance ID)
        Dim sql As String = String.Format("[{0}] <> {1} and {2} = {3} and {4} Not In (select {4} from {5} where ({6} = {7} or {6} = {8}) and {9} <> 1)", _
                    IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Deleted), IMSConstants.FieldConstants.ApplianceID, applianceID, _
                    IMSConstants.FieldConstants.StationApplianceID, IMSConstants.TableNames.AssignedAppliance, _
                    IMSConstants.FieldConstants.AssignedApplianceStatus, CInt(IMSEnums.ApplianceStatus.Dispatched), CInt(IMSEnums.ApplianceStatus.Redispatched), _
                    IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes))


        Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        Return lstAvailableAppliance

    End Function

    ''' <summary>
    ''' (out of use)
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetAllCheckedInEmployee() As List(Of Employee)

        Dim sql As String = String.Format("IsDeleted <> 1 and EmployeeID In (select EmployeeID from EmployeeRegister where RegisterStatus = 1 and ShiftID = 1)")
        lstCheckedInEmployee = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()
        Return lstCheckedInEmployee

    End Function

    ''' <summary>
    ''' Method to Get checked IN Employee station and shift wise.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Private Function GetAllCheckedInEmployeeStationAndShiftWise(ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

    '    Dim sql As String = String.Format("{0} <> {1} and {2} In (select {2} from {3} where {4} = {5} and {6} = {7} and {8} = {9} and {10} = {11})", _
    '                                    IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
    '                                    , IMSConstants.FieldConstants.StationID, stationID, IMSConstants.FieldConstants.RegisterStatus, _
    '                                   CInt(IMSEnums.RegisterStatus.CheckedIn), IMSConstants.FieldConstants.ShiftID, shiftID, IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes))

    '    lstCheckedInEmployee = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

    '    Return lstCheckedInEmployee

    'End Function

    ''' <summary>
    ''' Method to Get All station with QTY of Available appliance
    ''' </summary>
    ''' <param name="lstFireStation"></param>
    ''' <param name="lstAvailableAppliance"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMappedAllStation(lstFireStation As List(Of FireStation), dtCheckedInVehicle As DataTable) As DataTable

        Dim dv As DataView
        Dim dt As DataTable
        Dim lstAvailableApplianceFiltered As New List(Of FireStationAppliance)
        Dim dtstationWiseVehicle As DataTable = CreateStationWiseVehicleBlankTable()
        Dim row As DataRow

        For Each objFireStation As FireStation In lstFireStation

            row = dtstationWiseVehicle.NewRow

            row(IMSConstants.FieldConstants.StationID) = objFireStation.StationID
            row(IMSConstants.FieldConstants.StationName) = objFireStation.StationName
            'row(IMSConstants.FieldConstants.StationCode) = objFireStation.StationCode
            ' Get Available Appliance Qty for a Station

            dv = New DataView(dtCheckedInVehicle)
            dv.RowFilter = "CheckedInStationID = " + objFireStation.StationID.ToString() ' IMSConstants.Common.CheckedInStationID + " = " + objFireStation.StationID
            dt = dv.ToTable()

            'lstAvailableApplianceFiltered = lstAvailableAppliance.FindAll(Function(x) x.StationID = objFireStation.StationID)
            row(IMSConstants.FieldConstants.AvailableQuantity) = dt.Rows.Count ' lstAvailableApplianceFiltered.Count

            'Take space
            row(IMSConstants.Common.Vehicle) = String.Empty
            row(IMSConstants.Common.Employee) = String.Empty
            row(IMSConstants.Common.Action) = IMSConstants.GridHeader.Dispatch
            row(IMSConstants.Common.EmployeeIDs) = String.Empty
            row(IMSConstants.Common.EmployeeDuplicate) = String.Empty

            dtstationWiseVehicle.Rows.Add(row)
        Next

        Return dtstationWiseVehicle

    End Function

    ''' <summary>
    ''' Method to Load Appliance Combo (Station Wise)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub LoadApplianceComboStationWise(ByVal stationID As Integer, ByVal applianceID As Integer)

        Dim dtVehicle As DataTable = GetVehicleTableForDropDown(stationID, applianceID)

        cmbVehicle.DisplayMember = IMSConstants.FieldConstants.SerialNumber
        cmbVehicle.DataSource = dtVehicle
        cmbVehicle.DataBind()
        cmbVehicle.DisplayLayout.Bands(0).Columns(0).Hidden = True

    End Sub

    ''' <summary>
    ''' Method to cerate empty Vehicle table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateVehicleTable() As DataTable

        Dim dtVehicle As New DataTable
        dtVehicle.Columns.Add(IMSConstants.FieldConstants.StationApplianceID, GetType(Integer))
        dtVehicle.Columns.Add(IMSConstants.FieldConstants.SerialNumber, GetType(String))

        Return dtVehicle

    End Function

    ''' <summary>
    '''  Method to Get appliance code by appliance ID
    ''' </summary>
    ''' <param name="applianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetApplianceCodeByApplianceID(ByVal applianceID As Integer) As String

        Dim applian As Appliance = _proxy.GetApplianceByID(applianceID)
        If Not IsNothing(applian) Then
            Return applian.ApplianceCode
        Else
            Return String.Empty
        End If

    End Function

    ''' <summary>
    ''' Method to Get Vehicle table (Filtering By Station ID) For dropdown
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetVehicleTableForDropDown(ByVal stationID As Integer, ByVal applianceID As Integer) As DataTable

        Dim dtVehicle As DataTable = CreateVehicleTable()
        Dim lstFireStationAppliance As List(Of FireStationAppliance) = CommonFunction.GetAllCheckedInAndParkedApplianceStationAndApplianceIDWise(stationID, applianceID)

        If lstCmbVehicle.Count > 0 Then
            lstCmbVehicle.Clear() ' Clear before new assign
        End If

        If lstFireStationAppliance.Count > 0 Then

            For Each objFireStationAppliance As FireStationAppliance In lstFireStationAppliance

                Dim row As DataRow = dtVehicle.NewRow
                With objFireStationAppliance
                    row(IMSConstants.FieldConstants.StationApplianceID) = .StationApplianceID
                    row(IMSConstants.FieldConstants.SerialNumber) = .SerialNumber
                End With
                dtVehicle.Rows.Add(row)

                lstCmbVehicle.Add(objFireStationAppliance.SerialNumber)

            Next
        End If

        Return dtVehicle

    End Function

    'Private Sub cmbEmployee_Click(sender As Object, e As EventArgs) Handles cmbEmployee.Click
    '    Dim frm As frmViewEmployee = New frmViewEmployee(lstAvailableAppliance)
    '    frm.ShowDialog()
    'End Sub

    ''' <summary>
    ''' Method to Get Available Employee
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <remarks></remarks>
    Private Sub SetAvailableEmployee(stationID As Integer)

        Dim table As New DataTable()
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim shiftId As Integer = CommonFunction.GetShiftIDByStationIDAndTime(stationID, currentTime)
        Dim lstAvailableEmployee As List(Of Employee) = CommonFunction.GetAllCheckedInAndParkedEmployeeStationAndShiftWise(stationID, shiftId)       '' Shift ID.

        If lstAvailableEmployee.Count > 0 Then

            table = GetEmployeeTableFromList(lstAvailableEmployee)

            grvMultiSelectGrid.DataSource = table
            grvMultiSelectGrid.DataBind()
            Me.grvMultiSelectGrid.DisplayLayout.Override.ActiveRowAppearance.Reset()

            With Me.grvMultiSelectGrid
                .DataSource = table
                .DataBind()
                .DisplayLayout.Bands(0).Columns(1).Hidden = True
                .DisplayLayout.Bands(0).Columns(0).Width = 70
                '.DisplayLayout.Bands(2).Columns(0).Width = 200

                'text
                .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
                .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center

                .DisplayLayout.Override.ActiveCellAppearance.Reset()
                .DisplayLayout.Override.ActiveRowAppearance.Reset()
            End With

        Else

            'table = GetEmployeeTableBlank()
            With Me.grvMultiSelectGrid
                .DataSource = Nothing
                .DataBind()
            End With

        End If

    End Sub

    ''' <summary>
    ''' Method to generate Employee datatable
    ''' </summary>
    ''' <param name="lstAvailableEmployee"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEmployeeTableFromList(lstAvailableEmployee As List(Of Employee)) As DataTable

        Dim table As New DataTable()
        table.Columns.Add(IMSConstants.Common.SelectEmployee, GetType(Boolean))
        table.Columns.Add(IMSConstants.FieldConstants.EmployeeID)
        table.Columns.Add(IMSConstants.Common.EmployeeNameWithSpace)
        For Each obj As Employee In lstAvailableEmployee
            Dim row As DataRow = table.NewRow()
            row(0) = False
            row(1) = obj.EmployeeID
            row(2) = obj.EmployeeName
            table.Rows.Add(row)
        Next

        Return table

    End Function

    ''' <summary>
    ''' Method to Get Blank table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetEmployeeTableBlank() As DataTable

        Dim table As New DataTable()
        table.Columns.Add(IMSConstants.Common.SelectEmployee, GetType(String))
        table.Columns.Add(IMSConstants.FieldConstants.EmployeeID)
        table.Columns.Add(IMSConstants.Common.EmployeeNameWithSpace)

        Dim row As DataRow = table.NewRow()
        row(0) = String.Empty
        row(1) = String.Empty
        row(2) = String.Empty
        table.Rows.Add(row)

        Return table

    End Function

    ''' <summary>
    ''' Method to Get All the Appliances ID (Distinct) list of the Grid.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetApplianceListAtGrid() As List(Of Integer)

        Dim lstApplianceAtGrid As New List(Of Integer)
        Dim lstApplianceAtGridDistinct As New List(Of Integer)

        For i = 0 To grvApplianceForIncident.Rows.Count - 2 '' 2 - because don't take undercount the last row as last row added just now
            lstApplianceAtGrid.Add(CInt(grvApplianceForIncident.Rows(i).Cells(2).Text))
        Next

        lstApplianceAtGridDistinct = lstApplianceAtGrid.Distinct().ToList()

        Return lstApplianceAtGridDistinct

    End Function

    ''' <summary>
    ''' Method to Hide Combo symble form Grid But New Added Row.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HideComboFromPreviousRowOfGrid(ByVal noPreviousRow As Boolean)

        If Not noPreviousRow Then
            For Each item As UltraGridRow In grvApplianceForIncident.Rows
                If item.Cells(8).Text = "Yes" Then
                    item.Cells(3).EditorComponent = Nothing
                    item.Cells(3).Activation = Activation.NoEdit
                End If
            Next
        End If

    End Sub

    ''' <summary>
    ''' Method to Load Other appliance combo
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadOtherApplianceCombo()

        Dim lstApplianceAtGrid As List(Of Integer) = GetApplianceListAtGrid()
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " <> " & IMSEnums.IsDeleted.Yes
        Dim lstAppliance As List(Of Appliance) = _proxy.GetFilteredAppliance(sql).Cast(Of Appliance).ToList()
        Dim dtApplianceCmb As New DataTable
        Dim row As DataRow

        dtApplianceCmb.Columns.Add(IMSConstants.FieldConstants.ApplianceID, GetType(Integer))
        dtApplianceCmb.Columns.Add(IMSConstants.FieldConstants.ApplianceCode, GetType(String))
        dtApplianceCmb.Columns.Add(IMSConstants.FieldConstants.ApplianceName, GetType(String))

        If lstAppliance.Count > 0 Then

            For Each appliance As Appliance In lstAppliance

                If lstApplianceAtGrid.Contains(appliance.ApplianceID) Then
                    Continue For
                End If

                row = dtApplianceCmb.NewRow
                With appliance
                    row(IMSConstants.FieldConstants.ApplianceID) = .ApplianceID
                    row(IMSConstants.FieldConstants.ApplianceCode) = .ApplianceCode
                    row(IMSConstants.FieldConstants.ApplianceName) = .ApplianceName
                End With

                dtApplianceCmb.Rows.Add(row)
            Next

            cmbOtherVehicle.DisplayMember = IMSConstants.FieldConstants.ApplianceCode
            cmbOtherVehicle.ValueMember = IMSConstants.FieldConstants.ApplianceID
            cmbOtherVehicle.DataSource = dtApplianceCmb
            cmbOtherVehicle.DataBind()
            cmbOtherVehicle.DisplayLayout.Bands(0).Columns(0).Hidden = True
            cmbOtherVehicle.DisplayLayout.Bands(0).Columns(2).Hidden = True
        End If

    End Sub

    ''' <summary>
    ''' Method to Clean the dropdowns in Mapped row of the Grid.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CleanStationWiseApplianceGrid()

        lblVehicleCode.Text = String.Empty
        lblRequiredQuantity.Text = String.Empty

        grvStationApplianceForDispatch.DataSource = Nothing
        grvStationApplianceForDispatch.DataBind()

    End Sub

    ''' <summary>
    ''' Method to Load StationWise Vehicle Grid depending on Incident grid cell click.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadStationWiseVehicleGridOnCellClick(sender As Object, e As ClickCellEventArgs)

        If Not IsNothing(e.Cell.Row.Cells(2)) And Not String.IsNullOrEmpty(e.Cell.Row.Cells(2).Text) Then

            'Dim applianceID = CInt(e.Cell.Row.Cells(2).Text)
            'Dim vehicleCode = e.Cell.Row.Cells(3).Text
            'Dim requiredQuantity = CInt(e.Cell.Row.Cells(5).Text)
            applianceID = CInt(e.Cell.Row.Cells(2).Text)
            vehicleCode = e.Cell.Row.Cells(3).Text

            If Not String.IsNullOrEmpty(e.Cell.Row.Cells(5).Text) Then
                requiredQuantity = CInt(e.Cell.Row.Cells(5).Text)
            Else
                requiredQuantity = -1  ' To specify - this is others vehicel (Not Mapped)
            End If

            selectedTypeID = CInt(e.Cell.Row.Cells(7).Text)
            LoadStationWiseApplianceWithApplianceID(applianceID, vehicleCode, requiredQuantity)

        Else


        End If

    End Sub

    ''' <summary>
    ''' Method to Load StationWise Vehicle Grid depending on Incident grid Combo select.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub LoadStationWiseVehicleGridOnCellChange(sender As Object, e As CellEventArgs)

        If Not IsNothing(e.Cell.Row.Cells(2)) And Not String.IsNullOrEmpty(e.Cell.Row.Cells(2).Text) Then

            'Dim applianceID = CInt(e.Cell.Row.Cells(2).Text)
            'Dim vehicleCode = e.Cell.Row.Cells(3).Text
            'Dim requiredQuantity = CInt(e.Cell.Row.Cells(5).Text)
            applianceID = CInt(e.Cell.Row.Cells(2).Text)
            vehicleCode = e.Cell.Row.Cells(3).Text

            If Not String.IsNullOrEmpty(e.Cell.Row.Cells(5).Text) Then
                requiredQuantity = CInt(e.Cell.Row.Cells(5).Text)
            Else
                requiredQuantity = -1  ' To specify - this is others vehicel (Not Mapped)
            End If

            selectedTypeID = CInt(e.Cell.Row.Cells(7).Text)
            LoadStationWiseApplianceWithApplianceID(applianceID, vehicleCode, requiredQuantity)

        Else


        End If

    End Sub

    ''' <summary>
    ''' Method to Create Station wise Vehicle Table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateCheckedInVehicleBlankTable() As DataTable

        Dim dtCheckedInStationWiseVehicle As New DataTable
        With dtCheckedInStationWiseVehicle
            .Columns.Add(IMSConstants.FieldConstants.StationID, GetType(Integer))
            .Columns.Add(IMSConstants.FieldConstants.StationApplianceID, GetType(Integer))
            .Columns.Add(IMSConstants.FieldConstants.ApplianceID, GetType(Integer))
            .Columns.Add(IMSConstants.FieldConstants.SerialNumber, GetType(String))
            .Columns.Add(IMSConstants.FieldConstants.IncidentID, GetType(Integer))
            .Columns.Add(IMSConstants.FieldConstants.Reason, GetType(String))
            .Columns.Add(IMSConstants.Common.CheckedInStationID, GetType(Integer))
        End With

        Return dtCheckedInStationWiseVehicle

    End Function

    ''' <summary>
    ''' Method to Hide some column of Grid named "StationwiseDispalyVehicle"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub HideSomeColumnGridDispatchVehicle()

        With grvStationApplianceForDispatch

            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(6).Hidden = True
            .DisplayLayout.Bands(0).Columns(7).Hidden = True

        End With

    End Sub

#End Region

#Region "Current Dispatch List"

    ''' <summary>
    ''' Method to load Current dispatched appliances for a specific incident.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCurrentDispatchList()

        Dim dtAssignedAppliance As New DataTable

        Dim sql As String = String.Format("{0} = {1} and {2} <> {3}", IMSConstants.FieldConstants.IncidentID, incidentID, IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes))
        Dim lstAssignedAppliance As List(Of AssignedAppliance) = _proxy.GetFilteredAssignedAppliance(sql).Cast(Of AssignedAppliance).ToList()

        If lstAssignedAppliance.Count > 0 Then

            dtAssignedAppliance = GetTableOfAssignedAppliance(lstAssignedAppliance)

            With grvCurrentDispatch

                .DataSource = dtAssignedAppliance
                .DataBind()

                'text center
                '.DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
                '.DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
                .DisplayLayout.Bands(0).Columns(6).CellAppearance.TextHAlign = HAlign.Center
                .DisplayLayout.Bands(0).Columns(7).CellAppearance.TextHAlign = HAlign.Center
                .DisplayLayout.Bands(0).Columns(8).CellAppearance.TextHAlign = HAlign.Center

                .DisplayLayout.Bands(0).Columns(5).Width = 160
                .DisplayLayout.Bands(0).Columns(6).Width = 80

                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Bands(0).Columns(9).Hidden = True 'dispatch Log id - column

                ''TODO : User Access Right of Grid buttons (dispatch)
                If Not CommonFunction.IsSuperAdmin Then

                    Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Dispatch And x.FrontEndParentID = Me.Name).FirstOrDefault()
                    If IsNothing(objSavePrivilig) Then
                        .DisplayLayout.Bands(0).Columns(7).Hidden = True
                    End If

                End If

            End With

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
        Dim objDispatchLog As DispatchLog

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

                    'time of arival block (dipatch Log table)
                    objDispatchLog = CommonFunction.GetLatestDispatchLogByIncidentIDAndStationApplianceID(obj.IncidentID, obj.StationApplianceID)

                    row(IMSConstants.ColumnHeader.TimeOfArival) = IMSConstants.Common.N_A

                    If Not IsNothing(objDispatchLog) Then
                        row(IMSConstants.Common.DispatchLogID) = objDispatchLog.DispatchLogID
                        If Not String.IsNullOrEmpty(objDispatchLog.TimeOfArrival) Then

                            If objDispatchLog.TimeOfArrival <> Date.Parse(IMSConstants.Settings.DateTimeDefault) Then
                                row(IMSConstants.ColumnHeader.TimeOfArival) = objDispatchLog.TimeOfArrival
                            End If

                        End If
                    End If

                    row(IMSConstants.ColumnHeader.SetTimeOfArival) = IMSConstants.ColumnHeader.SetTimeOfArival

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

        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.TimeOfArival, GetType(String))
        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.SetTimeOfArival)

        dtAssignedAppliance.Columns.Add(IMSConstants.ColumnHeader.Redispatch)
        dtAssignedAppliance.Columns.Add(IMSConstants.Common.Revoke)
        dtAssignedAppliance.Columns.Add(IMSConstants.Common.DispatchLogID)

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
            Dim currentTime As DateTime
            Dim dispatchLog As New DispatchLog
            Dim objAssignedAppliance As AssignedAppliance = _proxy.GetAssignedApplianceByID(assignedApplianceID)
            Dim lstAssignedAppliance As New List(Of AssignedAppliance)
            Dim sql As String

            If Not IsNothing(objAssignedAppliance) Then

                'Re-dispatched Button Clicked
                If gridCellIndex = 7 Then

                    'Check - Is this vehicle already busy?
                    If CommonFunction.IsVehicleOccupied(objAssignedAppliance.StationApplianceID) Then
                        DisplayError(IMSConstants.ErrorMessage.ThisVehicleOccupiedOthers)
                        Exit Sub
                    End If

                    'Check out from (Appliance Register) Table If in the mean time this vehicle checked in
                    CommonFunction.CheckOutVehicle(objAssignedAppliance.StationApplianceID, String.Empty, objAssignedAppliance.IncidentID)

                    objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Redispatched)
                End If

                'Revoke Button Clicked
                If gridCellIndex = 8 Then
                    objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Revoked)
                End If

                If _proxy.UpdateAssignedAppliance(objAssignedAppliance) > 0 Then

                    If gridCellIndex = 7 Then
                        DisplaySuccessfull(IMSConstants.SuccessMessageConstants.ReDispatchedSuccessfully)
                    End If
                    If gridCellIndex = 8 Then
                        DisplaySuccessfull(IMSConstants.SuccessMessageConstants.RevokedSuccessfully)
                    End If
                Else

                    If gridCellIndex = 7 Then
                        DisplayError(IMSConstants.ErrorMessage.RedispathedFailed)
                    End If
                    If gridCellIndex = 8 Then
                        DisplayError(IMSConstants.ErrorMessage.RevokedFailed)
                    End If

                End If

                'Insert into Dispatch Log
                With dispatchLog
                    .IncidentID = objAssignedAppliance.IncidentID
                    .StationApplianceID = objAssignedAppliance.StationApplianceID
                    .AssignedApplianceStatus = objAssignedAppliance.AssignedApplianceStatus
                    .Reason = reason
                    DateTime.TryParseExact(DateTime.Now.ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.AppConstants.DateFormatToQuery, CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)
                    .DispatchDate = currentTime
                    .CreatedBy = IMSConstants.AppConstants.UsersEmployeeID '36  '(dolater)change it by logged in employee
                    .TimeOfArrival = Date.Parse(IMSConstants.Settings.DateTimeDefault)

                End With

                _proxy.InsertDispatchLog(dispatchLog)

                Me.LoadCurrentDispatchList()

                'Reset values
                assignedApplianceID = 0
                gridCellIndex = 0

                ''Load Others Grids (Dispatch Vehicle, Station wise Vehicle and Dispatch Log)

                LoadDispatchLog(incidentID)
                LoadApplianceForSpecificIncidentType()
                LoadStationWiseApplianceWithApplianceID(applianceID, vehicleCode, requiredQuantity)
            End If

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

#Region "Dispatch Log"

    ''' <summary>
    ''' Method to loaad form data.
    ''' </summary>
    ''' <param name="incidentId"></param>
    ''' <remarks></remarks>
    Private Sub LoadDispatchLog(ByVal incidentId As Integer)

        Dim tblIncidentType As DataTable = CreateDataTable()
        Dim row As DataRow = tblIncidentType.NewRow
        Dim strSQL As String = IMSConstants.FieldConstants.IncidentID & "=" & incidentId & " ORDER BY " & "DispatchLogID DESC"

        For Each obj As IMSService.DispatchLog In _proxy.GetFilteredDispatchLog(strSQL).Cast(Of IMSService.DispatchLog).ToList()

            row = CreateRow(obj, tblIncidentType)
            tblIncidentType.Rows.Add(row)

        Next

        With Me.grvDispatchLog
            .DataSource = tblIncidentType
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

    End Sub

    ''' <summary>
    ''' Method to Create data table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDataTable() As DataTable

        Dim tblIncidentType As New DataTable

        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.DispatchLogID, GetType(Integer))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.Time, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.ActionTaken, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.User, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.Reason, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.Serialno, GetType(String))

        Return tblIncidentType

    End Function

    ''' <summary>
    ''' Method to create row.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="tblIncidentType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateRow(ByVal obj As IMSService.DispatchLog, ByVal tblIncidentType As DataTable) As DataRow

        Dim row As DataRow = tblIncidentType.NewRow

        Dim employeeName As String = String.Empty
        Dim objemployee As IMSService.Employee = _proxy.GetEmployeeByID(obj.CreatedBy)
        If Not IsNothing(objemployee) Then
            employeeName = objemployee.EmployeeName
        End If

        Dim serialNo As String = Nothing
        Dim objFireStationAppliance As IMSService.FireStationAppliance = _proxy.GetFireStationApplianceByID(obj.StationApplianceID)
        If Not IsNothing(objFireStationAppliance) Then
            serialNo = objFireStationAppliance.SerialNumber
        End If

        row(IMSConstants.FieldConstants.DispatchLogID) = obj.DispatchLogID
        row(IMSConstants.GridHeader.Time) = obj.DispatchDate
        row(IMSConstants.GridHeader.ActionTaken) = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), obj.AssignedApplianceStatus)
        row(IMSConstants.GridHeader.User) = employeeName
        row(IMSConstants.GridHeader.Reason) = obj.Reason
        row(IMSConstants.GridHeader.Serialno) = serialNo

        Return row

    End Function

    ''' <summary>
    ''' Method to delete dispatchLog
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteDispatchLog()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvDispatchLog.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objDispatchLog As IMS.Win.IMSService.DispatchLog = _proxy.GetDispatchLogByID(id)
            If Not IsNothing(objDispatchLog) Then
                deletedId = _proxy.DeleteDispatchLog(objDispatchLog)
            End If
            If deletedId > -1 Then
                Me.DisplaySuccessfull(IMSConstants.SuccessMessageConstants.RecordDeletedSuccessfully)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

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
        End If

    End Sub


#End Region


    Private Sub SaveTimeOfArrival(ByVal dispatchLogID As Integer, ByVal timeOfArrival As String)

        Dim dispatchLog As DispatchLog = _proxy.GetDispatchLogByID(dispatchLogID)
        If Not IsNothing(dispatchLog) Then
            dispatchLog.TimeOfArrival = DateTime.Parse(timeOfArrival)

            If _proxy.UpdateDispatchLog(dispatchLog) > 0 Then
                DisplayConfirmation(IMSConstants.SuccessMessageConstants.TimeOfArrivalSavedSuccessfully)
                LoadCurrentDispatchList()
            Else
                DisplayError(IMSConstants.ErrorMessage.SorryTimeOfArrivalSaveFailed)
            End If

        End If

    End Sub




#End Region

#Region "Event Handlers"

#Region "Dispatch Vehicle"


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmDispatchVehicles_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            '' MyBase.SetSecurity(Me) 
            '  NOTE:  // this page don't need security as the button on which click this form popup; 
            'that button has accessed track - Hence who has access this form, 
            'has all button of this Form


            lblReferenceNo.Text = referenceNo
            LoadAllThreePanels()

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
    'Private Sub btnClose_Click(sender As Object, e As EventArgs)
    '    Try

    '        RaiseEvent LoadDispatchVehicleForm()
    '        Me.Close()

    '    Catch ex As Exception
    '        Me.WriteLog(ex)
    '        Me.DisplayError(IMSConstants.ExceptionMessage.Message)
    '    End Try

    'End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grvApplianceForIncident_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grvApplianceForIncident.ClickCell
        Try
            '' Click to load dropdown

            If e.Cell.Column.Index = 3 Then

                If e.Cell.Row.Cells(8).Text = "Yes" Then
                    e.Cell.Row.Cells(3).EditorComponent = Nothing
                    e.Cell.Row.Cells(3).Activation = Activation.NoEdit
                Else
                    e.Cell.Row.Cells(3).EditorComponent = cmbOtherVehicle
                    'Load others vehicle combo
                    LoadOtherApplianceCombo()
                End If

            End If

            If String.IsNullOrEmpty(e.Cell.Row.Cells(4).Text) Then
                CleanStationWiseApplianceGrid()
                Exit Sub
            End If

            ''Click to Load Station wise appliance Grid
            LoadStationWiseVehicleGridOnCellClick(sender, e)

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
    Private Sub grvStationApplianceForDispatch_ClickCell(sender As Object, e As ClickCellEventArgs) Handles grvStationApplianceForDispatch.ClickCell
        Try

            Dim stationID As Integer = 0
            If Not IsNothing(e.Cell.Row.Cells(0)) And Not String.IsNullOrEmpty(e.Cell.Row.Cells(0).Text) Then
                stationID = CInt(e.Cell.Row.Cells(0).Text)
            End If

            If stationID <= 0 Then
                Exit Sub
            End If

            If e.Cell.Column.Index = 3 Then
                '' TODO : For Vehicle dropdown list Load 
                LoadApplianceComboStationWise(stationID, applianceID)
            End If

            If e.Cell.Column.Index = 4 Then
                '' TODO : For Employee dropdown list Load 
                SetAvailableEmployee(stationID)
            End If

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
    Private Sub grvStationApplianceForDispatch_AfterEditorButtonCloseUp(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinEditors.EditorButtonEventArgs) Handles uteForEmployeeGrid.AfterEditorButtonCloseUp
        Try
            If Me.grvStationApplianceForDispatch.ActiveRow Is Nothing Then Return
            ''Me.grvStationApplianceForDispatch.ActiveCell.Value = Me.theMultiSelectGrid.ActiveRow.Cells(1).Value
            'Me.grvStationApplianceForDispatch.ActiveRow.Cells(6).Value = Me.grvMultiSelectGrid.ActiveRow.Cells(4).Value

            'Get the Employee selected.
            Dim employeeIDs As String = String.Empty
            Dim employeeNames As String = String.Empty
            Dim employee As New Employee

            For Each row As UltraGridRow In grvMultiSelectGrid.Rows

                If row.Cells(0).Value Then

                    'Create comma separated employee IDs.
                    If String.IsNullOrEmpty(employeeIDs) Then
                        employeeIDs = row.Cells(1).Value.ToString()
                    Else
                        employeeIDs = employeeIDs + "," + row.Cells(1).Value.ToString()
                    End If

                    'Create comma separated employee name.
                    employee = _proxy.GetEmployeeByID(CInt(row.Cells(1).Value.ToString()))

                    If Not IsNothing(employee) Then
                        If String.IsNullOrEmpty(employeeNames) Then
                            employeeNames = employee.EmployeeName
                        Else
                            employeeNames = employeeNames + " , " + employee.EmployeeName
                        End If
                    End If

                End If
            Next

            Me.grvStationApplianceForDispatch.ActiveRow.Cells(6).Value = employeeIDs
            Me.grvStationApplianceForDispatch.ActiveRow.Cells(4).Value = employeeNames
            Me.grvStationApplianceForDispatch.ActiveRow.Cells(7).Value = employeeNames

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
    Private Sub grvStationApplianceForDispatch_ClickCellButton(sender As Object, e As CellEventArgs) Handles grvStationApplianceForDispatch.ClickCellButton
        Try

            Dim applianceSerialNO As String = String.Empty
            Dim employeeIDs As String = String.Empty
            Dim employeeNames As String = String.Empty
            Dim selectedEmployee() As String
            Dim selectedEmployeeName() As String
            Dim objEmployeeRegister As New EmployeeRegister
            Dim objApplianceRegister As New ApplianceRegister
            Dim objAssignedAppliance As New AssignedAppliance
            Dim objStationAppliance As New FireStationAppliance
            Dim objAssignedEmployee As New AssignedEmployee
            Dim appliance As New Appliance
            Dim lstStationAppliance As New List(Of FireStationAppliance)
            Dim objDispatchLog As New DispatchLog
            Dim insertStatus As Boolean = True
            Dim sql As String = String.Empty
            Dim stationApplianceID As Integer = 0
            Dim lstAppliance As New List(Of Appearance)
            Dim assignedApplianceID As Integer = 0
            'Dim applianceID As Integer = 0
            Dim currentTime As DateTime
            DateTime.TryParseExact(Date.Now.ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.AppConstants.DateFormatToQuery, CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)
            Dim errorMessageOccupied As String = String.Empty

            If e.Cell.Column.Index = 5 Then

                applianceSerialNO = e.Cell.Row.Cells(3).Value
                employeeIDs = e.Cell.Row.Cells(6).Value
                employeeNames = e.Cell.Row.Cells(4).Value

                'Check Vehicle and Eployee selected.

                If String.IsNullOrEmpty(applianceSerialNO) Then
                    Me.DisplayError(IMSConstants.ErrorMessage.SelectVehicle)
                    Exit Sub
                End If

                If String.IsNullOrEmpty(employeeIDs) Then
                    Me.DisplayError(IMSConstants.ErrorMessage.SelectEmployee)
                    Exit Sub
                End If

                'If employeeIDs.Contains(",") Then
                '    selectedEmployee = employeeIDs.Split(",")
                'Else
                '    'selectedEmployee(0) = employeeIDs
                'End If

                selectedEmployee = employeeIDs.Split(",")
                selectedEmployeeName = employeeNames.Split(",")

                ''TODO (Validation Check) - a: Check Vehicle already occupied or not.
                If CommonFunction.IsVehicleOccupied(applianceSerialNO) Then
                    errorMessageOccupied = String.Format(IMSConstants.ErrorMessage.VehicleOccupied, applianceSerialNO)
                End If

                ''TODO (Validation Check) - b: Check Employees are already occupied or not.
                Dim i As Integer = 0

                If selectedEmployee.Count > 0 Then
                    For Each employeeID As Integer In selectedEmployee

                        If CommonFunction.IsEmployeeOccupied(employeeID) Then
                            If String.IsNullOrEmpty(errorMessageOccupied) Then
                                errorMessageOccupied = String.Format(IMSConstants.ErrorMessage.EmployeeOccupied, selectedEmployeeName(i))
                            Else
                                errorMessageOccupied += vbNewLine + String.Format(IMSConstants.ErrorMessage.EmployeeOccupied, selectedEmployeeName(i))
                            End If

                        End If

                        i = i + 1
                    Next
                End If

                If Not String.IsNullOrEmpty(errorMessageOccupied) Then

                    Me.DisplayError(errorMessageOccupied)
                    'Load the Station Wise Vehicle grid again.
                    LoadStationWiseApplianceWithApplianceID(applianceID, vehicleCode, requiredQuantity)
                    Exit Sub

                End If

                ''TODO 1:  Assinged Appliance (Insert/Update (if already has assigned entry))
                sql = String.Format("{0}='{1}' and {2} <> {3}", IMSConstants.FieldConstants.SerialNumber, applianceSerialNO, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Deleted))
                lstStationAppliance = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

                If lstStationAppliance.Count > 0 Then
                    stationApplianceID = lstStationAppliance(0).StationApplianceID
                End If

                ''Insert (First time) Or Update
                sql = String.Format("{0} = {1} and {2} = {3} and {4} = {5} and {6} = {7} ", _
                                    IMSConstants.FieldConstants.IncidentID, incidentID, _
                                    IMSConstants.FieldConstants.StationApplianceID, stationApplianceID, _
                                     IMSConstants.FieldConstants.IncidentTypeID, selectedTypeID, _
                                    IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No))

                Dim lstAssignedAppliance As List(Of AssignedAppliance) = _proxy.GetFilteredAssignedAppliance(sql).Cast(Of AssignedAppliance).ToList()
                If lstAssignedAppliance.Count > 0 Then

                    objAssignedAppliance = lstAssignedAppliance(0)
                    objAssignedAppliance.AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Redispatched)

                    assignedApplianceID = _proxy.UpdateAssignedAppliance(objAssignedAppliance)
                Else
                    With objAssignedAppliance
                        .IncidentTypeID = selectedTypeID
                        .IncidentID = incidentID
                        .StationApplianceID = stationApplianceID
                        .AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Dispatched)
                        .IsDeleted = False
                    End With

                    assignedApplianceID = _proxy.InsertAssignedAppliance(objAssignedAppliance)
                End If

                If Not (assignedApplianceID > 0) Then
                    Me.DisplayError(IMSConstants.ExceptionMessage.Message)
                End If

                ''TODO 2: CheckOut Vehicle

                'Do false all IsTrue fields of the Appliance Register
                CommonFunction.UpdateIsTrueForApplianceRegister(stationApplianceID)

                If assignedApplianceID > 0 Then
                    With objApplianceRegister
                        .ShiftID = selectedShiftID ' What will be this -(dolater)
                        .StationID = e.Cell.Row.Cells(0).Value
                        .StationApplianceID = stationApplianceID
                        '.AssignedApplienceID = assignedApplianceID
                        .RegisterStatus = IMSEnums.RegisterStatus.CheckedOut
                        .IsCurrent = True
                        .OnEvent = True
                        .IncidentID = incidentID
                        .Reason = String.Empty
                        .CapturedBy = IMSConstants.AppConstants.UsersEmployeeID  '36  ' Change By loggedin ID (dolater)
                        .InsertionDate = currentTime
                        .ModificationDate = currentTime
                    End With

                    If Not (_proxy.InsertApplianceRegister(objApplianceRegister) > 0) Then
                        insertStatus = False
                    End If
                End If

                ''TODO 3: Insert Dispatch Log

                Dim dateDefault As Date = Date.Parse(IMSConstants.Settings.DateTimeDefault)

                With objDispatchLog
                    .IncidentID = incidentID
                    .StationApplianceID = stationApplianceID
                    .AssignedApplianceStatus = CInt(IMSEnums.ApplianceStatus.Dispatched)
                    .Reason = IMSConstants.Common.OnEvent
                    .CreatedBy = IMSConstants.AppConstants.UsersEmployeeID
                    .TimeOfArrival = dateDefault  ' Inserting default date time
                    .DispatchDate = currentTime
                End With

                If Not (_proxy.InsertDispatchLog(objDispatchLog) > 0) Then
                    insertStatus = False
                End If

                ''TODO 4: CheckOut Employee  ''TODO 5: Insert Assigned Employee

                For Each employeeID As String In selectedEmployee
                    With objEmployeeRegister
                        .ShiftID = selectedShiftID  ' What will be this -later.
                        .StationID = e.Cell.Row.Cells(0).Value
                        .EmployeeID = employeeID
                        .RegisterStatus = IMSEnums.RegisterStatus.CheckedOut
                        .IsCurrent = True
                        .OnEvent = True
                        .IncidentID = incidentID
                        .Reason = String.Empty
                        .CapturedBy = IMSConstants.AppConstants.UsersEmployeeID
                        .InsertionDate = currentTime
                        .ModificationDate = currentTime
                    End With

                    'Do false all IsTrue fields of the Appliance Register
                    CommonFunction.UpdateIsTrueForEmployeeRegister(employeeID)

                    If Not (_proxy.InsertEmployeeRegister(objEmployeeRegister) > 0) Then
                        insertStatus = False
                    End If

                    With objAssignedEmployee
                        .StationApplianceID = stationApplianceID
                        .IncidentID = incidentID
                        .EmployeeID = employeeID
                        .AssignedEmployeeStatus = IMSEnums.ApplianceStatus.Dispatched
                        .IsDeleted = False
                    End With

                    If Not (_proxy.InsertAssignedEmployee(objAssignedEmployee) > 0) Then
                        insertStatus = False
                    End If
                Next

                '' TODO 5: Update Incident Register (IncidentStatus)
                Dim objIncidentRegister As IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)
                If Not IsNothing(objIncidentRegister) Then
                    objIncidentRegister.IncidentStatus = CInt(IMSEnums.IncidentStatus.Dispatched)
                    _proxy.UpdateIncidentRegister(objIncidentRegister)
                End If

            End If

            If Not insertStatus Then
                Me.DisplayError(IMSConstants.ExceptionMessage.Message)
            End If

            'Load whole grids again to reflect the changes.
            LoadAllThreePanels()
            'LoadApplianceForSpecificIncidentType()
            LoadStationWiseApplianceWithApplianceID(applianceID, vehicleCode, requiredQuantity)

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
    Private Sub grvApplianceForIncident_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grvApplianceForIncident.InitializeRow

        Try
            With grvApplianceForIncident

                'Background color
                If String.IsNullOrEmpty(e.Row.Cells(5).Text) Then
                    Exit Sub
                End If

                If e.Row.Cells(5).Value >= 0 And e.Row.Cells(6).Value >= 0 Then
                    If e.Row.Cells(5).Value <= e.Row.Cells(6).Value Then
                        e.Row.Appearance.BackColor = Color.Green
                        e.Row.Appearance.ForeColor = Color.White
                    ElseIf e.Row.Cells(6).Value = 0 Then
                        e.Row.Appearance.BackColor = Color.Red
                    ElseIf e.Row.Cells(5).Value > e.Row.Cells(6).Value Then
                        e.Row.Appearance.BackColor = Color.Yellow
                    End If
                End If

            End With

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
    Private Sub grvStationApplianceForDispatch_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grvStationApplianceForDispatch.InitializeRow
        Try
            grvStationApplianceForDispatch.DisplayLayout.Bands(0).Columns(5).Style = UltraWinGrid.ColumnStyle.Button
            grvStationApplianceForDispatch.DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D
            grvStationApplianceForDispatch.DisplayLayout.Bands(0).Columns(5).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always

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
    Private Sub btnAdditionalVehicle_Click(sender As Object, e As EventArgs) Handles btnAdditionalVehicle.Click
        Try
            With grvApplianceForIncident
                'Check Add only one new row (can't add more than one new without assign vehicle)
                If .Rows.Count > 0 Then
                    If .Rows(.Rows.Count - 1).Cells(8).Text = "Yes" Then
                        .DisplayLayout.Bands(0).AddNew()
                        .DisplayLayout.Bands(0).Columns(3).EditorComponent = cmbOtherVehicle
                        HideComboFromPreviousRowOfGrid(False)
                    End If
                End If

                If .Rows.Count = 0 Then
                    .DisplayLayout.Bands(0).AddNew()
                    .DisplayLayout.Bands(0).Columns(3).EditorComponent = cmbOtherVehicle

                    '.DisplayLayout.Bands(0).Columns(0).Hidden = True
                    '.DisplayLayout.Bands(0).Columns(1).Hidden = True
                    '.DisplayLayout.Bands(0).Columns(6).Hidden = True
                    '.DisplayLayout.Bands(0).Columns(7).Hidden = True

                    HideComboFromPreviousRowOfGrid(True)
                End If

            End With

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
    Private Sub grvApplianceForIncident_CellChange(sender As Object, e As CellEventArgs) Handles grvApplianceForIncident.CellChange
        Try

            e.Cell.Row.Cells(2).Value = cmbOtherVehicle.SelectedRow.Cells(0).Text
            e.Cell.Row.Cells(4).Value = cmbOtherVehicle.SelectedRow.Cells(2).Text
            e.Cell.Row.Cells(7).Value = 0 '' The Others appliance "Incident Type ID" giving 0  to Isolate them.

            'Load Stationwise Vehicle Grid depending on cmbo select.
            LoadStationWiseVehicleGridOnCellChange(sender, e)

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
    Private Sub grvApplianceForIncident_BeforeCellActivate(sender As Object, e As CancelableCellEventArgs) Handles grvApplianceForIncident.BeforeCellActivate
        Try

            If e.Cell.Column.Index = 3 Then

                If e.Cell.Row.Cells(8).Text = "Yes" Then
                    e.Cell.Activation = Activation.NoEdit
                Else
                    e.Cell.Activation = Activation.AllowEdit

                    e.Cell.Row.Cells(3).EditorComponent = cmbOtherVehicle
                    'Load others vehicle combo
                    LoadOtherApplianceCombo()
                End If

            Else
                e.Cell.Activation = Activation.NoEdit

            End If

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
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try

            RaiseEvent LoadDispatchVehicleForm()
            Me.Close()

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
    Private Sub grvStationApplianceForDispatch_BeforeCellActivate(sender As Object, e As CancelableCellEventArgs) Handles grvStationApplianceForDispatch.BeforeCellActivate
        Try

            If e.Cell.Column.Index = 3 Or e.Cell.Column.Index = 4 Or e.Cell.Column.Index = 5 Then
                e.Cell.Activation = Activation.AllowEdit
            Else
                e.Cell.Activation = Activation.NoEdit
            End If

            e.Cell.Row.Selected = True

            grvStationApplianceForDispatch.DisplayLayout.Override.SelectTypeRow =
                          Infragistics.Win.UltraWinGrid.SelectType.Single

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
    Private Sub grvStationApplianceForDispatch_CellChange(sender As Object, e As CellEventArgs) Handles grvStationApplianceForDispatch.CellChange

        Try
            'Logic : This event is for protect from edit the dropdown cell.
            'Vehicle dropdown edit
            If e.Cell.Column.Index = 3 Then
                If Not lstCmbVehicle.Contains(e.Cell.Row.Cells(3).Text) Then
                    e.Cell.Row.Cells(3).Value = String.Empty
                End If
            End If

            ' Employee edit.
            If e.Cell.Column.Index = 4 Then
                e.Cell.Row.Cells(4).Value = e.Cell.Row.Cells(7).Text
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

#Region "Current Dispatch List"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grvCurrentDispatch_ClickCellButton(sender As Object, e As CellEventArgs) Handles grvCurrentDispatch.ClickCellButton
        Try

            assignedApplianceID = grvCurrentDispatch.Rows(e.Cell.Row.Index).Cells(0).Value

            'Time Of Arrival Button Clicked
            If e.Cell.Column.Index = 6 Then

                gridCellIndex = 6

                Dim arrivalTime As String = grvCurrentDispatch.Rows(e.Cell.Row.Index).Cells(5).Value
                If arrivalTime = IMSConstants.Common.N_A Then
                    arrivalTime = String.Empty
                End If

                Dim dispatchLogID As Integer = grvCurrentDispatch.Rows(e.Cell.Row.Index).Cells(9).Value

                Dim frm As frmTimeOfArrival = New frmTimeOfArrival(dispatchLogID, arrivalTime)
                AddHandler frm.LoadTOAForSave, AddressOf SaveTimeOfArrival
                AddHandler frm.LoadDoNothig, AddressOf DoNothig
                frm.ShowDialog()

            End If

            'Re-dispatched Button Clicked
            If e.Cell.Column.Index = 7 Then

                gridCellIndex = 7

                Dim frm As frmRevokeReason = New frmRevokeReason(IMSConstants.Information.PleaseGiveAReasonForRedispatch)
                AddHandler frm.LoadReasonForSave, AddressOf UpdateCurrentDispatch
                AddHandler frm.LoadDoNothig, AddressOf DoNothig
                frm.ShowDialog()

            End If

            'Revoke Button Clicked
            If e.Cell.Column.Index = 8 Then

                gridCellIndex = 8

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
        Try

            e.Row.Cells(4).Appearance.ForeColor = Color.White
            e.Row.Cells(4).Appearance.BackColor = Color.Gray

            With grvCurrentDispatch

                .DisplayLayout.Bands(0).Columns(6).Style = UltraWinGrid.ColumnStyle.Button
                .DisplayLayout.Bands(0).Columns(6).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always

                .DisplayLayout.Bands(0).Columns(7).Style = UltraWinGrid.ColumnStyle.Button
                .DisplayLayout.Bands(0).Columns(7).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always

                .DisplayLayout.Bands(0).Columns(8).Style = UltraWinGrid.ColumnStyle.Button
                .DisplayLayout.Bands(0).Columns(8).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always

                .DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D

            End With

            If (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Dispatched)) Or (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Redispatched)) Then
                'Button Re-dispatch disable
                e.Row.Cells(7).Activation = Activation.Disabled
            End If

            If (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Revoked)) Or (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.BackAfterResolved)) _
                Or (e.Row.Cells(4).Text = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), IMSEnums.ApplianceStatus.Available)) Then
                'Button Revoke disable
                e.Row.Cells(8).Activation = Activation.Disabled
                'Button TOA disable
                e.Row.Cells(6).Activation = Activation.Disabled

                'Check Is this Vehicle already occupied other's
                If Not String.IsNullOrEmpty(e.Row.Cells(3).Value) Then
                    If CommonFunction.IsVehicleOccupied(e.Row.Cells(3).Value) Then
                        'Button Re-dispatch and Button TOA disable
                        e.Row.Cells(7).Activation = Activation.Disabled
                        e.Row.Cells(6).Activation = Activation.Disabled
                        e.Row.Appearance.BackColor = Color.Red
                    End If
                End If

            End If

            ''TODO : User Access Right of Grid buttons (dispatch)
            If Not CommonFunction.IsSuperAdmin Then

                'Time Of Arrival button autho.
                Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.TimeOfArrival And x.FrontEndParentID = Me.Name).FirstOrDefault()
                If IsNothing(objSavePrivilig) Then
                    e.Row.Cells(6).Activation = Activation.Disabled
                End If

                'Re-dispatch button autho.
                objSavePrivilig = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Redispatch And x.FrontEndParentID = Me.Name).FirstOrDefault()
                If IsNothing(objSavePrivilig) Then
                    e.Row.Cells(7).Activation = Activation.Disabled
                End If
                'Revoke button autho.
                objSavePrivilig = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Revoke And x.FrontEndParentID = Me.Name).FirstOrDefault()
                If IsNothing(objSavePrivilig) Then
                    e.Row.Cells(8).Activation = Activation.Disabled
                End If



            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

#Region "Dispatch Log"

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try

            'Dim frm As frmAddIncidentType = New frmAddIncidentType()
            'AddHandler frm.LoadIncidentType, AddressOf LoadIncidentType
            'frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try

            If grvDispatchLog.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvDispatchLog.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    'Dim frm As frmAddIncidentType = New frmAddIncidentType(editId)
                    'AddHandler frm.LoadIncidentType, AddressOf LoadIncidentType
                    'frm.ShowDialog()
                End If

            Else
                DisplayInformation("Pelase Select A Incidedent Type. ")
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Try
            If grvDispatchLog.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    DeleteDispatchLog()
                    Me.LoadDispatchLog(incidentID)

                End If
            Else
                DisplayError(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)

        Try
            Me.LoadDispatchLog(incidentID)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    'Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
    '    Me.Close()
    'End Sub


#End Region

#End Region

End Class




