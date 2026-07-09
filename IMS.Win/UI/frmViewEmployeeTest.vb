Imports IMS.Win.IMSService

Public Class frmViewEmployeeTest
    Private _lstEmployee As New List(Of FireStationAppliance)

    Public Sub New(lstEmployee As List(Of FireStationAppliance))
        _lstEmployee = lstEmployee
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub




    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

    End Sub


    Private Sub frmViewEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim table As New DataTable()
        table.Columns.Add("", GetType(Boolean))
        table.Columns.Add("EmployeeID")
        table.Columns.Add("Employee Name")
        For Each obj As FireStationAppliance In _lstEmployee
            Dim row As DataRow = table.NewRow()
            row(0) = False
            row(1) = obj.StationID
            row(2) = obj.SerialNumber
            table.Rows.Add(row)
        Next


        grvEmployee.DataSource = table
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class