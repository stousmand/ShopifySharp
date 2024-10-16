#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface ICheckoutServiceFactory : IServiceFactory<ICheckoutService> { }

public class CheckoutServiceFactory : ICheckoutServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public CheckoutServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual ICheckoutService Create(string shopDomain, string accessToken)
    {
        ICheckoutService service = shopifyDomainUtility is null ? new CheckoutService(shopDomain, accessToken) : new CheckoutService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICheckoutService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}

#else
public interface ICheckoutServiceFactory : IServiceFactory<ICheckoutService>;

public class CheckoutServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : ICheckoutServiceFactory
{
    /// <inheritDoc />
    public virtual ICheckoutService Create(string shopDomain, string accessToken)
    {
        ICheckoutService service = shopifyDomainUtility is null ? new CheckoutService(shopDomain, accessToken) : new CheckoutService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICheckoutService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif