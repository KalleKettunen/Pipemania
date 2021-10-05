using System.Threading.Tasks;

namespace Pipemania.Core.Interfaces
{

    public abstract class Consumer<TSource> : IEndPoint<TSource>
    {
        protected bool ReadyState;
        public abstract Task Receive(TSource source);

        public virtual void Ready(bool ready)
        {
            ReadyState = ready;
        }
        
        public virtual bool IsConnected => true;
    }
}
