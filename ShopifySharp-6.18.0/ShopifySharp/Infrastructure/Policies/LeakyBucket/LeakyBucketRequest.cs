using System;
using System.Threading;

namespace ShopifySharp.Infrastructure.Policies.LeakyBucket;

#if NET7_0
internal sealed class LeakyBucketRequest : IDisposable
{
    public readonly int Cost;
    public readonly SemaphoreSlim Semaphore = new(0, 1);
    public readonly CancellationToken CancellationToken;

    public LeakyBucketRequest(int _cost, CancellationToken _cancellationToken)
    {
        Cost = _cost;
        CancellationToken = _cancellationToken;
    }

    public void Dispose()
    {
        Semaphore?.Dispose();
    }
}
#else
internal sealed class LeakyBucketRequest(int cost, CancellationToken cancellationToken) : IDisposable
{
    public readonly int Cost = cost;
    public readonly SemaphoreSlim Semaphore = new(0, 1);
    public readonly CancellationToken CancellationToken = cancellationToken;

    public void Dispose()
    {
        Semaphore?.Dispose();
    }
}
#endif