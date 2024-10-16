#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IRecurringChargeServiceFactory : IServiceFactory<IRecurringChargeService> { }

public class RecurringChargeServiceFactory : IRecurringChargeServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public RecurringChargeServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IRecurringChargeService Create(string shopDomain, string accessToken)
    {
        IRecurringChargeService service = shopifyDomainUtility is null ? new RecurringChargeService(shopDomain, accessToken) : new RecurringChargeService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IRecurringChargeService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IRecurringChargeServiceFactory : IServiceFactory<IRecurringChargeService>;

public class RecurringChargeServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IRecurringChargeServiceFactory
{
    /// <inheritDoc />
    public virtual IRecurringChargeService Create(string shopDomain, string accessToken)
    {
        IRecurringChargeService service = shopifyDomainUtility is null ? new RecurringChargeService(shopDomain, accessToken) : new RecurringChargeService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IRecurringChargeService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif