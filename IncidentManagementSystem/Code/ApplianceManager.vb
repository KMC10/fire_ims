Imports IMS.Win.IMSServices

Public Class ApplianceManager

    Dim IMSProxy As New IMSServices.IMSServices()

    Public Function getApplianceStatus() As DataTable
        Dim dt As New DataTable
        dt.Columns.Add(IMSConstant.FireStationName)
        dt.Columns.Add(IMSConstant.AvailAbleApplianceName)
        dt.Columns.Add(IMSConstant.OnIncidentApplianceName)
        dt.Columns.Add(IMSConstant.OnMaintanceApplianceName)


        For Each station As FireStation In IMSProxy.GetAllFireStation
            Dim row As DataRow = dt.NewRow
            row(IMSConstant.FireStationName) = station.StationName
            Dim maintenanceAppliance As String = ""
            Dim availableAppliance As String = ""
            Dim OnIncidentAppliance As String = ""
            For Each appliance As Appliance In IMSProxy.GetFilteredAppliance("StationID=" & station.StationID)
                If appliance.ApplianceStatus = 1 Then
                    Dim lst As IList = IMSProxy.GetFilteredAssignedAppliance(" ApplianceID IN (select ApplianceID from Appliance where StationID=" & station.StationID & ") AND year(IncidentDate)=" & Today.Year & " AND month(IncidentDate)=" & Month(Today))
                    If lst.Count = 0 Then
                        availableAppliance = availableAppliance + "  " + appliance.ApplianceName
                    Else
                        For Each assignedapp As AssignedAppliance In lst
                            OnIncidentAppliance = OnIncidentAppliance + "  " + IMSProxy.GetApplianceByID(assignedapp.ApplianceID).ApplianceName
                        Next
                    End If

                Else
                    maintenanceAppliance = maintenanceAppliance + "  " + appliance.ApplianceName
                End If
            Next

            row(IMSConstant.OnMaintanceApplianceName) = maintenanceAppliance
            row(IMSConstant.AvailAbleApplianceName) = availableAppliance
            row(IMSConstant.OnIncidentApplianceName) = OnIncidentAppliance
            dt.Rows.Add(row)

        Next

        Return dt

    End Function


End Class
