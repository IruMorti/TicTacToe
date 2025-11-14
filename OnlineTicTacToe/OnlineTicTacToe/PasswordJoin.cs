namespace OnlineTicTacToe
{
    public partial class PasswordJoin : Form
    {
        public EventHandler<string> onPasswordChange;

        public PasswordJoin()
        {
            InitializeComponent();
        }
       
        private void JoinBt_Click_1(object sender, EventArgs e)
        {
            if (lobbyPasswordBox.Text != "")
                onPasswordChange?.Invoke(this, lobbyPasswordBox.Text);

            this.Close();
        }
    }
}
