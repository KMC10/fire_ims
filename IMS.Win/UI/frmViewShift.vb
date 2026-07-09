'Author                : Md Khairuz-Zaman Ronny
'Crated Date           : 8-May-2014
'Last Modified by      : Jafar Ulla
'Last Modifiation Date : 6/6/2014
'CopyRight Nybsys.

Imports IMS.Lib

Public Class frmViewShift
    Inherits BaseForm

#Region "Member Variables"

    Private _proxy As New IMSService.IMSServices
    Private pageIndex As Integer = 0
    Private listSize As Integer = 17
    Private lstShift As New List(Of IMSService.Shift)

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
    ''' Method toLoad From Data.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadData()

        Dim tblShift As New DataTable
        Dim filter As String = String.Format("{0}='{1}' order by {2}", IMSConstants.FieldConstants.Status, CInt(IMSEnum.IMSEnums.Status.Active), IMSConstants.FieldConstants.StationID)

        tblShift.Columns.Add(IMSConstants.FieldConstants.ShiftID, GetType(Integer))
        tblShift.Columns.Add(IMSConstants.GridHeader.StationName, GetType(String))
        tblShift.Columns.Add(IMSConstants.GridHeader.ShiftName, GetType(String))
        tblShift.Columns.Add(IMSConstants.GridHeader.StartTime, GetType(String))
        tblShift.Columns.Add(IMSConstants.GridHeader.EndTime, GetType(String))

        lstShift = _proxy.GetFilteredShift(filter).Cast(Of IMSService.Shift).ToList()

        For Each obj As IMSService.Shift In lstShift.Skip(pageIndex * listSize).Take(listSize) ' TODO: taking only paging list.

            Dim row As DataRow = tblShift.NewRow
            Dim stationName As String = Nothing
            Dim objFireStation As New IMSService.FireStation

            objFireStation = _proxy.GetFireStationByID(obj.StationID)
            If Not IsNothing(objFireStation) Then
                stationName = objFireStation.StationName
            End If
            row(IMSConstants.FieldConstants.ShiftID) = obj.ShiftID
            row(IMSConstants.GridHeader.StationName) = stationName
            row(IMSConstants.GridHeader.ShiftName) = obj.ShiftName
            row(IMSConstants.GridHeader.StartTime) = obj.ShiftStartTime
            row(IMSConstants.GridHeader.EndTime) = obj.ShiftEndTime


            tblShift.Rows.Add(row)
        Next

        'sort table
        Dim dv As DataView = New DataView(tblShift)
        dv.Sort = IMSConstants.GridHeader.StationName & " asc, " & IMSConstants.GridHeader.StartTime & " asc"
        tblShift = dv.ToTable()

        With Me.grvShift
            .DataSource = tblShift
            .DisplayLayout.Bands(0).Columns(0).Hidden = True
            .DisplayLayout.Override.ActiveCellAppearance.Reset()
            .DisplayLayout.Override.ActiveRowAppearance.Reset()
        End With
    End Sub

    ''' <summary>
    ''' Method to Delete Shift.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub DeleteShift()
        Try
            Dim deletedId As Integer = 0
            Dim id As Integer = grvShift.Selected.Rows(0).Cells(0).Value.ToString()
            Dim objShift As IMS.Win.IMSService.Shift = _proxy.GetShiftByID(id)
            If Not IsNothing(objShift) Then
                objShift.Status = CInt(IMSEnums.Status.Deleted)
                deletedId = _proxy.UpdateShift(objShift)
            End If
            If deletedId > 0 Then
                Me.DisplayInformation(IMSConstants.Messages.DeleteSuccessfull)
            End If

        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Method to Load Shift.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadShift()
        Me.LoadData()
        Me.EnableDisableButton()
    End Sub

    ''' <summary>
    ''' Method to Enable Disable Button.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub EnableDisableButton()

        Dim count As Integer = lstShift.Count
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

    Private Sub frmViewShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

            Dim frm As frmAddShift = New frmAddShift()
            AddHandler frm.LoadShift, AddressOf LoadShift
            frm.ShowDialog()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        Try

            If grvShift.Selected.Rows.Count > 0 Then

                Dim editId As Integer = -1
                editId = grvShift.Selected.Rows(0).Cells(0).Value.ToString()

                If editId > -1 Then
                    Dim frm As frmAddShift = New frmAddShift(editId)
                    AddHandler frm.LoadShift, AddressOf LoadShift
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
            If grvShift.Selected.Rows.Count > 0 Then

                If DisplayConfirmation(String.Format(IMSConstants.Information.DoYouWantToDeleteThisInformationPermanantly, Environment.NewLine)) = DialogResult.Yes Then

                    Me.DeleteShift()
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