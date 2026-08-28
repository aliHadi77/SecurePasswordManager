namespace SecurePasswordManager.Forms
{
    partial class CreateVaultForm
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
            lblConfirmPassword = new Label();

            txtMasterPassword = new TextBox();
            txtConfirmPassword = new TextBox();

            btnShowMasterPassword = new Button();
            btnShowConfirmPassword = new Button();

            btnCreateVault = new Button();
            btnCancel = new Button();

            pnlSecurityInfo = new Panel();
            lblSecurityInfo = new Label();

            SuspendLayout();

            // 
            // CreateVaultForm
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
                    570);

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
                "CreateVaultForm";

            Text =
                "إنشاء خزنة جديدة";

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
                "إنشاء خزنة جديدة";

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
                "أنشئ كلمة مرور رئيسية قوية لحماية بياناتك داخل الخزنة.";

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
            // btnShowMasterPassword
            // 
            btnShowMasterPassword.FlatAppearance.BorderSize =
                0;

            btnShowMasterPassword.FlatStyle =
                FlatStyle.Flat;

            btnShowMasterPassword.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnShowMasterPassword.ForeColor =
                Color.FromArgb(
                    37,
                    99,
                    235);

            btnShowMasterPassword.Location =
                new Point(
                    590,
                    195);

            btnShowMasterPassword.Name =
                "btnShowMasterPassword";

            btnShowMasterPassword.Size =
                new Size(
                    65,
                    38);

            btnShowMasterPassword.TabIndex =
                4;

            btnShowMasterPassword.Text =
                "إظهار";

            btnShowMasterPassword.UseVisualStyleBackColor =
                false;

            btnShowMasterPassword.Click +=
                btnShowMasterPassword_Click;

            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = false;

            lblConfirmPassword.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            lblConfirmPassword.ForeColor =
                Color.FromArgb(
                    226,
                    232,
                    240);

            lblConfirmPassword.Location =
                new Point(
                    105,
                    255);

            lblConfirmPassword.Name =
                "lblConfirmPassword";

            lblConfirmPassword.Size =
                new Size(
                    550,
                    30);

            lblConfirmPassword.TabIndex =
                5;

            lblConfirmPassword.Text =
                "تأكيد كلمة المرور الرئيسية";

            lblConfirmPassword.TextAlign =
                ContentAlignment.MiddleRight;

            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BackColor =
                Color.FromArgb(
                    248,
                    250,
                    252);

            txtConfirmPassword.BorderStyle =
                BorderStyle.FixedSingle;

            txtConfirmPassword.Font =
                new Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    0);

            txtConfirmPassword.ForeColor =
                Color.FromArgb(
                    15,
                    23,
                    42);

            txtConfirmPassword.Location =
                new Point(
                    105,
                    290);

            txtConfirmPassword.Name =
                "txtConfirmPassword";

            txtConfirmPassword.Size =
                new Size(
                    480,
                    38);

            txtConfirmPassword.TabIndex =
                6;

            txtConfirmPassword.UseSystemPasswordChar =
                true;

            // 
            // btnShowConfirmPassword
            // 
            btnShowConfirmPassword.FlatAppearance.BorderSize =
                0;

            btnShowConfirmPassword.FlatStyle =
                FlatStyle.Flat;

            btnShowConfirmPassword.Font =
                new Font(
                    "Segoe UI",
                    9F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnShowConfirmPassword.ForeColor =
                Color.FromArgb(
                    37,
                    99,
                    235);

            btnShowConfirmPassword.Location =
                new Point(
                    590,
                    290);

            btnShowConfirmPassword.Name =
                "btnShowConfirmPassword";

            btnShowConfirmPassword.Size =
                new Size(
                    65,
                    38);

            btnShowConfirmPassword.TabIndex =
                7;

            btnShowConfirmPassword.Text =
                "إظهار";

            btnShowConfirmPassword.UseVisualStyleBackColor =
                false;

            btnShowConfirmPassword.Click +=
                btnShowConfirmPassword_Click;

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
                    350);

            pnlSecurityInfo.Name =
                "pnlSecurityInfo";

            pnlSecurityInfo.Size =
                new Size(
                    550,
                    65);

            pnlSecurityInfo.TabIndex =
                8;

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
                "متطلبات كلمة المرور: من 14 إلى 128 حرفًا،" +
                " مع تجنب المسافات في البداية والنهاية.";

            lblSecurityInfo.TextAlign =
                ContentAlignment.MiddleCenter;

            pnlSecurityInfo.Controls.Add(
                lblSecurityInfo);

            // 
            // btnCreateVault
            // 
            btnCreateVault.BackColor =
                Color.FromArgb(
                    37,
                    99,
                    235);

            btnCreateVault.FlatAppearance.BorderColor =
                Color.FromArgb(
                    59,
                    130,
                    246);

            btnCreateVault.FlatAppearance.BorderSize =
                1;

            btnCreateVault.FlatStyle =
                FlatStyle.Flat;

            btnCreateVault.Font =
                new Font(
                    "Segoe UI",
                    10.5F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            btnCreateVault.ForeColor =
                Color.White;

            btnCreateVault.Location =
                new Point(
                    390,
                    455);

            btnCreateVault.Name =
                "btnCreateVault";

            btnCreateVault.Size =
                new Size(
                    265,
                    52);

            btnCreateVault.TabIndex =
                9;

            btnCreateVault.Text =
                "إنشاء الخزنة";

            btnCreateVault.UseVisualStyleBackColor =
                false;

            btnCreateVault.Click +=
                btnCreateVault_Click;

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
                    455);

            btnCancel.Name =
                "btnCancel";

            btnCancel.Size =
                new Size(
                    265,
                    52);

            btnCancel.TabIndex =
                10;

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
                btnCreateVault);

            Controls.Add(
                pnlSecurityInfo);

            Controls.Add(
                btnShowConfirmPassword);

            Controls.Add(
                txtConfirmPassword);

            Controls.Add(
                lblConfirmPassword);

            Controls.Add(
                btnShowMasterPassword);

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
        private Label lblConfirmPassword;

        private TextBox txtMasterPassword;
        private TextBox txtConfirmPassword;

        private Button btnShowMasterPassword;
        private Button btnShowConfirmPassword;

        private Button btnCreateVault;
        private Button btnCancel;

        private Panel pnlSecurityInfo;
        private Label lblSecurityInfo;
    }
}