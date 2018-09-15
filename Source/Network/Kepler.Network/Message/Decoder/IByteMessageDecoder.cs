namespace Kepler.Network.Message.Decoder
{
    using System;
    using System.Net.Sockets;

    public interface IByteMessageDecoder
    {
        void Decode(TcpClient tcpClient);
    }
}