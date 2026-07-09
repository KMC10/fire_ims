
Imports IMS.Win.IMSService
Imports System.Collections
Imports System.Collections.Generic

Public Class CentralBoardDisplay

    Dim IMSProxy As New IMSServices()

    Dim lstOnEventIncidents As IList(Of IncidentRegister)
    Dim lstAssignedFireStations As IList(Of AssignedFireStation)
    Dim lstOnEventAppliances As IList(Of Appliance)
    Dim lstOnEventRiders As IList(Of Employee)
    Dim lstFireStation As IList(Of FireStation)
    Dim lstIncidentTypes As IList(Of IncidentType)

    Public Function IncidentDisplayOnCentralBoard() As DataTable
        Dim DT As New DataTable()

        lstOnEventIncidents = IMSProxy.LoadOnEventIncidents()
        lstAssignedFireStations = IMSProxy.LoadAssignedFireStations()
        lstFireStation = IMSProxy.GetAllFireStation()

        DT = AssignedValueToTable(BuildTable())
        Return DT

    End Function

    Private Function AssignedValueToTable(ByVal CentralDisplayTable As DataTable) As DataTable

        Dim DR As DataRow

        Dim lstAssignFireStation As IList(Of AssignedFireStation)

        Dim OnEventIncidentID, AssignFirestationID, OneventApplianceID As Integer
        Dim RiderCounter, IncidetCounter As Boolean

        IncidetCounter = True
        RiderCounter = True

        For Each OnEventIncident As IncidentRegister In lstOnEventIncidents

            OnEventIncidentID = OnEventIncident.IncidentID
            lstAssignFireStation = (From ASF In lstAssignedFireStations Where ASF.IncidentID = OnEventIncidentID Select ASF).ToList()

            For Each ASFireStation As AssignedFireStation In lstAssignFireStation

                AssignFirestationID = ASFireStation.StationID

                lstOnEventAppliances = IMSProxy.LoadAssignedAppliance(OnEventIncidentID, AssignFirestationID)
                lstIncidentTypes = IMSProxy.LoadAssignedIncidentTypesByIncidentID(OnEventIncidentID)

                For Each EventAppliance As Appliance In lstOnEventAppliances

                    OneventApplianceID = EventAppliance.ApplianceID
                    RiderCounter = True

                    lstOnEventRiders = IMSProxy.LoadOnEventRider(OnEventIncidentID, OneventApplianceID)

                    For Each EventRider As Employee In lstOnEventRiders
                        DR = CentralDisplayTable.NewRow()

                        If (IncidetCounter = True) Then

                            DR(IMSConstant.IncidentID) = OnEventIncidentID
                            DR(IMSConstant.IncidentName) = (From IT In lstIncidentTypes Select IT.IncidentTypeDescription).FirstOrDefault()

                            DR(IMSConstant.FireStationId) = AssignFirestationID
                            DR(IMSConstant.FireStationName) = (From FS In lstFireStation Where FS.StationID = AssignFirestationID Select FS.StationName).FirstOrDefault()

                            IncidetCounter = False
                        Else
                            DR(IMSConstant.IncidentID) = OnEventIncidentID
                            DR(IMSConstant.IncidentName) = String.Empty

                            DR(IMSConstant.FireStationId) = AssignFirestationID
                            DR(IMSConstant.FireStationName) = ""

                        End If

                        If (RiderCounter = True) Then
                            DR(IMSConstant.ApplianceID) = OneventApplianceID
                            DR(IMSConstant.ApplianceName) = EventAppliance.ApplianceName
                            RiderCounter = False
                        Else
                            DR(IMSConstant.ApplianceID) = OneventApplianceID
                            DR(IMSConstant.ApplianceName) = String.Empty
                        End If

                        DR(IMSConstant.RiderId) = EventRider.EmployeeID
                        DR(IMSConstant.RiderName) = EventRider.EmployeeName

                        CentralDisplayTable.Rows.Add(DR)

                    Next

                Next


            Next

        Next

        Return CentralDisplayTable
    End Function

    Public Function BuildTable()

        Dim CentralDisplayTable As New DataTable(IMSConstant.CentralDisplayBoard)

        Dim IncidentId As New DataColumn
        Dim IncidentName As New DataColumn
        Dim FireStationId As New DataColumn
        Dim FireStationName As New DataColumn
        Dim ApplianceID As New DataColumn
        Dim ApplianceName As New DataColumn
        Dim RiderId As New DataColumn
        Dim RiderName As New DataColumn

        IncidentId.DataType = System.Type.GetType(IMSConstant.IntType)
        IncidentId.ColumnName = IMSConstant.IncidentID
        CentralDisplayTable.Columns.Add(IncidentId)

        IncidentName.DataType = System.Type.GetType(IMSConstant.StringType)
        IncidentName.ColumnName = IMSConstant.IncidentName
        CentralDisplayTable.Columns.Add(IncidentName)

        FireStationId.DataType = System.Type.GetType(IMSConstant.IntType)
        FireStationId.ColumnName = IMSConstant.FireStationId
        CentralDisplayTable.Columns.Add(FireStationId)

        FireStationName.DataType = System.Type.GetType(IMSConstant.StringType)
        FireStationName.ColumnName = IMSConstant.FireStationName
        CentralDisplayTable.Columns.Add(FireStationName)

        ApplianceID.DataType = System.Type.GetType(IMSConstant.IntType)
        ApplianceID.ColumnName = IMSConstant.ApplianceID
        CentralDisplayTable.Columns.Add(ApplianceID)

        ApplianceName.DataType = System.Type.GetType(IMSConstant.StringType)
        ApplianceName.ColumnName = IMSConstant.ApplianceName
        CentralDisplayTable.Columns.Add(ApplianceName)

        RiderId.DataType = System.Type.GetType(IMSConstant.IntType)
        RiderId.ColumnName = IMSConstant.RiderId
        CentralDisplayTable.Columns.Add(RiderId)

        RiderName.DataType = System.Type.GetType(IMSConstant.StringType)
        RiderName.ColumnName = IMSConstant.RiderName
        CentralDisplayTable.Columns.Add(RiderName)

        Return CentralDisplayTable

    End Function

End Class
