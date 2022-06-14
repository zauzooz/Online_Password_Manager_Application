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
using System.Diagnostics;

namespace pwManager
{
    public partial class pw : UserControl
    {
        public pw()
        {
            InitializeComponent();
        }

        private static pw _instance;
        public static pw Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new pw();
                return _instance;
            }
        }
        public static void GetInfo(string app)
        {
            getInfo(app);
        }

        public static void GetNameApp(string app)
        {
            Instance.labelApp.Text = app;
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
        private static TextBox web;
        public static TextBox Web
        {
            get
            {
                if (web == null)
                    web = Instance.textBoxWeb;
                return web;
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

        //lấy đường link của 1 web dựa vào tên web
        string getURL(string app)
        {
            string url = "";
            FileStream fileStream = new FileStream("..\\URL.txt", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(fileStream);
            string data = readFile.ReadToEnd();
            fileStream.Close();
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                var s = line.Split('-');
                if (string.Compare(s[0], app, true) == 0)
                    url = s[1];
            }
            return url;
        }

        //điền thông tin user, pw, website
        private static void getInfo(string app)
        {
            FileStream fileStream = new FileStream("..\\pw.txt", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(fileStream, Encoding.UTF8);
            string data = readFile.ReadToEnd();
            fileStream.Close();
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                var s = line.Split('-');
                if (string.Compare(s[0], app, true) == 0)
                {
                    pw.User.Text = s[1].ToString();
                    pw.Pass.Text = s[2].ToString();
                    pw.Web.Text = pw.Instance.getURL(s[0]).ToString();
                }
            }
        }

        private void pw_Load(object sender, EventArgs e)
        {
            
        }

        public void buttonWeb_Click(object sender, EventArgs e)
        {
            Process.Start(textBoxWeb.Text);
        }

         private static string getNameApp(string website)
         {  
            website = Instance.textBoxWeb.Text;
            string app = "";
            FileStream fileStream = new FileStream("..\\URL.txt", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(fileStream);
            string data = readFile.ReadToEnd();
            fileStream.Close();
            string[] lines = data.Split('\n');
            foreach (string line in lines)
            {
                var s = line.Split('-');
                if (string.Compare(s[1], website, true) == 0)
                {
                    app = s[0];
                    break;
                }
            }
            return app;
         }
        
        //trả về số dòng của tài khoản ở dạng app-username-pass
        int getLine(string website)
        {
            website = textBoxWeb.Text;
            string app = getNameApp(website);

            int line_number = 0, count = -1 ;
            FileStream fs = new FileStream("..\\pw.txt", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fs);
            string dt = rd.ReadToEnd();
            fs.Close();
            string[] ls = dt.Split('\n');
            foreach(string line in ls)
            {
                count++;
                var s = line.Split('-');
                if (string.Compare(s[0], app, true) == 0) 
                {
                    line_number = count;
                    break;
                }    
            }
            return line_number;
        }
        
        private void buttonChange_Click(object sender, EventArgs e)
        {
              
        }

        void removeLine(List<string> list)
        {
            FileStream fileStream = new FileStream("..\\pw.txt", FileMode.Open, FileAccess.Read);
            StreamReader readFile = new StreamReader(fileStream);
            string data = readFile.ReadToEnd();
            fileStream.Close();
            string[] lines = data.Split('\n');
            for(int i=0;i<lines.Length;i++)
            {
                if (i != getLine(textBoxWeb.Text))
                {
                    if (list.Contains(lines[i]) == false)
                    {
                        list.Add(lines[i]);
                    }
                }
            }

            FileStream fs = new FileStream("..\\pw1.txt", FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter wf = new StreamWriter(fs);
            foreach (string line in list)
            {
                wf.Write(line);
            }
            wf.Flush();
            fs.Close();

            //xoá file cũ
            File.Delete("..\\pw.txt");
            if (File.Exists("..\\pw1.txt"))
            {
                File.Copy("..\\pw1.txt", "..\\pw.txt", true);
                File.Delete("..\\pw1.txt");
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            List<string> list = new List<string>();
            removeLine(list);

            MessageBox.Show("Remove success!");
            textBoxUser.Clear();
            textBoxPw.Clear();
            textBoxWeb.Clear();
        }

        private void labelApp_Click(object sender, EventArgs e)
        {

        }
    }
}
