'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 25-Apr-2014
'Last Modified by      : Md.ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmViewIncidentType
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 17
    Private lstIncidentType As New List(Of IMSService.IncidentType)

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
    ''' Method to Load form data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()

        Dim tblIncidentType As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active))

        tblIncidentType.Columns.Add(IMS.Lib.IMSConstants.FieldConstants.IncidentTypeID, GetType(Integer))
        tblIncidentType.Columns.Add(IMS.Lib.IMSConstants.GridHeader.IncidentCategory, GetType(String))
        tblIncidentType.Columns.Add(IMS.Lib.IMSConstants.GridHeader.IncidentTypeCode, GetType(String))
        tblIncidentType.Columns.Add(IMS.Lib.IMSConstants.GridHeader.IncidentType, GetType(String))

        lstIncidentType = _proxy.GetFilteredIncidentType(filter).Cast(Of IMSService.IncidentType).ToList()

        For Each obj As IMSService.IncidentType In lstIncidentType.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

            Dim row As DataRow = tblIncidentType.NewRow

            row(IMS.Lib.IMSConstants.FieldConstants.IncidentTypeID) = obj.IncidentTypeID
            row(IMS.Lib.IMSConstants.GridHeader.IncidentCategory) = _proxy.GetIncidentCategoryByID(obj.CategoryID).CategoryName
            row(IMS.Lib.IMSConstants.GridHeader.IncidentTypeCode) = obj.IncidentTypeCode
            row(IMS.Lib.IMSConstants.GridHeader.IncidentType) = obj.IncidentTypeDescription

            tblIncidentType.Rows.Add(row)
        Next

        Dim dv As DataView = New DataView(tblIncidentType)
        dv.Sort = IMS.Lib.IMSConstants.GridHeader.IncidentCategory & " asc"
        tblIncidentType = dv.ToTable()

        With Me.grvIncidentType
            .DataSource = tblIncidentType
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Method to delete Incident Type.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteIncidentType()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvIncidentType.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objIncidentType As IMS.Win.IMSService.IncidentType = _proxy.GetIncidentTypeByID(id)
            If Not IsNothing(objIncidentType) Then
                objIncidentType.Status = CInt(IMSEnums.Status.Deleted)
                deletedId = _proxy.UpdateIncidentType(objIncidentType)
            End If
            If deletedId > -1 Then
                Me.DisplaySuccessfull(IMSConstants.SuccessMessageConstants.RecordDeletedSuccessfully)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method toLoad vehicles.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadVehicles()
        Me.LoadData()
        Me.EnableDisableButton()
    End Sub

    ''' <summary>
    ''' Method to load Incident type.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadIncidentType()
        Me.LoadData()
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

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstIncidentType.Count
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

#End Region

#Region "Event Handlers"

    Private Sub frmViewIncidentType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            pageIndex = 0
            Me.LoadData()
            Me.EnableDisableButton()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Try

            Dim frm As frmAddIncidentType = New frmAddIncidentType()
            AddHandler frm.LoadIncidentType, AddressOf LoadIncidentType
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try

            If grvIncidentType.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvIncidentType.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    Dim frm As frmAddIncidentType = New frmAddIncidentType(editId)
                    AddHandler frm.LoadIncidentType, AddressOf LoadIncidentType
                    frm.ShowDialog()
                End If

            Else
                DisplayWarning(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

        Try
            If grvIncidentType.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    DeleteIncidentType()
                    Me.LoadData()
                    Me.EnableDisableButton()

                End If
            Else
                DisplayWarning(IMSConstants.Messages.SelectARecord)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try


    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Try
            Me.LoadData()
            Me.EnableDisableButton()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
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

#End Region

End Class