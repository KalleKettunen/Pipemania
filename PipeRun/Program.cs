using Pipemania.Console;
using System.Threading.Tasks;
using Pipemania.PipeLine;
using Pipemania.PipeLine.Extensions;

namespace PipeRun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var source = new ConsoleReader();
            var endPoint = new ConsoleWriter();

            var pipeline = new ContinuousPipeLineBuilder<string>(source).Map(s => s.ToUpper()).Close(endPoint);

            await pipeline.Run();

         
        }
    }
}
