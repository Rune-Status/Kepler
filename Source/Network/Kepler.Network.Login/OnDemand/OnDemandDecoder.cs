namespace Kepler.Network.Login.OnDemand
{
    using System;
    using System.Net.Sockets;

    using Kepler.Network.Message.Decoder;

    public class OnDemandDecoder : IByteMessageDecoder
    {
        public void Decode(TcpClient tcpClient)
        {
            throw new NotImplementedException();
        }
    }
}