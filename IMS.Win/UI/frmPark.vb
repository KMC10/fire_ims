'Author                : Jafar Ulla
'Crated Date           : 09/07/2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib
Imports System.Globalization

Public Class frmPark
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private _stationIDEmployee As Integer = 0
    Private _stationIDVehicle As Integer = 0

#End Region

#Region "Constructors"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

#End Region

#Region "Event"

    'Public Event LoadByStation(ByVal stationIDEmployee As Integer, ByVal stationIDVehicle As Integer)

#End Region

#Region "User Defined Methods"

    ''' <summary>
    ''' Method to Load Incident Catagory.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadIncidentCategory()

        Dim tblIncidentCategory As New DataTable
        Dim filter As String = String.Format("{0}='{1}' order by {2} asc", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.CategoryName)

        tblIncidentCategory.Columns.Add(IMSConstants.FieldConstants.CategoryID)
        tblIncidentCategory.Columns.Add(IMSConstants.FieldConstants.CategoryName)

        For Each obj As IMSService.IncidentCategory In _proxy.GetFilteredIncidentCategory(filter)
            Dim rows As DataRow = tblIncidentCategory.NewRow
            rows(IMSConstants.FieldConstants.CategoryID) = obj.CategoryID
            rows(IMSConstants.FieldConstants.CategoryName) = obj.CategoryName
            tblIncidentCategory.Rows.Add(rows)
        Next

        Dim row As DataRow = tblIncidentCategory.NewRow
        row(IMSConstants.FieldConstants.CategoryID) = String.Empty
        row(IMSConstants.FieldConstants.CategoryName) = String.Empty
        tblIncidentCategory.Rows.InsertAt(row, 0)

        With Me.cmbIncidentCategory
            .DataSource = tblIncidentCategory
            .ValueMember = IMSConstants.FieldConstants.CategoryID
            .DisplayMember = IMSConstants.FieldConstants.CategoryName
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Incident Type depending on Incident Category ID.
    ''' </summary>
    ''' <param name="incidentCategoryID"></param>
    ''' <remarks></remarks>
    Private Sub LoadIncidentType(ByVal incidentCategoryID As Integer)

        Dim tblIncidentType As New DataTable
        Dim filter As String = String.Format("{0}='{1}' and {2} = {3} order by {4} asc", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.CategoryID, incidentCategoryID, IMSConstants.FieldConstants.IncidentTypeDescription)

        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.IncidentTypeID)
        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.IncidentTypeDescription)

        For Each obj As IMSService.IncidentType In _proxy.GetFilteredIncidentType(filter)
            Dim rows As DataRow = tblIncidentType.NewRow
            rows(IMSConstants.FieldConstants.IncidentTypeID) = obj.IncidentTypeID
            rows(IMSConstants.FieldConstants.IncidentTypeDescription) = obj.IncidentTypeDescription
            tblIncidentType.Rows.Add(rows)
        Next

        Dim row As DataRow = tblIncidentType.NewRow
        row(IMSConstants.FieldConstants.IncidentTypeID) = String.Empty
        row(IMSConstants.FieldConstants.IncidentTypeDescription) = String.Empty
        tblIncidentType.Rows.InsertAt(row, 0)

        With Me.cmbIncidentType
            .DataSource = tblIncidentType
            .ValueMember = IMSConstants.FieldConstants.IncidentTypeID
            .DisplayMember = IMSConstants.FieldConstants.IncidentTypeDescription
            .DataBind()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Incident  Reference
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadIncidentReference()

        If Not String.IsNullOrEmpty(cmbIncidentType.Text.Trim()) Then

            Dim lstIncidentReference As List(Of IMSService.IncidentRegister) = CommonFunction.GetIncidentsUnresolvedAndResolvedWithInTwoDaysByIncidentType(cmbIncidentType.Value).Cast(Of IMSService.IncidentRegister).ToList()

            Dim objIncidnetRegister As New IMSService.IncidentRegister()
            objIncidnetRegister.IncidentID = 0
            objIncidnetRegister.ReferenceNo = " "

            lstIncidentReference.Insert(0, objIncidnetRegister)

            With cmbIncidentReference
                .DataSource = lstIncidentReference
                .DisplayMember = IMSConstants.FieldConstants.ReferenceNo
                .ValueMember = IMSConstants.FieldConstants.IncidentID
                '.DataBind()
            End With

        Else
            cmbIncidentReference.DataSource = Nothing
        End If

    End Sub

    ''' <summary>
    ''' Method to Load Employee checkbox list
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Private Sub LoadEmployee(ByVal incidentID As Integer)

        Dim lstIncidentEmployee As List(Of IMSService.Employee) = CommonFunction.GetCurrentlyInvolvedButParkedEmployeeByIncidentID(incidentID)

        With chkEmployeeList
            .DataSource = lstIncidentEmployee
            .ValueMember = IMSConstants.FieldConstants.EmployeeID
            .DisplayMember = IMSConstants.FieldConstants.EmployeeName
            .ClearSelected()
        End With

    End Sub

    ''' <summary>
    ''' Method to Clear List Boxes.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearEmployeeAndVehicleListBox()

        With chkEmployeeList
            .DataSource = Nothing
            '.ValueMember = IMSConstants.FieldConstants.EmployeeID
            '.DisplayMember = IMSConstants.FieldConstants.EmployeeName
            '.ClearSelected()
        End With

        With chkVehicleList
            .DataSource = Nothing
            '.ValueMember = IMSConstants.FieldConstants.EmployeeID
            '.DisplayMember = IMSConstants.FieldConstants.EmployeeName
            '.ClearSelected()
        End With

    End Sub

    ''' <summary>
    ''' Method to Load Vehicle checkbox list
    ''' </summary>
    ''' <param name="incidentID"></param>
    ''' <remarks></remarks>
    Private Sub LoadVehicle(ByVal incidentID As Integer)

        Dim lstIncidentVehicle As List(Of IMSService.FireStationAppliance) = CommonFunction.GetCurrentlyInvolvedApplienceByIncidentID(incidentID)

        With chkVehicleList
            .DataSource = lstIncidentVehicle
            .ValueMember = IMSConstants.FieldConstants.StationApplianceID
            .DisplayMember = IMSConstants.FieldConstants.SerialNumber
            .ClearSelected()
        End With

    End Sub

    ''' <summary>
    ''' Method to CheckIn all Employees at Check Box list.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ParkEmployees()

        Dim objEmployeeRegister As IMSService.EmployeeRegister
        Dim objEmployeeRegisterNew As IMSService.EmployeeRegister
        Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.AppConstants.DateFormatToQuery, CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        'Check In all checked Employee
        For Each objEmployee As IMSService.Employee In chkEmployeeList.CheckedItems

            objEmployeeRegister = CommonFunction.GetLatestDataAtEmployeeRegister(objEmployee.EmployeeID)

            If Not IsNothing(objEmployeeRegister) Then

                objEmployeeRegisterNew = New IMSService.EmployeeRegister()
                With objEmployeeRegisterNew
                    .EmployeeID = objEmployee.EmployeeID
                    .StationID = objEmployeeRegister.StationID
                    _stationIDEmployee = objEmployeeRegister.StationID ' for event fire parameter
                    .ShiftID = CommonFunction.GetShiftIDByStationIDAndTime(objEmployeeRegister.StationID, currentTime)
                    .RegisterStatus = CInt(IMSEnums.RegisterStatus.Parked)
                    .IsCurrent = True
                    If Not String.IsNullOrEmpty(cmbIncidentReference.Text.Trim()) Then
                        .IncidentID = cmbIncidentReference.Value
                    End If
                    .Reason = IMSConstants.Common.IncidentCheckIn
                    .CapturedBy = IMSConstants.AppConstants.UsersEmployeeID
                    .InsertionDate = currentDate
                    .ModificationDate = currentDate
                End With

                'If Check in make available status at "Assigned Employee"
                'CommonFunction.UpdateEmployeeOccupied(objEmployeeRegister.EmployeeID)
                CommonFunction.UpdateEmployeeOccupiedToAvailable(objEmployeeRegister.EmployeeID)
                CommonFunction.UpdateIsTrueForEmployeeRegister(objEmployeeRegister.EmployeeID)
                _proxy.InsertEmployeeRegister(objEmployeeRegisterNew)

            End If
        Next

    End Sub

    ''' <summary>
    ''' Method to Check In all Vehicle at Check box list
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ParkVehicles()

        Dim objApplianceRegister As IMSService.ApplianceRegister
        Dim objApplianceRegisterNew As IMSService.ApplianceRegister
        'Dim currentTime As TimeSpan = Now.TimeOfDay()
        Dim currentDate As DateTime
        DateTime.TryParseExact(Date.Now.ToString(IMSConstants.AppConstants.DateFormatToQuery), IMSConstants.AppConstants.DateFormatToQuery, CultureInfo.InvariantCulture, DateTimeStyles.None, currentDate)

        'Check In all checked Vehicle
        For Each objFireStationAppliance As IMSService.FireStationAppliance In chkVehicleList.CheckedItems

            objApplianceRegister = CommonFunction.GetLatestDataAtApplianceRegister(objFireStationAppliance.StationApplianceID)

            If Not IsNothing(objApplianceRegister) Then

                objApplianceRegisterNew = New IMSService.ApplianceRegister()

                With objApplianceRegisterNew
                    .StationApplianceID = objFireStationAppliance.StationApplianceID
                    .StationID = objApplianceRegister.StationID
                    _stationIDVehicle = objApplianceRegister.StationID ' for event fire parameter
                    .RegisterStatus = CInt(IMSEnums.RegisterStatus.Parked)
                    .IsCurrent = True
                    If Not String.IsNullOrEmpty(cmbIncidentReference.Text.Trim()) Then
                        .IncidentID = cmbIncidentReference.Value
                    End If
                    .Reason = IMSConstants.Common.IncidentCheckIn
                    .CapturedBy = IMSConstants.AppConstants.UsersEmployeeID
                    .InsertionDate = currentDate
                    .ModificationDate = currentDate
                End With

                'If Check in make available status at "Assigned Employee"
                CommonFunction.UpdateIsTrueForApplianceRegister(objApplianceRegister.StationApplianceID)
                'CommonFunction.UpdateAssinedApplience(objApplianceRegister.StationApplianceID)
                CommonFunction.UpdateAssinedApplienceToAvailable(objApplianceRegister.StationApplianceID)

                _proxy.InsertApplianceRegister(objApplianceRegisterNew)

            End If
        Next

    End Sub

    ''' <summary>
    ''' Method to Load the Box lists
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadCheckBoxes()

        If Not String.IsNullOrEmpty(cmbIncidentReference.Text.Trim()) Then
            Me.LoadEmployee(cmbIncidentReference.Value)
            Me.LoadVehicle(cmbIncidentReference.Value)
        Else
            Me.LoadEmployee(0)
            Me.LoadVehicle(0)
        End If

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmIncidentCheckIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try

            LoadIncidentCategory()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub cmbIncidentCategory_SelectionChanged(sender As Object, e As EventArgs) Handles cmbIncidentCategory.SelectionChanged
        Try

            If Not String.IsNullOrEmpty(cmbIncidentCategory.Value) Then
                Me.LoadIncidentType(cmbIncidentCategory.Value)
            Else
                Me.LoadIncidentType(0)
                Me.LoadIncidentReference()
                Me.ClearEmployeeAndVehicleListBox()
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub cmbIncidentType_SelectionChanged(sender As Object, e As EventArgs) Handles cmbIncidentType.SelectionChanged
        Try

            Me.LoadIncidentReference()
            If String.IsNullOrEmpty(cmbIncidentType.Text.Trim()) Then
                Me.ClearEmployeeAndVehicleListBox()
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub cmbIncidentReference_SelectionChanged(sender As Object, e As EventArgs) Handles cmbIncidentReference.SelectionChanged
        Try
            Me.LoadCheckBoxes()

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try

            Me.ParkEmployees()
            Me.ParkVehicles()

            cmbIncidentReference.Value = String.Empty
            Me.ClearEmployeeAndVehicleListBox()
            'Me.LoadCheckBoxes()
            DisplaySuccessfull(IMSConstants.SuccessMessageConstants.ParkedSuccessfull)
            'RaiseEvent LoadByStation(_stationIDEmployee, _stationIDVehicle)

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

#End Region

End Class