Public NotInheritable Class Converters

    Public Shared Function IncidentStatustoDescription(ByVal id As Integer) As String
        Select Case id
            Case Is = 1
                Return "Registered"
            Case Is = 2
                Return " Attended"
            Case Is = 3
                Return "Solved"
            Case Else
                Return "unknown"
        End Select
    End Function

End Class
