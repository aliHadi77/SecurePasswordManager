using SecurePasswordManager.Services;

namespace SecurePasswordManager.Forms
{
    public partial class UnlockVaultForm : Form
    {
        private readonly VaultService _vaultService;
        private readonly long _vaultId;

        public UnlockVaultForm(
            VaultService vaultService,
            long vaultId)
        {
            InitializeComponent();

            _vaultService =
                vaultService
                ?? throw new ArgumentNullException(
                    nameof(vaultService));

            if (vaultId <= 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(vaultId));
            }

            _vaultId = vaultId;

            AcceptButton = btnUnlock;
            CancelButton = btnCancel;
        }

        private void btnUnlock_Click(
            object? sender,
            EventArgs e)
        {
            string masterPassword =
                txtMasterPassword.Text;

            if (string.IsNullOrWhiteSpace(masterPassword))
            {
                MessageBox.Show(
                    "يرجى إدخال كلمة المرور الرئيسية.",
                    "بيانات ناقصة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMasterPassword.Focus();
                return;
            }

            try
            {
                _vaultService.Unlock(
                    _vaultId,
                    masterPassword);

                DialogResult =
                    DialogResult.OK;

                Close();
            }
            catch (UnauthorizedAccessException)
            {
                MessageBox.Show(
                    "كلمة المرور الرئيسية غير صحيحة.",
                    "فشل فتح الخزنة",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMasterPassword.SelectAll();
                txtMasterPassword.Focus();
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "تعذر فتح الخزنة",
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
                    "حدث خطأ غير متوقع أثناء فتح الخزنة.",
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