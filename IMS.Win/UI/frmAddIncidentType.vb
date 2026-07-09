'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 25-Apr-2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization


Public Class frmAddIncidentType
    Inherits BaseForm

#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mIncidentType As New IMSService.IncidentType
    Private _proxy As New IMSService.IMSServices

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal IncidentTypeID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mIncidentType = _proxy.GetIncidentTypeByID(IncidentTypeID)
        Me.Text = "Update Incident Type"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to Load Incident Catagory.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadIncidentCategory()

        Dim tblIncidentCategory As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active))

        tblIncidentCategory.Columns.Add(IMSConstants.FieldConstants.CategoryID)
        tblIncidentCategory.Columns.Add(IMSConstants.FieldConstants.CategoryName)

        For Each obj As IMSService.IncidentCategory In _proxy.GetFilteredIncidentCategory(filter)
            Dim rows As DataRow = tblIncidentCategory.NewRow
            rows(IMSConstants.FieldConstants.CategoryID) = obj.CategoryID
            rows(IMSConstants.FieldConstants.CategoryName) = obj.CategoryName
            tblIncidentCategory.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblIncidentCategory)
        dView.Sort = "CategoryName ASC"

        Dim sortedTable As DataTable = dView.ToTable()

        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.CategoryID) = String.Empty
        row(IMSConstants.FieldConstants.CategoryName) = String.Empty
        sortedTable.Rows.InsertAt(row, 0)


        With Me.cmbIncidentCategory
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.CategoryID
            .DisplayMember = IMSConstants.FieldConstants.CategoryName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to set data in IncidentType object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.IncidentType
        Dim objIncidentType As New IMS.Win.IMSService.IncidentType

        With objIncidentType
            .CategoryID = cmbIncidentCategory.Value
            .IncidentTypeCode = txtIncidentTypeCode.Text.Trim()
            .IncidentTypeDescription = txtIncidentType.Text.Trim()
            .Status = CInt(IMSEnums.Status.Active)
        End With

        Return objIncidentType

    End Function

    ''' <summary>
    ''' Method to set data in IncidentType object by object.
    ''' </summary>
    ''' <param name="objIncidentType"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objIncidentType As IMS.Win.IMSService.IncidentType)

        With objIncidentType
            .CategoryID = cmbIncidentCategory.Value
            .IncidentTypeCode = txtIncidentTypeCode.Text.Trim()
            .IncidentTypeDescription = txtIncidentType.Text.Trim()

        End With

    End Sub

    ''' <summary>
    ''' Method to clear all field.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllFields()

        cmbIncidentCategory.Text = String.Empty
        txtIncidentTypeCode.Text = String.Empty
        txtIncidentType.Text = String.Empty
        IsUpdate = False

    End Sub

    ''' <summary>
    ''' Method to check from validation
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True
        Dim chkDuplicateTypeDescription As Boolean = True

        If cmbIncidentCategory.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectIncidentCategory)
            cmbIncidentCategory.Focus()
            Return False
        End If

        If txtIncidentTypeCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeIncidentTypeCode)
            txtIncidentTypeCode.Focus()
            Return False
        End If

        If txtIncidentType.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeIncidentType)
            txtIncidentType.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mIncidentType.IncidentTypeCode = (txtIncidentTypeCode.Text.Trim()) Then
                chkDuplicate = False
            End If

            If mIncidentType.IncidentTypeDescription = (txtIncidentType.Text.Trim()) Then
                chkDuplicateTypeDescription = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtIncidentTypeCode.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateIncidentTypeCode)
            Me.txtIncidentTypeCode.Focus()
            Return False
        End If

        If chkDuplicateTypeDescription = True AndAlso IsDuplicateTypeDescription(txtIncidentType.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateIncidentType)
            Me.txtIncidentType.Focus()
            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' method to Check duplicate (Incident Type Code).
    ''' </summary>
    ''' <param name="IncidentTypeCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal IncidentTypeCode As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.IncidentTypeCode, IncidentTypeCode, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Active))
        Dim lstIncidentType As List(Of IMS.Win.IMSService.IncidentType) = _proxy.GetFilteredIncidentType(filter).Cast(Of IMS.Win.IMSService.IncidentType).ToList

        If lstIncidentType.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    '''  method to Check duplicate (Incident Type Description).
    ''' </summary>
    ''' <param name="IncidentTypeDescription"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicateTypeDescription(ByVal IncidentTypeDescription As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.IncidentTypeDescription, IncidentTypeDescription, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Active))
        Dim lstIncidentType As List(Of IMS.Win.IMSService.IncidentType) = _proxy.GetFilteredIncidentType(filter).Cast(Of IMS.Win.IMSService.IncidentType).ToList

        If lstIncidentType.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to view form data.
    ''' </summary>
    ''' <param name="objIncidentType"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objIncidentType As IMS.Win.IMSService.IncidentType)

        With objIncidentType
            cmbIncidentCategory.Value = .CategoryID
            txtIncidentTypeCode.Text = .IncidentTypeCode
            txtIncidentType.Text = .IncidentTypeDescription
            If .CategoryID = 0 Then
                cmbIncidentCategory.Text = String.Empty
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to update IncidentType.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateIncidentType() As Integer

        Dim id As Integer = -1
        Me.SetData(mIncidentType)
        Dim objIncidentType As IMS.Win.IMSService.IncidentType = mIncidentType

        id = _proxy.UpdateIncidentType(objIncidentType)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save IncidentType.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveIncidentType() As Integer

        Dim id As Integer = -1
        Dim objIncidentType As IMS.Win.IMSService.IncidentType = SetData()

        id = _proxy.InsertIncidentType(objIncidentType)

        Return id

    End Function

    ''' <summary>
    ''' method for reset all controll.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetallCrontroll()
        Me.cmbIncidentCategory.Text = String.Empty
        Me.txtIncidentType.Text = String.Empty
        Me.txtIncidentTypeCode.Text = String.Empty
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

#Region "Event"

    Public Event LoadIncidentType()

#End Region

#Region "Event Handlers"

    Private Sub frmAddIncidentType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)

            Me.LoadIncidentCategory()
            Me.ViewFormData(mIncidentType)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Dim intActionResult As Integer = 0

            If Me.IsValidate = False Then Exit Sub

            If Me.IsUpdate = True Then
                intActionResult = Me.UpdateIncidentType()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadIncidentType()
                    Me.Close()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)
                End If
            Else
                intActionResult = Me.SaveIncidentType()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadIncidentType()
                    ResetallCrontroll()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)
                End If
            End If

            
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Try
            ViewFormData(mIncidentType)
            If IsNothing(mIncidentType.IncidentTypeDescription) Then
                Me.cmbIncidentCategory.Value = -1
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

End Class