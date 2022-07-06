using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public bool Enabled { get; set; }
        public string ClientIdentifier { get; set; }
        public string ProtocolType { get; set; }
        public bool RequireClientSecret { get; set; }
        public string ClientName { get; set; }
        public string Description { get; set; }
        public string ClientUri { get; set; }
        public string LogoUri { get; set; }
        public bool RequireConsent { get; set; }
        public bool AllowRememberConsent { get; set; }
        public bool AlwaysIncludeUserClaimsInIdToken { get; set; }
        public bool RequirePkce { get; set; }
        public bool AllowPlainTextPkce { get; set; }
        public bool RequireRequestObject { get; set; }
        public bool AllowAccessTokensViaBrowser { get; set; }
        public string FrontChannelLogoutUri { get; set; }
        public bool FrontChannelLogoutSessionRequired { get; set; }
        public string BackChannelLogoutUri { get; set; }
        public bool BackChannelLogoutSessionRequired { get; set; }
        public bool AllowOfflineAccess { get; set; }
        public int IdentityTokenLifetime { get; set; }
        public string AllowedIdentityTokenSigningAlgorithms { get; set; }
        public int AccessTokenLifetime { get; set; }
        public int AuthorizationCodeLifetime { get; set; }
        public int? ConsentLifetime { get; set; }
        public int AbsoluteRefreshTokenLifetime { get; set; }
        public int SlidingRefreshTokenLifetime { get; set; }
        public string RefreshTokenUsage { get; set; }
        public bool UpdateAccessTokenClaimsOnRefresh { get; set; }
        public string RefreshTokenExpiration { get; set; }
        public int AccessTokenType { get; set; }
        public bool EnableLocalLogin { get; set; }
        public bool IncludeJwtId { get; set; }
        public bool AlwaysSendClientClaims { get; set; }
        public string ClientClaimsPrefix { get; set; }
        public string PairWiseSubjectSalt { get; set; }
        public LocalDateTime Created { get; set; }
        public LocalDateTime? Updated { get; set; }
        public LocalDateTime? LastAccessed { get; set; }
        public int? UserSsoLifetime { get; set; }
        public string UserCodeType { get; set; }
        public int DeviceCodeLifetime { get; set; }
        public bool NonEditable { get; set; }

        public ICollection<ClientClaim> ClientClaims { get; set; }
        public ICollection<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public ICollection<ClientGrantType> ClientGrantTypes { get; set; }
        public ICollection<ClientIdPrestriction> ClientIdPrestrictions { get; set; }
        public ICollection<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public ICollection<ClientProperty> ClientProperties { get; set; }
        public ICollection<ClientRedirectUri> ClientRedirectUris { get; set; }
        public ICollection<ClientScope> ClientScopes { get; set; }
        public ICollection<ClientSecret> ClientSecrets { get; set; }
    }
}
