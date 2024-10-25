using System.IO;
using System.Net.Sockets;
using System.Text;
using NNTPProject.Infrastructure;

namespace NNTPProject.InterfaceAdapter;

public class ServerAdapter : IServer
{
    public void Connect(string url, int port, string username, string password)
    {
        try
        {
            using (TcpClient client = new TcpClient(url, port))
            {

                NetworkStream stream = client.GetStream();
                StreamReader reader = new StreamReader(stream, Encoding.ASCII);
                StreamWriter writer = new StreamWriter(stream, Encoding.ASCII)
                {

                    AutoFlush = true

                };



                string response = reader.ReadLine();
                Console.WriteLine($"Server response: {response}\n");

                writer.WriteLine($"AUTHINFO USER {username}\r\n");
                Console.WriteLine($"Sent: AUTHINFO USER {username}");
                response = reader.ReadLine();
                Console.WriteLine($"Server response: {response}\n");



                if (response.StartsWith("381"))
                {

                    writer.WriteLine($"AUTHINFO PASS {password}\r\n");
                    Console.WriteLine($"Sent: AUTHINFO PASS {password}\n");

                    response = reader.ReadLine();
                    Console.WriteLine($"Server response: {response}");


                    if (response.StartsWith("281"))
                    {
                        Console.WriteLine("Successfully authenticated");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public string List()
    {
        throw new NotImplementedException();
    }
}


  