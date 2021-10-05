using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public class TaskEndPointDecorator<TSource> : IBatchEndPoint<TSource>
    {
        private readonly IEndPoint<TSource> _endPoint;
        private bool _ready;
        private readonly Task _result;
        private TSource _value;
        
        public TaskEndPointDecorator(IEndPoint<TSource> endPoint)
        {
            _endPoint = endPoint;
            _result = Task.Run(async () =>
            {
                while (!_ready)
                {
                    await Task.Delay(100);
                }
            });
        }
        
        public async Task Receive(TSource source)
        {
            _value = source;
            _ready = true;

            await _endPoint.Receive(source);
            
        }

        public void Ready(bool ready)
        {
            _endPoint.Ready(ready);
        }

        public async Task<TSource> GetValue()
        {
            await _result;
            return _value;
        }

        public bool IsConnected => _endPoint.IsConnected;
    }
}