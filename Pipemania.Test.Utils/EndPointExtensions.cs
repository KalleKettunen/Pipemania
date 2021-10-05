using System;
using System.Collections.Generic;
using System.Text;
using Pipemania.Core;
using Pipemania.Core.Interfaces;

namespace Pipemania.Test.Utils
{
    public static class EndPointExtensions
    {
        public static AssertingEndPointDecorator<TSource> ToAssertingEndPoint<TSource>(this IEndPoint<TSource> endPoint,
            params Action<TSource>[] assertion)
        {
            return new AssertingEndPointDecorator<TSource>(endPoint, assertion);
        }

        public static IFeeder ConnectAssertingEndpoint<T>(this Feeder<T> feeder, params Action<T>[] assertions)
        {
            feeder.Connect(new NullEndPoint<T>().ToAssertingEndPoint(assertions));
            return feeder;
        }
    }
}
