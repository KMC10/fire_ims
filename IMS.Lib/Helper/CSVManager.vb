

Imports SLAF.DataAccess.DTO
Imports SLAF.Lib
Imports System.Xml
Imports System.Linq
Imports System.Collections.Generic
Imports System.Reflection

Public Class CSVManager
#Region "Member variables"

    Private schemaLocation As String = String.Empty
    Private fileLocation As String = String.Empty
    Private mvarFilename As String = String.Empty

#End Region

#Region "Constructor"
    Public Sub New(ByVal filePath As String, ByVal schemaPath As String)
        If ValidateFileLocations(filePath, schemaPath) Then
            Me.schemaLocation = schemaPath
            Me.fileLocation = filePath
        End If
    End Sub
#End Region

#Region "Public Methods"

    Public Function IsValidFile(ByRef validationMessage As String) As Boolean
        validationMessage = String.Empty
        Dim schemaColumns As List(Of SchemaColumn) = ReadSchemaFile()
        Dim lineEntries As List(Of String) = ReadCSVFile()

        If schemaColumns.Count = 0 Then
            validationMessage = "No column found in schema file."
            Return False
        End If

        If lineEntries.Count = 0 Then
            validationMessage = "CSV file contains no data."
            Return False
        End If

        If Not HasValidNumberOfColumn(schemaColumns.Count, lineEntries) Then
            validationMessage = "CSV file has invalid number of columns."
            Return False
        End If

        For Each lineEntry As String In lineEntries
            Dim columnIndex As Integer = -1
            Dim result As Boolean = CheckLineEntry(lineEntry, schemaColumns, columnIndex)
            If Not result Then
                Dim lineIndex As Integer = lineEntries.IndexOf(lineEntry) + 1
                validationMessage = String.Format("Invalid data at line : ({0}), column : ({1})", lineIndex.ToString(), columnIndex.ToString())
                Return False
            End If
        Next

        Return True
    End Function

    Public Function GetCSVData(Of T)() As List(Of T)

        Dim returnList As New List(Of T)()
        Dim lineEntries As List(Of String) = ReadCSVFile()

        For Each lineEntry As String In lineEntries
            returnList.Add(FillObject(Of T)(lineEntry))
        Next

        Return returnList

    End Function

#End Region

#Region "Private Methods"

    ''' <summary>
    ''' Method to validate file paths.
    ''' </summary>
    ''' <param name="filePath"></param>
    ''' <param name="schemaPath"></param>
    ''' <returns></returns>
    ''' 
    Private Function ValidateFileLocations(ByVal filePath As String, ByVal schemaPath As String) As Boolean
        If String.IsNullOrEmpty(filePath) Then
            Throw New CSVException("CSV file path is empty.")
        End If

        If String.IsNullOrEmpty(schemaPath) Then
            Throw New CSVException("Schema path is empty.")
        End If

        If Not System.IO.File.Exists(filePath) Then
            Throw New CSVException("CSV file not found.")
        End If

        If Not System.IO.File.Exists(schemaPath) Then
            Throw New CSVException("Schema file not found.")
        End If

        Return True
    End Function

    ''' <summary>
    ''' Method to read schema file.
    ''' </summary>
    ''' <returns></returns>
    Private Function ReadSchemaFile() As List(Of SchemaColumn)
        Dim columnList As New List(Of SchemaColumn)()
        Dim xDoc As New XmlDocument()
        Try
            xDoc.Load(Me.schemaLocation)
            Dim chileNodes As XmlNodeList = xDoc.SelectSingleNode("columns").ChildNodes
            For Each chileNode As XmlNode In chileNodes
                Dim schemaColumn As New SchemaColumn()
                If chileNode.Attributes("name") IsNot Nothing Then
                    schemaColumn.ColumnName = chileNode.Attributes("name").Value
                End If
                If chileNode.Attributes("type") IsNot Nothing Then
                    schemaColumn.ColumnType = chileNode.Attributes("type").Value
                End If
                columnList.Add(schemaColumn)
            Next
        Catch ex As Exception
            Throw New CSVException("Error while reading XML schema.", ex)
        Finally
            xDoc = Nothing
        End Try


        Return columnList
    End Function

    ''' <summary>
    ''' Method to read CSV file.
    ''' </summary>
    ''' <returns></returns>
    Private Function ReadCSVFile() As List(Of String)
        Return System.IO.File.ReadAllLines(fileLocation).ToList()
    End Function

    ''' <summary>
    ''' Method to check if csv file has valid number of columns.
    ''' </summary>
    ''' <returns></returns>
    Private Function HasValidNumberOfColumn(ByVal columnCount As Integer, ByVal lineEntries As List(Of String)) As Boolean
        For Each lineEntry As String In lineEntries
            Dim arTemp As String() = lineEntry.Split(","c)
            If arTemp.Length <> columnCount Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' Method to check the entries of each line
    ''' </summary>
    ''' <param name="lineEntry"></param>
    ''' <param name="columns"></param>
    ''' <param name="columnIndex"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckLineEntry(ByVal lineEntry As String, ByVal columns As List(Of SchemaColumn), ByRef columnIndex As Integer) As Boolean
        Dim result As Boolean = True
        columnIndex = -1
        Dim lineValues As String() = lineEntry.Split(","c)
        For i As Integer = 0 To lineValues.Length - 1
            columnIndex = i + 1
            Dim value As String = lineValues(i)
            result = CheckDataType(value, columns(i).ColumnType.ToLower())
            If Not result Then
                Exit For
            End If
        Next
        Return result
    End Function

    ''' <summary>
    ''' Method to check datatype of a value.
    ''' </summary>
    ''' <param name="value"></param>
    ''' <param name="dataType"></param>
    ''' <returns></returns>
    Private Function CheckDataType(ByVal value As String, ByVal dataType As String) As Boolean
        Dim result As Boolean = True
        Select Case dataType
            Case "int"
                Dim intValue As Integer = 0
                result = Integer.TryParse(value, intValue)
                Exit Select
            Case "double"
                Dim doubleValue As Double = 0
                result = Double.TryParse(value, doubleValue)
                Exit Select
            Case Else
                'for string no need to check data type.
                Exit Select
        End Select
        Return result
    End Function

    Private Function FillObject(Of T)(ByVal lineEntry As String) As T

        Dim lineValues As String() = lineEntry.Split(","c)
        Dim entityObject = Activator.CreateInstance(GetType(T))
        Dim properties As PropertyInfo() = GetType(T).GetProperties()
        Dim propertyCount As Integer = properties.Length

        For i As Integer = 0 To propertyCount - 1
            Dim propertyInfo As PropertyInfo = properties(i)
            Dim propertyValue As Object
            If (propertyInfo.PropertyType = GetType(String)) Then
                ' No need to check for valid input as it takes anything.
                propertyValue = Convert.ChangeType(lineValues(i), propertyInfo.PropertyType, System.Globalization.CultureInfo.InvariantCulture)
                propertyInfo.SetValue(entityObject, propertyValue, Nothing)
            Else
                ' Not every datatype other than string takes empty string as a valid input
                ' So we will skip assigning any value to the fileds which is not of type string and for which empty string was received.
                ' TODO: Need to checkl for valid input based on data types.
                If lineValues(i).Trim() <> String.Empty Then
                    propertyValue = Convert.ChangeType(lineValues(i), propertyInfo.PropertyType, System.Globalization.CultureInfo.InvariantCulture)
                    propertyInfo.SetValue(entityObject, propertyValue, Nothing)
                End If

            End If
        Next

        Return entityObject

    End Function

#Region "Internal Class"

    ''' <summary>
    ''' Class to denote each column.
    ''' </summary>
    Private Class SchemaColumn

        Private _columnName As String
        Public Property ColumnName() As String
            Get
                Return _columnName
            End Get
            Set(ByVal value As String)
                _columnName = value
            End Set
        End Property

        Private _columnType As String
        Public Property ColumnType() As String
            Get
                Return _columnType
            End Get
            Set(ByVal value As String)
                _columnType = value
            End Set
        End Property

    End Class



    Public Class CSVException
        Inherits Exception

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub

        Public Sub New(ByVal message As String, ByVal ex As Exception)
            MyBase.New(message, ex)
        End Sub

    End Class

#End Region

#End Region

End Class
