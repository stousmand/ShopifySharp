#nullable enable
using System;
using System.Diagnostics;

namespace ShopifySharp;

#if NET7_0
public class ShopifyException : Exception
{
    public string message { get; }
    public Exception? innerException { get; }

    public ShopifyException(string _message, Exception? _innerException = null)
    {
        message = _message ?? string.Empty;
        innerException = _innerException;
    }
}
#else
    public class ShopifyException(string message, Exception? innerException = null) : Exception(message, innerException);
#endif