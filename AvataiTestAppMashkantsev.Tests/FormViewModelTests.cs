using Moq;
using AvataiTestAppMashkantsev.Core.ViewModel;
using AvataiTestAppMashkantsev.Core.Services;
using Microsoft.Extensions.Logging.Abstractions;

namespace AvataiTestAppMashkantsev.Tests;

public class FormViewModelTests
{
    [Fact]
    public async Task SubmitCommand_DoesNotExecute_WhenNameOrEmailEmpty()
    {
        var mockCrashReport = new Mock<ICrashReportService>();
        var mockDialog = new Mock<IDialogService>();
        mockDialog.Setup(d => d.ShowAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var vm = new FormViewModel(new NullLogger<FormViewModel>(), mockCrashReport.Object, mockDialog.Object)
        {
            Name = "",
            Email = ""
        };

        await vm.SubmitCommand.ExecuteAsync(null);

        Assert.False(vm.IsBusy);
        Assert.Equal("", vm.Name);
        mockDialog.Verify(d => d.ShowAlert("Ошибка", "Имя и Email обязательны", "Ок"), Times.Once);
    }

    [Fact]
    public async Task SubmitCommand_SetsIsBusyAndClearsFields_WhenValid()
    {
        var mockCrashReport = new Mock<ICrashReportService>();
        var mockDialog = new Mock<IDialogService>();
        mockDialog.Setup(d => d.ShowAlert(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
            .Returns(Task.CompletedTask);

        var vm = new FormViewModel(new NullLogger<FormViewModel>(), mockCrashReport.Object, mockDialog.Object)
        {
            Name = "Test User",
            Email = "test@example.com",
            Message = "Hello!"
        };

        bool wasBusySet = false;
        vm.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(vm.IsBusy) && vm.IsBusy)
                wasBusySet = true;
        };

        await vm.SubmitCommand.ExecuteAsync(null);

        Assert.True(wasBusySet);
        Assert.False(vm.IsBusy);
        Assert.Equal("", vm.Name);
        Assert.Equal("", vm.Email);
        Assert.Equal("", vm.Message);
    }
}