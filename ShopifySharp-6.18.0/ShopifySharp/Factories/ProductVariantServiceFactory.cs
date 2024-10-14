#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IProductVariantServiceFactory : IServiceFactory<IProductVariantService> { }

public class ProductVariantServiceFactory : IProductVariantServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public ProductVariantServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }
    /// <inheritDoc />
    public virtual IProductVariantService Create(string shopDomain, string accessToken)
    {
        IProductVariantService service = shopifyDomainUtility is null ? new ProductVariantService(shopDomain, accessToken) : new ProductVariantService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IProductVariantService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IProductVariantServiceFactory : IServiceFactory<IProductVariantService>;

public class ProductVariantServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IProductVariantServiceFactory
{
    /// <inheritDoc />
    public virtual IProductVariantService Create(string shopDomain, string accessToken)
    {
        IProductVariantService service = shopifyDomainUtility is null ? new ProductVariantService(shopDomain, accessToken) : new ProductVariantService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IProductVariantService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif