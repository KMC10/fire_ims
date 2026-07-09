'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 06-May-2014
'Last Modified by      : Md.ilias 
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization
Imports System.Configuration

Public Class frmAddEmployee
    Inherits BaseForm


#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mEmployee As New IMSService.Employee
    Private _proxy As New IMSService.IMSServices
    Private _employeeCode As Integer = 0

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal EmployeeID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mEmployee = _proxy.GetEmployeeByID(EmployeeID)
        Me.Text = "Update Employee"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load employee type.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployeeType()

        Dim tblEmployeeType As New DataTable

        tblEmployeeType.Columns.Add(IMSConstants.FieldConstants.EmpTypeID)
        tblEmployeeType.Columns.Add(IMSConstants.FieldConstants.EmpTypeDescription)

        For Each obj As IMSService.EmployeeType In _proxy.GetAllEmployeeType()
            Dim rows As DataRow = tblEmployeeType.NewRow
            rows(IMSConstants.FieldConstants.EmpTypeID) = obj.EmpTypeID
            rows(IMSConstants.FieldConstants.EmpTypeDescription) = obj.EmpTypeDescription
            tblEmployeeType.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblEmployeeType)
        dView.Sort = "EmpTypeDescription ASC"

        Dim sortedTable As DataTable = dView.ToTable()
        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.EmpTypeID) = String.Empty
        row(IMSConstants.FieldConstants.EmpTypeDescription) = String.Empty

        sortedTable.Rows.InsertAt(row, 0)
        With Me.cmbEmployeeType
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.EmpTypeID
            .DisplayMember = IMSConstants.FieldConstants.EmpTypeDescription
            .DataBind()
            ' .Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to load fire station.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStation()

        Dim dtFireStation As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & "StationName ASC"

        With dtFireStation.Columns
            .Add(IMSConstants.FieldConstants.StationID)
            .Add(IMSConstants.FieldConstants.StationName)
        End With

        For Each obj As IMSService.FireStation In _proxy.GetFilteredFireStation(strSQL)
            Dim row As DataRow = dtFireStation.NewRow
            row(IMSConstants.FieldConstants.StationID) = obj.StationID
            row(IMSConstants.FieldConstants.StationName) = obj.StationName

            dtFireStation.Rows.Add(row)
        Next

        Dim rows As DataRow = dtFireStation.NewRow
        rows(IMSConstants.FieldConstants.StationID) = String.Empty
        rows(IMSConstants.FieldConstants.StationName) = String.Empty
        dtFireStation.Rows.InsertAt(rows, 0)


        With Me.cmbStation
            .DataSource = dtFireStation
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Employee Group
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployeeGroup()

        'Dim dtFireStation As New DataTable
        Dim strSQL As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & IMSConstants.FieldConstants.GroupName & " ASC"
        Dim lstGroup As List(Of IMSService.Group) = _proxy.GetFilteredGroup(strSQL).Cast(Of IMSService.Group).ToList()

        Dim objGroup As New IMSService.Group
        objGroup.GroupID = 0
        objGroup.GroupName = " "
        lstGroup.Insert(0, objGroup)

        If lstGroup.Count > 0 Then

            With Me.cmbEmployeeGroup
                .DataSource = lstGroup
                .ValueMember = IMSConstants.FieldConstants.GroupID
                .DisplayMember = IMSConstants.FieldConstants.GroupName
                .DataBind()
            End With

        End If

    End Sub

    ''' <summary>
    ''' Method to set data in object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.Employee
        Dim objEmployee As New IMS.Win.IMSService.Employee
        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With objEmployee

            .EmployeeName = txtName.Text.Trim()
            .EmployeeCode = txtCode.Text.Trim()
            .PhoneNumber = txtPhone.Text.Trim()
            .EmailAddress = txtEmail.Text.Trim()
            .CanDrive = chkCanDrive.Checked
            .EmpTypeID = cmbEmployeeType.Value
            .StationID = cmbStation.Value
            .GroupID = cmbEmployeeGroup.Value
            .PostalAddress = txtAddress.Text.Trim()
            .IsDeleted = CInt(IMSEnums.IsDeleted.No)
            .InsertionDate = currentDate
            .ModificationDate = currentDate

        End With
        Return objEmployee

    End Function

    ''' <summary>
    ''' Method to set data by an employee.
    ''' </summary>
    ''' <param name="objEmployee"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objEmployee As IMS.Win.IMSService.Employee)

        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        With mEmployee
            .EmployeeName = txtName.Text
            .EmployeeCode = txtCode.Text
            .PhoneNumber = txtPhone.Text
            .EmailAddress = txtEmail.Text
            .CanDrive = chkCanDrive.Checked
            .EmpTypeID = cmbEmployeeType.Value
            .StationID = cmbStation.Value
            .GroupID = cmbEmployeeGroup.Value
            .PostalAddress = txtAddress.Text
            .ModificationDate = currentDate
        End With

    End Sub

    ''' <summary>
    ''' Method to check validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If txtName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeName)
            txtName.Focus()
            Return False
        End If

        If txtCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeCode)
            txtCode.Focus()
            Return False
        End If

        Dim employeeCodeLength As String

        employeeCodeLength = ConfigurationSettings.AppSettings("employeeCodeLength")

        If Not IsNothing(employeeCodeLength) Then

            If Me.txtCode.Text.Length <> employeeCodeLength Then
                DisplayWarning(IMSConstants.ErrorMessage.TypeCodeLength)
                txtCode.Focus()
                Return False

            End If

            Try
                Dim employeecode = Convert.ToInt32(Me.txtCode.Text.Trim())
            Catch ex As Exception
                DisplayWarning(IMSConstants.ErrorMessage.EnterValidEmployeeCode)
                txtCode.Focus()
                Return False
            End Try

        Else

            DisplayWarning(IMSConstants.ErrorMessage.EmployeeCodeLengthSettingsMissing)
            txtCode.Focus()
            Return False

        End If



        If txtPhone.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypePhoneNo)
            txtPhone.Focus()
            Return False
        End If

        If txtEmail.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeEmail)
            txtEmail.Focus()
            Return False
        End If

        If txtEmail.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeEmail)
            txtEmail.Focus()
            Return False
        End If

        If Not CommonFunction.IsValidEmailFormat(Me.txtEmail.Text.Trim) Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.EnterValidEmailAddress)
            Me.txtEmail.Focus()
            Return False
        End If

        If cmbEmployeeType.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectEmployeeType)
            cmbEmployeeType.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(cmbStation.Text) Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectStation)
            cmbStation.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(cmbEmployeeGroup.Text.Trim()) Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectEmployeeGroup)
            cmbEmployeeGroup.Focus()
            Return False
        End If

        If txtAddress.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeAddress)
            txtAddress.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mEmployee.EmployeeCode.Trim() = (txtCode.Text.Trim()) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtCode.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateEmployeeCode)
            Me.txtCode.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to check duplicate.
    ''' </summary>
    ''' <param name="employeeCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal employeeCode As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.EmployeeCode, employeeCode, IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No))
        Dim lstEmployee As List(Of IMS.Win.IMSService.Employee) = _proxy.GetFilteredEmployee(filter).Cast(Of IMS.Win.IMSService.Employee).ToList()

        If lstEmployee.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to view form data.
    ''' </summary>
    ''' <param name="objEmployee"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objEmployee As IMS.Win.IMSService.Employee)

        With objEmployee

            txtName.Text = .EmployeeName
            txtCode.Text = .EmployeeCode.Trim()
            txtPhone.Text = .PhoneNumber
            txtEmail.Text = .EmailAddress
            chkCanDrive.Checked = .CanDrive
            cmbEmployeeType.Value = .EmpTypeID
            cmbStation.Value = .StationID
            cmbEmployeeGroup.Value = .GroupID
            txtAddress.Text = .PostalAddress

            If .EmployeeID = 0 Then
                cmbEmployeeType.Text = String.Empty
            End If

            If .StationID = 0 Then
                cmbStation.Text = String.Empty
            End If

            If .GroupID = 0 Then
                cmbEmployeeGroup.Text = String.Empty
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to update employee.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateEmployee() As Integer

        Dim id As Integer = 0
        Me.SetData(mEmployee)
        Dim objEmployee As IMS.Win.IMSService.Employee = mEmployee

        id = _proxy.UpdateEmployee(objEmployee)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save Employee.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveEmployee() As Integer

        Dim id As Integer = -1
        Dim objEmployee As IMS.Win.IMSService.Employee = SetData()

        id = _proxy.InsertEmployee(objEmployee)

        Return id

    End Function

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


