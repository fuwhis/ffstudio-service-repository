using System;

namespace FFStudioServices.Exceptions
{
    public class CommonException : Exception
    {
        public CommonException(int statusCode, object? value = null) =>
            (StatusCode, Value) = (statusCode, value);

        public int StatusCode { get; }

        public object? Value { get; }
    }
}
