'Author                : Shah Mohammad Sharif
'Crated Date           : 06-May-2014
'Last Modified by      : Md.ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib
Imports IMS.Win.IMSService

Public Class frmViewUser
    Inherits BaseForm

#Region "Member Variables"

    Dim _proxy As New IMSService.IMSServices
    Private _userID As String
    Private pageIndex As Integer = 0
    Private listSize As Integer = 15
    Private lstUser As New List(Of IMSService.Users)

#End Region

#Region "Constructor"

    Public Sub New()

        InitializeComponent()

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmViewUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            Me.ClearFileds()
            Me.LoadUserStatus()
            Me.cmbUserStatus.Value = CInt(IMSEnums.UserStatus.Active)
            'Me.LoadUsers()
            Me.cmbUserStatus.Focus()
            Me.pageIndex = 0
            ' Me.LoadUsers()
            Me.EnableDisableButton()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub cmbUserStatus_ValueChanged(sender As Object, e As EventArgs) Handles cmbUserStatus.ValueChanged
        Try

            Me.pageIndex = 0
            Me.LoadUsers()
            Me.EnableDisableButton()

            Me.grvUsers.Enabled = True
            Me.btnEdit.Enabled = False
            Me.btnInactive.Enabled = False
            'Me.btnDelete.Enabled = False

            If Not String.IsNullOrEmpty(cmbUserStatus.Value) Then
                If cmbUserStatus.Value = CInt(IMSEnums.UserStatus.Active) Then
                    btnInactive.Text = "&Inactive"
                ElseIf cmbUserStatus.Value = CInt(IMSEnums.UserStatus.Inactive) Then
                    btnInactive.Text = "&Active"
                End If
            End If
            
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try
            Dim frm As frmAddUser = New frmAddUser()
            AddHandler frm.LoadUsers, AddressOf LoadUsers
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub grvUsers_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grvUsers.ClickCell
        Try
            If cmbUserStatus.Value = CInt(IMSEnums.UserStatus.Active) Then
                Me.btnEdit.Enabled = True
                'Me.btnDelete.Enabled = True
                Me.btnInactive.Enabled = True

            ElseIf cmbUserStatus.Value = CInt(IMSEnums.UserStatus.Inactive) Then
                Me.btnInactive.Text = "Active"
                Me.btnEdit.Enabled = True
                'Me.btnDelete.Enabled = True
                Me.btnInactive.Enabled = True

                'ElseIf cmbUserStatus.Value = CInt(IMSEnums.Status.Deleted) Then
                '    Me.btnEdit.Enabled = False
                '    'Me.btnDelete.Enabled = False
                '    Me.btnInactive.Enabled = False

            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try

            If Me.grvUsers.Selected.Rows.Count > 0 Then
                Dim editedUserId = Me.grvUsers.Selected.Rows(0).Cells(0).Value.ToString()

                If Not String.IsNullOrEmpty(editedUserId) Then
                    Dim frm As frmAddUser = New frmAddUser(editedUserId)
                    AddHandler frm.LoadUsers, AddressOf LoadUsers
                    frm.ShowDialog()
                End If
            Else
                Me.DisplayWarning(IMSConstants.ErrorMessage.PleaseSelectUserRecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnInactive_Click(sender As Object, e As EventArgs) Handles btnInactive.Click
        Try
            Dim editedUserId As String = String.Empty
            Dim user As New Users
            Dim message As String = String.Empty

            If Me.grvUsers.Selected.Rows.Count > 0 Then
                editedUserId = Me.grvUsers.Selected.Rows(0).Cells(0).Value.ToString()

                If Not String.IsNullOrEmpty(editedUserId) Then

                    If cmbUserStatus.Value = CInt(IMSEnums.Status.Inactive) Then
                        message = "Are you sure want to activate user?"
                    ElseIf cmbUserStatus.Value = CInt(IMSEnums.Status.Active) Then
                        message = "Are you sure want to Inactivate user?"
                    End If

                    If MsgBox(message, MsgBoxStyle.OkCancel, "Closing") = MsgBoxResult.Ok Then

                        user = _proxy.GetUsersByID(editedUserId)

                        If Not IsNothing(user) Then

                            If cmbUserStatus.Value = CInt(IMSEnums.Status.Inactive) Then
                                user.Status = CInt(IMSEnums.Status.Active)
                            ElseIf cmbUserStatus.Value = CInt(IMSEnums.Status.Active) Then
                                user.Status = CInt(IMSEnums.Status.Inactive)
                            End If

                            If _proxy.UpdateUsers(user) > 0 Then

                                If cmbUserStatus.Value = CInt(IMSEnums.Status.Inactive) Then
                                    DisplayInformation("User activated successfully.")
                                ElseIf cmbUserStatus.Value = CInt(IMSEnums.Status.Active) Then
                                    DisplayInformation("User inactivated successfully.")
                                End If

                                Me.LoadUsers()
                                Me.EnableDisableButton()

                            Else

                                If cmbUserStatus.Value = CInt(IMSEnums.Status.Inactive) Then
                                    DisplayInformation("User activation failed.")
                                ElseIf cmbUserStatus.Value = CInt(IMSEnums.Status.Active) Then
                                    DisplayInformation("User inactivation failed.")
                                End If

                            End If
                        End If

                    End If
                End If
            Else
                Me.DisplayWarning(IMSConstants.ErrorMessage.PleaseSelectUserRecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            pageIndex = pageIndex - 1
            Me.LoadUsers()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            pageIndex = pageIndex + 1
            Me.LoadUsers()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load users info.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUsers()

        Dim tblUsers As New DataTable

        tblUsers.Columns.Add(IMSConstants.GridHeader.UserID)
        tblUsers.Columns.Add(IMSConstants.FieldConstants.Name)
        tblUsers.Columns.Add(IMSConstants.FieldConstants.Surname)
        tblUsers.Columns.Add(IMSConstants.FieldConstants.Status)

        Try
            Dim query As String = GetQuery()

            If Not String.IsNullOrEmpty(query) Then

                lstUser = _proxy.GetFilteredUsers(query).Cast(Of Users).ToList()

                For Each obj As Users In lstUser.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.
                    Dim row As DataRow = tblUsers.NewRow

                    row(IMSConstants.GridHeader.UserID) = obj.UserID
                    row(IMSConstants.FieldConstants.Name) = obj.Name
                    row(IMSConstants.FieldConstants.Surname) = obj.Surname
                    row(IMSConstants.FieldConstants.Status) = [Enum].GetName(GetType(IMSEnums.Status), obj.Status)

                    tblUsers.Rows.Add(row)

                Next

                With Me.grvUsers
                    .DataSource = tblUsers
                    .DisplayLayout.Override.ActiveCellAppearance.Reset()
                    .DisplayLayout.Override.ActiveRowAppearance.Reset()
                End With

            Else
                grvUsers.DataSource = Nothing
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Method to load user status.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUserStatus()

        Dim arrUserStatusValue As Array = [Enum].GetValues(GetType(IMSEnums.UserStatus))
        Dim arrUserStatusName As Array = [Enum].GetNames(GetType(IMSEnums.UserStatus))

        Dim table As New DataTable
        table.Columns.Add(IMSConstants.FieldConstants.ID)
        table.Columns.Add(IMSConstants.FieldConstants.Status)

        Dim userStatusList As List(Of Object) = New List(Of Object)()

        Dim i As Integer = 0

        While arrUserStatusName.Length > i

            Dim dr As DataRow = table.NewRow
            dr(IMSConstants.FieldConstants.ID) = Convert.ToInt32(arrUserStatusValue.GetValue(i))
            dr(IMSConstants.FieldConstants.Status) = arrUserStatusName.GetValue(i).ToString()
            table.Rows.Add(dr)
            i += 1
        End While

        Dim row As DataRow = table.NewRow
        row(IMSConstants.FieldConstants.ID) = String.Empty
        row(IMSConstants.FieldConstants.Status) = String.Empty
        table.Rows.InsertAt(row, 0)

        With cmbUserStatus
            .ValueMember = IMSConstants.FieldConstants.ID
            .DisplayMember = IMSConstants.FieldConstants.Status
            .DataSource = table
        End With

    End Sub

    ''' <summary>
    ''' Method to clear fields.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFileds()
        Me.grvUsers.Enabled = False
        Me.btnEdit.Enabled = False
        Me.btnInactive.Enabled = False
        'Me.btnDelete.Enabled = False
        Me.LoadUserStatus()
    End Sub

    ''' <summary>
    ''' Method to create query string.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetQuery() As String

        Dim query As String = String.Empty

        If Me.cmbUserStatus.Value = "-1" Or cmbUserStatus.Text = String.Empty Then
            query = String.Empty
        Else
            query = String.Format("{0}={1} order by {2} asc", IMSConstants.FieldConstants.Status, cmbUserStatus.Value, IMSConstants.FieldConstants.UserID)
        End If

        Return query

    End Function

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstUser.Count
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

    'Private Sub btnDelete_Click(sender As Object, e As EventArgs)
    '    Try
    '        Dim editedUserId As String = String.Empty
    '        Dim user As New Users

    '        If Me.grvUsers.Selected.Rows.Count > 0 Then
    '            editedUserId = Me.grvUsers.Selected.Rows(0).Cells(0).Value.ToString()

    '            If Not String.IsNullOrEmpty(editedUserId) Then
    '                If MsgBox(" Do you want to delete user permanently?", MsgBoxStyle.OkCancel, "Closing") = MsgBoxResult.Ok Then

    '                    user = _proxy.GetUsersByID(editedUserId)

    '                    If Not IsNothing(user) Then
    '                        user.Status = CInt(IMSEnums.Status.Deleted)
    '                        If _proxy.UpdateUsers(user) > 0 Then

    '                            DisplayInformation("User deleted successfully.")
    '                            LoadUsers()

    '                        Else
    '                            DisplayError("Sorry! User deletion failed.")
    '                        End If
    '                    End If

    '                End If
    '            End If
    '        Else
    '            Me.DisplayInformation(IMSConstants.ErrorMessage.PleaseSelectUserRecord)
    '        End If

    '    Catch ex As Exception
    '        Me.WriteLog(ex)
    '        Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
    '    End Try

    'End Sub

End Class