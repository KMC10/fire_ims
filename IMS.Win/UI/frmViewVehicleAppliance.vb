'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 24-Apr-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmViewVehicleAppliance
    Inherits BaseForm

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 17
    Private lstAppliance As New List(Of IMSService.Appliance)

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to Load Form Data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()

        Dim tblAppliance As New DataTable
        Dim filter As String = String.Format("{0}='{1}' order by {2} asc", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No), IMSConstants.FieldConstants.ApplianceCode)

        tblAppliance.Columns.Add(IMS.Lib.IMSConstants.GridHeader.ApplianceID, GetType(Integer))
        tblAppliance.Columns.Add(IMS.Lib.IMSConstants.GridHeader.VehicleApplianceCode, GetType(String))
        tblAppliance.Columns.Add(IMS.Lib.IMSConstants.GridHeader.VehicleApplianceName, GetType(String))

        lstAppliance = _proxy.GetFilteredAppliance(filter).Cast(Of IMSService.Appliance).ToList()

        For Each obj As IMSService.Appliance In lstAppliance.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

            Dim row As DataRow = tblAppliance.NewRow

            row(IMS.Lib.IMSConstants.GridHeader.ApplianceID) = obj.ApplianceID
            row(IMS.Lib.IMSConstants.GridHeader.VehicleApplianceCode) = obj.ApplianceCode
            row(IMS.Lib.IMSConstants.GridHeader.VehicleApplianceName) = obj.ApplianceName

            tblAppliance.Rows.Add(row)
        Next

        With Me.grvVehicles
            .DataSource = tblAppliance
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Method to Delete vehicles.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteVehicle()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvVehicles.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objAppliance As IMS.Win.IMSService.Appliance = _proxy.GetApplianceByID(id)
            If Not IsNothing(objAppliance.ApplianceCode) Then
                objAppliance.IsDeleted = CInt(IMSEnum.IMSEnums.IsDeleted.Yes)
                deletedId = _proxy.UpdateAppliance(objAppliance)
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
    ''' Method to Load vehicles.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadVehicles()
        Me.LoadData()
        Me.EnableDisableButton()
    End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstAppliance.Count
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

    Private Sub frmViewVehicleAppliance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
            Dim frm As frmAddVehicle = New frmAddVehicle()
            AddHandler frm.LoadVehicles, AddressOf LoadVehicles
            frm.ShowDialog()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

        Try

            If grvVehicles.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvVehicles.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    Dim frm As frmAddVehicle = New frmAddVehicle(editId)
                    AddHandler frm.LoadVehicles, AddressOf LoadVehicles
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
            If grvVehicles.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    Me.DeleteVehicle()

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