namespace Kepler.Network.Message.Encoder
{
    using System.Net.Sockets;

    public interface IByteMessageEncoder
    {
        void Encode(TcpClient tcpClient);
    }
}