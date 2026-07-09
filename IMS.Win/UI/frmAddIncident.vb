'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 25-Apr-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization
Imports IMS.Win.IMSService

Public Class frmAddIncident
    Inherits BaseForm

#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private IsWithoutEventFire As Boolean = False
    Private mIncidentRegister As New IMSService.IncidentRegister
    Private _proxy As New IMSService.IMSServices
    Private isFromIncidentRegister As Boolean = False
    Private lstIncidentTypeSelected As New List(Of Integer)

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.IsWithoutEventFire = True
        ' Add any initialization after the InitializeComponent() call.

        'Me.IsUpdate = True
        'Me.mIncidentRegister = _proxy.GetIncidentRegisterByID(49)
        'Me.txtResolution.Visible = True
        Me.btnResolve.Visible = False
        'Me.lblResolution.Visible = True


    End Sub


    Public Sub New(ByVal IncidentID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.mIncidentRegister = _proxy.GetIncidentRegisterByID(IncidentID)
        Me.btnAddNew.Visible = False
        Me.btnSave.Visible = False
        Me.btnResolve.Visible = False
        Me.btnReopen.Visible = False

    End Sub


    Public Sub New(ByVal IncidentID As Integer, ByVal eventFromIncidentRegister As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.IsUpdate = True
        Me.mIncidentRegister = _proxy.GetIncidentRegisterByID(IncidentID)
        Me.Text = "Update Incident Register"
        Me.btnSave.Text = "Update"
        Me.isFromIncidentRegister = True
        Me.txtResolution.Visible = True
        Me.btnResolve.Visible = True
        Me.lblResolution.Visible = True

        'Check for Reopen
        If (mIncidentRegister.IncidentStatus = IMSEnums.IncidentStatus.Resolved) And (Not String.IsNullOrEmpty(mIncidentRegister.Resolution)) Then
            Me.btnReopen.Visible = True
            Me.btnResolve.Enabled = False
        End If

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to Load Incident category List box.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadIncidentCategoryCheckBoxList()

        Dim sql As String = IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active)
        Dim lstIncidentCategory As List(Of IncidentCategory) = _proxy.GetFilteredIncidentCategory(sql).Cast(Of IncidentCategory).ToList()

        With chklstIncidentCategory
            .DataSource = lstIncidentCategory
            .ValueMember = IMSConstants.FieldConstants.chklstIncidentCategoryVM
            .DisplayMember = IMSConstants.FieldConstants.chklstIncidentCategoryDM
            .ClearSelected()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Station List box.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStationCheckBoxList()

        Dim sql As String = IMSConstants.FieldConstants.IsDeleted & "=" & IMSEnums.IsDeleted.No & " ORDER BY " & "StationName ASC"
        Dim lstFireStation As List(Of FireStation) = _proxy.GetFilteredFireStation(sql).Cast(Of FireStation).ToList()

        With chkFireStation
            .DataSource = lstFireStation
            .ValueMember = IMSConstants.FieldConstants.chkFireStationVM
            .DisplayMember = IMSConstants.FieldConstants.chkFireStationDM
            .ClearSelected()
        End With

        LoadStationDropDown(lstFireStation)
    End Sub

    ''' <summary>
    ''' Method to Save IncidentTypeIncident
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Private Sub SaveIncidentTypeIncident(ByVal incidentID As Integer)

        Me.DeleteIncidentTypeIncident(incidentID)

        For Each objIncidentType As IMSService.IncidentType In chklstIncidentType.CheckedItems
            Dim objIncidentTypeIncident As New IMSService.IncidentTypeIncident

            objIncidentTypeIncident.IncidentID = incidentID
            objIncidentTypeIncident.IncidentTypeID = objIncidentType.IncidentTypeID

            _proxy.InsertIncidentTypeIncident(objIncidentTypeIncident)

        Next

    End Sub

    ''' <summary>
    ''' Method to Delete IncidentTypeIncident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Private Sub DeleteIncidentTypeIncident(ByVal incidentID As Integer)

        Dim strSQL = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IncidentID, incidentID)
        Dim lstIncidentTypeIncident As List(Of IMSService.IncidentTypeIncident) = _proxy.GetFilteredIncidentTypeIncident(strSQL).Cast(Of IMSService.IncidentTypeIncident).ToList()

        If Not IsNothing(lstIncidentTypeIncident) Then

            For Each objIncidentTypeIncident As IMSService.IncidentTypeIncident In lstIncidentTypeIncident
                _proxy.DeleteIncidentTypeIncident(objIncidentTypeIncident)
            Next

        End If

    End Sub

    ''' <summary>
    ''' Method to Save StationIncident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Private Sub SaveStationIncident(ByVal incidentID As Integer)

        Dim objStationIncident As IMSService.StationIncident
        Dim primaryStationID As Integer = 0
        If Not String.IsNullOrEmpty(cmbPrimaryStation.Value) Then
            primaryStationID = cmbPrimaryStation.Value
        End If

        Me.DeleteStationIncident(incidentID)

        'Insert optional stations (from check list)
        For Each objFireStation As IMSService.FireStation In chkFireStation.CheckedItems

            If primaryStationID <> objFireStation.StationID Then

                objStationIncident = New IMSService.StationIncident
                With objStationIncident
                    .IncidentID = incidentID
                    .StationID = objFireStation.StationID
                    .IsPrimaryStation = False
                End With
                objStationIncident.IsPrimaryStation = False
                _proxy.InsertStationIncident(objStationIncident)

            End If
        Next

        'Insert Primary station
        If primaryStationID > 0 Then

            objStationIncident = New IMSService.StationIncident

            With objStationIncident
                .IncidentID = incidentID
                .StationID = primaryStationID
                .IsPrimaryStation = True
            End With
            objStationIncident.IsPrimaryStation = True
            _proxy.InsertStationIncident(objStationIncident)

        End If
        
    End Sub

    ''' <summary>
    ''' Method to delete StationIncident.
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Private Sub DeleteStationIncident(ByVal incidentID As Integer)

        Dim strSQL = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IncidentID, incidentID)
        Dim lstStationIncident As List(Of IMSService.StationIncident) = _proxy.GetFilteredStationIncident(strSQL).Cast(Of IMSService.StationIncident).ToList()

        If Not IsNothing(lstStationIncident) Then

            For Each objStationIncident As IMSService.StationIncident In lstStationIncident
                _proxy.DeleteStationIncident(objStationIncident)
            Next

        End If

    End Sub

    ''' <summary>
    ''' Method to Save Incident.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveIncident() As Integer

        Dim objIncidentRegister As IMS.Win.IMSService.IncidentRegister = SetData()

        Return _proxy.InsertIncidentRegister(objIncidentRegister)

    End Function

    ''' <summary>
    ''' Method to Set data.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.IncidentRegister
        Dim objIncidentRegister As New IMS.Win.IMSService.IncidentRegister
        Dim currentTime As DateTime
        DateTime.TryParseExact(Date.Now.ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.AppConstants.DateFormatToQuery, CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)
        Dim callType As Integer = 0

        If rdoFullCall.Checked = True Then
            callType = CInt(IMSEnums.CallType.FullCall)
        Else
            callType = CInt(IMSEnums.CallType.PartialCall)
        End If

        With objIncidentRegister

            .CallerPhone = txtCallerNumber.Text.Trim()
            .CallerFullName = txtCallerName.Text.Trim()
            .CallType = callType
            .Address = txtAddress.Text.Trim()
            .Message = txtMessage.Text.Trim()
            .IsDeleted = CInt(IMSEnums.IsDeleted.No)
            .InsertionDate = currentTime
            .ModificationDate = currentTime
            .IncidentStatus = CInt(IMSEnums.IncidentStatus.Undispatched)

        End With

        Return objIncidentRegister

    End Function

    ''' <summary>
    ''' Method to set data by IncidentRegister.
    ''' </summary>
    ''' <param name="objIncidentRegister"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objIncidentRegister As IMS.Win.IMSService.IncidentRegister)
        Dim currentTime As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)


        With mIncidentRegister
            Dim callType As Integer = 0
            If rdoFullCall.Checked = True Then
                callType = CInt(IMSEnums.CallType.FullCall)
            Else
                callType = CInt(IMSEnums.CallType.PartialCall)
            End If

            .CallerPhone = txtCallerNumber.Text.Trim()
            .CallerFullName = txtCallerName.Text.Trim()
            .CallType = callType
            .Address = txtAddress.Text.Trim()
            .Message = txtMessage.Text.Trim()
            .IsDeleted = CInt(IMSEnums.IsDeleted.No)
            .ModificationDate = currentTime
            .Resolution = txtResolution.Text

        End With

    End Sub

    ''' <summary>
    ''' Method to clear all fields.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllFields()

            txtResolution.Text = String.Empty
        txtReferenceNo.Text = String.Empty
        txtCallerNumber.Text = String.Empty
        txtCallerName.Text = String.Empty
        txtAddress.Text = String.Empty
        txtMessage.Text = String.Empty
        IsUpdate = False

        For i = 0 To chklstIncidentCategory.Items.Count - 1
            Me.chklstIncidentCategory.SetItemCheckState(i, CheckState.Unchecked)
        Next
        For i = 0 To chkFireStation.Items.Count - 1
            Me.chkFireStation.SetItemCheckState(i, CheckState.Unchecked)
        Next

        chklstIncidentType.DataSource = Nothing

        cmbPrimaryStation.Text = String.Empty


    End Sub

    ''' <summary>
    ''' Method to check form data validate.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If txtCallerNumber.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeCallerNumber)
            txtCallerNumber.Focus()
            Return False
        End If

        If txtCallerName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeCallerName)
            txtCallerName.Focus()
            Return False
        End If

        If txtAddress.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeAddress)
            txtAddress.Focus()
            Return False
        End If

        If chklstIncidentCategory.CheckedItems.Count < 1 Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectIncidentCategory)
            chklstIncidentCategory.Focus()
            Return False
        End If

        If chklstIncidentType.CheckedItems.Count < 1 Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectIncidentType)
            chklstIncidentType.Focus()
            Return False
        End If

        If cmbPrimaryStation.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectPrimaryFireStation)
            cmbPrimaryStation.Focus()
            Return False
        End If

        'If chkFireStation.CheckedItems.Count < 1 Then
        '    DisplayInformation(IMSConstants.ErrorMessage.SelectStation)
        '    chkFireStation.Focus()
        '    Return False
        'End If

        Return True

    End Function

    ''' <summary>
    ''' Methode to view form data.
    ''' </summary>
    ''' <param name="objIncidentRegister"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objIncidentRegister As IMS.Win.IMSService.IncidentRegister)

        Dim strSQL As String = Nothing

        Dim lstStationIncident As New List(Of IMSService.StationIncident)
        Dim lstIncidentTypeIncident As New List(Of IMSService.IncidentTypeIncident)

        With objIncidentRegister

            If .CallType = CInt(IMSEnums.CallType.FullCall) Then
                rdoFullCall.Checked = True
            Else
                rdoPartialCall.Checked = True
            End If
            txtReferenceNo.Text = .ReferenceNo
            txtCallerNumber.Text = .CallerPhone
            txtCallerName.Text = .CallerFullName
            txtAddress.Text = .Address
            txtMessage.Text = .Message
            txtResolution.Text = .Resolution

            strSQL = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IncidentID, .IncidentID)
        End With

        lstIncidentTypeIncident = _proxy.GetFilteredIncidentTypeIncident(strSQL).Cast(Of IMSService.IncidentTypeIncident).ToList()
        lstStationIncident = _proxy.GetFilteredStationIncident(strSQL).Cast(Of IMSService.StationIncident).ToList()


        If lstIncidentTypeIncident.Count > 0 Then
            Me.LoadIncidentCatagoryByList(lstIncidentTypeIncident)
            Me.LoadIncidentTypeListByList(lstIncidentTypeIncident)
        End If

        If lstStationIncident.Count > 0 Then
            Me.LoadFireStationByList(lstStationIncident)
        End If

    End Sub

    ''' <summary>
    ''' Method to load incident catagory.
    ''' </summary>
    ''' <param name="lstIncidentTypeIncident"></param>
    ''' <remarks></remarks>
    Private Sub LoadIncidentCatagoryByList(ByVal lstIncidentTypeIncident As List(Of IMSService.IncidentTypeIncident))

        Dim lstIncidentType As New List(Of IMSService.IncidentType)
        Dim intLstCheckedCategory As New List(Of Integer)
        Dim lstIncidentCatagory As New List(Of IMSService.IncidentCategory)
        Dim strSQLa = Nothing
        Dim i As Integer = 0

        For Each obj As IMSService.IncidentTypeIncident In lstIncidentTypeIncident

            If i = 0 Then
                strSQLa = IMSConstants.FieldConstants.IncidentTypeID & "=" & obj.IncidentTypeID
            Else
                strSQLa = strSQLa + " or " + IMSConstants.FieldConstants.IncidentTypeID & "=" & obj.IncidentTypeID
            End If
            i = i + 1

        Next

        lstIncidentType = _proxy.GetFilteredIncidentType(strSQLa).Cast(Of IMSService.IncidentType).ToList()

        If lstIncidentType.Count > 0 Then

            For Each objIncidentType As IMSService.IncidentType In lstIncidentType

                Dim str As String = String.Format("{0}={1}", IMSConstants.FieldConstants.CategoryID, objIncidentType.CategoryID)
                Dim lst As List(Of IMSService.IncidentCategory) = _proxy.GetFilteredIncidentCategory(str).Cast(Of IMSService.IncidentCategory).ToList()

                lstIncidentCatagory.AddRange(lst)
            Next

        End If


        If lstIncidentCatagory.Count > 0 Then
            For Each incidentCategory As IMSService.IncidentCategory In lstIncidentCatagory
                intLstCheckedCategory.Add(incidentCategory.CategoryID)
            Next
        End If

        For i = 0 To chklstIncidentCategory.Items.Count - 1
            Dim kk As IMSService.IncidentCategory = chklstIncidentCategory.Items(i)
            If intLstCheckedCategory.Contains(kk.CategoryID) Then
                Me.chklstIncidentCategory.SetItemCheckState(i, CheckState.Checked)
            End If
        Next
    End Sub

    ''' <summary>
    ''' Method to Update Incident Register.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateIncidentRegister() As Integer

        Dim id As Integer = -1
        Me.SetData(mIncidentRegister)
        Dim objIncidentRegister As IMS.Win.IMSService.IncidentRegister = mIncidentRegister

        id = _proxy.UpdateIncidentRegister(objIncidentRegister)

        Return id

    End Function

    ''' <summary>
    ''' Methodto save Incident Register.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveIncidentRegister() As Integer

        Dim id As Integer = 0
        Dim objIncidentRegister As IMS.Win.IMSService.IncidentRegister = SetData()

        'Dim referenceNo As String = _proxy.UpdateReferenceNo.ToString() + "/" + Now.Year.ToString.Substring(2)
        'objIncidentRegister.ReferenceNo = referenceNo
        id = _proxy.InsertIncidentRegister(objIncidentRegister)
        Me.mIncidentRegister = _proxy.GetIncidentRegisterByID(id)
        Me.ViewFormData(mIncidentRegister)

        Return id

    End Function

    ''' <summary>
    ''' Method to load incidentType.
    ''' </summary>
    ''' <param name="lstIncidentTypeIncident"></param>
    ''' <remarks></remarks>
    Private Sub LoadIncidentTypeListByList(ByVal lstIncidentTypeIncident As List(Of IMSService.IncidentTypeIncident))
        Dim lstIncidentType As New List(Of IMSService.IncidentType)
        Dim intLstCheckedIncidentType As New List(Of Integer)

        For Each objIncidentCategory As IMSService.IncidentCategory In chklstIncidentCategory.CheckedItems

            Dim strSQL As String = IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & " and " & IMSConstants.FieldConstants.CategoryID & "=" & CType(objIncidentCategory.CategoryID, Integer) & " ORDER BY " & "IncidentTypeDescription ASC"
            Dim lstIncidentTypes As List(Of IMSService.IncidentType) = _proxy.GetFilteredIncidentType(strSQL).Cast(Of IMSService.IncidentType).ToList()

            lstIncidentType.AddRange(lstIncidentTypes)

        Next

        With chklstIncidentType
            .DataSource = lstIncidentType
            .ValueMember = IMSConstants.FieldConstants.chklstIncidentTypeVM
            .DisplayMember = IMSConstants.FieldConstants.chklstIncidentTypeDM
            .ClearSelected()

        End With

        If lstIncidentTypeIncident.Count > 0 Then
            For Each objIncidentTypeIncident As IMSService.IncidentTypeIncident In lstIncidentTypeIncident
                intLstCheckedIncidentType.Add(objIncidentTypeIncident.IncidentTypeID)
            Next
        End If

        For i = 0 To chklstIncidentType.Items.Count - 1
            Dim kk As IMSService.IncidentType = chklstIncidentType.Items(i)
            If intLstCheckedIncidentType.Contains(kk.IncidentTypeID) Then
                Me.chklstIncidentType.SetItemCheckState(i, CheckState.Checked)
            End If
        Next

    End Sub

    ''' <summary>
    ''' Method to load fire satation
    ''' </summary>
    ''' <param name="lstStationIncident"></param>
    ''' <remarks></remarks>
    Private Sub LoadFireStationByList(lstStationIncident As List(Of IMSService.StationIncident))

        Dim intLstCheckedStation As New List(Of Integer)
        Dim primaryStationID As Integer = 0

        If lstStationIncident.Count > 0 Then
            For Each objStationIncident As IMSService.StationIncident In lstStationIncident
                intLstCheckedStation.Add(objStationIncident.StationID)
                If objStationIncident.IsPrimaryStation Then
                    primaryStationID = objStationIncident.StationID
                End If
            Next
        End If

        For i = 0 To chkFireStation.Items.Count - 1
            Dim stationCheckBox As IMSService.FireStation = chkFireStation.Items(i)
            If intLstCheckedStation.Contains(stationCheckBox.StationID) Then
                If stationCheckBox.StationID <> primaryStationID Then
                    Me.chkFireStation.SetItemCheckState(i, CheckState.Checked)
                End If
            End If
        Next

        'Set Selected Primary station ID
        cmbPrimaryStation.Value = primaryStationID

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

    Private Sub UpdateIncident()
        Try
            mIncidentRegister.Resolution = txtResolution.Text
            mIncidentRegister.IncidentStatus = CInt(IMSEnums.IncidentStatus.Resolved)
            _proxy.UpdateIncidentRegister(mIncidentRegister)
            btnResolve.Enabled = False
            btnReopen.Visible = True
            btnReopen.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    ''' <summary>
    ''' Method to Load Fire station Combo.
    ''' </summary>
    ''' <param name="lstFireStation"></param>
    ''' <remarks></remarks>
    Private Sub LoadStationDropDown(ByVal lstFireStation As List(Of FireStation))

        Dim dtStation As New DataTable

        With dtStation.Columns
            .Add(IMSConstants.FieldConstants.StationID)
            .Add(IMSConstants.FieldConstants.StationName)
        End With

        For Each obj As IMSService.FireStation In lstFireStation
            Dim row As DataRow = dtStation.NewRow
            row(IMSConstants.FieldConstants.StationID) = obj.StationID
            row(IMSConstants.FieldConstants.StationName) = obj.StationName

            dtStation.Rows.Add(row)
        Next

        Dim rows As DataRow = dtStation.NewRow
        rows(IMSConstants.FieldConstants.StationID) = String.Empty
        rows(IMSConstants.FieldConstants.StationName) = String.Empty
        dtStation.Rows.InsertAt(rows, 0)

        With Me.cmbPrimaryStation
            .DataSource = dtStation
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to ReLoad the Incidnet Register
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EventToUpdateIncidentRegister()

        If CommonFunction.IsFormOpen("frmIncidentRegister") Then
            RaiseEvent LoadAddIncidentForm()
        End If

        If Me.IsWithoutEventFire Then
            Dim i As Int16
            Dim form As New frmIncidentRegister

            Try
                For i = 0 To frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs.Count - 1
                    If frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form.Name = "frmIncidentRegister" Then
                        form = frmMain.ultraTabbedMdiManager.TabGroups(0).Tabs(i).Form
                    End If
                Next

                form.LoadIncidentRegisterAfterEvent()
            Catch ex As Exception

            End Try
        End If

    End Sub

#End Region

#Region "Events"

    Public Event LoadAddIncidentForm()

#End Region

#Region "Event Handlers"

    Private Sub frmAddIncident_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            Me.LoadIncidentCategoryCheckBoxList()
            Me.LoadStationCheckBoxList()

            Me.ViewFormData(mIncidentRegister)
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
                intActionResult = Me.UpdateIncidentRegister()
            Else
                intActionResult = Me.SaveIncidentRegister()
            End If

            If intActionResult > 0 Then
                Me.SaveStationIncident(mIncidentRegister.IncidentID)
                Me.SaveIncidentTypeIncident(mIncidentRegister.IncidentID)
                Me.DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                Me.IsUpdate = True
                Me.txtCallerNumber.Focus()
            End If

            'TODO: event for Incident register form
            Me.EventToUpdateIncidentRegister()

            ''If Me.isFromIncidentRegister And CommonFunction.IsFormOpen("frmIncidentRegister") Then
            'If CommonFunction.IsFormOpen("frmIncidentRegister") Then
            '    RaiseEvent LoadAddIncidentForm()
            'End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Try
            ViewFormData(mIncidentRegister)

            'IsUpdate = False
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.EventToUpdateIncidentRegister()
        Me.Close()

    End Sub

    Private Sub btnResolve_Click(sender As Object, e As EventArgs) Handles btnResolve.Click
        Try

            If txtResolution.Text = String.Empty Then
                DisplayWarning(IMSConstants.ErrorMessage.TypeResolution)
                txtResolution.Focus()
                Exit Sub

            End If

            Dim frm As frmAddResolvedIncident = New frmAddResolvedIncident(mIncidentRegister.IncidentID)
            AddHandler frm.UpdateIncident, AddressOf UpdateIncident
            frm.ShowDialog()

            'TODO: event for Incident register form
            Me.EventToUpdateIncidentRegister()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub chklstIncidentCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles chklstIncidentCategory.SelectedIndexChanged
        Try
            Dim lstIncidentType As New List(Of IMSService.IncidentType)
            Dim checckitemCOunt As Integer = chklstIncidentCategory.CheckedItems.Count()
            For Each objIncidentCategory As IMSService.IncidentCategory In chklstIncidentCategory.CheckedItems

                Dim strSQL As String = IMSConstants.FieldConstants.CategoryID & "=" & CType(objIncidentCategory.CategoryID, Integer) & " and " & _
                    IMSConstants.FieldConstants.Status & " = " & CInt(IMSEnums.Status.Active) & _
                    " ORDER BY " & "IncidentTypeDescription ASC"

                Dim lstIncidentTypes As List(Of IMSService.IncidentType) = _proxy.GetFilteredIncidentType(strSQL).Cast(Of IMSService.IncidentType).ToList()

                lstIncidentType.AddRange(lstIncidentTypes)

            Next

            If lstIncidentTypeSelected.Count > 0 Then
                lstIncidentTypeSelected.Clear()
            End If

            For Each objIncidentType As IMSService.IncidentType In chklstIncidentType.CheckedItems
                lstIncidentTypeSelected.Add(objIncidentType.IncidentTypeID)
            Next

            With chklstIncidentType
                .DataSource = lstIncidentType
                .ValueMember = IMSConstants.FieldConstants.chklstIncidentTypeVM
                .DisplayMember = IMSConstants.FieldConstants.chklstIncidentTypeDM
                .ClearSelected()

            End With

            For i = 0 To chklstIncidentType.Items.Count - 1
                Me.chklstIncidentType.SetItemCheckState(i, CheckState.Unchecked)
            Next

            For i = 0 To chklstIncidentType.Items.Count - 1
                Dim kk As IMSService.IncidentType = chklstIncidentType.Items(i)
                If lstIncidentTypeSelected.Contains(kk.IncidentTypeID) Then
                    Me.chklstIncidentType.SetItemCheckState(i, CheckState.Checked)
                End If
            Next

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnAddNew_Click(sender As Object, e As EventArgs) Handles btnAddNew.Click

        Try
            If IsUpdate Then
                Me.btnSave.Text = "Save"
                Me.btnResolve.Enabled = False
            End If

            Me.LoadIncidentCategoryCheckBoxList()
            Me.LoadStationCheckBoxList()
            Me.ClearAllFields()
            Me.IsUpdate = False
            Me.txtCallerNumber.Focus()

            Me.rdoFullCall.Checked = True
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnReopen_Click(sender As Object, e As EventArgs) Handles btnReopen.Click
        Try

            mIncidentRegister.IncidentStatus = IMSEnums.IncidentStatus.Reopened
            If _proxy.UpdateIncidentRegister(mIncidentRegister) > 0 Then
                Me.DisplaySuccessfull(IMSConstants.SuccessMessageConstants.IncidentReopenedSuccessfully)
                Me.btnReopen.Enabled = False
                Me.btnResolve.Enabled = True

                'TODO: event for Incident register form
                Me.EventToUpdateIncidentRegister()

            Else
                Me.DisplayError(IMS.Lib.IMSConstants.ErrorMessage.ReopenFail)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

#End Region

End Class