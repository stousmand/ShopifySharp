#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IFulfillmentRequestServiceFactory : IServiceFactory<IFulfillmentRequestService> { }

public class FulfillmentRequestServiceFactory : IFulfillmentRequestServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public FulfillmentRequestServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IFulfillmentRequestService Create(string shopDomain, string accessToken)
    {
        IFulfillmentRequestService service = shopifyDomainUtility is null ? new FulfillmentRequestService(shopDomain, accessToken) : new FulfillmentRequestService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IFulfillmentRequestService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IFulfillmentRequestServiceFactory : IServiceFactory<IFulfillmentRequestService>;

public class FulfillmentRequestServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IFulfillmentRequestServiceFactory
{
    /// <inheritDoc />
    public virtual IFulfillmentRequestService Create(string shopDomain, string accessToken)
    {
        IFulfillmentRequestService service = shopifyDomainUtility is null ? new FulfillmentRequestService(shopDomain, accessToken) : new FulfillmentRequestService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IFulfillmentRequestService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif