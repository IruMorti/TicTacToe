using Microsoft.VisualBasic.Devices;

namespace OnlineTicTacToe
{
    public partial class ServerConnect : Form
    {
        private GameEngine engine = new GameEngine();

        public ServerConnect()
        {
            InitializeComponent();
        }

        private async void connectBt_Click(object sender, EventArgs e)
        {
            connectBt.Enabled = false;
            if (await engine.Connect(ipBox.Text) == true)
            {
                var newLauncher = new Launcher(engine);
                Program.Context.MainForm = newLauncher;                
                newLauncher.Show();
                this.Close();
            }
            connectBt.Enabled = true;
        }

        private void ipBox_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (e.KeyChar == '\r')
                connectBt_Click((object) sender, e);
        }         
    }
}
