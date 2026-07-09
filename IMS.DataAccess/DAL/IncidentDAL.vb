Imports FrameworkX.ObjectSpace
Imports System.Linq
Imports IMS.DataAccess.DBHelper
Imports System.Threading

Namespace DAL

    Public Class SQLQueryConstants
        Public Const VIEW_INCIDENT_MESSAGE_SQL As String = "SELECT Employee.EmployeeName, EmployeeType.EmpTypeDescription, IncidentMessage.InsertionDate, IncidentMessage.MessageText " +
        "FROM Employee,EmployeeType,IncidentMessage " +
        "WHERE IncidentMessage.EmployeeID = Employee.EmployeeID and Employee.EmpTypeID=EmployeeType.EmpTypeID AND IncidentMessage.IncidentID = {0} " +
        "Order by IncidentMessage.InsertionDate desc"
    End Class

    Partial Public Class DataAcessManager

#Region "Member Variable"

        Private Shared sharedObject As New Object

#End Region

#Region "Codes for IncidentRegister"

        ''' <summary>
        ''' Method to insert incident register
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertIncidentRegister(ByVal obj As DTO.IncidentRegister) As Integer

            Monitor.Enter(sharedObject)

            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.IncidentID = KeyGen.GetAutoKey(GetType(DTO.IncidentRegister), "IncidentID")

                If obj.IncidentID > 0 Then
                    obj.ReferenceNo = GetReference()
                    db.Insert(obj)
                    insertedID = obj.IncidentID
                End If

                Return insertedID

            Catch exp As Exception
                Throw exp
            Finally
                Monitor.Exit(sharedObject)
            End Try

        End Function

        ''' <summary>
        ''' Method to update incident register.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateIncidentRegister(ByVal obj As DTO.IncidentRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to delete incident register.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteIncidentRegister(ByVal obj As DTO.IncidentRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.IncidentRegister), obj.IncidentID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all incident register.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllIncidentRegister() As List(Of DTO.IncidentRegister)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.IncidentRegister)).Cast(Of DTO.IncidentRegister).ToList()
        End Function

        ''' <summary>
        ''' Method to get filtered incident register.
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredIncidentRegister(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.IncidentRegister), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get incident register by ID
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIncidentRegisterByID(ByVal ID As Integer) As DTO.IncidentRegister
            Dim obj As DTO.IncidentRegister = Nothing
            Dim filter As String = String.Format("IncidentID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.IncidentRegister), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.IncidentRegister)
            End If
            Return obj
        End Function

        ' ''' <summary>
        ' ''' Method to load view incident message of employee
        ' ''' </summary>
        ' ''' <param name="incidentID"></param>
        ' ''' <returns></returns>
        ' ''' <remarks></remarks>
        ' ''Public Function LoadEmployeeIncidentMesssage(ByVal incidentID As Integer) As IList
        ' ''    Dim filter As String = String.Format(SQLQueryConstants.VIEW_INCIDENT_MESSAGE_SQL, incidentID)
        ' ''    Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        ' ''    Dim objs As IList = db.PassthroughSQL(Of ViewModels.EmployeeIncidentMessage)(filter)
        ' ''    Return objs
        ' ''End Function

        ''' <summary>
        ''' Methdo to insert incident type.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertIncidentType(ByVal obj As DTO.IncidentType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.IncidentTypeID = KeyGen.GetAutoKey(GetType(DTO.IncidentType), "IncidentTypeID")

                If obj.IncidentTypeID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.IncidentTypeID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to update incident type.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateIncidentType(ByVal obj As DTO.IncidentType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Methdo to delete incident type.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteIncidentType(ByVal obj As DTO.IncidentType)
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.IncidentType), obj.IncidentTypeID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all incident type.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllIncidentType() As List(Of DTO.IncidentType)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.IncidentType)).Cast(Of DTO.IncidentType).ToList()
        End Function

        ''' <summary>
        ''' Method to get filtered incident type.
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredIncidentType(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.IncidentType), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get incident type by id.
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIncidentTypeByID(ByVal ID As Integer) As DTO.IncidentType
            Dim obj As DTO.IncidentType = Nothing
            Dim filter As String = String.Format("IncidentTypeID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.IncidentType), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.IncidentType)
            End If
            Return obj
        End Function

        ''' <summary>
        ''' Method to insert assigned incident type.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertAssignedIncidentType(ByVal obj As DTO.AssignedIncidentType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Insert(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to update assigned incident type.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateAssignedIncidentType(ByVal obj As DTO.AssignedIncidentType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to delete assigned incident type.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteAssignedIncidentType(ByVal obj As DTO.AssignedIncidentType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.AssignedIncidentType), obj.AssignedIncidentTypeID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all assigned incident type
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllAssignedIncidentType() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.AssignedIncidentType))
        End Function

        ''' <summary>
        ''' Method to get filtered assigned incident type.
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredAssignedIncidentType(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.AssignedIncidentType), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get assigned incident type by ID.
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAssignedIncidentTypeByID(ByVal ID As Integer) As DTO.AssignedIncidentType
            Dim obj As DTO.AssignedIncidentType = Nothing
            Dim filter As String = String.Format("AssignedIncidentTypeID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.AssignedIncidentType), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.AssignedIncidentType)
            End If
            Return obj
        End Function

        ''' <summary>
        ''' Method to insert incident message.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function InsertIncidentMessage(ByVal obj As DTO.IncidentMessage) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Insert(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to update incident message.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function UpdateIncidentMessage(ByVal obj As DTO.IncidentMessage) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to delete incident message.
        ''' </summary>
        ''' <param name="obj"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function DeleteIncidentMessage(ByVal obj As DTO.IncidentMessage) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.IncidentMessage), obj.MessageID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function

        ''' <summary>
        ''' Method to get all incident message.
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetAllIncidentMessage() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.IncidentMessage))
        End Function

        ''' <summary>
        ''' Method to get filtered incident message.
        ''' </summary>
        ''' <param name="sqlFilter"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetFilteredIncidentMessage(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.IncidentMessage), sqlFilter, ""), IList)
            Return usr
        End Function

        ''' <summary>
        ''' Method to get incident message by ID.
        ''' </summary>
        ''' <param name="ID"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GetIncidentMessageByID(ByVal ID As Integer) As DTO.IncidentMessage
            Dim obj As DTO.IncidentMessage = Nothing
            Dim filter As String = String.Format("MessageID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.IncidentMessage), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.IncidentMessage)
            End If
            Return obj
        End Function

        ''' <summary>
        ''' Add an incident with required information
        ''' </summary>
        ''' <param name="DTOIncidentRegistration"></param>
        ''' <param name="lstAssignedIncidentType"></param>
        ''' <param name="lstAssignedFireStation"></param>
        ''' <param name="DTOIncidentMessage"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function AddRecord(ByVal DTOIncidentRegistration As DTO.IncidentRegister, ByVal lstAssignedIncidentType As List(Of DTO.AssignedIncidentType), ByVal lstAssignedFireStation As List(Of DTO.AssignedFireStation), ByVal DTOIncidentMessage As DTO.IncidentMessage) As Boolean

            Dim DTOAssignedIncidentType As DTO.AssignedIncidentType
            Dim DTOAssignedFireStation As DTO.AssignedFireStation

            Dim IncidentID As Integer

            Try

                ' Save incident.
                IncidentID = Me.InsertIncidentRegister(DTOIncidentRegistration)

                ' Save Assigned Incident Types
                For Each objAssignedIncidentType As DTO.AssignedIncidentType In lstAssignedIncidentType

                    DTOAssignedIncidentType = New DTO.AssignedIncidentType()
                    DTOAssignedIncidentType.IncidentID = IncidentID
                    DTOAssignedIncidentType.IncidentTypeID = objAssignedIncidentType.IncidentTypeID

                    Me.InsertAssignedIncidentType(DTOAssignedIncidentType)

                Next

                ' Save Assigned Firestations
                For Each objAssignedFireStation As DTO.AssignedFireStation In lstAssignedFireStation

                    DTOAssignedFireStation = New DTO.AssignedFireStation()
                    DTOAssignedFireStation.IncidentID = IncidentID
                    DTOAssignedFireStation.StationID = objAssignedFireStation.StationID
                    DTOAssignedFireStation.IncidentStatus = 1

                    Me.InsertAssignedFireStation(DTOAssignedFireStation)

                Next

                ' Save first incident message
                DTOIncidentMessage.IncidentID = IncidentID
                Me.InsertIncidentMessage(DTOIncidentMessage)

            Catch ex As Exception
                Throw ex
            End Try

            Return True

        End Function

        ''' <summary>
        ''' Load unsolved incidents of last 24 hours or all unsolved incident
        ''' </summary>
        ''' <param name="ShowIncidentWithinDays"></param>
        ''' <returns>List of Unsolved Incident</returns>
        ''' <remarks></remarks>
        Public Function LoadRecords(ByVal ShowIncidentWithinDays As Integer) As List(Of DTO.IncidentRegister)

            'incidentStatus = 1 -> Unsolved Incident(Registered but wait for assign appliance).
            'incidentStatus = 2 -> On Going Incident(Incident which assign appliance).
            'incidentStatus = 3 -> Solved Incident.

            Dim filter As String = String.Empty
            Dim DateFrom As New DateTime
            Dim DateTo As New DateTime

            DateFrom = DateTime.Now.AddDays(-1)
            DateTo = DateTime.Now().AddMinutes(2)

            Try
                If (ShowIncidentWithinDays = 1) Then
                    filter = String.Format(" IncidentStatus = 1 AND IsDeleted = 'false' AND (InsertionDate BETWEEN '{0}' AND '{1}') ORDER BY InsertionDate DESC", DateFrom.ToString(Constants.DateFormatToQueryShort) + " 00:00:00", DateTo.ToString(Constants.DateFormatToQueryShort) + " 23:59:59")
                Else
                    filter = " IncidentStatus = 1 AND IsDeleted = 'false' ORDER BY InsertionDate DESC"
                End If

                Return Me.GetFilteredIncidentRegister(filter).Cast(Of DTO.IncidentRegister).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load unsolved incidents of a particular firestation to assign appliance
        ''' </summary>
        ''' <param name="StationId"></param>
        ''' <returns>List of Unsolved Incident</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordsForAssignAppliance(ByVal StationId As Integer) As List(Of DTO.IncidentRegister)

            'incidentStatus = 1 -> Unsolved Incident(Registered but wait for assign appliance).
            'incidentStatus = 2 -> On Going Incident(Incident which assign appliance).
            'incidentStatus = 3 -> Solved Incident.
            Dim filter As String = String.Empty

            Try
                If (StationId <> 0) Then
                    filter = String.Format(" IsDeleted = 'false' AND IncidentStatus IN (1,2,3) AND IncidentID IN (SELECT IncidentID FROM AssignedFireStation WHERE IncidentStatus = 1 AND StationID = {0}) ORDER By IncidentID", StationId)
                Else
                    filter = " IsDeleted = 'false' AND IncidentStatus IN (1,2,3) AND IncidentID IN (SELECT IncidentID FROM AssignedFireStation WHERE IncidentStatus = 1 ) ORDER By IncidentID"
                End If

                Return Me.GetFilteredIncidentRegister(filter).Cast(Of DTO.IncidentRegister).ToList()

            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load On Going incidents of a particular firestation.
        ''' </summary>
        ''' <param name="StationId"></param>
        ''' <returns>List of On Going Incident</returns>
        ''' <remarks></remarks>
        Public Function LoadOnGoingRecords(ByVal StationId As Integer) As List(Of DTO.IncidentRegister)

            'incidentStatus = 1 -> Unsolved Incident(Registered but wait for assign appliance).
            'incidentStatus = 2 -> On Going Incident(Incident which assign appliance).
            'incidentStatus = 3 -> Solved Incident.

            Dim filter As String = String.Format(" IsDeleted = 'false' AND IncidentStatus IN (2,3) AND IncidentID IN (SELECT IncidentID FROM AssignedFireStation WHERE IncidentStatus = 2 AND StationID = {0}) ORDER By IncidentID", StationId)

            Try
                Return Me.GetFilteredIncidentRegister(filter).Cast(Of DTO.IncidentRegister).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load incident by incident id.
        ''' </summary>
        ''' <param name="IncidentID"></param>
        ''' <returns>Incident</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordByIncidentID(ByVal IncidentID As Integer) As DTO.IncidentRegister

            Try
                Return Me.GetIncidentRegisterByID(IncidentID)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Function UpdateRecord(ByVal DTOIncident As DTO.IncidentRegister, ByVal IncidentId As Integer) As Boolean

            Try
                Me.UpdateIncidentRegister(DTOIncident)

            Catch ex As Exception
                Throw ex
            End Try

            Return True

        End Function

        ''' <summary>
        ''' Load on-going incident
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadOnEventIncidents() As List(Of DTO.IncidentRegister)

            Dim filter As String = " IsDeleted = 'false' AND IncidentStatus IN (2,3) AND IncidentID IN (SELECT IncidentID FROM AssignedFireStation WHERE IncidentStatus = 2) ORDER By IncidentID"

            Try
                Return Me.GetFilteredIncidentRegister(filter).Cast(Of DTO.IncidentRegister).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load All Solved Incidents
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function LoadSolvedIncidents() As List(Of DTO.IncidentRegister)

            Dim filter As String = " IsDeleted = 'false' AND IncidentStatus = 3 AND IncidentID IN (SELECT IncidentID FROM AssignedFireStation WHERE IncidentStatus = 3) ORDER By IncidentID"

            Try
                Return Me.GetFilteredIncidentRegister(filter).Cast(Of DTO.IncidentRegister).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load the first incident type by Incident Id
        ''' </summary>
        ''' <param name="IncidentId"></param>
        ''' <returns>Incident Type</returns>
        ''' <remarks></remarks>
        Public Function LoadIncidentTypeDescriptionByIncidentId(ByVal IncidentId As Integer) As String

            Dim result As String = String.Empty
            Dim DTOAssignedIncidentType As DTO.AssignedIncidentType = Nothing
            Dim objIncidentType As DTO.IncidentType = Nothing

            Dim filter As String = String.Format(" IncidentID = {0} ", IncidentId)

            Try
                DTOAssignedIncidentType = Me.GetFilteredAssignedIncidentType(filter).Cast(Of DTO.AssignedIncidentType).FirstOrDefault()

                If Not IsNothing(DTOAssignedIncidentType) Then
                    objIncidentType = Me.GetIncidentTypeByID(DTOAssignedIncidentType.IncidentTypeID)

                    If Not IsNothing(objIncidentType) Then
                        result = objIncidentType.IncidentTypeDescription
                    End If

                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return result

        End Function

        ''' <summary>
        ''' Load Incident Types by Incident Id.
        ''' </summary>
        ''' <param name="IncidentId"></param>
        ''' <returns>List of Incident Type</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordsByIncidentId(ByVal IncidentId As Integer) As List(Of DTO.IncidentType)

            Dim filter As String = String.Format(" IncidentTypeID IN (SELECT IncidentTypeID FROM AssignedIncidentType WHERE IncidentID = {0})", IncidentId)

            Try
                Return Me.GetFilteredIncidentType(filter).Cast(Of DTO.IncidentType).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ' ''' <summary>
        ' ''' Load Employee Name, Employee Type, Date of Message and Messages
        ' ''' </summary>
        ' ''' <param name="IncidentId"></param>
        ' ''' <returns>List Incident Message</returns>
        ' ''' <remarks></remarks>
        'Public Function LoadRecords(ByVal IncidentId As Integer) As List(Of USP_ViewIncidentMessageResult)
        '    Dim DataContext As New IMSDCDataContext
        '    Dim lstIncidentMessage As List(Of USP_ViewIncidentMessageResult)

        '    Try
        '        lstIncidentMessage = DataContext.USP_ViewIncidentMessage(IncidentId).ToList()
        '    Catch ex As Exception
        '        Throw ex
        '    End Try

        '    Return lstIncidentMessage

        'End Function

        ''' <summary>
        ''' Load First Message of Incident of particular Incident by Incident Id
        ''' </summary>
        ''' <param name="IncidentId"></param>
        ''' <returns>Incident Message</returns>
        ''' <remarks></remarks>
        Public Function LoadFirstMessageOfIncidentByIncidentId(ByVal IncidentId As Integer) As String

            Dim FirstIncidentMessage As String = String.Empty
            Dim objIncidentMessage As DTO.IncidentMessage = Nothing
            Dim filter As String = String.Format(" IncidentID = {0}", IncidentId)

            Try
                objIncidentMessage = Me.GetFilteredIncidentMessage(filter).Cast(Of DTO.IncidentMessage).FirstOrDefault()

                If Not IsNothing(objIncidentMessage) Then
                    FirstIncidentMessage = objIncidentMessage.MessageText
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return FirstIncidentMessage

        End Function

        ''' <summary>
        ''' Add an Incident Message of selected Incident
        ''' </summary>
        ''' <param name="DTOIncidentMessage"></param>
        ''' <returns>Boolean</returns>
        ''' <remarks></remarks>
        Public Function AddRecord(ByVal DTOIncidentMessage As DTO.IncidentMessage) As Boolean

            Try
                Me.InsertIncidentMessage(DTOIncidentMessage)
            Catch ex As Exception
                Throw ex
            End Try

            Return True

        End Function


#Region "Codes for OccurrenceBook"

        ' Here goes codes for Insert Statements
        Public Function InsertOccurrenceBook(ByVal obj As DTO.OccurrenceBook) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.OccurrenceBookID = KeyGen.GetAutoKey(GetType(DTO.OccurrenceBook), "OccurrenceBookID")

                If obj.OccurrenceBookID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.OccurrenceBookID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateOccurrenceBook(ByVal obj As DTO.OccurrenceBook) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteOccurrenceBook(ByVal obj As DTO.OccurrenceBook) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.OccurrenceBook), obj.OccurrenceBookID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &OccurrenceBook
        Public Function GetAllOccurrenceBook() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.OccurrenceBook))
        End Function
        ' Here goes codes for Filtered Records call for the table &OccurrenceBook
        Public Function GetFilteredOccurrenceBook(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.OccurrenceBook), sqlFilter, ""), IList)
            Return usr
        End Function

        'This is an pice of code for Specific Records of a table
        Public Function GetOccurrenceBookByID(ByVal ID As Integer) As DTO.OccurrenceBook
            Dim obj As DTO.OccurrenceBook = Nothing
            Dim filter As String = String.Format("OccurrenceBookID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.OccurrenceBook), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.OccurrenceBook)
            End If
            Return obj
        End Function

#End Region


        '#Region "Codes for IncidentRegister"

        '        ' Here goes codes for Insert Statements
        '        Public Sub InsertIncidentRegister(ByVal obj As DTO.IncidentRegister)
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                db.Insert(obj)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Sub
        '        ' Here goes codes for Update Statements
        '        Public Sub UpdateIncidentRegister(ByVal obj As DTO.IncidentRegister)
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                db.Update(obj)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Sub
        '        ' Here goes codes for Delete Statements
        '        Public Sub DeleteIncidentRegister(ByVal obj As DTO.IncidentRegister)
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                db.Delete(GetType(DTO.IncidentRegister), obj.IncidentRegisterID)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Sub
        '        ' Here goes codes for All Records call for the table &IncidentRegister
        '        Public Function GetAllIncidentRegister() As IList
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Return db.SelectAll(GetType(DTO.IncidentRegister))
        '        End Function
        '        ' Here goes codes for Filtered Records call for the table &IncidentRegister
        '        Public Function GetFilteredIncidentRegister(ByVal sqlFilter As String) As IList
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Dim usr As IList = CType(db.SelectBy(GetType(DTO.IncidentRegister), sqlFilter, ""), IList)
        '            Return usr
        '        End Function
        '        'This is an pice of code for Specific Records of a table
        '        Public Function GetIncidentRegisterByID(ByVal ID As Integer) As DTO.IncidentRegister
        '            Dim obj As DTO.IncidentRegister = Nothing
        '            Dim filter As String = String.Format("IncidentRegisterID = {0} ", ID)
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Dim objs As IList = db.SelectBy(GetType(DTO.IncidentRegister), filter, "")
        '            If (objs.Count > 0) Then
        '                obj = CType(objs(0), DTO.IncidentRegister)
        '            End If
        '            Return obj
        '        End Function

        '#End Region


#Region "Codes for IncidentCategory"

        ' Here goes codes for Insert Statements
        Public Function InsertIncidentCategory(ByVal obj As DTO.IncidentCategory) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.CategoryID = KeyGen.GetAutoKey(GetType(DTO.IncidentCategory), "CategoryID")

                If obj.CategoryID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.CategoryID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateIncidentCategory(ByVal obj As DTO.IncidentCategory) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteIncidentCategory(ByVal obj As DTO.IncidentCategory) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.IncidentCategory), obj.CategoryID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &IncidentCategory
        Public Function GetAllIncidentCategory() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.IncidentCategory))
        End Function
        ' Here goes codes for Filtered Records call for the table &IncidentCategory
        Public Function GetFilteredIncidentCategory(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.IncidentCategory), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetIncidentCategoryByID(ByVal ID As Integer) As DTO.IncidentCategory
            Dim obj As DTO.IncidentCategory = Nothing
            Dim filter As String = String.Format("CategoryID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.IncidentCategory), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.IncidentCategory)
            End If
            Return obj
        End Function

#End Region


#Region "Codes for DispatchLog"

        ' Here goes codes for Insert Statements
        Public Function InsertDispatchLog(ByVal obj As DTO.DispatchLog) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.DispatchLogID = KeyGen.GetAutoKey(GetType(DTO.DispatchLog), "DispatchLogID")

                If obj.DispatchLogID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.DispatchLogID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateDispatchLog(ByVal obj As DTO.DispatchLog) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteDispatchLog(ByVal obj As DTO.DispatchLog) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.DispatchLog), obj.DispatchLogID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &DispatchLog
        Public Function GetAllDispatchLog() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.DispatchLog))
        End Function
        ' Here goes codes for Filtered Records call for the table &DispatchLog
        Public Function GetFilteredDispatchLog(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.DispatchLog), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetDispatchLogByID(ByVal ID As Integer) As DTO.DispatchLog
            Dim obj As DTO.DispatchLog = Nothing
            Dim filter As String = String.Format("DispatchLogID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.DispatchLog), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.DispatchLog)
            End If
            Return obj
        End Function

#End Region


#End Region

#Region "Codes for AssignedAppliance"

        ' Here goes codes for Insert Statements
        Public Function InsertAssignedAppliance(ByVal obj As DTO.AssignedAppliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.AssignedApplianceID = KeyGen.GetAutoKey(GetType(DTO.AssignedAppliance), "AssignedApplianceID")

                If obj.AssignedApplianceID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.AssignedApplianceID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateAssignedAppliance(ByVal obj As DTO.AssignedAppliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteAssignedAppliance(ByVal obj As DTO.AssignedAppliance) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.AssignedAppliance), obj.AssignedApplianceID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &AssignedAppliance
        Public Function GetAllAssignedAppliance() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.AssignedAppliance))
        End Function
        ' Here goes codes for Filtered Records call for the table &AssignedAppliance
        Public Function GetFilteredAssignedAppliance(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.AssignedAppliance), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetAssignedApplianceByID(ByVal ID As Integer) As DTO.AssignedAppliance
            Dim obj As DTO.AssignedAppliance = Nothing
            Dim filter As String = String.Format("AssignedApplianceID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.AssignedAppliance), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.AssignedAppliance)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for StationIncident"

        ' Here goes codes for Insert Statements
        Public Function InsertStationIncident(ByVal obj As DTO.StationIncident) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                obj.StationIncidentID = KeyGen.GetAutoKey(GetType(DTO.StationIncident), "StationIncidentID")
                If obj.StationIncidentID = 0 Then
                    Return 0
                End If
                db.Insert(obj)
                Return obj.StationIncidentID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateStationIncident(ByVal obj As DTO.StationIncident) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteStationIncident(ByVal obj As DTO.StationIncident) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.StationIncident), obj.StationIncidentID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &StationIncident
        Public Function GetAllStationIncident() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.StationIncident))
        End Function
        ' Here goes codes for Filtered Records call for the table &StationIncident
        Public Function GetFilteredStationIncident(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.StationIncident), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetStationIncidentByID(ByVal ID As Integer) As DTO.StationIncident
            Dim obj As DTO.StationIncident = Nothing
            Dim filter As String = String.Format("StationIncidentID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.StationIncident), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.StationIncident)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for IncidentTypeIncident"

        ' Here goes codes for Insert Statements
        Public Function InsertIncidentTypeIncident(ByVal obj As DTO.IncidentTypeIncident) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                obj.IncidentTypeIncidentID = KeyGen.GetAutoKey(GetType(DTO.IncidentTypeIncident), "IncidentTypeIncidentID")
                If obj.IncidentTypeIncidentID = 0 Then
                    Return 0
                End If
                db.Insert(obj)
                Return obj.IncidentTypeIncidentID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateIncidentTypeIncident(ByVal obj As DTO.IncidentTypeIncident) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteIncidentTypeIncident(ByVal obj As DTO.IncidentTypeIncident) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.IncidentTypeIncident), obj.IncidentTypeIncidentID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &IncidentTypeIncident
        Public Function GetAllIncidentTypeIncident() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.IncidentTypeIncident))
        End Function
        ' Here goes codes for Filtered Records call for the table &IncidentTypeIncident
        Public Function GetFilteredIncidentTypeIncident(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.IncidentTypeIncident), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetIncidentTypeIncidentByID(ByVal ID As Integer) As DTO.IncidentTypeIncident
            Dim obj As DTO.IncidentTypeIncident = Nothing
            Dim filter As String = String.Format("IncidentTypeIncidentID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.IncidentTypeIncident), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.IncidentTypeIncident)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for Casualities"

        ' Here goes codes for Insert Statements
        Public Function InsertCasualities(ByVal obj As DTO.Casualities) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                obj.CasualitiesID = KeyGen.GetAutoKey(GetType(DTO.Casualities), "CasualitiesID")
                If obj.CasualitiesID = 0 Then
                    Return 0
                End If
                db.Insert(obj)
                Return obj.CasualitiesID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateCasualities(ByVal obj As DTO.Casualities) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteCasualities(ByVal obj As DTO.Casualities) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.Casualities), obj.CasualitiesID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &Casualities
        Public Function GetAllCasualities() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Casualities))
        End Function
        ' Here goes codes for Filtered Records call for the table &Casualities
        Public Function GetFilteredCasualities(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Casualities), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetCasualitiesByID(ByVal ID As Integer) As DTO.Casualities
            Dim obj As DTO.Casualities = Nothing
            Dim filter As String = String.Format("CasualitiesID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Casualities), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Casualities)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for PersonsRescuedAndEscaping"

        ' Here goes codes for Insert Statements
        Public Function InsertPersonsRescuedAndEscaping(ByVal obj As DTO.PersonsRescuedAndEscaping) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                obj.RescuedID = KeyGen.GetAutoKey(GetType(DTO.PersonsRescuedAndEscaping), "RescuedID")
                If obj.RescuedID = 0 Then
                    Return 0
                End If
                db.Insert(obj)
                Return obj.RescuedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdatePersonsRescuedAndEscaping(ByVal obj As DTO.PersonsRescuedAndEscaping) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeletePersonsRescuedAndEscaping(ByVal obj As DTO.PersonsRescuedAndEscaping) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.PersonsRescuedAndEscaping), obj.RescuedID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &PersonsRescuedAndEscaping
        Public Function GetAllPersonsRescuedAndEscaping() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.PersonsRescuedAndEscaping))
        End Function
        ' Here goes codes for Filtered Records call for the table &PersonsRescuedAndEscaping
        Public Function GetFilteredPersonsRescuedAndEscaping(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.PersonsRescuedAndEscaping), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetPersonsRescuedAndEscapingByID(ByVal ID As Integer) As DTO.PersonsRescuedAndEscaping
            Dim obj As DTO.PersonsRescuedAndEscaping = Nothing
            Dim filter As String = String.Format("RescuedID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.PersonsRescuedAndEscaping), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.PersonsRescuedAndEscaping)
            End If
            Return obj
        End Function

#End Region

    End Class

End Namespace
