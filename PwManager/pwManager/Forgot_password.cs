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
using System.Net.Mail;
using System.Net.Sockets;
using System.IO;
namespace pwManager
{
    public partial class Forgot_password : Form
    {
        Socket socket;
        StreamReader streamReader;
        StreamWriter streamWriter;
        public Forgot_password(Socket soc, StreamWriter sw, StreamReader sr)
        {
            socket = soc;
            streamReader = sr;
            streamWriter = sw;
            InitializeComponent();
        }
        //String randomCode;
        public static String to;
        public Point mouseLocation;

        private void txtEnter(object sender, EventArgs e)
        {
            if (Phone_number.Text.Equals(@"Enter email"))
            {
                Phone_number.Text = "";
            }
        }

        private void txtLeave(object sender, EventArgs e)
        {
            if (Phone_number.Text.Equals(""))
            {
                Phone_number.Text = "Enter email";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("CLOSE_CONNECTION\\");
            socket.Close();
            Application.Exit();
        }

        private void CodeEnter(object sender, EventArgs e)
        {
            if (enter_code.Text.Equals(@"Enter code"))
            {
                enter_code.Text = "";
            }
        }

        private void Codeleave(object sender, EventArgs e)
        {
            if (enter_code.Text.Equals(""))
            {
                enter_code.Text = "Enter code";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string msg = String.Format("SEND_CODE\\{0}", Phone_number.Text);
            streamWriter.WriteLine(msg);
        }

        private void verify_Click(object sender, EventArgs e)
        {
            string msg = String.Format("CHECK_CODE\\{0}\\{1}", Phone_number.Text, enter_code.Text);
            streamWriter.WriteLine(msg);
            msg = streamReader.ReadLine();
            string[] vs = msg.Split('\\');
            if (vs[1] == "1")
            {
                this.Hide();
                Form form = new Resetpassword(socket, streamWriter, streamReader, Phone_number.Text);
                form.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Mã code không khớp.");
            }
        }

        private void enter_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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
            //Form Form1 = new LoginMsPw();
            //Form1.ShowDialog();
        }

        private void Forgot_password_Load(object sender, EventArgs e)
        {

        }
    }
}
