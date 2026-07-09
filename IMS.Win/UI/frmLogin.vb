'Author                : Shah Mohammad Sharif
'Crated Date           : 07-May-2014
'Last Modified by      : Md ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Win.IMSService
Imports IMS.Lib

Public Class frmLogin

#Region "Member Variables"

    Dim _proxy As New IMSService.IMSServices
    Public LoginInfo As String = String.Empty
    Public LoggedInUser As Users = Nothing

    Public SessionID As Integer = 0
    Public LoggedInTime As Date

#End Region

#Region "Private Methods"

    Private Sub FocusOnNextControl(ByVal txtFirst As TextBox, ByVal txtSecond As TextBox, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If String.Empty <> txtFirst.Text And e.KeyChar = ChrW(Keys.Enter) Then
            txtSecond.Focus()
        Else
            txtFirst.Focus()
        End If
    End Sub

    Private Sub FocusOnNextControl(ByVal txtControl As TextBox, ByVal btnControl As Button, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If String.Empty <> txtControl.Text And e.KeyChar = ChrW(Keys.Enter) Then
            btnControl.Focus()
        Else
            txtControl.Focus()
        End If
    End Sub

    ''' <summary>
    ''' Method to save login information
    ''' </summary>
    ''' <param name="user"></param>
    ''' <remarks></remarks>
    Private Sub SaveLoginInformation(ByRef user As Users)
        Try
            Dim objNetworkUtil As New NetworkUtil()
            Dim info As NetworkInfo = objNetworkUtil.GetNetworkInfo()
            Dim loginInformation As New IMSService.LoginInfo
            Dim objLoginSecurity As New LoginSecurity

            With loginInformation
                '.SessionKey = objLoginSecurity.GetSessionKey()
                .SessionKey = 1
                .UserID = user.UserID
                .LoginDateTime = DateTime.Now
                .LogoutDate = DateTime.Now
                .IPAddress = info.IPAddress
                .MACAddress = info.MACAddress
                .HostName = info.HostName
                .InterfaceName = info.InterfaceName
                .Protocol = info.Protocol
                .PublicIP = info.GatewayAddress
                .InterfaceDescription = info.InterfaceDescription
                .Status = IMSEnums.Status.Active

            End With

            '  LoginSecurity.FormName = "frmLogin"

            SessionID = _proxy.InsertLoginInfo(loginInformation)
            LoginSecurity.SessionID = SessionID
            LoginSecurity.UserRight = user.AccessRight

        Catch ex As Exception
            Me.WriteLog(ex)
        End Try

    End Sub

    ''' <summary>
    ''' Methode to check validation
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        If Me.txtUserId.Text.Trim = String.Empty Then
            DisplayWarningPopup(IMSConstants.ErrorMessage.EnterUserID)
            Me.txtUserId.Focus()
            Return False
        End If

        If txtPassword.Text.Trim = String.Empty Then
            DisplayWarningPopup(IMSConstants.ErrorMessage.EnterPassword)
            txtPassword.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to get user by ID and password
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <param name="password"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetUser(ByVal userId As String, ByVal password As String) As Users
        Dim users As Users = Nothing
        Dim filter As String = String.Format("{0}='{1}' and {2}='{3}'", IMSConstants.FieldConstants.UserID, userId, IMSConstants.FieldConstants.Password, password)

        Dim lstusers As List(Of Users) = _proxy.GetFilteredUsers(filter).Cast(Of Users).ToList()

        If (lstusers.Count > 0) Then
            users = lstusers(0)
        End If

        Return users

    End Function

    ''' <summary>
    ''' Method to getRolePrs by user ID.
    ''' </summary>
    ''' <param name="userId"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Private Function GetRolePriviligeByUserID(ByVal userId As String) As List(Of Privileges)

    '    Dim lstPrivileges As New List(Of Privileges)
    '    Dim lstRolePrivileges As New List(Of RolePrivileges)
    '    Dim strSQL = IMSConstants.FieldConstants.UserID & "='" & userId & "'"
    '    Dim lstRoleUsers As List(Of RoleUsers) = _proxy.GetFilteredRoleUsers(strSQL).Cast(Of RoleUsers).ToList()

    '    If lstRoleUsers.Count > 0 Then
    '        For Each obj As RoleUsers In lstRoleUsers
    '            Dim sql As String = IMSConstants.FieldConstants.RoleID & "=" & obj.RoleID
    '            Dim lstRolePrivilege As List(Of RolePrivileges) = _proxy.GetFilteredRolePrivileges(sql).Cast(Of RolePrivileges).ToList()

    '            For Each objRolePrivileges As RolePrivileges In lstRolePrivilege

    '                Dim objPrivileges As Privileges = _proxy.GetPrivilegesByID(objRolePrivileges.PrivilegeID)
    '                If Not IsNothing(objPrivileges) Then
    '                    lstPrivileges.Add(objPrivileges)
    '                End If

    '            Next

    '            lstRolePrivileges.AddRange(lstRolePrivilege)
    '        Next

    '    End If

    '    Return lstPrivileges

    'End Function

    Private Function GetRolePriviligeByUserID(ByVal userId As String) As List(Of Privileges)

        Dim lstPrivileges As New List(Of Privileges)
        Dim lstRolePrivileges As New List(Of RolePrivileges)
        Dim strSQL = IMSConstants.FieldConstants.UserID & "='" & userId & "'"
        Dim lstRoleUsers As List(Of RoleUsers) = _proxy.GetFilteredRoleUsers(strSQL).Cast(Of RoleUsers).ToList()

        If lstRoleUsers.Count > 0 Then
            For Each obj As RoleUsers In lstRoleUsers

                '' old code.
                'Dim sql As String = IMSConstants.FieldConstants.RoleID & "=" & obj.RoleID
                'Dim lstRolePrivilege As List(Of RolePrivileges) = _proxy.GetFilteredRolePrivileges(sql).Cast(Of RolePrivileges).ToList()

                'For Each objRolePrivileges As RolePrivileges In lstRolePrivilege

                '    Dim objPrivileges As Privileges = _proxy.GetPrivilegesByID(objRolePrivileges.PrivilegeID)
                '    If Not IsNothing(objPrivileges) Then
                '        lstPrivileges.Add(objPrivileges)
                '    End If

                'Next

                '' new code (by Jafar Ulla)

                Dim sql As String = " select * from Privileges" _
                                      & " where PrivilegeID IN ( " _
                                       & " Select PrivilegeID from RolePrivileges " _
                                       & " where RoleID IN " _
                                       & "( " _
                                         & " select RoleID from RoleUsers " _
                                         & " where UserID = '" & userId & "' " _
                                         & " ) " _
                                         & " ) "

                ''lstPrivileges = _proxy.GetExecuteQueryPrivileges(sql).Cast(Of Privileges).ToList()
            Next
        End If

        Return lstPrivileges

    End Function

    ''' <summary>
    ''' Method to Login event.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Login()
        Dim employee As New Employee
        Dim lstPrivilige As New List(Of Privileges)
        Dim userRight As New UserRight
        LoginSecurity.userID = Me.txtUserId.Text
        LoginSecurity.password = Me.txtPassword.Text

        Try
            Dim objUser As IMSService.Users = Nothing
            Dim objEncryptionHelpers As New EncryptionHelpers
            'form validation check
            If IsValidate() Then

                'Encript Password
                Dim password As String = objEncryptionHelpers.Encrypt(Me.txtPassword.Text)

                objUser = GetUser(Me.txtUserId.Text.Trim(), password)
                If objUser IsNot Nothing Then

                    With objUser
                        If .Status = CInt(IMSEnums.Status.Active) Then

                            lstPrivilige = Me.GetRolePriviligeByUserID(.UserID)
                            IMSConstants.AppConstants.LoggedinUserID = .UserID
                            IMSConstants.AppConstants.LoggedInUserName = .Name
                            IMSConstants.AppConstants.LoginTime = Now
                            IMSConstants.AppConstants.LoggedInAccessRightID = .AccessRight

                            userRight = _proxy.GetUserRightByID(.AccessRight)
                            If Not IsNothing(userRight) Then
                                IMSConstants.AppConstants.LoggedInAccessRightName = userRight.RightDescription
                            End If

                            'Get User's Employee Information.
                            employee = CommonFunction.GetEmployeeByUserID(.UserID)
                            If Not IsNothing(employee) Then
                                With employee
                                    IMSConstants.AppConstants.UserStationID = .StationID
                                    IMSConstants.AppConstants.UsersEmployeeID = .EmployeeID
                                    IMSConstants.AppConstants.LoggedInEmployeeName = .EmployeeName
                                End With
                            End If

                            'set login user info
                            UserUtil.SetLoggedinUser(objUser)
                            UserUtil.SetUserPreviliges(lstPrivilige)
                            LoginSecurity.UserRight = .AccessRight

                            Me.SaveLoginInformation(objUser)

                            LoggedInUser = objUser
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            LoggedInTime = Now

                        Else
                            DisplayWarningPopup(IMSConstants.ErrorMessage.InactiveUser)

                        End If

                    End With

                Else
                    DisplayWarningPopup(IMSConstants.ErrorMessage.InvalidUser)
                End If
            End If
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

#Region "Event Handers"

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.txtUserId.Focus()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click

        Try
            Me.Login()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayErrorPopup(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub txtUserId_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUserId.KeyPress

        Try
            Me.FocusOnNextControl(txtUserId, txtPassword, e)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayErrorPopup(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress

        Try
            If e.KeyChar = ChrW(Keys.Enter) Then
                Me.Login()
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayErrorPopup(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            DialogResult = Windows.Forms.DialogResult.Cancel
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayErrorPopup(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

End Class