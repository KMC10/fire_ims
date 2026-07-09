'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 29-Apr-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmIncidentReport
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 10
    Private lstOccurrenceBook As New List(Of IMSService.OccurrenceBook)

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

        'Dim lstOccurrenceBook As List(Of IMSService.IncidentRegister) = _proxy.GetFilteredIncidentRegister(filter).Cast(Of IMSService.IncidentRegister).ToList()

        For Each obj As IMSService.OccurrenceBook In lstOccurrenceBook.Skip(pageIndex * listSize).Take(listSize)
            row = CreateRow(obj, tblIncident)
            tblIncident.Rows.Add(row)
        Next

        With Me.grvOccarenceBook
            .DataSource = tblIncident
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Bands(0).Columns(1).Width = 70
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
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
        'tblIncident.Columns.Add(IMSConstants.FieldConstants.Status, GetType(String))

        Return tblIncident

    End Function

    ''' <summary>
    ''' Method to create Row.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="tblIncidentRegister"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateRow(ByVal obj As IMSService.OccurrenceBook, ByVal tblIncidentRegister As DataTable) As DataRow

        Dim row As DataRow = tblIncidentRegister.NewRow

        With obj
            row(IMSConstants.FieldConstants.IncidentID) = .IncidentID
            row(IMSConstants.GridHeader.ReferenceNo) = CommonFunction.GetReferenceNumberByIncidentID(.IncidentID)
            row(IMSConstants.GridHeader.IncidentType) = CommonFunction.GetIncidentTypesInCommaSeparated(.IncidentID)
            'row(IMSConstants.FieldConstants.Status) = [Enum].GetName(GetType(IMSEnums.IncidentStatus), obj.IncidentStatus)
        End With

        Return row

    End Function

    ''' <summary>
    ''' Method to Generate Incidentn List
    ''' </summary>
    ''' <param name="fromDate"></param>
    ''' <param name="toDate"></param>
    ''' <remarks></remarks>
    Private Sub GenerateIncidentList(fromDate As DateTime, toDate As DateTime)

        Dim filter As String = String.Format("{0} between '{1}' AND '{2}'", IMSConstants.FieldConstants.ReportDate, GetFromDate(fromDate).ToString(IMSConstants.AppConstants.DateFormatToQuery), GetToDate(toDate).ToString(IMSConstants.AppConstants.DateFormatToQuery))

        If Not String.IsNullOrEmpty(cmbIncidentCategory.Value) Then

        End If

        lstOccurrenceBook = _proxy.GetFilteredIncidentRegister(filter).Cast(Of IMSService.OccurrenceBook).ToList()

    End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstOccurrenceBook.Count
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

    ''' <summary>
    ''' Method to Load Incident Catagory.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadIncidentCategory()

        Dim tblIncidentCategory As New DataTable
        Dim filter As String = String.Format("{0}='{1}' order by {2} asc", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.CategoryName)

        tblIncidentCategory.Columns.Add(IMSConstants.FieldConstants.CategoryID)
        tblIncidentCategory.Columns.Add(IMSConstants.FieldConstants.CategoryName)

        For Each obj As IMSService.IncidentCategory In _proxy.GetFilteredIncidentCategory(filter)
            Dim rows As DataRow = tblIncidentCategory.NewRow
            rows(IMSConstants.FieldConstants.CategoryID) = obj.CategoryID
            rows(IMSConstants.FieldConstants.CategoryName) = obj.CategoryName
            tblIncidentCategory.Rows.Add(rows)
        Next

        Dim row As DataRow = tblIncidentCategory.NewRow
        row(IMSConstants.FieldConstants.CategoryID) = String.Empty
        row(IMSConstants.FieldConstants.CategoryName) = String.Empty
        tblIncidentCategory.Rows.InsertAt(row, 0)

        With Me.cmbIncidentCategory
            .DataSource = tblIncidentCategory
            .ValueMember = IMSConstants.FieldConstants.CategoryID
            .DisplayMember = IMSConstants.FieldConstants.CategoryName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Incident Type depending on Incident Category ID.
    ''' </summary>
    ''' <param name="incidentCategoryID"></param>
    ''' <remarks></remarks>
    Private Sub LoadIncidentType(ByVal incidentCategoryID As Integer)

        Dim tblIncidentType As New DataTable
        Dim filter As String = String.Format("{0}='{1}' and {2} = {3} order by {4} asc", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.CategoryID, incidentCategoryID, IMSConstants.FieldConstants.IncidentTypeDescription)

        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.IncidentTypeID)
        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.IncidentTypeDescription)

        For Each obj As IMSService.IncidentType In _proxy.GetFilteredIncidentType(filter)
            Dim rows As DataRow = tblIncidentType.NewRow
            rows(IMSConstants.FieldConstants.IncidentTypeID) = obj.IncidentTypeID
            rows(IMSConstants.FieldConstants.IncidentTypeDescription) = obj.IncidentTypeDescription
            tblIncidentType.Rows.Add(rows)
        Next

        Dim row As DataRow = tblIncidentType.NewRow
        row(IMSConstants.FieldConstants.IncidentTypeID) = String.Empty
        row(IMSConstants.FieldConstants.IncidentTypeDescription) = String.Empty
        tblIncidentType.Rows.InsertAt(row, 0)

        With Me.cmbIncidentType
            .DataSource = tblIncidentType
            .ValueMember = IMSConstants.FieldConstants.IncidentTypeID
            .DisplayMember = IMSConstants.FieldConstants.IncidentTypeDescription
            .DataBind()
        End With

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
        End With

    End Sub



#End Region

#Region "Event Handlers"

    Private Sub frmOccurrenceBook_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            Me.LoadStation()
            Me.LoadIncidentCategory()
            Me.dtpDateFrom.Value = Now
            Me.dtpDateTo.Value = Now
            'Me.GenerateIncidentList(GetFromDate(dtpDateFrom.Value), GetFromDate(dtpDateTo.Value))
            'Me.LoadOccurenceBook()
            'Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            Dim sql As String = String.Empty
            Dim sqlIncidentTye As String = String.Empty
            Dim lstIncidentType As New List(Of IMSService.IncidentType)
            Dim counter As Integer = 0

            If Not String.IsNullOrEmpty(txtReferenceNO.Text) Then
                'Find with Reference NO
                sql = IMSConstants.FieldConstants.IncidentID & " In (select " & _
                    IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.IncidentRegister & _
                    " where " & IMSConstants.FieldConstants.IncidentStatus & " = " & CInt(IMSEnums.IncidentStatus.Resolved) & " and  " & IMSConstants.FieldConstants.IsDeleted & " = 0  and " & IMSConstants.FieldConstants.ReferenceNo & " = '" & txtReferenceNO.Text & "')"

                lstOccurrenceBook = _proxy.GetFilteredOccurrenceBook(sql).Cast(Of IMSService.OccurrenceBook).ToList()

                If lstOccurrenceBook.Count <= 0 Then
                    DisplayWarning(IMSConstants.ErrorMessage.InvalidReferenceNumberORUnresolvedIncident)
                End If

            Else
                'TODO : Search
                ''Common query part
                'sql = IMSConstants.FieldConstants.ReportDate & " between '" & GetFromDate(dtpDateFrom.DateTime) & "' and '" & GetToDate(dtpDateTo.DateTime) & "' "
                sql = IMSConstants.FieldConstants.ReportDate & " between '" & GetFromDate(dtpDateFrom.DateTime).ToString(IMSConstants.AppConstants.DateFormatToQuery) & "' and '" & GetToDate(dtpDateTo.DateTime).ToString(IMSConstants.AppConstants.DateFormatToQuery) & "' "

                'If station selected
                If Not String.IsNullOrEmpty(cmbStationName.Value) Then
                    sql += " and " & IMSConstants.FieldConstants.IncidentID & " In (select " _
                        & IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.StationIncident & " where " & IMSConstants.FieldConstants.StationID & " = " & CInt(cmbStationName.Value) & " ) "
                End If

                ' If Incident type selected
                If Not String.IsNullOrEmpty(cmbIncidentType.Value) Then

                    sql += " and " & IMSConstants.FieldConstants.IncidentID & " In (select " _
                        & IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.IncidentTypeIncident & " where " & IMSConstants.FieldConstants.IncidentTypeID & " = " & CInt(cmbIncidentType.Value) & " ) "

                ElseIf Not String.IsNullOrEmpty(cmbIncidentCategory.Value) Then

                    sqlIncidentTye = IMSConstants.FieldConstants.CategoryID & " = " & CInt(cmbIncidentCategory.Value) & " and " & IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active)
                    lstIncidentType = _proxy.GetFilteredIncidentType(sqlIncidentTye).Cast(Of IMSService.IncidentType).ToList()

                    If lstIncidentType.Count > 0 Then

                        sql += " and " & IMSConstants.FieldConstants.IncidentID & " In (select " _
                        & IMSConstants.FieldConstants.IncidentID & " from " & IMSConstants.TableNames.IncidentTypeIncident & " where "
                        ' & IMSConstants.FieldConstants.IncidentTypeID & " = " & CInt(cmbIncidentType.Value) & " ) "

                        For Each obj As IMSService.IncidentType In lstIncidentType
                            If counter > 0 Then
                                sql += " or " & IMSConstants.FieldConstants.IncidentTypeID & " = " & obj.IncidentTypeID
                            Else
                                sql += " " & IMSConstants.FieldConstants.IncidentTypeID & " = " & obj.IncidentTypeID
                            End If

                            counter = counter + 1
                        Next

                        sql += " ) "

                    End If

                End If

                lstOccurrenceBook = _proxy.GetFilteredOccurrenceBook(sql).Cast(Of IMSService.OccurrenceBook).ToList()

                'Me.GenerateIncidentList(GetFromDate(dtpDateFrom.Value), GetFromDate(dtpDateTo.Value))

            End If

            Me.LoadOccurenceBook()
            Me.EnableDisableButton()

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

    Private Sub btnShowReport_Click(sender As Object, e As EventArgs) Handles btnShowReport.Click
        Try
            Dim isGrassFire As Boolean = False

            If grvOccarenceBook.Selected.Rows.Count > 0 Then

                Dim frm As frmShowReport
                'Dim lstCategory As List(Of IMSService.IncidentCategory)
                Dim lstTypes As New List(Of IMSService.IncidentType)

                Dim incidentID As Integer = 0
                incidentID = CInt(grvOccarenceBook.Selected.Rows(0).Cells(0).Value.ToString())

                If incidentID > 0 Then

                    ''Decide what is the report will open (depending on types and categories)
                    'lstCategory = CommonFunction.GetAllCategoriesForSpecificIncident(incidentID)

                    lstTypes = CommonFunction.GetAllTypesOfSpecificIncident(incidentID)

                    For Each objType As IMSService.IncidentType In lstTypes

                        'Decide - Is it Grass Fire
                        If objType.IncidentTypeCode = IMSConstants.Settings.GrassFireTypeCode Then
                            isGrassFire = True
                        End If

                        '' Open one report for each categories.
                        frm = New frmShowReport(incidentID, objType.CategoryID, isGrassFire)
                        frm.MdiParent = frmMain
                        frm.AutoScrollMinSize = frm.Size
                        frm.Show()
                        frm.AutoScroll = True

                    Next
                End If
            Else
                DisplayWarning(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub cmbIncidentCategory_SelectionChanged(sender As Object, e As EventArgs) Handles cmbIncidentCategory.SelectionChanged
        Try

            If Not String.IsNullOrEmpty(cmbIncidentCategory.Value) Then
                Me.LoadIncidentType(cmbIncidentCategory.Value)
            Else
                Me.LoadIncidentType(0)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

End Class