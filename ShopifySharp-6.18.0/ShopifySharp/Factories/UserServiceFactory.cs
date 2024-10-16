#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IUserServiceFactory : IServiceFactory<IUserService> { }

public class UserServiceFactory: IUserServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public UserServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IUserService Create(string shopDomain, string accessToken)
    {
        IUserService service = shopifyDomainUtility is null ? new UserService(shopDomain, accessToken) : new UserService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IUserService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IUserServiceFactory : IServiceFactory<IUserService>;

public class UserServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IUserServiceFactory
{
    /// <inheritDoc />
    public virtual IUserService Create(string shopDomain, string accessToken)
    {
        IUserService service = shopifyDomainUtility is null ? new UserService(shopDomain, accessToken) : new UserService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IUserService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif
