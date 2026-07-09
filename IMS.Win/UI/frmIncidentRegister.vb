'Author                : Shah Jafar Ulla
'Crated Date           : 24/4/2014
'Last Modified by      : 
'Last Modifiation Date : 
'(C) CopyRight Nybsys.

Imports Infragistics.Win.UltraWinGrid
Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win
Imports System.Globalization

Public Class frmIncidentRegister
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 12
    Private lstIncidentRegister As New List(Of IMSService.IncidentRegister)

#End Region

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

    End Sub

#Region "User Defined Methods"



    ''' <summary>
    ''' Method to Load GridView
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()

        Dim tblIncidentRegister As DataTable = GetIncidentRegisterTable()

        With Me.grvIncidentRegister
            .DataSource = tblIncidentRegister
            .DisplayLayout.Bands(0).Columns(0).Hidden = True

            'text
            .DisplayLayout.Bands(0).Override.CellAppearance.TextHAlign = HAlign.Center
            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center
            'Button
            .DisplayLayout.Bands(0).Columns(4).Style = UltraWinGrid.ColumnStyle.Button
            .DisplayLayout.Bands(0).Columns(4).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
            .DisplayLayout.Bands(0).Columns(4).Width = 100

            .DisplayLayout.Bands(0).Columns(5).Style = UltraWinGrid.ColumnStyle.Button
            .DisplayLayout.Bands(0).Columns(5).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
            .DisplayLayout.Bands(0).Columns(6).Width = 80

            .DisplayLayout.Bands(0).Columns(6).Style = UltraWinGrid.ColumnStyle.Button
            .DisplayLayout.Bands(0).Columns(6).ButtonDisplayStyle = Infragistics.Win.UltraWinGrid.ButtonDisplayStyle.Always
            .DisplayLayout.Bands(0).Columns(6).Width = 80

            .DisplayLayout.Bands(0).Override.ButtonStyle = UIElementButtonStyle.Button3D

            ''TODO : User Access Right of Grid buttons (dispatch, edit, delete)
            If Not CommonFunction.IsSuperAdmin Then
                Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Dispatch And x.FrontEndParentID = Me.Name).FirstOrDefault()
                If IsNothing(objSavePrivilig) Then
                    .DisplayLayout.Bands(0).Columns(4).Hidden = True
                End If

                objSavePrivilig = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Edit And x.FrontEndParentID = Me.Name).FirstOrDefault()
                If IsNothing(objSavePrivilig) Then
                    .DisplayLayout.Bands(0).Columns(5).Hidden = True
                End If

                objSavePrivilig = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = IMSConstants.DataBaseValue.Delete And x.FrontEndParentID = Me.Name).FirstOrDefault()
                If IsNothing(objSavePrivilig) Then
                    .DisplayLayout.Bands(0).Columns(6).Hidden = True
                End If
            End If

            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub AddGridColumnStyle()

    End Sub

    ''' <summary>
    ''' Method to create Incident Register Table From Database.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetIncidentRegisterTable() As DataTable

        Dim sql As String
        Dim tblIncidentRegister As New DataTable
        Dim currentTime24HoursPrevFormated As DateTime
        Dim currentTime24HoursPrev As DateTime
        Dim currentTime As DateTime
        Dim lstIncidentTypeIncident As List(Of IncidentTypeIncident)
        Dim strIncidentType As String = String.Empty
        Dim stationIDForIncidentList As Integer = 0

        'Dim lstIncidentRegister As New List(Of IncidentRegister) ' this is now global variable.

        DateTime.TryParseExact(Date.Now.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)
        currentTime24HoursPrev = currentTime.AddDays(-1)
        currentTime24HoursPrev = currentTime.AddHours(-24)
        DateTime.TryParseExact(currentTime24HoursPrev.ToString("dd-MM-yyyy HH:mm:ss"), "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime24HoursPrevFormated)

        tblIncidentRegister.Columns.Add(IMSConstants.FieldConstants.IncidentID, GetType(Integer))
        tblIncidentRegister.Columns.Add(IMSConstants.GridHeader.ReferenceNo, GetType(String))
        tblIncidentRegister.Columns.Add(IMSConstants.GridHeader.IncidentType, GetType(String))
        tblIncidentRegister.Columns.Add(IMSConstants.GridHeader.Status, GetType(String))

        tblIncidentRegister.Columns.Add(IMSConstants.GridHeader.Dispatch, GetType(String))
        tblIncidentRegister.Columns.Add(IMSConstants.GridHeader.Edit, GetType(String))
        tblIncidentRegister.Columns.Add(IMSConstants.GridHeader.Delete, GetType(String))

        ''sql = String.Format("{0} <> {1}", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes))
        'sql = String.Format("{0} <> {1}  and ( {2} <> {3} or ({4} <= '{5}' and {4} >= '{6}')) order by {7} desc", _
        '                    IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.Yes), _
        '                    IMSConstants.FieldConstants.IncidentStatus, CInt(IMSEnums.IncidentStatus.Resolved), _
        '                    IMSConstants.FieldConstants.InsertionDate, currentTime, currentTime24HoursPrevFormated, _
        '                    IMSConstants.FieldConstants.IncidentID)

        ''Logic : If User (a) Station Stuff OR (b) Station Manager =>
        '' then he call see only his station incident. and bellow function will return this type user's staion or return Zero.
        stationIDForIncidentList = CommonFunction.GetLoggedInUserStationToShow()

        lstIncidentRegister = CommonFunction.GetIncidentsUnresolvedAndResolvedWithInTwoDays(stationIDForIncidentList)

        'For Each obj As IMSService.IncidentRegister In lstIncidentRegister
        For Each obj As IMSService.IncidentRegister In lstIncidentRegister.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

            Dim row As DataRow = tblIncidentRegister.NewRow

            row(IMSConstants.FieldConstants.IncidentID) = obj.IncidentID

            If Not String.IsNullOrEmpty(obj.ReferenceNo) Then
                row(IMSConstants.GridHeader.ReferenceNo) = obj.ReferenceNo
            Else
                row(IMSConstants.GridHeader.ReferenceNo) = String.Empty
            End If

            'Get Incident type
            row(IMSConstants.GridHeader.IncidentType) = CommonFunction.GetIncidentTypesInCommaSeparated(obj.IncidentID)

            If obj.IncidentStatus > 0 Then

                'Get and set status (Dispatching and Dispatched)
                If obj.IncidentStatus = CInt(IMSEnums.IncidentStatus.Dispatched) Then
                    If CommonFunction.IsAllRequiredVehicleDispatched(obj.IncidentID) Then
                        'means Dispathed
                        row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Dispatched)
                    Else
                        'means Dispatching
                        row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Dispatching)
                    End If
                End If

                'Get and Set status ( Undispatched)
                If obj.IncidentStatus = CInt(IMSEnums.IncidentStatus.Undispatched) Then

                    row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Undispatched)

                    'Dim sqlOccurrenceBook As String = IMSConstants.FieldConstants.IncidentID & " = " & obj.IncidentID
                    'Dim lstOccurrenceBook As List(Of OccurrenceBook) = _proxy.GetFilteredOccurrenceBook(sqlOccurrenceBook).Cast(Of OccurrenceBook).ToList()

                    'If lstOccurrenceBook.Count > 0 Then
                    '    'means Reopen
                    '    row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Reopened)
                    'Else
                    '    'means Undispatched
                    '    row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Undispatched)
                    'End If

                End If

                'Get and Set status (Reopen)
                If obj.IncidentStatus = CInt(IMSEnums.IncidentStatus.Reopened) Then
                    row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Reopened)

                End If

                'Get and Set status (Resolved)
                If obj.IncidentStatus = CInt(IMSEnums.IncidentStatus.Resolved) Then
                    row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Resolved)
                End If

                'row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), obj.IncidentStatus)
            Else
                row(IMSConstants.GridHeader.Status) = String.Empty
            End If

            'TODO: Add Text for Button show 

            'Dispatch Button text
            If row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Dispatched) Then
                row(IMSConstants.GridHeader.Dispatch) = IMSConstants.GridHeader.Redispatch
            ElseIf row(IMSConstants.GridHeader.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Resolved) Then
                row(IMSConstants.GridHeader.Dispatch) = String.Empty
            Else
                row(IMSConstants.GridHeader.Dispatch) = IMSConstants.GridHeader.Dispatch
            End If


            row(IMSConstants.GridHeader.Edit) = IMSConstants.GridHeader.Edit
            row(IMSConstants.GridHeader.Delete) = IMSConstants.GridHeader.Delete

            tblIncidentRegister.Rows.Add(row)

        Next

        Return tblIncidentRegister

    End Function

    ''' <summary>
    ''' Method To Load this page after event backed.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub LoadIncidentRegisterAfterEvent()

        Try
            LoadData()
            'Me.Activate()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' Method to Delete Incident Register selected at gridview.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub RemoveIncidentRegister(ByVal incidentID As Integer)

        Dim deletedId As Integer = -1
        Dim objIncidedentRegister As IMS.Win.IMSService.IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)

        If Not IsNothing(objIncidedentRegister) Then
            objIncidedentRegister.IsDeleted = IMSEnums.IsDeleted.Yes
            deletedId = _proxy.UpdateIncidentRegister(objIncidedentRegister)
        End If

        If deletedId > -1 Then
            Me.DisplaySuccessfull(IMSConstants.SuccessMessageConstants.RecordDeletedSuccessfully)
        Else
            Me.DisplayError(IMSConstants.ErrorMessage.RecordDeletionFailed)
        End If

    End Sub

    ''' <summary>
    ''' Method to Set Security.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSecurity()

        For Each objControl As Control In Me.Controls
            Me.RecurseControls(objControl)
        Next

    End Sub

    ''' <summary>
    ''' Method to recurcive function for enable disablecontrols.
    ''' </summary>
    ''' <param name="ctr"></param>
    ''' <remarks></remarks>
    Private Sub RecurseControls(ByVal ctr As Control)

        If ctr.HasChildren Then
            For Each objControl As Control In ctr.Controls
                RecurseControls(objControl)
            Next objControl
        Else
            If ctr.Name.Contains("btn") Then
                Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = ctr.Name And x.FrontEndParentID = Me.Name).FirstOrDefault()
                ctr.Enabled = Not IsNothing(objSavePrivilig)
            End If
            btnClose.Enabled = True
        End If

    End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstIncidentRegister.Count
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


    Private Sub grvIncidentRegister_InitializeLayout(sender As Object, e As InitializeLayoutEventArgs) Handles grvIncidentRegister.InitializeLayout

    End Sub

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmIncidentRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            pageIndex = 0
            Me.LoadData()
            Me.EnableDisableButton()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Try
            pageIndex = 0
            Me.LoadData()
            Me.EnableDisableButton()
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
    Private Sub grvIncidentRegister_ClickCellButton(sender As Object, e As CellEventArgs) Handles grvIncidentRegister.ClickCellButton
        Try

            Dim incidentID As Integer = grvIncidentRegister.Rows(e.Cell.Row.Index).Cells(0).Value
            Dim referenceNo As String = grvIncidentRegister.Rows(e.Cell.Row.Index).Cells(1).Value

            'Dispatch Button Clicked
            If e.Cell.Column.Index = 4 Then
                Dim frm As frmDispatchVehicles = New frmDispatchVehicles(incidentID, referenceNo)
                AddHandler frm.LoadDispatchVehicleForm, AddressOf LoadIncidentRegisterAfterEvent
                frm.ShowDialog()
            End If

            'Edit Button Clicked
            If e.Cell.Column.Index = 5 Then
                Dim frm As frmAddIncident = New frmAddIncident(incidentID, True)
                AddHandler frm.LoadAddIncidentForm, AddressOf LoadIncidentRegisterAfterEvent

                'Dim IsAddIncidentOpened = CommonFunction.IsFormOpen("frmAddIncident")
                'Me.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Activate()

                With frm
                    .MdiParent = frmMain
                    .AutoScrollMinSize = .Size
                    .Show()
                    .AutoScroll = True
                End With

            End If

            'Delete Button Clicked
            If e.Cell.Column.Index = 6 Then
                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then
                    If incidentID > 0 Then
                        RemoveIncidentRegister(incidentID)
                        Me.LoadData()
                    Else
                        Me.DisplayError(IMSConstants.ErrorMessage.RecordDeletionFailed)
                    End If
                End If
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOccuranceBook_Click(sender As Object, e As EventArgs) Handles btnOccuranceBook.Click

        Try
            Dim frm As frmOccurrenceBook = New frmOccurrenceBook()
            frm.ShowDialog()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try
            Dim frm As frmAddIncident = New frmAddIncident()
            AddHandler frm.LoadAddIncidentForm, AddressOf LoadIncidentRegisterAfterEvent

            frm.ShowDialog()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ' ''' <summary>
    ' ''' 
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click

    '    Try
    '        LoadData()
    '    Catch ex As Exception
    '        Me.WriteLog(ex)
    '        Me.DisplayError(IMSConstants.ExceptionMessage.Message)
    '    End Try

    'End Sub

    ''' <summary>
    ''' Event on row bound.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub grvIncidentRegister_InitializeRow(sender As Object, e As InitializeRowEventArgs) Handles grvIncidentRegister.InitializeRow
        With grvIncidentRegister

            'Background color
            If e.Row.Cells(3).Value = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Undispatched) Then
                e.Row.Appearance.BackColor = Color.Red
            ElseIf e.Row.Cells(3).Value = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Dispatching) Then
                e.Row.Appearance.BackColor = Color.Yellow
            ElseIf e.Row.Cells(3).Value = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Dispatched) Then
                e.Row.Appearance.BackColor = Color.Blue
                e.Row.Appearance.ForeColor = Color.White
            ElseIf e.Row.Cells(3).Value = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Resolved) Then
                e.Row.Appearance.BackColor = Color.Green
                e.Row.Appearance.ForeColor = Color.White
                'Disable "Dispatch" button - as incident status is resolved
                e.Row.Cells(4).Activation = Activation.Disabled
            ElseIf e.Row.Cells(3).Value = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Reopened) Then
                e.Row.Appearance.BackColor = Color.Red
            End If

        End With
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

    Private Sub tRefresh_Tick(sender As Object, e As EventArgs) Handles tRefresh.Tick

        Try
            pageIndex = 0
            Me.LoadData()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

    'Private Sub frmIncidentRegister_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
    '    RemoveHandler frm.LoadAddIncidentForm, AddressOf LoadIncidentRegisterAfterEvent
    'End Sub

End Class



