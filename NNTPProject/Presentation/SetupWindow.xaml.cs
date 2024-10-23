using System.Windows;
using NNTPProject.Presentation.ViewModels;

namespace NNTPProject.Presentation;

public partial class SetupWindow : Window
{
    public SetupWindow()
    {
        InitializeComponent();
        this.DataContext = new SetupViewModel();
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        var viewModel = (SetupViewModel)this.DataContext;
        viewModel.Password = PasswordBox.Password;
        viewModel.ExecuteOK(null);
    }

}