#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IDraftOrderServiceFactory : IServiceFactory<IDraftOrderService> { }

public class DraftOrderServiceFactory : IDraftOrderServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public DraftOrderServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IDraftOrderService Create(string shopDomain, string accessToken)
    {
        IDraftOrderService service = shopifyDomainUtility is null ? new DraftOrderService(shopDomain, accessToken) : new DraftOrderService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IDraftOrderService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IDraftOrderServiceFactory : IServiceFactory<IDraftOrderService>;

public class DraftOrderServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IDraftOrderServiceFactory
{
    /// <inheritDoc />
    public virtual IDraftOrderService Create(string shopDomain, string accessToken)
    {
        IDraftOrderService service = shopifyDomainUtility is null ? new DraftOrderService(shopDomain, accessToken) : new DraftOrderService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IDraftOrderService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif