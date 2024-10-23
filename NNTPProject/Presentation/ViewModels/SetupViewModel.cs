using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NNTPProject.Presentation.ViewModels;

public class SetupViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    private string _serverName;
    private string _port;
    private string _username;
    private string _password;
    public RelayCommand OkCommand { get; }
    public RelayCommand CancelCommand { get; }

    public SetupViewModel()
    {
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

    public string Port
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
        MessageBox.Show("Server Connected!");
        
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