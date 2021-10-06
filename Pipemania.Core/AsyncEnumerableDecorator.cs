using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public class AsyncEnumerableDecorator<TSource> : IEndPoint<TSource>, IAsyncEnumerable<TSource>
    {
        private readonly IEndPoint<TSource> _endpoint;
        private readonly Queue<TSource> _queue = new Queue<TSource>();
        private bool _ready;

        public AsyncEnumerableDecorator(IEndPoint<TSource> endpoint)
        {
            _endpoint = endpoint;
        }

        public async Task Receive(TSource source)
        {
            _queue.Enqueue(source);
            await _endpoint.Receive(source);
        }

        public async Task SetReady()
        {
            await _endpoint.SetReady();
            _ready = true;
        }

        public async IAsyncEnumerator<TSource> GetAsyncEnumerator(CancellationToken token = new CancellationToken())
        {
            while (!(token.IsCancellationRequested || (_ready && !_queue.Any())))
            {
                if (_queue.Any())
                    yield return _queue.Dequeue();
                else
                    await Task.Delay(10, token);
            }
        }

        public bool IsConnected => _endpoint.IsConnected; 
    }
}