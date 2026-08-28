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

            ConfigureButtonInteractions();

            UpdateVaultState();
        }

        private void ConfigureButtonInteractions()
        {
            ConfigureButton(btnCreateVault);
            ConfigureButton(btnUnlockVault);
            ConfigureButton(btnLockVault);
            ConfigureButton(btnAccounts);
            ConfigureButton(btnPasswordGenerator);
        }

        private void ConfigureButton(Button button)
        {
            button.MouseEnter += Button_MouseEnter;
            button.MouseLeave += Button_MouseLeave;
            button.MouseDown += Button_MouseDown;
            button.MouseUp += Button_MouseUp;
        }

        private void Button_MouseEnter(
            object? sender,
            EventArgs e)
        {
            if (sender is not Button button ||
                !button.Enabled)
            {
                return;
            }

            button.BackColor =
                Color.FromArgb(
                    59,
                    130,
                    246);
        }

        private void Button_MouseLeave(
            object? sender,
            EventArgs e)
        {
            if (sender is not Button button ||
                !button.Enabled)
            {
                return;
            }

            button.BackColor =
                Color.FromArgb(
                    37,
                    99,
                    235);
        }

        private void Button_MouseDown(
            object? sender,
            MouseEventArgs e)
        {
            if (sender is not Button button ||
                !button.Enabled ||
                e.Button != MouseButtons.Left)
            {
                return;
            }

            button.BackColor =
                Color.FromArgb(
                    29,
                    78,
                    216);
        }

        private void Button_MouseUp(
            object? sender,
            MouseEventArgs e)
        {
            if (sender is not Button button ||
                !button.Enabled ||
                e.Button != MouseButtons.Left)
            {
                return;
            }

            button.BackColor =
                Color.FromArgb(
                    59,
                    130,
                    246);
        }

        private void ApplyButtonStyles()
        {
            StyleButton(btnCreateVault);
            StyleButton(btnUnlockVault);
            StyleButton(btnLockVault);
            StyleButton(btnAccounts);
            StyleButton(btnPasswordGenerator);
        }

        private void StyleButton(Button button)
        {
            button.FlatStyle =
                FlatStyle.Flat;

            button.FlatAppearance.BorderSize =
                1;

            button.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    11F,
                    FontStyle.Bold,
                    GraphicsUnit.Point,
                    0);

            button.UseVisualStyleBackColor =
                false;

            if (button.Enabled)
            {
                button.BackColor =
                    Color.FromArgb(
                        37,
                        99,
                        235);

                button.ForeColor =
                    Color.White;

                button.FlatAppearance.BorderColor =
                    Color.FromArgb(
                        59,
                        130,
                        246);

                button.Cursor =
                    Cursors.Hand;
            }
            else
            {
                button.BackColor =
                    Color.FromArgb(
                        235,
                        238,
                        242);

                button.ForeColor =
                    Color.FromArgb(
                        30,
                        41,
                        59);

                button.FlatAppearance.BorderColor =
                    Color.FromArgb(
                        200,
                        207,
                        216);

                button.Cursor =
                    Cursors.Default;
            }
        }

        private void UpdateVaultState()
        {
            bool vaultExists =
                _repository.GetVaultCount() > 0;

            if (_vaultService.IsUnlocked)
            {
                lblVaultStatus.Text =
                    "حالة الخزنة: مفتوحة";

                lblStatusDescription.Text =
                    "الخزنة مفتوحة ويمكنك الوصول إلى حساباتك";

                UpdateVaultStatusAppearance(
                    isUnlocked: true,
                    vaultExists: true);

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

                lblStatusDescription.Text =
                    "البيانات محمية والخزنة مغلقة حاليًا";

                UpdateVaultStatusAppearance(
                    isUnlocked: false,
                    vaultExists: true);

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

                lblStatusDescription.Text =
                    "أنشئ خزنة جديدة للبدء";

                UpdateVaultStatusAppearance(
                    isUnlocked: false,
                    vaultExists: false);

                btnCreateVault.Enabled = true;
                btnUnlockVault.Enabled = false;
                btnLockVault.Enabled = false;

                btnAccounts.Enabled = false;
                btnPasswordGenerator.Enabled = true;
            }

            ApplyButtonStyles();
        }

        private void UpdateVaultStatusAppearance(
            bool isUnlocked,
            bool vaultExists)
        {
            if (isUnlocked)
            {
                pnlStatus.BackColor =
                    Color.FromArgb(
                        22,
                        55,
                        43);

                lblVaultStatus.ForeColor =
                    Color.FromArgb(
                        134,
                        239,
                        172);

                lblStatusDescription.ForeColor =
                    Color.FromArgb(
                        187,
                        247,
                        208);
            }
            else if (vaultExists)
            {
                pnlStatus.BackColor =
                    Color.FromArgb(
                        67,
                        52,
                        28);

                lblVaultStatus.ForeColor =
                    Color.FromArgb(
                        253,
                        230,
                        138);

                lblStatusDescription.ForeColor =
                    Color.FromArgb(
                        254,
                        240,
                        180);
            }
            else
            {
                pnlStatus.BackColor =
                    Color.FromArgb(
                        30,
                        41,
                        59);

                lblVaultStatus.ForeColor =
                    Color.FromArgb(
                        226,
                        232,
                        240);

                lblStatusDescription.ForeColor =
                    Color.FromArgb(
                        148,
                        163,
                        184);
            }
        }

        private void btnCreateVault_Click(
            object? sender,
            EventArgs e)
        {
            using var form =
                new CreateVaultForm(
                    _vaultService);

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