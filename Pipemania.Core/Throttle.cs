using System.Threading.Tasks;
using System.Timers;

namespace Pipemania.Core
{
    public class Throttle<TSource> : Filter<TSource>
    {
        private readonly int _milliSeconds;
        private bool _throttling = false;
        
        public Throttle(int milliSeconds)
        {
            _milliSeconds = milliSeconds;
        }

        private async Task StartThrottle()
        {
            await Task.Delay(_milliSeconds);
            _throttling = false;
        }
        
        protected override bool FilterFunc(TSource source)
        {
            if (_throttling) return false;
            
            _throttling = true;
            StartThrottle();
            return true;

        }
    }
}