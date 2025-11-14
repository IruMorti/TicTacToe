namespace OnlineTicTacToe
{
    public partial class LobbyBrowser : Form
    {
        private System.Windows.Forms.Timer timer = new();
        private string? selectedLobby = null;
        private int lobbyIndex;
        private GameEngine engine;
        private PasswordJoin passwordJoin = new PasswordJoin();
        public event EventHandler<string[]> gameStart;

        public LobbyBrowser(GameEngine en)
        {
            InitializeComponent();
            engine = en;
            engine.OnLobbyRefresh += Engine_onLobbyRefresh;
            engine.OnLobbyRequest += Engine_onLobbyRequest;
            engine.OnDisconnect += Engine_onDisconnect;
            engine.OnGameStart += Engine_onDisconnect;
            passwordJoin.onPasswordChange += onPasswordChange_Event;
            SetTimer();
            engine.RefreshLobbyList("");
        }
       
        private void SetTimer()
        {
            timer.Interval = 8000;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            int? newIndex = engine.RefreshLobbyList(selectedLobby);
            if (newIndex != null)                          
                lobbyListBox.SelectedIndex = newIndex.Value;                                    
        }

        private void Engine_onLobbyRefresh(object? sender, string[] lobby)
        {
            lobbyListBox.Items.Clear();
            playerInfoLabel.Text = "";
            lobbyListBox.Items.AddRange(lobby);
            lobbyCountLabel.Text = $"Lobbys: {lobbyListBox.Items.Count}";
        }

        private void lobbyListBox_SelectedIndexChanged(object sender, EventArgs e)
        {           
            selectedLobby = lobbyListBox.SelectedItem?.ToString();
            lobbyIndex = lobbyListBox.SelectedIndex;
            playerInfoLabel.Text = engine.GetPlayerName(lobbyIndex);
        }
       
        private void lobbyListBox_DoubleClick(object sender, EventArgs e)
        {
            if (lobbyListBox.Items.Count != 0)            
                engine.LobbyRequest(lobbyIndex);            
        }

        private void lobbyListBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && lobbyListBox.Items.Count != 0)            
                engine.LobbyRequest(lobbyIndex);            
        }

        private void Engine_onLobbyRequest(object? sender, string lobby) 
        { 
            if (lobby == "false")
                engine.LobbyJoin(lobbyIndex, "");
            else if (lobby == "true")
                passwordJoin.ShowDialog();
        }
               
        private void onPasswordChange_Event(object? sender, string password)
        {
            engine.LobbyJoin(lobbyIndex, password);
        }

        private void Engine_onDisconnect(object? sender, string e)
        {
            Invoke(new Action(() => this.Close()));
        }

        private void LobbyBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.OnLobbyRefresh -= Engine_onLobbyRefresh;
            engine.OnLobbyRequest -= Engine_onLobbyRequest;
            engine.OnDisconnect -= Engine_onDisconnect;
            engine.OnGameStart -= Engine_onDisconnect;
            timer.Stop();
        }
    }
}