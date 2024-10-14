#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IFulfillmentServiceServiceFactory : IServiceFactory<IFulfillmentServiceService> { }

public class FulfillmentServiceServiceFactory : IFulfillmentServiceServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;
    
    public FulfillmentServiceServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }
    /// <inheritDoc />
    public virtual IFulfillmentServiceService Create(string shopDomain, string accessToken)
    {
        IFulfillmentServiceService service = shopifyDomainUtility is null ? new FulfillmentServiceService(shopDomain, accessToken) : new FulfillmentServiceService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IFulfillmentServiceService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IFulfillmentServiceServiceFactory : IServiceFactory<IFulfillmentServiceService>;

public class FulfillmentServiceServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IFulfillmentServiceServiceFactory
{
    /// <inheritDoc />
    public virtual IFulfillmentServiceService Create(string shopDomain, string accessToken)
    {
        IFulfillmentServiceService service = shopifyDomainUtility is null ? new FulfillmentServiceService(shopDomain, accessToken) : new FulfillmentServiceService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IFulfillmentServiceService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif