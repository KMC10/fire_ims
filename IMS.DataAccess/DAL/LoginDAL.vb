Imports FrameworkX.ObjectSpace
Imports System.Linq
Imports IMS.DataAccess.DBHelper


Namespace DAL
    Partial Public Class DataAcessManager

        ''' <summary>
        ''' Load an user by UserId and Password
        ''' </summary>
        ''' <param name="UserId"></param>
        ''' <param name="Password"></param>
        ''' <returns>User</returns>
        ''' <remarks></remarks>
        Public Function LoadRecordById(ByVal UserId As String, ByVal Password As String) As DTO.Users

            Dim filter As String = String.Format("UserID = '{0}' AND Password='{1}'", UserId, Password)
            Dim objUsers As DTO.Users = Nothing

            Try

                Dim lstUsers As List(Of DTO.Users) = GetFilteredUsers(filter).Cast(Of DTO.Users).ToList()

                If lstUsers.Count > 0 Then
                    objUsers = lstUsers(0)
                End If

                Return objUsers
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load User Type, Fire Station Id and Employee Id by UserId
        ''' </summary>
        ''' <param name="UserId"></param>
        ''' <returns>Login information(UserType,FirestationId and EmployeeId)</returns>
        ''' <remarks></remarks>
        Public Function LoadLoginInfo(ByVal UserId As String) As String
            Dim FireStationId As Integer = 0
            Dim SelectedEmployeeId As Integer = 0
            Dim UserType As String = String.Empty

            Dim filter As String = String.Format("UserID = '{0}'", UserId)

            Dim lstEmployeeUsers = GetFilteredEmployeeUser(filter).Cast(Of DTO.EmployeeUser).ToList()

            If (lstEmployeeUsers.Count > 0) Then
                SelectedEmployeeId = lstEmployeeUsers(0).EmployeeID

                Dim objEmployee = Me.GetEmployeeByID(SelectedEmployeeId)

                If Not IsNothing(objEmployee) Then
                    Dim employeeTypeID = objEmployee.EmpTypeID

                    FireStationId = objEmployee.StationID

                    Dim objEmployeeType = Me.GetEmployeeTypeByID(employeeTypeID)
                    If Not IsNothing(objEmployeeType) Then
                        UserType = objEmployeeType.EmpTypeDescription
                    End If
                End If
            End If

            Return UserType & "," & FireStationId.ToString() & "," & SelectedEmployeeId.ToString()

        End Function

#Region "Codes for Privileges"

        ' Here goes codes for Insert Statements
        Public Function InsertPrivileges(ByVal obj As DTO.Privileges) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                obj.PrivilegeID = KeyGen.GetAutoKey(GetType(DTO.Privileges), "PrivilegeID")
                If obj.PrivilegeID = 0 Then
                    Return 0
                End If
                db.Insert(obj)
                Return obj.PrivilegeID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdatePrivileges(ByVal obj As DTO.Privileges) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeletePrivileges(ByVal obj As DTO.Privileges) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.Privileges), obj.PrivilegeID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &Privileges
        Public Function GetAllPrivileges() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Privileges))
        End Function
        ' Here goes codes for Filtered Records call for the table &Privileges
        Public Function GetFilteredPrivileges(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Privileges), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetPrivilegesByID(ByVal ID As Integer) As DTO.Privileges
            Dim obj As DTO.Privileges = Nothing
            Dim filter As String = String.Format("PrivilegeID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Privileges), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Privileges)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for Roles"

        ' Here goes codes for Insert Statements
        Public Function InsertRoles(ByVal obj As DTO.Roles) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                obj.RoleID = KeyGen.GetAutoKey(GetType(DTO.Roles), "RoleID")
                If obj.RoleID = 0 Then
                    Return 0
                End If
                db.Insert(obj)
                Return obj.RoleID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateRoles(ByVal obj As DTO.Roles) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteRoles(ByVal obj As DTO.Roles) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.Roles), obj.RoleID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &Roles
        Public Function GetAllRoles() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Roles))
        End Function
        ' Here goes codes for Filtered Records call for the table &Roles
        Public Function GetFilteredRoles(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Roles), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetRolesByID(ByVal ID As Integer) As DTO.Roles
            Dim obj As DTO.Roles = Nothing
            Dim filter As String = String.Format("RolesID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Roles), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Roles)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for RolePrivileges"

        ' Here goes codes for Insert Statements
        Public Function InsertRolePrivileges(ByVal obj As DTO.RolePrivileges) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)

                db.Insert(obj)
                Return obj.RoleID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateRolePrivileges(ByVal obj As DTO.RolePrivileges) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteRolePrivileges(ByVal obj As DTO.RolePrivileges) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.RolePrivileges), obj.RoleID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &RolePrivileges
        Public Function GetAllRolePrivileges() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.RolePrivileges))
        End Function
        ' Here goes codes for Filtered Records call for the table &RolePrivileges
        Public Function GetFilteredRolePrivileges(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.RolePrivileges), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetRolePrivilegesByID(ByVal ID As Integer) As DTO.RolePrivileges
            Dim obj As DTO.RolePrivileges = Nothing
            Dim filter As String = String.Format("RolePrivilegesID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.RolePrivileges), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.RolePrivileges)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for RoleUsers"

        ' Here goes codes for Insert Statements
        Public Function InsertRoleUsers(ByVal obj As DTO.RoleUsers) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)

                db.Insert(obj)
                Return obj.RoleID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateRoleUsers(ByVal obj As DTO.RoleUsers) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteRoleUsers(ByVal obj As DTO.RoleUsers) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                db.Delete(GetType(DTO.RoleUsers), obj.RoleID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &RoleUsers
        Public Function GetAllRoleUsers() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.RoleUsers))
        End Function
        ' Here goes codes for Filtered Records call for the table &RoleUsers
        Public Function GetFilteredRoleUsers(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.RoleUsers), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetRoleUsersByID(ByVal ID As Integer) As DTO.RoleUsers
            Dim obj As DTO.RoleUsers = Nothing
            Dim filter As String = String.Format("RoleUsersID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.RoleUsers), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.RoleUsers)
            End If
            Return obj
        End Function

#End Region

    End Class
End Namespace


