using System.Numerics;

namespace OnlineTicTacToe
{
    public partial class LoadingScreen : UserControl
    {
        public event EventHandler onEndPlayerSearch;
        private System.Windows.Forms.Timer timer = new();
        private System.Windows.Forms.Timer transitionTimer = new();
        private int loadingScreenPostion;
        private int startPosition;
        private int movingLength;

        public LoadingScreen()
        {
            InitializeComponent();
            timer.Interval = 600;
            timer.Tick += Timer_Tick;
            transitionTimer.Tick += TransitionTimer_Tick;
            movingLength = Size.Height;
            loadingScreenPostion = Location.Y - movingLength;           
        }

        private void TransitionTimer_Tick(object? sender, EventArgs e)
        {
            if (movingLength >= startPosition && Visible == true)
            {
                this.Location = new Point(this.Location.X, startPosition++);
                movingLength--;
            }
            else
            {
                movingLength = this.Size.Height;
                transitionTimer.Stop();
            }
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            label1.Text += " .";
            if (label1.Text.Length >= 31)
                label1.Text = "Wait for another player!";
        }

        private void CloseBt_Click(object sender, EventArgs e)
        {
            onEndPlayerSearch?.Invoke(this, EventArgs.Empty); 
            this.Hide();
        }

        private void LoadingScreen_VisibleChanged(object sender, EventArgs e)
        {
            transitionTimer.Interval = 5;
            transitionTimer.Start();

            if (Visible == true)
                timer.Start();
            else
            {
                startPosition = loadingScreenPostion;
                timer.Stop();
            }
        }                
    }
}
