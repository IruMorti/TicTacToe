namespace OnlineTicTacToe
{
    partial class LobbyBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lobbyListBox = new ListBox();
            headerLabel = new Label();
            label1 = new Label();
            playerInfoLabel = new Label();
            lobbyCountLabel = new Label();
            SuspendLayout();
            // 
            // lobbyListBox
            // 
            lobbyListBox.BackColor = Color.FromArgb(64, 64, 64);
            lobbyListBox.BorderStyle = BorderStyle.None;
            lobbyListBox.Font = new Font("Segoe UI", 14F);
            lobbyListBox.ForeColor = SystemColors.ControlLight;
            lobbyListBox.FormattingEnabled = true;
            lobbyListBox.ItemHeight = 50;
            lobbyListBox.Location = new Point(10, 83);
            lobbyListBox.Name = "lobbyListBox";
            lobbyListBox.Size = new Size(897, 350);
            lobbyListBox.TabIndex = 0;
            lobbyListBox.SelectedIndexChanged += lobbyListBox_SelectedIndexChanged;
            lobbyListBox.DoubleClick += lobbyListBox_DoubleClick;
            lobbyListBox.KeyPress += lobbyListBox_KeyPress;
            // 
            // headerLabel
            // 
            headerLabel.AutoSize = true;
            headerLabel.Font = new Font("Segoe UI", 18F);
            headerLabel.ForeColor = SystemColors.ControlLight;
            headerLabel.Location = new Point(10, 8);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(347, 65);
            headerLabel.TabIndex = 12;
            headerLabel.Text = "Lobby-Browser";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(10, 496);
            label1.Name = "label1";
            label1.Size = new Size(112, 45);
            label1.TabIndex = 13;
            label1.Text = "Player:";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // playerInfoLabel
            // 
            playerInfoLabel.AutoSize = true;
            playerInfoLabel.Font = new Font("Segoe UI", 12F);
            playerInfoLabel.ForeColor = SystemColors.ControlLight;
            playerInfoLabel.Location = new Point(123, 496);
            playerInfoLabel.Name = "playerInfoLabel";
            playerInfoLabel.Size = new Size(0, 45);
            playerInfoLabel.TabIndex = 14;
            playerInfoLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lobbyCountLabel
            // 
            lobbyCountLabel.Font = new Font("Segoe UI", 12F);
            lobbyCountLabel.ForeColor = SystemColors.ControlLight;
            lobbyCountLabel.Location = new Point(679, 496);
            lobbyCountLabel.Name = "lobbyCountLabel";
            lobbyCountLabel.RightToLeft = RightToLeft.No;
            lobbyCountLabel.Size = new Size(228, 42);
            lobbyCountLabel.TabIndex = 15;
            lobbyCountLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // LobbyBrowser
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 30);
            ClientSize = new Size(918, 560);
            Controls.Add(lobbyCountLabel);
            Controls.Add(playerInfoLabel);
            Controls.Add(label1);
            Controls.Add(headerLabel);
            Controls.Add(lobbyListBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LobbyBrowser";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LobbyBrowser";
            FormClosing += LobbyBrowser_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lobbyListBox;
        private Label headerLabel;
        private Label label1;
        private Label playerInfoLabel;
        private Label lobbyCountLabel;
    }
}