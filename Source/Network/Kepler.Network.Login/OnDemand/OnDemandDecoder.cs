namespace Kepler.Network.Login.OnDemand
{
    using System;
    using System.Net.Sockets;

    using Kepler.Common.Extensions;
    using Kepler.Network.Message.Decoder;

    public class OnDemandDecoder : IByteMessageDecoder
    {
        private readonly IByteMessageDecoder loginStateDecoder;

        public OnDemandDecoder(IByteMessageDecoder loginStateDecoder)
        {
            this.loginStateDecoder = loginStateDecoder;
        }

        public void Decode(TcpClient tcpClient)
        {
            int opcode = tcpClient.ReadByte();

            if (Enum.TryParse(opcode.ToString(), out OnDemandOpcode result))
            {
                switch (result)
                {
                    case OnDemandOpcode.FileRequest:
                        throw new NotImplementedException();
                    case OnDemandOpcode.PriorityFileRequest:
                        throw new NotImplementedException();
                    case OnDemandOpcode.ClientLoggedIn:
                    case OnDemandOpcode.ClientLoggedOut:
                        loginStateDecoder.Decode(tcpClient);
                        Console.WriteLine(tcpClient.ReadByte());
                        break;
                    case OnDemandOpcode.EncryptionKeyUpdate:
                        throw new NotImplementedException();
                    case OnDemandOpcode.ClientConnected:
                        throw new NotImplementedException();
                    case OnDemandOpcode.ClientDisconnected:
                        throw new NotImplementedException();
                }
            }
        }
    }
}