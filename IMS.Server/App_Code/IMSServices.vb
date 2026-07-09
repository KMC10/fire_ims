Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports IMS.DataAccess
Imports IMS.DataAccess.DAL
Imports IMS.DataAccess.DTO
Imports System.Collections.Generic
Imports System.Collections
Imports System.Xml.Serialization
Imports System.ServiceModel


' To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line.
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class IMSServices
    Inherits System.Web.Services.WebService

    'Private FireStationGateway As FireStationDAL
    'Private IncidentTypeGateway As DLIncidentType
    'Private IncidentRegistrationGateway As DLIncidentRegister
    'Private IncidentMessageGateway As DLIncidentMessage
    'Private AssignedIncidentTypeGateway As DLAssignedIncidentType
    'Private ApplianceRiderGateway As DLRider
    'Private EmployeeGateway As DLEmployee
    'Private AssignedFirestationGateway As DLAssignedFireStation
    'Private ApplianceGateway As DLAppliance
    'Private AssignedApplainceGateway As DLAssignedApplaince
    'Private LoginGateway As DLLogin

    Private _DataAccessManager As DataAcessManager

    Public Sub New()

        'FireStationGateway = New DLFireStation()
        'IncidentTypeGateway = New DLIncidentType()
        'IncidentRegistrationGateway = New DLIncidentRegister()
        'IncidentMessageGateway = New DLIncidentMessage()
        'AssignedIncidentTypeGateway = New DLAssignedIncidentType()
        'ApplianceRiderGateway = New DLRider()
        'EmployeeGateway = New DLEmployee()
        'AssignedFirestationGateway = New DLAssignedFireStation()
        'ApplianceGateway = New DLAppliance()
        'AssignedApplainceGateway = New DLAssignedApplaince()
        'LoginGateway = New DLLogin()
        _DataAccessManager = New DataAcessManager()

    End Sub

#Region "Code for Incident Registration"

    <WebMethod()> <XmlInclude(GetType(IncidentType)), XmlInclude(GetType(FireStation))> _
    Public Function AddIncident(ByVal DTOIncidentRegistration As IncidentRegister, ByVal lstAssignedIncidentType As List(Of AssignedIncidentType), ByVal lstAssignedFireStation As List(Of AssignedFireStation), ByVal DTOIncidentMessage As IncidentMessage) As Boolean
        Return _DataAccessManager.AddRecord(DTOIncidentRegistration, lstAssignedIncidentType, lstAssignedFireStation, DTOIncidentMessage)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function LoadUnsolvedIncidentWithin24HoursOrAll(ByVal ShowIncidentWithinDays As Integer) As List(Of IncidentRegister)
        Return _DataAccessManager.LoadRecords(ShowIncidentWithinDays)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function LoadIncidentsForAssignAppliance(ByVal StationId As Integer) As List(Of IncidentRegister)
        Return _DataAccessManager.LoadRecordsForAssignAppliance(StationId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function LoadOnGoingIncidents(ByVal StationId As Integer) As List(Of IncidentRegister)
        Return _DataAccessManager.LoadOnGoingRecords(StationId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function LoadIncidentByID(ByVal IncidentIDs As Integer) As IncidentRegister
        Return _DataAccessManager.LoadRecordByIncidentID(IncidentIDs)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function UpdateIncidentRegisterStatus(ByVal DTOIncident As IncidentRegister, ByVal IncidentId As Integer) As Boolean
        Return _DataAccessManager.UpdateRecord(DTOIncident, IncidentId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function LoadSolvedIncidents() As List(Of IncidentRegister)
        Return _DataAccessManager.LoadSolvedIncidents()
    End Function

    '<WebMethod()> _
    'Public Function GetFilteredIncidentRegister(ByVal sqlFilter As String) As List(Of IncidentRegister)
    '    Return _DataAccessManager.GetFilteredIncidentRegister(sqlFilter).Cast(Of IncidentRegister).ToList()
    'End Function

#End Region

#Region "Code for Fire Station"
    <WebMethod()> <XmlInclude(GetType(FireStation))> _
    Public Function GetFireStationByID(ByVal FireStationId As Integer) As FireStation
        Return _DataAccessManager.GetFireStationByID(FireStationId)
    End Function

    <WebMethod()> <XmlInclude(GetType(FireStation))> _
    Public Function InsertFireStation(ByVal obj As FireStation) As Integer
        Return _DataAccessManager.InsertFireStation(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStation))> _
    Public Function UpdateFireStation(ByVal obj As FireStation) As Integer
        Return _DataAccessManager.UpdateFireStation(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStation))> _
    Public Function DeleteFireStation(ByVal obj As FireStation) As Integer
        Return _DataAccessManager.DeleteFireStation(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStation))> _
    Public Function GetAllFireStation() As List(Of FireStation)
        Return _DataAccessManager.GetAllFireStation().Cast(Of FireStation).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStation))> _
    Public Function GetFilteredFireStation(ByVal sqlFilter As String) As List(Of FireStation)
        Return _DataAccessManager.GetFilteredFireStation(sqlFilter).Cast(Of FireStation).ToList()
    End Function



#End Region

#Region "Code for Incident Type"

    <WebMethod()> <XmlInclude(GetType(IncidentType))> _
    Public Function GetIncidentTypeByID(ByVal IncidentTypeId As Integer) As IncidentType
        Return _DataAccessManager.GetIncidentTypeByID(IncidentTypeId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentType))> _
    Public Function InsertIncidentType(ByVal obj As IncidentType) As Integer
        Return _DataAccessManager.InsertIncidentType(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentType))> _
    Public Function UpdateIncidentType(ByVal obj As IncidentType) As Integer
        Return _DataAccessManager.UpdateIncidentType(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentType))> _
    Public Function DeleteIncidentType(ByVal obj As IncidentType) As Integer
        Return _DataAccessManager.DeleteIncidentType(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentType))> _
    Public Function GetAllIncidentType() As List(Of IncidentType)
        Return _DataAccessManager.GetAllIncidentType().Cast(Of IncidentType).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentType))> _
    Public Function GetFilteredIncidentType(ByVal sqlFilter As String) As List(Of IncidentType)
        Return _DataAccessManager.GetFilteredIncidentType(sqlFilter).Cast(Of IncidentType).ToList()
    End Function


