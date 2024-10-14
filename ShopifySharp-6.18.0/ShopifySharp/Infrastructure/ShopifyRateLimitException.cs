#nullable enable
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using ShopifySharp.Infrastructure;

namespace ShopifySharp;

#if NET7_0
/// An exception thrown when an API call has reached Shopify's rate limit.
public class ShopifyRateLimitException : ShopifyHttpException
{
    public readonly int? RetryAfterSeconds;

    //When a 429 is returned because the bucket is full, Shopify doesn't include the X-Shopify-Shop-Api-Call-Limit header in the response
    public readonly ShopifyRateLimitReason Reason;

    public ShopifyRateLimitException(string requestInfo, HttpStatusCode statusCode, ICollection<string> errors, string message,
                                        string rawResponseBody, string? requestId, ShopifyRateLimitReason reason, int? retryAfterSeconds) : base(requestInfo, statusCode, errors, message, rawResponseBody, requestId)
    {
        RetryAfterSeconds = retryAfterSeconds;
        Reason = reason;
    }
}
#else
/// An exception thrown when an API call has reached Shopify's rate limit.
public class ShopifyRateLimitException(
    string requestInfo,
    HttpStatusCode statusCode,
    ICollection<string> errors,
    string message,
    string rawResponseBody,
    string? requestId,
    ShopifyRateLimitReason reason,
    int? retryAfterSeconds)
    : ShopifyHttpException(requestInfo,  statusCode, errors, message, rawResponseBody, requestId)
{
    public readonly int? RetryAfterSeconds = retryAfterSeconds;

    //When a 429 is returned because the bucket is full, Shopify doesn't include the X-Shopify-Shop-Api-Call-Limit header in the response
    public readonly ShopifyRateLimitReason Reason = reason;
}
#endif