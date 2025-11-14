using ChatWindowTest;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Windows.Forms;

namespace OnlineTicTacToe
{
    public partial class Chat : UserControl
    {
        int currentPanelHeight = 0;
        private int scrollY = 0;
        private const int scrollStep = 10;
        private GameEngine engine;

        public Chat()
        {
            InitializeComponent();
            currentPanelHeight = buttomPanel.Height;
        }

        public Chat(GameEngine en)
        {
            engine = en;
            InitializeComponent();
            currentPanelHeight = buttomPanel.Height;          
        }

       
        private void inputBox_TextChanged(object sender, EventArgs e)
        {
            //if (inputBox == null) return;
            //Graphics grafic = inputBox.CreateGraphics();
            //SizeF textBoxSizeF = grafic.MeasureString(inputBox.Text, inputBox.Font);
            //if (textBoxSizeF.Width >= inputBox.Width)
            //{
            //    inputBox.Multiline = true;
            //    buttomPanel.Height = currentPanelHeight * 2;
            //}
            //else           
            //{
            //    buttomPanel.Height = currentPanelHeight;
            //    inputBox.Multiline = false;
            //}
        }
            
        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            var regex = new Regex(@"\r");
            if (regex.IsMatch(e.KeyChar.ToString()))
            {
                e.Handled = true;
                SubmitBt_Click(sender, e);
            }
        }

        public void AddMsgRight(string userName, string msg)
        {
            flowChatPanel.Controls.Add(new ChatFieldRight(userName, msg, 
                Width - SystemInformation.VerticalScrollBarWidth - 8));
        }

        public void AddMsgLeft(string userName, string msg)
        {
            flowChatPanel.Controls.Add(new ChatFieldLeft(userName, msg, 
                Width - SystemInformation.VerticalScrollBarWidth - 8));
        }

        private void SubmitBt_Click(object sender, EventArgs e)
        {
            engine.SendChatMsg(inputBox.Text);
            inputBox.Clear();            
        }        
    }  
}
