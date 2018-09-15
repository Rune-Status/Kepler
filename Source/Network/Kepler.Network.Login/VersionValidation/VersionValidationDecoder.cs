namespace Kepler.Network.Login.VersionValidation
{
    using System;
    using System.Net.Sockets;

    using Kepler.Common.Extensions;
    using Kepler.Network.Message.Decoder;

    public class VersionValidationDecoder : IByteMessageDecoder
    {
        public void Decode(TcpClient tcpClient)
        {
            int clientVersion = tcpClient.ReadInt32();

            if (VersionIsCurrent(clientVersion))
            {
                throw new NotImplementedException();
            }
        }

        private bool VersionIsCurrent(int clientVersion)
        {
            return clientVersion == 172; // TODO Pull this from configuration
        }
    }
}