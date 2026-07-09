Imports IMS.Lib

Public Class Form1 : Implements IMainForm

    Public Sub CallObject(Obj As Form) Implements IMainForm.CallObject

    End Sub

    Public Function CheckObjects(ObjName As String) As Boolean Implements IMainForm.CheckObjects

    End Function

    Public Sub InitializeMain() Implements IMainForm.InitializeMain

    End Sub

    Public Sub OnBeforeFormClosing(e As FormClosingEventArgs) Implements IMainForm.OnBeforeFormClosing

    End Sub


End Class