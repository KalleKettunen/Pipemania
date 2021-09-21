using System;
using System.Collections.Generic;
using System.Text;

namespace Pipemania.Test.Utils
{
    public static class EndPointExtensions
    {
        public static AssertingEndPointDecorator<TSource> ToAssertingEndPoint<TSource>(this IEndPoint<TSource> endPoint,
            params Action<TSource>[] assertion)
        {
            return new AssertingEndPointDecorator<TSource>(endPoint, assertion);
        }
    }
}
