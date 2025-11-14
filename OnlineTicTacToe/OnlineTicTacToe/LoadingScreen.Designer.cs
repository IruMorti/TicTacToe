namespace OnlineTicTacToe
{
    partial class LoadingScreen
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
            label1 = new Label();
            CloseBt = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(6, 61, 13);
            label1.Font = new Font("Segoe UI", 14F);
            label1.ForeColor = SystemColors.ControlLight;
            label1.Location = new Point(3, 12);
            label1.Name = "label1";
            label1.Size = new Size(466, 57);
            label1.TabIndex = 5;
            label1.Text = "Wait for another player!";
            // 
            // CloseBt
            // 
            CloseBt.BackColor = Color.FromArgb(6, 61, 13);
            CloseBt.FlatAppearance.BorderSize = 0;
            CloseBt.FlatAppearance.MouseDownBackColor = Color.FromArgb(6, 61, 13);
            CloseBt.FlatAppearance.MouseOverBackColor = Color.DarkGreen;
            CloseBt.FlatStyle = FlatStyle.Flat;
            CloseBt.Font = new Font("Segoe UI", 11F);
            CloseBt.ForeColor = SystemColors.ControlLight;
            CloseBt.Location = new Point(543, 6);
            CloseBt.Name = "CloseBt";
            CloseBt.Size = new Size(69, 69);
            CloseBt.TabIndex = 4;
            CloseBt.Text = "X";
            CloseBt.UseVisualStyleBackColor = false;
            CloseBt.Click += CloseBt_Click;
            // 
            // LoadingScreen
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 61, 13);
            Controls.Add(label1);
            Controls.Add(CloseBt);
            Name = "LoadingScreen";
            Size = new Size(615, 82);
            VisibleChanged += LoadingScreen_VisibleChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button CloseBt;
    }
}
