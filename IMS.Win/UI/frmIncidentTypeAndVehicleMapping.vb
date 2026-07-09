'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 27-Apr-2014
'Last Modified by      : Md.ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmIncidentTypeAndVehicleMapping
    Inherits BaseForm

#Region "Member Variables"
    Private _proxy As New IMSService.IMSServices
    Private IsUpdate As Boolean = False
    Private mApplianceMapping As New IMSService.ApplianceMapping
    Private pageIndex As Integer = 0
    Private listSize As Integer = 10
    Private lstApplianceMapping As New List(Of IMSService.ApplianceMapping)

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load IncidentCategory
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
            ' .Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to load IncidentType by catagoryID
    ''' </summary>
    ''' <param name="strCategotyID"></param>
    ''' <remarks></remarks>
    Private Sub LoadIncidentType(ByVal strCategotyID As String)

        Dim categoryID As Integer = 0
        If Not String.IsNullOrEmpty(strCategotyID) Then
            categoryID = CInt(strCategotyID)
        End If

        Dim tblIncidentType As New DataTable
        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.CategoryID, categoryID)

        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.IncidentTypeID)
        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.IncidentTypeDescription)

        For Each obj As IMSService.IncidentType In _proxy.GetFilteredIncidentType(filter)
            Dim rows As DataRow = tblIncidentType.NewRow
            rows(IMSConstants.FieldConstants.IncidentTypeID) = obj.IncidentTypeID
            rows(IMSConstants.FieldConstants.IncidentTypeDescription) = obj.IncidentTypeDescription
            tblIncidentType.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblIncidentType)
        dView.Sort = "IncidentTypeDescription ASC"

        Dim sortedTable As DataTable = dView.ToTable()

        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.IncidentTypeID) = String.Empty
        row(IMSConstants.FieldConstants.IncidentTypeDescription) = String.Empty
        sortedTable.Rows.InsertAt(row, 0)


        With Me.cmbIncidentType
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.IncidentTypeID
            .DisplayMember = IMSConstants.FieldConstants.IncidentTypeDescription
            .DataBind()
            ' .Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to load applience.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadAppliance()

        Dim tblAppliance As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No))

        tblAppliance.Columns.Add(IMSConstants.FieldConstants.ApplianceID)
        tblAppliance.Columns.Add(IMSConstants.FieldConstants.ApplianceName)

        For Each obj As IMSService.Appliance In _proxy.GetFilteredAppliance(filter)
            Dim rows As DataRow = tblAppliance.NewRow
            rows(IMSConstants.FieldConstants.ApplianceID) = obj.ApplianceID
            rows(IMSConstants.FieldConstants.ApplianceName) = obj.ApplianceName
            tblAppliance.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblAppliance)
        dView.Sort = "ApplianceName ASC"

        Dim sortedTable As DataTable = dView.ToTable()

        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.ApplianceID) = String.Empty
        row(IMSConstants.FieldConstants.ApplianceName) = String.Empty
        sortedTable.Rows.InsertAt(row, 0)


        With Me.cmbVehicleName
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.ApplianceID
            .DisplayMember = IMSConstants.FieldConstants.ApplianceName
            .DataBind()
            '.Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to Set ApplianceMapping .
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.ApplianceMapping

        Dim objApplianceMapping As New IMS.Win.IMSService.ApplianceMapping

        With objApplianceMapping
            .CategoryID = cmbIncidentCategory.Value
            .IncidentTypeID = cmbIncidentType.Value
            .ApplianceID = cmbVehicleName.Value
            .Quantity = CInt(txtQuantity.Text.Trim())
            .Status = CInt(IMSEnums.Status.Active)
        End With

        Return objApplianceMapping

    End Function

    ''' <summary>
    ''' Method to Set ApplianceMapping by object .
    ''' </summary>
    ''' <param name="objFireStationAppliance"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objFireStationAppliance As IMS.Win.IMSService.ApplianceMapping)


        With mApplianceMapping

            .CategoryID = cmbIncidentCategory.Value
            .IncidentTypeID = cmbIncidentType.Value
            .ApplianceID = cmbVehicleName.Value
            .Quantity = CInt(txtQuantity.Value)

        End With

    End Sub

    ''' <summary>
    ''' Method clear all fields.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllFields()

        Me.mApplianceMapping = New IMSService.ApplianceMapping
        cmbIncidentCategory.Text = String.Empty
        cmbIncidentType.Text = String.Empty
        cmbVehicleName.Text = String.Empty
        txtQuantity.Value = 0
        btnAdd.Text = "Add"
        IsUpdate = False

    End Sub

    ''' <summary>
    ''' Method to check validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If cmbIncidentCategory.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectIncidentCategory)
            cmbIncidentCategory.Focus()
            Return False
        End If

        If cmbIncidentType.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectIncidentType)
            cmbIncidentType.Focus()
            Return False
        End If

        If cmbVehicleName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectVehicleName)
            cmbVehicleName.Focus()
            Return False
        End If

        If txtQuantity.Value <= 0 Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeQuantity)
            txtQuantity.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mApplianceMapping.IncidentTypeID = (cmbIncidentType.Value) And mApplianceMapping.ApplianceID = (cmbVehicleName.Value) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(cmbIncidentType.Value, cmbVehicleName.Value) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateMapping)
            Me.cmbIncidentType.Focus()

            Me.LoadDuplicate(cmbIncidentType.Value, cmbVehicleName.Value)

            Return False
        End If

        Return True

    End Function

    ''' <summary>
    ''' Method to check duplicate.
    ''' </summary>
    ''' <param name="incidentTypeID"></param>
    ''' <param name="applienceID"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal incidentTypeID As Integer, ByVal applienceID As Integer) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'", IMSConstants.FieldConstants.IncidentTypeID, incidentTypeID, IMSConstants.FieldConstants.ApplianceID, applienceID, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Active))
        Dim lstApplianceMapping As List(Of IMS.Win.IMSService.ApplianceMapping) = _proxy.GetFilteredApplianceMapping(filter).Cast(Of IMS.Win.IMSService.ApplianceMapping).ToList

        If lstApplianceMapping.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to view form data.
    ''' </summary>
    ''' <param name="objApplianceMapping"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objApplianceMapping As IMS.Win.IMSService.ApplianceMapping)

        With objApplianceMapping

            cmbIncidentCategory.Value = .CategoryID
            cmbIncidentType.Value = .IncidentTypeID
            cmbVehicleName.Value = .ApplianceID
            txtQuantity.Value = .Quantity

            If .CategoryID = 0 Then
                cmbIncidentCategory.Value = String.Empty
            End If
            If .IncidentTypeID = 0 Then
                cmbIncidentType.Value = String.Empty
            End If

            If .ApplianceID = 0 Then
                cmbVehicleName.Value = String.Empty
            End If
        End With

    End Sub

    ''' <summary>
    ''' Method to Update ApplianceMapping .
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateApplianceMapping() As Integer

        Dim id As Integer = -1
        Me.SetData(mApplianceMapping)
        Dim objApplianceMapping As IMS.Win.IMSService.ApplianceMapping = mApplianceMapping

        id = _proxy.UpdateApplianceMapping(objApplianceMapping)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save ApplianceMapping .
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveApplianceMapping() As Integer

        Dim id As Integer = -1
        Dim objApplianceMapping As IMS.Win.IMSService.ApplianceMapping = SetData()

        id = _proxy.InsertApplianceMapping(objApplianceMapping)

        Return id

    End Function

    ''' <summary>
    ''' Method to load form data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()

        Dim tblAppliance As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active))

        tblAppliance.Columns.Add(IMSConstants.FieldConstants.MappingID, GetType(Integer))
        tblAppliance.Columns.Add(IMSConstants.GridHeader.IncidentCategory, GetType(String))
        tblAppliance.Columns.Add(IMSConstants.GridHeader.IncidentType, GetType(String))
        tblAppliance.Columns.Add(IMSConstants.GridHeader.VehicleName, GetType(String))
        tblAppliance.Columns.Add(IMSConstants.GridHeader.Code, GetType(String))
        tblAppliance.Columns.Add(IMSConstants.GridHeader.Quantity, GetType(String))

        lstApplianceMapping = _proxy.GetFilteredApplianceMapping(filter).Cast(Of IMSService.ApplianceMapping).ToList()

        For Each obj As IMSService.ApplianceMapping In lstApplianceMapping.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

            Dim row As DataRow = tblAppliance.NewRow

            Dim incidentCategory As String = String.Empty
            Dim incidentType As String = String.Empty
            Dim applience As String = String.Empty
            Dim code As String = String.Empty

            Dim objIncidentCategory As IMSService.IncidentCategory = _proxy.GetIncidentCategoryByID(obj.CategoryID)
            Dim objIncidentType As IMSService.IncidentType = _proxy.GetIncidentTypeByID(obj.IncidentTypeID)
            Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(obj.ApplianceID)

            If Not IsNothing(objIncidentCategory) Then
                incidentCategory = objIncidentCategory.CategoryName
            End If

            If Not IsNothing(objIncidentType) Then
                incidentType = objIncidentType.IncidentTypeDescription
            End If

            If Not IsNothing(objApplience) Then
                applience = objApplience.ApplianceName
                code = objApplience.ApplianceCode
            End If

            row(IMSConstants.FieldConstants.MappingID) = obj.MappingID
            row(IMSConstants.GridHeader.IncidentCategory) = incidentCategory
            row(IMSConstants.GridHeader.IncidentType) = incidentType
            row(IMSConstants.GridHeader.VehicleName) = applience
            row(IMSConstants.GridHeader.Code) = code
            row(IMSConstants.GridHeader.Quantity) = obj.Quantity

            tblAppliance.Rows.Add(row)
        Next

        Dim dv As DataView = New DataView(tblAppliance)
        dv.Sort = IMS.Lib.IMSConstants.GridHeader.IncidentCategory & " asc"
        tblAppliance = dv.ToTable()

        With Me.grvApplioenceMapping
            .DataSource = tblAppliance
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Methode Delete Appliance Mapping.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteApplianceMapping()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvApplioenceMapping.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objApplianceMapping As IMS.Win.IMSService.ApplianceMapping = _proxy.GetApplianceMappingByID(id)
            If Not IsNothing(objApplianceMapping) Then
                objApplianceMapping.Status = CInt(IMSEnums.Status.Deleted)
                deletedId = _proxy.UpdateApplianceMapping(objApplianceMapping)
            End If
            If deletedId > -1 Then
                Me.DisplayInformation(IMSConstants.Messages.DeleteSuccessfull)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
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
    ''' Method to Load Specific Mapping by id
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub LoadSpecificMapping(id As Integer)

        mApplianceMapping = _proxy.GetApplianceMappingByID(id)
        btnAdd.Text = "Update"
        IsUpdate = True
        Me.ViewFormData(mApplianceMapping)

    End Sub

    ''' <summary>
    ''' Method to Load Duplicate Mapping 
    ''' </summary>
    ''' <param name="incidentTypeID"></param>
    ''' <param name="applienceID"></param>
    ''' <remarks></remarks>
    Private Sub LoadDuplicate(ByVal incidentTypeID As Integer, ByVal applienceID As Integer)

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}' AND {4}='{5}'", IMSConstants.FieldConstants.IncidentTypeID, incidentTypeID, IMSConstants.FieldConstants.ApplianceID, applienceID, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Active))
        Dim lstApplianceMapping As List(Of IMS.Win.IMSService.ApplianceMapping) = _proxy.GetFilteredApplianceMapping(filter).Cast(Of IMS.Win.IMSService.ApplianceMapping).ToList

        If lstApplianceMapping.Count > 0 Then
            Me.LoadSpecificMapping(lstApplianceMapping(0).MappingID)
        End If

    End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstApplianceMapping.Count
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

    Private Sub frmIncidentTypeAndVehicleMapping_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            Me.LoadIncidentCategory()
            ' Me.LoadIncidentType()
            Me.LoadAppliance()
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
            Dim intActionResult As Integer = 0

            If IsValidate() = False Then Exit Sub

            If IsUpdate = True Then
                intActionResult = Me.UpdateApplianceMapping()
            Else
                intActionResult = Me.SaveApplianceMapping()
            End If

            If intActionResult > 0 Then

                DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                Me.ClearAllFields()

            End If
            Me.LoadData()
            Me.EnableDisableButton()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If grvApplioenceMapping.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    Me.DeleteApplianceMapping()
                    Me.ClearAllFields()
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
            Me.ClearAllFields()
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

    Private Sub cmbIncidentCategory_ValueChanged(sender As Object, e As EventArgs) Handles cmbIncidentCategory.ValueChanged

        Try
            LoadIncidentType(cmbIncidentCategory.Value)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub cmbVehicleName_SelectionChanged(sender As Object, e As EventArgs) Handles cmbVehicleName.SelectionChanged
        Try
            Dim vehicleCode As String = String.Empty
            Dim objAlpplience As New IMSService.Appliance
            Dim applianceID As Integer = 0

            If Not String.IsNullOrEmpty(cmbVehicleName.Value) And cmbVehicleName.Value <> "-1" Then
                applianceID = CInt(cmbVehicleName.Value)
                objAlpplience = _proxy.GetApplianceByID(applianceID)

                If Not IsNothing(objAlpplience) Then
                    vehicleCode = objAlpplience.ApplianceCode
                End If

            End If

            txtCode.Text = vehicleCode

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub grvApplioenceMapping_ClickCell(sender As Object, e As Infragistics.Win.UltraWinGrid.ClickCellEventArgs) Handles grvApplioenceMapping.ClickCell
        Try
            Dim id As Integer = CInt(grvApplioenceMapping.Selected.Rows(0).Cells(0).Value.ToString())

            Me.LoadSpecificMapping(id)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try

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