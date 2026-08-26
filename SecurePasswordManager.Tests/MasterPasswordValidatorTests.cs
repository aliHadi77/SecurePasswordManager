using SecurePasswordManager.Security;

namespace SecurePasswordManager.Tests;

public class MasterPasswordValidatorTests
{
    [Fact]
    public void Validate_PasswordShorterThan14Characters_ShouldReject()
    {
        ArgumentException exception = Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate(new string('a', 13)));

        Assert.Equal(
            MasterPasswordValidator.ValidationMessage,
            exception.Message);
    }

    [Fact]
    public void Validate_PasswordWithExactly14Characters_ShouldAccept()
    {
        MasterPasswordValidator.Validate(new string('a', 14));
    }

    [Fact]
    public void Validate_PasswordWithExactly128Characters_ShouldAccept()
    {
        MasterPasswordValidator.Validate(new string('a', 128));
    }

    [Fact]
    public void Validate_PasswordLongerThan128Characters_ShouldReject()
    {
        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate(new string('a', 129)));
    }

    [Fact]
    public void Validate_LongPassphraseWithInternalSpaces_ShouldAccept()
    {
        MasterPasswordValidator.Validate("correct horse battery staple");
    }

    [Fact]
    public void Validate_PasswordWithLeadingSpace_ShouldReject()
    {
        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate(" valid passphrase"));
    }

    [Fact]
    public void Validate_PasswordWithTrailingSpace_ShouldReject()
    {
        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate("valid passphrase "));
    }

    [Fact]
    public void Validate_LongPasswordWithoutDigits_ShouldAccept()
    {
        MasterPasswordValidator.Validate("onlylettersarefine");
    }

    [Fact]
    public void Validate_LongPasswordWithoutSymbols_ShouldAccept()
    {
        MasterPasswordValidator.Validate("LongPasswordNoSymbols");
    }

    [Fact]
    public void Validate_LongPasswordWithoutUppercase_ShouldAccept()
    {
        MasterPasswordValidator.Validate("lowercasepassphrase");
    }

    [Fact]
    public void Validate_PasswordWithControlCharacter_ShouldReject()
    {
        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate("valid\u0001passphrase"));
    }

    [Fact]
    public void Validate_NullEmptyOrWhitespaceOnly_ShouldReject()
    {
        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate(null));

        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate(string.Empty));

        Assert.Throws<ArgumentException>(() =>
            MasterPasswordValidator.Validate("              "));
    }
}
