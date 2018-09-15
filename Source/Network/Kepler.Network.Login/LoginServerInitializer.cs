namespace Kepler.Network.Login
{
    using System;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    using Kepler.Network.Message.Decoder;

    public class LoginServerInitializer : ILoginServerInitializer
    {
        private const int PortNumber = 43594; //TODO Pull this from configuration

        private readonly IByteMessageDecoder handshakeDecoder;

        public LoginServerInitializer(IByteMessageDecoder handshakeDecoder)
        {
            this.handshakeDecoder = handshakeDecoder;
        }

        public void InitializeLoginServer()
        {
            TcpListener tcpListener = CreateTcpListener();

            tcpListener.Start();

            Console.WriteLine("Login server now listening for connections.");

            while (true)
            {
                TcpClient tcpClient = tcpListener.AcceptTcpClient();

                Task.Run(() => DecodeHandshake(tcpClient));
            }
        }

        private TcpListener CreateTcpListener()
        {
            return TcpListener.Create(PortNumber);
        }

        private void DecodeHandshake(TcpClient tcpClient)
        {
            handshakeDecoder.Decode(tcpClient);
        }
    }
}