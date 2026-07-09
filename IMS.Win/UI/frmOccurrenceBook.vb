'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 29-Apr-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win

Public Class frmOccurrenceBook
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 12
    Private lstIncidentRegister As New List(Of IMSService.IncidentRegister)

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
    ''' Method to load Occarence Book.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadOccurenceBook()

        Dim tblIncident As DataTable = CreateDataTable()
        Dim row As DataRow = tblIncident.NewRow
        'Dim filter As String = String.Format("{0} between '{1}' AND '{2}'", IMSConstants.FieldConstants.InsertionDate, dateFrom, dateTo)

        'Dim lstIncidentRegister As List(Of IMSService.IncidentRegister) = _proxy.GetFilteredIncidentRegister(filter).Cast(Of IMSService.IncidentRegister).ToList()


        For Each obj As IMSService.IncidentRegister In lstIncidentRegister.Skip(pageIndex * listSize).Take(listSize)

            row = CreateRow(obj, tblIncident)
            tblIncident.Rows.Add(row)

        Next

        With Me.grvOccarenceBook

            If tblIncident.Rows.Count > 0 Then
                .DataSource = tblIncident
                .DisplayLayout.Bands(0).Columns(0).Hidden = True
                .DisplayLayout.Override.ActiveCellAppearance.Reset()
                .DisplayLayout.Override.ActiveRowAppearance.Reset()
            Else
                tblIncident = CreateDataTableForNoDataFound()
                .DataSource = tblIncident

                '.DisplayLayout.Bands(0).Columns(0).Hidden = True
                '.DisplayLayout.Override.ActiveCellAppearance.Reset()
                '.DisplayLayout.Override.ActiveRowAppearance.Reset()
            End If

            .DisplayLayout.Bands(0).Override.HeaderAppearance.TextHAlign = HAlign.Center

        End With

    End Sub

    ''' <summary>
    ''' Method to Create data table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDataTable() As DataTable

        Dim tblIncident As New DataTable

        tblIncident.Columns.Add(IMSConstants.FieldConstants.IncidentID, GetType(Integer))
        tblIncident.Columns.Add(IMSConstants.GridHeader.ReferenceNo, GetType(String))
        tblIncident.Columns.Add(IMSConstants.GridHeader.IncidentType, GetType(String))
        tblIncident.Columns.Add(IMSConstants.FieldConstants.Status, GetType(String))

        Return tblIncident

    End Function

    ''' <summary>
    ''' Method to Create blank table.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDataTableForNoDataFound() As DataTable

        Dim tblIncident As New DataTable

        tblIncident.Columns.Add(IMSConstants.Common.Message, GetType(String))
        Dim dr As DataRow = tblIncident.NewRow
        dr(IMSConstants.Common.Message) = IMSConstants.Messages.NoRecordFound
        tblIncident.Rows.Add(dr)

        Return tblIncident

    End Function

    ''' <summary>
    ''' Method to create Row.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="tblIncidentRegister"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateRow(ByVal obj As IMSService.IncidentRegister, ByVal tblIncidentRegister As DataTable) As DataRow

        Dim row As DataRow = tblIncidentRegister.NewRow

        row(IMSConstants.FieldConstants.IncidentID) = obj.IncidentID
        row(IMSConstants.GridHeader.ReferenceNo) = obj.ReferenceNo
        row(IMSConstants.GridHeader.IncidentType) = CommonFunction.GetIncidentTypesInCommaSeparated(obj.IncidentID)
        row(IMSConstants.FieldConstants.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), obj.IncidentStatus)

        ''Get and Set status (Reopen and Undispatched)
        'If obj.IncidentStatus = CInt(IMSEnums.IncidentStatus.Undispatched) Then

        '    Dim sqlOccurrenceBook As String = IMSConstants.FieldConstants.IncidentID & " = " & obj.IncidentID
        '    Dim lstOccurrenceBook As List(Of OccurrenceBook) = _proxy.GetFilteredOccurrenceBook(sqlOccurrenceBook).Cast(Of OccurrenceBook).ToList()

        '    If lstOccurrenceBook.Count > 0 Then
        '        'means Reopen
        '        row(IMSConstants.FieldConstants.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Reopened)
        '    Else
        '        'means Undispatched
        '        row(IMSConstants.FieldConstants.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), IMSEnums.IncidentStatus.Undispatched)
        '    End If
        'End If

        Return row

    End Function

    ''' <summary>
    ''' Method to Generate Incidentn List
    ''' </summary>
    ''' <param name="fromDate"></param>
    ''' <param name="toDate"></param>
    ''' <remarks></remarks>
    Private Sub GenerateIncidentList(ByVal stationID As Integer, fromDate As DateTime, toDate As DateTime)

        Dim filter As String = String.Empty
        Dim sqlForSpecificStationFilter As String = IMSConstants.FieldConstants.IncidentID & " In( select " & IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.StationIncident & " where " & IMSConstants.FieldConstants.StationID & " = " & stationID.ToString() & ")"

        If stationID > 0 Then

            filter = String.Format("{0} between '{1}' AND '{2}' AND {3}='{4}' AND {5}", IMSConstants.FieldConstants.InsertionDate, GetFromDate(fromDate).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(toDate).ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No), sqlForSpecificStationFilter)
        Else
            filter = String.Format("{0} between '{1}' AND '{2}' AND {3}='{4}'", IMSConstants.FieldConstants.InsertionDate, GetFromDate(fromDate).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(toDate).ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No))

        End If

        lstIncidentRegister = _proxy.GetFilteredIncidentRegister(filter).Cast(Of IMSService.IncidentRegister).ToList()

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

    ''' <summary>
    ''' Method to search and load incident
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadSearchedIncident()

        ''Logic : If User (a) Station Stuff OR (b) Station Manager =>
        '' then he call see only his station incident. and bellow function will return this type user's staion or return Zero.
        Dim stationIDForIncidentList As Integer = CommonFunction.GetLoggedInUserStationToShow()

        Me.GenerateIncidentList(stationIDForIncidentList, GetFromDate(dtpDateFrom.Value), GetToDate(dtpDateTo.Value))
        Me.LoadOccurenceBook()
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

#End Region

#Region "Event Handlers"

    Private Sub frmOccurrenceBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            ''Logic : If User (a) Station Stuff OR (b) Station Manager =>
            '' then he call see only his station incident. and bellow function will return this type user's staion or return Zero.
            Dim stationIDForIncidentList As Integer = CommonFunction.GetLoggedInUserStationToShow()
            Me.dtpDateFrom.Value = GetFromDate(DateTime.Now)
            Me.dtpDateTo.Value = GetToDate(DateTime.Now)
            Me.GenerateIncidentList(stationIDForIncidentList, GetFromDate(DateTime.Now), GetToDate(DateTime.Now))
            Me.LoadOccurenceBook()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            pageIndex = 0
            LoadSearchedIncident()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        Try
            pageIndex = pageIndex - 1
            Me.LoadOccurenceBook()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Try
            pageIndex = pageIndex + 1
            Me.LoadOccurenceBook()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnReopen_Click(sender As Object, e As EventArgs) Handles btnReopen.Click
        Try
            Dim incidentID As Integer = 0
            Dim valInt As Integer

            If grvOccarenceBook.Selected.Rows.Count > 0 Then
                If Integer.TryParse(grvOccarenceBook.Selected.Rows(0).Cells(0).Value, valInt) Then

                    incidentID = CInt(grvOccarenceBook.Selected.Rows(0).Cells(0).Value.ToString())
                    Dim objIncidentRegister As IMSService.IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)

                    If Not objIncidentRegister Is Nothing Then

                        objIncidentRegister.IncidentStatus = IMSEnums.IncidentStatus.Reopened
                        If _proxy.UpdateIncidentRegister(objIncidentRegister) > 0 Then
                            Me.DisplaySuccessfull(IMSConstants.SuccessMessageConstants.IncidentReopenedSuccessfully)
                            LoadSearchedIncident()
                        Else
                            Me.DisplayError(IMS.Lib.IMSConstants.ErrorMessage.ReopenFail)
                        End If
                    End If
                End If
            Else
                If grvOccarenceBook.Rows.Count > 0 Then
                    If Integer.TryParse(grvOccarenceBook.Rows(0).Cells(0).Value, valInt) Then
                        DisplayWarning(IMSConstants.Messages.SelectARecord)
                    End If
                End If
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        Try
            Dim incidentID As Integer = 0
            Dim valInt As Integer

            If grvOccarenceBook.Selected.Rows.Count > 0 Then
                If Integer.TryParse(grvOccarenceBook.Selected.Rows(0).Cells(0).Value, valInt) Then

                    incidentID = CInt(grvOccarenceBook.Selected.Rows(0).Cells(0).Value.ToString())
                    Dim objIncidentRegister As IMSService.IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)
                    If Not objIncidentRegister Is Nothing Then
                        If objIncidentRegister.IncidentStatus = CInt(IMSEnums.IncidentStatus.Resolved) Then
                            Dim frm As frmAddResolvedIncident = New frmAddResolvedIncident(incidentID)
                            frm.ShowDialog()
                        Else
                            Dim frm As frmAddIncident = New frmAddIncident(incidentID)
                            frm.ShowDialog()
                        End If
                    End If
                End If

                'If grvOccarenceBook.Selected.Rows(0).Cells(0).Value <> "No data found." Then
                '    Dim incidentID As Integer = 0
                '    incidentID = CInt(grvOccarenceBook.Selected.Rows(0).Cells(0).Value.ToString())
                '    Dim objIncidentRegister As IMSService.IncidentRegister = _proxy.GetIncidentRegisterByID(incidentID)
                '    If Not objIncidentRegister Is Nothing Then
                '        If objIncidentRegister.IncidentStatus = CInt(IMSEnums.IncidentStatus.Resolved) Then
                '            Dim frm As frmAddResolvedIncident = New frmAddResolvedIncident(incidentID)
                '            frm.ShowDialog()
                '        Else
                '            Dim frm As frmAddIncident = New frmAddIncident(incidentID)
                '            frm.ShowDialog()
                '        End If

                '    End If
                'End If
            Else
                'If grvOccarenceBook.Rows.Count > 0 Then
                '    If Integer.TryParse(grvOccarenceBook.Rows(0).Cells(0).Value, valInt) Then
                '        DisplayWarning(IMSConstants.Messages.SelectARecord)
                '    End If
                'End If
                DisplayWarning(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

End Class