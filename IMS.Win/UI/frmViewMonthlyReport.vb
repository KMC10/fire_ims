
Imports IMS.Lib
Imports System.Globalization
Imports IMS.Win.IMSService
Imports CrystalDecisions.CrystalReports.Engine

Public Class frmViewMonthlyReport
    Inherits BaseForm

#Region "Member Variable"

    Private _proxy As New IMSService.IMSServices

#End Region

#Region "User Defined Methods"

    ''' <summary>
    ''' Method to load years
    ''' </summary>
    ''' <remarks></remarks>
    Protected Sub LoadYears()
        Dim tblYear As New DataTable

        tblYear.Columns.Add(IMSConstants.Common.Year)

        For i = Now.Date.Year To CInt(IMSConstants.Settings.EndYear) Step -1
            Dim rows As DataRow = tblYear.NewRow
            rows(IMSConstants.Common.Year) = i
            tblYear.Rows.Add(rows)
        Next

        With Me.cmbYear
            .NullText = IMSConstants.Common.SelectString
            .DataSource = tblYear
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
            .SelectedText = Now.Date.Year
        End With

    End Sub

    ''' <summary>
    ''' Method to load months
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMonths()
        Dim lstLoanStatus As New Dictionary(Of Integer, String)()
        Dim table As New DataTable
        table.Columns.Add(IMSConstants.FieldConstants.ID)
        table.Columns.Add(IMSConstants.Common.Month)

        Dim itemValues As Array = System.Enum.GetValues(GetType(IMSEnums.Months))
        Dim itemNames As Array = System.Enum.GetNames(GetType(IMSEnums.Months))

        For Each enumValue As Integer In [Enum].GetValues(GetType(IMSEnums.Months))
            Dim dr As DataRow = table.NewRow()
            dr(IMSConstants.FieldConstants.ID) = enumValue
            dr(IMSConstants.Common.Month) = [Enum].GetName(GetType(IMSEnums.Months), enumValue)
            table.Rows.Add(dr)
        Next

        With cmbMonth
            .DisplayMember = IMSConstants.Common.Month
            .ValueMember = IMSConstants.FieldConstants.ID
            .DataSource = table
            .SelectedText = [Enum].GetName(GetType(IMSEnums.Months), Date.Now.Month)

            .DisplayLayout.Bands(0).Columns(IMSConstants.FieldConstants.ID).Hidden = True
            .NullText = IMSConstants.Common.SelectString
            .DisplayLayout.AutoFitStyle = Infragistics.Win.UltraWinGrid.AutoFitStyle.ResizeAllColumns
        End With

    End Sub

    ''' <summary>
    ''' Method to Get Month Name.
    ''' </summary>
    ''' <param name="monthNum"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetMonthName(ByVal monthNum As Integer) As String

        Try
            Dim strDate As New DateTime(1, monthNum, 1)
            Return (strDate.ToString("MMM")).ToUpper()
        Catch ex As Exception
        End Try

    End Function

    ''' <summary>
    ''' Method to load monthly fire services info
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadMonthlyInfo()

        Dim lstMonthlyReport As List(Of MonthlyReport) = GetMonthlyReportListWithFixedStation()

        If lstMonthlyReport.Count > 0 Then

            Dim doc As ReportDocument = New ReportDocument()
            doc.Load(Application.StartupPath + "/Reports/rptMonthlyFinal.rpt")

            Dim headerSection = doc.ReportDefinition.Sections("Section1")
            If Not IsNothing(headerSection) Then

                Dim txtTitleOfMonthlyReport = CType(headerSection.ReportObjects("txtTitleOfMonthlyReport"), CrystalDecisions.CrystalReports.Engine.TextObject)
                If Not IsNothing(txtTitleOfMonthlyReport) Then
                    txtTitleOfMonthlyReport.Text = "STATISTICS FOR THE MONTH OF" + " " + MonthName(cmbMonth.Value).ToUpper() + "  " + cmbYear.Value.ToString()
                End If
            End If

            doc.SetDataSource(lstMonthlyReport)

            rptViewerMonthlyReport.ReportSource = doc
            rptViewerMonthlyReport.Refresh()

            ''(Section 1 - Header block)

            'Dim headerSection = doc.ReportDefinition.Sections("Section1")
            'If Not IsNothing(headerSection) Then
            '    SetCommonLabels(headerSection, primaryStation, IncidentRegister, lstIncidentTypes, stationNames)
            'End If

        End If

    End Sub

    ''' <summary>
    ''' Method to Get the From Date.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetFromDateTime() As DateTime

        Dim startDate As DateTime = Nothing

        If Not String.IsNullOrEmpty(cmbMonth.Value) And Not String.IsNullOrEmpty(cmbYear.Value) Then
            Dim year As String = cmbYear.Value
            Dim month As String = cmbMonth.Value
            Dim start As DateTime = Date.Parse(month + "/1/" + year)
            startDate = GetFromDate(start)
        End If

        Return startDate

    End Function

    ''' <summary>
    ''' Method to Get The TO Date
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetToDateTime() As Date

        Dim endDate As DateTime = Nothing

        If Not String.IsNullOrEmpty(cmbMonth.Value) And Not String.IsNullOrEmpty(cmbYear.Value) Then

            Dim startDate As DateTime = GetFromDateTime()
            endDate = LastDayOfMonth(startDate)

        End If

        Return endDate

    End Function

    ''' <summary>
    ''' Method to Get Last date of Month
    ''' </summary>
    ''' <param name="aDate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function LastDayOfMonth(aDate As DateTime) As Date
        Return New DateTime(aDate.Year, _
                            aDate.Month, _
                            DateTime.DaysInMonth(aDate.Year, aDate.Month))
    End Function

    ''' <summary>
    ''' Method to IncidentTypeIncident in Occurrrence Book
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetIncidentListOfOccurrenceBook() As List(Of IncidentTypeIncident)

        Dim startDate As DateTime = GetFromDateTime()
        Dim endDate As DateTime = GetToDateTime()

        Dim sql As String = IMSConstants.FieldConstants.IncidentID & " In ( select " & _
        IMSConstants.FieldConstants.IncidentID & "  from " & IMSConstants.TableNames.IncidentRegister & _
        " where " & IMSConstants.FieldConstants.IncidentStatus & " = " & CInt(IMSEnums.IncidentStatus.Resolved) & _
        " and " & IMSConstants.FieldConstants.IncidentID & " In ( select " & _
            IMSConstants.FieldConstants.IncidentID & "  from " & IMSConstants.TableNames.OccurrenceBook & _
            " where " & IMSConstants.FieldConstants.ReportDate & " between '" & startDate.ToString(IMSConstants.AppConstants.DateFormatToQuery) & "' and '" & endDate.ToString(IMSConstants.AppConstants.DateFormatToQuery) & _
            "' ) ) order by " & IMSConstants.FieldConstants.IncidentTypeID & "  asc "

        Dim lstIncidentTypeIncident As List(Of IncidentTypeIncident) = _proxy.GetFilteredIncidentTypeIncident(sql).Cast(Of IncidentTypeIncident).ToList()

        Return lstIncidentTypeIncident

    End Function

    ''' <summary>
    ''' Method to Get StationIncident List Of Occurrence Book.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetStationIncidentLisOfOccurrenceBook() As List(Of StationIncident)

        Dim startDate As DateTime = GetFromDateTime()
        Dim endDate As DateTime = GetToDateTime()

        Dim sql As String = IMSConstants.FieldConstants.IncidentID & " In ( select " & _
            IMSConstants.FieldConstants.IncidentID & "  from " & IMSConstants.TableNames.OccurrenceBook & _
            " where " & IMSConstants.FieldConstants.ReportDate & " between '" & startDate & "' and '" & endDate & "' ) "

        Dim lstStationIncident As List(Of StationIncident) = _proxy.GetFilteredStationIncident(sql).Cast(Of StationIncident).ToList()

        Return lstStationIncident

    End Function

    ''' <summary>
    ''' Method to Get (Only Primary Station) StationIncident List Of Occurrence Book.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetPrimaryStationIncidentLisOfOccurrenceBook() As List(Of StationIncident)

        Dim startDate As DateTime = GetFromDateTime()
        Dim endDate As DateTime = GetToDateTime()

        Dim sql As String = IMSConstants.FieldConstants.IsPrimaryStation & " = " & CInt(IMSEnums.IsPrimaryStation.Yes) & " and " & IMSConstants.FieldConstants.IncidentID & " In ( select " & _
            IMSConstants.FieldConstants.IncidentID & "  from " & IMSConstants.TableNames.OccurrenceBook & _
            " where " & IMSConstants.FieldConstants.ReportDate & " between '" & GetFromDate(startDate).ToString(IMSConstants.AppConstants.DateFormatToQuery) & "' and '" & GetToDate(endDate).ToString(IMSConstants.AppConstants.DateFormatToQuery) & "' ) "

        Dim lstStationIncident As List(Of StationIncident) = _proxy.GetFilteredStationIncident(sql).Cast(Of StationIncident).ToList()

        Return lstStationIncident

    End Function

    ''' <summary>
    ''' Method to Get Monthly Report list.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    'Private Function GetMonthlyReportList() As List(Of MonthlyReport)

    '    Dim lstIncidentCategory As List(Of IncidentCategory) = CommonFunction.GetAllActiveIncidentCategory()
    '    Dim lstStation As List(Of FireStation) = CommonFunction.GetAllActiveFireStation()
    '    Dim lstStationFiltered As New List(Of FireStation)

    '    Dim lstIncidentTypes As List(Of IncidentType) = CommonFunction.GetAllActiveIncidentTypes()
    '    Dim lstIncidentTypesFiltered As New List(Of IncidentType)

    '    Dim lstIncidentTypeIncident As List(Of IncidentTypeIncident) = GetIncidentLisOfOccurrenceBook()
    '    Dim lstIncidentTypeIncidentFiltered As New List(Of IncidentTypeIncident)

    '    ''Take a look (TODO) - Here taking only Primary station related with the incident. If need all the stations related with Incident then take second function.
    '    Dim lstStationIncident As List(Of StationIncident) = GetPrimaryStationIncidentLisOfOccurrenceBook() ' GetStationIncidentLisOfOccurrenceBook()
    '    Dim lstStationIncidentFiltered As New List(Of StationIncident)

    '    ''Create List (Output list)
    '    Dim lstMonthlyReport As New List(Of MonthlyReport)
    '    Dim objMonthlyReport As New MonthlyReport()

    '    If lstIncidentCategory.Count > 0 Then

    '        For Each objCategory As IncidentCategory In lstIncidentCategory

    '            lstIncidentTypesFiltered = lstIncidentTypes.FindAll(Function(x) x.CategoryID = objCategory.CategoryID)

    '            If lstIncidentTypesFiltered.Count > 0 Then

    '                For Each objType As IncidentType In lstIncidentTypesFiltered

    '                    objMonthlyReport = New MonthlyReport()

    '                    With objMonthlyReport
    '                        .IncidentCategory = objCategory.CategoryName
    '                        .IncidentTypeCode = objType.IncidentTypeCode
    '                        .IncidentTypeDescription = objType.IncidentTypeDescription

    '                        lstIncidentTypeIncidentFiltered = lstIncidentTypeIncident.FindAll(Function(x) x.IncidentTypeID = objType.IncidentTypeID)
    '                        If lstIncidentTypeIncidentFiltered.Count > 0 Then

    '                            For Each objIncidentTypeIncident As IncidentTypeIncident In lstIncidentTypeIncidentFiltered

    '                                lstStationIncidentFiltered = lstStationIncident.FindAll(Function(x) x.IncidentID = objIncidentTypeIncident.IncidentID)

    '                                ''ADD to output list (with incidnet ID and station)
    '                                For Each objStationIncident As StationIncident In lstStationIncidentFiltered

    '                                    lstStationFiltered = lstStation.FindAll(Function(x) x.StationID = objStationIncident.StationID)
    '                                    If lstStationFiltered.Count > 0 Then
    '                                        .Station = lstStationFiltered(0).StationName
    '                                    Else
    '                                        .Station = String.Empty
    '                                    End If

    '                                    .IncidentCount = 1

    '                                    lstMonthlyReport.Add(objMonthlyReport) ' adding at output list.

    '                                Next
    '                            Next
    '                        End If
    '                    End With
    '                Next
    '            End If
    '        Next
    '    End If

    '    Return lstMonthlyReport

    'End Function


    Private Function GetMonthlyReportListWithFixedStation() As List(Of MonthlyReport)

        Dim lstIncidentCategory As List(Of IncidentCategory) = CommonFunction.GetAllActiveIncidentCategory()
        Dim lstStation As List(Of FireStation) = CommonFunction.GetAllActiveFireStation()
        Dim lstStationFiltered As New List(Of FireStation)

        Dim lstIncidentTypes As List(Of IncidentType) = CommonFunction.GetAllActiveIncidentTypes()
        Dim lstIncidentTypesFiltered As New List(Of IncidentType)

        Dim lstIncidentTypeIncident As List(Of IncidentTypeIncident) = GetIncidentListOfOccurrenceBook()
        Dim lstIncidentTypeIncidentFiltered As New List(Of IncidentTypeIncident)

        ''Take a look (TODO) - Here taking only Primary station related with the incident. If need all the stations related with Incident then take second function.
        Dim lstStationIncident As List(Of StationIncident) = GetPrimaryStationIncidentLisOfOccurrenceBook() ' GetStationIncidentLisOfOccurrenceBook()
        Dim lstStationIncidentFiltered As New List(Of StationIncident)

        ''Create List (Output list)
        Dim lstMonthlyReport As New List(Of MonthlyReport)
        Dim objMonthlyReport As New MonthlyReport()

        If lstIncidentCategory.Count > 0 Then

            For Each objCategory As IncidentCategory In lstIncidentCategory     '' Take category wise

                lstIncidentTypesFiltered = lstIncidentTypes.FindAll(Function(x) x.CategoryID = objCategory.CategoryID)

                If lstIncidentTypesFiltered.Count > 0 Then

                    For Each objType As IncidentType In lstIncidentTypesFiltered ''Take Type wise

                        objMonthlyReport = New MonthlyReport()

                        With objMonthlyReport
                            .IncidentCategory = objCategory.CategoryName
                            .IncidentTypeCode = objType.IncidentTypeCode
                            .IncidentTypeDescription = objType.IncidentTypeDescription

                            lstIncidentTypeIncidentFiltered = lstIncidentTypeIncident.FindAll(Function(x) x.IncidentTypeID = objType.IncidentTypeID)

                            .IncidentCount = lstIncidentTypeIncidentFiltered.Count

                            '' TODO : Now calculate for Station.

                            If lstIncidentTypeIncidentFiltered.Count > 0 Then

                                For Each objIncidentTypeIncident As IncidentTypeIncident In lstIncidentTypeIncidentFiltered

                                    '' TODO : taking specific type all station incident id list.
                                    lstStationIncidentFiltered = lstStationIncident.FindAll(Function(x) x.IncidentID = objIncidentTypeIncident.IncidentID)

                                    ''ADD to output list (with incidnet ID and station)
                                    For Each objStationIncident As StationIncident In lstStationIncidentFiltered

                                        Dim count As Integer = 0

                                        lstStationFiltered = lstStation.FindAll(Function(x) x.StationID = objStationIncident.StationID)
                                        If lstStationFiltered.Count > 0 Then

                                            ' .Station = lstStationFiltered(0).StationName
                                            ''TODO : Add this incident under a station (under specific station)

                                            Select Case objStationIncident.StationID
                                                Case CInt(IMSEnums.Station.MBN)
                                                    .MBN += 1

                                                Case CInt(IMSEnums.Station.LOB)
                                                    .LOB += 1

                                                Case CInt(IMSEnums.Station.PPK)
                                                    .PPK += 1

                                                Case CInt(IMSEnums.Station.MNZ)
                                                    .MNZ += 1

                                                Case CInt(IMSEnums.Station.MTS)
                                                    .MTS += 1

                                                Case CInt(IMSEnums.Station.STKI)
                                                    .STKI += 1

                                                Case CInt(IMSEnums.Station.NHL)
                                                    .NHL += 1

                                                Case Else
                                                    ''Console.WriteLine("You typed something else")
                                            End Select

                                        End If

                                        'lstMonthlyReport.Add(objMonthlyReport) ' adding at output list.

                                    Next
                                Next

                            End If

                        End With

                        lstMonthlyReport.Add(objMonthlyReport) ' adding at output list.

                    Next
                End If
            Next
        End If

        Return lstMonthlyReport

    End Function

#End Region

#Region "Event Handlers"

    Private Sub frmViewMonthlyReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            MyBase.SetSecurity(Me)

            Me.LoadYears()
            Me.LoadMonths()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try
    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click

        Try
            Me.LoadMonthlyInfo()
        Catch ex As Exception
            Me.WriteLog(ex)
            Me.DisplayError(IMS.Lib.IMSConstants.ExceptionMessage.Message)
        End Try

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

End Class