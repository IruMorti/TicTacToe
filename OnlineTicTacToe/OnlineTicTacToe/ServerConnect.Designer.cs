namespace OnlineTicTacToe
{
    partial class ServerConnect
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            connectBt = new Button();
            ipBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // connectBt
            // 
            connectBt.BackColor = Color.FromArgb(64, 64, 64);
            connectBt.FlatAppearance.BorderSize = 0;
            connectBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            connectBt.FlatStyle = FlatStyle.Flat;
            connectBt.Font = new Font("Segoe UI", 12F);
            connectBt.ForeColor = SystemColors.ControlLight;
            connectBt.Location = new Point(249, 42);
            connectBt.Margin = new Padding(2, 2, 2, 2);
            connectBt.Name = "connectBt";
            connectBt.Size = new Size(102, 29);
            connectBt.TabIndex = 1;
            connectBt.Text = "Connect";
            connectBt.UseVisualStyleBackColor = false;
            connectBt.Click += connectBt_Click;
            // 
            // ipBox
            // 
            ipBox.BackColor = Color.FromArgb(64, 64, 64);
            ipBox.BorderStyle = BorderStyle.None;
            ipBox.Font = new Font("Segoe UI", 14F);
            ipBox.ForeColor = SystemColors.ControlLight;
            ipBox.Location = new Point(7, 42);
            ipBox.Margin = new Padding(2, 2, 2, 2);
            ipBox.Name = "ipBox";
            ipBox.Size = new Size(238, 25);
            ipBox.TabIndex = 2;
            ipBox.Text = "127.0.0.1";
            ipBox.KeyPress += ipBox_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(7, 5);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(135, 21);
            label1.TabIndex = 3;
            label1.Text = "Type the server ip.";
            // 
            // ServerConnect
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 30);
            ClientSize = new Size(358, 81);
            Controls.Add(label1);
            Controls.Add(ipBox);
            Controls.Add(connectBt);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(2, 2, 2, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ServerConnect";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "TicTacToe-Online";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button connectBt;
        private TextBox ipBox;
        private Label label1;
    }
}
