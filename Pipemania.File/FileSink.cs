using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.File
{
    public abstract class FileSink<TSource> : Consumer<TSource>, IBatchEndPoint<TSource>
    {
        public override async Task Receive(TSource source)
        {
            await WriteToFile(source);
        }

        protected abstract Task WriteToFile(TSource source);
    }
}