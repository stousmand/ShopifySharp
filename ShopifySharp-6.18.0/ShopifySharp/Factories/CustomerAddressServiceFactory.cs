#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface ICustomerAddressServiceFactory : IServiceFactory<ICustomerAddressService> { }

public class CustomerAddressServiceFactory : ICustomerAddressServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public CustomerAddressServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual ICustomerAddressService Create(string shopDomain, string accessToken)
    {
        ICustomerAddressService service = shopifyDomainUtility is null ? new CustomerAddressService(shopDomain, accessToken) : new CustomerAddressService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICustomerAddressService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface ICustomerAddressServiceFactory : IServiceFactory<ICustomerAddressService>;

public class CustomerAddressServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : ICustomerAddressServiceFactory
{
    /// <inheritDoc />
    public virtual ICustomerAddressService Create(string shopDomain, string accessToken)
    {
        ICustomerAddressService service = shopifyDomainUtility is null ? new CustomerAddressService(shopDomain, accessToken) : new CustomerAddressService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual ICustomerAddressService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif