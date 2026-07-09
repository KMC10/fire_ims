'Author                : Jafar Ulla
'Crated Date           : 21/6/2014
'Last Modified by      : Md.ilias
'Last Modifiation Date : 25-07-2017
'(C) CopyRight Nybsys.

Imports Infragistics.Win.UltraWinGrid
Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win

Public Class frmTimeOfArrival
    Inherits BaseForm

#Region "Member"

    Public Event LoadTOAForSave(ByVal dispatchLogID As Integer, ByVal timeOfArrival As String)
    Public Event LoadDoNothig()

    Private dispatchLogID As Integer

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal dispatchLogIDint As Integer, ByVal arrivalTime As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.

        dispatchLogID = dispatchLogIDint

        If Not String.IsNullOrEmpty(arrivalTime) Then
            dtpTimeOfArrival.Value = DateTime.Parse(arrivalTime)
        Else
            dtpTimeOfArrival.Value = Now
        End If

    End Sub

#End Region


#Region "Event Handlers"

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        RaiseEvent LoadDoNothig()
        Me.Close()

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Not String.IsNullOrEmpty(dtpTimeOfArrival.Value) Then
            RaiseEvent LoadTOAForSave(dispatchLogID, dtpTimeOfArrival.Value)
            Me.Close()
        Else
            DisplayWarning(IMSConstants.ErrorMessage.GiveTimeOfArrival)
        End If

    End Sub

#End Region

#Region "User Defined Methods"



#End Region



End Class