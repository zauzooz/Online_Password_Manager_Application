using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void Main()
        {
            Executive();
        }
        private void Authentication()
        { }
        private static void Executive()
        {
            // create a endpoint
            IPHostEntry ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostEntry.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddress, 15000);

            // creat socket
            Socket socket = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            // bind the endpoint
            socket.Bind(ipEndPoint);

            socket.ReceiveTimeout = 10;
            socket.SendTimeout = 10;

            socket.Listen(socket.ReceiveTimeout);

            while (true)
            {
                Console.WriteLine("Password Manager Server");
                break;
            }    

            socket.Close();
        }
    }
}