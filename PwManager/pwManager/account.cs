using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pwManager
{
    public partial class account : UserControl
    {
        public account()
        {
            InitializeComponent();
        }
        private static account _instance;
        public static account Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new account();
                return _instance;
            }
        }

        private string _email;
        public string Email
        {
            set { _email = value; }
        }

        private string _accountName;
        public string AccountName
        {
            set { _accountName = value; }
        }
        

        private void account_Load(object sender, EventArgs e)
        {
            textBoxUser.Text = _accountName;
            textBox1.Text = _email;
        }

        private void textBoxUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
