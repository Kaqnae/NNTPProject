namespace NNTPProject.Infrastructure;

public interface IServer
{
    void Connect(string url, int port, string username, string password);
    string List();
}