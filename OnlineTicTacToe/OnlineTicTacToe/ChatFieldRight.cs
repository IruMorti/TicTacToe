namespace ChatWindowTest
{
    public partial class ChatFieldRight : UserControl
    {
        int currentMsgBoxHeight = 0;

        public ChatFieldRight()
        {
            InitializeComponent();
        }

        public ChatFieldRight(string userName, string msg, int width)
        {
            InitializeComponent();            
            userNameLbl.Text = userName;
            messageLbl.Text = msg;
            this.Width = width;
        }        
    }
}
