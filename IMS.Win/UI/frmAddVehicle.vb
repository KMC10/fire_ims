Imports IMS.Lib
Imports System.Globalization


Public Class frmAddVehicle
    Inherits BaseForm

#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mAppliance As New IMS.Win.IMSService.Appliance
    Private _proxy As New IMSService.IMSServices

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ApplianceID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mAppliance = _proxy.GetApplianceByID(ApplianceID)

        Me.Text = "Update Vehicle"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to save Applience.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveAppliance() As Integer

        Dim objAppliance As IMS.Win.IMSService.Appliance = SetData()

        Return _proxy.InsertAppliance(objAppliance)

    End Function

    ''' <summary>
    ''' Methodto set applience object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.Appliance
        Dim objAppliance As New IMS.Win.IMSService.Appliance
        Dim convertedSTartDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, convertedSTartDate)

        With objAppliance
            .ApplianceCode = txtVehicleCode.Text.Trim()
            .ApplianceName = txtVehicleName.Text.Trim()
            .ApplianceDescription = txtVehicleDescription.Text.Trim()
            .InsertionDate = convertedSTartDate
            .ModificationDate = convertedSTartDate
        End With
        Return objAppliance

    End Function

    ''' <summary>
    ''' Method to Set Applience Object By object.
    ''' </summary>
    ''' <param name="objAppliance"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objAppliance As IMS.Win.IMSService.Appliance)

        Dim convertedSTartDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, convertedSTartDate)

        With objAppliance
            .ApplianceCode = txtVehicleCode.Text.Trim()
            .ApplianceName = txtVehicleName.Text.Trim()
            .ApplianceDescription = txtVehicleDescription.Text.Trim()
            .ModificationDate = convertedSTartDate
        End With

    End Sub

    ''' <summary>
    ''' Method to clear from Field.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllFields()

        txtVehicleCode.Text = String.Empty
        txtVehicleName.Text = String.Empty
        txtVehicleDescription.Text = String.Empty
        IsUpdate = False

    End Sub

    ''' <summary>
    ''' Method to Check form validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If txtVehicleCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeVehicleCode)
            txtVehicleCode.Focus()
            Return False
        End If

        If txtVehicleName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeVehicleName)
            txtVehicleName.Focus()
            Return False
        End If

        If txtVehicleDescription.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeVehicleDescription)
            txtVehicleDescription.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mAppliance.ApplianceCode = (txtVehicleCode.Text.Trim()) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtVehicleCode.Text) = True Then
            Me.DisplayInformation(IMSConstants.ErrorMessage.VehicleCodeAlreadyUsed)
            Me.txtVehicleCode.Focus()
            Return False
        End If


        Return True

    End Function

    ''' <summary>
    ''' Method to Check Applience Duplicate.
    ''' </summary>
    ''' <param name="VehicleCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal VehicleCode As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.ApplianceCode, VehicleCode, IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No))
        Dim lstloanType As List(Of IMS.Win.IMSService.Appliance) = _proxy.GetFilteredAppliance(filter).Cast(Of IMS.Win.IMSService.Appliance).ToList

        If lstloanType.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to View form data.
    ''' </summary>
    ''' <param name="objVehicle"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objVehicle As IMS.Win.IMSService.Appliance)

        With objVehicle
            txtVehicleCode.Text = .ApplianceCode
            txtVehicleName.Text = .ApplianceName
            txtVehicleDescription.Text = .ApplianceDescription
        End With

    End Sub

    ''' <summary>
    ''' Method to Update Applience.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateVehicle() As Integer

        Dim id As Integer = -1
        Me.SetData(mAppliance)
        Dim objVehicle As IMS.Win.IMSService.Appliance = mAppliance

        id = _proxy.UpdateAppliance(objVehicle)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save vehicles.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveVehicle() As Integer

        Dim id As Integer = -1
        Dim objVehicle As IMS.Win.IMSService.Appliance = SetData()
        objVehicle.IsDeleted = CInt(IMSEnum.IMSEnums.IsDeleted.No)

        id = _proxy.InsertAppliance(objVehicle)

        Return id

    End Function

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

    Private Sub ResetallControll()

        Me.txtVehicleCode.Text = String.Empty
        Me.txtVehicleName.Text = String.Empty
        Me.txtVehicleDescription.Text = String.Empty
    End Sub


#End Region

#Region "Event"

    Public Event LoadVehicles()

#End Region

#Region "Event Handlers"

    Private Sub frmAddVehicle_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            Me.ViewFormData(mAppliance)
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
                intActionResult = Me.UpdateVehicle()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadVehicles()
                    Me.Close()
                Else
                    Me.DisplayError(IMSConstants.ErrorMessage.RecordInsertionFailed)
                End If
            Else
                intActionResult = Me.SaveVehicle()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadVehicles()
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
            ClearAllFields()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click

        Me.Close()

    End Sub

#End Region

   
End Class