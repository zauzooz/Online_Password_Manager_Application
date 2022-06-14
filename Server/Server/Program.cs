using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Diagnostics;
namespace Server
{
    class Program
    {
        static string ConnectionString = "server=NNT\\SQLEXPRESS; database=\"Password Management\";integrated security=true";
        static private IPAddress ipAddress;
        static private int PORT;
        static private IPEndPoint ipEndPoint;
        static private Socket listener ;
        static private List<Socket> connection = null;
        static string randomCode = "";


        static void Main()
        {
            Console.WriteLine("Begin...");
            Thread thread = new Thread(new ThreadStart(ServerThread));
            thread.Start();
        }

        private static string Recieve(Socket socket)
        {
            var networkStream = new NetworkStream(socket);
            var streamReader = new StreamReader(networkStream);
            string recieve = streamReader.ReadLine();
            return recieve;
        }

        private static void Send(Socket socket, string respone)
        {
            var networkStream = new NetworkStream(socket);
            var streamWriter  = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;
            streamWriter.WriteLine(respone);
        }

        private static bool LOGIN(
            string UserName,
            string Password
            )
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                string query = String.Format(
                    "SELECT UserName, Password FROM dbo.LoginTable " +
                    "WHERE UserName='{0}'", UserName);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string username = reader.GetString(0).Trim();
                    string password = reader.GetString(1).Trim();
                    if (username == UserName && password == Password)
                        return true;
                }
                conn.Close();
                return false;
            }
        }

        private static int CREATE_ACCOUNT(
             string UserName, 
             string Password,
             string Email
            )
        {

            /* check user is existed in database
             * True:
             *     1. Create user accout
             *     2. return "Create account successfull."
             * False:
             *     return "User Name already exist."
             */

            bool check1 = false;
            //bool check2 = false;
            //bool check3 = false;
            bool check4 = false;

            // check username
            using ( SqlConnection conn = new SqlConnection(ConnectionString) )
            {
                string query = String.Format(
                    "SELECT UserName FROM dbo.LoginTable " +
                    "WHERE UserName='{0}'", UserName);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if ( reader.Read() )
                {
                    return 1;
                }
                else
                {
                    check1 = true;
                }    
                conn.Close();
            }

            // check email
            using ( SqlConnection conn = new SqlConnection(ConnectionString) )
            {
                string query = String.Format(
                    "SELECT Email FROM dbo.LoginTable " +
                    "WHERE Email='{0}'", Email);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return 4;
                }
                else
                {
                    check4 = true;
                }
                conn.Close();
            }

            if ( check1 && check4 )
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = String.Format(
                        "INSERT INTO LoginTable " +
                        "(UserName, Password, Email) " +
                        "VALUES ('{0}','{1}','{2}')"
                        , UserName, Password, Email
                        );
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return 0;
            }
            return 5;
        }

        private static bool DELETE_ACCOUNT(
            string UserName,
            string Password
            )
        {
            /* 
             * Yêu cầu nhập lại tài khoản, mật khẩu
             * Nếu nhập đúng: thực hiện xóa tài khoản.
             * Ngược lại: thông báo tài khoản hoặc mật khẩu sai.
             */
            if (LOGIN(UserName, Password))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = String.Format(
                        "DELETE FROM LoginTable " +
                        "WHERE UserName='{0}'", UserName);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            return false;
        }

        private static bool CHANGE_MASSTER_PASSWORD_ACCOUNT(
            string UserName,
            string Password,
            string NewPassword
            )
        {
            if (LOGIN(UserName, Password))
            {
                using (SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = String.Format(
                        "UPDATE LoginTable " +
                        "SET Password='{0}' " +
                        "WHERE UserName='{1}'"
                        , NewPassword, UserName);
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return true;
            }
            return false;
        }

        private static bool CHANGE_VAULT_KEY(
            string UserName,
            string Password
            )
        {
            if (LOGIN(UserName, Password) )
            {
                // do something with vault.txt
                return true;
            }
            return false;
        }

        private static bool FORGOT_PASSWORD(
            string Email,
            string Password
            )
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();                
                string query = String.Format(
                    "UPDATE LoginTable " +
                    "SET Password='{0}' " +
                    "WHERE Email='{1}'",
                    Password, Email
                    );
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return true;
        }
        private static void DoEvent(Socket socket, string msg)
        {
            string[] ev = msg.Split('\\');

            switch (ev[0])
            {
                case "LOGIN":
                    // do something -> LOGIN\\username\\masterpassword_password
                    // log to log.txt

                    /* 
                     * if login:
                     *     T: send vault from D:/Password_Management/<UserName>/vault.txt
                     *     F: username or password is not incorrect.
                     */
                    // 
                    if (LOGIN(ev[1], ev[2]))
                    {
                        // send LOGIN\\1 to client - login successful.
                        // send content of D:/Password_Management/<UserName>/vault.txt to the user
                        Console.WriteLine("Login successfull.");
                        Send(socket, "LOGIN\\1");
                        string path = String.Format(@"D:\Password_Management\{0}\pw.txt", ev[1]);
                        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                        using (StreamReader readFile = new StreamReader(fs))
                        {
                            while (true)
                            {
                                string line = readFile.ReadLine();
                                if(line == null)
                                {
                                    break;
                                }
                                Send(socket, line);
                            }
                        }
                        Send(socket, "<EOF>");
                        fs.Close();
                    }
                    else
                    {
                        // send LOGIN\\0 to client - login failed.
                        Send(socket, "LOGIN\\0");
                    }
                    break;
                case "LOGOUT":
                    // do something -> LOGOUT\\username
                    // log to log.txt
                    // remove socket in list

                    break;
                case "CREATE_ACCOUNT":
                    // do something -> CREATE_ACCOUT\\UserName\\Pasword\\Email
                    // log to log.txt

                    /* 
                     * if create_accout:
                     *     T: 
                     *          1. create D:/Password_Management/<UserName>
                     *          2. create D:/Password_Management/<UserName>/log.txt
                     *          3. write to log.txt
                     *     F:    
                     */
                    // -> send CREATE_ACCOUT\\0 to client
                    int check = CREATE_ACCOUNT(ev[1], ev[2], ev[3]);
                    if (check == 0)
                    {
                        // send CREATE_ACCOUNT\\0 to client --> create account successful.
                        string di_path = String.Format("D:/Password_Management/{0}", ev[1]);
                        DirectoryInfo di = Directory.CreateDirectory(di_path);
                        string log = di_path + "/log.txt";
                        FileStream fs = new FileStream(log, FileMode.CreateNew);
                        fs.Close();
                        string pw = di_path + "/pw.txt";
                        fs = new FileStream(pw, FileMode.CreateNew);
                        fs.Close();
                        Send(socket, "CREATE_ACCOUNT\\0");
                    }
                    else
                    {
                        // create account failed.

                        switch (check)
                        {
                            case 1:
                                // send CREATE_ACCOUT\\1 to client --> user name is existed.
                                Send(socket, "CREATE_ACCOUNT\\1");
                                break;
                            //case 2:
                            //    // send CREATE_ACCOUT\\2 to client --> personal ID is existed.
                            //    Send(socket, "CREATE_ACCOUNT\\2");
                            //    break;
                            //case 3:
                            //    // send CREATE_ACCOUT\\3 to client --> phone number is existed.
                            //    Send(socket, "CREATE_ACCOUNT\\3");
                            //    break;
                            case 4:
                                // send CREATE_ACCOUT\\4 to client --> email is existed.
                                Send(socket, "CREATE_ACCOUNT\\4");
                                break;
                            default:
                                break;
                        }
                    }

                    break;
                case "DELETE_ACCOUNT":
                    // do something -> DELETE\\username\\password
                    // log to log.txt

                    /*
                     * if delete:
                     *     T: 
                     *         1. delete D:/Password_Manager/<UserMame>
                     *         2. delete item has UserName in database
                     *     F: 
                     */

                    if (DELETE_ACCOUNT(ev[1], ev[2]))
                    {
                        // send DELETE_ACCOUNT\\1 to client
                        // delete account in database successfull to client
                        // detete D:/Password_Management/<ev[1]>/vault.txt
                        // detete D:/Password_Management/<ev[1]>/log.txt

                        // do something
                        Send(socket, "DELETE_ACCOUNT\\1");
                    }
                    else
                    {
                        // send DELETE_ACCOUNT\\0 to client
                        Send(socket, "DELETE_ACCOUNT\\0");

                    }

                    break;
                case "CHANGE_VAULT_KEY":
                    // do something -> CHANGE_VAULT_KEY\\username\\password\\line\\URL\\user\\pass
                    // log to log.txt

                    /*
                     * 
                     */

                    break;
                // use for fogot password and changed password
                case "CHANGE_MASSTER_PASSWORD_ACCOUNT":
                    // do something -> CHANGE_MASSTER_PASSWORD_ACCOUT\\username\\master_password\\new_master_password
                    // log to log.txt

                    /*
                     * 
                     */

                    if (CHANGE_MASSTER_PASSWORD_ACCOUNT(ev[1], ev[2], ev[3]))
                    {
                        // send CHANGE_MASSTER_PASSWORD_ACCOUNT\\1 to client
                        // master password change successfull.
                        Send(socket, "CHANGE_MASSTER_PASSWORD_ACCOUNT\\1");
                    }
                    else
                    {
                        // send CHANGE_MASSTER_PASSWORD_ACCOUNT\\0 to client
                        // master password change failed.
                        Send(socket, "CHANGE_MASSTER_PASSWORD_ACCOUNT\\0");
                    }

                    break;

                case "SEND_CODE":
                    // do somthing -> SEND_CODE\\Email
                    String from, pass, messageBody;
                    // random code
                    Random rand = new Random();
                    randomCode = (rand.Next(999999)).ToString();
                    // tao noi dung tin nhan
                    MailMessage message = new MailMessage();
                    string to = (ev[1]).ToString();
                    // thiet lap mail server
                    from = "phanthituyetlan471@gmail.com";
                    pass = "pshuuljgcjyvtylh";
                    // noi dung tin nhan
                    messageBody = "Your reset code is " + randomCode;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Password Reseting Code";
                    // Khoi tao ket noi moi
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    // Chi dinh ma hoa ket noi
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    // Chi dinh cach de gui tin nhan di
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    // Xac thuc nguoi gui
                    smtp.Credentials = new NetworkCredential(from, pass);
                    smtp.Send(message);
                    break;
                    
                case "CHECK_CODE":
                    Console.WriteLine(randomCode);
                    // do something -> "CHECK_CODE\\Email\\Code"
                    if (randomCode == ev[2])
                    {
                        Send(socket, "CHECK_CODE\\1");
                        randomCode = "";
                    }
                    else
                    {
                        Send(socket, "CHECK_CODE\\0");
                    }
                    
                    break;
 
                case "FORGOT_PASSWORD":
                    // do something -> FORGOT_PASSWORD\\email\\new_password
                    if (FORGOT_PASSWORD(ev[1], ev[2]))
                    {
                        Send(socket, "FORGOT_PASSWORD\\1");
                    }
                    else
                    {
                        Send(socket, "FORGOT_PASSWORD\\0");
                    }

                    break;
                case "CLOSE_CONNECTION":
                    socket.Close();
                    break;
                default:
                    // do something

                    /*
                     * 
                     */

                    break;
            }
        }
        private static void Service(Socket socket)
        {
            //var endPoint = (IPEndPoint) socket.RemoteEndPoint;
            while (socket.Connected)
            {
                string msg = Recieve(socket);
                DoEvent(socket, msg);
            }
            Console.WriteLine("Connect close.\n");
        }
        private static void ServerThread()
        {
            ipAddress = IPAddress.Parse("127.0.0.1");
            PORT = 8080;
            ipEndPoint = new IPEndPoint(ipAddress, PORT);
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(ipEndPoint);
            listener.Listen();
            connection = new List<Socket>();
            Console.WriteLine("Start listenning...");
            while (true)
            {
                Socket accept = listener.Accept();
                Console.WriteLine("client connected.");
                connection.Add(accept);
                Thread thread = new Thread(() => Service(accept));
                thread.Start();
            }
        }
    }
} 