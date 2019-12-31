using System;
using System.Collections.Generic;
using System.Text;

namespace Pipemania.Test.Utils
{
    public static class EndPointExtensions
    {
        public static IEndPoint<TSource> ToAssertingEndPoint<TSource>(this IEndPoint<TSource> endPoint,
            Action<TSource> assertion)
        {
            return new AssertingEndPointDecorator<TSource>(endPoint, assertion);
        }
    }
}
