
Public Class IMSHerlper

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function GetRandomLoanReferenceNumber() As String

        Dim charList = New String() {"A", "B", "C", "D", "E", "F",
                                            "G", "H", "I", "J", "K", "L", "M", "N", "O",
                                             "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                            "1", "2", "3", "4", "5", "6", "7", "8", "9", "0"}

        Dim refNumber As String = String.Empty
        Dim index As Integer
        Dim objRandom As New Random()

        For i As Integer = 0 To 11

            index = objRandom.Next(0, charList.Length - 1)
            refNumber += charList(index)

        Next

        Return refNumber

    End Function


 

End Class
