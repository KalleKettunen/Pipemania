using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public sealed class NullEndPoint<TSource> : IEndPoint<TSource>
    {
        public Task Receive(TSource source)
        {
            return Task.CompletedTask;
        }

        public Task SetReady()
        {
            return Task.CompletedTask;
        }

        public bool IsConnected => true;
    }
}
