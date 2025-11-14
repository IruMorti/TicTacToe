using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatWindowTest
{
    public partial class ChatFieldLeft : UserControl
    {
        public ChatFieldLeft()
        {
            InitializeComponent();
        }

        public ChatFieldLeft(string userName, string msg, int width)
        {
            InitializeComponent();
            userNameLbl.Text = userName;
            messageLbl.Text = msg;
            this.Width = width;      
        }
    }
}
