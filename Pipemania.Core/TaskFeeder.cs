using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.Core
{
    public class TaskFeeder<T> : BatchFeeder<T>
    {
        private readonly Task<T> _task;

        public TaskFeeder(Task<T> task)
        {
            _task = task;
        }
        public override async Task Feed()
        {
            if (!Ready)
            {
                await Task.WhenAll(EndPoints.Select(async endpoint => endpoint.Receive(await _task)));
                Ready = true;
            }
        }
    }
}