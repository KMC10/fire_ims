Imports IMS.Win.IMSService

Public Class UserUtil

    Private Shared _LoggedinUser As IMSService.Users = Nothing
    Private Shared _UserPreviliges As New List(Of IMSService.Privileges)

    ''' <summary>
    ''' Method to set loggedin user to access from overall application.
    ''' </summary>
    ''' <param name="user"></param>
    ''' <remarks></remarks>
    Public Shared Sub SetLoggedinUser(ByVal user As IMSService.Users)
        _LoggedinUser = user
    End Sub

    Public Shared Sub SetUserPreviliges(ByVal lstPrevilig As List(Of IMSService.Privileges))
        _UserPreviliges = lstPrevilig
    End Sub

    Public Shared Function GetUserPreviliges() As List(Of IMSService.Privileges)
        Return _UserPreviliges
    End Function

    ''' <summary>
    ''' Method to get loggedin user ID
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLoggedinUserID() As String

        If _LoggedinUser IsNot Nothing Then
            Return _LoggedinUser.UserID
        Else
            Return 0
        End If

    End Function

    ''' <summary>
    ''' Method to get loggedin user.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetLoggedinUser() As IMSService.Users
        Return _LoggedinUser
    End Function

    ''' <summary>
    ''' Method to get user access right
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetUserAccessRight() As Integer

        If _LoggedinUser IsNot Nothing Then
            Return _LoggedinUser.AccessRight
        Else
            Return 0
        End If

    End Function

    Public Shared Sub Logout()

        _LoggedinUser = Nothing
        _UserPreviliges.Clear()

    End Sub


End Class
