'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 22-Apr-2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.


Imports IMS.Lib
Imports IMS.Win.IMSService

Public Class frmAddIncidentCategory
    Inherits BaseForm


#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mIncidentCategory As New IMSService.IncidentCategory
    Private _proxy As New IMSService.IMSServices

#End Region


#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(IncidentCategoryId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.IsUpdate = True
        Me.mIncidentCategory = _proxy.GetIncidentCategoryByID(IncidentCategoryId)
        Me.Text = "Update Incident Category"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Event"

    Public Event LoadIncidentCategory()

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load form Data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        txtIncidentCategory.Text = mIncidentCategory.CategoryName
    End Sub

    ''' <summary>
    ''' Method to check field validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If txtIncidentCategory.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeIncidentCategory)
            txtIncidentCategory.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mIncidentCategory.CategoryName = (txtIncidentCategory.Text.Trim()) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtIncidentCategory.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateIncidentCategory)
            Me.txtIncidentCategory.Focus()
            Return False
        End If


        Return True

    End Function

    ''' <summary>
    ''' Method to Sava IncidentCategory
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveIncidentCategory() As Integer

        Dim objIncidentCategory As New IMS.Win.IMSService.IncidentCategory
        objIncidentCategory.CategoryName = txtIncidentCategory.Text.Trim()
        objIncidentCategory.Status = CInt(IMSEnum.IMSEnums.Status.Active)

        Dim id As Integer = _proxy.InsertIncidentCategory(objIncidentCategory)
        Return id

    End Function

    ''' <summary>
    ''' Method to Update IncidentCategory
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateIncidentCategory() As Integer

        Dim objIncidentCategory As IMS.Win.IMSService.IncidentCategory = mIncidentCategory
        objIncidentCategory.CategoryName = txtIncidentCategory.Text.Trim()

        Dim id As Integer = _proxy.UpdateIncidentCategory(objIncidentCategory)
        Return id

    End Function

    ''' <summary>
    ''' Method to check duplicate.
    ''' </summary>
    ''' <param name="IncidentCatagoryName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal IncidentCatagoryName As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.CategoryName, IncidentCatagoryName, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Active))
        Dim lstIncidentCatagor As List(Of IMS.Win.IMSService.IncidentCategory) = _proxy.GetFilteredIncidentCategory(filter).Cast(Of IMS.Win.IMSService.IncidentCategory).ToList

        If lstIncidentCatagor.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' method for reset all controll.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetallControll()
        Me.txtIncidentCategory.Text = String.Empty
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

    Private Sub frmAddIncidentCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            MyBase.SetSecurity(Me)
            Me.LoadData()

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
                intActionResult = Me.UpdateIncidentCategory()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadIncidentCategory()
                    Me.Close()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)

                End If
            Else
                intActionResult = Me.SaveIncidentCategory()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadIncidentCategory()
                    ResetallControll()

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
            txtIncidentCategory.Text = mIncidentCategory.CategoryName
            'IsUpdate = False
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