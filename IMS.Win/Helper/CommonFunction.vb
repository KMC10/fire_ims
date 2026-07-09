'Author                : Shah Jafar Ulla
'Crated Date           : 24/4/2014
'Last Modified by      : 
'Last Modifiation Date : 
'(C) CopyRight Nybsys.

Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win
Imports System.Globalization
Imports System.Text.RegularExpressions
Imports System.Text
Imports System.Reflection
Imports System.ComponentModel

Public Class CommonFunction

    ''' <summary>
    ''' Method to Update all IsCurrent  to False (StationAppliance wise). (Table Appliance Register)
    ''' </summary> 
    ''' <param name="stationApplianceID"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateIsTrueForApplianceRegister(ByVal stationApplianceID As Integer)

        Dim _proxy As New IMSService.IMSServices

        Dim sql As String = IMSConstants.FieldConstants.StationApplianceID & " = " & stationApplianceID.ToString() & " and " & IMSConstants.FieldConstants.IsCurrent & " = 1"
        Dim lstApplianceRegister As List(Of ApplianceRegister) = _proxy.GetFilteredApplianceRegister(sql).Cast(Of ApplianceRegister).ToList()

        If lstApplianceRegister.Count > 0 Then
            For Each objApplianceRegister As ApplianceRegister In lstApplianceRegister
                objApplianceRegister.IsCurrent = False
                _proxy.UpdateApplianceRegister(objApplianceRegister)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Method to Update all IsCurrent  to False (Employee wise). (Table Employee Register)
    ''' </summary>
    ''' <param name="employeeID"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateIsTrueForEmployeeRegister(ByVal employeeID As Integer)

        Dim _proxy As New IMSService.IMSServices

        Dim sql As String = IMSConstants.FieldConstants.EmployeeID & " = " & employeeID.ToString() & " and " & IMSConstants.FieldConstants.IsCurrent & " = 1"
        Dim lstEmployeeRegister As List(Of EmployeeRegister) = _proxy.GetFilteredEmployeeRegister(sql).Cast(Of EmployeeRegister).ToList()

        If lstEmployeeRegister.Count > 0 Then
            For Each objEmployeeRegister As EmployeeRegister In lstEmployeeRegister
                objEmployeeRegister.IsCurrent = False
                _proxy.UpdateEmployeeRegister(objEmployeeRegister)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Method to Get Latest Rocord of Employee Register
    ''' </summary>
    ''' <param name="employeeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLatestDataAtEmployeeRegister(ByVal employeeID As Integer) As EmployeeRegister

        Dim _proxy As New IMSService.IMSServices

        Dim sql As String = IMSConstants.FieldConstants.EmployeeID & " = " & employeeID.ToString() & " and " & IMSConstants.FieldConstants.IsCurrent & " = 1"
        Dim lstEmployeeRegister As List(Of EmployeeRegister) = _proxy.GetFilteredEmployeeRegister(sql).Cast(Of EmployeeRegister).ToList()

        If lstEmployeeRegister.Count > 0 Then
            Return lstEmployeeRegister(0)
        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' Method to Get Latest Entry of Appliance Register Table.
    ''' </summary>
    ''' <param name="stationApplianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLatestDataAtApplianceRegister(ByVal stationApplianceID As Integer) As ApplianceRegister

        Dim _proxy As New IMSService.IMSServices

        Dim sql As String = IMSConstants.FieldConstants.StationApplianceID & " = " & stationApplianceID.ToString() & " and " & IMSConstants.FieldConstants.IsCurrent & " = 1"
        Dim lstApplianceRegister As List(Of ApplianceRegister) = _proxy.GetFilteredApplianceRegister(sql).Cast(Of ApplianceRegister).ToList()

        If lstApplianceRegister.Count > 0 Then
            Return lstApplianceRegister(0)
        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' Method to Get all Incident of a specific station.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllIncidentOfSpeficStation(ByVal stationID As Integer) As List(Of IncidentRegister)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " <> " & CInt(IMSEnums.IsDeleted.Yes) & " and " & IMSConstants.FieldConstants.IncidentID & " In( select " & IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.StationIncident & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID.ToString() & ")"
        Dim lstIncidentRegister As List(Of IncidentRegister) = _proxy.GetFilteredIncidentRegister(sql).Cast(Of IncidentRegister).ToList()

        Return lstIncidentRegister

    End Function

    ''' <summary>
    ''' Method to Get Only Dispatched and UnderDispatched Incident of a specific station.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllIncidentDTPAndUDTPOfSpeficStation(ByVal stationID As Integer) As List(Of IncidentRegister)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " <> " & CInt(IMSEnums.IsDeleted.Yes) & " and " & IMSConstants.FieldConstants.IncidentStatus & " = " & CInt(IMSEnums.IncidentStatus.Dispatched) & " and " & IMSConstants.FieldConstants.IncidentID & " In( select " & IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.StationIncident & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID.ToString() & " )"
        Dim lstIncidentRegister As List(Of IncidentRegister) = _proxy.GetFilteredIncidentRegister(sql).Cast(Of IncidentRegister).ToList()

        Return lstIncidentRegister

    End Function

    ''' <summary>
    ''' Method to Get Only Dispatched and UnderDispatched Incident (for all station).
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllIncidentDTPAndUDTP() As List(Of IncidentRegister)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " <> " & CInt(IMSEnums.IsDeleted.Yes) & " and " & IMSConstants.FieldConstants.IncidentStatus & " = " & CInt(IMSEnums.IncidentStatus.Dispatched)
        Dim lstIncidentRegister As List(Of IncidentRegister) = _proxy.GetFilteredIncidentRegister(sql).Cast(Of IncidentRegister).ToList()

        Return lstIncidentRegister

    End Function

    ''' <summary>
    ''' Method to Get The Dispatched Appliance Quantity
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="applianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetDispatchedApplianceQuantityForThisIncident(ByVal incidentID As Integer, ByVal applianceID As Integer, ByVal incidentTypeID As Integer) As Integer
        Dim _proxy As New IMSService.IMSServices
        Dim lstAssignedAppliance As List(Of AssignedAppliance)

        Dim sql As String = String.Format("{0} = {1} and ({2} = {3} or {2} = {4}) and {9} <> {10} and {5} In (Select {5} from {6} where {11} <> 3 and {7} = {8})", IMSConstants.FieldConstants.IncidentID, incidentID, IMSConstants.FieldConstants.AssignedApplianceStatus, CInt(IMSEnums.ApplianceStatus.Dispatched), CInt(IMSEnums.ApplianceStatus.Redispatched), IMSConstants.FieldConstants.StationApplianceID, IMSConstants.TableNames.FireStationAppliance, IMSConstants.FieldConstants.ApplianceID, applianceID, IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Deleted))
        sql = IMSConstants.FieldConstants.IncidentTypeID & "=" & incidentTypeID.ToString() & " and " & sql

        lstAssignedAppliance = _proxy.GetFilteredAssignedAppliance(sql).Cast(Of AssignedAppliance).ToList()

        Return lstAssignedAppliance.Count

    End Function

    ''' <summary>
    ''' Method to Get all Types for a specific Incident
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAlltypesForSpecificIncident(ByVal incidentID As Integer) As List(Of ApplianceMapping)

        Dim _proxy As New IMSService.IMSServices
        Dim incidentTypeID As Integer = 0
        Dim lstApplianceMapping As New List(Of ApplianceMapping)
        Dim lstApplianceMappingForTypes As New List(Of ApplianceMapping)

        ''Get all types For an incident
        Dim sql As String = String.Format("{0} = {1}", IMSConstants.FieldConstants.IncidentID, incidentID)
        Dim lstincidentTypeIncident As List(Of IncidentTypeIncident) = _proxy.GetFilteredIncidentTypeIncident(sql).Cast(Of IncidentTypeIncident).ToList()

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

        Return lstApplianceMappingForTypes

    End Function

    ''' <summary>
    ''' Method to Get All categories by incident ID.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCategoriesForSpecificIncident(ByVal incidentID As Integer) As List(Of IMSService.IncidentCategory)

        Dim _proxy As New IMSService.IMSServices

        ''Get all Categories For an incident
        Dim sql As String = IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & " and " _
                            & IMSConstants.FieldConstants.CategoryID & " In ( select " & IMSConstants.FieldConstants.CategoryID _
                            & " From " & IMSConstants.TableNames.IncidentType & " where " & _
                            IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & " and " & _
        IMSConstants.FieldConstants.IncidentTypeID & " In ( select " & IMSConstants.FieldConstants.IncidentTypeID & _
        " from " & IMSConstants.TableNames.IncidentTypeIncident & " where " & IMSConstants.FieldConstants.IncidentID & " = " _
        & incidentID & " ))"

        Dim lstincidentCategory As List(Of IncidentCategory) = _proxy.GetFilteredIncidentCategory(sql).Cast(Of IncidentCategory).ToList()

        Return lstincidentCategory

    End Function

    Public Shared Function GetAllTypesOfSpecificIncident(ByVal incidentID As Integer) As List(Of IMSService.IncidentType)

        Dim _proxy As New IMSService.IMSServices
        Dim lstincidentTypeFiltered As New List(Of IncidentType)

        ''Get all Types For an incident
        Dim sql As String = IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & " and " & _
        IMSConstants.FieldConstants.IncidentTypeID & " In ( select " & IMSConstants.FieldConstants.IncidentTypeID & _
        " from " & IMSConstants.TableNames.IncidentTypeIncident & " where " & IMSConstants.FieldConstants.IncidentID & " = " _
        & incidentID & " )"

        Dim lstincidentType As List(Of IncidentType) = _proxy.GetFilteredIncidentType(sql).Cast(Of IncidentType).ToList()

        Return lstincidentType

    End Function

    ''' <summary>
    ''' Method to Get Two List item (1. for Is it Grass Fire and 2. Is others types But Grass Fire.)
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsGrassFireAndIsOthersFireTypes(ByVal incidentID As Integer) As List(Of Boolean)

        Dim _proxy As New IMSService.IMSServices
        Dim lstDecision As New List(Of Boolean)
        Dim lstincidentTypeFiltered As New List(Of IncidentType)

        ''Get all Categories For an incident
        Dim sql As String = IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & " and " & _
        IMSConstants.FieldConstants.IncidentTypeID & " In ( select " & IMSConstants.FieldConstants.IncidentTypeID & _
        " from " & IMSConstants.TableNames.IncidentTypeIncident & " where " & IMSConstants.FieldConstants.IncidentID & " = " _
        & incidentID & " )"

        Dim lstincidentType As List(Of IncidentType) = _proxy.GetFilteredIncidentType(sql).Cast(Of IncidentType).ToList()

        If lstincidentType.Count > 0 Then

            lstincidentTypeFiltered = lstincidentType.FindAll(Function(x) x.IncidentTypeCode = IMSConstants.Settings.GrassFireTypeCode)
            If lstincidentTypeFiltered.Count > 0 Then
                lstDecision.Add(True) ' This is Grass Fire
            Else
                lstDecision.Add(False)
            End If

            lstincidentTypeFiltered = lstincidentType.FindAll(Function(x) x.CategoryID = CInt(IMSEnums.IncidentCategory.Fire) And x.IncidentTypeCode <> IMSConstants.Settings.GrassFireTypeCode)
            If lstincidentTypeFiltered.Count > 0 Then
                lstDecision.Add(True) ' More types of Fire category (Other then  "Grass Fire")
            Else
                lstDecision.Add(False)
            End If

        End If

        Return lstDecision

    End Function

    ''' <summary>
    ''' Method to Get all types by category and incident
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="incidentCategoryID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIncidentTypesByCategoryAndIncidentID(ByVal incidentID As Integer, ByVal incidentCategoryID As Integer) As List(Of IMSService.IncidentType)

        Dim _proxy As New IMSService.IMSServices

        ''Get all types For an incident
        Dim sql As String = IMSConstants.FieldConstants.CategoryID & " = " & incidentCategoryID & " and " _
                              & IMSConstants.FieldConstants.IncidentTypeID & " In ( select " & _
                              IMSConstants.FieldConstants.IncidentTypeID & " from " & _
                              IMSConstants.TableNames.IncidentTypeIncident & _
                              " where " & IMSConstants.FieldConstants.IncidentID & " = " & incidentID & " )"

        Dim lstIncidentType As List(Of IMSService.IncidentType) = _proxy.GetFilteredIncidentType(sql).Cast(Of IMSService.IncidentType).ToList()

        Return lstIncidentType

    End Function

    ''' <summary>
    ''' Method to Get Current Checkout "Applicance Register"
    ''' </summary>
    ''' <param name="stationApplianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentCheckOut(ByVal stationApplianceID As Integer) As ApplianceRegister

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.StationApplianceID & " = " & stationApplianceID & " and " & IMSConstants.FieldConstants.IsCurrent & " = 1 and " & IMSConstants.FieldConstants.RegisterStatus & " = 0 "

        Dim lstApplianceRegister As List(Of ApplianceRegister) = _proxy.GetFilteredApplianceRegister(sql).Cast(Of ApplianceRegister).ToList()

        If lstApplianceRegister.Count > 0 Then
            Return lstApplianceRegister(0)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Method to Get Date Time of last Appliance Back to fire station
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeOfLastApplianceBackToStation(ByVal incidentID As Integer) As DateTime

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IncidentID & " = " & incidentID & " and " & IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.CheckedIn) _
                            & " order by " & IMSConstants.FieldConstants.InsertionDate & " desc"
        Dim lstApplianceRegister As List(Of IMSService.ApplianceRegister) = _proxy.GetFilteredApplianceRegister(sql).Cast(Of ApplianceRegister).ToList()

        If lstApplianceRegister.Count > 0 Then
            Return lstApplianceRegister(0).InsertionDate
        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' Method to Get the Date Time of First arrival of appliance.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTimeOfFirstArrivalOfFireService(ByVal incidentID As Integer) As DateTime

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IncidentID & " = " & incidentID & _
         " order by " & IMSConstants.FieldConstants.DispatchDate & " asc"
        Dim dateDefault As Date = Date.Parse(IMSConstants.Settings.DateTimeDefault)

        Dim lstDispatchLog As List(Of IMSService.DispatchLog) = _proxy.GetFilteredDispatchLog(sql).Cast(Of IMSService.DispatchLog).ToList()

        If lstDispatchLog.Count > 0 Then
            If lstDispatchLog(0).TimeOfArrival <> dateDefault Then
                Return lstDispatchLog(0).TimeOfArrival
            End If
        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' Method to Check All required vehicle is dispatched or not
    ''' </summary>
    ''' <param name="IncidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsAllRequiredVehicleDispatched(ByVal IncidentID As Integer) As Boolean

        Dim _proxy As New IMSService.IMSServices
        Dim objAppliance As New Appliance
        Dim lstApplianceMappingForTypes As New List(Of ApplianceMapping)
        Dim requiredQuantity As Integer = 0
        Dim dispatchedQuantity As Integer = 0
        'Dim IsAllVehicleDispatched As Boolean = True

        ''Get all types For an incident
        lstApplianceMappingForTypes = GetAlltypesForSpecificIncident(IncidentID)

        For Each objApplianceMapping As ApplianceMapping In lstApplianceMappingForTypes

            objAppliance = _proxy.GetApplianceByID(objApplianceMapping.ApplianceID)

            If Not IsNothing(objAppliance) Then
                If objAppliance.IsDeleted <> CInt(IMSEnums.Status.Deleted) Then

                    requiredQuantity = objApplianceMapping.Quantity
                    dispatchedQuantity = GetDispatchedApplianceQuantityForThisIncident(IncidentID, objAppliance.ApplianceID, objApplianceMapping.IncidentTypeID)

                    If requiredQuantity > dispatchedQuantity Then
                        ' IsAllVehicleDispatched = False
                        Return False
                    End If

                End If
            End If
        Next

        Return True

    End Function

    ''' <summary>
    ''' Method to Get All Under Dispatched Incident List (station wise)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllIncidentUnderDispatchedStationWise(ByVal stationID As Integer) As List(Of IncidentRegister)

        Dim lstIncidentUnderDispatched As New List(Of IncidentRegister)

        'Get All Incident status = dispatched (station wise)
        Dim lstIncidentDispatchedAndUnderDispatched As List(Of IncidentRegister) = GetAllIncidentDTPAndUDTPOfSpeficStation(stationID)

        If lstIncidentDispatchedAndUnderDispatched.Count > 0 Then

            For Each objIncident As IncidentRegister In lstIncidentDispatchedAndUnderDispatched
                If Not IsAllRequiredVehicleDispatched(objIncident.IncidentID) Then
                    lstIncidentUnderDispatched.Add(objIncident)
                End If
            Next
        End If

        Return lstIncidentUnderDispatched

    End Function

    ''' <summary>
    '''  Method to Get All Under Dispatched Incident List
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllIncidentUnderDispatched() As List(Of IncidentRegister)

        Dim lstIncidentUnderDispatched As New List(Of IncidentRegister)

        'Get All Incident status = dispatched 
        Dim lstIncidentDispatchedAndUnderDispatched As List(Of IncidentRegister) = GetAllIncidentDTPAndUDTP()

        If lstIncidentDispatchedAndUnderDispatched.Count > 0 Then

            For Each objIncident As IncidentRegister In lstIncidentDispatchedAndUnderDispatched
                If Not IsAllRequiredVehicleDispatched(objIncident.IncidentID) Then
                    lstIncidentUnderDispatched.Add(objIncident)
                End If
            Next
        End If

        Return lstIncidentUnderDispatched

    End Function

    '   ''' <summary>
    '   ''' Method to Get All Checked In Fire Station Appliance (With Appliance ID)
    '   ''' </summary>
    '   ''' <param name="applianceID"></param>
    '   ''' <returns></returns>
    '   ''' <remarks></remarks>
    ''   Public Shared Function GetAllCheckedInSpecificAppliance(applianceID As Integer) As List(Of FireStationAppliance)

    ''       Dim _proxy As New IMSService.IMSServices

    ''       'Get Available Fire station Appliance (With Appliance ID)
    ''       Dim sql As String = IMSConstants.FieldConstants.Status & " <> " & CInt(IMSEnums.Status.Deleted).ToString() & " and " & IMSConstants.FieldConstants.ApplianceID & " = " & applianceID.ToString() & " and " & IMSConstants.FieldConstants.StationApplianceID & " In( " & _
    ''" select " & IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & " where " & IMSConstants.FieldConstants.IsCurrent & " = 1 and " & IMSConstants.FieldConstants.RegisterStatus & " = 1 )"

    ''       Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()
    ''       Return lstAvailableAppliance

    ''   End Function

    ''' <summary>
    ''' Method to Get CheckedIn Vehicles Table.
    ''' </summary>
    ''' <param name="applianceID"></param>
    ''' <param name="dtCheckedInVehicle"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCheckedInVehicleTable(ByVal applianceID As Integer, ByVal dtCheckedInVehicle As DataTable) As DataTable

        Dim _proxy As New IMSService.IMSServices
        Dim row As DataRow
        Dim lstApplianceRegister As New List(Of ApplianceRegister)

        'Get Available Fire station Appliance (With Appliance ID)
        Dim sql As String = IMSConstants.FieldConstants.Status & " <> " & CInt(IMSEnums.Status.Deleted).ToString() & " and " & IMSConstants.FieldConstants.ApplianceID & " = " & applianceID.ToString() & " and " & IMSConstants.FieldConstants.StationApplianceID & " In( " & _
         " select " & IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & " where " & IMSConstants.FieldConstants.IsCurrent & " = 1 and " & _
         " ( " & IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.CheckedIn) & _
         " or " & IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.Parked) & " ) ) " _
         & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc "

        Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        If lstAvailableAppliance.Count > 0 Then

            For Each obj As FireStationAppliance In lstAvailableAppliance
                row = dtCheckedInVehicle.NewRow

                row(IMSConstants.FieldConstants.StationID) = obj.StationID
                row(IMSConstants.FieldConstants.StationApplianceID) = obj.StationApplianceID
                row(IMSConstants.FieldConstants.ApplianceID) = obj.ApplianceID
                row(IMSConstants.FieldConstants.SerialNumber) = obj.SerialNumber

                'Get Appliance Register By StationApplianceID checked In.
                sql = IMSConstants.FieldConstants.IsCurrent & " = 1 and ( " & _
                    IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.CheckedIn) & _
                   " or " & IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.Parked) & _
                    " ) and " & IMSConstants.FieldConstants.StationApplianceID & " = " & obj.StationApplianceID
                lstApplianceRegister = _proxy.GetFilteredApplianceRegister(sql).Cast(Of ApplianceRegister).ToList()

                If lstApplianceRegister.Count > 0 Then

                    With lstApplianceRegister(0)
                        row(IMSConstants.FieldConstants.Reason) = .Reason
                        row(IMSConstants.FieldConstants.IncidentID) = .IncidentID
                        row(IMSConstants.Common.CheckedInStationID) = .StationID
                    End With

                End If

                dtCheckedInVehicle.Rows.Add(row)
            Next

        End If

        Return dtCheckedInVehicle

    End Function

    ''' <summary>
    ''' Get All Checked IN Fire station Appliance (With CheckedIn Station ID)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInApplianceStationWise(ByVal stationID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices

        'Get Available Fire station Appliance (With Station ID)
        Dim sql As String = IMSConstants.FieldConstants.Status & " <> " & CInt(IMSEnums.Status.Deleted).ToString() & " and " & IMSConstants.FieldConstants.StationApplianceID & " In( " & _
 " select " & IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID.ToString() & "  and " & IMSConstants.FieldConstants.IsCurrent & " = 1 AND " & IMSConstants.FieldConstants.RegisterStatus & " =" & CInt(IMSEnums.RegisterStatus.CheckedIn) & ")"

        Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()
        Return lstAvailableAppliance

    End Function

    ''' <summary>
    ''' Get All Checked IN FireStation Appliance (With CheckedInStation ID and Appliance ID)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInApplianceStationAndApplianceIDWise(ByVal stationID As Integer, ByVal applianceID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices

        'Get Available Fire station Appliance (With Station ID)
        Dim sql As String = IMSConstants.FieldConstants.ApplianceID & " = " & applianceID & " and " & IMSConstants.FieldConstants.Status & " <> " & CInt(IMSEnums.Status.Deleted).ToString() & " and " & _
            IMSConstants.FieldConstants.StationApplianceID & " In( " & _
 " select " & IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister _
 & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID.ToString() & "  and " & IMSConstants.FieldConstants.IsCurrent & " = 1 AND " _
 & IMSConstants.FieldConstants.RegisterStatus & " =" & CInt(IMSEnums.RegisterStatus.CheckedIn) & ")" _
 & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc"


        Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()
        Return lstAvailableAppliance

    End Function

    ''' <summary>
    ''' Get All Checked IN and Parked FireStation Appliance (With CheckedInStation ID and Appliance ID)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInAndParkedApplianceStationAndApplianceIDWise(ByVal stationID As Integer, ByVal applianceID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices

        'Get Available Fire station Appliance (With Station ID)
        Dim sql As String = IMSConstants.FieldConstants.ApplianceID & " = " & applianceID & " and " & _
            IMSConstants.FieldConstants.Status & " <> " & CInt(IMSEnums.Status.Deleted).ToString() & " and " & _
            IMSConstants.FieldConstants.StationApplianceID & " In( " & _
             " select " & IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister _
             & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID.ToString() & "  and " & _
             IMSConstants.FieldConstants.IsCurrent & " = 1 AND ( " _
             & IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.CheckedIn) & " or " _
             & IMSConstants.FieldConstants.RegisterStatus & " = " & CInt(IMSEnums.RegisterStatus.Parked) & " ) " _
             & " ) order by " & IMSConstants.FieldConstants.SerialNumber & " asc"


        Dim lstAvailableAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()
        Return lstAvailableAppliance

    End Function

    ''' <summary>
    ''' Method To get all checked in employee (Station and Shift wise)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Public Shared Function GetAllCheckedInEmployeeStationAndShiftWise(ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

    '    Dim lstCheckedInEmployeeOtherDay As New List(Of Employee)
    '    Dim _proxy As New IMSService.IMSServices
    '    Dim sql As String = String.Format("{0} = {1} and {2} In (select {2} from {3} where {4} = {5} and {6} = {7} and {8} = {9} and {10} = {11} And {12} = '{13}')", _
    '                                    IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No), IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
    '                                    , IMSConstants.FieldConstants.StationID, stationID, IMSConstants.FieldConstants.RegisterStatus, _
    '                                   CInt(IMSEnums.RegisterStatus.CheckedIn), IMSConstants.FieldConstants.ShiftID, shiftID, IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), IMSConstants.FieldConstants.InsertionDate, Now.Date)

    '    sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

    '    Dim lstCheckedInEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

    '    ''Logic - some shift touch two days (then have to check the employee checked in with two date)
    '    Dim currentTime As TimeSpan = Now.TimeOfDay()
    '    If CommonFunction.GetShiftTouchedDay(shiftID, currentTime) = CInt(IMSEnums.ShiftTouchDays.ShiftTouchTwoDaysSecondPart) Then

    '        sql = String.Format("{0} <> {1} and {2} In (select {2} from {3} where {4} = {5} and {6} = {7} and {8} = {9} and {10} = {11} And {12} = '{13}')", _
    '                            IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
    '                            , IMSConstants.FieldConstants.StationID, stationID, IMSConstants.FieldConstants.RegisterStatus, _
    '                           CInt(IMSEnums.RegisterStatus.CheckedIn), IMSConstants.FieldConstants.ShiftID, shiftID, IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), IMSConstants.FieldConstants.InsertionDate, Now.Date.AddDays(-1))

    '        sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

    '        lstCheckedInEmployeeOtherDay = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

    '        If lstCheckedInEmployeeOtherDay.Count > 0 Then
    '            lstCheckedInEmployee.AddRange(lstCheckedInEmployeeOtherDay)
    '        End If

    '    End If

    '    Return lstCheckedInEmployee

    'End Function

    Public Shared Function GetFromDate(ByVal value As DateTime) As DateTime

        Return New DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0)

    End Function

    Public Shared Function GetToDate(ByVal value As DateTime) As DateTime

        Return New DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 999)

    End Function

    ''' <summary>
    ''' Method To get all checkedIn and Parked employee (Station and Shift wise)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInAndParkedEmployeeStationAndShiftWise(ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

        Dim lstCheckedInEmployeeOtherDay As New List(Of Employee)
        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = String.Format("{0} = {1} and {2} In (select {2} from {3} where {4} = {5} and ( {6} = {7} or {8} = {9} ) and {10} = {11} and {12} = {13} And {14} between '{15}' and '{16}')", _
                                        IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No), IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
                                        , IMSConstants.FieldConstants.StationID, stationID, _
                                        IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.CheckedIn), _
                                       IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.Parked), _
                                       IMSConstants.FieldConstants.ShiftID, shiftID, _
                                       IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), _
                                       IMSConstants.FieldConstants.InsertionDate, GetFromDate(Date.Now).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(Date.Now).ToString(IMSConstants.AppConstants.DateFormatToQuery))

        sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

        Dim lstCheckedInEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

        ''Logic - some shift touch two days (then have to check the employee checked in with two date)
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        If CommonFunction.GetShiftTouchedDay(shiftID, currentTime) = CInt(IMSEnums.ShiftTouchDays.ShiftTouchTwoDaysSecondPart) Then

            sql = String.Format("{0} <> {1} and {2} In (select {2} from {3} where {4} = {5} and ( {6} = {7} or {8} = {9} ) and {10} = {11} and {12} = {13} And {14} between '{15}' and '{16}')", _
                                IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), _
                                IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
                                , IMSConstants.FieldConstants.StationID, stationID, _
                                IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.CheckedIn), _
                                IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.Parked), _
                               IMSConstants.FieldConstants.ShiftID, shiftID, _
                               IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), _
                               IMSConstants.FieldConstants.InsertionDate, GetFromDate(Now.Date.AddDays(-1)).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(Now.Date.AddDays(-1)).ToString(IMSConstants.AppConstants.DateFormatToQuery))

            sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

            lstCheckedInEmployeeOtherDay = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

            If lstCheckedInEmployeeOtherDay.Count > 0 Then
                lstCheckedInEmployee.AddRange(lstCheckedInEmployeeOtherDay)
            End If

        End If

        Return lstCheckedInEmployee

    End Function

    ''' <summary>
    ''' Method to Get all Checked in Employee at a station.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInEmployeeStationAndShiftWise(ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

        Dim lstCheckedInEmployeeOtherDay As New List(Of Employee)
        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = String.Format("{0} = {1} and {2} In (select {2} from {3} where {4} = {5}  and {6} = {7} and {8} = {9} and {10} = {11} and {12} between '{13}' and '{14}')", _
                                        IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No), _
                                        IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
                                        , IMSConstants.FieldConstants.StationID, stationID, _
                                        IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.CheckedIn), _
                                        IMSConstants.FieldConstants.ShiftID, shiftID, _
                                       IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), _
                                       IMSConstants.FieldConstants.InsertionDate, GetFromDate(Now.Date).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(Now.Date).ToString(IMSConstants.AppConstants.DateFormatToQuery))

        sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

        Dim lstCheckedInEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

        ''Logic - some shift touch two days (then have to check the employee checked in with two date)
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        If CommonFunction.GetShiftTouchedDay(shiftID, currentTime) = CInt(IMSEnums.ShiftTouchDays.ShiftTouchTwoDaysSecondPart) Then

            sql = String.Format("{0} <> {1} and {2} In (select {2} from {3} where {4} = {5} and {6} = {7} and {8} = {9} and {10} = {11} and {12} between '{13}' and '{14}')", _
                                IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), _
                                IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
                                , IMSConstants.FieldConstants.StationID, stationID, _
                                IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.CheckedIn), _
                                IMSConstants.FieldConstants.ShiftID, shiftID, _
                                IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), _
                                IMSConstants.FieldConstants.InsertionDate, GetFromDate(Now.Date.AddDays(-1)).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(Now.Date.AddDays(-1)).ToString(IMSConstants.AppConstants.DateFormatToQuery))

            sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

            lstCheckedInEmployeeOtherDay = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

            If lstCheckedInEmployeeOtherDay.Count > 0 Then
                lstCheckedInEmployee.AddRange(lstCheckedInEmployeeOtherDay)
            End If

        End If

        Return lstCheckedInEmployee

    End Function

    ''' <summary>
    ''' Method to Get all checkedIn Specific group (GroupID) employee with (StationID and Shift ID)
    ''' </summary>
    ''' <param name="groupID"></param>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInEmployeeGroupAndStationAndShiftWise(ByVal groupID As Integer, ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

        Dim lstCheckedInEmployeeOtherDay As New List(Of Employee)
        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = String.Format("{0} = {1} and {2} In (select {2} from {3} where {4} = {5}  and {6} = {7} and {8} = {9} and {10} = {11} and  {12} = {13} and {14} between '{15}' and '{16}')", _
                                        IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No), _
                                        IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
                                        , IMSConstants.FieldConstants.StationID, stationID, _
                                        IMSConstants.FieldConstants.GroupID, groupID, _
                                        IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.CheckedIn), _
                                        IMSConstants.FieldConstants.ShiftID, shiftID, _
                                       IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), _
                                       IMSConstants.FieldConstants.InsertionDate, GetFromDate(Now.Date).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(Now.Date).ToString(IMSConstants.AppConstants.DateFormatToQuery))

        sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

        Dim lstCheckedInEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

        ''Logic - some shift touch two days (then have to check the employee checked in with two date)
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        If CommonFunction.GetShiftTouchedDay(shiftID, currentTime) = CInt(IMSEnums.ShiftTouchDays.ShiftTouchTwoDaysSecondPart) Then

            sql = String.Format("{0} <> {1} and {2} In (select {2} from {3} where {4} = {5} and {6} = {7} and {8} = {9} and {10} = {11} and {12} = {13} and {14} between '{15}' and '{16}')", _
                                IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), _
                                IMSConstants.FieldConstants.EmployeeID, IMSConstants.TableNames.EmployeeRegister _
                                , IMSConstants.FieldConstants.StationID, stationID, _
                                IMSConstants.FieldConstants.GroupID, groupID, _
                                IMSConstants.FieldConstants.RegisterStatus, CInt(IMSEnums.RegisterStatus.CheckedIn), _
                                IMSConstants.FieldConstants.ShiftID, shiftID, _
                                IMSConstants.FieldConstants.IsCurrent, CInt(IMSEnums.IsDeleted.Yes), _
                                IMSConstants.FieldConstants.InsertionDate, GetFromDate(Now.Date.AddDays(-1)).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(Now.Date.AddDays(-1)).ToString(IMSConstants.AppConstants.DateFormatToQuery))

            sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

            lstCheckedInEmployeeOtherDay = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

            If lstCheckedInEmployeeOtherDay.Count > 0 Then
                lstCheckedInEmployee.AddRange(lstCheckedInEmployeeOtherDay)
            End If

        End If

        Return lstCheckedInEmployee

    End Function

    ''' <summary>
    ''' Method to Get all specific station employee of a group
    ''' </summary>
    ''' <param name="groupID"></param>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllGroupEmployee(ByVal groupID As Integer, ByVal stationID As Integer) As List(Of Employee)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.GroupID & " = " & groupID & " and " & _
                             IMSConstants.FieldConstants.StationID & " = " & stationID & _
        " and " & IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No)

        sql = sql & " order by  " & IMSConstants.FieldConstants.EmployeeName & " asc"

        Dim lstGroupEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

        Return lstGroupEmployee

    End Function

    ''' <summary>
    ''' Method to Get All Not CheckedIn (ie. Checkout and Parked) Employee (Group , Station and shift wise)
    ''' </summary>
    ''' <param name="groupID"></param>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllNotCheckedInEmployeeGroupAndStationAndShiftWise(ByVal groupID As Integer, ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

        Dim lstNotCheckedInEmployee As New List(Of Employee)
        Dim _proxy As New IMSService.IMSServices
        Dim lstCheckedInEmployee As List(Of Employee) = GetAllCheckedInEmployeeGroupAndStationAndShiftWise(groupID, stationID, shiftID)
        Dim lstGroupEmployee As List(Of Employee) = GetAllGroupEmployee(groupID, stationID)

        If lstGroupEmployee.Count > 0 Then

            For Each objEmployee As Employee In lstGroupEmployee
                If IsNothing(lstCheckedInEmployee.Where(Function(f) f.EmployeeID = objEmployee.EmployeeID).FirstOrDefault()) Then
                    lstNotCheckedInEmployee.Add(objEmployee)
                End If
            Next

        End If

        Return lstNotCheckedInEmployee

    End Function

    ''' <summary>
    ''' Get all Not Checkedin station employee (causion: this method is not checking whether this employee is checked in at others station)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="shiftID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllNotCheckedInEmployeeStationAndShiftWise(ByVal stationID As Integer, ByVal shiftID As Integer) As List(Of Employee)

        Dim lstNotCheckedInEmployee As New List(Of Employee)
        Dim _proxy As New IMSService.IMSServices
        Dim lstCheckedInEmployee As List(Of Employee) = GetAllCheckedInEmployeeStationAndShiftWise(stationID, shiftID)
        Dim lstGroupEmployee As List(Of Employee) = GetAllActiveEmployeeByStation(stationID)

        If lstGroupEmployee.Count > 0 Then

            For Each objEmployee As Employee In lstGroupEmployee
                If IsNothing(lstCheckedInEmployee.Where(Function(f) f.EmployeeID = objEmployee.EmployeeID).FirstOrDefault()) Then
                    lstNotCheckedInEmployee.Add(objEmployee)
                End If
            Next

        End If

        Return lstNotCheckedInEmployee

    End Function

    ''' <summary>
    ''' Method to Get all Active station employee
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllActiveEmployeeByStation(ByVal stationID As Integer) As List(Of Employee)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) _
                            & " and " & IMSConstants.FieldConstants.StationID & " = " & stationID

        Dim lstStationEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(sql).Cast(Of Employee).ToList()

        Return lstStationEmployee

    End Function

    ''' <summary>
    ''' Method to Get First dispatched vehicle from "Dispatch Log" table.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFirstDispatchTime(ByVal incidentID As Integer) As DateTime

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IncidentID & " = " & incidentID

        Dim lstDispatchLog As List(Of DispatchLog) = _proxy.GetFilteredDispatchLog(sql).Cast(Of DispatchLog).ToList()

        If lstDispatchLog.Count > 0 Then
            Return lstDispatchLog(0).DispatchDate
        End If

        Return Convert.ToDateTime("1/1/0001")

    End Function

    ' ''' <summary>
    ' ''' Method to Get Shift ID By Station ID.
    ' ''' </summary>
    ' ''' <param name="stationID"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared Function GetShiftIDByStationID(ByVal stationID As Integer) As Integer

    '    Dim _proxy As New IMSService.IMSServices
    '    Dim shiftID As Integer = 0
    '    Dim strSQL As String = IMSConstants.FieldConstants.StationID & "='" & stationID & "' AND (Convert(datetime," & IMSConstants.FieldConstants.ShiftStartTime & "))<=(Convert(datetime,'" & Now.TimeOfDay.ToString().Substring(0, 8) & "')) AND (Convert(datetime," & IMSConstants.FieldConstants.ShiftEndTime & ")) > (Convert(datetime,'" & Now.TimeOfDay.ToString().Substring(0, 8) & "'))"
    '    Dim objShift As IMSService.Shift = _proxy.GetFilteredShift(strSQL).Cast(Of IMSService.Shift).ToList().FirstOrDefault

    '    If Not IsNothing(objShift) Then
    '        shiftID = objShift.ShiftID
    '    End If

    '    Return shiftID

    'End Function

    ''' <summary>
    ''' Method to Get Shift ID By Station ID.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetShiftIDByStationIDAndTime(ByVal stationID As Integer, ByVal currentTime As TimeSpan) As Integer

        Dim _proxy As New IMSService.IMSServices
        Dim shiftID As Integer = 0
        'Dim strSQL As String = IMSConstants.FieldConstants.Status & " <> '" & CInt(IMSEnums.Status.Deleted) & "' AND " & IMSConstants.FieldConstants.StationID & "='" & stationID & "' AND (Convert(datetime," & IMSConstants.FieldConstants.ShiftStartTime & "))<=(Convert(datetime,'" & Now.TimeOfDay.ToString().Substring(0, 8) & "')) AND (Convert(datetime," & IMSConstants.FieldConstants.ShiftEndTime & ")) > (Convert(datetime,'" & Now.TimeOfDay.ToString().Substring(0, 8) & "'))"
        ' Dim objShift As IMSService.Shift = _proxy.GetFilteredShift(strSQL).Cast(Of IMSService.Shift).ToList().FirstOrDefault
        Dim startTime As TimeSpan
        Dim endTime As TimeSpan
        'Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim midNightTimeEnd As TimeSpan = TimeSpan.Parse("23:59:59")
        Dim midNightTimeStart As TimeSpan = TimeSpan.Parse("00:00:01")

        Dim strSQL As String = IMSConstants.FieldConstants.StationID & " = " & stationID & " and " & IMSConstants.FieldConstants.Status & " <> " & CInt(IMSEnums.Status.Deleted)
        Dim lstShift As List(Of IMSService.Shift) = _proxy.GetFilteredShift(strSQL).Cast(Of IMSService.Shift).ToList()

        If lstShift.Count > 0 Then

            For Each objShift As Shift In lstShift

                startTime = TimeSpan.Parse(objShift.ShiftStartTime)
                endTime = TimeSpan.Parse(objShift.ShiftEndTime)
                'Logic :: Taking One second minus from original End time (Because End time should be one second before the showing time)
                endTime = endTime - TimeSpan.Parse("00:00:01")

                If startTime > endTime Then
                    'if cross Mid night
                    If currentTime >= startTime And currentTime <= midNightTimeEnd Then
                        shiftID = objShift.ShiftID
                    ElseIf currentTime >= midNightTimeStart And currentTime <= endTime Then
                        shiftID = objShift.ShiftID
                    End If
                Else
                    If currentTime >= startTime And currentTime <= endTime Then
                        shiftID = objShift.ShiftID
                    End If

                End If
            Next
        End If

        Return shiftID

    End Function

    ''' <summary>
    ''' Method to  check given time is belongs to a shift that (the shift) is touching two or single day.
    ''' </summary>
    ''' <param name="shiftID"></param>
    ''' <param name="currentTime"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetShiftTouchedDay(ByVal shiftID As Integer, ByVal currentTime As TimeSpan) As Integer

        Dim shiftTouchStatus As Integer
        Dim _proxy As New IMSService.IMSServices
        Dim startTime As TimeSpan
        Dim endTime As TimeSpan
        Dim midNightTimeEnd As TimeSpan = TimeSpan.Parse("23:59:59")
        Dim midNightTimeStart As TimeSpan = TimeSpan.Parse("00:00:01")

        Dim objShift As Shift = _proxy.GetShiftByID(shiftID)
        If Not IsNothing(objShift) Then

            startTime = TimeSpan.Parse(objShift.ShiftStartTime)
            endTime = TimeSpan.Parse(objShift.ShiftEndTime)

            If startTime < endTime Then
                shiftTouchStatus = CInt(IMSEnums.ShiftTouchDays.ShiftTouchSingleDay)
            Else
                'if cross Mid night
                If currentTime >= startTime And currentTime <= midNightTimeEnd Then
                    shiftTouchStatus = CInt(IMSEnums.ShiftTouchDays.ShiftTouchTwoDaysFirstPart)
                ElseIf currentTime >= midNightTimeStart And currentTime <= endTime Then
                    shiftTouchStatus = CInt(IMSEnums.ShiftTouchDays.ShiftTouchTwoDaysSecondPart)
                End If
            End If

        End If

        Return shiftTouchStatus

    End Function

    ''' <summary>
    ''' Method to Check email validation.
    ''' </summary>
    ''' <param name="emailAddress"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsValidEmailFormat(ByVal emailAddress As String) As Boolean

        Return Regex.IsMatch(emailAddress, IMSConstants.AppConstants.EmailValidation)

    End Function

    ''' <summary>
    ''' Method to Get Incident Type in comma separated (If multiple types)
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIncidentTypesInCommaSeparated(ByVal incidentID As Integer) As String

        Dim Sql As String = String.Empty
        Dim strIncidentType As String = String.Empty
        Dim lstIncidentTypeIncident As New List(Of IncidentTypeIncident)
        Dim _proxy As New IMSService.IMSServices

        'Get Incident type
        Sql = String.Format("{0} = {1}", IMSConstants.FieldConstants.IncidentID, incidentID)
        lstIncidentTypeIncident = _proxy.GetFilteredIncidentTypeIncident(Sql).Cast(Of IncidentTypeIncident).ToList()

        If lstIncidentTypeIncident.Count > 0 Then

            strIncidentType = String.Empty

            For Each IncidentTypeIncident As IncidentTypeIncident In lstIncidentTypeIncident

                If IncidentTypeIncident.IncidentTypeID > 0 Then

                    Dim objIncidentType As IncidentType = _proxy.GetIncidentTypeByID(IncidentTypeIncident.IncidentTypeID)

                    If Not IsNothing(objIncidentType) Then
                        If Not String.IsNullOrEmpty(strIncidentType) Then
                            strIncidentType = strIncidentType + " ; " + objIncidentType.IncidentTypeDescription
                        Else
                            strIncidentType = objIncidentType.IncidentTypeDescription
                        End If
                    Else
                        If String.IsNullOrEmpty(strIncidentType) Then
                            strIncidentType = String.Empty
                        End If
                    End If

                Else
                    If String.IsNullOrEmpty(strIncidentType) Then
                        strIncidentType = String.Empty
                    End If
                End If
            Next
        End If

        Return strIncidentType

    End Function

    ''' <summary>
    ''' Method to Get Satation names in comma separated value By IncidentID.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetStationsInCommaSeparated(ByVal incidentID As Integer) As String

        Dim sql As String = String.Empty
        Dim strStationName As New StringBuilder
        Dim lstFireStation As New List(Of FireStation)
        Dim _proxy As New IMSService.IMSServices

        'Get Stations
        sql = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & " and " & IMSConstants.FieldConstants.StationID & "  In( select " & _
           IMSConstants.FieldConstants.StationID & " from " & IMSConstants.TableNames.StationIncident & " where " & _
           IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ") "

        lstFireStation = _proxy.GetFilteredFireStation(sql).Cast(Of FireStation).ToList()

        If lstFireStation.Count > 0 Then

            For Each objFireStation As FireStation In lstFireStation

                If Not String.IsNullOrEmpty(strStationName.ToString()) Then
                    strStationName.Append(" , ")
                    strStationName.Append(objFireStation.StationName)
                Else
                    strStationName.Append(objFireStation.StationName)
                End If

            Next
        End If

        Return strStationName.ToString()

    End Function

    ''' <summary>
    ''' Method to Check is this Vehicle (WIth serial number) is occupied with any incident.
    ''' </summary>
    ''' <param name="vehicleSerialNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsVehicleOccupied(ByVal vehicleSerialNumber As String) As Boolean

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & " and ( " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & _
            IMSEnums.ApplianceStatus.Dispatched & " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & IMSEnums.ApplianceStatus.Redispatched & " )" _
            & " and " & IMSConstants.FieldConstants.StationApplianceID & " In ( select " & _
            IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.FireStationAppliance _
            & " where " & IMSConstants.FieldConstants.Status & " = 1 and " & IMSConstants.FieldConstants.SerialNumber & " = '" & vehicleSerialNumber & "'  )"

        Dim lstAssignedAppliance As List(Of AssignedAppliance) = _proxy.GetFilteredAssignedAppliance(sql).Cast(Of AssignedAppliance).ToList()

        If lstAssignedAppliance.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to Check Is employee occupied somewhere's else. 
    ''' </summary>
    ''' <param name="employeeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsEmployeeOccupied(ByVal employeeID As Integer) As Boolean

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & " and ( " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & _
            IMSEnums.ApplianceStatus.Dispatched & " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & IMSEnums.ApplianceStatus.Redispatched & " )" _
            & " and " & IMSConstants.FieldConstants.EmployeeID & " = " & employeeID

        Dim lstAssignedEmployee As List(Of AssignedEmployee) = _proxy.GetFilteredAssignedEmployee(sql).Cast(Of AssignedEmployee).ToList()

        If lstAssignedEmployee.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to Make emolpoyee "Available"
    ''' </summary>
    ''' <param name="employeeID"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateEmployeeOccupied(ByVal employeeID As Integer)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & " and ( " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & _
            IMSEnums.ApplianceStatus.Dispatched & " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & IMSEnums.ApplianceStatus.Redispatched & " )" _
            & " and " & IMSConstants.FieldConstants.EmployeeID & " = " & employeeID

        Dim lstAssignedEmployee As List(Of IMSService.AssignedEmployee) = _proxy.GetFilteredAssignedEmployee(sql).Cast(Of IMSService.AssignedEmployee).ToList()

        If lstAssignedEmployee.Count > 0 Then

            For Each objAssignedEmployee As AssignedEmployee In lstAssignedEmployee
                objAssignedEmployee.AssignedEmployeeStatus = IMSEnums.ApplianceStatus.Available
                _proxy.UpdateAssignedEmployee(objAssignedEmployee)
            Next

        End If

    End Sub

    ''' <summary>
    ''' Method to make employee available from all incident (this is when employee check in or checkin event)
    ''' </summary>
    ''' <param name="employeeID"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateEmployeeOccupiedToAvailable(ByVal employeeID As Integer)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & _
            " and " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " <> " & IMSEnums.ApplianceStatus.Available & _
            " and " & IMSConstants.FieldConstants.EmployeeID & " = " & employeeID

        Dim lstAssignedEmployee As List(Of IMSService.AssignedEmployee) = _proxy.GetFilteredAssignedEmployee(sql).Cast(Of IMSService.AssignedEmployee).ToList()

        If lstAssignedEmployee.Count > 0 Then

            For Each objAssignedEmployee As AssignedEmployee In lstAssignedEmployee
                objAssignedEmployee.AssignedEmployeeStatus = IMSEnums.ApplianceStatus.Available
                _proxy.UpdateAssignedEmployee(objAssignedEmployee)
            Next

        End If

    End Sub

    ''' <summary>
    ''' Method to Make Assigned Appliance status "Available".
    ''' </summary>
    ''' <param name="stationApplianceID"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateAssinedApplience(stationApplianceID As Integer)
        Dim _proxy As New IMSService.IMSServices
        Dim lstAssignedApplience As New List(Of IMSService.AssignedAppliance)
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & " and ( " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & _
            IMSEnums.ApplianceStatus.Dispatched & " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & IMSEnums.ApplianceStatus.Redispatched & " )" _
            & " and " & IMSConstants.FieldConstants.StationApplianceID & "=" & stationApplianceID

        lstAssignedApplience = _proxy.GetFilteredAssignedAppliance(strSQL).Cast(Of IMSService.AssignedAppliance).ToList()

        If lstAssignedApplience.Count > 0 Then
            For Each objAssignedApplience As IMSService.AssignedAppliance In lstAssignedApplience
                objAssignedApplience.AssignedApplianceStatus = IMSEnums.ApplianceStatus.Available
                _proxy.UpdateAssignedAppliance(objAssignedApplience)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Method to Update THis appliance Free from all involved Incident (As it check in manualy or by event)
    ''' </summary>
    ''' <param name="stationApplianceID"></param>
    ''' <remarks></remarks>
    Public Shared Sub UpdateAssinedApplienceToAvailable(stationApplianceID As Integer)
        Dim _proxy As New IMSService.IMSServices
        Dim lstAssignedApplience As New List(Of IMSService.AssignedAppliance)
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & _
            " and  " & IMSConstants.FieldConstants.AssignedApplianceStatus & " <> " & _
            IMSEnums.ApplianceStatus.Available & " and " & IMSConstants.FieldConstants.StationApplianceID & "=" & stationApplianceID

        lstAssignedApplience = _proxy.GetFilteredAssignedAppliance(strSQL).Cast(Of IMSService.AssignedAppliance).ToList()

        If lstAssignedApplience.Count > 0 Then
            For Each objAssignedApplience As IMSService.AssignedAppliance In lstAssignedApplience
                objAssignedApplience.AssignedApplianceStatus = IMSEnums.ApplianceStatus.Available
                _proxy.UpdateAssignedAppliance(objAssignedApplience)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Method to Check out Vehicle 
    ''' </summary>
    ''' <param name="stationApplianceID"></param>
    ''' <param name="reason"></param>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Public Shared Sub CheckOutVehicle(ByVal stationApplianceID As Integer, ByVal reason As String, ByVal incidentID As Integer)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsCurrent & " = " & CInt(IMSEnums.IsDeleted.Yes) & " and " & _
            IMSConstants.FieldConstants.StationApplianceID & " = " & stationApplianceID & " and " & _
            IMSConstants.FieldConstants.RegisterStatus & " = " & IMSEnums.RegisterStatus.CheckedIn

        Dim lstapplianceRegister As List(Of ApplianceRegister) = _proxy.GetFilteredApplianceRegister(sql).Cast(Of ApplianceRegister).ToList()

        If lstapplianceRegister.Count > 0 Then

            For Each obj As ApplianceRegister In lstapplianceRegister

                With obj
                    .RegisterStatus = CInt(IMSEnums.RegisterStatus.CheckedOut)
                    .Reason = reason
                    .IncidentID = incidentID
                End With

                _proxy.UpdateApplianceRegister(obj)
            Next

        End If
    End Sub

    ''' <summary>
    ''' Method to Get Table of  All station for combo.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetTableForStationDropDown() As DataTable

        Dim _proxy As New IMSService.IMSServices
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

        Return dtStation

    End Function

    ''' <summary>
    ''' Method to Get Employee table for combo by station ID.
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetEmployeeTableForComboByStationID(ByVal stationID As Integer) As DataTable

        Dim _proxy As New IMSService.IMSServices
        Dim tblEmployee As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.StationID & "=" & stationID & " And " & IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & "EmployeeName ASC"

        tblEmployee.Columns.Add(IMSConstants.FieldConstants.EmployeeID)
        tblEmployee.Columns.Add(IMSConstants.FieldConstants.EmployeeCode)
        tblEmployee.Columns.Add(IMSConstants.FieldConstants.EmployeeName)

        For Each obj As IMSService.Employee In _proxy.GetFilteredEmployee(strSQL)
            Dim row As DataRow = tblEmployee.NewRow
            row(IMSConstants.FieldConstants.EmployeeID) = obj.EmployeeID
            row(IMSConstants.FieldConstants.EmployeeCode) = obj.EmployeeCode
            row(IMSConstants.FieldConstants.EmployeeName) = obj.EmployeeName

            tblEmployee.Rows.Add(row)
        Next
        Dim rows As DataRow = tblEmployee.NewRow
        rows(IMSConstants.FieldConstants.EmployeeID) = String.Empty
        rows(IMSConstants.FieldConstants.EmployeeName) = String.Empty
        tblEmployee.Rows.InsertAt(rows, 0)

        Return tblEmployee

    End Function

    ''' <summary>
    ''' Method to Get Employee Table  of the User (By user ID)
    ''' </summary>
    ''' <param name="userID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetEmployeeByUserID(ByVal userID As String) As Employee

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & " = " & IMSEnums.IsDeleted.No & " and " & IMSConstants.FieldConstants.EmployeeID & _
            " In ( Select " & IMSConstants.FieldConstants.EmployeeID & " from " & IMSConstants.TableNames.EmployeeUser & " Where " & _
            IMSConstants.FieldConstants.UserID & " = '" & userID & "' ) "

        Dim lstEmployee As List(Of Employee) = _proxy.GetFilteredEmployee(strSQL).Cast(Of Employee).ToList()

        If lstEmployee.Count > 0 Then
            Return lstEmployee(0)
        End If

        Return Nothing

    End Function

    ''' <summary>
    ''' Method to Check Is this form already open
    ''' </summary>
    ''' <param name="formName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsFormOpen(ByVal formName As String) As Boolean

        Dim BolFlag As Boolean
        'Dim obj As Form
        Dim i As Int16
        Try

            For i = 0 To frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs.Count - 1
                If frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Name = formName Then
                    BolFlag = True
                End If
            Next
        Catch ex As Exception
            BolFlag = False
        End Try

        Return BolFlag

    End Function

    ''' <summary>
    ''' Method to Chcek Logged in user is super admin or not.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function IsSuperAdmin() As Boolean

        If LoginSecurity.UserRight = IMSConstants.Settings.SupperAdminID Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to Get Reference Number By Incident ID.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetReferenceNumberByIncidentID(ByVal incidentID As Integer) As String

        Dim _proxy As New IMSService.IMSServices
        Dim incident As IMSService.IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)

        If Not IsNothing(incident) Then
            Return incident.ReferenceNo
        Else
            Return 0
        End If

    End Function

    ''' <summary>
    ''' Method to get primary fire station for an Incident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPrimaryStationByIncidentID(ByVal incidentID As Integer) As IMSService.FireStation

        Dim _proxy As New IMSService.IMSServices
        Dim sql = IMSConstants.FieldConstants.StationID & " In ( select " & _
        IMSConstants.FieldConstants.StationID & " from " & IMSConstants.TableNames.StationIncident & _
        " where " & IMSConstants.FieldConstants.IsPrimaryStation & " = 1 and " & IMSConstants.FieldConstants.IncidentID & _
        " = " & incidentID & " ) "

        Dim lstStation As List(Of IMSService.FireStation) = _proxy.GetFilteredFireStation(sql).Cast(Of IMSService.FireStation).ToList()

        If lstStation.Count > 0 Then
            Return lstStation(0)
        End If

        Return Nothing
    End Function

    ''' <summary>
    ''' Method to Get Latest Dispatch Log By Incident ID and StationApplianceID.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="stationApplianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLatestDispatchLogByIncidentIDAndStationApplianceID(ByVal incidentID As Integer, ByVal stationApplianceID As Integer) As IMSService.DispatchLog

        Dim _proxy As New IMSService.IMSServices
        Dim sql = IMSConstants.FieldConstants.IncidentID & " = " & incidentID & " and " & IMSConstants.FieldConstants.StationApplianceID & " = " & stationApplianceID _
                  & " order by " & IMSConstants.FieldConstants.DispatchDate & " desc"


        Dim lstDispatchLog As List(Of DispatchLog) = _proxy.GetFilteredDispatchLog(sql).Cast(Of DispatchLog).ToList()

        If lstDispatchLog.Count > 0 Then
            Return lstDispatchLog(0)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Method to Get Time of First Appliance arrival time at incident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="stationApplianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetFirstDispatchLogByIncidentIDAndStationApplianceID(ByVal incidentID As Integer, ByVal stationApplianceID As Integer) As IMSService.DispatchLog

        Dim _proxy As New IMSService.IMSServices
        Dim sql = IMSConstants.FieldConstants.IncidentID & " = " & incidentID & " and " & IMSConstants.FieldConstants.StationApplianceID & " = " & stationApplianceID _
                  & " order by " & IMSConstants.FieldConstants.DispatchDate & " asc"

        Dim lstDispatchLog As List(Of DispatchLog) = _proxy.GetFilteredDispatchLog(sql).Cast(Of DispatchLog).ToList()

        If lstDispatchLog.Count > 0 Then
            Return lstDispatchLog(0)
        Else
            Return Nothing
        End If

    End Function

    ''' <summary>
    ''' Method to Get Fire Station Appliance.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetApplienceByIncidentID(ByVal incidentID As Integer) As List(Of IMSService.FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.Status & " = " & IMSEnums.Status.Active & " And " & _
            IMSConstants.FieldConstants.StationApplianceID & " IN ( SELECT " & IMSConstants.FieldConstants.StationApplianceID _
                        & " FROM " & IMSConstants.TableNames.AssignedAppliance & " WHERE " & _
                        IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And " & _
                        IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstFireStationAppliance As List(Of IMSService.FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(strSQL).Cast(Of IMSService.FireStationAppliance).ToList()

        Return lstFireStationAppliance

    End Function

    ''' <summary>
    ''' Method to Get involved appliance in comma separated.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCommaSeparatedApplienceByIncidentID(ByVal incidentID As Integer) As String

        Dim applianceStr As String = String.Empty
        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.Status & " = " & IMSEnums.Status.Active & " And " & _
            IMSConstants.FieldConstants.StationApplianceID & " IN ( SELECT " & IMSConstants.FieldConstants.StationApplianceID _
                        & " FROM " & IMSConstants.TableNames.AssignedAppliance & " WHERE " & _
                        IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And " & _
                        IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstFireStationAppliance As List(Of IMSService.FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(strSQL).Cast(Of IMSService.FireStationAppliance).ToList()

        For Each objFireStationAppliance As IMSService.FireStationAppliance In lstFireStationAppliance

            If String.IsNullOrEmpty(applianceStr) Then
                applianceStr = objFireStationAppliance.SerialNumber
            Else
                applianceStr += " , " + objFireStationAppliance.SerialNumber
            End If
        Next

        Return applianceStr

    End Function

    ''' <summary>
    ''' Method to Get Currently involved  (Without available) appliance at an incident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentlyInvolvedApplienceByIncidentID(incidentID As Integer) As List(Of IMSService.FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.Status & " = " & IMSEnums.Status.Active & " And " & _
            IMSConstants.FieldConstants.StationApplianceID & " IN ( SELECT " & IMSConstants.FieldConstants.StationApplianceID _
                        & " FROM " & IMSConstants.TableNames.AssignedAppliance & " WHERE " & _
                        IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And ( " & _
                        IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Dispatched) & _
                        " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Revoked) & _
                        " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Parked) & _
                       " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Redispatched) & " ) and " & _
                        IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstFireStationAppliance As List(Of IMSService.FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(strSQL).Cast(Of IMSService.FireStationAppliance).ToList()

        Return lstFireStationAppliance

    End Function

    ''' <summary>
    ''' Method to Get all involved Appliance (Without available and Parked)
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentlyInvolvedButParkedApplienceByIncidentID(incidentID As Integer) As List(Of IMSService.FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.Status & " = " & IMSEnums.Status.Active & " And " & _
            IMSConstants.FieldConstants.StationApplianceID & " IN ( SELECT " & IMSConstants.FieldConstants.StationApplianceID _
                        & " FROM " & IMSConstants.TableNames.AssignedAppliance & " WHERE " & _
                        IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And ( " & _
                        IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Dispatched) & _
                        " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Revoked) & _
                       " or " & IMSConstants.FieldConstants.AssignedApplianceStatus & " = " & CInt(IMSEnums.ApplianceStatus.Redispatched) & " ) and " & _
                        IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstFireStationAppliance As List(Of IMSService.FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(strSQL).Cast(Of IMSService.FireStationAppliance).ToList()

        Return lstFireStationAppliance

    End Function

    ''' <summary>
    ''' Method to Get Employee involed into Incident 
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetEmployeeByIncidentID(incidentID As Integer) As List(Of IMSService.Employee)

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And " & _
                        IMSConstants.FieldConstants.EmployeeID & " IN ( SELECT " & IMSConstants.FieldConstants.EmployeeID _
                       & " FROM " & IMSConstants.TableNames.AssignedEmployee & " WHERE " & _
                       IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And " & _
                       IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstEmployee As List(Of IMSService.Employee) = _proxy.GetFilteredEmployee(strSQL).Cast(Of IMSService.Employee).ToList()

        Return lstEmployee

    End Function

    ''' <summary>
    ''' Method to Get currently involved employee (without available) at  an incident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentlyInvolvedEmployeeByIncidentID(incidentID As Integer) As List(Of IMSService.Employee)

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And " & _
                        IMSConstants.FieldConstants.EmployeeID & " IN ( SELECT " & IMSConstants.FieldConstants.EmployeeID _
                       & " FROM " & IMSConstants.TableNames.AssignedEmployee & " WHERE " & _
                       IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And  ( " & _
                        IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Dispatched) & _
                       " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Redispatched) & _
                       " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Revoked) & _
                       " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Parked) & _
                       " ) and " & _
                       IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstEmployee As List(Of IMSService.Employee) = _proxy.GetFilteredEmployee(strSQL).Cast(Of IMSService.Employee).ToList()

        Return lstEmployee

    End Function

    ''' <summary>
    ''' Method to Get all involved employee (Without available and Parked)
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCurrentlyInvolvedButParkedEmployeeByIncidentID(incidentID As Integer) As List(Of IMSService.Employee)

        Dim _proxy As New IMSService.IMSServices
        Dim strSQL = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And " & _
                        IMSConstants.FieldConstants.EmployeeID & " IN ( SELECT " & IMSConstants.FieldConstants.EmployeeID _
                       & " FROM " & IMSConstants.TableNames.AssignedEmployee & " WHERE " & _
                       IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " And  ( " & _
                        IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Dispatched) & _
                       " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Redispatched) & _
                       " or " & IMSConstants.FieldConstants.AssignedEmployeeStatus & " = " & CInt(IMSEnums.ApplianceStatus.Revoked) & _
                       " ) and " & _
                       IMSConstants.FieldConstants.IncidentID & " = " & incidentID & ")"

        Dim lstEmployee As List(Of IMSService.Employee) = _proxy.GetFilteredEmployee(strSQL).Cast(Of IMSService.Employee).ToList()

        Return lstEmployee

    End Function

    ''' <summary>
    ''' Method to Get Interger in Word.
    ''' </summary>
    ''' <param name="integerValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIntegerInWord(ByVal integerValue As Integer) As String

        Dim one() As String = {" ", " One", " Two", " Three", " Four", " Five", " Six", " Seven", "Eight", " Nine", " Ten", " Eleven", " Twelve", " Thirteen", " Fourteen", "Fifteen", " Sixteen", " Seventeen", " Eighteen", " Nineteen"}
        Dim ten() As String = {" ", " ", " Twenty", " Thirty", " Forty", " Fifty", " Sixty", "Seventy", " Eighty", " Ninety"}

        Dim hundrades = String.Empty
        Dim p = integerValue \ 100
        Dim q = integerValue Mod 100
        If p > 0 Then
            hundrades = one(p) & "   Hundrade "
        End If

        Dim tens As String = String.Empty

        If q > 19 Then
            tens = ten(q / 10) & one(integerValue Mod 10)
        Else
            tens = one(q)
        End If

        Return hundrades + tens

    End Function

    ''' <summary>
    ''' Method to Get all Active incident types
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllActiveIncidentTypes() As List(Of IncidentType)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.Status & " =  " & IMSEnums.Status.Active & " order by " & IMSConstants.FieldConstants.CategoryID _
                            & " asc , " & IMSConstants.FieldConstants.IncidentTypeDescription & " asc"
        Dim lstTypes As List(Of IncidentType) = _proxy.GetFilteredIncidentType(sql).Cast(Of IncidentType).ToList()

        Return lstTypes

    End Function

    ''' <summary>
    ''' Method to Get all active Incidnet Category
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllActiveIncidentCategory() As List(Of IncidentCategory)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.Status & " =  " & IMSEnums.Status.Active & " order by " & IMSConstants.FieldConstants.CategoryName & " asc "
        Dim lstCategories As List(Of IncidentCategory) = _proxy.GetFilteredIncidentCategory(sql).Cast(Of IncidentCategory).ToList()

        Return lstCategories

    End Function

    ''' <summary>
    ''' Method to Get All active Fire station.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllActiveFireStation() As List(Of FireStation)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " =  " & IMSEnums.IsDeleted.No
        Dim lstFireStation As List(Of FireStation) = _proxy.GetFilteredFireStation(sql).Cast(Of FireStation).ToList()

        Return lstFireStation

    End Function

    ''' <summary>
    ''' Method to Get All Incident By Incident Type 
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllIncidentByIncidentType(ByVal incidentID As Integer) As List(Of IncidentRegister)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " =  " & IMSEnums.IsDeleted.No & _
                            " and " & IMSConstants.FieldConstants.IncidentID & " In ( select " & _
                            IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.IncidentTypeIncident & _
                            " where " & IMSConstants.FieldConstants.IncidentTypeID & " = " & incidentID & " ) "


        Dim lstIncidentRegister As List(Of IncidentRegister) = _proxy.GetFilteredIncidentRegister(sql).Cast(Of IncidentRegister).ToList()

        Return lstIncidentRegister

    End Function

    ''' <summary>
    ''' Method to Get all checked in vehicle stationwise (by station id)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInVehicleStationWise(ByVal stationID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.StationID & " = " & stationID & _
                            " and " & IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & _
                            " and " & IMSConstants.FieldConstants.StationApplianceID & " In ( select " & _
                            IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & _
                            " where " & IMSConstants.FieldConstants.IsCurrent & " =  " & IMSEnums.IsDeleted.Yes & _
                             " and " & IMSConstants.FieldConstants.RegisterStatus & " =  " & CInt(IMSEnums.RegisterStatus.CheckedIn) & " ) " _
                                 & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc "

        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        Return lstCheckedInAppliance

    End Function

    ''' <summary>
    ''' Method to Get all checked in vehicle stationwise (by station id and Appliance ID)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllCheckedInVehicleStationAndApplianceIDWise(ByVal stationID As Integer, ByVal applianceID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.StationID & " = " & stationID & _
                            " and " & IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & _
                             " and " & IMSConstants.FieldConstants.ApplianceID & " = " & applianceID & _
                            " and " & IMSConstants.FieldConstants.StationApplianceID & " In ( select " & _
                            IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & _
                            " where " & IMSConstants.FieldConstants.IsCurrent & " =  " & IMSEnums.IsDeleted.Yes & _
                             " and " & IMSConstants.FieldConstants.RegisterStatus & " =  " & CInt(IMSEnums.RegisterStatus.CheckedIn) & " ) " _
                                 & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc "

        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        Return lstCheckedInAppliance

    End Function

    ''' <summary>
    ''' Method to Get all not checked in Vehicle (by station ID)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllNotCheckedInVehicleStationWise(ByVal stationID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.StationID & " = " & stationID & _
                            " and " & IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & _
                            " and " & IMSConstants.FieldConstants.StationApplianceID & " Not In ( select " & _
                            IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & _
                            " where " & IMSConstants.FieldConstants.IsCurrent & " =  " & IMSEnums.IsDeleted.Yes & _
                             " and " & IMSConstants.FieldConstants.RegisterStatus & " =  " & CInt(IMSEnums.RegisterStatus.CheckedIn) & " ) " _
                             & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc "

        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        Return lstCheckedInAppliance

    End Function

    ''' <summary>
    ''' Method to Get all not checked in Vehicle (by station ID and Appliance ID)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <param name="applianceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllNotCheckedInVehicleStationAndApplianceIDWise(ByVal stationID As Integer, ByVal applianceID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.StationID & " = " & stationID & _
                            " and " & IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & _
                             " and " & IMSConstants.FieldConstants.ApplianceID & " = " & applianceID & _
                            " and " & IMSConstants.FieldConstants.StationApplianceID & " Not In ( select " & _
                            IMSConstants.FieldConstants.StationApplianceID & " from " & IMSConstants.TableNames.ApplianceRegister & _
                            " where " & IMSConstants.FieldConstants.IsCurrent & " =  " & IMSEnums.IsDeleted.Yes & _
                             " and " & IMSConstants.FieldConstants.RegisterStatus & " =  " & CInt(IMSEnums.RegisterStatus.CheckedIn) & " ) " _
                             & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc "

        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        Return lstCheckedInAppliance

    End Function

    ''' <summary>
    ''' Method to get all station appliance (by station id)
    ''' </summary>
    ''' <param name="stationID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetAllStationAppliance(ByVal stationID As Integer) As List(Of FireStationAppliance)

        Dim _proxy As New IMSService.IMSServices
        Dim sql As String = IMSConstants.FieldConstants.StationID & " = " & stationID & _
                            " and " & IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) _
                                & " order by " & IMSConstants.FieldConstants.SerialNumber & " asc "

        Dim lstCheckedInAppliance As List(Of FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(sql).Cast(Of FireStationAppliance).ToList()

        Return lstCheckedInAppliance

    End Function

    ''' <summary>
    ''' Method to Get UnResolve Incidents + Incidents Resolved with in two days
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIncidentsUnresolvedAndResolvedWithInTwoDays(ByVal stationID As Integer) As List(Of IncidentRegister)

        Dim _proxy As New IMSService.IMSServices

        Dim currentTime As DateTime = GetToDate(Date.Now)
        Dim currentTimeFormated As DateTime
        Dim currentTime2DaysPrev As DateTime = GetFromDate(Date.Now.AddDays(-2))
        Dim currentTime2DaysPrevFormated As DateTime

        DateTime.TryParseExact(currentTime, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTimeFormated)
        DateTime.TryParseExact(currentTime2DaysPrev, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime2DaysPrevFormated)
        Dim sql As String = String.Empty

        If stationID > 0 Then

            sql = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & _
                        " and " & IMSConstants.FieldConstants.IncidentID & " In (select " & IMSConstants.FieldConstants.IncidentID & _
                        " from " & IMSConstants.TableNames.StationIncident & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID & " ) " & _
            "  and ( " & IMSConstants.FieldConstants.IncidentStatus & " <> " & CInt(IMSEnums.IncidentStatus.Resolved) & "  or " & _
            " ( " & IMSConstants.FieldConstants.IncidentID & " In (select " & _
            IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.OccurrenceBook & _
            " where ( " & IMSConstants.FieldConstants.InsertionDate & " >= '" & currentTime2DaysPrev.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & _
            "' and " & IMSConstants.FieldConstants.InsertionDate & " <= '" & currentTime.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & "'))) ) " & _
            " order by " & IMSConstants.FieldConstants.IncidentID & " desc "
        Else
            sql = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & "  and ( " & _
            IMSConstants.FieldConstants.IncidentStatus & " <> " & CInt(IMSEnums.IncidentStatus.Resolved) & "  or " & _
            " ( " & IMSConstants.FieldConstants.IncidentID & " In (select " & _
            IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.OccurrenceBook & _
            " where ( " & IMSConstants.FieldConstants.InsertionDate & " >= '" & currentTime2DaysPrev.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & _
            "' and " & IMSConstants.FieldConstants.InsertionDate & " <= '" & currentTime.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & "'))) ) " & _
            " order by " & IMSConstants.FieldConstants.IncidentID & " desc "

        End If


        Dim lstIncidentRegister As List(Of IncidentRegister) = _proxy.GetFilteredIncidentRegister(sql).Cast(Of IncidentRegister).ToList()

        Return lstIncidentRegister

    End Function

    ''' <summary>
    ''' Method to Get UnResolve Incidents + Incidents Resolved with in two days (Incident Type wise)
    ''' </summary>
    ''' <param name="incidentTypeID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetIncidentsUnresolvedAndResolvedWithInTwoDaysByIncidentType(ByVal incidentTypeID As Integer) As List(Of IncidentRegister)

        Dim _proxy As New IMSService.IMSServices

        Dim currentTime As DateTime = GetToDate(Date.Now)
        Dim currentTimeFormated As DateTime
        Dim currentTime2DaysPrev As DateTime = GetFromDate(Date.Now.AddDays(-2))
        Dim currentTime2DaysPrevFormated As DateTime

        DateTime.TryParseExact(currentTime, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTimeFormated)
        DateTime.TryParseExact(currentTime2DaysPrev, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime2DaysPrevFormated)

        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & _
                            " and " & IMSConstants.FieldConstants.IncidentID & " In ( select " & _
                            IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.IncidentTypeIncident & _
                            " where " & IMSConstants.FieldConstants.IncidentTypeID & " = " & incidentTypeID & " ) " & _
                            "  and ( " & _
                            IMSConstants.FieldConstants.IncidentStatus & " <> " & CInt(IMSEnums.IncidentStatus.Resolved) & "  or " & _
                            " ( " & IMSConstants.FieldConstants.IncidentID & " In (select " & _
                            IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.OccurrenceBook & _
                            " where ( " & IMSConstants.FieldConstants.InsertionDate & " >= '" & currentTime2DaysPrev.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & _
                            "' and " & IMSConstants.FieldConstants.InsertionDate & " <= '" & currentTime.ToString(IMSConstants.AppConstants.DateFormatToQueryShort) & "'))) ) " & _
                            " order by " & IMSConstants.FieldConstants.IncidentID & " desc "

        Dim lstIncidentRegister As List(Of IncidentRegister) = _proxy.GetFilteredIncidentRegister(sql).Cast(Of IncidentRegister).ToList()

        Return lstIncidentRegister

        ' real data of above query =>  sql =  IsDeleted = 0 and
        ' IncidentID In ( select IncidentID from IncidentTypeIncident where IncidentTypeID = 2 )   and 
        '     ( IncidentStatus <> 3  or  ( IncidentID In (select IncidentID from OccurrenceBook 
        '                 where ( InsertionDate >= '7/12/2014' and InsertionDate <= '7/14/2014 11:59:59 PM'))) )  
        'order by IncidentID desc 

    End Function

    ' ''' <summary>
    ' ''' Method to Get Enum description.
    ' ''' </summary>
    ' ''' <param name="currentEnum"></param>
    ' ''' <returns></returns>
    ' ''' <remarks></remarks>
    'Public Shared Function GetDescription(ByVal currentEnum As [Enum]) As String

    '    Dim description As String = String.Empty
    '    Dim da As DescriptionAttribute

    '    Dim fi As FieldInfo = currentEnum.GetType.GetField(currentEnum.ToString)
    '    da = DirectCast(Attribute.GetCustomAttribute(fi, GetType(DescriptionAttribute)), DescriptionAttribute)
    '    If da IsNot Nothing Then
    '        description = da.Description
    '    Else
    '        description = currentEnum.ToString
    '    End If

    '    Return description

    'End Function

    'Public Shared Function GetEnumValueFromDescription(ByVal enumDescription As String) As Integer

    '    For Each enumValue As Integer In [Enum].GetValues(GetType(IMSEnums.Sex))
    '        Dim display As String = GetDescription([Enum].Parse(GetType(IMSEnums.Sex), enumValue))
    '        If enumDescription = display Then
    '            Return enumValue
    '        End If
    '    Next

    '    Return 0
    'End Function

    ''' <summary>
    ''' Method to Get List of Person Rescued depending on Incident ID and Incident category.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="incidentCategory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetPersonRescuedByIncidentIDAndCategory(ByVal incidentID As Integer, ByVal incidentCategory As Integer) As List(Of PersonsRescuedAndEscaping)

        Dim _proxy As New IMSService.IMSServices

        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & " and " & _
    IMSConstants.FieldConstants.IncidentID & " = " & incidentID & " and " & _
    IMSConstants.FieldConstants.IncidentCategoryID & " = " & incidentCategory

        Dim lstGFPersonRescued As List(Of PersonsRescuedAndEscaping) = _proxy.GetFilteredPersonsRescuedAndEscaping(sql).Cast(Of IMSService.PersonsRescuedAndEscaping).ToList()

        Return lstGFPersonRescued

    End Function

    ''' <summary>
    ''' Method to Get List of Casualties depending on Incident ID and Incident category.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <param name="incidentCategory"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetCasualtiesByIncidentIDAndCategory(ByVal incidentID As Integer, ByVal incidentCategory As Integer) As List(Of Casualities)

        Dim _proxy As New IMSService.IMSServices

        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnums.IsDeleted.No) & " and " & _
    IMSConstants.FieldConstants.IncidentID & " = " & incidentID & " and " & _
    IMSConstants.FieldConstants.IncidentCategoryID & " = " & incidentCategory

        Dim lstCasualties As List(Of Casualities) = _proxy.GetFilteredCasualities(sql).Cast(Of IMSService.Casualities).ToList()

        Return lstCasualties

    End Function


    ''' <summary>
    ''' If User (a) Station Stuff OR (b) Station Manager => then he call see only his station incident. and bellow function will return this type user's staion or return Zero.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLoggedInUserStationToShow() As Integer

        If IMSConstants.AppConstants.LoggedInAccessRightID = CInt(IMSEnums.UserRight.StationManager) Or IMSConstants.AppConstants.LoggedInAccessRightID = CInt(IMSEnums.UserRight.StationStuff) Then

            Return IMSConstants.AppConstants.UserStationID
        Else
            Return 0

        End If

    End Function


End Class



