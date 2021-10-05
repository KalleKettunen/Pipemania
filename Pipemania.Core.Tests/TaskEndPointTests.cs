using System.Threading.Tasks;
using Pipemania.Core;
using Xunit;

namespace PipemaniaTests
{
    public class TaskEndPointTests
    {
        [Fact]
        public async Task GetsResultFromTask()
        {
            var feeder = new[] {1}.ToFeeder();

            var endpoint = new TaskEndPointDecorator<int>(new NullEndPoint<int>());

            feeder.Connect(endpoint);
            
            var result = endpoint.GetValue();

            await feeder.Feed();
            
            Assert.Equal(1, await result);

        }
    }
}