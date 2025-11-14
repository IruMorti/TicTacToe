namespace OnlineTicTacToe
{
    public partial class LobbyCreate : Form
    {
        GameEngine engine;
        public event EventHandler<string[]> gameStart;

        public LobbyCreate(GameEngine en)
        {
            InitializeComponent();
            engine = en;
            engine.OnConfirmLobbyCreate += Engine_onConfirmLobbyCreate;
            engine.OnDisconnect += Engine_onDisconnect;
        }
       
        private void Engine_onConfirmLobbyCreate(object? sender, string e)
        {
            Invoke(new Action(() => this.Close()));
        }

        private void Engine_onDisconnect(object? sender, string e)
        {
            Invoke(new Action(() => this.Close()));
        }

        private void addLobbyBt_Click(object sender, EventArgs e)
        {
            engine.CrateLobby(lobbyNameBox.Text, lobbyPasswordBox.Text);
        }

        private void LobbyCreate_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.OnConfirmLobbyCreate -= Engine_onConfirmLobbyCreate;
            engine.OnDisconnect -= Engine_onDisconnect;
        }
    }
}