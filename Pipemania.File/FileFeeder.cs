using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Pipemania.Core.Interfaces;

namespace Pipemania.File
{
    public abstract class FileFeeder<TSource> : BatchFeeder<TSource>
    {
        public override async Task Feed()
        {
            if (!Ready)
            {
                await Task.WhenAll(EndPoints.Select((async endpoint => endpoint.Receive((await ReadFile())))));
                Ready = true;
            }
        }

        protected abstract Task<TSource> ReadFile();
    }
}