
Imports IMS.Lib
Imports Infragistics.Win.Misc

Public Class frmMain
    Inherits BaseForm
    Implements IMainForm

#Region "Member Veriable"

    Dim timercount As Integer = 0
    Public Delegate Sub MainFormShowMessageInvoker(caption As String, message As String, imageUrl As String, soundUrl As String, isPinned As Boolean)
    Dim alertCount As Integer = 0

#End Region

#Region "Constuctor"


    Public Sub New()

        If frmLogin.ShowDialog = Windows.Forms.DialogResult.OK Then
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            initializeMain()

        Else
            End
        End If
        'InitializeComponent()

    End Sub

    Sub initializeMain() Implements IMainForm.InitializeMain

        'Proxys.moduleID = CInt(SLAF.Lib.SLAFEnum.SLAFModules.Selection)
        'UserUtil.UpdateProxy(Me.Name)

        'With Me.UltraStatusBar1

        '    .Panels(1).Text = Proxys.userID
        '    .Panels(3).Text = Proxys.GetFacadeProxy.GetUserRightByID(Proxys.GetFacadeProxy.ServerLoggedInUser.AccessRight).RightDescription
        '    .Panels(7).Text = Proxys.SessionID

        'End With

        'CallObject(New frmDashboard)
        'SetTime = 70
        'AddHandler Timer1.Tick, AddressOf Timer1_Tick
        'Timer1.Interval = New TimeSpan
        'Timer1.Start()

    End Sub


#End Region

#Region "Private Methods"

    Private Sub OnBeforeFormClosing(e As FormClosingEventArgs) Implements IMainForm.OnBeforeFormClosing

        If MsgBox(" Do you want to Close ?", MsgBoxStyle.OkCancel, "Closing") <> MsgBoxResult.Ok Then
            e.Cancel = True
        End If

    End Sub

#Region "Call Object"

    Private Sub CallObject(ByVal Obj As Form) Implements IMainForm.CallObject
        If Not CheckObjects(Obj.Name) Then
            Obj.MdiParent = Me
            Obj.AutoScrollMinSize = Obj.Size
            Obj.Show()
            Obj.AutoScroll = True
        End If
    End Sub

    Private Sub CallObject(ByVal Obj As Form, ByVal willNotOpenCheck As Boolean)

        If willNotOpenCheck Then
            Obj.MdiParent = Me
            Obj.AutoScrollMinSize = Obj.Size
            Obj.Show()
            Obj.AutoScroll = True
        End If

    End Sub

    Private Function CheckObjects(ByVal ObjName As String) As Boolean Implements IMainForm.CheckObjects
        Dim BolFlag As Boolean
        'Dim obj As Form
        Dim i As Int16
        Try
            For i = 0 To Me.ultraTabbedMdiManager.TabGroups(0).Tabs.Count - 1
                If Me.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Name = ObjName Then
                    BolFlag = True
                    Me.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Activate()

                End If
            Next
        Catch ex As Exception
            BolFlag = False
        End Try

        Return BolFlag
    End Function

#End Region

    ''' <summary>
    ''' Method to Get the Type name by form name.
    ''' </summary>
    ''' <param name="formName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTypeName(ByVal formName As String) As String
        Return Me.GetType().ToString().Replace(Me.Name, formName)
    End Function



#End Region

