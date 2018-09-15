namespace Kepler.Network.Login.VersionValidation
{
    using System.Net.Sockets;

    using Kepler.Common.Extensions;
    using Kepler.Network.Message.Decoder;
    using Kepler.Network.Message.Encoder;

    public class VersionValidationDecoder : IByteMessageDecoder
    {
        private readonly IByteMessageEncoder updateStatusEncoder;

        public VersionValidationDecoder(IByteMessageEncoder updateStatusEncoder)
        {
            this.updateStatusEncoder = updateStatusEncoder;
        }

        public void Decode(TcpClient tcpClient)
        {
            int clientVersion = tcpClient.ReadInt32();

            if (VersionIsCurrent(clientVersion))
            {
                SendUpdateStatus(tcpClient);
            }
        }

        private void SendUpdateStatus(TcpClient tcpClient)
        {
            updateStatusEncoder.Encode(tcpClient);
        }

        private bool VersionIsCurrent(int clientVersion)
        {
            return clientVersion == 172; // TODO Pull this from configuration
        }
    }
}