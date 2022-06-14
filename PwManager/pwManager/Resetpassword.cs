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
using System.Net.Sockets;
using System.IO;
using System.Security.Cryptography;
namespace pwManager
{
    public partial class Resetpassword : Form
    {
        public Point mouseLocation;
        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*?[#?!@$%^&*-]).*$";
        StreamReader streamReader;
        StreamWriter streamWriter;
        Socket socket;
        string Email;
        public Resetpassword(Socket soc, StreamWriter sw, StreamReader sr, string email)
        {
            socket = soc;
            streamReader = sr;
            streamWriter = sw;
            Email = email;
            InitializeComponent();
        }

        private void Resetpassword_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("CLOSE_CONNECTION\\");
            socket.Close();
            Application.Exit();

        }

        private void mouse_enter(object sender, EventArgs e)
        {
            if (new_password.Text.Equals(@"New password"))
            {
                new_password.Text = "";
            }
        }

        private void mouse_leave(object sender, EventArgs e)
        {
            if (new_password.Text.Equals(""))
            {
                new_password.Text = "New password";
            }
        }

        private void new_password_TextChanged(object sender, EventArgs e)
        {

        }

        private void new_pass_leave(object sender, EventArgs e)
        {
            if(Regex.IsMatch(new_password.Text, pattern) == false)
            {
                errorProvider1.SetError(this.new_password, "Password weak");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void comfirm_pass_leave(object sender, EventArgs e)
        {
            if (new_password.Text != password_again.Text)
            {
                errorProvider2.SetError(this.password_again, "Not Matched");
            }
            else
            {
                errorProvider2.Clear();
            }
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

        private void mouse_down(object sender, MouseEventArgs e)
        {
            mouseLocation = new Point(-e.X, -e.Y);
        }

        private void back_Click(object sender, EventArgs e)
        {
            this.Close();
            Form Form1 = new LoginMsPw();
            Form1.ShowDialog();
        }

        private void reset_Click(object sender, EventArgs e)
        {
            if (new_password.Text.Trim() != password_again.Text.Trim())
            {
                MessageBox.Show("Mật khẩu không khớp.");
            }
            else
            {
                byte[] HashPassword = SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(new_password.Text));
                StringBuilder hex = new StringBuilder(HashPassword.Length * 2);
                foreach (byte b in HashPassword)
                {
                    hex.AppendFormat("{0:x2}", b);
                }
                string password = hex.ToString();
                string msg = String.Format("FORGOT_PASSWORD\\{0}\\{1}", Email, password);
                streamWriter.WriteLine(msg);
                msg = streamReader.ReadLine();
                MessageBox.Show(msg);
                this.Close();
            }
        }
    }
}
