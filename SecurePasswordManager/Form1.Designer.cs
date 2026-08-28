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
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();

            pnlStatus = new System.Windows.Forms.Panel();
            lblVaultStatus = new System.Windows.Forms.Label();
            lblStatusDescription = new System.Windows.Forms.Label();

            lblFunctionsTitle = new System.Windows.Forms.Label();
            pnlSeparator = new System.Windows.Forms.Panel();

            btnCreateVault = new System.Windows.Forms.Button();
            btnUnlockVault = new System.Windows.Forms.Button();
            btnLockVault = new System.Windows.Forms.Button();
            btnAccounts = new System.Windows.Forms.Button();
            btnPasswordGenerator = new System.Windows.Forms.Button();

            pnlStatus.SuspendLayout();
            SuspendLayout();

            // 
            // Form1
            // 
            AutoScaleDimensions =
                new System.Drawing.SizeF(
                    10F,
                    25F);

            AutoScaleMode =
                System.Windows.Forms.AutoScaleMode.Font;

            BackColor =
                System.Drawing.Color.FromArgb(
                    18,
                    24,
                    38);

            ClientSize =
                new System.Drawing.Size(
                    1000,
                    650);

            Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedSingle;

            MaximizeBox =
                false;

            MinimizeBox =
                true;

            Name =
                "Form1";

            StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;

            Text =
                "Secure Password Manager";

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;

            lblTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    24F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            lblTitle.ForeColor =
                System.Drawing.Color.White;

            lblTitle.Location =
                new System.Drawing.Point(
                    150,
                    30);

            lblTitle.Name =
                "lblTitle";

            lblTitle.Size =
                new System.Drawing.Size(
                    700,
                    55);

            lblTitle.TabIndex =
                0;

            lblTitle.Text =
                "مدير كلمات المرور الآمن";

            lblTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = false;

            lblSubtitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10.5F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            lblSubtitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    148,
                    163,
                    184);

            lblSubtitle.Location =
                new System.Drawing.Point(
                    150,
                    88);

            lblSubtitle.Name =
                "lblSubtitle";

            lblSubtitle.Size =
                new System.Drawing.Size(
                    700,
                    30);

            lblSubtitle.TabIndex =
                1;

            lblSubtitle.Text =
                "إدارة كلمات المرور وحماية حساباتك بأمان";

            lblSubtitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlStatus
            // 
            pnlStatus.BackColor =
                System.Drawing.Color.FromArgb(
                    67,
                    52,
                    28);

            pnlStatus.Location =
                new System.Drawing.Point(
                    150,
                    140);

            pnlStatus.Name =
                "pnlStatus";

            pnlStatus.Size =
                new System.Drawing.Size(
                    700,
                    125);

            pnlStatus.TabIndex =
                2;

            // 
            // lblVaultStatus
            // 
            lblVaultStatus.AutoSize = false;

            lblVaultStatus.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    17F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            lblVaultStatus.ForeColor =
                System.Drawing.Color.FromArgb(
                    253,
                    230,
                    138);

            lblVaultStatus.Location =
                new System.Drawing.Point(
                    25,
                    18);

            lblVaultStatus.Name =
                "lblVaultStatus";

            lblVaultStatus.Size =
                new System.Drawing.Size(
                    650,
                    40);

            lblVaultStatus.TabIndex =
                0;

            lblVaultStatus.Text =
                "حالة الخزنة: مقفلة";

            lblVaultStatus.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // lblStatusDescription
            // 
            lblStatusDescription.AutoSize = false;

            lblStatusDescription.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10F,
                    System.Drawing.FontStyle.Regular,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            lblStatusDescription.ForeColor =
                System.Drawing.Color.FromArgb(
                    254,
                    240,
                    180);

            lblStatusDescription.Location =
                new System.Drawing.Point(
                    25,
                    68);

            lblStatusDescription.Name =
                "lblStatusDescription";

            lblStatusDescription.Size =
                new System.Drawing.Size(
                    650,
                    30);

            lblStatusDescription.TabIndex =
                1;

            lblStatusDescription.Text =
                "البيانات محمية والخزنة مغلقة حاليًا";

            lblStatusDescription.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            pnlStatus.Controls.Add(
                lblStatusDescription);

            pnlStatus.Controls.Add(
                lblVaultStatus);

            // 
            // lblFunctionsTitle
            // 
            lblFunctionsTitle.AutoSize = false;

            lblFunctionsTitle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    12F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            lblFunctionsTitle.ForeColor =
                System.Drawing.Color.FromArgb(
                    226,
                    232,
                    240);

            lblFunctionsTitle.Location =
                new System.Drawing.Point(
                    150,
                    290);

            lblFunctionsTitle.Name =
                "lblFunctionsTitle";

            lblFunctionsTitle.Size =
                new System.Drawing.Size(
                    700,
                    32);

            lblFunctionsTitle.TabIndex =
                3;

            lblFunctionsTitle.Text =
                "وظائف التطبيق";

            lblFunctionsTitle.TextAlign =
                System.Drawing.ContentAlignment.MiddleCenter;

            // 
            // pnlSeparator
            // 
            pnlSeparator.BackColor =
                System.Drawing.Color.FromArgb(
                    51,
                    65,
                    85);

            pnlSeparator.Location =
                new System.Drawing.Point(
                    250,
                    330);

            pnlSeparator.Name =
                "pnlSeparator";

            pnlSeparator.Size =
                new System.Drawing.Size(
                    500,
                    1);

            pnlSeparator.TabIndex =
                4;

            // 
            // btnUnlockVault
            // 
            btnUnlockVault.FlatAppearance.BorderSize = 1;

            btnUnlockVault.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnUnlockVault.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            btnUnlockVault.Location =
                new System.Drawing.Point(
                    150,
                    355);

            btnUnlockVault.Name =
                "btnUnlockVault";

            btnUnlockVault.Size =
                new System.Drawing.Size(
                    335,
                    58);

            btnUnlockVault.TabIndex =
                5;

            btnUnlockVault.Text =
                "فتح الخزنة";

            btnUnlockVault.UseVisualStyleBackColor =
                false;

            btnUnlockVault.Click +=
                btnUnlockVault_Click;

            // 
            // btnLockVault
            // 
            btnLockVault.FlatAppearance.BorderSize = 1;

            btnLockVault.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnLockVault.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            btnLockVault.Location =
                new System.Drawing.Point(
                    515,
                    355);

            btnLockVault.Name =
                "btnLockVault";

            btnLockVault.Size =
                new System.Drawing.Size(
                    335,
                    58);

            btnLockVault.TabIndex =
                6;

            btnLockVault.Text =
                "قفل الخزنة";

            btnLockVault.UseVisualStyleBackColor =
                false;

            btnLockVault.Click +=
                btnLockVault_Click;

            // 
            // btnAccounts
            // 
            btnAccounts.FlatAppearance.BorderSize = 1;

            btnAccounts.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnAccounts.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            btnAccounts.Location =
                new System.Drawing.Point(
                    150,
                    430);

            btnAccounts.Name =
                "btnAccounts";

            btnAccounts.Size =
                new System.Drawing.Size(
                    335,
                    58);

            btnAccounts.TabIndex =
                7;

            btnAccounts.Text =
                "إدارة الحسابات";

            btnAccounts.UseVisualStyleBackColor =
                false;

            btnAccounts.Click +=
                btnAccounts_Click;

            // 
            // btnPasswordGenerator
            // 
            btnPasswordGenerator.FlatAppearance.BorderSize = 1;

            btnPasswordGenerator.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnPasswordGenerator.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            btnPasswordGenerator.Location =
                new System.Drawing.Point(
                    515,
                    430);

            btnPasswordGenerator.Name =
                "btnPasswordGenerator";

            btnPasswordGenerator.Size =
                new System.Drawing.Size(
                    335,
                    58);

            btnPasswordGenerator.TabIndex =
                8;

            btnPasswordGenerator.Text =
                "مولد كلمات المرور";

            btnPasswordGenerator.UseVisualStyleBackColor =
                false;

            btnPasswordGenerator.Click +=
                btnPasswordGenerator_Click;

            // 
            // btnCreateVault
            // 
            btnCreateVault.FlatAppearance.BorderSize = 1;

            btnCreateVault.FlatStyle =
                System.Windows.Forms.FlatStyle.Flat;

            btnCreateVault.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    10.5F,
                    System.Drawing.FontStyle.Bold,
                    System.Drawing.GraphicsUnit.Point,
                    0);

            btnCreateVault.Location =
                new System.Drawing.Point(
                    300,
                    525);

            btnCreateVault.Name =
                "btnCreateVault";

            btnCreateVault.Size =
                new System.Drawing.Size(
                    400,
                    52);

            btnCreateVault.TabIndex =
                9;

            btnCreateVault.Text =
                "إنشاء خزنة جديدة";

            btnCreateVault.UseVisualStyleBackColor =
                false;

            btnCreateVault.Click +=
                btnCreateVault_Click;

            // 
            // Add controls
            // 
            Controls.Add(
                btnCreateVault);

            Controls.Add(
                btnPasswordGenerator);

            Controls.Add(
                btnAccounts);

            Controls.Add(
                btnLockVault);

            Controls.Add(
                btnUnlockVault);

            Controls.Add(
                pnlSeparator);

            Controls.Add(
                lblFunctionsTitle);

            Controls.Add(
                pnlStatus);

            Controls.Add(
                lblSubtitle);

            Controls.Add(
                lblTitle);

            pnlStatus.ResumeLayout(false);

            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;

        private System.Windows.Forms.Panel pnlStatus;
        private System.Windows.Forms.Label lblVaultStatus;
        private System.Windows.Forms.Label lblStatusDescription;

        private System.Windows.Forms.Label lblFunctionsTitle;
        private System.Windows.Forms.Panel pnlSeparator;

        private System.Windows.Forms.Button btnCreateVault;
        private System.Windows.Forms.Button btnUnlockVault;
        private System.Windows.Forms.Button btnLockVault;
        private System.Windows.Forms.Button btnAccounts;
        private System.Windows.Forms.Button btnPasswordGenerator;
    }
}