#End Region

#Region "Code for Incident Message"
    '<WebMethod()> <XmlInclude(GetType(IMS.DataQ.USP_ViewIncidentMessageResult))> _
    'Public Function LoadIncidentMessages(ByVal IncidentId As Integer) As List(Of USP_ViewIncidentMessageResult)
    '    'Return _DataAccessManager.LoadRecords(IncidentId)
    'End Function

    <WebMethod()> _
    Public Function LoadFirstMessageOfIncidentByIncidentId(ByVal IncidentId As Integer) As String
        Return _DataAccessManager.LoadFirstMessageOfIncidentByIncidentId(IncidentId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentMessage))> _
    Public Function AddIncidentMessage(ByVal DTOIncidentMessage As IncidentMessage) As Boolean
        Return _DataAccessManager.AddRecord(DTOIncidentMessage)
    End Function
    '<WebMethod()> _
    'Public Function LoadEmployeeIncidentMesssage(ByVal incidentID As Integer) As List(Of ViewModels.EmployeeIncidentMessage)
    '    Return _DataAccessManager.LoadEmployeeIncidentMesssage(incidentID).Cast(Of ViewModels.EmployeeIncidentMessage).ToList()
    'End Function

#End Region

#Region "Code for Assigned Incident Type"
    <WebMethod()> _
    Public Function LoadIncidentTypeByIncidentId(ByVal IncidentId As Integer) As IncidentRegister
        Return _DataAccessManager.LoadRecordByIncidentID(IncidentId)
    End Function

    <WebMethod()> <XmlInclude(GetType(AssignedIncidentType))> _
    Public Function LoadAssignedIncidentTypesByIncidentID(ByVal IncidentID As Integer) As List(Of IncidentType)
        Return _DataAccessManager.LoadRecordsByIncidentId(IncidentID)
    End Function

    <WebMethod()> _
    Public Function LoadIncidentTypeDescriptionByIncidentId(ByVal IncidentID As Integer) As String
        Return _DataAccessManager.LoadIncidentTypeDescriptionByIncidentId(IncidentID)
    End Function

    <WebMethod()> _
    Public Function GetFilteredAssignedIncidentType(ByVal sqlFilter As String) As List(Of AssignedIncidentType)
        Return _DataAccessManager.GetFilteredAssignedIncidentType(sqlFilter).Cast(Of AssignedIncidentType).ToList()
    End Function
#End Region

#Region "Code For Appliance Rider"

    <WebMethod()> <XmlInclude(GetType(ApplianceRider))> _
    Public Function LoadRiderByApplianceAndStationID(ByVal FireStationId As Integer, ByVal ApplianceIDs As Integer) As List(Of ApplianceRider)
        Return _DataAccessManager.LoadRiderByApplianceAndStationID(FireStationId, ApplianceIDs)
    End Function

    <WebMethod()> <XmlInclude(GetType(ApplianceRider))> _
    Public Function LoadRiderByApplianceID(ByVal ApplianceID As Integer) As List(Of ApplianceRider)
        Return _DataAccessManager.LoadRiderByApplianceID(ApplianceID)
    End Function

#End Region

#Region "Code For Assigned Fire Station"

    <WebMethod()> <XmlInclude(GetType(AssignedFireStation))> _
    Public Function LoadAssignedFireStationByID(ByVal IncidentID As Integer) As List(Of FireStation)
        Return _DataAccessManager.LoadRecordsByID(IncidentID)
    End Function

    <WebMethod()> <XmlInclude(GetType(AssignedFireStation))> _
    Public Function UpdateIncidentStatus(ByVal DTOAssignedFireStation As AssignedFireStation, ByVal IncidentId As Integer, ByVal StationId As Integer) As Boolean
        Return _DataAccessManager.UpdateRecord(DTOAssignedFireStation, IncidentId, StationId)
    End Function

    <WebMethod()> _
    Public Function GetFilteredAssignedFireStation(ByVal sqlFilter As String) As List(Of AssignedFireStation)
        Return _DataAccessManager.GetFilteredAssignedFireStation(sqlFilter).Cast(Of AssignedFireStation).ToList()
    End Function

#End Region

#Region "Code For Appliance"


    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function InsertAppliance(ByVal obj As Appliance) As Integer
        Return _DataAccessManager.InsertAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function UpdateAppliance(ByVal obj As Appliance) As Integer
        Return _DataAccessManager.UpdateAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function DeleteAppliance(ByVal obj As Appliance) As Integer
        Return _DataAccessManager.DeleteAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function LoadAppliancesByStationAndIncidentID(ByVal SataionId As Integer, ByVal IncidentId As Integer) As List(Of Appliance)
        Return _DataAccessManager.LoadRecordsByStationAndIncidentID(SataionId, IncidentId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function AvailableAppliances() As List(Of Appliance)
        Return _DataAccessManager.LoadAvailableAppliances().Cast(Of Appliance).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function OnEventAppliances() As List(Of Appliance)
        Return _DataAccessManager.LoadOnEventAppliances().Cast(Of Appliance).ToList()
    End Function

    <WebMethod()> _
    Public Function GetFilteredAppliance(ByVal sqlFilter As String) As List(Of Appliance)
        Return _DataAccessManager.GetFilteredAppliance(sqlFilter).Cast(Of Appliance).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function OnMaintananceAppliances() As List(Of Appliance)
        Return _DataAccessManager.LoadOnMaintananceAppliances().Cast(Of Appliance).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function GetApplianceByID(ByVal IncidentID As Integer) As Appliance
        Return _DataAccessManager.GetApplianceByID(IncidentID)
    End Function


    <WebMethod()> <XmlInclude(GetType(Appliance))> _
    Public Function GetAllAppliance() As List(Of Appliance)
        Return _DataAccessManager.GetAllAppliance().Cast(Of Appliance).ToList()
    End Function

#End Region

#Region "Code for Employee"

    <WebMethod()> _
    Public Function LoadEmployeeNameByKey(ByVal EmployeeIds As Integer) As String
        Return _DataAccessManager.LoadEmployeeNameByKey(EmployeeIds)
    End Function

    '<WebMethod()> <XmlInclude(GetType(Employee))> _
    'Public Function GetEmployeeByID(ByVal EmployeeId As Integer) As Employee
    '    Return _DataAccessManager.GetEmployeeByID(EmployeeId)
    'End Function

    '<WebMethod()> <XmlInclude(GetType(Employee))> _
    'Public Function GetAllEmployee() As List(Of Employee)
    '    Return _DataAccessManager.GetAllEmployee().Cast(Of Employee).ToList()
    'End Function


    '<WebMethod()> <XmlInclude(GetType(Employee))> _
    'Public Function GetFilteredEmployee(ByVal sqlFilter As String) As List(Of Employee)
    '    Return _DataAccessManager.GetFilteredEmployee(sqlFilter).Cast(Of Employee).ToList()
    'End Function


    <WebMethod()> <XmlInclude(GetType(Employee))> _
    Public Function GetEmployeeByID(ByVal EmployeeId As Integer) As Employee
        Return _DataAccessManager.GetEmployeeByID(EmployeeId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Employee))> _
    Public Function InsertEmployee(ByVal obj As Employee) As Integer
        Return _DataAccessManager.InsertEmployee(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Employee))> _
    Public Function UpdateEmployee(ByVal obj As Employee) As Integer
        Return _DataAccessManager.UpdateEmployee(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Employee))> _
    Public Function DeleteEmployee(ByVal obj As Employee) As Integer
        Return _DataAccessManager.DeleteEmployee(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Employee))> _
    Public Function GetAllEmployee() As List(Of Employee)
        Return _DataAccessManager.GetAllEmployee().Cast(Of Employee).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(Employee))> _
    Public Function GetFilteredEmployee(ByVal sqlFilter As String) As List(Of Employee)
        Return _DataAccessManager.GetFilteredEmployee(sqlFilter).Cast(Of Employee).ToList()
    End Function



#End Region


#Region "Code For Assigned Appliance"

    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function AddApplianceToIncident(ByVal lstAssignedAppliance As List(Of AssignedAppliance), ByVal lstAppliancesOnEvent As List(Of Appliance)) As Boolean
        Return _DataAccessManager.AddRecords(lstAssignedAppliance, lstAppliancesOnEvent)
    End Function

    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function AddOrReleaseAppliances(ByVal lstNewAssignedAppliance As List(Of AssignedAppliance), ByVal lstReleaseAppliances As List(Of Appliance), ByVal lstAppliancesOnEvent As List(Of Appliance), ByVal IncidentId As Integer, ByVal FirestationId As Integer) As Boolean
        Return _DataAccessManager.AddOrRelease(lstNewAssignedAppliance, lstReleaseAppliances, lstAppliancesOnEvent, IncidentId, FirestationId)
    End Function

    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function AssignedApplianceByIncidentID(ByVal IncidentID As Integer) As List(Of AssignedAppliance)
        Return _DataAccessManager.LoadAssignedApplianceByIncidentID(IncidentID)
    End Function

    '<WebMethod()> _
    'Public Function GetFilteredAssignedAppliance(ByVal sqlFilter As String) As List(Of AssignedAppliance)
    '    Return _DataAccessManager.GetFilteredAssignedAppliance(sqlFilter).Cast(Of AssignedAppliance).ToList()
    'End Function

#End Region

    '#Region "Code for User Login"
    '    <WebMethod()> <XmlInclude(GetType(Users))> _
    '    Public Function GetValidUser(ByVal UserId As String, ByVal Password As String) As Users
    '        Return _DataAccessManager.LoadRecordById(UserId, Password)
    '    End Function

    '    <WebMethod()> _
    '    Public Function LoadLoginInfo(ByVal UserId As String) As String
    '        Return _DataAccessManager.LoadLoginInfo(UserId)
    '    End Function
    '#End Region

#Region "Code For National Center Display Board"

    <WebMethod()> _
    Public Function LoadOnEventIncidents() As List(Of IncidentRegister)
        Return _DataAccessManager.LoadOnEventIncidents()
    End Function

    <WebMethod()> _
    Public Function LoadAssignedFireStations() As List(Of AssignedFireStation)
        Return _DataAccessManager.LoadAssignedFireStations()
    End Function

    <WebMethod()> _
    Public Function LoadAssignedAppliance(ByVal IncidentID As Integer, ByVal FireStationID As Integer) As List(Of Appliance)
        Return _DataAccessManager.LoadAssignedAppliance(IncidentID, FireStationID)
    End Function

    <WebMethod()> _
    Public Function LoadOnEventRider(ByVal IncidentID As Integer, ByVal ApplianceID As Integer) As List(Of Employee)
        Return _DataAccessManager.LoadOnEventRider(IncidentID, ApplianceID)
    End Function

#End Region

#Region "Code for ApplianceMapping"


    <WebMethod()> <XmlInclude(GetType(ApplianceMapping))> _
    Public Function InsertApplianceMapping(ByVal obj As ApplianceMapping) As Integer
        Return _DataAccessManager.InsertApplianceMapping(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceMapping))> _
    Public Function UpdateApplianceMapping(ByVal obj As ApplianceMapping) As Integer
        Return _DataAccessManager.UpdateApplianceMapping(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceMapping))> _
    Public Function DeleteApplianceMapping(ByVal obj As ApplianceMapping) As Integer
        Return _DataAccessManager.DeleteApplianceMapping(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceMapping))> _
    Public Function GetAllApplianceMapping() As List(Of ApplianceMapping)
        Return _DataAccessManager.GetAllApplianceMapping().Cast(Of ApplianceMapping).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceMapping))> _
    Public Function GetApplianceMappingByID(ByVal ApplianceMappingId As Integer) As ApplianceMapping
        Return _DataAccessManager.GetApplianceMappingByID(ApplianceMappingId)
    End Function

    <WebMethod()> <XmlInclude(GetType(ApplianceMapping))> _
    Public Function GetFilteredApplianceMapping(ByVal sqlFilter As String) As List(Of ApplianceMapping)
        Return _DataAccessManager.GetFilteredApplianceMapping(sqlFilter).Cast(Of ApplianceMapping).ToList()
    End Function

#End Region

#Region "Code for AssignedEmployee"


    <WebMethod()> <XmlInclude(GetType(AssignedEmployee))> _
    Public Function InsertAssignedEmployee(ByVal obj As AssignedEmployee) As Integer
        Return _DataAccessManager.InsertAssignedEmployee(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedEmployee))> _
    Public Function UpdateAssignedEmployee(ByVal obj As AssignedEmployee) As Integer
        Return _DataAccessManager.UpdateAssignedEmployee(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedEmployee))> _
    Public Function DeleteAssignedEmployee(ByVal obj As AssignedEmployee) As Integer
        Return _DataAccessManager.DeleteAssignedEmployee(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedEmployee))> _
    Public Function GetAllAssignedEmployee() As List(Of AssignedEmployee)
        Return _DataAccessManager.GetAllAssignedEmployee().Cast(Of AssignedEmployee).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedEmployee))> _
    Public Function GetAssignedEmployeeByID(ByVal AssignedEmployeeId As Integer) As AssignedEmployee
        Return _DataAccessManager.GetAssignedEmployeeByID(AssignedEmployeeId)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedEmployee))> _
    Public Function GetFilteredAssignedEmployee(ByVal sqlFilter As String) As List(Of AssignedEmployee)
        Return _DataAccessManager.GetFilteredAssignedEmployee(sqlFilter).Cast(Of AssignedEmployee).ToList()
    End Function


#End Region

#Region "Code for DispatchLog"


    <WebMethod()> <XmlInclude(GetType(DispatchLog))> _
    Public Function InsertDispatchLog(ByVal obj As DispatchLog) As Integer
        Return _DataAccessManager.InsertDispatchLog(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(DispatchLog))> _
    Public Function UpdateDispatchLog(ByVal obj As DispatchLog) As Integer
        Return _DataAccessManager.UpdateDispatchLog(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(DispatchLog))> _
    Public Function DeleteDispatchLog(ByVal obj As DispatchLog) As Integer
        Return _DataAccessManager.DeleteDispatchLog(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(DispatchLog))> _
    Public Function GetAllDispatchLog() As List(Of DispatchLog)
        Return _DataAccessManager.GetAllDispatchLog().Cast(Of DispatchLog).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(DispatchLog))> _
    Public Function GetDispatchLogByID(ByVal DispatchLogId As Integer) As DispatchLog
        Return _DataAccessManager.GetDispatchLogByID(DispatchLogId)
    End Function


    <WebMethod()> <XmlInclude(GetType(DispatchLog))> _
    Public Function GetFilteredDispatchLog(ByVal sqlFilter As String) As List(Of DispatchLog)
        Return _DataAccessManager.GetFilteredDispatchLog(sqlFilter).Cast(Of DispatchLog).ToList()
    End Function


#End Region

#Region "Code for FireStationAppliance"


    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function InsertFireStationAppliance(ByVal obj As FireStationAppliance) As Integer
        Return _DataAccessManager.InsertFireStationAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function UpdateFireStationAppliance(ByVal obj As FireStationAppliance) As Integer
        Return _DataAccessManager.UpdateFireStationAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function DeleteFireStationAppliance(ByVal obj As FireStationAppliance) As Integer
        Return _DataAccessManager.DeleteFireStationAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function GetAllFireStationAppliance() As List(Of FireStationAppliance)
        Return _DataAccessManager.GetAllFireStationAppliance().Cast(Of FireStationAppliance).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function GetFireStationApplianceByID(ByVal FireStationApplianceId As Integer) As FireStationAppliance
        Return _DataAccessManager.GetFireStationApplianceByID(FireStationApplianceId)
    End Function

    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function GetFilteredFireStationAppliance(ByVal sqlFilter As String) As List(Of FireStationAppliance)
        Return _DataAccessManager.GetFilteredFireStationAppliance(sqlFilter).Cast(Of FireStationAppliance).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(FireStationAppliance))> _
    Public Function GetAvailableApplianceBySationID(ByVal stationID As String) As List(Of FireStationAppliance)
        Return _DataAccessManager.GetAvailableApplianceBySationID(stationID).Cast(Of FireStationAppliance).ToList()
    End Function

#End Region

#Region "Code for IncidentCategory"


    <WebMethod()> <XmlInclude(GetType(IncidentCategory))> _
    Public Function InsertIncidentCategory(ByVal obj As IncidentCategory) As Integer
        Return _DataAccessManager.InsertIncidentCategory(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentCategory))> _
    Public Function UpdateIncidentCategory(ByVal obj As IncidentCategory) As Integer
        Return _DataAccessManager.UpdateIncidentCategory(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentCategory))> _
    Public Function DeleteIncidentCategory(ByVal obj As IncidentCategory) As Integer
        Return _DataAccessManager.DeleteIncidentCategory(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentCategory))> _
    Public Function GetAllIncidentCategory() As List(Of IncidentCategory)
        Return _DataAccessManager.GetAllIncidentCategory().Cast(Of IncidentCategory).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentCategory))> _
    Public Function GetIncidentCategoryByID(ByVal IncidentCategoryId As Integer) As IncidentCategory
        Return _DataAccessManager.GetIncidentCategoryByID(IncidentCategoryId)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentCategory))> _
    Public Function GetFilteredIncidentCategory(ByVal sqlFilter As String) As List(Of IncidentCategory)
        Return _DataAccessManager.GetFilteredIncidentCategory(sqlFilter).Cast(Of IncidentCategory).ToList()
    End Function


#End Region

#Region "Code for IncidentRegister"


    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function InsertIncidentRegister(ByVal obj As IncidentRegister) As Integer
        Return _DataAccessManager.InsertIncidentRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function UpdateIncidentRegister(ByVal obj As IncidentRegister) As Integer
        Return _DataAccessManager.UpdateIncidentRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function DeleteIncidentRegister(ByVal obj As IncidentRegister) As Integer
        Return _DataAccessManager.DeleteIncidentRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function GetAllIncidentRegister() As List(Of IncidentRegister)
        Return _DataAccessManager.GetAllIncidentRegister().Cast(Of IncidentRegister).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function GetIncidentRegisterByID(ByVal IncidentRegisterId As Integer) As IncidentRegister
        Return _DataAccessManager.GetIncidentRegisterByID(IncidentRegisterId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentRegister))> _
    Public Function GetFilteredIncidentRegister(ByVal sqlFilter As String) As List(Of IncidentRegister)
        Return _DataAccessManager.GetFilteredIncidentRegister(sqlFilter).Cast(Of IncidentRegister).ToList()
    End Function


#End Region

#Region "Code for OccurrenceBook"

    <WebMethod()> <XmlInclude(GetType(OccurrenceBook))> _
    Public Function GetOccurrenceBookByID(ByVal OccurrenceBookId As Integer) As OccurrenceBook
        Return _DataAccessManager.GetOccurrenceBookByID(OccurrenceBookId)
    End Function


    <WebMethod()> <XmlInclude(GetType(OccurrenceBook))> _
    Public Function InsertOccurrenceBook(ByVal obj As OccurrenceBook) As Integer
        Return _DataAccessManager.InsertOccurrenceBook(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(OccurrenceBook))> _
    Public Function UpdateOccurrenceBook(ByVal obj As OccurrenceBook) As Integer
        Return _DataAccessManager.UpdateOccurrenceBook(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(OccurrenceBook))> _
    Public Function DeleteOccurrenceBook(ByVal obj As OccurrenceBook) As Integer
        Return _DataAccessManager.DeleteOccurrenceBook(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(OccurrenceBook))> _
    Public Function GetAllOccurrenceBook(ByVal id As Integer) As List(Of OccurrenceBook)
        Return _DataAccessManager.GetAllOccurrenceBook().Cast(Of OccurrenceBook).ToList()
    End Function



    <WebMethod()> <XmlInclude(GetType(OccurrenceBook))> _
    Public Function GetFilteredOccurrenceBook(ByVal sqlFilter As String) As List(Of OccurrenceBook)
        Return _DataAccessManager.GetFilteredOccurrenceBook(sqlFilter).Cast(Of OccurrenceBook).ToList()
    End Function


#End Region

#Region "Code for Shift"

    <WebMethod()> <XmlInclude(GetType(Shift))> _
    Public Function GetShiftByID(ByVal ShiftId As Integer) As Shift
        Return _DataAccessManager.GetShiftByID(ShiftId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Shift))> _
    Public Function InsertShift(ByVal obj As Shift) As Integer
        Return _DataAccessManager.InsertShift(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Shift))> _
    Public Function UpdateShift(ByVal obj As Shift) As Integer
        Return _DataAccessManager.UpdateShift(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Shift))> _
    Public Function DeleteShift(ByVal obj As Shift) As Integer
        Return _DataAccessManager.DeleteShift(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Shift))> _
    Public Function GetAllShift() As List(Of Shift)
        Return _DataAccessManager.GetAllShift().Cast(Of Shift).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(Shift))> _
    Public Function GetFilteredShift(ByVal sqlFilter As String) As List(Of Shift)
        Return _DataAccessManager.GetFilteredShift(sqlFilter).Cast(Of Shift).ToList()
    End Function

#End Region

#Region "Code for EmployeeRegister"


    <WebMethod()> <XmlInclude(GetType(EmployeeRegister))> _
    Public Function InsertEmployeeRegister(ByVal obj As EmployeeRegister) As Integer
        Return _DataAccessManager.InsertEmployeeRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeRegister))> _
    Public Function UpdateEmployeeRegister(ByVal obj As EmployeeRegister) As Integer
        Return _DataAccessManager.UpdateEmployeeRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeRegister))> _
    Public Function DeleteEmployeeRegister(ByVal obj As EmployeeRegister) As Integer
        Return _DataAccessManager.DeleteEmployeeRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeRegister))> _
    Public Function GetAllEmployeeRegister() As List(Of EmployeeRegister)
        Return _DataAccessManager.GetAllEmployeeRegister().Cast(Of EmployeeRegister).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeRegister))> _
    Public Function GetEmployeeRegisterByID(ByVal EmployeeRegisterId As Integer) As EmployeeRegister
        Return _DataAccessManager.GetEmployeeRegisterByID(EmployeeRegisterId)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeRegister))> _
    Public Function GetFilteredEmployeeRegister(ByVal sqlFilter As String) As List(Of EmployeeRegister)
        Return _DataAccessManager.GetFilteredEmployeeRegister(sqlFilter).Cast(Of EmployeeRegister).ToList()
    End Function


#End Region

#Region "Code for AssignedAppliance"


    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function InsertAssignedAppliance(ByVal obj As AssignedAppliance) As Integer
        Return _DataAccessManager.InsertAssignedAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function UpdateAssignedAppliance(ByVal obj As AssignedAppliance) As Integer
        Return _DataAccessManager.UpdateAssignedAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function DeleteAssignedAppliance(ByVal obj As AssignedAppliance) As Integer
        Return _DataAccessManager.DeleteAssignedAppliance(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function GetAllAssignedAppliance() As List(Of AssignedAppliance)
        Return _DataAccessManager.GetAllAssignedAppliance().Cast(Of AssignedAppliance).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function GetAssignedApplianceByID(ByVal AssignedApplianceId As Integer) As AssignedAppliance
        Return _DataAccessManager.GetAssignedApplianceByID(AssignedApplianceId)
    End Function


    <WebMethod()> <XmlInclude(GetType(AssignedAppliance))> _
    Public Function GetFilteredAssignedAppliance(ByVal sqlFilter As String) As List(Of AssignedAppliance)
        Return _DataAccessManager.GetFilteredAssignedAppliance(sqlFilter).Cast(Of AssignedAppliance).ToList()
    End Function

#End Region


#Region "Code for ApplianceRegister"

    <WebMethod()> <XmlInclude(GetType(ApplianceRegister))> _
    Public Function InsertApplianceRegister(ByVal obj As ApplianceRegister) As Integer
        Return _DataAccessManager.InsertApplianceRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceRegister))> _
    Public Function UpdateApplianceRegister(ByVal obj As ApplianceRegister) As Integer
        Return _DataAccessManager.UpdateApplianceRegister(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceRegister))> _
    Public Function DeleteApplianceRegister(ByVal obj As ApplianceRegister) As Integer
        Return _DataAccessManager.DeleteApplianceRegister(obj)
    End Function

    <WebMethod()> <XmlInclude(GetType(ApplianceRegister))> _
    Public Function GetAllApplianceRegister() As List(Of ApplianceRegister)
        Return _DataAccessManager.GetAllApplianceRegister().Cast(Of ApplianceRegister).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceRegister))> _
    Public Function GetApplianceRegisterByID(ByVal ApplianceRegisterId As Integer) As ApplianceRegister
        Return _DataAccessManager.GetApplianceRegisterByID(ApplianceRegisterId)
    End Function


    <WebMethod()> <XmlInclude(GetType(ApplianceRegister))> _
    Public Function GetFilteredApplianceRegister(ByVal sqlFilter As String) As List(Of ApplianceRegister)
        Return _DataAccessManager.GetFilteredApplianceRegister(sqlFilter).Cast(Of ApplianceRegister).ToList()
    End Function


