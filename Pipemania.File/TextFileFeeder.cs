using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Pipemania.File
{
    public class TextFileFeeder : FileFeeder<IReadOnlyCollection<string>>
    {
        private readonly string _path;
        private readonly FileStream _fileStream;

        public TextFileFeeder(string path)
        {
            _path = path;
        }

        protected override async Task<IReadOnlyCollection<string>> ReadFile()
        {
            return await System.IO.File.ReadAllLinesAsync(_path);
        }
    }
}