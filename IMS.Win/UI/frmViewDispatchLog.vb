'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 28-Apr-2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmViewDispatchLog
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private _incidentId As Integer

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _incidentId = 34

    End Sub

    Public Sub New(ByVal IncidentId As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _incidentId = IncidentId

    End Sub

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to loaad form data.
    ''' </summary>
    ''' <param name="incidentId"></param>
    ''' <remarks></remarks>
    Private Sub LoadData(ByVal incidentId As Integer)

        Dim tblIncidentType As DataTable = CreateDataTable()
        Dim row As DataRow = tblIncidentType.NewRow
        Dim strSQL As String = IMSConstants.FieldConstants.IncidentID & "=" & incidentId & " ORDER BY " & "DispatchLogID DESC"

        For Each obj As IMSService.DispatchLog In _proxy.GetFilteredDispatchLog(strSQL).Cast(Of IMSService.DispatchLog).ToList()

            row = CreateRow(obj, tblIncidentType)
            tblIncidentType.Rows.Add(row)

        Next

        With Me.grvDispatchLog
            .DataSource = tblIncidentType
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With

    End Sub

    ''' <summary>
    ''' Method to Create data table
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateDataTable() As DataTable

        Dim tblIncidentType As New DataTable

        tblIncidentType.Columns.Add(IMSConstants.FieldConstants.DispatchLogID, GetType(Integer))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.Time, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.ActionTaken, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.User, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.Reason, GetType(String))
        tblIncidentType.Columns.Add(IMSConstants.GridHeader.Serialno, GetType(String))

        Return tblIncidentType

    End Function

    ''' <summary>
    ''' Method to create row.
    ''' </summary>
    ''' <param name="obj"></param>
    ''' <param name="tblIncidentType"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CreateRow(ByVal obj As IMSService.DispatchLog, ByVal tblIncidentType As DataTable) As DataRow

        Dim row As DataRow = tblIncidentType.NewRow

        Dim employee As String = Nothing
        Dim objemployee As IMSService.Employee = _proxy.GetEmployeeByID(obj.CreatedBy)
        If Not IsNothing(objemployee) Then
            employee = objemployee.EmployeeName
        End If

        Dim serialNo As String = Nothing
        Dim objFireStationAppliance As IMSService.FireStationAppliance = _proxy.GetFireStationApplianceByID(obj.StationApplianceID)
        If Not IsNothing(objFireStationAppliance) Then
            serialNo = objFireStationAppliance.SerialNumber
        End If

        row(IMSConstants.FieldConstants.DispatchLogID) = obj.DispatchLogID
        row(IMSConstants.GridHeader.Time) = obj.DispatchDate
        row(IMSConstants.GridHeader.ActionTaken) = [Enum].GetName(GetType(IMSEnums.ApplianceStatus), obj.AssignedApplianceStatus)
        row(IMSConstants.GridHeader.User) = employee
        row(IMSConstants.GridHeader.Reason) = obj.Reason
        row(IMSConstants.GridHeader.Serialno) = serialNo

        Return row

    End Function

    ''' <summary>
    ''' Method to delete dispatchLog
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteDispatchLog()
        Try
            Dim deletedId As Integer = -1
            Dim id As Integer = grvDispatchLog.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objDispatchLog As IMS.Win.IMSService.DispatchLog = _proxy.GetDispatchLogByID(id)
            If Not IsNothing(objDispatchLog) Then
                deletedId = _proxy.DeleteDispatchLog(objDispatchLog)
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
    ''' Method to Set Security.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub SetSecurity()

        For Each objControl As Control In Me.Controls
            Me.RecurseControls(objControl)
        Next

    End Sub

    ''' <summary>
    ''' Method to recurcive function for enable disablecontrols.
    ''' </summary>
    ''' <param name="ctr"></param>
    ''' <remarks></remarks>
    Private Sub RecurseControls(ByVal ctr As Control)

        If ctr.HasChildren Then
            For Each objControl As Control In ctr.Controls
                RecurseControls(objControl)
            Next objControl
        Else
            If ctr.Name.Contains("btn") Then
                Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = ctr.Name And x.FrontEndParentID = Me.Name).FirstOrDefault()
                ctr.Enabled = Not IsNothing(objSavePrivilig)
            End If
            btnClose.Enabled = True
        End If

    End Sub

#End Region

#Region "Event Handlers"

    Private Sub frmViewDispatchLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Me.LoadData(_incidentId)
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs)
        Try

            'Dim frm As frmAddIncidentType = New frmAddIncidentType()
            'AddHandler frm.LoadIncidentType, AddressOf LoadIncidentType
            'frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs)
        Try

            If grvDispatchLog.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvDispatchLog.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    'Dim frm As frmAddIncidentType = New frmAddIncidentType(editId)
                    'AddHandler frm.LoadIncidentType, AddressOf LoadIncidentType
                    'frm.ShowDialog()
                End If

            Else
                DisplayInformation("Pelase Select A Incidedent Type. ")
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs)
        Try
            If grvDispatchLog.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    DeleteDispatchLog()
                    Me.LoadData(_incidentId)

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
            Me.LoadData(_incidentId)
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