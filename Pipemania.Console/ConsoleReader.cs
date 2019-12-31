using System;
using System.Threading.Tasks;

namespace Pipemania.Console
{
    public class ConsoleReader : Feeder<string>
    {
        public override Task Feed()
        {
            return Task.Run(() =>
            {
                while (true)
                {
                    foreach (var endPoint in EndPoints)
                    {
                        var input = System.Console.ReadLine();
                        endPoint.Receive(input);
                    }
                }
            });
        }
    }
}
