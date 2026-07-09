Public Interface IMainForm
    Sub InitializeMain()
    Sub CallObject(ByVal Obj As Windows.Forms.Form)
    Function CheckObjects(ByVal ObjName As String) As Boolean
    'Sub OnFormActivated()
    Sub OnBeforeFormClosing(e As Windows.Forms.FormClosingEventArgs)
End Interface
