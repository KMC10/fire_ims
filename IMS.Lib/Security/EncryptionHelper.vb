
Imports System
Imports System.Security.Cryptography
Imports System.Text

Public Class EncryptionHelper

    Public Shared Function GetMd5Hash(md5Hash As MD5, input As String) As String

        ' Convert the input string to a byte array and compute the hash. 
        Dim data As Byte() = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input))

        ' Create a new Stringbuilder to collect the bytes 
        ' and create a string.
        Dim sBuilder As New StringBuilder()

        ' Loop through each byte of the hashed data  
        ' and format each one as a hexadecimal string. 
        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next

        ' Return the hexadecimal string. 
        Return sBuilder.ToString()
    End Function

    ' Verify a hash against a string. 
    Public Shared Function VerifyMd5Hash(md5Hash As MD5, input As String, hash As String) As Boolean
        ' Hash the input. 
        Dim hashOfInput As String = GetMd5Hash(md5Hash, input)

        ' Create a StringComparer an compare the hashes.
        Dim comparer As StringComparer = StringComparer.OrdinalIgnoreCase

        If 0 = comparer.Compare(hashOfInput, hash) Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
