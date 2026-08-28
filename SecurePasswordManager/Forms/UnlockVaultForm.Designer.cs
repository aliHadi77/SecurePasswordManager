namespace SecurePasswordManager.Forms
{
    partial class UnlockVaultForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblDescription = new Label();

            lblMasterPassword = new Label();
            txtMasterPassword = new TextBox();

            btnShowPassword = new Button();

            btnUnlock = new Button();
            btnCancel = new Button();

            pnlSecurityInfo = new Panel();
            lblSecurityInfo = new Label();

            SuspendLayout();

            // 
            // UnlockVaultForm
            // 
            AutoScaleDimensions =
                new SizeF(10F, 25F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(
                    18,
                    24,
                    38);

            ClientSize =
                new Size(
                    760,
                    500);

            Font =
                new Font(
                    "Segoe UI",
                    10F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    0);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox =
                false;

            MinimizeBox =
                false;

            StartPosition =
                FormStartPosition.CenterParent;

            Name =
                "UnlockVaultForm";

            Text =
                "فتح الخزنة";

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = false;

            lblTitle.Font =
                new Font(
                    "Segoe UI",
                    22F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            lblTitle.ForeColor =
                Color.White;

            lblTitle.Location =
                new Point(
                    80,
                    35);

            lblTitle.Name =
                "lblTitle";

            lblTitle.Size =
                new Size(
                    600,
                    50);

            lblTitle.TabIndex =
                0;

            lblTitle.Text =
                "فتح الخزنة";

            lblTitle.TextAlign =
                ContentAlignment.MiddleCenter;

            // 
            // lblDescription
            // 
            lblDescription.AutoSize = false;

            lblDescription.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    0);

            lblDescription.ForeColor =
                Color.FromArgb(
                    148,
                    163,
                    184);

            lblDescription.Location =
                new Point(
                    80,
                    90);

            lblDescription.Name =
                "lblDescription";

            lblDescription.Size =
                new Size(
                    600,
                    45);

            lblDescription.TabIndex =
                1;

            lblDescription.Text =
                "أدخل كلمة المرور الرئيسية للوصول إلى بيانات الخزنة.";

            lblDescription.TextAlign =
                ContentAlignment.MiddleCenter;

            // 
            // lblMasterPassword
            // 
            lblMasterPassword.AutoSize = false;

            lblMasterPassword.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            lblMasterPassword.ForeColor =
                Color.FromArgb(
                    226,
                    232,
                    240);

            lblMasterPassword.Location =
                new Point(
                    105,
                    160);

            lblMasterPassword.Name =
                "lblMasterPassword";

            lblMasterPassword.Size =
                new Size(
                    550,
                    30);

            lblMasterPassword.TabIndex =
                2;

            lblMasterPassword.Text =
                "كلمة المرور الرئيسية";

            lblMasterPassword.TextAlign =
                ContentAlignment.MiddleRight;

            // 
            // txtMasterPassword
            // 
            txtMasterPassword.BackColor =
                Color.FromArgb(
                    248,
                    250,
                    252);

            txtMasterPassword.BorderStyle =
                BorderStyle.FixedSingle;

            txtMasterPassword.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    0);

            txtMasterPassword.ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42);

            txtMasterPassword.Location =
                new Point(
                    105,
                    195);

            txtMasterPassword.Name =
                "txtMasterPassword";

            txtMasterPassword.Size =
                new Size(
                    480,
                    38);

            txtMasterPassword.TabIndex =
                3;

            txtMasterPassword.UseSystemPasswordChar =
                true;

            // 
            // btnShowPassword
            // 
            btnShowPassword.FlatAppearance.BorderSize =
                0;

            btnShowPassword.FlatStyle =
                FlatStyle.Flat;

            btnShowPassword.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnShowPassword.ForeColor =
                Color.FromArgb(
                    37,
                    99,
                    235);

            btnShowPassword.Location =
                new Point(
                    590,
                    195);

            btnShowPassword.Name =
                "btnShowPassword";

            btnShowPassword.Size =
                new Size(
                    65,
                    38);

            btnShowPassword.TabIndex =
                4;

            btnShowPassword.Text =
                "إظهار";

            btnShowPassword.UseVisualStyleBackColor =
                false;

            btnShowPassword.Click +=
                btnShowPassword_Click;

            // 
            // pnlSecurityInfo
            // 
            pnlSecurityInfo.BackColor =
                Color.FromArgb(
                    30,
                    41,
                    59);

            pnlSecurityInfo.Location =
                new Point(
                    105,
                    255);

            pnlSecurityInfo.Name =
                "pnlSecurityInfo";

            pnlSecurityInfo.Size =
                new Size(
                    550,
                    65);

            pnlSecurityInfo.TabIndex =
                5;

            // 
            // lblSecurityInfo
            // 
            lblSecurityInfo.AutoSize = false;

            lblSecurityInfo.Font =
                new Font(
                    "Segoe UI",
                    9.5F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    0);

            lblSecurityInfo.ForeColor =
                Color.FromArgb(
                    203,
                    213,
                    225);

            lblSecurityInfo.Location =
                new Point(
                    15,
                    8);

            lblSecurityInfo.Name =
                "lblSecurityInfo";

            lblSecurityInfo.Size =
                new Size(
                    520,
                    50);

            lblSecurityInfo.TabIndex =
                0;

            lblSecurityInfo.Text =
                "كلمة المرور الرئيسية لا يتم عرضها أو تخزينها داخل هذه الشاشة.";

            lblSecurityInfo.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlSecurityInfo.Controls.Add(
                lblSecurityInfo);

            // 
            // btnUnlock
            // 
            btnUnlock.BackColor =
                Color.FromArgb(
                    37,
                    99,
                    235);

            btnUnlock.FlatAppearance.BorderColor =
                Color.FromArgb(
                    59,
                    130,
                    246);

            btnUnlock.FlatAppearance.BorderSize =
                1;

            btnUnlock.FlatStyle =
                FlatStyle.Flat;

            btnUnlock.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnUnlock.ForeColor =
                Color.White;

            btnUnlock.Location =
                new Point(
                    390,
                    355);

            btnUnlock.Name =
                "btnUnlock";

            btnUnlock.Size =
                new Size(
                    265,
                    52);

            btnUnlock.TabIndex =
                6;

            btnUnlock.Text =
                "فتح الخزنة";

            btnUnlock.UseVisualStyleBackColor =
                false;

            btnUnlock.Click +=
                btnUnlock_Click;

            // 
            // btnCancel
            // 
            btnCancel.BackColor =
                Color.FromArgb(
                    235,
                    238,
                    242);

            btnCancel.FlatAppearance.BorderColor =
                Color.FromArgb(
                    200,
                    207,
                    216);

            btnCancel.FlatAppearance.BorderSize =
                1;

            btnCancel.FlatStyle =
                FlatStyle.Flat;

            btnCancel.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnCancel.ForeColor =
                Color.FromArgb(
                    30,
                    41,
                    59);

            btnCancel.Location =
                new Point(
                    105,
                    355);

            btnCancel.Name =
                "btnCancel";

            btnCancel.Size =
                new Size(
                    265,
                    52);

            btnCancel.TabIndex =
                7;

            btnCancel.Text =
                "إلغاء";

            btnCancel.UseVisualStyleBackColor =
                false;

            btnCancel.Click +=
                btnCancel_Click;

            // 
            // Add controls
            // 
            Controls.Add(
                btnCancel);

            Controls.Add(
                btnUnlock);

            Controls.Add(
                pnlSecurityInfo);

            Controls.Add(
                btnShowPassword);

            Controls.Add(
                txtMasterPassword);

            Controls.Add(
                lblMasterPassword);

            Controls.Add(
                lblDescription);

            Controls.Add(
                lblTitle);

            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Label lblDescription;

        private Label lblMasterPassword;
        private TextBox txtMasterPassword;

        private Button btnShowPassword;

        private Button btnUnlock;
        private Button btnCancel;

        private Panel pnlSecurityInfo;
        private Label lblSecurityInfo;
    }
}