Imports System.Reflection
Imports System.Data.SqlClient
Imports System.Linq

Namespace DBHelper

    Public Class KeyGen

        Private Const STR_FrameworkXObjectSpaceDataSchemaPrimaryKeyAttribute As String = "FrameworkX.ObjectSpace.Data.Schema.PrimaryKeyAttribute"


        Public Shared Function GetAutoKey(ByVal obj As Type, ByVal pk As String) As Integer
            Dim strKeyFiled As String = pk

            Dim sql As String = String.Format("SELECT MAX({0}) + 1 FROM {1}",
                                    strKeyFiled,
                                    obj.Name)

            Dim db As New DataAccess.DAL.DataAcessManager
            Dim cn As New SqlConnection(db.DBConnectionString)

            cn.Open()

            Dim cmd As New SqlCommand() With {.CommandType = CommandType.Text, .Connection = cn, .CommandText = sql}

            Dim objChk As Object = cmd.ExecuteScalar
            If objChk Is DBNull.Value Then
                cn.Close()
                Return 1
            Else
                cn.Close()
                Return CType(objChk, Int32)
            End If
        End Function

    End Class

End Namespace


