namespace SecurePasswordManager
{
    partial class PasswordGeneratorForm
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

        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            numLength = new NumericUpDown();
            Uppercase = new CheckBox();
            Lowercase = new CheckBox();
            Digits = new CheckBox();
            Symbols = new CheckBox();

            txtGeneratedPassword = new TextBox();

            lblStrength = new Label();
            lblSuggestionsTitle = new Label();
            lblSuggestions = new Label();

            btnCopy = new Button();
            btnRegenerate = new Button();
            btnGenerate = new Button();

            lblManualPassword = new Label();
            txtPasswordToEvaluate = new TextBox();
            btnEvaluate = new Button();
            btnTogglePassword = new Button();

            ((System.ComponentModel.ISupportInitialize)numLength).BeginInit();
            SuspendLayout();

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font =
                new Font(
                    "Arial",
                    16F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    178);

            label1.Location =
                new Point(331, 18);

            label1.Name =
                "label1";

            label1.Size =
                new Size(281, 37);

            label1.TabIndex =
                0;

            label1.Text =
                "مولد كلمات المرور الآمنة";

            label1.ForeColor =
                Color.FromArgb(25, 35, 55);

            // 
            // label2
            // 
            label2.AutoSize = true;

            label2.Location =
                new Point(12, 58);

            label2.Name =
                "label2";

            label2.Size =
                new Size(138, 25);

            label2.TabIndex =
                1;

            label2.Text =
                "طول كلمة المرور";

            label2.ForeColor =
                Color.FromArgb(25, 35, 55);

            // 
            // numLength
            // 
            numLength.Location =
                new Point(156, 58);

            numLength.Maximum =
                new decimal(
                    new int[]
                    {
                        128,
                        0,
                        0,
                        0
                    });

            numLength.Minimum =
                new decimal(
                    new int[]
                    {
                        8,
                        0,
                        0,
                        0
                    });

            numLength.Name =
                "numLength";

            numLength.Size =
                new Size(68, 31);

            numLength.TabIndex =
                2;

            numLength.Value =
                new decimal(
                    new int[]
                    {
                        16,
                        0,
                        0,
                        0
                    });

            // 
            // Uppercase
            // 
            Uppercase.AutoSize = true;
            Uppercase.Checked = true;
            Uppercase.CheckState = CheckState.Checked;

            Uppercase.Location =
                new Point(12, 105);

            Uppercase.Name =
                "Uppercase";

            Uppercase.Size =
                new Size(163, 29);

            Uppercase.TabIndex =
                3;

            Uppercase.Text =
                "أحرف كبيرة (A-Z)";

            Uppercase.ForeColor =
                Color.FromArgb(25, 35, 55);

            Uppercase.UseVisualStyleBackColor =
                true;

            Uppercase.CheckedChanged +=
                checkBox1_CheckedChanged;

            // 
            // Lowercase
            // 
            Lowercase.AutoSize = true;
            Lowercase.Checked = true;
            Lowercase.CheckState = CheckState.Checked;

            Lowercase.Location =
                new Point(12, 152);

            Lowercase.Name =
                "Lowercase";

            Lowercase.Size =
                new Size(172, 29);

            Lowercase.TabIndex =
                4;

            Lowercase.Text =
                "أحرف صغيرة (a-z)";

            Lowercase.ForeColor =
                Color.FromArgb(25, 35, 55);

            Lowercase.UseVisualStyleBackColor =
                true;

            // 
            // Digits
            // 
            Digits.AutoSize = true;
            Digits.Checked = true;
            Digits.CheckState = CheckState.Checked;

            Digits.Location =
                new Point(12, 197);

            Digits.Name =
                "Digits";

            Digits.Size =
                new Size(116, 29);

            Digits.TabIndex =
                5;

            Digits.Text =
                "أرقام (0-9)";

            Digits.ForeColor =
                Color.FromArgb(25, 35, 55);

            Digits.UseVisualStyleBackColor =
                true;

            // 
            // Symbols
            // 
            Symbols.AutoSize = true;
            Symbols.Checked = true;
            Symbols.CheckState = CheckState.Checked;

            Symbols.Location =
                new Point(12, 232);

            Symbols.Name =
                "Symbols";

            Symbols.Size =
                new Size(130, 29);

            Symbols.TabIndex =
                6;

            Symbols.Text =
                "رموز (!@#$)";

            Symbols.ForeColor =
                Color.FromArgb(25, 35, 55);

            Symbols.UseVisualStyleBackColor =
                true;

            // 
            // txtGeneratedPassword
            // 
            txtGeneratedPassword.Location =
                new Point(266, 131);

            txtGeneratedPassword.Name =
                "txtGeneratedPassword";

            txtGeneratedPassword.ReadOnly =
                true;

            txtGeneratedPassword.Size =
                new Size(442, 31);

            txtGeneratedPassword.TabIndex =
                7;

            // 
            // lblStrength
            // 
            lblStrength.AutoSize = true;

            lblStrength.Location =
                new Point(266, 183);

            lblStrength.Name =
                "lblStrength";

            lblStrength.Size =
                new Size(300, 25);

            lblStrength.TabIndex =
                8;

            lblStrength.Text =
                "القوة";

            lblStrength.ForeColor =
                Color.FromArgb(25, 35, 55);

            // 
            // lblSuggestionsTitle
            // 
            lblSuggestionsTitle.AutoSize = true;

            lblSuggestionsTitle.Location =
                new Point(266, 218);

            lblSuggestionsTitle.Name =
                "lblSuggestionsTitle";

            lblSuggestionsTitle.Size =
                new Size(75, 25);

            lblSuggestionsTitle.TabIndex =
                9;

            lblSuggestionsTitle.Text =
                "الملاحظات:";

            lblSuggestionsTitle.Font =
                new Font(
                    "Arial",
                    10F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    178);

            lblSuggestionsTitle.ForeColor =
                Color.FromArgb(25, 35, 55);

            // 
            // lblSuggestions
            // 
            lblSuggestions.AutoSize = false;

            lblSuggestions.Location =
                new Point(266, 248);

            lblSuggestions.Name =
                "lblSuggestions";

            lblSuggestions.Size =
                new Size(442, 75);

            lblSuggestions.TabIndex =
                10;

            lblSuggestions.Text =
                "الملاحظات";

            lblSuggestions.TextAlign =
                ContentAlignment.TopLeft;

            lblSuggestions.ForeColor =
                Color.FromArgb(25, 35, 55);

            // 
            // btnCopy
            // 
            btnCopy.Location =
                new Point(295, 77);

            btnCopy.Name =
                "btnCopy";

            btnCopy.Size =
                new Size(112, 34);

            btnCopy.TabIndex =
                11;

            btnCopy.Text =
                "نسخ";

            btnCopy.UseVisualStyleBackColor =
                false;

            btnCopy.BackColor =
                Color.FromArgb(55, 85, 125);

            btnCopy.ForeColor =
                Color.White;

            btnCopy.FlatStyle =
                FlatStyle.Flat;

            btnCopy.FlatAppearance.BorderColor =
                Color.FromArgb(45, 70, 105);

            btnCopy.FlatAppearance.BorderSize =
                1;

            btnCopy.Click +=
                btnCopy_Click;

            // 
            // btnRegenerate
            // 
            btnRegenerate.Location =
                new Point(430, 77);

            btnRegenerate.Name =
                "btnRegenerate";

            btnRegenerate.Size =
                new Size(112, 34);

            btnRegenerate.TabIndex =
                12;

            btnRegenerate.Text =
                "إعادة توليد";

            btnRegenerate.UseVisualStyleBackColor =
                false;

            btnRegenerate.BackColor =
                Color.FromArgb(60, 95, 140);

            btnRegenerate.ForeColor =
                Color.White;

            btnRegenerate.FlatStyle =
                FlatStyle.Flat;

            btnRegenerate.FlatAppearance.BorderColor =
                Color.FromArgb(50, 78, 115);

            btnRegenerate.FlatAppearance.BorderSize =
                1;

            btnRegenerate.Click +=
                btnRegenerate_Click;

            // 
            // btnGenerate
            // 
            btnGenerate.Location =
                new Point(574, 77);

            btnGenerate.Name =
                "btnGenerate";

            btnGenerate.Size =
                new Size(112, 34);

            btnGenerate.TabIndex =
                13;

            btnGenerate.Text =
                "توليد";

            btnGenerate.UseVisualStyleBackColor =
                false;

            btnGenerate.BackColor =
                Color.FromArgb(45, 80, 125);

            btnGenerate.ForeColor =
                Color.White;

            btnGenerate.FlatStyle =
                FlatStyle.Flat;

            btnGenerate.FlatAppearance.BorderColor =
                Color.FromArgb(35, 65, 105);

            btnGenerate.FlatAppearance.BorderSize =
                1;

            btnGenerate.Click +=
                btnGenerate_Click;

            // 
            // lblManualPassword
            // 
            lblManualPassword.AutoSize = true;

            lblManualPassword.Location =
                new Point(373, 340);

            lblManualPassword.Name =
                "lblManualPassword";

            lblManualPassword.Size =
                new Size(169, 25);

            lblManualPassword.TabIndex =
                14;

            lblManualPassword.Text =
                "اختبر كلمة مرور يدويًا";

            lblManualPassword.Font =
                new Font(
                    "Arial",
                    10F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    178);

            lblManualPassword.ForeColor =
                Color.FromArgb(25, 35, 55);

            // 
            // txtPasswordToEvaluate
            // 
            txtPasswordToEvaluate.Location =
                new Point(321, 380);

            txtPasswordToEvaluate.Name =
                "txtPasswordToEvaluate";

            txtPasswordToEvaluate.Size =
                new Size(320, 31);

            txtPasswordToEvaluate.TabIndex =
                15;

            txtPasswordToEvaluate.UseSystemPasswordChar =
                true;

            txtPasswordToEvaluate.TextChanged +=
                textBox1_TextChanged;

            // 
            // btnEvaluate
            // 
            btnEvaluate.Location =
                new Point(417, 420);

            btnEvaluate.Name =
                "btnEvaluate";

            btnEvaluate.Size =
                new Size(112, 34);

            btnEvaluate.TabIndex =
                16;

            btnEvaluate.Text =
                "تقييم كلمة المرور";

            btnEvaluate.UseVisualStyleBackColor =
                false;

            btnEvaluate.BackColor =
    Color.FromArgb(55, 125, 85);

            btnEvaluate.ForeColor =
                Color.White;

            btnEvaluate.FlatStyle =
                FlatStyle.Flat;

            btnEvaluate.FlatAppearance.BorderColor =
                Color.FromArgb(45, 105, 70);

            btnEvaluate.FlatAppearance.BorderSize =
                1;

            btnEvaluate.ForeColor =
                Color.White;

            btnEvaluate.FlatStyle =
                FlatStyle.Flat;

            btnEvaluate.FlatAppearance.BorderColor =
                Color.FromArgb(55, 82, 120);

            btnEvaluate.FlatAppearance.BorderSize =
                1;

            btnEvaluate.Click +=
                btnEvaluate_Click;

            // 
            // btnTogglePassword
            // 
            btnTogglePassword.Location =
                new Point(647, 378);

            btnTogglePassword.Name =
                "btnTogglePassword";

            btnTogglePassword.Size =
                new Size(112, 34);

            btnTogglePassword.TabIndex =
                17;

            btnTogglePassword.Text =
                "إظهار";

            btnTogglePassword.UseVisualStyleBackColor =
                true;

            btnTogglePassword.Click +=
                btnTogglePassword_Click;

            // 
            // PasswordGeneratorForm
            // 
            AutoScaleDimensions =
                new SizeF(10F, 25F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(248, 249, 251);

            ClientSize =
                new Size(800, 480);

            Controls.Add(btnTogglePassword);
            Controls.Add(btnEvaluate);
            Controls.Add(txtPasswordToEvaluate);
            Controls.Add(lblManualPassword);

            Controls.Add(btnGenerate);
            Controls.Add(btnRegenerate);
            Controls.Add(btnCopy);

            Controls.Add(lblSuggestions);
            Controls.Add(lblSuggestionsTitle);
            Controls.Add(lblStrength);

            Controls.Add(txtGeneratedPassword);

            Controls.Add(Symbols);
            Controls.Add(Digits);
            Controls.Add(Lowercase);
            Controls.Add(Uppercase);
            Controls.Add(numLength);
            Controls.Add(label2);
            Controls.Add(label1);

            Font =
                new Font(
                    "Arial",
                    10F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    178);

            FormBorderStyle =
                FormBorderStyle.FixedSingle;

            MaximizeBox =
                false;

            MinimizeBox =
                false;

            Name =
                "PasswordGeneratorForm";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "مولد كلمات المرور الآمنة";

            Load +=
                chkUppercase_Load;

            ((System.ComponentModel.ISupportInitialize)numLength).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private NumericUpDown numLength;
        private CheckBox Uppercase;
        private CheckBox Lowercase;
        private CheckBox Digits;
        private CheckBox Symbols;

        private TextBox txtGeneratedPassword;

        private Label lblStrength;
        private Label lblSuggestionsTitle;
        private Label lblSuggestions;

        private Button btnCopy;
        private Button btnRegenerate;
        private Button btnGenerate;

        private Label lblManualPassword;
        private TextBox txtPasswordToEvaluate;
        private Button btnEvaluate;
        private Button btnTogglePassword;
    }
}