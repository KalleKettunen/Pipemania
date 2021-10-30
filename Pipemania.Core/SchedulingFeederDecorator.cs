using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public class SchedulingFeederDecorator<TSource> : Feeder<TSource>
    {
        private class DelayedEndpoint<T> : IEndPoint<T>
        {
            private readonly IEndPoint<T> _endPoint;
            private readonly int _milliSeconds;

            public DelayedEndpoint(IEndPoint<T> endPoint, int milliSeconds)
            {
                _endPoint = endPoint;
                _milliSeconds = milliSeconds;
            }

            public bool IsConnected => _endPoint.IsConnected;
            public async Task Receive(T source)
            {
                await _endPoint.Receive(source);
                await Task.Delay(_milliSeconds);
            }

            public async Task SetReady()
            {
                await _endPoint.SetReady();
            }
        }
        
        private readonly Feeder<TSource> _feeder;
        private readonly int _milliSeconds;

        protected override ICollection<IEndPoint<TSource>> EndPoints =>
            base.EndPoints.Select(e => (IEndPoint<TSource>) new DelayedEndpoint<TSource>(e, _milliSeconds)).ToList();

        public SchedulingFeederDecorator(Feeder<TSource> feeder, int milliSeconds)
        {
            _feeder = feeder;
            _milliSeconds = milliSeconds;
        }

        public override async Task Feed()
        {
            await _feeder.Feed();
        }
    }
}