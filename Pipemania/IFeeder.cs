using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipemania
{
    public interface IFeeder
    {
        Task Feed();
    }

    public abstract class Feeder<TSource> : Source<TSource>, IFeeder
    {
        public abstract Task Feed();

        protected override ICollection<IEndPoint<TSource>> EndPoints { get; } = new List<IEndPoint<TSource>>();
        
        public override bool IsConnected => EndPoints.Any();
    }
}
