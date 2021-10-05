using System;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Console
{
    public class ConsoleWriter : Consumer<string>
    {
        public override Task Receive(string source)
        {
            System.Console.WriteLine(source);
            
            return Task.CompletedTask;
        }
    }
}
