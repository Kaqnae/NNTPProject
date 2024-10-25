using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using NNTPProject.UseCases;

namespace NNTPProject.Presentation.ViewModels;

public class SetupViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _serverName;
    private int _port;
    private string _username;
    private string _password;
    public RelayCommand OkCommand { get; }
    public RelayCommand CancelCommand { get; }
    private ConnectToServer _connectToServer;
    private ConnectionState _connectionState;

    public SetupViewModel(ConnectToServer connectToServer)
    {
        this._connectToServer = connectToServer;
        _connectionState = ConnectionState.Instance;
            
        OkCommand = new RelayCommand(ExecuteOK);
        CancelCommand = new RelayCommand(ExecuteCancel);
    }


    public string Server
    {
        get => _serverName;
        set
        {
            _serverName = value;
            OnPropertyChanged("Server");
        }
    }

    public int Port
    {
        get => _port;
        set
        {
            _port = value;
            OnPropertyChanged("Port");
            
        }
    }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged("Username");
            
        }
    }



    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged("Password");
            
        }

    }

    public void ExecuteOK(object obj)
    {
        
        _connectionState.Server = Server;
        _connectionState.Port = Port;
        _connectionState.Username = Username;
        _connectionState.Password = Password;
        _connectToServer.Action(Server, Port, Username, Password);
        
        _connectionState.IsConnected = true;

        Console.WriteLine($"SetupViewModel: Connectionstate updated: {_connectionState.IsConnected}");

        if (_connectionState.IsConnected)
        {
            Application.Current.Windows[1]?.Close();
        }


    }

    private void ExecuteCancel(object obj)
    {
        Application.Current.Windows[1]?.Close();
        
    }
    
    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

  
}