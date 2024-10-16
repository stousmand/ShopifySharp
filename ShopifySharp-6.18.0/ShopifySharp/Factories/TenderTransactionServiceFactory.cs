#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface ITenderTransactionServiceFactory : IServiceFactory<ITenderTransactionService> { }

public class TenderTransactionServiceFactory : ITenderTransactionServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public TenderTransactionServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual ITenderTransactionService Create(string shopDomain, string accessToken)
    {
        ITenderTransactionService service = shopifyDomainUtility is null ? new TenderTransactionService(shopDomain, accessToken) : new TenderTransactionService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ITenderTransactionService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface ITenderTransactionServiceFactory : IServiceFactory<ITenderTransactionService>;

public class TenderTransactionServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : ITenderTransactionServiceFactory
{
    /// <inheritDoc />
    public virtual ITenderTransactionService Create(string shopDomain, string accessToken)
    {
        ITenderTransactionService service = shopifyDomainUtility is null ? new TenderTransactionService(shopDomain, accessToken) : new TenderTransactionService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ITenderTransactionService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif