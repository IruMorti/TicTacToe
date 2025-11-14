namespace OnlineTicTacToe
{
    partial class Chat
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            headerLbl = new Label();
            inputBox = new TextBox();
            submitBt = new Button();
            buttomPanel = new Panel();
            flowChatPanel = new FlowLayoutPanel();
            buttomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerLbl
            // 
            headerLbl.BackColor = Color.FromArgb(64, 64, 64);
            headerLbl.Dock = DockStyle.Top;
            headerLbl.Font = new Font("Segoe UI", 14F);
            headerLbl.ForeColor = SystemColors.ControlLight;
            headerLbl.Location = new Point(0, 0);
            headerLbl.Margin = new Padding(2, 0, 2, 5);
            headerLbl.Name = "headerLbl";
            headerLbl.Size = new Size(587, 23);
            headerLbl.TabIndex = 0;
            headerLbl.Text = "Game-Chat";
            headerLbl.TextAlign = ContentAlignment.TopCenter;
            // 
            // inputBox
            // 
            inputBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            inputBox.BackColor = Color.FromArgb(64, 64, 64);
            inputBox.BorderStyle = BorderStyle.None;
            inputBox.Font = new Font("Segoe UI", 12F);
            inputBox.ForeColor = SystemColors.ControlLight;
            inputBox.Location = new Point(2, 2);
            inputBox.Margin = new Padding(2, 1, 2, 1);
            inputBox.MaxLength = 100;
            inputBox.Name = "inputBox";
            inputBox.Size = new Size(509, 22);
            inputBox.TabIndex = 0;
            inputBox.TextChanged += inputBox_TextChanged;
            inputBox.KeyPress += InputBox_KeyPress;
            // 
            // submitBt
            // 
            submitBt.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            submitBt.BackColor = Color.FromArgb(64, 64, 64);
            submitBt.FlatAppearance.BorderColor = Color.FromArgb(128, 128, 255);
            submitBt.FlatAppearance.BorderSize = 0;
            submitBt.ForeColor = SystemColors.ControlLight;
            submitBt.Location = new Point(512, 1);
            submitBt.Margin = new Padding(16, 14, 16, 14);
            submitBt.Name = "submitBt";
            submitBt.Size = new Size(76, 23);
            submitBt.TabIndex = 2;
            submitBt.Text = "Submit";
            submitBt.UseVisualStyleBackColor = false;
            submitBt.Click += SubmitBt_Click;
            // 
            // buttomPanel
            // 
            buttomPanel.AutoSize = true;
            buttomPanel.BackColor = Color.FromArgb(64, 64, 64);
            buttomPanel.Controls.Add(submitBt);
            buttomPanel.Controls.Add(inputBox);
            buttomPanel.Dock = DockStyle.Bottom;
            buttomPanel.Location = new Point(0, 234);
            buttomPanel.Margin = new Padding(2, 5, 2, 1);
            buttomPanel.Name = "buttomPanel";
            buttomPanel.Size = new Size(587, 25);
            buttomPanel.TabIndex = 2;
            // 
            // flowChatPanel
            // 
            flowChatPanel.AutoScroll = true;
            flowChatPanel.AutoSize = true;
            flowChatPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowChatPanel.BackColor = Color.FromArgb(28, 30, 30);
            flowChatPanel.Dock = DockStyle.Fill;
            flowChatPanel.FlowDirection = FlowDirection.TopDown;
            flowChatPanel.Location = new Point(0, 23);
            flowChatPanel.Margin = new Padding(2, 1, 2, 1);
            flowChatPanel.Name = "flowChatPanel";
            flowChatPanel.Size = new Size(587, 211);
            flowChatPanel.TabIndex = 3;
            flowChatPanel.WrapContents = false;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(flowChatPanel);
            Controls.Add(buttomPanel);
            Controls.Add(headerLbl);
            Margin = new Padding(2, 1, 2, 1);
            Name = "Chat";
            Size = new Size(587, 259);
            buttomPanel.ResumeLayout(false);
            buttomPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label headerLbl;
        private TextBox inputBox;
        private Button submitBt;
        private Panel buttomPanel;
        private FlowLayoutPanel flowChatPanel;
    }
}
