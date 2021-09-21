using System.Threading.Tasks;
using Pipemania.Core;
using Pipemania.Test.Utils;
using Xunit;

namespace PipemaniaTests
{
    public class MaxAggregationTests
    {
        [Fact]
        public async Task ShouldReceiveLargest()
        {
            var max = new Max<int>();
            var feeder = new[] {1, 3, 45, 678, 2345, -1}.ToFeeder();
            var endpoint = new NullEndPoint<int>().ToAssertingEndPoint(
                i => Assert.Equal(1, i),
                i => Assert.Equal(3, i),
                i => Assert.Equal(45, i),
                i => Assert.Equal(678, i),
                i => Assert.Equal(2345, i),
                i => Assert.Equal(2345, i));

            feeder
                .Connect(max)
                .Connect(endpoint);
            
            await feeder.Feed();
            
            Assert.True(endpoint.Received);
        }
        
    }
}