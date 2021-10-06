using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

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
            await Task.WhenAll(_enumerable.SelectMany(i => EndPoints.Select(async e => await e.Receive(i))));
            
            foreach (var endPoint in EndPoints)
            {
                endPoint.SetReady();
            }
        }
    }
}
