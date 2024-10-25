using System.ComponentModel;
using System.Windows;
using NNTPProject.Infrastructure;
using NNTPProject.InterfaceAdapter;
using NNTPProject.Presentation.ViewModels;
using NNTPProject.UseCases;

namespace NNTPProject.Presentation;

public partial class SetupWindow : Window
{
    private readonly SetupViewModel _setupViewModel;
    private ConnectionState ConnectionState;
    
    
    public SetupWindow()
    {
        InitializeComponent();

        IServer serverAdapter = new ServerAdapter();
        var connectToServer = new ConnectToServer(serverAdapter);
        var _connectionState = ConnectionState.Instance;
        
        _setupViewModel = new SetupViewModel(connectToServer);
        this.DataContext = _setupViewModel;
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        string password = PasswordBox.Password;
        
        _setupViewModel.Password = password;
        
        _setupViewModel.ExecuteOK(null);
        
        
        
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        this.Close();
    }

}