'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 06-May-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmViewEmployee
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 17
    Private lstEmployee As New List(Of IMSService.Employee)

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to Load Form Data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        Dim tblFireStation As New DataTable
        'Dim filter As String = String.Format("{0}='{1}' order by {2} asc", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No), IMSConstants.FieldConstants.EmployeeName)

        Dim skipAmount As Integer = pageIndex * listSize
        Dim filter As String = String.Format("{0}='{1}' order by {2} asc", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No), IMSConstants.FieldConstants.EmployeeName)

        Dim filterNew As String = IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnum.IMSEnums.IsDeleted.No) & " and " & _
        IMSConstants.FieldConstants.EmployeeID & " IN ( select TOP (" & listSize & ") " & IMSConstants.FieldConstants.EmployeeID & _
        " from " & IMSConstants.TableNames.Employee & " Where " & IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnum.IMSEnums.IsDeleted.No) & _
        " and " & IMSConstants.FieldConstants.EmployeeID & " NOT IN ( select TOP (" & skipAmount.ToString() & ") " & IMSConstants.FieldConstants.EmployeeID & _
        " from " & IMSConstants.TableNames.Employee & " Where " & IMSConstants.FieldConstants.IsDeleted & " = " & CInt(IMSEnum.IMSEnums.IsDeleted.No) & _
        " order by " & IMSConstants.FieldConstants.EmployeeName & " asc) " & _
         " order by " & IMSConstants.FieldConstants.EmployeeName & " asc) " & _
          " order by " & IMSConstants.FieldConstants.EmployeeName & " asc "

        'IsDeleted='0'
        'and EmployeeID IN
        '(
        'select TOP 5 EmployeeID from Employee
        'where IsDeleted='0' and EmployeeID
        'NOT IN(SELECT TOP 10 EmployeeID FROM Employee  where IsDeleted='0' order by EmployeeName asc) 
        ' order by EmployeeName asc
        ')
        ' order by EmployeeName asc

        tblFireStation.Columns.Add(IMSConstants.FieldConstants.EmployeeID, GetType(Integer))
        tblFireStation.Columns.Add(IMSConstants.GridHeader.EmployeeName, GetType(String))
        tblFireStation.Columns.Add(IMSConstants.GridHeader.Code, GetType(String))
        tblFireStation.Columns.Add(IMSConstants.GridHeader.PhoneNumber, GetType(String))
        tblFireStation.Columns.Add(IMSConstants.GridHeader.Email, GetType(String))

        lstEmployee = _proxy.GetFilteredEmployee(filter).Cast(Of IMSService.Employee).ToList()
        Dim lstEmployeeNew As List(Of IMSService.Employee) = _proxy.GetFilteredEmployee(filterNew).Cast(Of IMSService.Employee).ToList()

        '' For Each obj As IMSService.Employee In lstEmployee.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

        For Each obj As IMSService.Employee In lstEmployeeNew
            Dim row As DataRow = tblFireStation.NewRow

            row(IMSConstants.FieldConstants.EmployeeID) = obj.EmployeeID
            row(IMSConstants.GridHeader.EmployeeName) = obj.EmployeeName
            row(IMSConstants.GridHeader.Code) = obj.EmployeeCode
            row(IMSConstants.GridHeader.PhoneNumber) = obj.PhoneNumber
            row(IMSConstants.GridHeader.Email) = obj.EmailAddress

            tblFireStation.Rows.Add(row)
        Next

        With Me.grvEmployee
            .DataSource = tblFireStation
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Method to Delete Employee.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteEmployee()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvEmployee.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objEmployee As IMS.Win.IMSService.Employee = _proxy.GetEmployeeByID(id)
            If Not IsNothing(objEmployee) Then
                objEmployee.IsDeleted = CInt(IMSEnums.IsDeleted.Yes)
                deletedId = _proxy.UpdateEmployee(objEmployee)
            End If
            If deletedId > -1 Then
                Me.DisplayInformation(IMSConstants.Messages.DeleteSuccessfull)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Load Employee
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployee()
        Me.LoadData()
        Me.EnableDisableButton()
    End Sub

    ' ''' <summary>
    ' ''' Method to Set Security.
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub SetSecurity()

    '    For Each objControl As Control In Me.Controls
    '        Me.RecurseControls(objControl)
    '    Next

    'End Sub

    ' ''' <summary>
    ' ''' Method to recurcive function for enable disablecontrols.
    ' ''' </summary>
    ' ''' <param name="ctr"></param>
    ' ''' <remarks></remarks>
    'Private Sub RecurseControls(ByVal ctr As Control)

    '    If ctr.HasChildren Then
    '        For Each objControl As Control In ctr.Controls
    '            RecurseControls(objControl)
    '        Next objControl
    '    Else
    '        If ctr.Name.Contains("btn") Then
    '            Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = ctr.Name And x.FrontEndParentID = Me.Name).FirstOrDefault()
    '            ctr.Enabled = Not IsNothing(objSavePrivilig)
    '        End If
    '        btnClose.Enabled = True
    '    End If

    'End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstEmployee.Count
        Dim totalList As Integer = Math.Floor(count / listSize)

        If count Mod listSize > 0 Then
            totalList = totalList + 1
        End If

        If pageIndex > 0 Then
            btnPrevious.Enabled = True
        Else
            btnPrevious.Enabled = False
        End If

        If pageIndex < totalList - 1 Then
            btnNext.Enabled = True
        Else
            btnNext.Enabled = False
        End If

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmViewEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            Me.pageIndex = 0
            Me.LoadData()
            Me.EnableDisableButton()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim frm As frmAddEmployee = New frmAddEmployee()
            AddHandler frm.LoadEmployee, AddressOf LoadEmployee
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Try

            If grvEmployee.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvEmployee.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    Dim frm As frmAddEmployee = New frmAddEmployee(editId)
                    AddHandler frm.LoadEmployee, AddressOf LoadEmployee
                    frm.ShowDialog()
                End If

            Else
                DisplayWarning(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try


    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try
            If grvEmployee.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    DeleteEmployee()
                    Me.LoadData()
                    Me.EnableDisableButton()

                End If
            Else
                DisplayWarning(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            pageIndex = pageIndex - 1
            Me.LoadData()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            pageIndex = pageIndex + 1
            Me.LoadData()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

End Class