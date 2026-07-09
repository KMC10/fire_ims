'Created By : Jafar Ulla
'Created Date : 2013_09_21
'Modified By : 
'(C) CopyRight Nybsys.
''''''''''''''''''''''''''''''''''

Imports System.Windows.Forms
Imports IMS.Lib.IMSConstants

Public Class BaseForm
    Inherits System.Windows.Forms.Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'BaseForm
        '
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.Name = "BaseForm"
        Me.ResumeLayout(False)

    End Sub

    Public Shared Sub Main()

    End Sub

    ''' <summary>
    ''' Method to Write log file.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteLog(ByVal message As String)
        ' Definition.
    End Sub

    ''' <summary>
    ''' Method to Write log file.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub WriteLog(ByVal ex As Exception)
        ' Definition.
    End Sub

    ''' <summary>
    ''' Method to Display Information.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisplayInformationPopup(ByVal message As String)
        System.Windows.Forms.MessageBox.Show(message, "IMS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub DisplayInformation(message As String)
        '  System.Windows.Forms.MessageBox.Show(message, Constants.Title.Declaration, MessageBoxButtons.OK, MessageBoxIcon.Information);
        CommonFunctions.MainForm.ShowMessage(AlertConstant.Information, message, AlertConstant.ImageCaptionInformation, AlertConstant.SoundCaptionInformation, False)
    End Sub

    Public Sub DisplaySuccessfullPopup(message As String)
        System.Windows.Forms.MessageBox.Show(message, "IMS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub DisplaySuccessfull(message As String)
        'System.Windows.Forms.MessageBox.Show(message, Constants.Title.Declaration, MessageBoxButtons.OK, MessageBoxIcon.Information);
        CommonFunctions.MainForm.ShowMessage(AlertConstant.SuccessMessage, message, AlertConstant.ImageCaptionSuccess, AlertConstant.SoundCaptionSuccess, False)
    End Sub

    ''' <summary>
    ''' Method to Display Information.
    ''' </summary>
    ''' <remarks></remarks>
    Public Function DisplayConfirmation(ByVal message As String) As DialogResult
        Return System.Windows.Forms.MessageBox.Show(message, "IMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
    End Function

    ''' <summary>
    ''' Method to Display Error.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DisplayErrorPopup(ByVal message As String)
        System.Windows.Forms.MessageBox.Show(message, "IMS", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub


    Public Sub DisplayError(message As String)
        'System.Windows.Forms.MessageBox.Show(message, Constants.Title.Declaration, MessageBoxButtons.OK, MessageBoxIcon.Error);
        CommonFunctions.MainForm.ShowMessage(AlertConstant.ErrorMessage, message, AlertConstant.ImageCaptionError, AlertConstant.SoundCaptionError, True)
    End Sub

    Public Sub DisplayWarningPopup(ByVal message As String)
        System.Windows.Forms.MessageBox.Show(message, "IMS", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Sub DisplayWarning(message As String)
        CommonFunctions.MainForm.ShowMessage(AlertConstant.WarningMessage, message, AlertConstant.ImageCaptionWarning, AlertConstant.SoundCaptionWarning, True)
    End Sub

    Private Sub BaseForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ss As String = ""
    End Sub

    Public Function GetFromDate(ByVal value As DateTime) As DateTime

        Return New DateTime(value.Year, value.Month, value.Day, 0, 0, 0, 0)

    End Function

    Public Function GetToDate(ByVal value As DateTime) As DateTime

        Return New DateTime(value.Year, value.Month, value.Day, 23, 59, 59, 999)

    End Function

    ''' <summary>
    ''' Method to Set Security.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetSecurity(ByVal form As Windows.Forms.Form)

        If Not CommonFunction.IsSuperAdmin Then
            For Each objControl As Control In form.Controls
                Me.RecurseControls(objControl, form)
            Next
        End If

    End Sub

    ''' <summary>
    ''' Method to recurcive function for enable disablecontrols.
    ''' </summary>
    ''' <param name="ctr"></param>
    ''' <remarks></remarks>
    Private Sub RecurseControls(ByVal ctr As Control, ByVal form As Windows.Forms.Form)

        If ctr.HasChildren Then
            For Each objControl As Control In ctr.Controls
                RecurseControls(objControl, form)
            Next objControl
        Else
            If ctr.Name.Contains("btn") Then
                Dim objSavePrivilig As IMSService.Privileges = UserUtil.GetUserPreviliges().Where(Function(x) x.FrontEndID = ctr.Name And x.FrontEndParentID = Me.Name).FirstOrDefault()
                ctr.Enabled = Not IsNothing(objSavePrivilig)
            End If

            'Enable close button.
            If ctr.Name = "btnClose" Then
                ctr.Enabled = True
            End If

        End If

    End Sub

End Class