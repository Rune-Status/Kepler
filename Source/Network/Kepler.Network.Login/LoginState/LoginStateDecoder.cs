namespace Kepler.Network.Login.LoginState
{
    using System.Net.Sockets;

    using Kepler.Common.Extensions;
    using Kepler.Network.Message.Decoder;

    public class LoginStateDecoder : IByteMessageDecoder
    {
        public void Decode(TcpClient tcpClient)
        {
            int value = tcpClient.ReadUnsignedMedium();

            if (value != 0)
            {
                tcpClient.Close();
            }
        }
    }
}