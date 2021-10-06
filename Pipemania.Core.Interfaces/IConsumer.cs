using System.Threading.Tasks;

namespace Pipemania.Core.Interfaces
{

    public abstract class Consumer<TSource> : IEndPoint<TSource>
    {
        protected bool ReadyState;
        public abstract Task Receive(TSource source);

        public virtual Task SetReady()
        {
            ReadyState = true;
            
            return Task.CompletedTask;
        }
        
        public virtual bool IsConnected => true;
    }
}
