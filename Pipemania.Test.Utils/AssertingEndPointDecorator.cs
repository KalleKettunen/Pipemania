using System;
using System.Threading.Tasks;

namespace Pipemania.Test.Utils
{
    public class AssertingEndPointDecorator<TSource> : IEndPoint<TSource>
    {
        private readonly IEndPoint<TSource> _endPoint;
        private readonly Action<TSource> _assertFunc;

        public AssertingEndPointDecorator(IEndPoint<TSource> endPoint, Action<TSource> assertFunc)
        {
            _endPoint = endPoint;
            _assertFunc = assertFunc;
        }
        public Task Receive(TSource source)
        {
            _assertFunc(source);
            return _endPoint.Receive(source);
        }

        public bool IsConnected => _endPoint.IsConnected;
    }
}
