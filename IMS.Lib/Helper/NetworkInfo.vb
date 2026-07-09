Public Class NetworkInfo

    Private _IPAddress As String = String.Empty
    Private _MACAddress As String = String.Empty
    Private _HostName As String = String.Empty

    ''' <summary>
    ''' Get the value of IPAddress
    ''' </summary>
    Public Property IPAddress() As String
        Get
            Return _IPAddress
        End Get
        Set(value As String)
            _IPAddress = value
        End Set
    End Property

    ''' <summary>
    ''' Get the value of MACAddress
    ''' </summary>
    Public Property MACAddress() As String
        Get
            Return _MACAddress
        End Get
        Set(value As String)
            _MACAddress = value
        End Set
    End Property

    ''' <summary>
    ''' Get the value of HostName
    ''' </summary>
    Public Property HostName() As String
        Get
            Return _HostName
        End Get
        Set(value As String)
            _HostName = value
        End Set
    End Property

    Private _InterfaceName As String

    ''' <summary>
    ''' Get the value of InterfaceName
    ''' </summary>
    Public Property InterfaceName() As String
        Get
            Return _InterfaceName
        End Get
        Set(value As String)
            _InterfaceName = value
        End Set
    End Property

    Private _InterfaceDescription As String

    ''' <summary>
    ''' Get the value of InterfaceDescription
    ''' </summary>
    Public Property InterfaceDescription() As String
        Get
            Return _InterfaceDescription
        End Get
        Set(value As String)
            _InterfaceDescription = value
        End Set
    End Property

    Private _protocol As String

    ''' <summary>
    ''' Get the value of Protocol
    ''' </summary>
    Public Property Protocol() As String
        Get
            Return _protocol
        End Get
        Set(value As String)
            _protocol = value
        End Set
    End Property

    Private _gatewayAddress As String

    ''' <summary>
    ''' Get the value of GatewayAddress
    ''' </summary>
    Public Property GatewayAddress() As String
        Get
            Return _gatewayAddress
        End Get
        Set(value As String)
            _gatewayAddress = value
        End Set
    End Property

    Private _PublicIPaddress As String

    ''' <summary>
    ''' Get the value of publicIpAddress
    ''' </summary>
    Public Property publicIpAddress() As String
        Get
            Return _PublicIPaddress
        End Get
        Set(value As String)
            _PublicIPaddress = value
        End Set
    End Property

End Class
