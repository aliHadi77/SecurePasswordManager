namespace SecurePasswordManager.Forms
{
    partial class UnlockVaultForm
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
            label1 = new Label();
            txtMasterPassword = new TextBox();
            btnUnlock = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(362, 78);
            label1.Name = "label1";
            label1.Size = new Size(86, 25);
            label1.TabIndex = 0;
            label1.Text = "فتح الخزنة";
            // 
            // txtMasterPassword
            // 
            txtMasterPassword.Location = new Point(251, 156);
            txtMasterPassword.Name = "txtMasterPassword";
            txtMasterPassword.Size = new Size(282, 31);
            txtMasterPassword.TabIndex = 1;
            txtMasterPassword.UseSystemPasswordChar = true;
            // 
            // btnUnlock
            // 
            btnUnlock.Location = new Point(444, 220);
            btnUnlock.Name = "btnUnlock";
            btnUnlock.Size = new Size(112, 34);
            btnUnlock.TabIndex = 2;
            btnUnlock.Text = "فتح الخزنة";
            btnUnlock.UseVisualStyleBackColor = true;
            btnUnlock.Click += btnUnlock_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(241, 220);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 3;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // UnlockVaultForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnUnlock);
            Controls.Add(txtMasterPassword);
            Controls.Add(label1);
            Name = "UnlockVaultForm";
            Text = "UnlockVaultForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMasterPassword;
        private Button btnUnlock;
        private Button btnCancel;
    }
}