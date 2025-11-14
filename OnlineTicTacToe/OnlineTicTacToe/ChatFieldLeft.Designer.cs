namespace ChatWindowTest
{
    partial class ChatFieldLeft
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
            userNameLbl = new Label();
            messageLbl = new Label();
            SuspendLayout();
            // 
            // userNameLbl
            // 
            userNameLbl.BackColor = Color.Transparent;
            userNameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            userNameLbl.ForeColor = SystemColors.ControlLight;
            userNameLbl.Location = new Point(15, 0);
            userNameLbl.Name = "userNameLbl";
            userNameLbl.RightToLeft = RightToLeft.No;
            userNameLbl.Size = new Size(430, 45);
            userNameLbl.TabIndex = 1;
            userNameLbl.Text = "userName";
            // 
            // messageLbl
            // 
            messageLbl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            messageLbl.AutoSize = true;
            messageLbl.BackColor = Color.FromArgb(64, 64, 64);
            messageLbl.FlatStyle = FlatStyle.Flat;
            messageLbl.Font = new Font("Segoe UI", 12F);
            messageLbl.ForeColor = SystemColors.ControlLight;
            messageLbl.Location = new Point(15, 52);
            messageLbl.Margin = new Padding(15, 0, 0, 15);
            messageLbl.MaximumSize = new Size(800, 0);
            messageLbl.Name = "messageLbl";
            messageLbl.Padding = new Padding(8);
            messageLbl.RightToLeft = RightToLeft.No;
            messageLbl.Size = new Size(52, 37);
            messageLbl.TabIndex = 2;
            messageLbl.Text = "Text";
            messageLbl.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // ChatFieldLeft
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.Transparent;
            Controls.Add(messageLbl);
            Controls.Add(userNameLbl);
            Name = "ChatFieldLeft";
            RightToLeft = RightToLeft.No;
            Size = new Size(448, 141);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label userNameLbl;
        private Label messageLbl;
    }
}
