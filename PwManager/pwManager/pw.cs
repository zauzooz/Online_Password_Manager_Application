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
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
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
        private Socket _socket;
        public Socket socket
        {
            set { _socket = value; }
        }
        private StreamReader _streamReader;
        public StreamReader streamReader
        {
            set { _streamReader = value; }
        }
        private StreamWriter _streamWriter;
        public StreamWriter streamWriter
        {
            set { _streamWriter = value; }
        }
        private string _userName;
        public string UserName
        {
            set { _userName = value; }
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
                    if (pw.Instance.getURL(s[0]) != "")
                    {
                        pw.Web.Text = pw.Instance.getURL(s[0]).ToString();
                    }
                    else pw.Web.Text = s[0].ToString();
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

         //private static string getNameApp(string website)
         //{  
         //   website = Instance.textBoxWeb.Text;
         //   string app = "";
         //   FileStream fileStream = new FileStream("..\\URL.txt", FileMode.Open, FileAccess.Read);
         //   StreamReader readFile = new StreamReader(fileStream);
         //   string data = readFile.ReadToEnd();
         //   fileStream.Close();
         //   string[] lines = data.Split('\n');
         //   foreach (string line in lines)
         //   {
         //       var s = line.Split('-');
         //       if (string.Compare(s[1], website, true) == 0)
         //       {
         //           app = s[0];
         //           break;
         //       }
         //       if (string.Compare(s[1],s[0], true) == 0)
         //       {
         //           app = s[0];
         //           break;
         //       }
         //   }
         //   return app;
         //}

        //trả về số dòng của tài khoản ở dạng app-username-pass
        int getLine(string website)
        {
            website = textBoxWeb.Text;
            string app = labelApp.Text;

            int line_number = 0, count = -1;
            FileStream fs = new FileStream("..\\pw.txt", FileMode.Open, FileAccess.Read);
            StreamReader rd = new StreamReader(fs);
            string dt = rd.ReadToEnd();
            fs.Close();
            string[] ls = dt.Split('\n');
            foreach (string line in ls)
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
        
        private void Remove(string content)
        {
            string path = @"D:\Online Password Manager Application\PwManager\pwManager\bin\pw.txt";
            string str = "";
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                StreamReader read = new StreamReader(fs);
                while (true)
                {
                    string line = read.ReadLine();
                    if (line == null)
                        break;
                    if (line == content)
                        continue;
                    else
                        str += line + Environment.NewLine;
                }

                fs.Close();
            }
            File.Delete(path);
            File.WriteAllText(path, "");
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                StreamWriter write = new StreamWriter(fs);
                write.Write(str);
                write.Flush();
                fs.Close();
            }
        }
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            //List<string> list = new List<string>();
            //removeLine(list);
            string content = labelApp.Text + "-" + textBoxUser.Text + "-" + textBoxPw.Text;
            string msg = String.Format(@"REMOVE_ACCOUNT\{0}\{1}", _userName, content);;
            _streamWriter.WriteLine(msg);
            string rcv = _streamReader.ReadLine();
            string[] sv = rcv.Split('\\');
            if (sv[1] == "1")
            {
                MessageBox.Show("Remove success!");
                Remove(content);
                textBoxUser.Clear();
                textBoxPw.Clear();
                textBoxWeb.Clear();
            }
            else
            {
                MessageBox.Show("Remove failed!");
            }
        }

        private void labelApp_Click(object sender, EventArgs e)
        {

        }

        private void labelApp_Click_1(object sender, EventArgs e)
        {

        }
    }
}
