namespace OnlineTicTacToe
{
    public partial class Launcher : Form
    {
        private GameEngine engine;
        
        public Launcher(GameEngine en)
        {
            InitializeComponent();
            engine = en;
            engine.OnInfoMsg += Engine_onInfoMsg;
            engine.OnLogin += Engine_onLogin;
            engine.OnGameStart += Engine_onGameStart;
            engine.OnConfirmLobbyCreate += Engine_onConfirmLobbyCreate;
            engine.OnDisconnect += Engine_onDisconnect;          
            engine.OnError += Engine_onError;
            this.LoadingScreen.onEndPlayerSearch += LoadingScreen_onEndPlayerSearch;           
        }
     
        private void addUserBt_Click(object sender, EventArgs e)
        {
            engine.CreateNewUser(usernameBox.Text);
        }

        private void usernameBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
                addUserBt_Click((object)sender, e);
        }

        private void createBt_Click(object sender, EventArgs e)
        {           
            new LobbyCreate(engine).ShowDialog();
        }       

        private void joinBt_Click(object sender, EventArgs e)
        {
            new LobbyBrowser(engine).ShowDialog();
        }

        private void LoadingScreen_onEndPlayerSearch(object? sender, EventArgs e)
        {
            Invoke(new Action(() => engine.LobbyLeave()));
        }

        private void reconnectBt_Click(object sender, EventArgs e)
        {
            engine.Reconnect();
        }

        //Events from GameEngine

        private void Engine_onConfirmLobbyCreate(object? sender, string e)
        {           
            Invoke(new Action(() => LoadingScreen.Show()));
        }
       
        private void Engine_onGameStart(object? sender, string startInfos)
        {
            Invoke(new Action(() =>
            {
                new TicTacToeFeld(engine).Show();
                LoadingScreen.Hide();           
            }));
        }
      
        private void Engine_onLogin(object? sender, string msg)
        {
            Invoke(new Action(() =>
            {
                addUserBt.Hide();
                usernameBox.Hide();
                reconnectBt.Hide();
                joinBt.Show();
                createBt.Show();
                joinBt.Enabled = true;
                createBt.Enabled = true;
                infoLable.Text = msg;
                this.Text = "TicTacToe-Launcher";
                headerLabel.Text = "Join or create a lobby.";
                infoLable.ForeColor = Color.LightGreen;
            }));
        }

        private void Engine_onInfoMsg(object? sender, string? msg)
        {
            infoLable.Text = msg;
        }

        private void Engine_onDisconnect(object? sender, string disconnectMsg)
        {
            Invoke(new Action(() =>
            {
                infoLable.ForeColor = Color.OrangeRed;
                infoLable.Text = disconnectMsg;
                joinBt.Enabled = false;
                createBt.Enabled = false;
                LoadingScreen.Hide();
                reconnectBt.Show();
            }));
        }

        private void Engine_onError(object? sender, string errorMsg)
        {
            new InfoMessageBox(errorMsg).ShowDialog();            
        }
     
        private void Launcher_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.OnInfoMsg -= Engine_onInfoMsg;
            engine.OnLogin -= Engine_onLogin;
            engine.OnGameStart -= Engine_onGameStart;
            engine.OnConfirmLobbyCreate -= Engine_onConfirmLobbyCreate;
            engine.OnDisconnect -= Engine_onDisconnect;
            engine.OnError -= Engine_onError;
            this.LoadingScreen.onEndPlayerSearch -= LoadingScreen_onEndPlayerSearch;
            engine.Disconnect();
        }
    }
}
