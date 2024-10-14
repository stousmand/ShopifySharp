#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IPriceRuleServiceFactory : IServiceFactory<IPriceRuleService> { }

public class PriceRuleServiceFactory : IPriceRuleServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public PriceRuleServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IPriceRuleService Create(string shopDomain, string accessToken)
    {
        IPriceRuleService service = shopifyDomainUtility is null ? new PriceRuleService(shopDomain, accessToken) : new PriceRuleService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IPriceRuleService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IPriceRuleServiceFactory : IServiceFactory<IPriceRuleService>;

public class PriceRuleServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IPriceRuleServiceFactory
{
    /// <inheritDoc />
    public virtual IPriceRuleService Create(string shopDomain, string accessToken)
    {
        IPriceRuleService service = shopifyDomainUtility is null ? new PriceRuleService(shopDomain, accessToken) : new PriceRuleService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IPriceRuleService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif