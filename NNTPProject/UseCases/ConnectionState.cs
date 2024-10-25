using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NNTPProject.UseCases;

public class ConnectionState : INotifyPropertyChanged
{
    private static ConnectionState _instance = new ConnectionState();
    public event PropertyChangedEventHandler? PropertyChanged;
    
    public string _server  { get; set; }
    public int _port { get; set; }
    public string _username { get; set; }
    public string _password { get; set; }
    
    public bool _isConnected { get; set; }

    private ConnectionState()
    {
        IsConnected = false;
    }

    public static ConnectionState Instance
    {
        get{
            if (_instance == null)
            {
                _instance = new ConnectionState();
            }
            return _instance;
        }
    }

    public string Server
    {
        get=>_server;
        set
        {
            _server = value;
            OnPropertyChanged();
        }

    }

    public int Port
    {
        get => _port;
        set
        {
            _port = value;
            OnPropertyChanged();
        }
    }

    public string Username
    {
        get => _username;
        set
        {
            _username = value;
            OnPropertyChanged();
        }
    }

    public string Password
    {
        get => _password;
        set
        {
            _password = value;
            OnPropertyChanged();
        }
    }

    public bool IsConnected
    {
        get => _isConnected;
        set
        {
            _isConnected = value;
            OnPropertyChanged();
        }
    }

    
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}