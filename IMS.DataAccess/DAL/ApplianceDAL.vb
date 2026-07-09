Imports FrameworkX.ObjectSpace
Imports System.Linq
Imports IMS.DataAccess.DBHelper

Namespace DAL

    Partial Public Class DataAcessManager

#Region "Codes for Appliance"

        ''' <summary>
        ''' Method to insert applience
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <remarks></remarks>
        Public Function InsertAppliance(ByVal obj As DTO.Appliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.ApplianceID = KeyGen.GetAutoKey(GetType(DTO.Appliance), "ApplianceID")

                If obj.ApplianceID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.ApplianceID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to update appliance
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateAppliance(ByVal obj As DTO.Appliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to delete appliance
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteAppliance(ByVal obj As DTO.Appliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.Appliance), obj.ApplianceID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all appliance
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllAppliance() As List(Of DTO.Appliance)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Appliance)).Cast(Of DTO.Appliance).ToList()
        End Function

        ''' <summary>
        ''' Method to get filtered appliance
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredAppliance(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Appliance), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get appliance by ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetApplianceByID(ByVal ID As Integer) As DTO.Appliance
            Dim obj As DTO.Appliance = Nothing
            Dim filter As String = String.Format("ApplianceID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Appliance), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Appliance)
            End If
            Return obj
        End Function

        ' ''' <summary>
        ' ''' Method to insert assigned appliance
        ' ''' </summary>
        ' ''' <param name="obj"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function InsertAssignedAppliance(ByVal obj As DTO.AssignedAppliance) As Integer
        '    Try
        '        Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '        Return db.Insert(obj)
        '    Catch exp As Exception
        '        Throw exp
        '    End Try
        'End Function

        ' ''' <summary>
        ' ''' Method to update assigned appliance
        ' ''' </summary>
        ' ''' <param name="obj"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function UpdateAssignedAppliance(ByVal obj As DTO.AssignedAppliance) As Integer
        '    Try
        '        Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '        db.Update(obj)
        '    Catch exp As Exception
        '        Throw exp
        '    End Try
        'End Function

        ' ''' <summary>
        ' ''' Method to delete assigned appliance.
        ' ''' </summary>
        ' ''' <param name="obj"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function DeleteAssignedAppliance(ByVal obj As DTO.AssignedAppliance) As Integer
        '    Try
        '        Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '        Return db.Delete(GetType(DTO.AssignedAppliance), obj.AssignedApplianceID)
        '    Catch exp As Exception
        '        Throw exp
        '    End Try
        'End Function

        ' ''' <summary>
        ' ''' Method to get all assigned appliance
        ' ''' </summary>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function GetAllAssignedAppliance() As List(Of DTO.AssignedAppliance)
        '    Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '    Return db.SelectAll(GetType(DTO.AssignedAppliance)).Cast(Of DTO.AssignedAppliance).ToList()
        'End Function

        ' ''' <summary>
        ' ''' Method to get filtered assigned appliance
        ' ''' </summary>
        ' ''' <param name="sqlFilter"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function GetFilteredAssignedAppliance(ByVal sqlFilter As String) As IList
        '    Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '    Dim usr As IList = CType(db.SelectBy(GetType(DTO.AssignedAppliance), sqlFilter, ""), IList)
        '    Return usr
        'End Function

        ' ''' <summary>
        ' ''' Method get assigned appliance by ID
        ' ''' </summary>
        ' ''' <param name="ID"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        'Public Function GetAssignedApplianceByID(ByVal ID As Integer) As DTO.AssignedAppliance
        '    Dim obj As DTO.AssignedAppliance = Nothing
        '    Dim filter As String = String.Format("AssignedApplianceID = {0} ", ID)
        '    Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '    Dim objs As IList = db.SelectBy(GetType(DTO.AssignedAppliance), filter, "")
        '    If (objs.Count > 0) Then
        '        obj = CType(objs(0), DTO.AssignedAppliance)
        '    End If
        '    Return obj
        'End Function

        ''' <summary>
        ''' Load Appliance by Firestation and Incident Id to assign appliance of a particular Incident.
        ''' </summary>
        ''' <param name="SataionId"></param>
        ''' <param name="IncidentId"></param>
        ''' <returns>List of Appliance</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordsByStationAndIncidentID(ByVal SataionId As Integer, ByVal IncidentId As Integer) As List(Of DTO.Appliance)

            'Dim filter As String = String.Format(" StationID = {0} AND ApplianceStatus = 2 AND IsDeleted = 'false' AND ApplianceID IN (SELECT ApplianceID FROM AssignedAppliance WHERE IncidentID = {1} AND IsDeleted = 'false') ", SataionId, IncidentId)
            Dim filter As String = String.Format(" StationID = {0} AND IsDeleted = 'false' AND ApplianceID IN (SELECT ApplianceID FROM AssignedAppliance WHERE IncidentID = {1} AND IsDeleted = 'false') ", SataionId, IncidentId)
            Return Me.GetFilteredAppliance(filter).Cast(Of DTO.Appliance).ToList()

        End Function

        ''' <summary>
        ''' Load appliances which are available
        ''' </summary>
        ''' <returns>List of Appliance</returns>
        ''' <remarks></remarks>
        Public Function LoadAvailableAppliances() As List(Of DTO.Appliance)

            Dim filter As String = " ApplianceStatus = 1 AND IsDeleted = 'false' ORDER BY StationID ASC "
            Return Me.GetFilteredAppliance(filter).Cast(Of DTO.Appliance).ToList()

        End Function

        ''' <summary>
        ''' Load appliances which are on the event
        ''' </summary>
        ''' <returns>List of Appliance</returns>
        ''' <remarks></remarks>
        Public Function LoadOnEventAppliances() As List(Of DTO.Appliance)

            Dim filter As String = " ApplianceStatus = 2 AND IsDeleted = 'false' ORDER BY StationID ASC "
            Return Me.GetFilteredAppliance(filter).Cast(Of DTO.Appliance).ToList()

        End Function

        ''' <summary>
        ''' Load appliances which are on maintenance
        ''' </summary>
        ''' <returns>List of Appliance</returns>
        ''' <remarks></remarks>
        Public Function LoadOnMaintananceAppliances() As List(Of DTO.Appliance)

            Dim filter As String = " ApplianceStatus = 3 AND IsDeleted = 'false' ORDER BY StationID ASC "
            Return Me.GetFilteredAppliance(filter).Cast(Of DTO.Appliance).ToList()

        End Function

        ''' <summary>
        ''' Add Assigned Appliances into AssignedAppliance table and Update Appliances Status on the Appliance table
        ''' </summary>
        ''' <param name="lstAssignedAppliance"></param>
        ''' <param name="lstAppliancesOnEvent"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function AddRecords(ByVal lstAssignedAppliance As List(Of DTO.AssignedAppliance), ByVal lstAppliancesOnEvent As List(Of DTO.Appliance)) As Boolean

            'TODO: Apply transaction

            Try

                For Each objAssignedApplience As DTO.AssignedAppliance In lstAssignedAppliance
                    Me.InsertAssignedAppliance(objAssignedApplience)
                Next

                'Update Appliance Status 'available' to 'on the event' in Appliance Table
                For Each objAppliance As DTO.Appliance In lstAppliancesOnEvent
                    Me.UpdateAppliance(objAppliance)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return True

        End Function

        ''' <summary>
        ''' Add New Assigned Appliance, Release Previous Assigned Appliance or change incident status 'on going' to 'solved' if required
        ''' </summary>
        ''' <param name="lstNewAssignedAppliance"></param>
        ''' <param name="lstReleaseAppliances"></param>
        ''' <param name="lstAppliancesOnEvent"></param>
        ''' <param name="IncidentId"></param>
        ''' <param name="FirestationId"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function AddOrRelease(ByVal lstNewAssignedAppliance As List(Of DTO.AssignedAppliance), ByVal lstReleaseAppliances As List(Of DTO.Appliance), ByVal lstAppliancesOnEvent As List(Of DTO.Appliance), ByVal IncidentId As Integer, ByVal FirestationId As Integer) As Boolean
            'ApplianceStatus = 1 -> Aviable Appliances.
            'ApplianceStatus = 2 -> Assigned to a Incident.
            'ApplianceStatus = 3 -> Appliance Is In Maintanance.

            'TODO: Apply transaction

            Try

                For Each objAssignedApplience As DTO.AssignedAppliance In lstNewAssignedAppliance
                    Me.InsertAssignedAppliance(objAssignedApplience)
                Next

                'Update Appliance Status 'on the event' to 'available' in Appliance Table
                For Each objAppliance As DTO.Appliance In lstReleaseAppliances
                    Me.UpdateAppliance(objAppliance)
                Next

                'Update Appliance Status 'available' to 'on the event' in Appliance Table
                For Each objAppliance As DTO.Appliance In lstAppliancesOnEvent
                    Me.UpdateAppliance(objAppliance)
                Next

            Catch ex As Exception
                Throw ex
            End Try

            Return True

        End Function

        ''' <summary>
        ''' Load AssignedAppliances by Incident Id
        ''' </summary>
        ''' <param name="IncidentID"></param>
        ''' <returns>List of AssignedAppliance</returns>
        ''' <remarks></remarks>
        Public Function LoadAssignedApplianceByIncidentID(ByVal IncidentID As Integer) As List(Of DTO.AssignedAppliance)

            Dim filter As String = String.Format(" IncidentID = {0} ", IncidentID)

            Try
                Return Me.GetFilteredAssignedAppliance(filter).Cast(Of DTO.AssignedAppliance).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load AssignedAppliance by AssignedApplianceId
        ''' </summary>
        ''' <param name="AssignedApplianceId"></param>
        ''' <returns>AssignedAppliance</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordByKey(ByVal AssignedApplianceId As Integer) As DTO.AssignedAppliance

            Try
                Return Me.GetAssignedApplianceByID(AssignedApplianceId)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load Appliance to update appliance status
        ''' </summary>
        ''' <param name="ApplianceID"></param>
        ''' <returns>Appliance</returns>
        ''' <remarks></remarks>
        Public Function LoadApplianceByKey(ByVal ApplianceID As Integer) As DTO.Appliance

            Try
                Return Me.GetApplianceByID(ApplianceID)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load All Assigned Appliances that is assigned on a particular Incidents
        ''' By IncidentId and FireStationID
        ''' </summary>
        ''' <param name="IncidentID">IncidentID</param>
        ''' <param name="FireStationID">FireStationID</param>
        ''' <returns>List of all Appliances</returns>
        ''' <remarks></remarks>
        Public Function LoadAssignedAppliance(ByVal IncidentID As Integer, ByVal FireStationID As Integer) As List(Of DTO.Appliance)

            Try
                Dim filter As String = String.Format(" StationID = {0} AND ApplianceStatus = 2 AND IsDeleted = 'false' AND ApplianceID IN ( SELECT ApplianceID FROM AssignedAppliance WHERE IsDeleted = 'false' AND IncidentID IN (SELECT IncidentID FROM IncidentRegister WHERE IncidentStatus IN (2,3) AND IsDeleted = 'false' AND IncidentID = {1} ))", FireStationID, IncidentID)
                Return Me.GetFilteredAppliance(filter).Cast(Of DTO.Appliance).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function




#End Region

#Region "Codes for ApplianceRegister"

        ' Here goes codes for Insert Statements
        Public Function InsertApplianceRegister(ByVal obj As DTO.ApplianceRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.ApplianceRegisterID = KeyGen.GetAutoKey(GetType(DTO.ApplianceRegister), "ApplianceRegisterID")

                If obj.ApplianceRegisterID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.ApplianceRegisterID
                End If

                Return insertedID

            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateApplianceRegister(ByVal obj As DTO.ApplianceRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteApplianceRegister(ByVal obj As DTO.ApplianceRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.ApplianceRegister), obj.ApplianceRegisterID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &ApplianceRegister
        Public Function GetAllApplianceRegister() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.ApplianceRegister))
        End Function
        ' Here goes codes for Filtered Records call for the table &ApplianceRegister
        Public Function GetFilteredApplianceRegister(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.ApplianceRegister), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetApplianceRegisterByID(ByVal ID As Integer) As DTO.ApplianceRegister
            Dim obj As DTO.ApplianceRegister = Nothing
            Dim filter As String = String.Format("MappingID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.ApplianceRegister), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.ApplianceRegister)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for ApplianceMapping"

        ' Here goes codes for Insert Statements
        Public Function InsertApplianceMapping(ByVal obj As DTO.ApplianceMapping) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.MappingID = KeyGen.GetAutoKey(GetType(DTO.ApplianceMapping), "MappingID")

                If obj.MappingID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.MappingID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateApplianceMapping(ByVal obj As DTO.ApplianceMapping) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteApplianceMapping(ByVal obj As DTO.ApplianceMapping) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.ApplianceMapping), obj.MappingID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &ApplianceMapping
        Public Function GetAllApplianceMapping() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.ApplianceMapping))
        End Function
        ' Here goes codes for Filtered Records call for the table &ApplianceMapping
        Public Function GetFilteredApplianceMapping(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.ApplianceMapping), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetApplianceMappingByID(ByVal ID As Integer) As DTO.ApplianceMapping
            Dim obj As DTO.ApplianceMapping = Nothing
            Dim filter As String = String.Format("MappingID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.ApplianceMapping), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.ApplianceMapping)
            End If
            Return obj
        End Function

#End Region



    End Class

End Namespace

