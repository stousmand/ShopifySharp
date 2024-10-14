#nullable enable

namespace ShopifySharp;

#if NET7_0
public class AuthorizationResult
{
    public string AccessToken { get; }
    public string[]? GrantedScopes { get; }

    public AuthorizationResult(string accessToken, string[]? grantedScopes)
    {
        AccessToken = accessToken;
        GrantedScopes = grantedScopes;
    }
}
#else
public class AuthorizationResult(string accessToken, string[]? grantedScopes)
{
    public string AccessToken { get; } = accessToken;
    public string[]? GrantedScopes { get; } = grantedScopes;
}
#endif