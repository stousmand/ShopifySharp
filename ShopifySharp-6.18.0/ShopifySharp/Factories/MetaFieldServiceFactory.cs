#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IMetaFieldServiceFactory : IServiceFactory<IMetaFieldService> { }

public class MetaFieldServiceFactory : IMetaFieldServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;
    
    public MetaFieldServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IMetaFieldService Create(string shopDomain, string accessToken)
    {
        IMetaFieldService service = shopifyDomainUtility is null ? new MetaFieldService(shopDomain, accessToken) : new MetaFieldService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IMetaFieldService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IMetaFieldServiceFactory : IServiceFactory<IMetaFieldService>;

public class MetaFieldServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IMetaFieldServiceFactory
{
    /// <inheritDoc />
    public virtual IMetaFieldService Create(string shopDomain, string accessToken)
    {
        IMetaFieldService service = shopifyDomainUtility is null ? new MetaFieldService(shopDomain, accessToken) : new MetaFieldService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IMetaFieldService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif