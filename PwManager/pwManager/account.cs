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
        private void buttonHind_Click(object sender, EventArgs e)
        {
            if (textBoxMstPass.PasswordChar == '\0')
            {
                buttonShow.BringToFront();
                textBoxMstPass.PasswordChar = '*';
            }
        }

        private void buttonShow_Click(object sender, EventArgs e)
        {
            if (textBoxMstPass.PasswordChar == '*')
            {
                buttonHind.BringToFront();
                textBoxMstPass.PasswordChar = '\0';
            }
        }

        private void account_Load(object sender, EventArgs e)
        {

        }
    }
}
