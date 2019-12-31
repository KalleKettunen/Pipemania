using System;
using System.Threading.Tasks;
using Pipemania.Core;
using Pipemania.Test.Utils;
using Xunit;

namespace PipemaniaTests
{
    public class FunctionMapperTests
    {
        [Fact]
        public async Task ShouldCallFunction()
        {
            var capitalizer = new FunctionMapper<string, string>(s => s.ToUpper());
            var feeder = new string[] {"foo"}.ToFeeder();
            feeder.Connect(capitalizer).Connect(new NullEndPoint<string>().ToAssertingEndPoint(s => Assert.Equal("FOO", s)));

            await feeder.Feed();
        }
    }
}
