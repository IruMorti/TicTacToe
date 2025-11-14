using ChatWindowTest;
using System.Windows.Forms;

namespace OnlineTicTacToe
{
    public partial class TicTacToeFeld : Form
    {
        private GameEngine engine;
        private Button[] buttons;
        private PlayerStats stats;
        private Chat chat;
        private System.Windows.Forms.Timer resetButtons = new();

        public TicTacToeFeld(GameEngine en)
        {
            engine = en;
            InitializeComponent();
            AddNewChat();
            engine.OnLobbyLeave += Engine_OnLobbyLeave;
            engine.OnDisconnect += Engine_OnDisconnect;
            engine.OnSetField += Engine_OnSetField;
            engine.OnResetFields += Engine_OnResetFields;
            engine.OnSetWinnigCobination += Engine_OnSetWinnigCobination;
            engine.OnStatsChange += Engine_OnStatsChange;
            engine.OnChatMsg += Engine_OnChatMsg;
            resetButtons.Interval = 3000;
            resetButtons.Tick += RestButtons_Tick;            
            buttons = [feld0, feld1, feld2, feld3, feld4, feld5, feld6, feld7, feld8];
        }

        private void AddNewChat()
        {
            chat = new Chat(engine);
            chat.Visible = false;
            Controls.Add(chat);
            chat.BringToFront();
            chat.Dock = DockStyle.Fill;
        }


        public void FeldClickClick(object sender, EventArgs e)
        {
            Button feld = (Button)sender;
            foreach (Button button in buttons) 
            {
                if (button == feld)
                    engine.SendGameResources(feld.TabIndex);
            }
        }

        private void Engine_OnSetField(object? sender, string[] fieldDescription)
        {
            Button setFeld = buttons[Convert.ToInt32(fieldDescription[1])];            //Select the button
            Invoke(new Action(() => setFeld.Text = fieldDescription[0].ToString()));   //Set the symbol
        }

        private void Engine_OnResetFields(object? sender, string e)
        {
            Invoke(new Action(() =>
            {
                foreach (Button button in buttons)
                    button.Text = "";
            }));
        }

        private void Engine_OnSetWinnigCobination(object? sender, string[] winnigCombination)
        {
            Invoke(new Action(() =>
            {
                foreach (Button button in buttons)
                    button.Enabled = false;

                for (int i = 0; i < winnigCombination.Length; i++)
                {
                    buttons[Convert.ToInt32(winnigCombination[i])].BackColor = SystemColors.ControlLight;
                }
                resetButtons.Start();
            }));
        }

        private void RestButtons_Tick(object? sender, EventArgs e)
        {
            resetButtons.Stop();
            foreach (Button button in buttons)
            {
                button.Enabled = true;
                button.Text = "";
                button.BackColor = Color.FromArgb(51, 51, 51);
            }
        }

        private void Engine_OnStatsChange(object? sender, PlayerStats stats)
        {
            Invoke(new Action(() =>
            {
                this.stats = stats;
                lblPlayerName1.Text = stats.player1;
                lblPlayerName2.Text = stats.player2;
                lblSymbol1.Text = ($"Symbol: {stats.player1Symbol}");
                lblSymbol2.Text = ($"Symbol: {stats.player2Symbol}");
                lblWon1.Text = ($"Wins: {stats.player1Won}");
                lblWon2.Text = ($"Wins: {stats.player2Won}");
                lblStart.Text = stats.startSymbol;
            }));
        }

        private void Engine_OnLobbyLeave(object? sender, string info)
        {
            new InfoMessageBox("Lobby was closed").ShowDialog();
            Invoke(new Action(() => this.Close()));
        }

        private void ChatBt_Click(object sender, EventArgs e)
        {
            chat.Visible = true;
        }

        private void Engine_OnChatMsg(object? sender, string[] msgInfos)
        {
            Invoke(new Action(() =>
            {
                string userName = msgInfos[1];
                string msg = msgInfos[2];
                tbChatView.Text = $"{userName}: {msg}\r\n";

                if (msgInfos[0] == engine.UID.ToString())            
                    chat.AddMsgRight(userName, msg);            
                else            
                    chat.AddMsgLeft(userName, msg);
            }));
        }


        private void InputBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void Engine_OnDisconnect(object? sender, string info)
        {
            Invoke(new Action(() => this.Close()));
        }

        private void TicTacToeFeld_FormClosing(object sender, FormClosingEventArgs e)
        {
            engine.OnLobbyLeave -= Engine_OnLobbyLeave;
            engine.OnDisconnect -= Engine_OnDisconnect;
            engine.OnSetField -= Engine_OnSetField;
            engine.OnResetFields -= Engine_OnResetFields;
            engine.OnSetWinnigCobination -= Engine_OnSetWinnigCobination;
            engine.OnStatsChange -= Engine_OnStatsChange;
            engine.OnChatMsg -= Engine_OnChatMsg;
            engine.LobbyLeave();
        }       
    }
}
