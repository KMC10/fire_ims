'Author                : Shah Mohammad Sharif
'Crated Date           : 07-May-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports IMS.Win.IMSService

Public Class frmAddUser

#Region "Member Variables"

    Dim _proxy As New IMSService.IMSServices
    Private mUsers As Users
    Dim IsUpdate As Boolean = False

#End Region

#Region "User Defined Event"

    Public Event LoadUsers()

#End Region

#Region "Constructor"

    Public Sub New()

        InitializeComponent()

    End Sub

    Public Sub New(ByVal userID As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mUsers = _proxy.GetUsersByID(userID)
        Me.Text = "Update User"
        btnSave.Text = "Update"
        lblPassword.ForeColor = Color.Black
        lblRetypePassword.ForeColor = Color.Black

    End Sub

#End Region

#Region "Private Methods"
    ''' <summary>
    ''' Method to insert user's info in the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function InsertUser() As Integer

        Dim encryption As New EncryptionHelpers
        Dim objUser As New Users
        Dim password As String = encryption.Encrypt(Me.txtPassword.Text)

        With objUser
            .UserID = Me.txtUserID.Text.Trim()
            .AccessRight = Me.cmbAccessRight.Value
            .CellPhone = Me.txtCellPhone.Text.Trim()
            .Telehphone = Me.txtTelehphone.Text.Trim()
            .Email = Me.txtEmail.Text.Trim()
            .MACAddress = String.Empty
            .Name = txtName.Text.Trim()
            .Network = String.Empty
            .Password = password
            .RegistryDate = Now
            .Status = 1
            .Surname = Me.txtSurname.Text.Trim()

        End With

        Return _proxy.InsertUsers(objUser)

    End Function

    ''' <summary>
    ''' Method to update user's info in the database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateUser() As Integer

        Dim encryption As New EncryptionHelpers

        If Not String.IsNullOrEmpty(Me.txtUserID.Text) Then
            Dim objUser As Users = _proxy.GetUsersByID(Me.txtUserID.Text)

            If Not IsNothing(objUser) Then
                With objUser
                    .UserID = Me.txtUserID.Text
                    .AccessRight = Me.cmbAccessRight.Value
                    .CellPhone = Me.txtCellPhone.Text
                    .Telehphone = Me.txtTelehphone.Text
                    .Email = Me.txtEmail.Text
                    .MACAddress = String.Empty
                    .Name = Me.txtName.Text
                    .Network = String.Empty

                    If Not String.IsNullOrEmpty(txtPassword.Text) Then
                        .Password = encryption.Encrypt(txtPassword.Text)
                    End If

                    .RegistryDate = Now
                    '.Status = 1
                    .Surname = Me.txtSurname.Text

                End With

                Return _proxy.UpdateUsers(objUser)
            Else
                DisplayWarning(IMSConstants.ExceptionMessage.NoUserFoundWithThisUserID)
                Return 0
            End If

        End If

        'If Not String.IsNullOrEmpty(txtPassword.Text) Then
        '    Dim password As String = encryption.Encrypt(txtPassword.Text)
        'End If

        Return 0

    End Function

    ''' <summary>
    ''' Method to load access right combo.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadAccessRight()

        Try
            Dim lstUserRight As New List(Of IMSService.UserRight)()

            Dim table As New DataTable
            table.Columns.Add(IMSConstants.FieldConstants.AccessRight)
            table.Columns.Add(IMSConstants.FieldConstants.Description)

            For Each objUserRight As IMSService.UserRight In _proxy.GetFilteredUserRight("")

                '' Logic: Do not give option of creating "SA" user.
                If objUserRight.AccessRight <> CInt(IMSEnums.UserRight.SuperAdmin) Then

                    Dim dr As DataRow = table.NewRow
                    dr(IMSConstants.FieldConstants.AccessRight) = objUserRight.AccessRight
                    dr(IMSConstants.FieldConstants.Description) = objUserRight.RightDescription

                    table.Rows.Add(dr)

                End If
            Next

            Dim row As DataRow = table.NewRow
            row(IMSConstants.FieldConstants.AccessRight) = String.Empty
            row(IMSConstants.FieldConstants.Description) = String.Empty
            table.Rows.InsertAt(row, 0)


            With Me.cmbAccessRight

                .DisplayMember = IMSConstants.FieldConstants.Description
                .ValueMember = IMSConstants.FieldConstants.AccessRight
                .DataSource = table

                .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.AccessRight).Hidden = True
                .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.Description).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
                .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

                .Value = -1
            End With

        Catch ex As Exception
            WriteLog(ex)
        End Try
    End Sub

    ''' <summary>
    ''' Method to load Fire Station. 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStation()

        Dim dtStation As DataTable = CommonFunction.GetTableForStationDropDown()

        With Me.cmbStationName
            .DataSource = dtStation
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
            .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.StationID).Hidden = True

            .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.StationName).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

        End With

    End Sub

    ''' <summary>
    ''' Method to view single record.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ViewSingleRecord(ByVal objUsers As Users)

        Dim sql As String = String.Empty
        Dim lstEmployeeUser As New List(Of EmployeeUser)
        Dim employee As New Employee

        With objUsers
            Me.txtCellPhone.Text = .CellPhone
            Me.txtEmail.Text = .Email
            Me.txtName.Text = .Name
            Me.txtSurname.Text = .Surname
            Me.txtTelehphone.Text = .Telehphone
            Me.txtUserID.Text = .UserID
            Me.cmbAccessRight.Value = .AccessRight
            Me.txtUserID.Enabled = False
            IsUpdate = True
        End With

        employee = CommonFunction.GetEmployeeByUserID(objUsers.UserID)
        If Not IsNothing(employee) Then
            cmbStationName.Value = employee.StationID
            cmbEmployee.Value = employee.EmployeeID
        End If

    End Sub

    ''' <summary>
    ''' Method to check field validation.
    ''' </summary>
    ''' <param name="IsUpdating"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate(ByVal IsUpdating As Boolean) As Boolean

        Dim chkDuplicate As Boolean = True

        If String.IsNullOrEmpty(Me.txtName.Text.Trim) Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.TypeName)
            Me.txtName.Focus()
            Return False
        End If

        'If String.IsNullOrEmpty(Me.txtSurname.Text.Trim) Then
        '    Me.DisplayWarning(IMSConstants.ErrorMessage.EnterSurname)
        '    Me.txtSurname.Focus()
        '    Return False
        'End If

        If String.IsNullOrEmpty(Me.txtCellPhone.Text.Trim) Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.EnterCellPhone)
            Me.txtCellPhone.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtEmail.Text.Trim) Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.EnterEmail)
            Me.txtEmail.Focus()
            Return False
        End If

        If Not CommonFunction.IsValidEmailFormat(Me.txtEmail.Text.Trim) Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.EnterValidEmailAddress)
            Me.txtEmail.Focus()
            Return False
        End If
        'If String.IsNullOrEmpty(Me.txtTelehphone.Text.Trim) Then
        '    Me.DisplayWarning(IMSConstants.ErrorMessage.EnterTelephone)
        '    Me.txtTelehphone.Focus()
        '    Return False
        'End If


        If cmbStationName.Value = Nothing Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.SelectEmployeeStation)
            Me.cmbStationName.Focus()
            Return False
        End If


        If cmbEmployee.Value = Nothing Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.TypeEmoloyee)
            Me.cmbAccessRight.Focus()
            Return False
        End If

        If cmbAccessRight.Value = Nothing Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.SelectAccessRight)
            Me.cmbAccessRight.Focus()
            Return False
        End If

        If String.IsNullOrEmpty(Me.txtUserID.Text.Trim) Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.TypeUserID)
            Me.txtUserID.Focus()
            Return False
        End If

        'If in update mode then password not mandatory
        If Me.IsUpdate Then

            If Not String.IsNullOrEmpty(Me.txtPassword.Text.Trim) Then

                If String.IsNullOrEmpty(Me.txtReTypePassword.Text.Trim) Then
                    Me.DisplayWarning(IMSConstants.ErrorMessage.TypeReTypePassword)
                    Me.txtReTypePassword.Focus()
                    Return False
                End If

            End If
        Else
            If String.IsNullOrEmpty(Me.txtPassword.Text.Trim) Then
                Me.DisplayWarning(IMSConstants.ErrorMessage.TypePassword)
                Me.txtPassword.Focus()
                Return False
            End If

            If String.IsNullOrEmpty(Me.txtReTypePassword.Text.Trim) Then
                Me.DisplayWarning(IMSConstants.ErrorMessage.TypeReTypePassword)
                Me.txtReTypePassword.Focus()
                Return False
            End If
        End If

        If Not isPasswordMatch() Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.MismatchPassword)
            Me.txtPassword.Focus()
            Return False
        End If

        If Me.IsUpdate = True Then
            If mUsers.UserID = (txtUserID.Text.Trim()) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtUserID.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateUserID)
            Me.txtUserID.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to check duplicate UserID
    ''' </summary>
    ''' <param name="users"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal users As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.UserID, users)
        Dim lstusers As List(Of Users) = _proxy.GetFilteredUsers(filter).Cast(Of Users).ToList

        If lstusers.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to check match password
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isPasswordMatch() As Boolean

        Dim result As Boolean = False

        If IsUpdate Then

            If Not String.IsNullOrEmpty(txtPassword.Text) Then
                If txtPassword.Text = txtReTypePassword.Text Then
                    result = True
                Else
                    result = False
                End If
            Else
                result = True
            End If

        Else

            If txtPassword.Text = txtReTypePassword.Text Then
                result = True
            Else
                result = False
            End If

        End If

        Return result

    End Function

    ''' <summary>
    ''' Method to reset controls.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetControls()

        Me.txtCellPhone.Text = String.Empty
        Me.txtEmail.Text = String.Empty
        Me.txtName.Text = String.Empty
        Me.txtPassword.Text = String.Empty
        Me.txtReTypePassword.Text = String.Empty
        Me.txtSurname.Text = String.Empty
        Me.txtTelehphone.Text = String.Empty
        Me.txtUserID.Text = String.Empty
        Me.cmbAccessRight.Text = String.Empty
        Me.cmbEmployee.Text = String.Empty
        Me.cmbStationName.Text = String.Empty
        Me.btnSave.Enabled = True
        Me.txtUserID.Enabled = True

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
    ''' Methode to load employee
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadEmployee(ByVal stationID As Integer)

        Dim tblEmployee As DataTable = CommonFunction.GetEmployeeTableForComboByStationID(stationID)

        With Me.cmbEmployee
            .DataSource = tblEmployee
            .ValueMember = IMSConstants.FieldConstants.EmployeeID
            .DisplayMember = IMSConstants.FieldConstants.EmployeeName
            .DataBind()
            .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.EmployeeID).Hidden = True
            .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.EmployeeName).SortIndicator = Infragistics.Win.UltraWinGrid.SortIndicator.Ascending
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns

            '.Value = -1
        End With

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmAddUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            Me.LoadAccessRight()
            Me.ResetControls()
            Me.LoadStation()
            Me.txtName.Focus()
            If Not IsNothing(mUsers) Then
                Me.ViewSingleRecord(mUsers)
                Me.btnSave.Enabled = True
                Me.txtUserID.Enabled = False
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If Me.IsValidate(True) Then
            If IsUpdate Then
                Dim editedUserID = Me.UpdateUser()
                If editedUserID > 0 Then

                    'Update Of EmployeeUser Table.
                    Dim sql As String = IMSConstants.FieldConstants.UserID & " = '" & txtUserID.Text.Trim() & "' "
                    Dim lstEmployeeUser As List(Of EmployeeUser) = _proxy.GetFilteredEmployeeUser(sql).Cast(Of EmployeeUser).ToList()

                    If lstEmployeeUser.Count > 0 Then
                        'If Value changed then update "EmployeeUser"
                        If lstEmployeeUser(0).EmployeeID <> cmbEmployee.Value Then
                            lstEmployeeUser(0).EmployeeID = cmbEmployee.Value
                            _proxy.UpdateEmployeeUser(lstEmployeeUser(0))
                        End If
                    End If

                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.UpdateSuccessfull)
                    Me.ResetControls()
                    Me.IsUpdate = False
                    Me.mUsers = New IMSService.Users
                    RaiseEvent LoadUsers()
                    Me.Close()
                End If
            Else
                Dim insertedID = Me.InsertUser()

                If insertedID > -1 Then

                    'Insert into EmployeeUser Table.
                    Dim objEmployeeUser As New EmployeeUser

                    With objEmployeeUser
                        .EmployeeID = cmbEmployee.Value
                        .UserID = Me.txtUserID.Text
                    End With

                    _proxy.InsertEmployeeUser(objEmployeeUser)

                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    Me.ResetControls()
                    RaiseEvent LoadUsers()
                    'Me.Close()

                End If
            End If
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbStationName_RowSelected(sender As Object, e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles cmbStationName.RowSelected

        Try
            Dim stationId As Integer = 0
            If Not String.IsNullOrEmpty(cmbStationName.Text) Then
                stationId = Convert.ToInt32(cmbStationName.Value)
            End If

            Me.LoadEmployee(stationId)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

End Class