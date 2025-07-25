using AvataiTestAppMashkantsev.Core.Model;
using AvataiTestAppMashkantsev.Core.Services;
using Microsoft.Extensions.Logging;

namespace AvataiTestAppMashkantsev.Core.ViewModel;

[QueryProperty(nameof(Item), "Item")]
public class DetailsViewModel : BaseViewModel
{
    private ItemModel _item;

    public ItemModel Item
    {
        get => _item;
        set => SetProperty(ref _item, value);
    }

    public DetailsViewModel(ILogger<DetailsViewModel> logger, ICrashReportService reportService) : base(logger,
        reportService)
    {
        LogInformation("DetailsViewModel initialized");
    }
}