#End Region

#Region "Code for EmployeeType"

    <WebMethod()> <XmlInclude(GetType(EmployeeType))> _
    Public Function GetEmployeeTypeByID(ByVal EmployeeTypeId As Integer) As EmployeeType
        Return _DataAccessManager.GetEmployeeTypeByID(EmployeeTypeId)
    End Function

    <WebMethod()> <XmlInclude(GetType(EmployeeType))> _
    Public Function InsertEmployeeType(ByVal obj As EmployeeType) As Integer
        Return _DataAccessManager.InsertEmployeeType(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeType))> _
    Public Function UpdateEmployeeType(ByVal obj As EmployeeType) As Integer
        Return _DataAccessManager.UpdateEmployeeType(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeType))> _
    Public Function DeleteEmployeeType(ByVal obj As EmployeeType) As Integer
        Return _DataAccessManager.DeleteEmployeeType(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeType))> _
    Public Function GetAllEmployeeType() As List(Of EmployeeType)
        Return _DataAccessManager.GetAllEmployeeType().Cast(Of EmployeeType).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeType))> _
    Public Function GetFilteredEmployeeType(ByVal sqlFilter As String) As List(Of EmployeeType)
        Return _DataAccessManager.GetFilteredEmployeeType(sqlFilter).Cast(Of EmployeeType).ToList()
    End Function

#End Region

#Region "Code for IncidentTypeIncident"

    <WebMethod()> <XmlInclude(GetType(IncidentTypeIncident))> _
    Public Function GetIncidentTypeIncidentByID(ByVal IncidentTypeIncidentId As Integer) As IncidentTypeIncident
        Return _DataAccessManager.GetIncidentTypeIncidentByID(IncidentTypeIncidentId)
    End Function

    <WebMethod()> <XmlInclude(GetType(IncidentTypeIncident))> _
    Public Function InsertIncidentTypeIncident(ByVal obj As IncidentTypeIncident) As Integer
        Return _DataAccessManager.InsertIncidentTypeIncident(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentTypeIncident))> _
    Public Function UpdateIncidentTypeIncident(ByVal obj As IncidentTypeIncident) As Integer
        Return _DataAccessManager.UpdateIncidentTypeIncident(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentTypeIncident))> _
    Public Function DeleteIncidentTypeIncident(ByVal obj As IncidentTypeIncident) As Integer
        Return _DataAccessManager.DeleteIncidentTypeIncident(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentTypeIncident))> _
    Public Function GetAllIncidentTypeIncident() As List(Of IncidentTypeIncident)
        Return _DataAccessManager.GetAllIncidentTypeIncident().Cast(Of IncidentTypeIncident).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(IncidentTypeIncident))> _
    Public Function GetFilteredIncidentTypeIncident(ByVal sqlFilter As String) As List(Of IncidentTypeIncident)
        Return _DataAccessManager.GetFilteredIncidentTypeIncident(sqlFilter).Cast(Of IncidentTypeIncident).ToList()
    End Function

#End Region


#Region "Code for Casualities"

    <WebMethod()> <XmlInclude(GetType(Casualities))> _
    Public Function GetCasualitiesByID(ByVal CasualitiesId As Integer) As Casualities
        Return _DataAccessManager.GetCasualitiesByID(CasualitiesId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Casualities))> _
    Public Function InsertCasualities(ByVal obj As Casualities) As Integer
        Return _DataAccessManager.InsertCasualities(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Casualities))> _
    Public Function UpdateCasualities(ByVal obj As Casualities) As Integer
        Return _DataAccessManager.UpdateCasualities(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Casualities))> _
    Public Function DeleteCasualities(ByVal obj As Casualities) As Integer
        Return _DataAccessManager.DeleteCasualities(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Casualities))> _
    Public Function GetAllCasualities() As List(Of Casualities)
        Return _DataAccessManager.GetAllCasualities().Cast(Of Casualities).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(Casualities))> _
    Public Function GetFilteredCasualities(ByVal sqlFilter As String) As List(Of Casualities)
        Return _DataAccessManager.GetFilteredCasualities(sqlFilter).Cast(Of Casualities).ToList()
    End Function

#End Region

#Region "Code for PersonsRescuedAndEscaping"

    <WebMethod()> <XmlInclude(GetType(PersonsRescuedAndEscaping))> _
    Public Function GetPersonsRescuedAndEscapingByID(ByVal RescuedID As Integer) As PersonsRescuedAndEscaping
        Return _DataAccessManager.GetPersonsRescuedAndEscapingByID(RescuedID)
    End Function

    <WebMethod()> <XmlInclude(GetType(PersonsRescuedAndEscaping))> _
    Public Function InsertPersonsRescuedAndEscaping(ByVal obj As PersonsRescuedAndEscaping) As Integer
        Return _DataAccessManager.InsertPersonsRescuedAndEscaping(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(PersonsRescuedAndEscaping))> _
    Public Function UpdatePersonsRescuedAndEscaping(ByVal obj As PersonsRescuedAndEscaping) As Integer
        Return _DataAccessManager.UpdatePersonsRescuedAndEscaping(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(PersonsRescuedAndEscaping))> _
    Public Function DeletePersonsRescuedAndEscaping(ByVal obj As PersonsRescuedAndEscaping) As Integer
        Return _DataAccessManager.DeletePersonsRescuedAndEscaping(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(PersonsRescuedAndEscaping))> _
    Public Function GetAllPersonsRescuedAndEscaping() As List(Of PersonsRescuedAndEscaping)
        Return _DataAccessManager.GetAllPersonsRescuedAndEscaping().Cast(Of PersonsRescuedAndEscaping).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(PersonsRescuedAndEscaping))> _
    Public Function GetFilteredPersonsRescuedAndEscaping(ByVal sqlFilter As String) As List(Of PersonsRescuedAndEscaping)
        Return _DataAccessManager.GetFilteredPersonsRescuedAndEscaping(sqlFilter).Cast(Of PersonsRescuedAndEscaping).ToList()
    End Function

