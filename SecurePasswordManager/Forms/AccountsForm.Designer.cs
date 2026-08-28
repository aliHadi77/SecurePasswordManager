namespace SecurePasswordManager.Forms
{
    partial class AccountsForm
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
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnClearSearch = new Button();
            dgvAccounts = new DataGridView();
            lblService = new Label();
            txtService = new TextBox();
            blUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnTogglePassword = new Button();
            lblWebsite = new Label();
            txtWebsite = new TextBox();
            lblNotes = new Label();
            txtNotes = new TextBox();
            btnGeneratePassword = new Button();
            btnEvaluatePassword = new Button();
            btnCopyPassword = new Button();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnClear = new Button();
            btnDelete = new Button();

            ((System.ComponentModel.ISupportInitialize)dgvAccounts).BeginInit();
            SuspendLayout();

            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font(
                "Arial",
                10F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            lblSearch.ForeColor = Color.FromArgb(30, 45, 65);
            lblSearch.Location = new Point(365, 33);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(46, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "بحث";

            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.ForeColor = Color.FromArgb(30, 45, 65);
            txtSearch.Location = new Point(287, 70);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(201, 31);
            txtSearch.TabIndex = 1;

            // 
            // btnSearch
            // 
            btnSearch.BackColor = Color.FromArgb(45, 110, 180);
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnSearch.ForeColor = Color.White;
            btnSearch.Location = new Point(405, 107);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(77, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = false;

            // 
            // btnClearSearch
            // 
            btnClearSearch.BackColor = Color.FromArgb(220, 225, 230);
            btnClearSearch.FlatAppearance.BorderSize = 0;
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnClearSearch.ForeColor = Color.FromArgb(30, 45, 65);
            btnClearSearch.Location = new Point(287, 107);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(77, 34);
            btnClearSearch.TabIndex = 3;
            btnClearSearch.Text = "مسح";
            btnClearSearch.UseVisualStyleBackColor = false;

            // 
            // dgvAccounts
            // 
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.BackgroundColor = Color.White;
            dgvAccounts.BorderStyle = BorderStyle.FixedSingle;
            dgvAccounts.ColumnHeadersDefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(220, 228, 238),
                    ForeColor = Color.FromArgb(25, 40, 60),
                    Font = new Font(
                        "Arial",
                        10F,
                        FontStyle.Bold,
                        GraphicsUnit.Point,
                        178),
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                };

            dgvAccounts.DefaultCellStyle =
                new DataGridViewCellStyle
                {
                    BackColor = Color.White,
                    ForeColor = Color.FromArgb(30, 45, 65),
                    SelectionBackColor = Color.FromArgb(205, 220, 238),
                    SelectionForeColor = Color.FromArgb(15, 30, 50),
                    Font = new Font(
                        "Arial",
                        10F,
                        FontStyle.Regular,
                        GraphicsUnit.Point,
                        178)
                };

            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.GridColor = Color.FromArgb(215, 220, 225);
            dgvAccounts.Location = new Point(12, 191);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.ReadOnly = true;
            dgvAccounts.RowHeadersWidth = 62;
            dgvAccounts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
            dgvAccounts.MultiSelect = false;
            dgvAccounts.Size = new Size(793, 87);
            dgvAccounts.TabIndex = 4;

            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.ForeColor = Color.FromArgb(30, 45, 65);
            lblService.Location = new Point(664, 281);
            lblService.Name = "lblService";
            lblService.Size = new Size(72, 25);
            lblService.TabIndex = 5;
            lblService.Text = "الخدمة :";

            // 
            // txtService
            // 
            txtService.BackColor = Color.White;
            txtService.ForeColor = Color.FromArgb(30, 45, 65);
            txtService.Location = new Point(508, 278);
            txtService.Name = "txtService";
            txtService.Size = new Size(150, 31);
            txtService.TabIndex = 6;

            // 
            // blUsername
            // 
            blUsername.AutoSize = true;
            blUsername.ForeColor = Color.FromArgb(30, 45, 65);
            blUsername.Location = new Point(365, 281);
            blUsername.Name = "blUsername";
            blUsername.Size = new Size(131, 25);
            blUsername.TabIndex = 7;
            blUsername.Text = "اسم المستخدم :";

            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.White;
            txtUsername.ForeColor = Color.FromArgb(30, 45, 65);
            txtUsername.Location = new Point(199, 281);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 31);
            txtUsername.TabIndex = 8;

            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.ForeColor = Color.FromArgb(30, 45, 65);
            lblPassword.Location = new Point(374, 334);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(97, 25);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "كلمة المرور";

            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.White;
            txtPassword.ForeColor = Color.FromArgb(30, 45, 65);
            txtPassword.Location = new Point(199, 328);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 31);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;

            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = Color.FromArgb(220, 225, 230);
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnTogglePassword.ForeColor = Color.FromArgb(30, 45, 65);
            btnTogglePassword.Location = new Point(81, 325);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(112, 34);
            btnTogglePassword.TabIndex = 11;
            btnTogglePassword.Text = "إظهار";
            btnTogglePassword.UseVisualStyleBackColor = false;

            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.ForeColor = Color.FromArgb(30, 45, 65);
            lblWebsite.Location = new Point(705, 403);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(63, 25);
            lblWebsite.TabIndex = 12;
            lblWebsite.Text = "الموقع";

            // 
            // txtWebsite
            // 
            txtWebsite.BackColor = Color.White;
            txtWebsite.ForeColor = Color.FromArgb(30, 45, 65);
            txtWebsite.Location = new Point(655, 441);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(150, 31);
            txtWebsite.TabIndex = 13;

            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.ForeColor = Color.FromArgb(30, 45, 65);
            lblNotes.Location = new Point(23, 432);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(98, 25);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "الملاحظات";

            // 
            // txtNotes
            // 
            txtNotes.BackColor = Color.White;
            txtNotes.ForeColor = Color.FromArgb(30, 45, 65);
            txtNotes.Location = new Point(12, 460);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(150, 31);
            txtNotes.TabIndex = 15;

            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.BackColor = Color.FromArgb(45, 110, 180);
            btnGeneratePassword.FlatAppearance.BorderSize = 0;
            btnGeneratePassword.FlatStyle = FlatStyle.Flat;
            btnGeneratePassword.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnGeneratePassword.ForeColor = Color.White;
            btnGeneratePassword.Location = new Point(12, 24);
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.Size = new Size(164, 34);
            btnGeneratePassword.TabIndex = 16;
            btnGeneratePassword.Text = "توليد كلمة المرور";
            btnGeneratePassword.UseVisualStyleBackColor = false;

            // 
            // btnEvaluatePassword
            // 
            btnEvaluatePassword.BackColor = Color.FromArgb(75, 145, 110);
            btnEvaluatePassword.FlatAppearance.BorderSize = 0;
            btnEvaluatePassword.FlatStyle = FlatStyle.Flat;
            btnEvaluatePassword.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnEvaluatePassword.ForeColor = Color.White;
            btnEvaluatePassword.Location = new Point(12, 70);
            btnEvaluatePassword.Name = "btnEvaluatePassword";
            btnEvaluatePassword.Size = new Size(164, 34);
            btnEvaluatePassword.TabIndex = 17;
            btnEvaluatePassword.Text = "تقييم القوة";
            btnEvaluatePassword.UseVisualStyleBackColor = false;

            // 
            // btnCopyPassword
            // 
            btnCopyPassword.BackColor = Color.FromArgb(220, 225, 230);
            btnCopyPassword.FlatAppearance.BorderSize = 0;
            btnCopyPassword.FlatStyle = FlatStyle.Flat;
            btnCopyPassword.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnCopyPassword.ForeColor = Color.FromArgb(30, 45, 65);
            btnCopyPassword.Location = new Point(12, 118);
            btnCopyPassword.Name = "btnCopyPassword";
            btnCopyPassword.Size = new Size(164, 34);
            btnCopyPassword.TabIndex = 18;
            btnCopyPassword.Text = "نسخ";
            btnCopyPassword.UseVisualStyleBackColor = false;

            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(55, 150, 95);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(746, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "إضافة";
            btnAdd.UseVisualStyleBackColor = false;

            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(45, 110, 180);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(746, 58);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "تعديل";
            btnUpdate.UseVisualStyleBackColor = false;

            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(220, 225, 230);
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnClear.ForeColor = Color.FromArgb(30, 45, 65);
            btnClear.Location = new Point(743, 144);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 21;
            btnClear.Text = "مسح";
            btnClear.UseVisualStyleBackColor = false;

            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(190, 65, 65);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font(
                "Arial",
                9.5F,
                FontStyle.Bold,
                GraphicsUnit.Point,
                178);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(746, 98);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "حذف";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;

            // 
            // AccountsForm
            // 
            AutoScaleDimensions =
                new SizeF(10F, 25F);

            AutoScaleMode =
                AutoScaleMode.Font;

            BackColor =
                Color.FromArgb(245, 247, 250);

            ClientSize =
                new Size(870, 507);

            Controls.Add(btnDelete);
            Controls.Add(btnClear);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnCopyPassword);
            Controls.Add(btnEvaluatePassword);
            Controls.Add(btnGeneratePassword);
            Controls.Add(txtNotes);
            Controls.Add(lblNotes);
            Controls.Add(txtWebsite);
            Controls.Add(lblWebsite);
            Controls.Add(btnTogglePassword);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(blUsername);
            Controls.Add(txtService);
            Controls.Add(lblService);
            Controls.Add(dgvAccounts);
            Controls.Add(btnClearSearch);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);

            Font =
                new Font(
                    "Arial",
                    10F,
                    FontStyle.Regular,
                    GraphicsUnit.Point,
                    178);

            ForeColor =
                Color.FromArgb(30, 45, 65);

            Name =
                "AccountsForm";

            StartPosition =
                FormStartPosition.CenterParent;

            Text =
                "إدارة الحسابات";

            ((System.ComponentModel.ISupportInitialize)dgvAccounts).EndInit();

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnClearSearch;
        private DataGridView dgvAccounts;
        private Label lblService;
        private TextBox txtService;
        private Label blUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnTogglePassword;
        private Label lblWebsite;
        private TextBox txtWebsite;
        private Label lblNotes;
        private TextBox txtNotes;
        private Button btnGeneratePassword;
        private Button btnEvaluatePassword;
        private Button btnCopyPassword;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnClear;
        private Button btnDelete;
    }
}