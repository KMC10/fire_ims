Imports System.Net.NetworkInformation
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Net.Sockets


Public NotInheritable Class NetworkUtil

    ''' <summary>
    ''' To get Network Information.
    ''' </summary>
    ''' <returns></returns>
    Public Function GetNetworkInfo() As NetworkInfo
        Dim netinfo As New NetworkInfo()

        For Each inter As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
            If inter.OperationalStatus = OperationalStatus.Up Then
                If inter.NetworkInterfaceType = NetworkInterfaceType.Ethernet Or inter.NetworkInterfaceType = NetworkInterfaceType.Wireless80211 Then
                    netinfo.InterfaceName = inter.Name
                    netinfo.InterfaceDescription = inter.Description
                    netinfo.MACAddress = inter.GetPhysicalAddress().ToString()
                    netinfo.Protocol = "Desktop client"
                    netinfo.GatewayAddress = "0.0.0.0"
                    netinfo.publicIpAddress = GetExternalIPAddress()
                    netinfo.IPAddress = GetIP()
                    netinfo.HostName = System.Net.Dns.GetHostName()

                    Return netinfo
                End If
            End If
        Next

        Return netinfo
    End Function

    Private Function GetExternalIPAddress() As String
        Dim myIPHostEntry As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())

        For Each myIPAddress As IPAddress In myIPHostEntry.AddressList
            Dim ipBytes As Byte() = myIPAddress.GetAddressBytes()

            If myIPAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
                If Not IsPrivateIP(myIPAddress) Then
                    Return myIPAddress.ToString()
                End If
            End If
        Next

        Return Nothing
    End Function

    Public Shared Function GetIP()
        Dim ip4Address = String.Empty
        For Each ipa As IPAddress In Dns.GetHostAddresses(Dns.GetHostName())
            If IsInterNetwork(ipa) Then
                ip4Address = ipa.ToString
                Exit For
            End If
        Next
        Return ip4Address
    End Function

    Private Shared Function IsInterNetwork(ipa As IPAddress) As Boolean
        Return ipa.AddressFamily = AddressFamily.InterNetwork
    End Function

    Private Function IsPrivateIP(myIPAddress As IPAddress) As Boolean
        If myIPAddress.AddressFamily = System.Net.Sockets.AddressFamily.InterNetwork Then
            Dim ipBytes As Byte() = myIPAddress.GetAddressBytes()

            ' 10.0.0.0/24 
            If ipBytes(0) = 10 Then
                Return True
                ' 172.16.0.0/16
            ElseIf ipBytes(0) = 172 AndAlso ipBytes(1) = 16 Then
                Return True
                ' 192.168.0.0/16
            ElseIf ipBytes(0) = 192 AndAlso ipBytes(1) = 168 Then
                Return True
                ' 169.254.0.0/16
            ElseIf ipBytes(0) = 169 AndAlso ipBytes(1) = 254 Then
                Return True
            End If
        End If

        Return False
    End Function

End Class

