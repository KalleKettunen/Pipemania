using System.Linq;
using System.Threading.Tasks;

namespace Pipemania.Core
{
    public class TaskFeeder<T> : Feeder<T>
    {
        private readonly Task<T> _task;

        public TaskFeeder(Task<T> task)
        {
            _task = task;
        }
        public override async Task Feed()
        {
            await Task.WhenAll(EndPoints.Select(async endpoint => endpoint.Receive(await _task)));
        }
    }
}