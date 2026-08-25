using SecurePasswordManager.Data;
using SecurePasswordManager.Forms;
using SecurePasswordManager.Security;
using SecurePasswordManager.Services;

namespace SecurePasswordManager
{
    public partial class Form1 : Form
    {
        private readonly VaultService _vaultService;
        private readonly VaultRepository _repository;

        private readonly EntryService _entryService;
        private readonly PasswordGenerator _passwordGenerator;
        private readonly PasswordStrengthEvaluator _strengthEvaluator;
        private readonly ClipboardService _clipboardService;

        public Form1()
        {
            InitializeComponent();

            string databasePath =
                Path.Combine(
                    AppContext.BaseDirectory,
                    "SecurePasswordManager.db");

            var initializer =
                new DatabaseInitializer(databasePath);

            initializer.Initialize();

            _repository =
                new VaultRepository(databasePath);
            _repository =
    new VaultRepository(databasePath);

            MessageBox.Show(
                $"عدد الخزائن: {_repository.GetVaultCount()}",
                "فحص",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            var encryptionService =
                new EncryptionService();

            _vaultService =
                new VaultService(
                    _repository,
                    new KeyDerivationService(),
                    encryptionService);

            _entryService =
                new EntryService(
                    _vaultService,
                    _repository,
                    encryptionService);

            _passwordGenerator =
                new PasswordGenerator();

            _strengthEvaluator =
                new PasswordStrengthEvaluator();

            _clipboardService =
                new ClipboardService();

            UpdateVaultState();
        }

        private void UpdateVaultState()
        {
            bool vaultExists =
                _repository.GetVaultCount() > 0;

            if (_vaultService.IsUnlocked)
            {
                lblVaultStatus.Text =
                    "حالة الخزنة: مفتوحة";

                btnCreateVault.Enabled = false;
                btnUnlockVault.Enabled = false;
                btnLockVault.Enabled = true;

                btnAccounts.Enabled = true;
                btnPasswordGenerator.Enabled = true;
            }
            else if (vaultExists)
            {
                lblVaultStatus.Text =
                    "حالة الخزنة: مقفلة";

                btnCreateVault.Enabled = false;
                btnUnlockVault.Enabled = true;
                btnLockVault.Enabled = false;

                btnAccounts.Enabled = false;
                btnPasswordGenerator.Enabled = true;
            }
            else
            {
                lblVaultStatus.Text =
                    "لا توجد خزنة";

                btnCreateVault.Enabled = true;
                btnUnlockVault.Enabled = false;
                btnLockVault.Enabled = false;

                btnAccounts.Enabled = false;
                btnPasswordGenerator.Enabled = true;
            }
        }

        private void btnCreateVault_Click(
            object? sender,
            EventArgs e)
        {
            using var form =
                new CreateVaultForm(_vaultService);

            if (form.ShowDialog(this) ==
                DialogResult.OK)
            {
                UpdateVaultState();

               
            }
        }

        private void btnUnlockVault_Click(
            object? sender,
            EventArgs e)
        {
            var vault =
                _repository.GetFirstVault();

            if (vault is null)
            {
                MessageBox.Show(
                    "لا توجد خزنة. قم بإنشاء خزنة جديدة أولًا.",
                    "لا توجد خزنة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            using var form =
                new UnlockVaultForm(
                    _vaultService,
                    vault.Id);

            if (form.ShowDialog(this) ==
                DialogResult.OK)
            {
                UpdateVaultState();

                MessageBox.Show(
                    "تم فتح الخزنة بنجاح.",
                    "نجاح",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnLockVault_Click(
            object? sender,
            EventArgs e)
        {
            if (!_vaultService.IsUnlocked)
            {
                MessageBox.Show(
                    "الخزنة مقفلة بالفعل.",
                    "تنبيه",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                return;
            }

            _vaultService.Lock();

            UpdateVaultState();

            MessageBox.Show(
                "تم قفل الخزنة وإنهاء الوصول إلى البيانات الحساسة.",
                "تم القفل",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnAccounts_Click(
            object? sender,
            EventArgs e)
        {
            if (!_vaultService.IsUnlocked)
            {
                MessageBox.Show(
                    "يجب فتح الخزنة أولًا.",
                    "الخزنة مقفلة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            using var form =
                new AccountsForm(
                    _entryService,
                    _passwordGenerator,
                    _strengthEvaluator,
                    _clipboardService);

            form.ShowDialog(this);
        }

        private void btnPasswordGenerator_Click(
            object? sender,
            EventArgs e)
        {
            using var form =
                new PasswordGeneratorForm(
                    _passwordGenerator,
                    _strengthEvaluator,
                    _clipboardService);

            form.ShowDialog(this);
        }
    }
}