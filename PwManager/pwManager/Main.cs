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
    public partial class Main : Form
    {

        List<Button> buttonApps = null;
        string userName;
        string Email;
        Socket socket;
        StreamReader streamReader;
        StreamWriter streamWriter;
        public Main(Socket soc, StreamWriter sw, StreamReader sr, string usr, string _email)
        {
            socket = soc;
            streamWriter = sw;
            streamReader = sr;
            userName = usr;
            Email = _email;
            InitializeComponent();

            //danh sách các button ứng dụng
            buttonApps = new List<Button>
            {
                buttonCourses, buttonFacebook, buttonGmail, buttonMessenger, buttonZalo, buttonYouTube, buttonNetFlix, buttonInstagram,  buttonTwitter, buttonGitHub,
                buttonMicrosoft, buttoneBay, buttonAmazon, buttonSpotify, buttonTikTok, buttonLazada, buttonShopee, buttonDropBox, buttonACB, buttonBIDV, buttonVietcombank,
                buttonYahoo,buttonTP,buttonTiki,buttonViber,buttonWhatsApp,buttonWeverse,buttonDiscord,buttonLinkedin,buttonSnapChat,buttonWordPress
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //tạo file chứa các trang web
            createUrlWeb();

            if (textBoxSearch.Text == "")
            {
                textBoxSearch.Text = "Search";
                textBoxSearch.ForeColor = Color.Gray;
            }

            //hiển thị giao diện của button home
            if (!panelContainer.Controls.Contains(home.Instance))
            {
                panelContainer.Controls.Add(home.Instance);
                home.Instance.Dock = DockStyle.Fill;
                home.Instance.BringToFront();
            }
            else
                home.Instance.BringToFront();
        }

        //hiển thị giao diện của button home
        private void buttonHome_Click(object sender, EventArgs e)
        {
            if (!panelContainer.Controls.Contains(home.Instance))
            {
                panelContainer.Controls.Add(home.Instance);
                home.Instance.Dock = DockStyle.Fill;
                home.Instance.BringToFront();
            }
            else
                home.Instance.BringToFront();
        }

        //tài khoản của bạn
        private void buttonAccount_Click(object sender, EventArgs e)
        {
            if (!panelContainer.Controls.Contains(account.Instance))
            {
                account.Instance.AccountName = userName;
                account.Instance.Email = Email;
                panelContainer.Controls.Add(account.Instance);
                account.Instance.Dock = DockStyle.Fill;
                account.Instance.BringToFront();
            }
            else
                account.Instance.BringToFront();
            account.Instance.AccountName = userName;
        }
        //thêm app mới
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            if (!panelContainer.Controls.Contains(Create.Instance))
            {
                panelContainer.Controls.Add(Create.Instance);
                Create.Instance.Dock = DockStyle.Fill;
                Create.Instance.BringToFront();
            }
            else
                Create.Instance.BringToFront();
            Create.Instance._socket = socket;
            Create.Instance._streamReader = streamReader;
            Create.Instance._streamWriter = streamWriter;
            Create.Instance.UserName = userName;
            Create.newApp.Clear();
            Create.User.Clear();
            Create.Pass.Clear();
            Create.Confirm.Clear();
            Create.ePass.Clear();
            Create.eConfirm.Clear();
        }
        //thoát khỏi chương trình
        private void buttonClose_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string path = @"D:\Online Password Manager Application\PwManager\pwManager\bin\pw.txt";
            result = MessageBox.Show("Do you want to exit?", "", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                streamWriter.WriteLine("CLOSE_CONNECTION\\");
                socket.Close();
                File.WriteAllText(path, "");
                Application.Exit(); ; //đóng chương trình
            }
        }

        private void textBoxSearch_MouseEnter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "Search")
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.SteelBlue;
            }
        }

        private void textBoxSearch_MouseLeave(object sender, EventArgs e)
        {
            if (textBoxSearch.Text == "")
            {
                textBoxSearch.Text = "Search";
                textBoxSearch.ForeColor = Color.Gray;
            }
        }
        //tạo file URL.txt chứa các website 
        void createUrlWeb()
        {
            FileStream fileStream = new FileStream("..\\URL.txt", FileMode.Create);
            StreamWriter writeFile = new StreamWriter(fileStream);
            writeFile.WriteLine("Facebook-https://facebook.com");
            writeFile.WriteLine("Gmail-https://mail.google.com");
            writeFile.WriteLine("Messenger-https://messenger.com");
            writeFile.WriteLine("Zalo-https://chat.zalo.me/");
            writeFile.WriteLine("Courses-https://courses.uit.edu.vn");
            writeFile.WriteLine("YouTube-https://youtube.com");
            writeFile.WriteLine("Twitter-https://twitter.com");
            writeFile.WriteLine("Instagram-https://instagram.com");
            writeFile.WriteLine("NetFlix-https://netflix.com");
            writeFile.WriteLine("GitHub-https://github.com");
            writeFile.WriteLine("Microsoft-https://microsoft.com");
            writeFile.WriteLine("eBay-https://ebay.com");
            writeFile.WriteLine("DropBox-https://dropbox.com");
            writeFile.WriteLine("Amazon-https://amazon.com");
            writeFile.WriteLine("Spotify-https://spotify.com");
            writeFile.WriteLine("Lazada-https://lazada.vn");
            writeFile.WriteLine("TikTok-https://tiktok.com");
            writeFile.WriteLine("Shopee-https://shopee.vn");
            writeFile.WriteLine("Vietcombank-https://vcbdigibank.vietcombank.com.vn");
            writeFile.WriteLine("BIDV Bank-https://smartbanking.bidv.com.vn");
            writeFile.WriteLine("A Chau Bank-https://online.acb.com.vn");
            writeFile.WriteLine("Yahoo-https://login.yahoo.com");
            writeFile.WriteLine("TP Bank-https://ebank.tpb.vn");
            writeFile.WriteLine("Tiki-https://tiki.vn");
            writeFile.WriteLine("WhatsApp-https://web.whatsapp.com");
            writeFile.WriteLine("Viber-https://account.viber.com/vi/login");
            writeFile.WriteLine("Weverse-https://weverse.io");
            writeFile.WriteLine("Discord-https://discord.com/");
            writeFile.WriteLine("Linkedin-https://linkedin.com/login");
            writeFile.WriteLine("SnapChat-https://accounts.snapchat.com");
            writeFile.WriteLine("WordPress-https://wordpress.com/login");
            writeFile.Flush(); 
            fileStream.Close(); 
        }

        

        //kiểm tra xem có tài khoản app này chưa
        int checkApp(string app,string filePath)
        {
            int count = 0;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
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

        //tìm kiếm app
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            DialogResult result;
            if (checkApp(textBoxSearch.Text,"..\\pw.txt") == 1)
            {
                if (!panelContainer.Controls.Contains(pw.Instance))
                {
                    panelContainer.Controls.Add(pw.Instance);
                    pw.Instance.Dock = DockStyle.Fill;
                    pw.Instance.BringToFront();
                }
                else
                    pw.Instance.BringToFront();
                pw.Instance.socket = socket;
                pw.Instance.streamReader = streamReader;
                pw.Instance.streamWriter = streamWriter;
                pw.Instance.UserName = userName;
                pw.GetInfo(textBoxSearch.Text);
                pw.GetNameApp(textBoxSearch.Text);
                
            }
            else
            {
                if (checkApp(textBoxSearch.Text, "..\\URL.txt") == 0)
                {
                    MessageBox.Show("Sorry, we don't have this app =(((", "", MessageBoxButtons.OK);
                }
                result = MessageBox.Show("You don't have this account! Want to create?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (!panelContainer.Controls.Contains(Create.Instance))
                    {
                        panelContainer.Controls.Add(Create.Instance);
                        Create.Instance.Dock = DockStyle.Fill;
                        Create.Instance.BringToFront();
                    }
                    else
                        Create.Instance.BringToFront();
                    Create.Instance._socket = socket;
                    Create.Instance._streamWriter = streamWriter;
                    Create.Instance._streamReader = streamReader;
                    Create.Instance.UserName = userName;
                    Create.newApp.Text = textBoxSearch.Text;
                    Create.User.Clear();
                    Create.Pass.Clear();
                    Create.Confirm.Clear();
                    Create.ePass.Clear();
                    Create.eConfirm.Clear();
                }
            }
        }

        //hiển thị giao diện khi click vào các button ứng dụng
        private void buttonsApp_Click(object sender, EventArgs e)
        {
            /* foreach (Button button in buttonApps)
             {

                 if (!panelContainer.Controls.Contains(pw.Instance))
                 {
                     panelContainer.Controls.Add(pw.Instance);
                     pw.Instance.Dock = DockStyle.Fill;
                     pw.Instance.BringToFront();
                 }
                 else
                     pw.Instance.BringToFront();
                 getInfo(button.Text);
             }*/

        }
        void clickApp(string app)
        {
            DialogResult result;
            if (checkApp(app, "..\\pw.txt") == 1)
            {
                if (!panelContainer.Controls.Contains(pw.Instance))
                {
                    panelContainer.Controls.Add(pw.Instance);
                    pw.Instance.Dock = DockStyle.Fill;
                    pw.Instance.BringToFront();
                }
                else
                    pw.Instance.BringToFront();
                pw.Instance.socket = socket;
                pw.Instance.streamReader = streamReader;
                pw.Instance.streamWriter = streamWriter;
                pw.Instance.UserName = userName;
                pw.GetInfo(app);
                pw.GetNameApp(app);
            }
            else
            {
                if (checkApp(app, "..\\URL.txt") == 0)
                {
                    MessageBox.Show("Sorry, we don't have this app =(((", "", MessageBoxButtons.OK);
                }
                result = MessageBox.Show("You don't have this account! Want to create?", "", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (!panelContainer.Controls.Contains(Create.Instance))
                    {
                        panelContainer.Controls.Add(Create.Instance);
                        Create.Instance.Dock = DockStyle.Fill;
                        Create.Instance.BringToFront();
                    }
                    else
                        Create.Instance.BringToFront();
                    Create.Instance._socket = socket;
                    Create.Instance._streamWriter = streamWriter;
                    Create.Instance._streamReader = streamReader;
                    Create.Instance.UserName = userName;
                    Create.newApp.Text = app;
                    Create.User.Clear();
                    Create.Pass.Clear();
                    Create.Confirm.Clear();
                    Create.ePass.Clear();
                    Create.eConfirm.Clear();
                }
            }

        }
        private void buttonCourses_Click(object sender, EventArgs e)
        {
            clickApp("Courses");
        }

        private void buttonFacebook_Click(object sender, EventArgs e)
        {
            clickApp("Facebook");
        }

        private void buttonGmail_Click(object sender, EventArgs e)
        {
            clickApp("Gmail");
        }

        private void buttonMessenger_Click(object sender, EventArgs e)
        {
            clickApp("Messenger");
        }

        private void buttonZalo_Click(object sender, EventArgs e)
        {
            clickApp("Zalo");
        }

        private void buttonYouTube_Click(object sender, EventArgs e)
        {
            clickApp("YouTube");
        }

        private void buttonNetFlix_Click(object sender, EventArgs e)
        {
            clickApp("NetFlix");
        }

        private void buttonInstagram_Click(object sender, EventArgs e)
        {
            clickApp("Instagram");
        }

        private void buttonTwitter_Click(object sender, EventArgs e)
        {
            clickApp("Twitter");
        }

        private void buttonGitHub_Click(object sender, EventArgs e)
        {
            clickApp("GitHub");

        }

        private void buttonMicrosoft_Click(object sender, EventArgs e)
        {
            clickApp("Microsoft");
        }

        private void buttoneBay_Click(object sender, EventArgs e)
        {
            clickApp("eBay");
        }

        private void buttonAmazon_Click(object sender, EventArgs e)
        {
            clickApp("Amazon");
        }

        private void buttonSpotify_Click(object sender, EventArgs e)
        {
            clickApp("Spotify");
        }

        private void buttonTikTok_Click(object sender, EventArgs e)
        {
            clickApp("TikTok");
        }

        private void buttonLazada_Click(object sender, EventArgs e)
        {
            clickApp("Lazada");
        }

        private void buttonShopee_Click(object sender, EventArgs e)
        {
            clickApp("Shopee");
        }

        private void buttonDropBox_Click(object sender, EventArgs e)
        {
            clickApp("DropBox");
        }

        private void buttonVietcombank_Click(object sender, EventArgs e)
        {
            clickApp("Vietcombank");
        }

        private void buttonACB_Click(object sender, EventArgs e)
        {
            clickApp("A Chau Bank");
        }

        private void buttonBIDV_Click(object sender, EventArgs e)
        {
            clickApp("BIDV Bank");
        }

        private void buttonYahoo_Click(object sender, EventArgs e)
        {
            clickApp("Yahoo");
        }

        private void buttonDiscord_Click(object sender, EventArgs e)
        {
            clickApp("Discord");
        }

        private void buttonViber_Click(object sender, EventArgs e)
        {
            clickApp("Viber");
        }

        private void buttonWordPress_Click(object sender, EventArgs e)
        {
            clickApp("WordPress");
        }

        private void buttonWhatApp_Click(object sender, EventArgs e)
        {
            clickApp("WhatsApp");
        }

        private void buttonTP_Click(object sender, EventArgs e)
        {
            clickApp("TP Bank");
        }

        private void buttonTiki_Click(object sender, EventArgs e)
        {
            clickApp("Tiki");
        }

        private void buttonLinkedin_Click(object sender, EventArgs e)
        {
            clickApp("Linkedin");
        }

        private void buttonWeverse_Click(object sender, EventArgs e)
        {
            clickApp("Weverse");
        }

        private void buttonSnapChat_Click(object sender, EventArgs e)
        {
            clickApp("SnapChat");
        }

        private void buttonModify_Click(object sender, EventArgs e)
        {
            
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            streamWriter.WriteLine("LOGOUT\\");
            File.Delete(@"D:\Online Password Manager Application\PwManager\pwManager\bin\pw.txt");
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
