using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
namespace pwManager
{
    public partial class SignUp : Form
    {
        public Point mouseLocation;
        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*?[#?!@$%^&*-]).*$";
        StreamWriter streamWriter;
        StreamReader streamReader;
        public SignUp(StreamWriter sw, StreamReader sr)
        {
            streamWriter = sw;
            streamReader = sr;
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("CLOSE_CONNECTION\\");
            Application.Exit();
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Hide();
            //Form fw = new LoginMsPw();
            //fw.ShowDialog();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void password_leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(password.Text, pattern) == false)
            {
                errorProvider1.SetError(this.password, "Password weak");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void confirm_pass_leave(object sender, EventArgs e)
        {
            if (password.Text != confirm_password.Text)
            {
                errorProvider2.SetError(this.confirm_password, "Not Matched");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void mouse_down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void mouse_move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point mousePose = Control.MousePosition;
                mousePose.Offset(mouseLocation.X, mouseLocation.Y);
                Location = mousePose;
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

        private void Create_Click(object sender, EventArgs e)
        {
            string userName = User_name.Text;
            string Password = password.Text;
            string Confirm = confirm_password.Text;
            string email = Email.Text;
            if (Password != Confirm)
            {
                MessageBox.Show("Nhập khẩu không khớp!");
            }
            else
            {
                byte[] HashPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(password.Text));
                StringBuilder hex = new StringBuilder(HashPassword.Length * 2);
                foreach (byte b in HashPassword)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                Password = hex.ToString();
                string msg = String.Format("CREATE_ACCOUNT\\{0}\\{1}\\{2}", userName, Password, email);
                streamWriter.WriteLine(msg);
                string rcv = streamReader.ReadLine();
                string[] vs = rcv.Split('\\');
                switch (vs[1])
                {
                    case "1":
                        MessageBox.Show("Tên tài khoản đã tồn tại.");
                        break;
                    case "4":
                        MessageBox.Show("Email đã tồn tại. Vui lòng nhập email khác.");
                        break;
                    case "0":
                        MessageBox.Show("Tạo tài khoản thành công.");
                        this.Close();
                        break;
                    default:
                        break;
                }

            }
        }
    }
}