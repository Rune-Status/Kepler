namespace Kepler.Network.Login.UpdateStatus
{
    using System.Net.Sockets;

    using Kepler.Common.Extensions;
    using Kepler.Network.Message.Decoder;
    using Kepler.Network.Message.Encoder;

    public class UpdateStatusEncoder : IByteMessageEncoder
    {
        private readonly IByteMessageDecoder onDemandDecoder;

        public UpdateStatusEncoder(IByteMessageDecoder onDemandDecoder)
        {
            this.onDemandDecoder = onDemandDecoder;
        }

        public void Encode(TcpClient tcpClient)
        {
            tcpClient.Write((int) UpdateStatus.Ok); //TODO Handle other update status types.

            InvokeOnDemandService(tcpClient);
        }

        private void InvokeOnDemandService(TcpClient tcpClient)
        {
            onDemandDecoder.Decode(tcpClient);
        }
    }
}