using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Test.Utils
{
    public class AssertingEndPointDecorator<TSource> : IEndPoint<TSource>
    {
        private readonly IEndPoint<TSource> _endPoint;
        private readonly IEnumerator<Action<TSource>> _assertFuncs;
        public bool Received { get; private set; }= false;

        public AssertingEndPointDecorator(IEndPoint<TSource> endPoint, params Action<TSource>[] assertFuncs)
        {
            _endPoint = endPoint;
            _assertFuncs = assertFuncs.ToList().GetEnumerator();
            _assertFuncs.MoveNext();
        }
        

        public Task Receive(TSource source)
        {
            Received = true;
            _assertFuncs.Current(source);
            _assertFuncs.MoveNext();
            return _endPoint.Receive(source);
        }

        public void Ready(bool ready)
        {
            
        }

        public bool IsConnected => _endPoint.IsConnected;
    }
}
