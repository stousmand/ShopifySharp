#nullable enable
using System;
using System.Transactions;
using ShopifySharp.Infrastructure.Policies.ExponentialRetry;

namespace ShopifySharp;

[Serializable]
#if NET7_0
public class ShopifyExponentialRetryCanceledException : ShopifyException
{
    public int CurrentTry { get; }
    public int BackoffInMilliseconds { get; }
    public int? MaximumRetries { get; }
    public TimeSpan? MaximumDelayBeforeTimeout { get; }

    public ShopifyExponentialRetryCanceledException(int currentTry, ExponentialRetryPolicyOptions options, Exception? innerException = null) 
        : base("Exponential Retry Policy request was canceled.", innerException)
    {
        CurrentTry = currentTry;
        BackoffInMilliseconds = options.InitialBackoffInMilliseconds;
        MaximumRetries = options.MaximumRetriesBeforeRequestCancellation;
        MaximumDelayBeforeTimeout = options.MaximumDelayBeforeRequestCancellation;
    }
}
#else
public class ShopifyExponentialRetryCanceledException(
    int currentTry,
    ExponentialRetryPolicyOptions options,
    Exception? innerException = null
) : ShopifyException("Exponential Retry Policy request was canceled.", innerException)
{
    public int CurrentTry { get; } = currentTry;
    public int BackoffInMilliseconds { get; } = options.InitialBackoffInMilliseconds;
    public int? MaximumRetries { get; } = options.MaximumRetriesBeforeRequestCancellation;
    public TimeSpan? MaximumDelayBeforeTimeout { get; } = options.MaximumDelayBeforeRequestCancellation;
}
#endif
