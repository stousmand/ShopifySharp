#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IGiftCardAdjustmentServiceFactory : IServiceFactory<IGiftCardAdjustmentService> { }

public class GiftCardAdjustmentServiceFactory : IGiftCardAdjustmentServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public GiftCardAdjustmentServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IGiftCardAdjustmentService Create(string shopDomain, string accessToken)
    {
        IGiftCardAdjustmentService service = shopifyDomainUtility is null ? new GiftCardAdjustmentService(shopDomain, accessToken) : new GiftCardAdjustmentService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IGiftCardAdjustmentService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IGiftCardAdjustmentServiceFactory : IServiceFactory<IGiftCardAdjustmentService>;

public class GiftCardAdjustmentServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IGiftCardAdjustmentServiceFactory
{
    /// <inheritDoc />
    public virtual IGiftCardAdjustmentService Create(string shopDomain, string accessToken)
    {
        IGiftCardAdjustmentService service = shopifyDomainUtility is null ? new GiftCardAdjustmentService(shopDomain, accessToken) : new GiftCardAdjustmentService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IGiftCardAdjustmentService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif