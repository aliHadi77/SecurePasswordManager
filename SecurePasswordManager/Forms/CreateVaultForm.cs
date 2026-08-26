using SecurePasswordManager.Services;

namespace SecurePasswordManager.Forms
{
    public partial class CreateVaultForm : Form
    {
        private readonly VaultService _vaultService;

        public CreateVaultForm(
            VaultService vaultService)
        {
            InitializeComponent();

            _vaultService =
                vaultService
                ?? throw new ArgumentNullException(
                    nameof(vaultService));

            AcceptButton = btnCreateVault;
            CancelButton = btnCancel;
        }

        private void btnCreateVault_Click(
            object? sender,
            EventArgs e)
        {
            string masterPassword =
                txtMasterPassword.Text;

            string confirmPassword =
                txtConfirmPassword.Text;

            try
            {
                SecurePasswordManager.Security.MasterPasswordValidator.Validate(
                    masterPassword);

            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "بيانات غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMasterPassword.Focus();

                return;
            }

            if (masterPassword !=
                confirmPassword)
            {
                MessageBox.Show(
                    "كلمتا المرور غير متطابقتين.",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtConfirmPassword.Focus();

                return;
            }

            try
            {
                _vaultService.CreateVault(
                    masterPassword);

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "تعذر إنشاء الخزنة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "بيانات غير صحيحة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "حدث خطأ غير متوقع أثناء إنشاء الخزنة.",
                    "خطأ",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(
            object? sender,
            EventArgs e)
        {
            DialogResult =
                DialogResult.Cancel;

            Close();
        }
    }
}
