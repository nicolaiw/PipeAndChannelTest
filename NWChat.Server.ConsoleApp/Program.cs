using NWChat.Core.Logging;
using NWChat.Core.Networking;
using System.Net.Sockets;

namespace NWChat.Server.ConsoleApp
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var listener = new TcpListener(System.Net.IPAddress.Any, 8888);

            listener.Start();

            var client = await listener.AcceptTcpClientAsync();

            Console.WriteLine("client connected.");

            var networkReader = new NetworkReader(new ConsoleLogger());

            var listenTask = networkReader.StartListeningAsync(client.Client);

            await foreach (var msg in networkReader.WaitForMessagesAsync())
            {
                string result = System.Text.Encoding.UTF8.GetString(msg.ToArray());

                Console.WriteLine("incomming message: " + result);
            }

            await listenTask;
        }
    }
}