#Region "Event Handlers"

    'Private Sub MessageToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MessageToolStripMenuItem.Click
    '    Dim tabForm As New frmMeesageSend()
    '    Me.CallObject(tabForm)
    'End Sub

    Private Sub ultraExplorerBar1_ItemClick(sender As Object, e As Infragistics.Win.UltraWinExplorerBar.ItemEventArgs) Handles ultraExplorerBar1.ItemClick
        Try

            Dim frmKey As String = e.Item.Key
            Dim tabForm As BaseForm = Nothing

            If Not String.IsNullOrEmpty(frmKey) Then

                Dim formFullName As String = GetTypeName(frmKey)

                If Not String.IsNullOrEmpty(formFullName) Then
                    tabForm = Activator.CreateInstance(Type.GetType(formFullName))
                    Me.CallObject(tabForm)
                End If

            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim objSavePrivilig As IMSService.Privileges

            CommonFunctions.MainForm = Me

            If Not CommonFunction.IsSuperAdmin() Then

                Dim lstPrivilege As List(Of IMSService.Privileges) = UserUtil.GetUserPreviliges()

                For Each ultraGroup As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarGroup In ultraExplorerBar1.Groups
                    For Each item As Infragistics.Win.UltraWinExplorerBar.UltraExplorerBarItem In ultraGroup.Items

                        'If item.Key = "DashBoard" Then
                        '    Dim dd As String = ""
                        'End If

                        objSavePrivilig = lstPrivilege.Where(Function(x) x.FrontEndID = item.Key And x.FrontEndParentID = String.Empty).FirstOrDefault()
                        item.Visible = Not IsNothing(objSavePrivilig)

                    Next
                Next
            End If

            UltraStatusBar1.Panels(1).Text = IMSConstants.AppConstants.LoggedInUserName
            UltraStatusBar1.Panels(3).Text = IMSConstants.AppConstants.LoggedInEmployeeName
            UltraStatusBar1.Panels(7).Text = IMSConstants.AppConstants.LoggedInAccessRightName
            UltraStatusBar1.Panels(9).Text = "Version: " + Application.ProductVersion

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Try
            Me.OnBeforeFormClosing(e)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub frmMain_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        'Me.OnFormActivated()
    End Sub

    Private Sub tsbDashboard_Click(sender As Object, e As EventArgs) Handles tsbDashboard.Click
        'CallObject(New frmDashboard)
    End Sub

    'Logout Sub by KMC
    Private Sub tsbLogout_Click(sender As Object, e As EventArgs) Handles tsbLogout.Click

        Try

            If MsgBox("Are you sure you want to logout?",
                  MsgBoxStyle.YesNo,
                  "Logout Confirmation") = MsgBoxResult.Yes Then

                UserUtil.Logout()

                Me.Hide()

                If frmLogin.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    Me.Show()
                Else
                    Me.Close()
                End If

            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub


    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Try
            Dim iHour As Integer
            Dim iMinutes As Integer
            Dim iSeconds As Integer

            timercount += 1
            iHour = Math.Floor(timercount / 3600)
            iMinutes = Math.Floor(timercount / 60) Mod 60
            iSeconds = timercount Mod 60

            UltraStatusBar1.Panels(5).Text = String.Format("{0}hr {1}min {2}sec", iHour, iMinutes, iSeconds)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

#Region "Alert Messages"

    Public Sub ShowMessage(caption As String, message As String, imageUrl As String, soundUrl As String, isPinned As Boolean)

        If Me.InvokeRequired Then
            Dim invoker As New MainFormShowMessageInvoker(AddressOf ShowMessage)
            Me.Invoke(invoker, New Object() {caption, message, imageUrl, soundUrl, isPinned})
        Else
            '  Create a new instance of the UltraDesktopAlertShowWindowInfo class.
            Dim showInfo As New UltraDesktopAlertShowWindowInfo()

            '  Set the key to uniquely identify this desktop alert window
            alertCount += 1
            showInfo.Key = "myWindow" + alertCount.ToString()

            '  Set the Caption, Text, and FooterText properties using formatting
            '  characters that are recognized by the FormattedTextUIElement.
            showInfo.Caption = (Convert.ToString("<span style=""font-weight:bold_x003B_"">") & caption) + "</span><br/>"
            showInfo.Text = (Convert.ToString("<span style="""">") & message) + "</span><br/>"
            'showInfo.FooterText = "<a href=\"www.infragistics.com\">Click to visit the Infragistics website</a>";

            '  Use the ScreenPosition property to make the desktop alert
            '  window appear at the top left corner of the screen
            showInfo.ScreenPosition = ScreenPosition.BottomRight
            showInfo.Screen = Screen.AllScreens(Screen.AllScreens.Length - 1)

            ' get image and sound
            Dim finfo As New System.IO.FileInfo(Application.ExecutablePath)
            Dim alertPath As String = finfo.DirectoryName + "\alert\"
            showInfo.Image = New Icon(alertPath & imageUrl).ToBitmap()
            showInfo.Sound = alertPath & soundUrl

            showInfo.PinButtonVisible = isPinned
            showInfo.Pinned = isPinned

            Me.Alerter.Show(showInfo)
        End If

    End Sub

#End Region


End Class