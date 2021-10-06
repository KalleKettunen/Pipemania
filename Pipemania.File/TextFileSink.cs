using System;
using System.IO;
using System.Threading.Tasks;

namespace Pipemania.File
{
    public class TextFileSink : FileSink<string>, IDisposable
    {
        private StreamWriter _writer;

        public TextFileSink(string path)
        {
            _writer = new StreamWriter(path);
        }
        protected override async Task WriteToFile(string source)
        {
            await _writer.WriteLineAsync(source);
        }

        public override async Task SetReady()
        {
            await base.SetReady();
            await _writer.FlushAsync();
        }

        public async void Dispose()
        {
            await _writer.DisposeAsync();
        }
    }
}