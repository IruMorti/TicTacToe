using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineTicTacToe
{
    public partial class InfoMessageBox : Form
    {
        public InfoMessageBox(string infoText)
        {
            InitializeComponent();
            infoLabel.Text = infoText;
        }

        private void addLobbyBt_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
