using SecurePasswordManager.Models;
using SecurePasswordManager.Security;
using SecurePasswordManager.Services;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SecurePasswordManager.Forms
{
    public partial class AccountsForm : Form
    {
        private readonly EntryService _entryService;
        private readonly PasswordGenerator _passwordGenerator;
        private readonly PasswordStrengthEvaluator _strengthEvaluator;
        private readonly ClipboardService _clipboardService;

        private long? _selectedEntryId;
        private bool _passwordVisible;

        public AccountsForm(
            EntryService entryService,
            PasswordGenerator passwordGenerator,
            PasswordStrengthEvaluator strengthEvaluator,
            ClipboardService clipboardService)
        {
            InitializeComponent();

            _entryService = entryService;
            _passwordGenerator = passwordGenerator;
            _strengthEvaluator = strengthEvaluator;
            _clipboardService = clipboardService;

            ConfigureAccountsGrid();

            Load += AccountsForm_Load;
            dgvAccounts.SelectionChanged += dgvAccounts_SelectionChanged;

            btnSearch.Click += btnSearch_Click;
            btnClearSearch.Click += btnClearSearch_Click;

            btnAdd.Click += btnAdd_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnClear.Click += btnClear_Click;

            btnGeneratePassword.Click += btnGeneratePassword_Click;
            btnEvaluatePassword.Click += btnEvaluatePassword_Click;
            btnCopyPassword.Click += btnCopyPassword_Click;
            btnTogglePassword.Click += btnTogglePassword_Click;
        }

        private void AccountsForm_Load(
            object? sender,
            EventArgs e)
        {
            _passwordVisible = false;
            txtPassword.UseSystemPasswordChar = true;
            btnTogglePassword.Text = "إظهار";

            LoadEntries();
        }

        private void ConfigureAccountsGrid()
        {
            dgvAccounts.AutoGenerateColumns = false;
            dgvAccounts.AllowUserToAddRows = false;
            dgvAccounts.ReadOnly = true;
            dgvAccounts.MultiSelect = false;
            dgvAccounts.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAccounts.Columns.Clear();

            var idColumn = new DataGridViewTextBoxColumn
            {
                Name = "Id",
                HeaderText = "Id",
                DataPropertyName = "Id",
                Visible = false
            };

            var serviceColumn = new DataGridViewTextBoxColumn
            {
                Name = "ServiceName",
                HeaderText = "الخدمة",
                DataPropertyName = "ServiceName",
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill
            };

            var usernameColumn = new DataGridViewTextBoxColumn
            {
                Name = "Username",
                HeaderText = "اسم المستخدم",
                DataPropertyName = "Username",
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill
            };

            var websiteColumn = new DataGridViewTextBoxColumn
            {
                Name = "Website",
                HeaderText = "الموقع",
                DataPropertyName = "Website",
                AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill
            };

            dgvAccounts.Columns.Add(idColumn);
            dgvAccounts.Columns.Add(serviceColumn);
            dgvAccounts.Columns.Add(usernameColumn);
            dgvAccounts.Columns.Add(websiteColumn);
        }

        private void LoadEntries()
        {
            try
            {
                List<VaultEntry> entries =
                    _entryService.GetEntries();

                dgvAccounts.DataSource = null;
                dgvAccounts.DataSource = entries;

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void SearchEntries()
        {
            try
            {
                string searchText =
                    txtSearch.Text.Trim();

                List<VaultEntry> entries;

                if (string.IsNullOrWhiteSpace(searchText))
                {
                    entries =
                        _entryService.GetEntries();
                }
                else
                {
                    entries =
                        _entryService.SearchEntries(
                            searchText);
                }

                dgvAccounts.DataSource = null;
                dgvAccounts.DataSource = entries;

                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في البحث",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvAccounts_SelectionChanged(
            object? sender,
            EventArgs e)
        {
            if (dgvAccounts.CurrentRow == null)
                return;

            if (dgvAccounts.CurrentRow.DataBoundItem
                is not VaultEntry entry)
            {
                return;
            }

            try
            {
                _selectedEntryId = entry.Id;

                txtService.Text =
                    entry.ServiceName;

                txtUsername.Text =
                    entry.Username;

                txtWebsite.Text =
                    entry.Website ?? string.Empty;

                txtPassword.Text =
                    _entryService.GetPassword(entry.Id);

                txtNotes.Text =
                    _entryService.GetNotes(entry.Id)
                    ?? string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تحميل بيانات الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(
            object? sender,
            EventArgs e)
        {
            SearchEntries();
        }

        private void btnClearSearch_Click(
            object? sender,
            EventArgs e)
        {
            txtSearch.Clear();
            LoadEntries();
        }

        private void btnAdd_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                string serviceName =
                    txtService.Text.Trim();

                string username =
                    txtUsername.Text.Trim();

                string password =
                    txtPassword.Text;

                string website =
                    txtWebsite.Text.Trim();

                string notes =
                    txtNotes.Text;

                ValidateAccountFields(
                    serviceName,
                    username,
                    password);

                long newEntryId =
                    _entryService.AddEntry(
                        serviceName,
                        username,
                        password,
                        string.IsNullOrWhiteSpace(notes)
                            ? null
                            : notes,
                        string.IsNullOrWhiteSpace(website)
                            ? null
                            : website);

                MessageBox.Show(
                    $"تمت إضافة الحساب بنجاح.\nرقم الحساب: {newEntryId}",
                    "تمت الإضافة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LoadEntries();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في إضافة الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                if (!_selectedEntryId.HasValue)
                {
                    MessageBox.Show(
                        "يرجى اختيار حساب من الجدول أولاً.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                string serviceName =
                    txtService.Text.Trim();

                string username =
                    txtUsername.Text.Trim();

                string password =
                    txtPassword.Text;

                string website =
                    txtWebsite.Text.Trim();

                string notes =
                    txtNotes.Text;

                ValidateAccountFields(
                    serviceName,
                    username,
                    password);

                bool updated =
                    _entryService.UpdateEntry(
                        _selectedEntryId.Value,
                        serviceName,
                        username,
                        password,
                        string.IsNullOrWhiteSpace(notes)
                            ? null
                            : notes,
                        string.IsNullOrWhiteSpace(website)
                            ? null
                            : website);

                if (updated)
                {
                    MessageBox.Show(
                        "تم تعديل الحساب بنجاح.",
                        "تم التعديل",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadEntries();
                }
                else
                {
                    MessageBox.Show(
                        "لم يتم تعديل الحساب.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تعديل الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                if (!_selectedEntryId.HasValue)
                {
                    MessageBox.Show(
                        "يرجى اختيار حساب من الجدول أولاً.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                DialogResult result =
                    MessageBox.Show(
                        "هل أنت متأكد من حذف الحساب المحدد؟",
                        "تأكيد الحذف",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                if (result != DialogResult.Yes)
                    return;

                bool deleted =
                    _entryService.DeleteEntry(
                        _selectedEntryId.Value);

                if (deleted)
                {
                    MessageBox.Show(
                        "تم حذف الحساب بنجاح.",
                        "تم الحذف",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadEntries();
                }
                else
                {
                    MessageBox.Show(
                        "لم يتم حذف الحساب.",
                        "تنبيه",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في حذف الحساب",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(
            object? sender,
            EventArgs e)
        {
            ClearFields();
        }

        private void btnGeneratePassword_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                string password =
                    _passwordGenerator.Generate(
                        length: 16,
                        includeUppercase: true,
                        includeLowercase: true,
                        includeDigits: true,
                        includeSymbols: true);

                txtPassword.Text = password;

                MessageBox.Show(
                    "تم توليد كلمة مرور قوية.",
                    "توليد كلمة المرور",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في توليد كلمة المرور",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnEvaluatePassword_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                string password =
                    txtPassword.Text;

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "يرجى إدخال كلمة المرور أولاً.",
                        "تقييم كلمة المرور",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                PasswordStrengthResult result =
                    _strengthEvaluator.Evaluate(
                        password);

                string suggestions =
                    result.Suggestions.Count == 0
                        ? "لا توجد اقتراحات. كلمة المرور جيدة."
                        : string.Join(
                            Environment.NewLine,
                            result.Suggestions);

                MessageBox.Show(
                    $"الدرجة: {result.Score}/100" +
                    Environment.NewLine +
                    $"المستوى: {GetArabicStrengthLevel(result.Level)}" +
                    Environment.NewLine +
                    Environment.NewLine +
                    suggestions,
                    "تقييم قوة كلمة المرور",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في تقييم كلمة المرور",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCopyPassword_Click(
            object? sender,
            EventArgs e)
        {
            try
            {
                string password =
                    txtPassword.Text;

                if (string.IsNullOrEmpty(password))
                {
                    MessageBox.Show(
                        "لا توجد كلمة مرور لنسخها.",
                        "نسخ كلمة المرور",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);

                    return;
                }

                _clipboardService.CopyText(password);

                MessageBox.Show(
                    "تم نسخ كلمة المرور إلى الحافظة.",
                    "تم النسخ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "خطأ في النسخ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnTogglePassword_Click(
            object? sender,
            EventArgs e)
        {
            _passwordVisible =
                !_passwordVisible;

            txtPassword.UseSystemPasswordChar =
                !_passwordVisible;

            btnTogglePassword.Text =
                _passwordVisible
                    ? "إخفاء"
                    : "إظهار";
        }

        private void ClearFields()
        {
            _selectedEntryId = null;

            txtService.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtWebsite.Clear();
            txtNotes.Clear();

            _passwordVisible = false;

            txtPassword.UseSystemPasswordChar =
                true;

            btnTogglePassword.Text =
                "إظهار";

            if (dgvAccounts.CurrentRow != null)
            {
                dgvAccounts.ClearSelection();
            }
        }

        private static void ValidateAccountFields(
            string serviceName,
            string username,
            string password)
        {
            if (string.IsNullOrWhiteSpace(serviceName))
            {
                throw new ArgumentException(
                    "يرجى إدخال اسم الخدمة.");
            }

            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException(
                    "يرجى إدخال اسم المستخدم.");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentException(
                    "يرجى إدخال كلمة المرور.");
            }
        }

        private static string GetArabicStrengthLevel(
            PasswordStrengthLevel level)
        {
            return level switch
            {
                PasswordStrengthLevel.Weak =>
                    "ضعيفة",

                PasswordStrengthLevel.Medium =>
                    "متوسطة",

                PasswordStrengthLevel.Strong =>
                    "قوية",

                PasswordStrengthLevel.VeryStrong =>
                    "قوية جدًا",

                _ =>
                    "غير معروف"
            };
        }
    }
}
