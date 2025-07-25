using AvataiTestAppMashkantsev.Core.ViewModel;

namespace AvataiTestAppMashkantsev.Core.Model;

public class ItemModel : LightweightBaseViewModel
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }

    private bool _isLastOpened;

    public bool IsLastOpened
    {
        get => _isLastOpened;
        set => SetProperty(ref _isLastOpened, value);
    }
}