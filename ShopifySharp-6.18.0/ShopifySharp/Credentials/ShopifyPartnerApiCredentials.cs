#if NETSTANDARD2_0
#else
#nullable enable
#endif

using System;

namespace ShopifySharp.Credentials;

#if NET7_0
public readonly struct ShopifyPartnerApiCredentials
{
    public long PartnerOrganizationId { get; }
    public string AccessToken { get; }

    public ShopifyPartnerApiCredentials(long partnerOrganizationId, string accessToken)
    {
        PartnerOrganizationId = partnerOrganizationId;
        AccessToken = accessToken;
    }
#else
public readonly struct ShopifyPartnerApiCredentials(long partnerOrganizationId, string accessToken)
{
    public long PartnerOrganizationId { get; } = partnerOrganizationId;
    public string AccessToken { get; } = accessToken;
#endif

#if NETSTANDARD2_0
        public override bool Equals(object obj)
        {
            return obj is ShopifyPartnerApiCredentials other
                && PartnerOrganizationId == other.PartnerOrganizationId
                && AccessToken == other.AccessToken;
        }
#else
    public override bool Equals(object? obj)
    {
        return obj is ShopifyPartnerApiCredentials other
               && PartnerOrganizationId == other.PartnerOrganizationId
               && AccessToken == other.AccessToken;
    }
#endif

    public override int GetHashCode()
    {
#if NETSTANDARD2_0
            return (PartnerOrganizationId, AccessToken).GetHashCode();
#else
        return HashCode.Combine(PartnerOrganizationId, AccessToken);
#endif
    }

    public static bool operator ==(ShopifyPartnerApiCredentials left, ShopifyPartnerApiCredentials right)
    {
        return left.Equals(right);
    }

    public static bool operator !=(ShopifyPartnerApiCredentials left, ShopifyPartnerApiCredentials right)
    {
        return !(left == right);
    }
}