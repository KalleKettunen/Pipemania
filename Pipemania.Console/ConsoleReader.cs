using System;
using System.Threading.Tasks;

namespace Pipemania.Console
{
    public class ConsoleReader : ContinuousFeeder<string>
    {
        protected override async Task<string> GetFeed()
        {
            return System.Console.ReadLine();
        }
    }
}
