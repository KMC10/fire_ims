Imports IMS.Win.IMSServices
Imports System.Collections
Imports System.Collections.Generic

Public Class StationWiseAppliances
    Dim IMSProxy As New IMSServices.IMSServices
    Dim lstAvailableAppliances As IList(Of Appliance)
    Dim lstOnEventAppliances As IList(Of Appliance)
    Dim lstOnMaintananceAppliances As IList(Of Appliance)
    Dim lstFireStation As IList(Of FireStation)

    Public Function StationAndStatusWiseAppliance() As DataTable
        Dim DT As New DataTable()

        lstAvailableAppliances = IMSProxy.AvailableAppliances()
        lstOnEventAppliances = IMSProxy.OnEventAppliances()
        lstOnMaintananceAppliances = IMSProxy.OnMaintananceAppliances()
        lstFireStation = IMSProxy.GetAllFireStation()

        DT = AssignedValueToTable(BuildTable())
        Return DT

    End Function

    Private Function AssignedValueToTable(ByVal ApplianceTable As DataTable) As DataTable
        Dim Dr As DataRow
        Dim FSID, IDS As Integer
        Dim StationCounter As Boolean = True

        Dim lstAvailableAppliance As List(Of Appliance)
        Dim lstOnEventAppliance As IList(Of Appliance)
        Dim lstOnMaintananceAppliance As IList(Of Appliance)

        Dim ONEventAppliance As New Appliance()
        Dim OnMaintanceAppliance As New Appliance()

        For Each FireStation As FireStation In lstFireStation
            StationCounter = True
            FSID = FireStation.StationID
            lstAvailableAppliance = (From AVAP In lstAvailableAppliances Where AVAP.StationID = FSID Select AVAP).ToList()

            For Each AV As Appliance In lstAvailableAppliance
                Dr = ApplianceTable.NewRow()
                If (StationCounter = True) Then
                    Dr(IMSConstant.FireStationId) = FSID
                    Dr(IMSConstant.FireStationName) = FireStation.StationName
                    StationCounter = False
                Else
                    Dr(IMSConstant.FireStationId) = FSID
                    Dr(IMSConstant.FireStationName) = String.Empty
                End If

                ONEventAppliance = (From GAP In lstOnEventAppliances Where GAP.StationID = FSID And GAP.StationID > 0 Select GAP).FirstOrDefault()
                OnMaintanceAppliance = (From MAP In lstOnMaintananceAppliances Where MAP.StationID = FSID And MAP.StationID > 0 Select MAP).FirstOrDefault()

                Dr(IMSConstant.AvailAbleApplianceID) = AV.ApplianceID
                Dr(IMSConstant.AvailAbleApplianceName) = AV.ApplianceName

                If (IsNothing(ONEventAppliance) = False) Then
                    Dr(IMSConstant.OnIncidentApplianceId) = ONEventAppliance.ApplianceID
                    Dr(IMSConstant.OnIncidentApplianceName) = ONEventAppliance.ApplianceName

                    IDS = lstOnEventAppliances.IndexOf(ONEventAppliance)
                    lstOnEventAppliances.Item(IDS).StationID = 0

                Else
                    Dr(IMSConstant.OnIncidentApplianceId) = 0
                    Dr(IMSConstant.OnIncidentApplianceName) = String.Empty
                End If

                If (IsNothing(OnMaintanceAppliance) = False) Then
                    Dr(IMSConstant.OnMaintanceApplianceId) = OnMaintanceAppliance.ApplianceID
                    Dr(IMSConstant.OnMaintanceApplianceName) = OnMaintanceAppliance.ApplianceName

                    IDS = lstOnMaintananceAppliances.IndexOf(OnMaintanceAppliance)
                    lstOnMaintananceAppliances.Item(IDS).StationID = 0

                Else
                    Dr(IMSConstant.OnMaintanceApplianceId) = 0
                    Dr(IMSConstant.OnMaintanceApplianceName) = String.Empty
                End If

                ApplianceTable.Rows.Add(Dr)
            Next

            lstOnEventAppliance = (From GAP In lstOnEventAppliances Where GAP.StationID = FSID And GAP.StationID > 0 Select GAP).ToList()

            For Each ONGAP As Appliance In lstOnEventAppliance
                Dr = ApplianceTable.NewRow()
                Dim Query = From DTA In (From P In ApplianceTable.AsEnumerable() Select New With {.SID = P(IMSConstant.FireStationId)}) Where DTA.SID = FSID Select DTA.SID Distinct

                If (Query.Count > 0) Then
                    Dr(IMSConstant.FireStationId) = FSID
                    Dr(IMSConstant.FireStationName) = String.Empty
                Else
                    Dr(IMSConstant.FireStationId) = FSID
                    Dr(IMSConstant.FireStationName) = FireStation.StationName
                End If

                Dr(IMSConstant.OnIncidentApplianceId) = ONGAP.ApplianceID
                Dr(IMSConstant.OnIncidentApplianceName) = ONGAP.ApplianceName

                OnMaintanceAppliance = (From MAP In lstOnMaintananceAppliances Where MAP.StationID = FSID And MAP.StationID > 0 Select MAP).FirstOrDefault()

                If (IsNothing(OnMaintanceAppliance) = False) Then
                    Dr(IMSConstant.OnMaintanceApplianceId) = OnMaintanceAppliance.ApplianceID
                    Dr(IMSConstant.OnMaintanceApplianceName) = OnMaintanceAppliance.ApplianceName

                    IDS = lstOnMaintananceAppliances.IndexOf(OnMaintanceAppliance)
                    lstOnMaintananceAppliances.Item(IDS).StationID = 0

                Else
                    Dr(IMSConstant.OnMaintanceApplianceId) = 0
                    Dr(IMSConstant.OnMaintanceApplianceName) = String.Empty
                End If

                ApplianceTable.Rows.Add(Dr)
            Next

            lstOnMaintananceAppliance = (From MAP In lstOnMaintananceAppliances Where MAP.StationID = FSID And MAP.StationID > 0 Select MAP).ToList()

            For Each ONMAP As Appliance In lstOnMaintananceAppliance

                Dr = ApplianceTable.NewRow()

                Dim Query = From DTA In (From P In ApplianceTable.AsEnumerable() Select New With {.SID = P(IMSConstant.FireStationId)}) Where DTA.SID = FSID Select DTA.SID Distinct

                If (Query.Count > 0) Then
                    Dr(IMSConstant.FireStationId) = FSID
                    Dr(IMSConstant.FireStationName) = String.Empty
                Else
                    Dr(IMSConstant.FireStationId) = FSID
                    Dr(IMSConstant.FireStationName) = FireStation.StationName
                End If

                Dr(IMSConstant.OnMaintanceApplianceId) = 0
                Dr(IMSConstant.OnMaintanceApplianceName) = String.Empty

                Dr(IMSConstant.OnMaintanceApplianceId) = ONMAP.ApplianceID
                Dr(IMSConstant.OnMaintanceApplianceName) = ONMAP.ApplianceName

                ApplianceTable.Rows.Add(Dr)
            Next

        Next

        Return ApplianceTable

    End Function

    Public Function BuildTable()
        Dim ApplianceTable As New DataTable(IMSConstant.DTFireStationWiseAppliance)

        Dim FireStationId As New DataColumn
        Dim FireStationName As New DataColumn
        Dim AvailAbleApplianceID As New DataColumn
        Dim AvailAbleApplianceName As New DataColumn
        Dim OnIncidentApplianceId As New DataColumn
        Dim OnIncidentApplianceName As New DataColumn
        Dim OnMaintanceApplianceId As New DataColumn
        Dim OnMaintanceApplianceName As New DataColumn

        FireStationId.DataType = System.Type.GetType(IMSConstant.IntType)
        FireStationId.ColumnName = IMSConstant.FireStationId
        ApplianceTable.Columns.Add(FireStationId)

        FireStationName.DataType = System.Type.GetType(IMSConstant.StringType)
        FireStationName.ColumnName = IMSConstant.FireStationName
        ApplianceTable.Columns.Add(FireStationName)

        AvailAbleApplianceID.DataType = System.Type.GetType(IMSConstant.IntType)
        AvailAbleApplianceID.ColumnName = IMSConstant.AvailAbleApplianceID
        ApplianceTable.Columns.Add(AvailAbleApplianceID)

        AvailAbleApplianceName.DataType = System.Type.GetType(IMSConstant.StringType)
        AvailAbleApplianceName.ColumnName = IMSConstant.AvailAbleApplianceName
        ApplianceTable.Columns.Add(AvailAbleApplianceName)

        OnIncidentApplianceId.DataType = System.Type.GetType(IMSConstant.IntType)
        OnIncidentApplianceId.ColumnName = IMSConstant.OnIncidentApplianceId
        ApplianceTable.Columns.Add(OnIncidentApplianceId)

        OnIncidentApplianceName.DataType = System.Type.GetType(IMSConstant.StringType)
        OnIncidentApplianceName.ColumnName = IMSConstant.OnIncidentApplianceName
        ApplianceTable.Columns.Add(OnIncidentApplianceName)

        OnMaintanceApplianceId.DataType = System.Type.GetType(IMSConstant.IntType)
        OnMaintanceApplianceId.ColumnName = IMSConstant.OnMaintanceApplianceId
        ApplianceTable.Columns.Add(OnMaintanceApplianceId)

        OnMaintanceApplianceName.DataType = System.Type.GetType(IMSConstant.StringType)
        OnMaintanceApplianceName.ColumnName = IMSConstant.OnMaintanceApplianceName
        ApplianceTable.Columns.Add(OnMaintanceApplianceName)

        Return ApplianceTable

    End Function

End Class
