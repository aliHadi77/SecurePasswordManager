namespace SecurePasswordManager.Forms
{
    partial class CreateVaultForm
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
            txtMasterPassword = new TextBox();
            button1 = new Button();
            txtConfirmPassword = new TextBox();
            btnCreateVault = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // txtMasterPassword
            // 
            txtMasterPassword.Location = new Point(126, 199);
            txtMasterPassword.Name = "txtMasterPassword";
            txtMasterPassword.Size = new Size(362, 31);
            txtMasterPassword.TabIndex = 1;
            txtMasterPassword.UseSystemPasswordChar = true;
            // 
            // button1
            // 
            button1.Location = new Point(287, 83);
            button1.Name = "button1";
            button1.Size = new Size(257, 80);
            button1.TabIndex = 2;
            button1.Text = "إنشاء خزنة جديدة  ";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Location = new Point(126, 247);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(362, 31);
            txtConfirmPassword.TabIndex = 3;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnCreateVault
            // 
            btnCreateVault.Location = new Point(536, 199);
            btnCreateVault.Name = "btnCreateVault";
            btnCreateVault.Size = new Size(112, 34);
            btnCreateVault.TabIndex = 4;
            btnCreateVault.Text = "إنشاء الخزنة ";
            btnCreateVault.UseVisualStyleBackColor = true;
            btnCreateVault.Click += btnCreateVault_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(536, 247);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "إلغاء";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CreateVaultForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnCreateVault);
            Controls.Add(txtConfirmPassword);
            Controls.Add(button1);
            Controls.Add(txtMasterPassword);
            Name = "CreateVaultForm";
            Text = "CreateVaultForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMasterPassword;
        private Button button1;
        private TextBox txtConfirmPassword;
        private Button btnCreateVault;
        private Button btnCancel;
    }
}