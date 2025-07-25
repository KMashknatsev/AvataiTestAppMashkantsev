

using AvataiTestAppMashkantsev.Core.ViewModel;

namespace AvataiTestAppMashkantsev.View;

public partial class FormPage : ContentPage
{
    public FormPage(FormViewModel formViewModel)
    {
        InitializeComponent();
        BindingContext = formViewModel;
    }
}