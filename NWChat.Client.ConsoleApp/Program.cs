using System.Net.Sockets;

namespace NWChat.Client.ConsoleApp;

internal class Program
{
    static async Task Main(string[] args)
    {
        string? msg;
        var client = new TcpClient("localhost", 8888);

        var writer = new StreamWriter(client.GetStream());

        while ((msg = Console.ReadLine()) != "c")
        {
            if (msg == null)
                continue;

            //await writer.WriteLineAsync(msg);

            await writer.WriteAsync(msg + "\n"); // Server listens to "\n" as the end of a message

            await writer.FlushAsync();
        }
    }
}
