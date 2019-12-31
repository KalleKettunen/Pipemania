using System;
using System.Threading.Tasks;

namespace Pipemania
{
    public interface IPipe : IDisposable
    {
        void Open();
        void Close();

        Task Pipe { get; }
    }

    public interface IPipe<T> : IPipe
    {
        ISource<T> Source { get; }
        IEndPoint<T> EndPoint { get; }
    }
}
