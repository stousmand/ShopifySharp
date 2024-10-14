#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface ISmartCollectionServiceFactory : IServiceFactory<ISmartCollectionService> { }

public class SmartCollectionServiceFactory : ISmartCollectionServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;
    
    public SmartCollectionServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }
    /// <inheritDoc />
    public virtual ISmartCollectionService Create(string shopDomain, string accessToken)
    {
        ISmartCollectionService service = shopifyDomainUtility is null ? new SmartCollectionService(shopDomain, accessToken) : new SmartCollectionService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ISmartCollectionService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface ISmartCollectionServiceFactory : IServiceFactory<ISmartCollectionService>;

public class SmartCollectionServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : ISmartCollectionServiceFactory
{
    /// <inheritDoc />
    public virtual ISmartCollectionService Create(string shopDomain, string accessToken)
    {
        ISmartCollectionService service = shopifyDomainUtility is null ? new SmartCollectionService(shopDomain, accessToken) : new SmartCollectionService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ISmartCollectionService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif