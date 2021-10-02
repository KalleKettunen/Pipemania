using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania
{
    public interface IFeeder : INode
    {
        Task Feed();
    }

    public abstract class Feeder<TSource> : Source<TSource>, IFeeder
    {
        public abstract Task Feed();

        protected override ICollection<IEndPoint<TSource>> EndPoints { get; } = new List<IEndPoint<TSource>>();
        
        public override bool IsConnected => EndPoints.Any();
    }

    public abstract class ContinuousFeeder<TSource> : Feeder<TSource>
    {
        public override Task Feed()
        {
            return Task.Run(async () =>
            {
                while (true)
                {
                    var feed  = await GetFeed();
                    foreach (var endPoint in EndPoints)
                    {
                        await endPoint.Receive(feed);
                    }
                }
            });
        }

        protected abstract Task<TSource> GetFeed();
    }
    
    public abstract class BatchFeeder<TSource> : Feeder<TSource>
    {
        public abstract bool Ready { get; }
    }
}
