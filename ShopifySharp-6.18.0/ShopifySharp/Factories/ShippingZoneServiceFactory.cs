#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IShippingZoneServiceFactory : IServiceFactory<IShippingZoneService> { }

public class ShippingZoneServiceFactory : IShippingZoneServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public ShippingZoneServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IShippingZoneService Create(string shopDomain, string accessToken)
    {
        IShippingZoneService service = shopifyDomainUtility is null ? new ShippingZoneService(shopDomain, accessToken) : new ShippingZoneService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IShippingZoneService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IShippingZoneServiceFactory : IServiceFactory<IShippingZoneService>;

public class ShippingZoneServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IShippingZoneServiceFactory
{
    /// <inheritDoc />
    public virtual IShippingZoneService Create(string shopDomain, string accessToken)
    {
        IShippingZoneService service = shopifyDomainUtility is null ? new ShippingZoneService(shopDomain, accessToken) : new ShippingZoneService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IShippingZoneService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif