using System.Threading.Tasks;
using Pipemania.Core;
using Pipemania.Test.Utils;
using Xunit;

namespace PipemaniaTests
{
    public class TaskFeederTests
    {
        [Fact]
        public async Task ShouldFeedWhenTaskIsCompleted()
        {
            var feeder = Task.Run(async () =>
            {
                await Task.Delay(100);
                return 1;
            }).ToFeeder();

            await feeder.ConnectAssertingEndpoint(i => Assert.Equal(1, i)).Feed();
        }
        
    }
}