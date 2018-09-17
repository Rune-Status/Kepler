namespace Kepler.Network.Login.Handshake
{
    using System;
    using System.Net.Sockets;

    using Kepler.Common.Extensions;
    using Kepler.Network.Message.Decoder;

    public class HandshakeDecoder : IByteMessageDecoder
    {
        private readonly IByteMessageDecoder versionValidationDecoder;

        public HandshakeDecoder(IByteMessageDecoder versionValidationDecoder)
        {
            this.versionValidationDecoder = versionValidationDecoder;
        }

        public void Decode(TcpClient tcpClient)
        {
            int handshakeTypeValue = tcpClient.ReadByte();

            if (Enum.TryParse(handshakeTypeValue.ToString(), out HandshakeType result))
            {
                switch (result)
                {
                    case HandshakeType.Login:
                        throw new NotImplementedException();
                    case HandshakeType.OnDemand:
                        ValidateVersion(tcpClient);
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid handshake opcode received. Closing connection.");
                tcpClient.Close();
            }
        }

        private void ValidateVersion(TcpClient tcpClient)
        {
            versionValidationDecoder.Decode(tcpClient);
        }
    }
}