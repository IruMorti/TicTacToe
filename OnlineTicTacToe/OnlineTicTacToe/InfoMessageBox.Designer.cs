namespace OnlineTicTacToe
{
    partial class InfoMessageBox
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
            infoLabel = new Label();
            okBt = new Button();
            SuspendLayout();
            // 
            // infoLabel
            // 
            infoLabel.Font = new Font("Segoe UI", 12F);
            infoLabel.ForeColor = SystemColors.ControlLight;
            infoLabel.Location = new Point(12, 23);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(880, 99);
            infoLabel.TabIndex = 11;
            infoLabel.Text = "Infotext";
            infoLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // okBt
            // 
            okBt.BackColor = Color.FromArgb(64, 64, 64);
            okBt.DialogResult = DialogResult.OK;
            okBt.FlatAppearance.BorderSize = 0;
            okBt.FlatAppearance.MouseDownBackColor = Color.Gray;
            okBt.FlatStyle = FlatStyle.Flat;
            okBt.Font = new Font("Segoe UI", 12F);
            okBt.ForeColor = SystemColors.ControlLight;
            okBt.Location = new Point(222, 133);
            okBt.Margin = new Padding(4);
            okBt.Name = "okBt";
            okBt.Size = new Size(458, 56);
            okBt.TabIndex = 10;
            okBt.Text = "OK";
            okBt.UseVisualStyleBackColor = false;
            okBt.Click += addLobbyBt_Click;
            // 
            // InfoMessageBox
            // 
            AutoScaleDimensions = new SizeF(15F, 37F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(28, 30, 30);
            ClientSize = new Size(904, 217);
            Controls.Add(infoLabel);
            Controls.Add(okBt);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "InfoMessageBox";
            StartPosition = FormStartPosition.CenterParent;
            Text = "InfoMessageBox";
            ResumeLayout(false);
        }

        #endregion

        private Label infoLabel;
        private Button okBt;
    }
}