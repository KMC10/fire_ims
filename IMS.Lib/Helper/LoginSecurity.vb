Imports System.ServiceModel

Public Class LoginSecurity

    Public Shared userID As String
    Public Shared password As String
    Public Shared FormName As String
    Public Shared UserRight As String
    Public Shared SessionID As Integer
    Public Shared moduleID As Integer
    Public Shared StudentID As Integer

    Public Function GetSessionKey() As String
        Return ServiceModel.OperationContext.Current.SessionId
    End Function

End Class
