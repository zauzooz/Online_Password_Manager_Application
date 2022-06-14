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
    public partial class home : UserControl
    {
        public home()
        {
            InitializeComponent();
        }

        private static home _instance;
        public static home Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new home();
                return _instance;
            }
        }
        private void home_Load(object sender, EventArgs e)
        {

        }
    }
}
