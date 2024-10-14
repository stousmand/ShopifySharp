#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using System;
using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
[Obsolete("https://shopify.dev/changelog/deprecation-notice-country-and-province-endpoints-in-admin-rest-api")]
public interface ICountryServiceFactory : IServiceFactory<ICountryService> { }

[Obsolete("https://shopify.dev/changelog/deprecation-notice-country-and-province-endpoints-in-admin-rest-api")]
public class CountryServiceFactory : ICountryServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public CountryServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual ICountryService Create(string shopDomain, string accessToken)
    {
        ICountryService service = shopifyDomainUtility is null ? new CountryService(shopDomain, accessToken) : new CountryService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICountryService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
[Obsolete("https://shopify.dev/changelog/deprecation-notice-country-and-province-endpoints-in-admin-rest-api")]
public interface ICountryServiceFactory : IServiceFactory<ICountryService>;

[Obsolete("https://shopify.dev/changelog/deprecation-notice-country-and-province-endpoints-in-admin-rest-api")]
public class CountryServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : ICountryServiceFactory
{
    /// <inheritDoc />
    public virtual ICountryService Create(string shopDomain, string accessToken)
    {
        ICountryService service = shopifyDomainUtility is null ? new CountryService(shopDomain, accessToken) : new CountryService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICountryService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif