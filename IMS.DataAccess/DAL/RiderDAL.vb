Imports FrameworkX.ObjectSpace
Imports System.Linq

Namespace DAL

    Partial Public Class DataAcessManager

        ''' <summary>
        ''' Load riders by firesation id and appliance id
        ''' </summary>
        ''' <param name="FireStationId">FireStationId</param>
        ''' <param name="ApplianceID">ApplianceID</param>
        ''' <returns>List of rider</returns>
        ''' <remarks></remarks>
        Public Function LoadRiderByApplianceAndStationID(ByVal FireStationId As Integer, ByVal ApplianceID As Integer) As List(Of DTO.ApplianceRider)

            Dim filter As String = String.Format(" ApplianceID IN (SELECT ApplianceID FROM Appliance WHERE ApplianceID = {0} AND StationID = {1} )", ApplianceID, FireStationId)

           Try
                Return Me.GetFilteredApplianceRider(filter).Cast(Of DTO.ApplianceRider).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load riders by appliance id
        ''' </summary>
        ''' <param name="ApplianceID">ApplianceID</param>
        ''' <returns>List of rider</returns>
        ''' <remarks></remarks>
        Public Function LoadRiderByApplianceID(ByVal ApplianceID As Integer) As List(Of DTO.ApplianceRider)

            Dim filter As String = String.Format("ApplianceID = {0}", ApplianceID)

            Try
                Return Me.GetFilteredApplianceRider(filter).Cast(Of DTO.ApplianceRider).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        ''' <summary>
        ''' Load all Rider whose are involved in a partcular Incident
        ''' By IncidentId and ApplianceID
        ''' </summary>
        ''' <param name="IncidentID">IncidentID</param>
        ''' <param name="ApplianceID">ApplianceID</param>
        ''' <returns>List of Rider as Employee</returns>
        ''' <remarks></remarks>
        Public Function LoadOnEventRider(ByVal IncidentID As Integer, ByVal ApplianceID As Integer) As List(Of DTO.Employee)

            Dim filter As String = String.Format(" IsDeleted = 'false' AND EmployeeID IN ( SELECT EmployeeID FROM ApplianceRider WHERE ApplianceID IN (SELECT ApplianceID FROM AssignedAppliance WHERE IsDeleted = 'false' AND IncidentID = {0} AND ApplianceID = {1}))", IncidentID, ApplianceID)

            Try
                Return Me.GetFilteredEmployee(filter).Cast(Of DTO.Employee).ToList()
            Catch ex As Exception
                Throw ex
            End Try

        End Function

    End Class

End Namespace

