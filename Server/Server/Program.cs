using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Data.SqlClient;

namespace Server
{
    class Program
    {
        static void Main()
        {
            Executive();
        }
        private void doEvent(string usernameAndPassword)
        { 
            string[] subs = usernameAndPassword.Split(':');
            switch (subs[0])
            {
                // Đăng nhập, nếu thành công thì gửi vault, không thì báo nhập sai
                case "LOGIN":
                    Console.WriteLine("LOGIN");
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
                    break;
                default:
                    Console.WriteLine("END");
                    break;
            }    
        }
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