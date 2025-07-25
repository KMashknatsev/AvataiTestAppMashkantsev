using System.Collections.ObjectModel;
using AvataiTestAppMashkantsev.Core.Model;
using AvataiTestAppMashkantsev.Core.Services;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.Logging;

namespace AvataiTestAppMashkantsev.Core.ViewModel;

public partial class ListViewModel : BaseViewModel
{
    private ObservableCollection<ItemModel> _items = new();
    private bool isBusy;
    private int page = 0;
    private readonly INavigationService _navigationService;

    public ListViewModel(ILogger<ListViewModel> logger, INavigationService navigationService,
        ICrashReportService reportService) : base(logger, reportService)
    {
        LogInformation("ListViewModel initialized");
        _navigationService = navigationService;
        LoadMore();
    }
    
    public ObservableCollection<ItemModel> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }

    public bool IsBusy
    {
        get => isBusy;
        set => SetProperty(ref isBusy, value);
    }

    [RelayCommand]
    async Task LoadMore()
    {
        if (IsBusy) return;
        IsBusy = true;

        await Task.Delay(500);
        var newItems = Enumerable.Range(page * 20, 20).Select(i => new ItemModel
        {
            Id = i,
            Title = $"Item #{i}",
            Description = $"Details about item {i}"
        });
        foreach (var item in newItems) Items.Add(item);

        page++;
        IsBusy = false;
    }

    [RelayCommand]
    private async Task OpenItem(ItemModel item)
    {
        foreach (var it in Items)
            it.IsLastOpened = false;

        item.IsLastOpened = true;

        await _navigationService.NavigateToAsync("DetailsPage", new Dictionary<string, object> { ["Item"] = item });
    }
}