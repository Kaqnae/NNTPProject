using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NNTPProject.Presentation;
using NNTPProject.UseCases;

namespace NNTPProject;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ConnectionState _connectionState;
    public MainWindow()
    {
        InitializeComponent();
        
        _connectionState = ConnectionState.Instance;
        _connectionState.PropertyChanged += ConnectionState_PropertyChanged;

        Console.WriteLine($"IsConnected: {_connectionState.IsConnected}");

        if (_connectionState.IsConnected)
        {
            Console.WriteLine($"Main Window connected! Connected to {_connectionState.Server}:{_connectionState.Port}");
        }
        
        
    }

    private void SetupButton_Click(object sender, RoutedEventArgs e)
    {
        SetupWindow setupWindow = new SetupWindow();
        setupWindow.Show();

     

    }

    private void ConnectionState_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(ConnectionState.IsConnected))
        {
            UpdateConnectionStatus();
        }
        
    }

    private void UpdateConnectionStatus()
    {
        if (_connectionState.IsConnected)
        {
            Console.WriteLine($"MainWindow IsConnected: {_connectionState.IsConnected}");
        }
    }

}