#End Region

#Region "Event"

    Public Event LoadEmployee()

#End Region

#Region "Event Handlers"

    Private Sub frmAddEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            'Me.RecurseControls(Me.Name)
            Me.LoadEmployeeType()
            Me.LoadStation()
            Me.LoadEmployeeGroup()
            Me.ViewFormData(mEmployee)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim intActionResult As Integer = 0

            If Me.IsValidate = False Then Exit Sub

            If Me.IsUpdate = True Then
                intActionResult = Me.UpdateEmployee()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadEmployee()
                    Me.Close()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)

                End If


            Else
                intActionResult = Me.SaveEmployee()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadEmployee()
                    ResetContrllData()

                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)

                End If
            End If

            'If intActionResult > 0 Then
            '    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
            '    RaiseEvent LoadEmployee()
            '    'Me.Close()

            'End If
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtCode_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCode.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If

        'If ("1234567890".IndexOf(e.KeyChar) > -1 Or e.KeyChar = Convert.ToChar(8)) Then
        '    e.Handled = False
        'Else

        '    e.Handled = True
        'End If


    End Sub


#End Region

    Private Sub ResetContrllData()
        Me.txtName.Text = String.Empty
        Me.txtCode.Text = String.Empty
        Me.txtPhone.Text = String.Empty
        Me.txtEmail.Text = String.Empty
        Me.cmbEmployeeType.Text = String.Empty
        Me.cmbStation.Text = String.Empty
        Me.cmbEmployeeGroup.Text = String.Empty
        Me.txtAddress.Text = String.Empty

    End Sub



End Class






