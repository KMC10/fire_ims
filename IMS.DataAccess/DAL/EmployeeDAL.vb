Imports FrameworkX.ObjectSpace
Imports System.Linq
Imports IMS.DataAccess.DBHelper

Namespace DAL

    Partial Public Class DataAcessManager

#Region "Codes for EmployeeUser"
        ' Here goes codes for Insert Statements
        Public Function InsertEmployeeUser(ByVal obj As DTO.EmployeeUser) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.RecordId = KeyGen.GetAutoKey(GetType(DTO.EmployeeUser), "RecordId")

                If obj.RecordId > 0 Then
                    db.Insert(obj)
                    insertedID = obj.RecordId
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateEmployeeUser(ByVal obj As DTO.EmployeeUser) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteEmployeeUser(ByVal obj As DTO.EmployeeUser) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.EmployeeUser), obj.RecordId)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &EmployeeUser
        Public Function GetAllEmployeeUser() As List(Of DTO.EmployeeUser)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.EmployeeUser)).Cast(Of DTO.EmployeeUser).ToList()
        End Function
        ' Here goes codes for Filtered Records call for the table &EmployeeUser
        Public Function GetFilteredEmployeeUser(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.EmployeeUser), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetEmployeeUserByID(ByVal ID As Integer) As DTO.EmployeeUser
            Dim obj As DTO.EmployeeUser = Nothing
            Dim filter As String = String.Format("RecordId = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.EmployeeUser), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.EmployeeUser)
            End If
            Return obj
        End Function
#End Region

#Region "Codes for EmployeeType"




        ' Here goes codes for Insert Statements
        Public Function InsertEmployeeType(ByVal obj As DTO.EmployeeType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.EmpTypeID = KeyGen.GetAutoKey(GetType(DTO.EmployeeType), "EmpTypeID")

                If obj.EmpTypeID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.EmpTypeID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateEmployeeType(ByVal obj As DTO.EmployeeType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteEmployeeType(ByVal obj As DTO.EmployeeType) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.EmployeeType), obj.EmpTypeID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &EmployeeType
        Public Function GetAllEmployeeType() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.EmployeeType))
        End Function
        ' Here goes codes for Filtered Records call for the table &EmployeeType
        Public Function GetFilteredEmployeeType(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.EmployeeType), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetEmployeeTypeByID(ByVal ID As Integer) As DTO.EmployeeType
            Dim obj As DTO.EmployeeType = Nothing
            Dim filter As String = String.Format("EmpTypeID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.EmployeeType), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.EmployeeType)
            End If
            Return obj
        End Function




#End Region

#Region "Codes for Employee"


        ''' <summary>
        ''' Load Employee Name by employee Id
        ''' </summary>
        ''' <param name="EmployeeId"></param>
        ''' <returns>Employee Name</returns>
        ''' <remarks></remarks>
        Public Function LoadEmployeeNameByKey(ByVal EmployeeId As Integer) As String

            Dim SelectedEmployeeName As String = String.Empty

            Try
                Dim objEmployee As DTO.Employee = Me.GetEmployeeByID(EmployeeId)

                If Not IsNothing(objEmployee) Then
                    SelectedEmployeeName = objEmployee.EmployeeName
                End If

            Catch ex As Exception
                Throw ex
            End Try

            Return SelectedEmployeeName

        End Function



        ' Here goes codes for Insert Statements
        Public Function InsertEmployee(ByVal obj As DTO.Employee) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.EmployeeID = KeyGen.GetAutoKey(GetType(DTO.Employee), "EmployeeID")

                If obj.EmployeeID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.EmployeeID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateEmployee(ByVal obj As DTO.Employee) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteEmployee(ByVal obj As DTO.Employee) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.Employee), obj.EmployeeID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &Employee
        Public Function GetAllEmployee() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Employee))
        End Function
        ' Here goes codes for Filtered Records call for the table &Employee
        Public Function GetFilteredEmployee(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Employee), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetEmployeeByID(ByVal ID As Integer) As DTO.Employee
            Dim obj As DTO.Employee = Nothing
            Dim filter As String = String.Format("EmployeeID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Employee), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Employee)
            End If
            Return obj
        End Function








#End Region

#Region "Codes for Shift"

        ' Here goes codes for Insert Statements
        Public Function InsertShift(ByVal obj As DTO.Shift) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.ShiftID = KeyGen.GetAutoKey(GetType(DTO.Shift), "ShiftID")

                If obj.ShiftID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.ShiftID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateShift(ByVal obj As DTO.Shift) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteShift(ByVal obj As DTO.Shift) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.Shift), obj.ShiftID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &Shift
        Public Function GetAllShift() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Shift))
        End Function
        ' Here goes codes for Filtered Records call for the table &Shift
        Public Function GetFilteredShift(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Shift), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetShiftByID(ByVal ID As Integer) As DTO.Shift
            Dim obj As DTO.Shift = Nothing
            Dim filter As String = String.Format("ShiftID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Shift), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Shift)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for AssignedEmployee"

        ' Here goes codes for Insert Statements
        Public Function InsertAssignedEmployee(ByVal obj As DTO.AssignedEmployee) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.AssignedEmployeeID = KeyGen.GetAutoKey(GetType(DTO.AssignedEmployee), "AssignedEmployeeID")

                If obj.AssignedEmployeeID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.AssignedEmployeeID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateAssignedEmployee(ByVal obj As DTO.AssignedEmployee) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteAssignedEmployee(ByVal obj As DTO.AssignedEmployee) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.AssignedEmployee), obj.AssignedEmployeeID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &AssignedEmployee
        Public Function GetAllAssignedEmployee() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.AssignedEmployee))
        End Function
        ' Here goes codes for Filtered Records call for the table &AssignedEmployee
        Public Function GetFilteredAssignedEmployee(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.AssignedEmployee), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetAssignedEmployeeByID(ByVal ID As Integer) As DTO.AssignedEmployee
            Dim obj As DTO.AssignedEmployee = Nothing
            Dim filter As String = String.Format("AssignedEmployeeID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.AssignedEmployee), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.AssignedEmployee)
            End If
            Return obj
        End Function

#End Region

        '#Region "Codes for Employee Register"

        '        ' Here goes codes for Insert Statements
        '        Public Function InsertEmployeeRegister(ByVal obj As DTO.EmployeeRegister) As Integer
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                Return db.Insert(obj)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Function
        '        ' Here goes codes for Update Statements
        '        Public Function UpdateEmployeeRegister(ByVal obj As DTO.EmployeeRegister) As Integer
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                Return db.Update(obj)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Function
        '        ' Here goes codes for Delete Statements
        '        Public Function DeleteEmployeeRegister(ByVal obj As DTO.EmployeeRegister) As Integer
        '            Try
        '                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '                Return db.Delete(GetType(DTO.EmployeeRegister), obj.EmployeeRegisterID)
        '            Catch exp As Exception
        '                Throw exp
        '            End Try
        '        End Function
        '        ' Here goes codes for All Records call for the table &EmployeeRegister
        '        Public Function GetAllEmployeeRegister() As IList
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Return db.SelectAll(GetType(DTO.EmployeeRegister))
        '        End Function
        '        ' Here goes codes for Filtered Records call for the table &EmployeeRegister
        '        Public Function GetFilteredEmployeeRegister(ByVal sqlFilter As String) As IList
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Dim usr As IList = CType(db.SelectBy(GetType(DTO.EmployeeRegister), sqlFilter, ""), IList)
        '            Return usr
        '        End Function
        '        'This is an pice of code for Specific Records of a table
        '        Public Function GetEmployeeRegisterByID(ByVal ID As Integer) As DTO.EmployeeRegister
        '            Dim obj As DTO.EmployeeRegister = Nothing
        '            Dim filter As String = String.Format("EmployeeRegisterID = {0} ", ID)
        '            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
        '            Dim objs As IList = db.SelectBy(GetType(DTO.EmployeeRegister), filter, "")
        '            If (objs.Count > 0) Then
        '                obj = CType(objs(0), DTO.EmployeeRegister)
        '            End If
        '            Return obj
        '        End Function

        '#End Region

#Region "Codes for EmployeeRegister"

        ' Here goes codes for Insert Statements
        Public Function InsertEmployeeRegister(ByVal obj As DTO.EmployeeRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.EmployeeRegisterID = KeyGen.GetAutoKey(GetType(DTO.EmployeeRegister), "EmployeeRegisterID")

                If obj.EmployeeRegisterID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.EmployeeRegisterID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateEmployeeRegister(ByVal obj As DTO.EmployeeRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteEmployeeRegister(ByVal obj As DTO.EmployeeRegister) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.EmployeeRegister), obj.EmployeeRegisterID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &EmployeeRegister
        Public Function GetAllEmployeeRegister() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.EmployeeRegister))
        End Function
        ' Here goes codes for Filtered Records call for the table &EmployeeRegister
        Public Function GetFilteredEmployeeRegister(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.EmployeeRegister), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetEmployeeRegisterByID(ByVal ID As Integer) As DTO.EmployeeRegister
            Dim obj As DTO.EmployeeRegister = Nothing
            Dim filter As String = String.Format("MappingID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.EmployeeRegister), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.EmployeeRegister)
            End If
            Return obj
        End Function

#End Region

#Region "Codes for Group"

        ' Here goes codes for Insert Statements
        Public Function InsertGroup(ByVal obj As DTO.Group) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Dim insertedID As Integer = 0

                obj.GroupID = KeyGen.GetAutoKey(GetType(DTO.Group), "GroupID")

                If obj.GroupID > 0 Then
                    db.Insert(obj)
                    insertedID = obj.GroupID
                End If

                Return insertedID
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Update Statements
        Public Function UpdateGroup(ByVal obj As DTO.Group) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Update(obj)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for Delete Statements
        Public Function DeleteGroup(ByVal obj As DTO.Group) As Integer
            Try
                Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
                Return db.Delete(GetType(DTO.Group), obj.GroupID)
            Catch exp As Exception
                Throw exp
            End Try
        End Function
        ' Here goes codes for All Records call for the table &Group
        Public Function GetAllGroup() As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Return db.SelectAll(GetType(DTO.Group))
        End Function
        ' Here goes codes for Filtered Records call for the table &Group
        Public Function GetFilteredGroup(ByVal sqlFilter As String) As IList
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim usr As IList = CType(db.SelectBy(GetType(DTO.Group), sqlFilter, ""), IList)
            Return usr
        End Function
        'This is an pice of code for Specific Records of a table
        Public Function GetGroupByID(ByVal ID As Integer) As DTO.Group
            Dim obj As DTO.Group = Nothing
            Dim filter As String = String.Format("GroupID = {0} ", ID)
            Dim db As Database = GetDB.GetFrameworkDB(DBConnectionString)
            Dim objs As IList = db.SelectBy(GetType(DTO.Group), filter, "")
            If (objs.Count > 0) Then
                obj = CType(objs(0), DTO.Group)
            End If
            Return obj
        End Function

#End Region

    End Class

End Namespace
