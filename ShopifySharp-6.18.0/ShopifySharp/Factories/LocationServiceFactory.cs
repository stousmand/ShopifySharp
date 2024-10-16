#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface ILocationServiceFactory : IServiceFactory<ILocationService> { }

public class LocationServiceFactory : ILocationServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public LocationServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual ILocationService Create(string shopDomain, string accessToken)
    {
        ILocationService service = shopifyDomainUtility is null ? new LocationService(shopDomain, accessToken) : new LocationService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ILocationService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}

#else
public interface ILocationServiceFactory : IServiceFactory<ILocationService>;

public class LocationServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : ILocationServiceFactory
{
    /// <inheritDoc />
    public virtual ILocationService Create(string shopDomain, string accessToken)
    {
        ILocationService service = shopifyDomainUtility is null ? new LocationService(shopDomain, accessToken) : new LocationService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ILocationService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif