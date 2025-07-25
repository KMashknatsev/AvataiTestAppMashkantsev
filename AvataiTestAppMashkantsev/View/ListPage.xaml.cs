using AvataiTestAppMashkantsev.Core.ViewModel;

namespace AvataiTestAppMashkantsev.View;

public partial class ListPage : ContentPage
{
    public ListPage(ListViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}