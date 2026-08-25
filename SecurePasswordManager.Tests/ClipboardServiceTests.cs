using SecurePasswordManager.Services;

namespace SecurePasswordManager.Tests;

public class ClipboardServiceTests
{
    [Fact]
    public void CopyText_EmptyText_ShouldThrow()
    {
        var service = new ClipboardService();

        Assert.Throws<ArgumentException>(
            () => service.CopyText(""));
    }

    [Fact]
    public void CopyText_NullText_ShouldThrow()
    {
        var service = new ClipboardService();

        Assert.Throws<ArgumentException>(
            () => service.CopyText(null!));
    }
}