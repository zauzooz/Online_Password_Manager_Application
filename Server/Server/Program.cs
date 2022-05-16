using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Data.SqlClient;
namespace Server
{
    class Program
    {
        SqlConnection sqlConnection = null;
        static private IPAddress ipAddress = null;
        static private int PORT = 12345;
        static private IPEndPoint ipEndPoint = null;
        static private Socket listener = null;
        //static private NetworkStream stream = null;
        //static private StreamReader streamReader = null;
        //static private StreamWriter streamWriter = null;
        static private List<Socket> connection = null;


        static void Main()
        {
            Console.WriteLine("Begin...");
            Thread thread = new Thread(new ThreadStart(ServerThread));
            thread.Start();
        }
        private static void Service(Socket socket)
        {
            var endPoint = (IPEndPoint)socket.RemoteEndPoint;
            while (true)
            {
                bool i = true;
                while (true)
                {
                    if (i != false)
                        Console.WriteLine(endPoint.ToString + " connected!!!");
                    i = false;
                }    
            }    
        }
        private static void ServerThread()
        {  
            ipAddress = IPAddress.Parse("127.0.0.1");
            PORT = 12345;
            ipEndPoint = new IPEndPoint(ipAddress, PORT);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ipEndPoint);
            listener.Listen();
            connection = new List<Socket>();
            Console.WriteLine("Start listenning...");
            while(true)
            {
                Socket accept = listener.Accept();
                connection.Add(accept);
                Thread thread = new Thread(() => Service(accept));
                thread.Start();
            }
        }
    }
} 