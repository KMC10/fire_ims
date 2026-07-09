'Author                : Jafar Ulla
'Crated Date           : 29-04-2014
'Last Modified by      : Md. ilias
'Last Modifiation Date : 25-07-2017
'(C) CopyRight Nybsys.

Imports Infragistics.Win.UltraWinGrid
Imports IMS.Lib
Imports IMS.Win.IMSService
Imports Infragistics.Win

Public Class frmRevokeReason
    Inherits BaseForm

#Region "Member"

    Public Event LoadReasonForSave(ByVal reason As String)
    Public Event LoadDoNothig()

#End Region

#Region "Constructor"

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal labelOfBox As String)

        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.lblRevokeReasonTitle.Text = labelOfBox

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

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If Not String.IsNullOrEmpty(txtReason.Text) Then
            RaiseEvent LoadReasonForSave(txtReason.Text.Trim())
            Me.Close()
        Else
            DisplayWarning(IMSConstants.ErrorMessage.GiveReason)
        End If

    End Sub


#End Region

#Region "User Defined Methods"



#End Region


End Class