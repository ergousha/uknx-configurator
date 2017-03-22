namespace uKNX_Configurator
{
    public class GatewayItem
    {
        public string Mac { get; set; }
        public string IP { get; set; }
        public string Model { get; set; }
        public string Firmware { get; set; }
        public bool DhcpEnabled { get; set; }
        public string StaticIP { get; set; }
        public string StaticSubnet { get; set; }
        public string StaticGateway { get; set; }
        public string StaticDns1 { get; set; }
        public string StaticDns2 { get; set; }
        public bool LocalUdpEnabled { get; set; }
        public bool BroadcastKnx { get; set; }

    }
}
