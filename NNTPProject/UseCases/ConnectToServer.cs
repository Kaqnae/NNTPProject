using NNTPProject.Infrastructure;
using NNTPProject.InterfaceAdapter;


namespace NNTPProject.UseCases;


public class ConnectToServer
{
    
    private IServer _server;

    public ConnectToServer(IServer server)
    {
        this._server = server;
    }

    public void Action(string url, int port, string username, string password)
    {
        _server.Connect(url, port, username, password);
    }

}