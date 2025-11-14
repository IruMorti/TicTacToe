namespace OnlineTicTacToe
{
    partial class PasswordJoin
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
            lobbyPasswordBox = new TextBox();
            JoinBt = new Button();
            SuspendLayout();
            // 
            // lobbyPasswordBox
            // 
            lobbyPasswordBox.BackColor = Color.FromArgb(64, 64, 64);
            lobbyPasswordBox.BorderStyle = BorderStyle.None;
            lobbyPasswordBox.Font = new Font("Segoe UI", 14F);
            lobbyPasswordBox.ForeColor = SystemColors.ControlLight;
            lobbyPasswordBox.Location = new Point(117, 40);
            lobbyPasswordBox.Margin = new Padding(4);
            lobbyPasswordBox.Name = "lobbyPasswordBox";
            lobbyPasswordBox.PasswordChar = '*';
            lobbyPasswordBox.Size = new Size(522, 56);
            lobbyPasswordBox.TabIndex = 14;
            // 
            // JoinBt
            // 
            JoinBt.BackColor = Color.FromArgb(64, 64, 64);
            JoinBt.FlatAppearance.BorderSize = 0;
            JoinBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            JoinBt.FlatStyle = FlatStyle.Flat;
            JoinBt.Font = new Font("Segoe UI", 12F);
            JoinBt.ForeColor = SystemColors.ControlLight;
            JoinBt.Location = new Point(117, 116);
            JoinBt.Margin = new Padding(4);
            JoinBt.Name = "JoinBt";
            JoinBt.Size = new Size(521, 56);
            JoinBt.TabIndex = 13;
            JoinBt.Text = "Join";
            JoinBt.UseVisualStyleBackColor = false;
            JoinBt.Click += JoinBt_Click_1;
            // 
            // PasswordJoin
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 30);
            ClientSize = new Size(754, 217);
            Controls.Add(lobbyPasswordBox);
            Controls.Add(JoinBt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "PasswordJoin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PasswordJoin";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox lobbyPasswordBox;
        private Button JoinBt;
    }
}