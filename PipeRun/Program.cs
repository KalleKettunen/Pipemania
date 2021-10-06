using System.Collections.Generic;
using System.Linq;
using Pipemania.Console;
using System.Threading.Tasks;
using Pipemania.File;
using Pipemania.PipeLine;
using Pipemania.PipeLine.Extensions;

namespace PipeRun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            /*var source = new ConsoleReader();
            var endPoint = new ConsoleWriter();

            var pipeline = new ContinuousPipeLineBuilder<string>(source).Map(s => s.ToUpper()).Close(endPoint);

            await pipeline.Run();*/

            var source = new TextFileFeeder(@"C:\Work\feed.txt");
            using var endpoint = new TextFileSink(@"C:\Work\sink.txt");
            
            var pipeLine = new BatchPipeLineBuilder<IReadOnlyCollection<string>>(source)
                .Map(lines => lines.Select(s => s.ToUpper()))
                .Flatten()
                .Close(endpoint);

            await pipeLine.Run();
        }
    }
}
