using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace pwManager
{
    public partial class Create : UserControl
    {
        string pattern = @"(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z])(?=.*?[#?!@$%^&*-]).*$";
        public Create()
        {
            InitializeComponent();
        }
        private static Create _instance;
        public static Create Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new Create();
                return _instance;
            }
        }
        private static TextBox newapp;
        public static TextBox newApp
        {
            get
            {
                if (newapp == null)
                    newapp = Instance.textBoxApp;
                return newapp;
            }
        }
        private static TextBox user;
        public static TextBox User
        {
            get
            {
                if (user == null)
                    user = Instance.textBoxUser;
                return user;
            }
        }
        private static TextBox pass;
        public static TextBox Pass
        {
            get
            {
                if (pass == null)
                    pass = Instance.textBoxPw;
                return pass;
            }
        }
        private static TextBox confirm;
        public static TextBox Confirm
        {
            get
            {
                if (confirm == null)
                    confirm = Instance.textBoxconfirm;
                return confirm;
            }
        }
        private static ErrorProvider epass;
        public static ErrorProvider ePass
        {
            get
            {
                if (epass == null)
                    epass = Instance.errorProvider1;
                return epass;
            }
        }
        private static ErrorProvider econfirm;
        public static ErrorProvider eConfirm
        {
            get
            {
                if (econfirm == null)
                    econfirm = Instance.errorProvider2;
                return econfirm;
            }
        }
        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (textBoxPw.PasswordChar == '*')
            {
                buttonHind.BringToFront();
                textBoxPw.PasswordChar = '\0';
            }
        }

        private void buttonHind_Click(object sender, EventArgs e)
        {
            if (textBoxPw.PasswordChar == '\0')
            {
                buttonShow.BringToFront();
                textBoxPw.PasswordChar = '*';
            }
        }
        private void buttonHind1_Click(object sender, EventArgs e)
        {
            if (textBoxconfirm.PasswordChar == '\0')
            {
                buttonShow1.BringToFront();
                textBoxconfirm.PasswordChar = '*';
            }
        }

        private void buttonShow1_Click(object sender, EventArgs e)
        {
            if (textBoxconfirm.PasswordChar == '*')
            {
                buttonHind1.BringToFront();
                textBoxconfirm.PasswordChar = '\0';
            }
        }
        private void Create_Load(object sender, EventArgs e)
        {

        }
        //kiểm tra xem có tài khoản app này chưa
        int checkApp(string app)
        {
            int count = 0;
            FileStream fileStream = new FileStream("..\\pw.txt", FileMode.Open,FileAccess.Read);
            StreamReader readFile = new StreamReader(fileStream);
            string data = readFile.ReadToEnd();
            fileStream.Close();
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                var s = line.Split('-');
                if (string.Compare(s[0], app, true) == 0)
                    count = 1;
            }
            return count;   //nếu count = 0 nghĩa là không có tên trong danh sách, ngược lại bằng 1
        }

        //ghi nội dung app mới vào file 
        void writeFile(string app, string user, string pw)
        {
            FileStream fileStream = new FileStream("..\\pw.txt", FileMode.Append,FileAccess.Write);
            StreamWriter writeFile = new StreamWriter(fileStream);
            writeFile.WriteLine(app + "-" + user + "-" + pw);
            writeFile.Flush();
            fileStream.Close();

        }
        private void buttonCreate_Click(object sender, EventArgs e)
        {
           if(checkApp(textBoxApp.Text)==1)
           {
                MessageBox.Show("You've already have this account!", "", MessageBoxButtons.OK);
                textBoxApp.Clear();
           }
           else
           {
                if (textBoxPw.Text != textBoxconfirm.Text)
                {
                    errorProvider2.SetError(this.textBoxconfirm, "Not Matched");
                    MessageBox.Show("Wrong password! Try again.", "", MessageBoxButtons.OK);
                }
                else
                {
                    errorProvider2.Clear();
                    writeFile(textBoxApp.Text, textBoxUser.Text, textBoxPw.Text);
                    MessageBox.Show("Success!", "", MessageBoxButtons.OK);
                }
           }
        }
        private void password_leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBoxPw.Text, pattern) == false)
            {
                errorProvider1.SetError(this.textBoxPw, "Password weak");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void confirm_pass_leave(object sender, EventArgs e)
        {
            if (textBoxPw.Text != textBoxconfirm.Text)
            {
                errorProvider2.SetError(this.textBoxconfirm, "Not Matched");
                MessageBox.Show("Wrong password! Try again.", "", MessageBoxButtons.OK);
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        
    }
}