#End Region

#Region "Code for StationIncident"

    <WebMethod()> <XmlInclude(GetType(StationIncident))> _
    Public Function GetStationIncidentByID(ByVal StationIncidentId As Integer) As StationIncident
        Return _DataAccessManager.GetStationIncidentByID(StationIncidentId)
    End Function

    <WebMethod()> <XmlInclude(GetType(StationIncident))> _
    Public Function InsertStationIncident(ByVal obj As StationIncident) As Integer
        Return _DataAccessManager.InsertStationIncident(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(StationIncident))> _
    Public Function UpdateStationIncident(ByVal obj As StationIncident) As Integer
        Return _DataAccessManager.UpdateStationIncident(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(StationIncident))> _
    Public Function DeleteStationIncident(ByVal obj As StationIncident) As Integer
        Return _DataAccessManager.DeleteStationIncident(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(StationIncident))> _
    Public Function GetAllStationIncident() As List(Of StationIncident)
        Return _DataAccessManager.GetAllStationIncident().Cast(Of StationIncident).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(StationIncident))> _
    Public Function GetFilteredStationIncident(ByVal sqlFilter As String) As List(Of StationIncident)
        Return _DataAccessManager.GetFilteredStationIncident(sqlFilter).Cast(Of StationIncident).ToList()
    End Function

#End Region

#Region "Code for Users"

    <WebMethod()> <XmlInclude(GetType(Users))> _
    Public Function InsertUsers(ByVal obj As Users) As Integer
        Return _DataAccessManager.InsertUsers(obj)
    End Function

    '<WebMethod()> <XmlInclude(GetType(Users))> _
    'Public Function DeleteUsers(ByVal obj As Users) As Integer
    '    Return _DataAccessManager.DeleteUsers(obj)
    'End Function

    <WebMethod()> <XmlInclude(GetType(Users))> _
    Public Function UpdateUsers(ByVal obj As Users) As Integer
        Return _DataAccessManager.UpdateUsers(obj)
    End Function

    <WebMethod()> <XmlInclude(GetType(Users))> _
    Public Function GetAllUsers() As List(Of Users)
        Return _DataAccessManager.GetAllUsers().Cast(Of Users).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(Users))> _
    Public Function GetUsersByID(ByVal userid As String) As Users
        Return _DataAccessManager.GetUserByID(userid)
    End Function

    <WebMethod()> <XmlInclude(GetType(Users))> _
    Public Function GetFilteredUsers(ByVal sqlFilter As String) As List(Of Users)
        Return _DataAccessManager.GetFilteredUsers(sqlFilter).Cast(Of Users).ToList()
    End Function

#End Region

#Region "Code for UserRight"

    <WebMethod()> <XmlInclude(GetType(UserRight))> _
    Public Function InsertUserRight(ByVal obj As UserRight) As Integer
        Return _DataAccessManager.InsertUserRight(obj)
    End Function

    '<WebMethod()> <XmlInclude(GetType(UserRight))> _
    'Public Function DeleteUserRight(ByVal obj As UserRight) As Integer
    '    Return _DataAccessManager.DeleteUserRight(obj)
    'End Function

    <WebMethod()> <XmlInclude(GetType(UserRight))> _
    Public Function UpdateUserRight(ByVal obj As UserRight) As Integer
        Return _DataAccessManager.UpdateUserRight(obj)
    End Function

    <WebMethod()> <XmlInclude(GetType(UserRight))> _
    Public Function GetAllUserRight() As List(Of UserRight)
        Return _DataAccessManager.GetAllUserRight().Cast(Of UserRight).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(UserRight))> _
    Public Function GetUserRightByID(ByVal userid As String) As UserRight
        Return _DataAccessManager.GetUserRightID(userid)
    End Function

    <WebMethod()> <XmlInclude(GetType(UserRight))> _
    Public Function GetFilteredUserRight(ByVal sqlFilter As String) As List(Of UserRight)
        Return _DataAccessManager.GetFilteredUserRight(sqlFilter).Cast(Of UserRight).ToList()
    End Function

#End Region

#Region "Code for LoginInfo"

    <WebMethod()> <XmlInclude(GetType(LoginInfo))> _
    Public Function InsertLoginInfo(ByVal obj As LoginInfo) As Integer
        Return _DataAccessManager.InsertLoginInfo(obj)
    End Function

#End Region

    '#Region "Code for ReferenceNo"

    '    <WebMethod()> <XmlInclude(GetType(ReferenceNo))> _
    '    Public Function UpdateReferenceNo() As Integer
    '        Return _DataAccessManager.UpdateReferenceNo()
    '    End Function

    '#End Region

#Region "Code for RoleUsers"

    <WebMethod()> <XmlInclude(GetType(RoleUsers))> _
    Public Function GetRoleUsersByID(ByVal RoleUsersId As Integer) As RoleUsers
        Return _DataAccessManager.GetRoleUsersByID(RoleUsersId)
    End Function

    <WebMethod()> <XmlInclude(GetType(RoleUsers))> _
    Public Function InsertRoleUsers(ByVal obj As RoleUsers) As Integer
        Return _DataAccessManager.InsertRoleUsers(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(RoleUsers))> _
    Public Function UpdateRoleUsers(ByVal obj As RoleUsers) As Integer
        Return _DataAccessManager.UpdateRoleUsers(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(RoleUsers))> _
    Public Function DeleteRoleUsers(ByVal obj As RoleUsers) As Integer
        Return _DataAccessManager.DeleteRoleUsers(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(RoleUsers))> _
    Public Function GetAllRoleUsers() As List(Of RoleUsers)
        Return _DataAccessManager.GetAllRoleUsers().Cast(Of RoleUsers).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(RoleUsers))> _
    Public Function GetFilteredRoleUsers(ByVal sqlFilter As String) As List(Of RoleUsers)
        Return _DataAccessManager.GetFilteredRoleUsers(sqlFilter).Cast(Of RoleUsers).ToList()
    End Function

#End Region

