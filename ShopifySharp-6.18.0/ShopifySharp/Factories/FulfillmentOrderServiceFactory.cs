#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IFulfillmentOrderServiceFactory : IServiceFactory<IFulfillmentOrderService> { }

public class FulfillmentOrderServiceFactory : IFulfillmentOrderServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;
    
    public FulfillmentOrderServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IFulfillmentOrderService Create(string shopDomain, string accessToken)
    {
        IFulfillmentOrderService service = shopifyDomainUtility is null ? new FulfillmentOrderService(shopDomain, accessToken) : new FulfillmentOrderService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IFulfillmentOrderService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IFulfillmentOrderServiceFactory : IServiceFactory<IFulfillmentOrderService>;

public class FulfillmentOrderServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IFulfillmentOrderServiceFactory
{
    /// <inheritDoc />
    public virtual IFulfillmentOrderService Create(string shopDomain, string accessToken)
    {
        IFulfillmentOrderService service = shopifyDomainUtility is null ? new FulfillmentOrderService(shopDomain, accessToken) : new FulfillmentOrderService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IFulfillmentOrderService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif