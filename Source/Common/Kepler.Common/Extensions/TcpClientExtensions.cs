namespace Kepler.Common.Extensions
{
    using System;
    using System.Net.Sockets;

    public static class TcpClientExtensions
    {
        public static int ReadByte(this TcpClient tcpClient)
        {
            return tcpClient.GetStream().ReadByte();
        }

        public static int ReadInt32(this TcpClient tcpClient)
        {
            var buffer = new byte[sizeof(int)];

            Read(tcpClient, buffer, true);

            return BitConverter.ToInt32(buffer, 0);
        }

        public static void Write<T>(this TcpClient tcpClient, T value)
        {
            Type type = typeof(T);

            byte[] buffer;

            if (type == typeof(int))
            {
                var writeValue = value as int?;

                buffer = BitConverter.GetBytes(writeValue ?? throw new ArgumentNullException());
            }
            else
            {
                throw new NotSupportedException();
            }

            tcpClient.GetStream().Write(buffer, 0, buffer.Length);
        }

        private static void Read(TcpClient tcpClient, byte[] buffer, bool readAsBigEndian)
        {
            tcpClient.GetStream().Read(buffer, 0, buffer.Length);

            if (readAsBigEndian)
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(buffer);
                }
            }
        }
    }
}