'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 25-Apr-2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization


Public Class frmStation
    Inherits BaseForm

    Public Event LoadStation()

#Region "Member Variables"

    Private IsUpdate As Boolean = False
    Private mFireStation As New IMSService.FireStation
    Private _proxy As New IMSService.IMSServices

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal StationID As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        Me.IsUpdate = True
        Me.mFireStation = _proxy.GetFireStationByID(StationID)
        Me.Text = "Update Fire Station"
        btnSave.Text = "Update"

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to load station Manager.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadStationManager()

        Dim tblEmployee As New DataTable
        Dim filter As String = String.Format("{0}='{1}'", IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnum.IMSEnums.IsDeleted.No))

        tblEmployee.Columns.Add(IMSConstants.FieldConstants.EmployeeID)
        tblEmployee.Columns.Add(IMSConstants.FieldConstants.EmployeeName)

        For Each obj As IMSService.Employee In _proxy.GetFilteredEmployee(filter)
            Dim rows As DataRow = tblEmployee.NewRow
            rows(IMSConstants.FieldConstants.EmployeeID) = obj.EmployeeID
            rows(IMSConstants.FieldConstants.EmployeeName) = obj.EmployeeName
            tblEmployee.Rows.Add(rows)
        Next

        'sort dataTable
        Dim dView As New DataView(tblEmployee)
        dView.Sort = "EmployeeName ASC"

        Dim sortedTable As DataTable = dView.ToTable()

        Dim row As DataRow = sortedTable.NewRow
        row(IMSConstants.FieldConstants.EmployeeID) = String.Empty
        row(IMSConstants.FieldConstants.EmployeeName) = String.Empty
        sortedTable.Rows.InsertAt(row, 0)

        With Me.cmbStationManager
            .DataSource = sortedTable
            .ValueMember = IMSConstants.FieldConstants.EmployeeID
            .DisplayMember = IMSConstants.FieldConstants.EmployeeName
            .DataBind()
            '.Value = -1
        End With

    End Sub

    ''' <summary>
    ''' Method to Save Station.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveStation() As Integer

        Dim objFireStation As IMS.Win.IMSService.FireStation = SetData()

        Return _proxy.InsertFireStation(objFireStation)

    End Function

    ''' <summary>
    ''' Method to Set Firestation object.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SetData() As IMS.Win.IMSService.FireStation
        Dim objFireStation As New IMS.Win.IMSService.FireStation
        Dim currentTime As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)

        With objFireStation
            .StationCode = txtStationCode.Text.Trim()
            .StationLetter = txtStationLetter.Text.Trim()
            .StationName = txtStationName.Text.Trim()
            .StationManagerID = cmbStationManager.Value
            .PhoneNumber = txtPhoneNo.Text.Trim()
            .PostalAddress = txtAddress.Text.Trim()
            .InsertionDate = currentTime
            .ModificationDate = currentTime
            .IsDeleted = CInt(IMSEnums.IsDeleted.No)

        End With
        Return objFireStation

    End Function

    ''' <summary>
    ''' Method to set Data from object.
    ''' </summary>
    ''' <param name="objFireStation"></param>
    ''' <remarks></remarks>
    Private Sub SetData(ByRef objFireStation As IMS.Win.IMSService.FireStation)
        Dim currentTime As DateTime
        DateTime.TryParseExact(Date.Now.ToString("dd/MM/yyyy"), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, currentTime)


        With mFireStation
            .StationCode = txtStationCode.Text.Trim()
            .StationLetter = txtStationLetter.Text.Trim()
            .StationName = txtStationName.Text.Trim()

            If Not String.IsNullOrEmpty(cmbStationManager.Value) Then
                .StationManagerID = cmbStationManager.Value
            Else
                .StationManagerID = Nothing
            End If

            .PhoneNumber = txtPhoneNo.Text.Trim()
            .PostalAddress = txtAddress.Text.Trim()
            .ModificationDate = currentTime

        End With

    End Sub

    ''' <summary>
    ''' Method to cleare all fields.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearAllFields()
        txtStationCode.Text = String.Empty
        txtStationLetter.Text = String.Empty
        txtStationName.Text = String.Empty
        cmbStationManager.Text = String.Empty
        txtPhoneNo.Text = String.Empty
        txtAddress.Text = String.Empty
        IsUpdate = False

    End Sub

    ''' <summary>
    ''' method to check validation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsValidate() As Boolean

        Dim chkDuplicate As Boolean = True

        If txtStationName.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeStationName)
            txtStationName.Focus()
            Return False
        End If

        If txtStationCode.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeStationCode)
            txtStationCode.Focus()
            Return False
        End If

        If txtStationLetter.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeStationLetter)
            txtStationLetter.Focus()
            Return False
        End If

        'If cmbStationManager.Text = String.Empty Then
        '    DisplayWarning(IMSConstants.ErrorMessage.SelectStationManager)
        '    cmbStationManager.Focus()
        '    Return False
        'End If

        If txtPhoneNo.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypePhoneNo)
            txtPhoneNo.Focus()
            Return False
        End If

        If txtAddress.Text = String.Empty Then
            DisplayWarning(IMSConstants.ErrorMessage.TypeAddress)
            txtAddress.Focus()
            Return False
        End If

        If IsUpdate = True Then
            If mFireStation.StationCode = (txtStationCode.Text.Trim()) Then
                chkDuplicate = False
            End If
        End If

        If chkDuplicate = True AndAlso IsDuplicate(txtStationCode.Text) = True Then
            Me.DisplayWarning(IMSConstants.ErrorMessage.DuplicateStationCode)
            Me.txtStationCode.Focus()
            Return False
        End If


        Return True

    End Function

    ''' <summary>
    ''' Method to check duplicate.
    ''' </summary>
    ''' <param name="FireStationCode"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function IsDuplicate(ByVal FireStationCode As String) As Boolean

        Dim filter As String = String.Format("{0}='{1}' and {2} = {3}", IMSConstants.FieldConstants.StationCode, FireStationCode, IMSConstants.FieldConstants.IsDeleted, CInt(IMSEnums.IsDeleted.No))
        Dim lstFireStation As List(Of IMS.Win.IMSService.FireStation) = _proxy.GetFilteredFireStation(filter).Cast(Of IMS.Win.IMSService.FireStation).ToList

        If lstFireStation.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    ''' <summary>
    ''' Method to view form Data.
    ''' </summary>
    ''' <param name="objFireStation"></param>
    ''' <remarks></remarks>
    Private Sub ViewFormData(ByVal objFireStation As IMS.Win.IMSService.FireStation)

        With objFireStation
            txtStationCode.Text = .StationCode
            txtStationLetter.Text = .StationLetter
            txtStationName.Text = .StationName
            cmbStationManager.Value = .StationManagerID
            txtPhoneNo.Text = .PhoneNumber
            txtAddress.Text = .PostalAddress
            If .StationManagerID = 0 Then
                cmbStationManager.Text = String.Empty
            End If

        End With

    End Sub

    ''' <summary>
    ''' Method to Update FireStation
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function UpdateFireStation() As Integer

        Dim id As Integer = -1
        Me.SetData(mFireStation)
        ' Dim objFireStation As IMS.Win.IMSService.FireStation = mFireStation

        id = _proxy.UpdateFireStation(mFireStation)

        Return id

    End Function

    ''' <summary>
    ''' Method to Save FireStation.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function SaveFireStation() As Integer

        Dim id As Integer = -1
        Dim objFireStation As IMS.Win.IMSService.FireStation = SetData()

        id = _proxy.InsertFireStation(objFireStation)

        Return id

    End Function

    ''' <summary>
    ''' method for reset all controll.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ResetallControll()
        Me.txtStationName.Text = String.Empty
        Me.txtStationCode.Text = String.Empty
        Me.txtStationLetter.Text = String.Empty
        Me.cmbStationManager.Text = String.Empty
        Me.txtPhoneNo.Text = String.Empty
        Me.txtAddress.Text = String.Empty
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

    Private Sub frmStation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            MyBase.SetSecurity(Me)

            Me.LoadStationManager()
            Me.ViewFormData(mFireStation)
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
                intActionResult = Me.UpdateFireStation()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadStation()
                    Me.Close()

                End If
            Else
                intActionResult = Me.SaveFireStation()
                If intActionResult > 0 Then
                    DisplaySuccessfull(IMSConstants.SuccessMessageConstants.InsertSuccessfull)
                    RaiseEvent LoadStation()
                    ResetallControll()

                End If
            End If

            
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs)
        Try
            ViewFormData(mFireStation)
            If IsNothing(mFireStation.StationCode) Then
                Me.cmbStationManager.Value = -1
            End If

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