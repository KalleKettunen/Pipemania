using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public class EnumerableFeeder<T> : Feeder<T>
    {
        private readonly IEnumerable<T> _enumerable;

        public EnumerableFeeder(IEnumerable<T> enumerable)
        {
            _enumerable = enumerable;
        }
        public override async Task Feed()
        {
            foreach (var item in _enumerable)
            {

                foreach (var endPoint in EndPoints)
                {
                    await endPoint.Receive(item);
                }
            }
        }
    }
}
