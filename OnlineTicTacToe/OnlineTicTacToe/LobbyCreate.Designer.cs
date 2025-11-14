namespace OnlineTicTacToe
{
    partial class LobbyCreate
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
            nameLabel = new Label();
            lobbyNameBox = new TextBox();
            addLobbyBt = new Button();
            passwordLabel = new Label();
            headerLabel = new Label();
            lobbyPasswordBox = new TextBox();
            SuspendLayout();
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Font = new Font("Segoe UI", 12F);
            nameLabel.ForeColor = SystemColors.ControlLight;
            nameLabel.Location = new Point(45, 99);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(234, 48);
            nameLabel.TabIndex = 9;
            nameLabel.Text = "Lobby-Name:";
            nameLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lobbyNameBox
            // 
            lobbyNameBox.BackColor = Color.FromArgb(64, 64, 64);
            lobbyNameBox.BorderStyle = BorderStyle.None;
            lobbyNameBox.Font = new Font("Segoe UI", 14F);
            lobbyNameBox.ForeColor = SystemColors.ControlLight;
            lobbyNameBox.Location = new Point(45, 151);
            lobbyNameBox.Name = "lobbyNameBox";
            lobbyNameBox.Size = new Size(459, 56);
            lobbyNameBox.TabIndex = 8;
            // 
            // addLobbyBt
            // 
            addLobbyBt.BackColor = Color.FromArgb(64, 64, 64);
            addLobbyBt.FlatAppearance.BorderSize = 0;
            addLobbyBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            addLobbyBt.FlatStyle = FlatStyle.Flat;
            addLobbyBt.Font = new Font("Segoe UI", 12F);
            addLobbyBt.ForeColor = SystemColors.ControlLight;
            addLobbyBt.Location = new Point(45, 394);
            addLobbyBt.Name = "addLobbyBt";
            addLobbyBt.Size = new Size(458, 56);
            addLobbyBt.TabIndex = 7;
            addLobbyBt.Text = "Add your Lobby!";
            addLobbyBt.UseVisualStyleBackColor = false;
            addLobbyBt.Click += addLobbyBt_Click;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Font = new Font("Segoe UI", 12F);
            passwordLabel.ForeColor = SystemColors.ControlLight;
            passwordLabel.Location = new Point(45, 224);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(287, 48);
            passwordLabel.TabIndex = 10;
            passwordLabel.Text = "Lobby-Password:";
            passwordLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Segoe UI", 18F);
            headerLabel.ForeColor = SystemColors.ControlLight;
            headerLabel.Location = new Point(45, 17);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(459, 84);
            headerLabel.TabIndex = 11;
            headerLabel.Text = "Your lobby";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // lobbyPasswordBox
            // 
            lobbyPasswordBox.BackColor = Color.FromArgb(64, 64, 64);
            lobbyPasswordBox.BorderStyle = BorderStyle.None;
            lobbyPasswordBox.Font = new Font("Segoe UI", 14F);
            lobbyPasswordBox.ForeColor = SystemColors.ControlLight;
            lobbyPasswordBox.Location = new Point(45, 276);
            lobbyPasswordBox.Name = "lobbyPasswordBox";
            lobbyPasswordBox.PasswordChar = '*';
            lobbyPasswordBox.Size = new Size(459, 56);
            lobbyPasswordBox.TabIndex = 12;
            // 
            // LobbyCreate
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 30);
            ClientSize = new Size(550, 481);
            Controls.Add(lobbyPasswordBox);
            Controls.Add(headerLabel);
            Controls.Add(passwordLabel);
            Controls.Add(nameLabel);
            Controls.Add(lobbyNameBox);
            Controls.Add(addLobbyBt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "LobbyCreate";
            StartPosition = FormStartPosition.CenterParent;
            Text = "LobbyCreate";
            FormClosing += LobbyCreate_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLabel;
        private TextBox lobbyNameBox;
        private Button addLobbyBt;
        private Label passwordLabel;
        private Label headerLabel;
        private TextBox lobbyPasswordBox;
    }
}