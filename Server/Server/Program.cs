using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static private IPAddress ipAddress = null;
        static private TcpListener listener = null;
        static private Socket clientSocket = null;
        static private NetworkStream stream = null;
        static private StreamReader streamReader = null;
        static private StreamWriter streamWriter = null;

        static void Close() 
        {
            stream.Close();
            clientSocket.Close();
        }

        static void Main()
        {
            Executive();
        }

        static private void LOGIN(string[] str)
        {
            /*
             * Kiểm tra có người nào đang đăng nhập tài khoản này không?
             *  - YES: gửi lại thông báo tài khoản đang được dùng 
             *  - NO: thực hiện đăng nhập, gửi là thông điệp đăng nhập thành công và gửi vault
             */
            string username = str[1];
            string password = str[2];
            if(username =="user" && password == "pass")
            {
                streamWriter.WriteLine("LOGIN SUCCESSFULL");
            }
            else
            {
                streamWriter.WriteLine("Username or password is incorrect.");
            }                
        }

        private void CREATE_ACCOUNT(string[] str)
        {
            string username = str[1];
            string password = str[2];
            /* Nếu username có trong database:
                   Yes: phản hồi lại "THE ACCOUNT AREADY EXISTS."
                   No: 
                       - lưu tài khoản mới trong database
                       - gửi phản hồi "CREATE ACCOUNT SUCCESS."
            */
            if (true)
            {
                streamWriter.WriteLine("THE ACCOUNT AREADY EXISTS.");
            }
            else
            {

            }
        }

        private void DELETE_ACCOUNT(string[] str)
        {
            string username = str[1];
            string password = str[2];
            /* Nếu username có trong database:
                   Yes:
                       - Thực hiện xóa toàn bộ vault thuộc về username cần xóa.
                       - Thực hiện xóa username và password khỏi database.
                   No: 
                       - Phản hồi lại "THE ACCOUNT DOSE NOT EXIST."
            */
            if (false)
            {

            }
            else
            {
                streamWriter.WriteLine("THE ACCOUNT DOSE NOT EXIST.");
            }
        }

        private void SYNCHRONIZATION()
        { }

        private static void END_CONNECTION()
        {
            streamWriter.WriteLine("END CONNECTION.");
            Close();
        }


        static private void doEvent(string cmd)
        {
            string[] subs = cmd.Split(":");
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
                // Khi thay đổi mật khảu của tài khoản hoặc một vault.
                case "SYNCHRONIZATION":
                    Console.WriteLine("SYNCHRONIZATION");
                    break;
                // Ngắt kết nối.
                case "END CONNECTION":
                    Console.WriteLine("END CONNECTION");
                    END_CONNECTION();
                    break;
                default:
                    break;
            }    
        }

        private static void Executive()
        {  
            ipAddress = IPAddress.Parse("127.0.0.1");
            listener = new TcpListener(ipAddress, 15000);
            
            while (true)
            {
                /*
                 1. Bắt đầu lắng nghe một kết nối đến.
                 */
                listener.Start();

                Console.WriteLine("Server started on " + listener.LocalEndpoint);
                Console.WriteLine("Waiting for a connection...");

                while (true)
                {
                    /*
                     2. Chấp nhận một kết nối từ Client
                     */
                    clientSocket = listener.AcceptSocket();
                    stream = new NetworkStream(clientSocket);
                    streamReader = new StreamReader(stream);
                    streamWriter = new StreamWriter(stream);
                    streamWriter.AutoFlush = true;

                    /*
                     3. Kiểm tra kết nối đến client vẫn tồn tại hay không:
                        YES: Tiếp tục xử lý các request từ client đó
                        NO: Chờ một kết nối mới
                     */
                    while (clientSocket.Connected)
                    {
                        string cmd = streamReader.ReadLine();
                        doEvent(cmd);
                    }
                }
            }    
        }
    }
} 