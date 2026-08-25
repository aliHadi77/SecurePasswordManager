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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            lblSearch.Location = new Point(365, 33);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(46, 25);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "بحث";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(287, 70);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(201, 31);
            txtSearch.TabIndex = 1;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(405, 107);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(77, 34);
            btnSearch.TabIndex = 2;
            btnSearch.Text = "بحث";
            btnSearch.UseVisualStyleBackColor = true;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Location = new Point(287, 107);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(77, 34);
            btnClearSearch.TabIndex = 3;
            btnClearSearch.Text = "مسح";
            btnClearSearch.UseVisualStyleBackColor = true;
            // 
            // dgvAccounts
            // 
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAccounts.Location = new Point(12, 191);
            dgvAccounts.Name = "dgvAccounts";
            dgvAccounts.RowHeadersWidth = 62;
            dgvAccounts.Size = new Size(793, 87);
            dgvAccounts.TabIndex = 4;
            // 
            // lblService
            // 
            lblService.AutoSize = true;
            lblService.Location = new Point(664, 281);
            lblService.Name = "lblService";
            lblService.Size = new Size(72, 25);
            lblService.TabIndex = 5;
            lblService.Text = "الخدمة :";
            // 
            // txtService
            // 
            txtService.Location = new Point(508, 278);
            txtService.Name = "txtService";
            txtService.Size = new Size(150, 31);
            txtService.TabIndex = 6;
            // 
            // blUsername
            // 
            blUsername.AutoSize = true;
            blUsername.Location = new Point(365, 281);
            blUsername.Name = "blUsername";
            blUsername.Size = new Size(131, 25);
            blUsername.TabIndex = 7;
            blUsername.Text = "اسم المستخدم :";
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(199, 281);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(150, 31);
            txtUsername.TabIndex = 8;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(374, 334);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(97, 25);
            lblPassword.TabIndex = 9;
            lblPassword.Text = "كلمة المرور";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(199, 328);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(150, 31);
            txtPassword.TabIndex = 10;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.Location = new Point(81, 325);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(112, 34);
            btnTogglePassword.TabIndex = 11;
            btnTogglePassword.Text = "إظهار ";
            btnTogglePassword.UseVisualStyleBackColor = true;
            // 
            // lblWebsite
            // 
            lblWebsite.AutoSize = true;
            lblWebsite.Location = new Point(705, 403);
            lblWebsite.Name = "lblWebsite";
            lblWebsite.Size = new Size(63, 25);
            lblWebsite.TabIndex = 12;
            lblWebsite.Text = "الموقع";
            // 
            // txtWebsite
            // 
            txtWebsite.Location = new Point(655, 441);
            txtWebsite.Name = "txtWebsite";
            txtWebsite.Size = new Size(150, 31);
            txtWebsite.TabIndex = 13;
            // 
            // lblNotes
            // 
            lblNotes.AutoSize = true;
            lblNotes.Location = new Point(23, 432);
            lblNotes.Name = "lblNotes";
            lblNotes.Size = new Size(98, 25);
            lblNotes.TabIndex = 14;
            lblNotes.Text = "الملاحظات ";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(12, 460);
            txtNotes.Multiline = true;
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(150, 31);
            txtNotes.TabIndex = 15;
            // 
            // btnGeneratePassword
            // 
            btnGeneratePassword.Location = new Point(12, 24);
            btnGeneratePassword.Name = "btnGeneratePassword";
            btnGeneratePassword.Size = new Size(164, 34);
            btnGeneratePassword.TabIndex = 16;
            btnGeneratePassword.Text = "توليد كلمة المرور";
            btnGeneratePassword.UseVisualStyleBackColor = true;
            // 
            // btnEvaluatePassword
            // 
            btnEvaluatePassword.Location = new Point(12, 70);
            btnEvaluatePassword.Name = "btnEvaluatePassword";
            btnEvaluatePassword.Size = new Size(164, 34);
            btnEvaluatePassword.TabIndex = 17;
            btnEvaluatePassword.Text = "تقييم القوة";
            btnEvaluatePassword.UseVisualStyleBackColor = true;
            // 
            // btnCopyPassword
            // 
            btnCopyPassword.Location = new Point(12, 118);
            btnCopyPassword.Name = "btnCopyPassword";
            btnCopyPassword.Size = new Size(164, 34);
            btnCopyPassword.TabIndex = 18;
            btnCopyPassword.Text = "نسخ";
            btnCopyPassword.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(746, 12);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "إضافة";
            btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(746, 58);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 20;
            btnUpdate.Text = "تعديل";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            btnClear.Location = new Point(743, 144);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(112, 34);
            btnClear.TabIndex = 21;
            btnClear.Text = "مسح";
            btnClear.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(746, 98);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(112, 34);
            btnDelete.TabIndex = 22;
            btnDelete.Text = "حذف ";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // AccountsForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 507);
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
            Name = "AccountsForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "إدارة الحسابات";
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