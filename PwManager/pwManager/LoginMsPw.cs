using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.IO;

namespace pwManager
{
    public partial class LoginMsPw : Form
    {
        public Point mouseLocation;
        public LoginMsPw()
        {
            InitializeComponent();
        }

        public IPAddress ipAdress;
        public int PORT;
        public Socket socket;
        public IPEndPoint remoteEndpoint;
        public NetworkStream networkStream;
        public StreamReader streamReader;
        public StreamWriter streamWriter;

        private void Start()
        {
            ipAdress = IPAddress.Parse("127.0.0.1");
            PORT = 8080;
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            remoteEndpoint = new IPEndPoint(ipAdress, PORT);
            socket.Connect(remoteEndpoint);

            networkStream = new NetworkStream(socket);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;
            streamReader = new StreamReader(networkStream);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Click(object sender, EventArgs e)
        {
            string UserName = user_name.Text;
            byte[] HashPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password.Text));
            StringBuilder hex = new StringBuilder(HashPassword.Length * 2);
            foreach (byte b in HashPassword)
            {
                hex.AppendFormat("{0:x2}", b);
            }
            string Password = hex.ToString();
            string msg = String.Format("LOGIN\\{0}\\{1}", UserName, Password);
            streamWriter.WriteLine(msg);
            string rcv = streamReader.ReadLine();
            string[] vs = rcv.Split('\\');
            switch (vs[1])
            {
                case "1":
                    //MessageBox.Show("Đăng nhập thành công.");                   
                    string path = @"D:\Online Password Manager Application\PwManager\pwManager\bin\pw.txt";
                    FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
                    using (StreamWriter writeFile = new StreamWriter(fs))
                    {
                        do
                        {
                            string r = streamReader.ReadLine();
                            if (r == "<EOF>")
                            {
                                break;
                            }
                            writeFile.Write(r+Environment.NewLine);
                        }
                        while (true);
                    };
                    fs.Close();
                    this.Hide();
                    Form fm = new Main(socket, streamWriter, streamReader, vs[2], vs[3]);
                    fm.ShowDialog();
                    try
                    {
                        msg = streamReader.ReadLine();
                        if (msg == "LOGOUT\\1")
                            this.Show();
                    }
                    catch
                    {
                        this.Close();
                    }
                    break;
                default:
                    MessageBox.Show("Tài khoản hoặc mật khẩu không đúng.");
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (password.PasswordChar == '\0') // Nếu password ở dạng text
            {
                button1.BringToFront(); // icon button1 hiển thị
                password.PasswordChar = '*'; // password được chuyển về dạng ***
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (password.PasswordChar == '*') // Nếu password ở dạng ****
            {
                button2.BringToFront(); // icon button2 hiển thị
                password.PasswordChar = '\0'; // password được chuyển về dạng text bình thường
            }
        }

        // Nhan vao Icon X thoat khoi ung dung
        private void button3_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("CLOSE_CONNECTION\\");
            socket.Close();
            Application.Exit();
        }
   
        private void txtUserEnter(object sender, EventArgs e)
        {
            if(user_name.Text.Equals(@"User name"))
            {
                user_name.Text = "";
            }
        }

        private void txtUserLeave(object sender, EventArgs e)
        {
            if(user_name.Text.Equals(""))
            {
                user_name.Text = "User name";
            }
        }

        private void txtpassEnter(object sender, EventArgs e)
        {
            if (password.Text.Equals("Password"))
            {
                password.Text = "";
            }
        }

        private void txtpassLeave(object sender, EventArgs e)
        {
            if (password.Text.Equals(""))
            {
                password.Text = "Password";
            }
        }
        // DI CHUYỂN FORM TỚI VỊ TRÍ BẤT KỲ Ở MÀN HÌNH
        private void mouse_down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
            }
        }

        private void forgot_password_Click(object sender, EventArgs e)
        {
            //Forgot_password fp = new Forgot_password();
            //this.Hide();
            //fp.ShowDialog();
            Forgot_password fp = new Forgot_password(socket, streamWriter, streamReader);
            this.Hide();
            fp.ShowDialog();
            try
            {
                this.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            //Form fw = new SignUp();
            //this.Hide();
            //fw.ShowDialog();
            Form fw = new SignUp(streamWriter, streamReader);
            this.Hide();
            fw.ShowDialog();
            try
            {
                this.Show();
            }
            catch (Exception ex)
            {
            }
        }

        private void user_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
