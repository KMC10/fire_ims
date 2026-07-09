Imports IMS.Lib

Public Class frmViewIncidentCategory
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 17
    Private lstIncidentCategory As New List(Of IMSService.IncidentCategory)

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
    ''' Method to Load Form Data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()
        Dim tblIncidentCategory As New DataTable
        Dim filter As String = String.Format("{0}='{1}' order by {2} asc", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.CategoryName)

        tblIncidentCategory.Columns.Add(IMS.Lib.IMSConstants.GridHeader.IncidentCategoryID, GetType(String))
        tblIncidentCategory.Columns.Add(IMS.Lib.IMSConstants.GridHeader.IncidentCategory, GetType(String))

        lstIncidentCategory = _proxy.GetFilteredIncidentCategory(filter).Cast(Of IMSService.IncidentCategory).ToList()

        For Each obj As IMSService.IncidentCategory In lstIncidentCategory.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

            Dim row As DataRow = tblIncidentCategory.NewRow

            row(IMS.Lib.IMSConstants.GridHeader.IncidentCategoryID) = obj.CategoryID
            row(IMS.Lib.IMSConstants.GridHeader.IncidentCategory) = obj.CategoryName

            tblIncidentCategory.Rows.Add(row)
        Next

        With Me.grvIncidedentCategory
            .DataSource = tblIncidentCategory
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Method to Delete Incidedent Category
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteIncidedentCategory()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvIncidedentCategory.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objIncidedentCategory As IMS.Win.IMSService.IncidentCategory = _proxy.GetIncidentCategoryByID(id)
            If Not IsNothing(objIncidedentCategory) Then
                objIncidedentCategory.Status = CInt(IMSEnums.Status.Deleted)
                deletedId = _proxy.UpdateIncidentCategory(objIncidedentCategory)
            End If
            If deletedId > -1 Then
                Me.DisplayInformation(IMSConstants.Messages.DeleteSuccessfull)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstIncidentCategory.Count
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

#Region "Event Handlers"

    Private Sub frmViewIncidentCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            Me.pageIndex = 0
            Me.LoadData()
            Me.EnableDisableButton()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click

        Try

            Dim frm As frmAddIncidentCategory = New frmAddIncidentCategory()
            AddHandler frm.LoadIncidentCategory, AddressOf LoadIncidentCategory
            frm.ShowDialog()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub LoadIncidentCategory()
        Me.LoadData()
        Me.EnableDisableButton()
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Try

            If grvIncidedentCategory.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvIncidedentCategory.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    Dim frm As frmAddIncidentCategory = New frmAddIncidentCategory(editId)
                    AddHandler frm.LoadIncidentCategory, AddressOf LoadIncidentCategory
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
            If grvIncidedentCategory.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    Me.DeleteIncidedentCategory()

                End If

                Me.LoadData()
                Me.EnableDisableButton()

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