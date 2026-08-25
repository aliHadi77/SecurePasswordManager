namespace SecurePasswordManager
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblVaultStatus = new Label();
            btnCreateVault = new Button();
            btnUnlockVault = new Button();
            btnLockVault = new Button();
            btnAccounts = new Button();
            btnPasswordGenerator = new Button();
            SuspendLayout();

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font =
                new Font(
                    "Arial",
                    18F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    178);

            lblTitle.Location =
                new Point(250, 55);

            lblTitle.Name =
                "lblTitle";

            lblTitle.Size =
                new Size(300, 43);

            lblTitle.TabIndex =
                0;

            lblTitle.Text =
                "مدير كلمات المرور الآمن";

            // 
            // lblVaultStatus
            // 
            lblVaultStatus.AutoSize = true;

            lblVaultStatus.Font =
                new Font(
                    "Arial",
                    12F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    178);

            lblVaultStatus.Location =
                new Point(300, 120);

            lblVaultStatus.Name =
                "lblVaultStatus";

            lblVaultStatus.Size =
                new Size(200, 28);

            lblVaultStatus.TabIndex =
                1;

            lblVaultStatus.Text =
                "حالة الخزنة: مقفلة";

            // 
            // btnCreateVault
            // 
            btnCreateVault.Location =
                new Point(270, 180);

            btnCreateVault.Name =
                "btnCreateVault";

            btnCreateVault.Size =
                new Size(260, 45);

            btnCreateVault.TabIndex =
                2;

            btnCreateVault.Text =
                "إنشاء خزنة جديدة";

            btnCreateVault.UseVisualStyleBackColor =
                true;

            btnCreateVault.Click +=
                btnCreateVault_Click;

            // 
            // btnUnlockVault
            // 
            btnUnlockVault.Location =
                new Point(270, 240);

            btnUnlockVault.Name =
                "btnUnlockVault";

            btnUnlockVault.Size =
                new Size(260, 45);

            btnUnlockVault.TabIndex =
                3;

            btnUnlockVault.Text =
                "فتح الخزنة";

            btnUnlockVault.UseVisualStyleBackColor =
                true;

            btnUnlockVault.Click +=
                btnUnlockVault_Click;

            // 
            // btnLockVault
            // 
            btnLockVault.Location =
                new Point(270, 300);

            btnLockVault.Name =
                "btnLockVault";

            btnLockVault.Size =
                new Size(260, 45);

            btnLockVault.TabIndex =
                4;

            btnLockVault.Text =
                "قفل الخزنة";

            btnLockVault.UseVisualStyleBackColor =
                true;

            btnLockVault.Click +=
                btnLockVault_Click;
            // 
            // btnAccounts
            // 
            btnAccounts.Location =
                new Point(270, 360);

            btnAccounts.Name =
                "btnAccounts";

            btnAccounts.Size =
                new Size(260, 45);

            btnAccounts.TabIndex =
                5;

            btnAccounts.Text =
                "إدارة الحسابات";

            btnAccounts.UseVisualStyleBackColor =
                true;

            btnAccounts.Click +=
                btnAccounts_Click;
            // 
            // btnPasswordGenerator
            // 
            btnPasswordGenerator.Location =
                new Point(270, 420);

            btnPasswordGenerator.Name =
                "btnPasswordGenerator";

            btnPasswordGenerator.Size =
                new Size(260, 45);

            btnPasswordGenerator.TabIndex =
                6;

            btnPasswordGenerator.Text =
                "مولد كلمات المرور";

            btnPasswordGenerator.UseVisualStyleBackColor =
                true;

            btnPasswordGenerator.Click +=
                btnPasswordGenerator_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions =
                new SizeF(10F, 25F);

            AutoScaleMode =
                AutoScaleMode.Font;

            ClientSize =
     new Size(800, 560);

            Controls.Add(btnPasswordGenerator);
            Controls.Add(btnAccounts);
            Controls.Add(btnLockVault);
            Controls.Add(btnUnlockVault);
            Controls.Add(btnCreateVault);
            Controls.Add(lblVaultStatus);
            Controls.Add(lblTitle);

            Name =
                "Form1";

            StartPosition =
                FormStartPosition.CenterScreen;

            Text =
                "Secure Password Manager";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label lblVaultStatus;
        private Button btnCreateVault;
        private Button btnUnlockVault;
        private Button btnLockVault;
        private Button btnAccounts;
        private Button btnPasswordGenerator;
    }
}