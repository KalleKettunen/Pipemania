using System.Collections.Generic;
using System.Threading.Tasks;
using Pipemania.Core;
using Xunit;

namespace PipemaniaTests
{
    public class AsyncEnumerableDecoratorTests
    {
        [Fact]
        public async Task Test()
        {
            var source = new[] {1, 2, 3, 4, 5, 6, 7};
            var feeder = source.ToFeeder();

            var endpoint = new AsyncEnumerableDecorator<int>(new NullEndPoint<int>());

            feeder.Connect(endpoint);

            var resultList = new List<int>();

            var feedTask = feeder.Feed();
            await foreach (var val in endpoint)
            {
                resultList.Add(val);
            }


            await feedTask;
            

            Assert.Equal(source, resultList);
        }
    }
}