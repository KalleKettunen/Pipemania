using Pipemania.Console;
using System;
using System.Threading.Tasks;
using Pipemania.PipeLine;

namespace PipeRun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var source = new ConsoleReader();
            var endPoint = new ConsoleWriter();

            var pipeline = new BatchPipeLineBuilder<string>(source).Close(endPoint);

            await pipeline.Run();

         
        }
    }
}
