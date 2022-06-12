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
namespace Server
{
    class Program
    {
        //SqlConnection sqlConnection = null;
        static string ConnectionString = "server=NNT\\SQLEXPRESS; database=\"Password Management\";integrated security=true";
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

        private static string Recieve()
        {
            string str = "";
            return str;
        }
        private static void Send(string respone)
        {

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
             string PersonalID,
             string Name,
             DateTime YearOfBirth,
             string BirthPlace,
             string PhoneNumber,
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
            bool check2 = false;
            bool check3 = false;
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

            // check personal ID
            using ( SqlConnection conn = new SqlConnection(ConnectionString) )
            {
                string query = String.Format(
                    "SELECT PersonalID FROM dbo.LoginTable " +
                    "WHERE PersonalID='{0}'", PersonalID);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if ( reader.Read() )
                {
                    return 2;
                }
                else
                {
                    check2 = true;
                }
                conn.Close();
            }

            // check phone number
            using ( SqlConnection conn = new SqlConnection(ConnectionString) )
            {
                string query = String.Format(
                    "SELECT PhoneNumber FROM dbo.LoginTable " +
                    "WHERE PhoneNumber='{0}'", PhoneNumber);
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if ( reader.Read() )
                {
                    return 3;
                }
                else
                {
                    check3 = true;
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

            if ( check1 && check2 && check3 && check4 )
            {
                using(SqlConnection conn = new SqlConnection(ConnectionString))
                {
                    conn.Open();
                    string query = String.Format(
                        "INSERT INTO LoginTable " +
                        "(UserName, Password, PersonalID, Name, YearOfBirth, BirthPlace, PhoneNumber, Email) " +
                        "VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')"
                        , UserName, Password, PersonalID, Name, YearOfBirth, BirthPlace, PhoneNumber, Email
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

        private static void DoEvent(string msg)
        {
            string[] ev = msg.Split('@');

            switch (ev[0])
            {
                case "LOGIN":
                    // do something -> LOGIN@username@masterpassword_password
                    // log to log.txt

                    /* 
                     * if login:
                     *     T: send vault from D:/Password_Management/<UserName>/vault.txt
                     *     F: username or password is not incorrect.
                     */
                    // 
                    if (LOGIN(ev[1], ev[2]))
                    {
                        // send LOGIN@1 to client - login successful.
                        // send content of D:/Password_Management/<UserName>/vault.txt to the user

                    }
                    else
                    {
                        // send LOGIN@0 to client - login failed.
                    }
                    break;
                case "LOGOUT":
                    // do something -> LOGOUT@username
                    // log to log.txt

                    break;
                case "CREATE_ACCOUNT":
                    // do something -> CREATE_ACCOUT@username@master_password@ID@Name@YOB@BP@Phone@Email
                    // log to log.txt

                    /* 
                     * if create_accout:
                     *     T: 
                     *          1. create D:/Password_Management/<UserName>
                     *          2. create D:/Password_Management/<UserName>/log.txt
                     *          3. write to log.txt
                     *     F:    
                     */
                    // -> send CREATE_ACCOUT@0 to client
                    int check = CREATE_ACCOUNT(ev[1], ev[2], ev[3], ev[4], DateTime.Parse(ev[5], System.Globalization.CultureInfo.InvariantCulture), ev[6], ev[7], ev[8]);
                    if (check == 0)
                    {
                        // send CREATE_ACCOUT@0 to client --> create account successful.

                    }
                    else
                    {
                        // create account failed.

                        switch (check)
                        {
                            case 1:
                                // send CREATE_ACCOUT@1 to client --> user name is existed.

                                break;
                            case 2:
                                // send CREATE_ACCOUT@2 to client --> personal ID is existed.

                                break;
                            case 3:
                                // send CREATE_ACCOUT@3 to client --> phone number is existed.

                                break;
                            case 4:
                                // send CREATE_ACCOUT@4 to client --> email is existed.

                                break;
                            default:
                                break;
                        }
                    }

                    break;
                case "DELETE_ACCOUNT":
                    // do something -> DELETE@username@password
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
                        // send DELETE_ACCOUNT@1 to client
                        // delete account in database successfull to client
                        // detete D:/Password_Management/<ev[1]>/vault.txt
                        // detete D:/Password_Management/<ev[1]>/log.txt

                    }
                    else
                    {
                        // send DELETE_ACCOUNT@0 to client

                    }

                    break;
                case "CHANGE_VAULT_KEY":
                    // do something -> CHANGE_VAULT_KEY@username@password@line@URL@user@pass
                    // log to log.txt

                    /*
                     * 
                     */

                    break;
                case "CHANGE_MASSTER_PASSWORD_ACCOUNT":
                    // do something -> CHANGE_MASSTER_PASSWORD_ACCOUT@username@master_password@new_master_password
                    // log to log.txt

                    /*
                     * 
                     */

                    if (CHANGE_MASSTER_PASSWORD_ACCOUNT(ev[1], ev[2], ev[3]))
                    {
                        // send CHANGE_MASSTER_PASSWORD_ACCOUNT@1 to client
                        // master password change successfull.

                    }
                    else
                    {
                        // send CHANGE_MASSTER_PASSWORD_ACCOUNT@0 to client
                        // master password change failed.

                    }

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
            var endPoint = (IPEndPoint)socket.RemoteEndPoint;
            while (true)
            {
                //bool i = true;
                while (socket.Connected)
                {
                    string msg = "LOGIN@user@pass";
                    DoEvent(msg);
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
            while (true)
            {
                Socket accept = listener.Accept();
                connection.Add(accept);
                Thread thread = new Thread(() => Service(accept));
                thread.Start();
            }
        }
    }
} 