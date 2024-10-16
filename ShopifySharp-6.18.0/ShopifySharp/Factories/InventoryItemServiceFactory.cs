#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IInventoryItemServiceFactory : IServiceFactory<IInventoryItemService> { }

public class InventoryItemServiceFactory : IInventoryItemServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public InventoryItemServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }
    /// <inheritDoc />
    public virtual IInventoryItemService Create(string shopDomain, string accessToken)
        {
            IInventoryItemService service = shopifyDomainUtility is null ? new InventoryItemService(shopDomain, accessToken) : new InventoryItemService(shopDomain, accessToken, shopifyDomainUtility);

            if (requestExecutionPolicy is not null)
            {
                service.SetExecutionPolicy(requestExecutionPolicy);
            }

            return service;
        }

    /// <inheritDoc />
    public virtual IInventoryItemService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IInventoryItemServiceFactory : IServiceFactory<IInventoryItemService>;

public class InventoryItemServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IInventoryItemServiceFactory
{
    /// <inheritDoc />
    public virtual IInventoryItemService Create(string shopDomain, string accessToken)
    {
        IInventoryItemService service = shopifyDomainUtility is null ? new InventoryItemService(shopDomain, accessToken) : new InventoryItemService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IInventoryItemService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif