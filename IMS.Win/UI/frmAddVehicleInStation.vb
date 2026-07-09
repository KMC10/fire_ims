'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 27-Apr-2014
'Last Modified by      : 
'Last Modifiation Date : 
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization



Public Class frmAddVehicleInStation
    Inherits BaseForm

#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mFireStationAppliance As New IMSService.FireStationAppliance
    Private _proxy As New IMSService.IMSServices

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal StationApplianceID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mFireStationAppliance = _proxy.GetFireStationApplianceByID(StationApplianceID)
        Me.Text = "Update Vehicle Assignments In Station"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Methode to Load fire station.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadFireStation()

        Dim tblFireStation As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No))

        tblFireStation.Columns.Add(IMSConstants.FieldConstants.StationID)
        tblFireStation.Columns.Add(IMSConstants.FieldConstants.StationCode)

        For Each obj As IMSService.FireStation In _proxy.GetFilteredFireStation(filter)
            Dim rows As DataRow = tblFireStation.NewRow
            rows(IMSConstants.FieldConstants.StationID) = obj.StationID
            rows(IMSConstants.FieldConstants.StationCode) = obj.StationCode
            tblFireStation.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblFireStation)
        dView.Sort = "StationCode ASC"

        Dim sortedTable As DataTable = dView.ToTable()

        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.StationID) = String.Empty
        row(IMSConstants.FieldConstants.StationCode) = String.Empty
        sortedTable.Rows.InsertAt(row, 0)

        With Me.cmbStationCode
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.StationID
            .DisplayMember = IMSConstants.FieldConstants.StationCode
            .DataBind()
            ' .Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Applience.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadAppliance()

        Dim tblAppliance As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No))

        tblAppliance.Columns.Add(IMSConstants.FieldConstants.ApplianceID)
        tblAppliance.Columns.Add(IMSConstants.FieldConstants.ApplianceCode)

        For Each obj As IMSService.Appliance In _proxy.GetFilteredAppliance(filter)
            Dim rows As DataRow = tblAppliance.NewRow
            rows(IMSConstants.FieldConstants.ApplianceID) = obj.ApplianceID
            rows(IMSConstants.FieldConstants.ApplianceCode) = obj.ApplianceCode
            tblAppliance.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblAppliance)
        dView.Sort = "ApplianceCode ASC"

        Dim sortedTable As DataTable = dView.ToTable()

        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.ApplianceID) = String.Empty
        row(IMSConstants.FieldConstants.ApplianceCode) = String.Empty
        sortedTable.Rows.InsertAt(row, 0)


        With Me.cmbVehicleCode
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.ApplianceID
            .DisplayMember = IMSConstants.FieldConstants.ApplianceCode
            .DataBind()
            '.Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to set FireStatiomApplience object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.FireStationAppliance

        Dim objFireStationAppliance As New IMS.Win.IMSService.FireStationAppliance

        With objFireStationAppliance

            .StationID = cmbStationCode.Value
            .ApplianceID = cmbVehicleCode.Value
            .SerialNumber = txtSerial.Text.Trim()
            .Status = CInt(IMSEnums.Status.Active)

        End With

        Return objFireStationAppliance

    End Function

    ''' <summary>
    ''' Method to set FireStatiomApplience object by an object.
    ''' </summary>
    ''' <param name="objFireStationAppliance"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objFireStationAppliance As IMS.Win.IMSService.FireStationAppliance)


        With mFireStationAppliance

            .StationID = cmbStationCode.Value
            .ApplianceID = cmbVehicleCode.Value
            .SerialNumber = txtSerial.Text.Trim()

        End With

    End Sub

    ''' <summary>
    ''' Method to Clear all Fields.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllFields()

        cmbStationCode.Text = String.Empty
        cmbVehicleCode.Text = String.Empty
        txtSerial.Text = String.Empty
        txtApplienceName.Text = String.Empty
        txtStationName.Text = String.Empty
        IsUpdate = False

    End Sub

    ''' <summary>
    ''' Method to check field validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If cmbStationCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectStationCode)
            cmbStationCode.Focus()
            Return False
        End If

        If cmbVehicleCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.SelectVehicleCode)
            cmbVehicleCode.Focus()
            Return False
        End If

        If txtSerial.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeSerial)
            txtSerial.Focus()
            Return False
        End If



        If IsUpdate = True Then
            If mFireStationAppliance.SerialNumber = (txtSerial.Text.Trim()) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtSerial.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateSerialNumber)
            Me.txtSerial.Focus()
            Return False
        End If


        Return True

    End Function

    ''' <summary>
    ''' Method to Check Duplicate.
    ''' </summary>
    ''' <param name="serialNumber"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal serialNumber As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' AND {2}='{3}'", IMSConstants.FieldConstants.SerialNumber, serialNumber, IMSConstants.FieldConstants.Status, CInt(IMSEnums.Status.Active))
        Dim lstFireStationAppliance As List(Of IMS.Win.IMSService.FireStationAppliance) = _proxy.GetFilteredFireStationAppliance(filter).Cast(Of IMS.Win.IMSService.FireStationAppliance).ToList

        If lstFireStationAppliance.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to View form data.
    ''' </summary>
    ''' <param name="objFireStationAppliance"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objFireStationAppliance As IMS.Win.IMSService.FireStationAppliance)

        With objFireStationAppliance

            cmbStationCode.Value = .StationID
            cmbVehicleCode.Value = .ApplianceID
            txtSerial.Text = .SerialNumber

            Dim objStation As IMSService.FireStation = _proxy.GetFireStationByID(.StationID)
            If Not IsNothing(objStation) Then
                txtStationName.Text = objStation.StationName
            End If

            Dim objApplience As IMSService.Appliance = _proxy.GetApplianceByID(.ApplianceID)
            If Not IsNothing(objApplience) Then
                txtApplienceName.Text = objApplience.ApplianceName
            End If

            If .StationID = 0 Then
                cmbStationCode.Text = String.Empty
            End If
            If .ApplianceID = 0 Then
                cmbVehicleCode.Text = String.Empty
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to Update FireStationAppliance
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateFireStationAppliance() As Integer

        Dim id As Integer = -1
        Me.SetData(mFireStationAppliance)
        Dim objFireStationAppliance As IMS.Win.IMSService.FireStationAppliance = mFireStationAppliance

        id = _proxy.UpdateFireStationAppliance(objFireStationAppliance)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save FireStationAppliance
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveFireStationAppliance() As Integer

        Dim id As Integer = -1
        Dim objFireStationAppliance As IMS.Win.IMSService.FireStationAppliance = SetData()

        id = _proxy.InsertFireStationAppliance(objFireStationAppliance)

        Return id

    End Function

    ''' <summary>
    ''' method for reset all controll
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetAllControll()
        Me.cmbStationCode.Text = String.Empty
        Me.cmbVehicleCode.Text = String.Empty
        Me.txtStationName.Text = String.Empty
        Me.txtApplienceName.Text = String.Empty
        Me.txtSerial.Text = String.Empty
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

    Public Event LoadVehiclesInStation()

#End Region

#Region "Event Handlers"

    Private Sub frmAddVehicleInStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            Me.LoadAppliance()
            Me.LoadFireStation()
            Me.ViewFormData(mFireStationAppliance)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Try
            Dim intActionResult As Integer = 0

            If Me.IsValidate = False Then Exit Sub

            If Me.IsUpdate = True Then
                intActionResult = Me.UpdateFireStationAppliance()

                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadVehiclesInStation()
                    Me.Close()

                End If
            Else
                intActionResult = Me.SaveFireStationAppliance()

                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadVehiclesInStation()
                    ResetAllControll()
                    'Me.Close()

                End If
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Try
            ViewFormData(mFireStationAppliance)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cmbStationCode_SelectionChanged(sender As Object, e As EventArgs) Handles cmbStationCode.SelectionChanged
        Try
            Dim stationName As String = String.Empty
            Dim objStation As New IMSService.FireStation

            If Not String.IsNullOrEmpty(cmbStationCode.Value) And cmbStationCode.Value <> "-1" Then
                objStation = _proxy.GetFireStationByID(cmbStationCode.Value)

                If Not IsNothing(objStation) Then
                    stationName = objStation.StationName
                End If

            End If

            txtStationName.Text = stationName

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub cmbVehicleCode_SelectionChanged(sender As Object, e As EventArgs) Handles cmbVehicleCode.SelectionChanged
        Try

            Dim vehicleName As String = String.Empty
            Dim objAlpplience As New IMSService.Appliance

            If Not String.IsNullOrEmpty(cmbVehicleCode.Value) And cmbVehicleCode.Value <> "-1" Then
                objAlpplience = _proxy.GetApplianceByID(cmbVehicleCode.Value)

                If Not IsNothing(objAlpplience) Then
                    vehicleName = objAlpplience.ApplianceName
                End If

            End If

            txtApplienceName.Text = vehicleName

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

End Class