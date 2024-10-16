#nullable enable
// Notice:
// This class is auto-generated from a template. Please do not edit it or change it directly.

using ShopifySharp.Credentials;
using ShopifySharp.Utilities;

namespace ShopifySharp.Factories;

#if NET7_0
public interface IScriptTagServiceFactory : IServiceFactory<IScriptTagService> { }

public class ScriptTagServiceFactory : IScriptTagServiceFactory
{
    public IRequestExecutionPolicy? requestExecutionPolicy;
    public IShopifyDomainUtility? shopifyDomainUtility;

    public ScriptTagServiceFactory(IRequestExecutionPolicy? _requestExecutionPolicy = null, IShopifyDomainUtility? _shopifyDomainUtility = null)
    {
        requestExecutionPolicy = _requestExecutionPolicy;
        shopifyDomainUtility = _shopifyDomainUtility;
    }

    /// <inheritDoc />
    public virtual IScriptTagService Create(string shopDomain, string accessToken)
    {
        IScriptTagService service = shopifyDomainUtility is null ? new ScriptTagService(shopDomain, accessToken) : new ScriptTagService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IScriptTagService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#else
public interface IScriptTagServiceFactory : IServiceFactory<IScriptTagService>;

public class ScriptTagServiceFactory(IRequestExecutionPolicy? requestExecutionPolicy = null, IShopifyDomainUtility? shopifyDomainUtility = null) : IScriptTagServiceFactory
{
    /// <inheritDoc />
    public virtual IScriptTagService Create(string shopDomain, string accessToken)
    {
        IScriptTagService service = shopifyDomainUtility is null ? new ScriptTagService(shopDomain, accessToken) : new ScriptTagService(shopDomain, accessToken, shopifyDomainUtility);

        if (requestExecutionPolicy is not null)
        {
            service.SetExecutionPolicy(requestExecutionPolicy);
        }

        return service;
    }

    /// <inheritDoc />
    public virtual IScriptTagService Create(ShopifyApiCredentials credentials) =>
        Create(credentials.ShopDomain, credentials.AccessToken);
}
#endif