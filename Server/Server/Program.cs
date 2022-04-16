using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        // create an endpoint
        //ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
        //ipAddress = ipHostEntry.AddressList[0];
        //ipEndPoint = new IPEndPoint(ipAddress, 15000);
        static private IPHostEntry ipHostEntry = null;
        static private IPAddress ipAddress = null;
        static private IPEndPoint ipEndPoint = null;
        // create a TCP socket:  listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp); 
        static private Socket listener = null;
        // accept a connection: clientSocket = listenner.Accept()
        static private Socket clientSocket = null;

        static void EndPoint()
        {
            // create an endpoint
            ipHostEntry = Dns.GetHostEntry(Dns.GetHostName());
            ipAddress = ipHostEntry.AddressList[0];
            ipEndPoint = new IPEndPoint(ipAddress, 15000);         
        }

        static void _Socket()
        {
            // creat a TCP socket
            listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        }

        static void Bind()
        {
            // bind the endpoint
            listener.Bind(ipEndPoint);
        }
        
        static void Listen()
        {
            listener.Listen();
        }

        static void Accept()
        {
            clientSocket = null;
            clientSocket = listener.Accept();
        }

        static void Send(string msg = "respone") 
        {
            byte[] message = Encoding.ASCII.GetBytes(msg);
            clientSocket.Send(message);
        }

        static string Recieve()
        {
            // data buffer
            string data = null;
            byte[] bytes = new byte[1024];

            while (true)
            {
                int numByte = clientSocket.Receive(bytes);

                data += Encoding.ASCII.GetString(bytes,
                                           0, numByte);

                if (data.IndexOf("\0") > -1)
                    break;
            }

            return data;
        }

        static void Close() 
        {
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
            listener.Close();
        }

        static void Main()
        {
            Executive();
        }

        static private void LOGIN(string[] str)
        {
            string username = str[1];
            string password = str[2];
            if(username =="user" && password == "pass")
            {
                Send("LOGIN SUCCESSFULL:your vault here");
            }
            else
            {
                Send("Username or password is incorrect.");
            }                
        }

        private void CREATE_ACCOUNT()
        { }

        private void DELETE_ACCOUNT()
        { }

        private void SYNCHRONIZATION()
        { }

        private static void END_CONNECTION()
        {
            Send("Close connection.");
            Close();
        }


        static private void doEvent()
        {
            string data = Recieve();
            string[] subs = data.Split(':');
            switch (subs[0])
            {
                // Đăng nhập, nếu thành công thì gửi vault, không thì báo nhập sai
                case "LOGIN":
                    Console.WriteLine("LOGIN");
                    LOGIN(subs);
                    break;
                // Tạo tài khoản trên hệ thống lưu trữ mật khẩu
                case "CREATE ACCOUNT":
                    Console.WriteLine("CREATE ACCOUNT");
                    break;
                // Xóa các tài vault, cuối cùng xóa tài khoản.
                case "DELETE ACCOUNT":
                    Console.WriteLine("DELETE ACCOUNT");
                    break ;
                // Khi thay đổi mật khảu của tài khoản hoặc một vault
                case "SYNCHRONIZATION":
                    Console.WriteLine("SYNCHRONIZATION");
                    break;
                // Ngắt kết nối
                case "END CONNECTION":
                    Console.WriteLine("END CONNECTION");
                    END_CONNECTION();
                    break;
                default:
                    Console.WriteLine("END");
                    break;
            }    
        }

        private static void Executive()
        {

            EndPoint();

            _Socket();

            Bind();

            Listen();

            while (true)
            { 
                Accept();
                doEvent();
            }    
        }
    }
}