#Region "Code for Roles"

    <WebMethod()> <XmlInclude(GetType(Roles))> _
    Public Function GetRolesByID(ByVal RolesId As Integer) As Roles
        Return _DataAccessManager.GetRolesByID(RolesId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Roles))> _
    Public Function InsertRoles(ByVal obj As Roles) As Integer
        Return _DataAccessManager.InsertRoles(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Roles))> _
    Public Function UpdateRoles(ByVal obj As Roles) As Integer
        Return _DataAccessManager.UpdateRoles(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Roles))> _
    Public Function DeleteRoles(ByVal obj As Roles) As Integer
        Return _DataAccessManager.DeleteRoles(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Roles))> _
    Public Function GetAllRoles() As List(Of Roles)
        Return _DataAccessManager.GetAllRoles().Cast(Of Roles).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(Roles))> _
    Public Function GetFilteredRoles(ByVal sqlFilter As String) As List(Of Roles)
        Return _DataAccessManager.GetFilteredRoles(sqlFilter).Cast(Of Roles).ToList()
    End Function

#End Region

#Region "Code for RolePrivileges"

    <WebMethod()> <XmlInclude(GetType(RolePrivileges))> _
    Public Function GetRolePrivilegesByID(ByVal RolePrivilegesId As Integer) As RolePrivileges
        Return _DataAccessManager.GetRolePrivilegesByID(RolePrivilegesId)
    End Function

    <WebMethod()> <XmlInclude(GetType(RolePrivileges))> _
    Public Function InsertRolePrivileges(ByVal obj As RolePrivileges) As Integer
        Return _DataAccessManager.InsertRolePrivileges(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(RolePrivileges))> _
    Public Function UpdateRolePrivileges(ByVal obj As RolePrivileges) As Integer
        Return _DataAccessManager.UpdateRolePrivileges(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(RolePrivileges))> _
    Public Function DeleteRolePrivileges(ByVal obj As RolePrivileges) As Integer
        Return _DataAccessManager.DeleteRolePrivileges(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(RolePrivileges))> _
    Public Function GetAllRolePrivileges() As List(Of RolePrivileges)
        Return _DataAccessManager.GetAllRolePrivileges().Cast(Of RolePrivileges).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(RolePrivileges))> _
    Public Function GetFilteredRolePrivileges(ByVal sqlFilter As String) As List(Of RolePrivileges)
        Return _DataAccessManager.GetFilteredRolePrivileges(sqlFilter).Cast(Of RolePrivileges).ToList()
    End Function

#End Region

#Region "Code for Privileges"

    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function GetPrivilegesByID(ByVal PrivilegesId As Integer) As Privileges
        Return _DataAccessManager.GetPrivilegesByID(PrivilegesId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function InsertPrivileges(ByVal obj As Privileges) As Integer
        Return _DataAccessManager.InsertPrivileges(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function UpdatePrivileges(ByVal obj As Privileges) As Integer
        Return _DataAccessManager.UpdatePrivileges(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function DeletePrivileges(ByVal obj As Privileges) As Integer
        Return _DataAccessManager.DeletePrivileges(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function GetAllPrivileges() As List(Of Privileges)
        Return _DataAccessManager.GetAllPrivileges().Cast(Of Privileges).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function GetFilteredPrivileges(ByVal sqlFilter As String) As List(Of Privileges)
        Return _DataAccessManager.GetFilteredPrivileges(sqlFilter).Cast(Of Privileges).ToList()
    End Function

    <WebMethod()> <XmlInclude(GetType(Privileges))> _
    Public Function GetExecuteQueryPrivileges(ByVal sqlString As String) As List(Of Privileges)
        Return _DataAccessManager.ExecuteJoinSQL(Of Privileges)(sqlString).Cast(Of Privileges).ToList()
    End Function

#End Region

#Region "Code for EmployeeUser"

    <WebMethod()> <XmlInclude(GetType(EmployeeUser))> _
    Public Function GetEmployeeUserByID(ByVal EmployeeUserId As Integer) As EmployeeUser
        Return _DataAccessManager.GetEmployeeUserByID(EmployeeUserId)
    End Function

    <WebMethod()> <XmlInclude(GetType(EmployeeUser))> _
    Public Function InsertEmployeeUser(ByVal obj As EmployeeUser) As Integer
        Return _DataAccessManager.InsertEmployeeUser(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeUser))> _
    Public Function UpdateEmployeeUser(ByVal obj As EmployeeUser) As Integer
        Return _DataAccessManager.UpdateEmployeeUser(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeUser))> _
    Public Function DeleteEmployeeUser(ByVal obj As EmployeeUser) As Integer
        Return _DataAccessManager.DeleteEmployeeUser(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeUser))> _
    Public Function GetAllEmployeeUser() As List(Of EmployeeUser)
        Return _DataAccessManager.GetAllEmployeeUser().Cast(Of EmployeeUser).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(EmployeeUser))> _
    Public Function GetFilteredEmployeeUser(ByVal sqlFilter As String) As List(Of EmployeeUser)
        Return _DataAccessManager.GetFilteredEmployeeUser(sqlFilter).Cast(Of EmployeeUser).ToList()
    End Function

#End Region

#Region "Code for Group"

    <WebMethod()> <XmlInclude(GetType(Group))> _
    Public Function GetGroupByID(ByVal GroupId As Integer) As Group
        Return _DataAccessManager.GetGroupByID(GroupId)
    End Function

    <WebMethod()> <XmlInclude(GetType(Group))> _
    Public Function InsertGroup(ByVal obj As Group) As Integer
        Return _DataAccessManager.InsertGroup(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Group))> _
    Public Function UpdateGroup(ByVal obj As Group) As Integer
        Return _DataAccessManager.UpdateGroup(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Group))> _
    Public Function DeleteGroup(ByVal obj As Group) As Integer
        Return _DataAccessManager.DeleteGroup(obj)
    End Function


    <WebMethod()> <XmlInclude(GetType(Group))> _
    Public Function GetAllGroup() As List(Of Group)
        Return _DataAccessManager.GetAllGroup().Cast(Of Group).ToList()
    End Function


    <WebMethod()> <XmlInclude(GetType(Group))> _
    Public Function GetFilteredGroup(ByVal sqlFilter As String) As List(Of Group)
        Return _DataAccessManager.GetFilteredGroup(sqlFilter).Cast(Of Group).ToList()
    End Function

#End Region

End Class
