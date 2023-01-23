using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWChat.Core.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void LogError(string message)
        {
            Console.WriteLine($"Error: {message}\n");
        }

        public void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}\n");
        }

        public void LogWarning(string message)
        {
            Console.WriteLine($"Warning: {message}\n");
        }
    }
}
