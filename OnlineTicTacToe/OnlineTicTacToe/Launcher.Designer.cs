namespace OnlineTicTacToe
{
    partial class Launcher
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
            headerLabel = new Label();
            usernameBox = new TextBox();
            addUserBt = new Button();
            infoLable = new Label();
            joinBt = new Button();
            createBt = new Button();
            reconnectBt = new Button();
            LoadingScreen = new LoadingScreen();
            SuspendLayout();
            // 
            // headerLabel
            // 
            headerLabel.Font = new Font("Segoe UI", 12F);
            headerLabel.ForeColor = SystemColors.ControlLight;
            headerLabel.Location = new Point(302, 9);
            headerLabel.Name = "headerLabel";
            headerLabel.Size = new Size(460, 47);
            headerLabel.TabIndex = 6;
            headerLabel.Text = "Type your username.";
            headerLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // usernameBox
            // 
            usernameBox.BackColor = Color.FromArgb(64, 64, 64);
            usernameBox.BorderStyle = BorderStyle.None;
            usernameBox.Font = new Font("Segoe UI", 14F);
            usernameBox.ForeColor = SystemColors.ControlLight;
            usernameBox.Location = new Point(302, 68);
            usernameBox.Name = "usernameBox";
            usernameBox.Size = new Size(459, 56);
            usernameBox.TabIndex = 5;
            usernameBox.KeyPress += usernameBox_KeyPress;
            // 
            // addUserBt
            // 
            addUserBt.BackColor = Color.FromArgb(64, 64, 64);
            addUserBt.FlatAppearance.BorderSize = 0;
            addUserBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            addUserBt.FlatStyle = FlatStyle.Flat;
            addUserBt.Font = new Font("Segoe UI", 12F);
            addUserBt.ForeColor = SystemColors.ControlLight;
            addUserBt.Location = new Point(302, 141);
            addUserBt.Name = "addUserBt";
            addUserBt.Size = new Size(458, 56);
            addUserBt.TabIndex = 4;
            addUserBt.TabStop = false;
            addUserBt.Text = "Add user!";
            addUserBt.UseVisualStyleBackColor = false;
            addUserBt.Click += addUserBt_Click;
            // 
            // infoLable
            // 
            infoLable.AutoSize = true;
            infoLable.Font = new Font("Segoe UI", 11F);
            infoLable.ForeColor = SystemColors.ControlLight;
            infoLable.Location = new Point(3, 201);
            infoLable.Name = "infoLable";
            infoLable.Size = new Size(0, 45);
            infoLable.TabIndex = 7;
            infoLable.TextAlign = ContentAlignment.TopCenter;
            // 
            // joinBt
            // 
            joinBt.BackColor = Color.FromArgb(64, 64, 64);
            joinBt.FlatAppearance.BorderSize = 0;
            joinBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            joinBt.FlatStyle = FlatStyle.Flat;
            joinBt.Font = new Font("Segoe UI", 12F);
            joinBt.ForeColor = SystemColors.ControlLight;
            joinBt.Location = new Point(144, 98);
            joinBt.Name = "joinBt";
            joinBt.Size = new Size(380, 56);
            joinBt.TabIndex = 8;
            joinBt.Text = "Join";
            joinBt.UseVisualStyleBackColor = false;
            joinBt.Visible = false;
            joinBt.Click += joinBt_Click;
            // 
            // createBt
            // 
            createBt.BackColor = Color.FromArgb(64, 64, 64);
            createBt.FlatAppearance.BorderSize = 0;
            createBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            createBt.FlatStyle = FlatStyle.Flat;
            createBt.Font = new Font("Segoe UI", 12F);
            createBt.ForeColor = SystemColors.ControlLight;
            createBt.Location = new Point(537, 98);
            createBt.Name = "createBt";
            createBt.Size = new Size(380, 56);
            createBt.TabIndex = 9;
            createBt.Text = "Create";
            createBt.UseVisualStyleBackColor = false;
            createBt.Visible = false;
            createBt.Click += createBt_Click;
            // 
            // reconnectBt
            // 
            reconnectBt.BackColor = Color.FromArgb(64, 64, 64);
            reconnectBt.FlatAppearance.BorderSize = 0;
            reconnectBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            reconnectBt.FlatStyle = FlatStyle.Flat;
            reconnectBt.Font = new Font("Segoe UI", 9F);
            reconnectBt.ForeColor = SystemColors.ControlLight;
            reconnectBt.Location = new Point(807, 201);
            reconnectBt.Name = "reconnectBt";
            reconnectBt.Size = new Size(239, 47);
            reconnectBt.TabIndex = 10;
            reconnectBt.Text = "Reconnect";
            reconnectBt.UseVisualStyleBackColor = false;
            reconnectBt.Visible = false;
            reconnectBt.Click += reconnectBt_Click;
            // 
            // LoadingScreen
            // 
            LoadingScreen.BackColor = Color.FromArgb(6, 61, 13);
            LoadingScreen.Location = new Point(223, 0);
            LoadingScreen.Name = "LoadingScreen";
            LoadingScreen.Size = new Size(618, 80);
            LoadingScreen.TabIndex = 11;
            LoadingScreen.Visible = false;
            // 
            // Launcher
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 30);
            ClientSize = new Size(1059, 256);
            Controls.Add(LoadingScreen);
            Controls.Add(reconnectBt);
            Controls.Add(infoLable);
            Controls.Add(headerLabel);
            Controls.Add(usernameBox);
            Controls.Add(addUserBt);
            Controls.Add(createBt);
            Controls.Add(joinBt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Launcher";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "AddUser";
            FormClosing += Launcher_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLabel;
        private TextBox usernameBox;
        private Button addUserBt;
        private Label infoLable;
        private Button joinBt;
        private Button createBt;
        private Button reconnectBt;
        private LoadingScreen LoadingScreen;
    }
}