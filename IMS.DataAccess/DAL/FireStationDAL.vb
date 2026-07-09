Imports FrameworkX.ObjectSpace
Imports System.Linq
Imports IMS.DataAccess.DBHelper

Namespace DAL

    Partial Public Class DataAcessManager

#Region "Codes for FireStation"

        ''' <summary>
        ''' Method to insert fire station.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertFireStation(ByVal obj As DTO.FireStation) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.StationID = KeyGen.GetAutoKey(GetType(DTO.FireStation), "StationID")

                If obj.StationID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.StationID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to update fire station.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateFireStation(ByVal obj As DTO.FireStation) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to delete fire station.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteFireStation(ByVal obj As DTO.FireStation) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.FireStation), obj.StationID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all fire station.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllFireStation() As List(Of DTO.FireStation)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.FireStation)).Cast(Of DTO.FireStation).ToList()
        End Function

        ''' <summary>
        ''' Method to get filtered fire station.
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredFireStation(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.FireStation), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get fire station by ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFireStationByID(ByVal ID As Integer) As DTO.FireStation
            Dim obj As DTO.FireStation = Nothing
            Dim filter As String = String.Format("StationID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.FireStation), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.FireStation)
            End If
            Return obj
        End Function

        ''' <summary>
        ''' Method to insert assigned fire station.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertAssignedFireStation(ByVal obj As DTO.AssignedFireStation) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Insert(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to update assigned fire station.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateAssignedFireStation(ByVal obj As DTO.AssignedFireStation) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to delete assigned fire station.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteAssignedFireStation(ByVal obj As DTO.AssignedFireStation) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.AssignedFireStation), obj.AssignedFSID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all assigned fire station.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllAssignedFireStation() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.AssignedFireStation))
        End Function

        ''' <summary>
        ''' Method to get filtered assigned fire station.
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredAssignedFireStation(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.AssignedFireStation), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get assigned fire station by ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAssignedFireStationByID(ByVal ID As Integer) As DTO.AssignedFireStation
            Dim obj As DTO.AssignedFireStation = Nothing
            Dim filter As String = String.Format("AssignedFSID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.AssignedFireStation), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.AssignedFireStation)
            End If
            Return obj
        End Function

        ''' <summary>
        ''' Load Firestations by Incident Id 
        ''' </summary>
        ''' <param name="IncidentID"></param>
        ''' <returns>List of FireStation</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordsByID(ByVal IncidentID As Integer) As List(Of DTO.FireStation)

            Dim filter As String = String.Format(" StationID IN (SELECT StationID FROM AssignedFireStation WHERE IncidentID = {0}) ", IncidentID)

            Try
                Return Me.GetFilteredFireStation(filter).Cast(Of DTO.FireStation).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Method to load assigned fire station.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadAssignedFireStations() As List(Of DTO.AssignedFireStation)

            Dim filter As String = " IncidentID IN (SELECT IncidentID FROM IncidentRegister WHERE IncidentStatus = 2) "

            Try
                Return Me.GetFilteredAssignedFireStation(filter).Cast(Of DTO.AssignedFireStation).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Method to load record by stationID and incidentID.
        ''' </summary>
        ''' <param name="StationId"></param>
        ''' <param name="IncidentId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadRecordByStationAndIncidentId(ByVal StationId As Integer, ByVal IncidentId As Integer) As DTO.AssignedFireStation

            Dim filter As String = String.Format(" IncidentID  = {0} AND StationID = {1} ", IncidentId, StationId)

            Try
                Return Me.GetFilteredAssignedFireStation(filter).Cast(Of DTO.AssignedFireStation).FirstOrDefault()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Method to update record.
        ''' </summary>
        ''' <param name="DTOAssignedFireStation"></param>
        ''' <param name="IncidentId"></param>
        ''' <param name="StationId"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateRecord(ByVal DTOAssignedFireStation As DTO.AssignedFireStation, ByVal IncidentId As Integer, ByVal StationId As Integer) As Boolean

            Dim DTOOldAssignedFireStation As DTO.AssignedFireStation

            Try
                DTOOldAssignedFireStation = LoadRecordByStationAndIncidentId(StationId, IncidentId)
                DTOAssignedFireStation.AssignedFSID = DTOOldAssignedFireStation.AssignedFSID
                DTOAssignedFireStation.IncidentID = DTOOldAssignedFireStation.IncidentID
                DTOAssignedFireStation.StationID = DTOOldAssignedFireStation.StationID

                Me.UpdateAssignedFireStation(DTOAssignedFireStation)

            Catch ex As Exception
                Throw ex
            End Try

            Return True

        End Function

        '#Region "Codes for FireStationAppliance"

        '        ' Here goes codes for Insert Statements
        '        Public Function InsertFireStationAppliance(ByVal obj As DTO.FireStationAppliance) As Integer
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                db.Insert(obj)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Function
        '        ' Here goes codes for Update Statements
        '        Public Function UpdateFireStationAppliance(ByVal obj As DTO.FireStationAppliance) As Integer
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                db.Update(obj)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Function
        '        ' Here goes codes for Delete Statements
        '        Public Function DeleteFireStationAppliance(ByVal obj As DTO.FireStationAppliance) As Integer
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                Return db.Delete(GetType(DTO.FireStationAppliance), obj.StationApplianceID)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Function
        '        ' Here goes codes for All Records call for the table &FireStationAppliance
        '        Public Function GetAllFireStationAppliance() As IList
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Return db.SelectAll(GetType(DTO.FireStationAppliance))
        '        End Function
        '        ' Here goes codes for Filtered Records call for the table &FireStationAppliance
        '        Public Function GetFilteredFireStationAppliance(ByVal sqlFilter As String) As IList
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Dim usr As IList = CType(db.SelectBy(GetType(DTO.FireStationAppliance), sqlFilter, ""), IList)
        '            Return usr
        '        End Function
        '        'This is an pice of code for Specific Records of a table
        '        Public Function GetFireStationApplianceByID(ByVal ID As Integer) As DTO.FireStationAppliance
        '            Dim obj As DTO.FireStationAppliance = Nothing
        '            Dim filter As String = String.Format("StationApplianceID = {0} ", ID)
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Dim objs As IList = db.SelectBy(GetType(DTO.FireStationAppliance), filter, "")
        '            If (objs.Count > 0) Then
        '                obj = CType(objs(0), DTO.FireStationAppliance)
        '            End If
        '            Return obj
        '        End Function

        '#End Region

#End Region


#Region "Codes for FireStationAppliance"

        ' Here goes codes for Insert Statements
        Public Function InsertFireStationAppliance(ByVal obj As DTO.FireStationAppliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.StationApplianceID = KeyGen.GetAutoKey(GetType(DTO.FireStationAppliance), "StationApplianceID")

                If obj.StationApplianceID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.StationApplianceID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateFireStationAppliance(ByVal obj As DTO.FireStationAppliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteFireStationAppliance(ByVal obj As DTO.FireStationAppliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.FireStationAppliance), obj.ApplianceID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &FireStationAppliance
        Public Function GetAllFireStationAppliance() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.FireStationAppliance))
        End Function
        ' Here goes codes for Filtered Records call for the table &FireStationAppliance
        Public Function GetFilteredFireStationAppliance(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.FireStationAppliance), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetFireStationApplianceByID(ByVal ID As Integer) As DTO.FireStationAppliance
            Dim obj As DTO.FireStationAppliance = Nothing
            Dim filter As String = String.Format("StationApplianceID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.FireStationAppliance), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.FireStationAppliance)
            End If
            Return obj
        End Function

        ''' <summary>
        ''' Method to Get All available Appliance (Satation Wise)
        ''' </summary>
        ''' <param name="stationID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAvailableApplianceBySationID(ByVal stationID As Integer) As IList
            Dim sql As String = "Status <> 3 and StationID = '" + stationID + "' and StationApplianceID Not In(Select StationApplianceID From AssignedAppliance where AssignedApplianceStatus <> 2 and AssignedApplianceStatus <> 4 )"
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.FireStationAppliance), sql, ""), IList)
            Return usr
        End Function

#End Region

    End Class

End Namespace
