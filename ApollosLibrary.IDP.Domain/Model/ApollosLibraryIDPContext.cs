using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

# nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApollosLibraryIDPContext : DbContext
    {
        public ApollosLibraryIDPContext(DbContextOptions<ApollosLibraryIDPContext> options) : base(options)
        {

        }
        public DbSet<ApiResource> ApiResources { get; set; }
        public DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }
        public DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }
        public DbSet<ApiResourceScope> ApiResourceScopes { get; set; }
        public DbSet<ApiResourceSecret> ApiResourceSecrets { get; set; }
        public DbSet<ApiScope> ApiScopes { get; set; }
        public DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }
        public DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientClaim> ClientClaims { get; set; }
        public DbSet<ClientCorsOrigin> ClientCorsOrigins { get; set; }
        public DbSet<ClientGrantType> ClientGrantTypes { get; set; }
        public DbSet<ClientIdPrestriction> ClientIdPrestrictions { get; set; }
        public DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }
        public DbSet<ClientProperty> ClientProperties { get; set; }
        public DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }
        public DbSet<ClientScope> ClientScopes { get; set; }
        public DbSet<ClientSecret> ClientSecrets { get; set; }
        public DbSet<DeviceCode> DeviceCodes { get; set; }
        public DbSet<IdentityResource> IdentityResources { get; set; }
        public DbSet<IdentityResourceClaim> IdentityResourceClaims { get; set; }
        public DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }
        public DbSet<PersistedGrant> PersistedGrants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserClaim> UserClaims { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var userId = Guid.Parse("e7f12974-73dd-48d6-aa79-95fe1ded101e");

            modelBuilder.Entity<User>().HasData(new User()
            {
                CreatedBy = userId,
                CreatedDate = LocalDateTime.FromDateTime(DateTime.Now),
                IsActive = true,
                Password = "AQAAAAEAACcQAAAAECY64tCZ5CSbcXzOp4NE6XAr1TB9wQ1zgMv6Sa49QGTmEftnFXzPMsBH+NB1cu5brw==",
                Subject = Guid.NewGuid().ToString(),
                UserId = userId,
                Username = "radulfr",
            });

            modelBuilder.Entity<UserClaim>().HasData(new List<UserClaim>()
            {
                new UserClaim()
                {
                    Type = "role",
                    UserId = userId,
                    Value = "administrator",
                    UserClaimId = Guid.NewGuid(),
                },
                new UserClaim()
                {
                    Type = "role",
                    UserId = userId,
                    Value = "moderator",
                    UserClaimId = Guid.NewGuid(),
                },
                new UserClaim()
                {
                    Type = "emailaddress",
                    UserId = userId,
                    Value = "wados.russell70@gmail.com",
                    UserClaimId = Guid.NewGuid(),
                },
            });

            modelBuilder.Entity<ApiResource>().HasData(new List<ApiResource>()
            {
                new ApiResource()
                {
                    AllowedAccessTokenSigningAlgorithms = null,
                    ApiResourceId = 1,
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "Open ID",
                    DisplayName = "Open ID",
                    Enabled = true,
                    Name = "openid",
                    NonEditable = false,
                    ShowInDiscoveryDocument = true,
                },
                new ApiResource()
                {
                    AllowedAccessTokenSigningAlgorithms = null,
                    ApiResourceId = 2,
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "Apollo's Library Website",
                    DisplayName = "Apollo's Library Website",
                    Enabled = true,
                    Name = "apolloslibrarywebsite",
                    NonEditable = false,
                    ShowInDiscoveryDocument = true,
                },
                new ApiResource()
                {
                    AllowedAccessTokenSigningAlgorithms = null,
                    ApiResourceId = 3,
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "API in the IDP app to manage users",
                    DisplayName = "User API",
                    Enabled = true,
                    Name = "IdentityServerApi",
                    NonEditable = false,
                    ShowInDiscoveryDocument = true,
                }
            });

            modelBuilder.Entity<ApiResourceClaim>().HasData(new List<ApiResourceClaim>()
            {
                new ApiResourceClaim()
                {
                    ApiResourceClaimId = 1,
                    Type = "role",
                    ApiResourceId = 1,
                },
                new ApiResourceClaim()
                {
                    ApiResourceClaimId = 2,
                    Type = "username",
                    ApiResourceId = 1,
                },
                new ApiResourceClaim()
                {
                    ApiResourceClaimId = 3,
                    Type = "emailaddress",
                    ApiResourceId = 1,
                }
            });

            modelBuilder.Entity<ApiScope>().HasData(new ApiScope()
            {
                ApiScopeId = 1,
                ShowInDiscoveryDocument = true,
                Description = "Provides access to the My Library Web API",
                DisplayName = "Apollo's Library API",
                Emphasize = false,
                Enabled = true,
                Name = "apolloslibraryapi",
                Required = true,
            }, new ApiScope()
            {
                ApiScopeId = 2,
                ShowInDiscoveryDocument = true,
                Description = "Provides access to the My Library User API in the IDP App",
                DisplayName = "Apollo's Library User API",
                Emphasize = false,
                Enabled = true,
                Name = "IdentityServerApi",
                Required = true,
            });

            modelBuilder.Entity<Client>().HasData(new Client()
            {
                AbsoluteRefreshTokenLifetime = 6000,
                AccessTokenLifetime = 6000,
                AccessTokenType = 0,
                AllowAccessTokensViaBrowser = true,
                AllowedIdentityTokenSigningAlgorithms = null,
                AllowOfflineAccess = true,
                AllowPlainTextPkce = false,
                AllowRememberConsent = false,
                AlwaysIncludeUserClaimsInIdToken = true,
                AlwaysSendClientClaims = true,
                AuthorizationCodeLifetime = 6000,
                BackChannelLogoutSessionRequired = true,
                BackChannelLogoutUri = null,
                ClientClaimsPrefix = null,
                ClientId = 1,
                ClientIdentifier = "apolloslibrarywebapp",
                ClientName = "Apollo's Library Web App",
                ClientUri = null,
                Created = LocalDateTime.FromDateTime(DateTime.Now),
                Description = "Apollo's Library Web App",
                DeviceCodeLifetime = 6000,
                Enabled = true,
                EnableLocalLogin = true,
                FrontChannelLogoutSessionRequired = true,
                IdentityTokenLifetime = 6000,
                IncludeJwtId = true,
                NonEditable = false,
                PairWiseSubjectSalt = null,
                ProtocolType = "oidc",
                RefreshTokenExpiration = "Sliding",
                RequireClientSecret = false,
                RefreshTokenUsage = "ReUse",
                RequireConsent = false,
                RequirePkce = true,
                RequireRequestObject = false,
                SlidingRefreshTokenLifetime = 6000,
                UpdateAccessTokenClaimsOnRefresh = true,
                UserCodeType = null,
                UserSsoLifetime = null,
            });

            modelBuilder.Entity<ClientGrantType>().HasData(new List<ClientGrantType>()
            {
                new ClientGrantType()
                {
                    ClientGrantTypeId = 1,
                    GrantType = "password",
                    ClientId = 1,
                },
                new ClientGrantType()
                {
                    ClientGrantTypeId = 2,
                    GrantType = "client_credentials",
                    ClientId = 1,
                },
                new ClientGrantType()
                {
                    ClientGrantTypeId = 3,
                    GrantType = "implicit",
                    ClientId = 1,
                },
                new ClientGrantType()
                {
                    ClientGrantTypeId = 4,
                    GrantType = "refresh_token",
                    ClientId = 1,
                },
            });

            modelBuilder.Entity<ClientCorsOrigin>().HasData(new List<ClientCorsOrigin>()
            {
                new ClientCorsOrigin()
                {
                    ClientCorsOriginId = 1,
                    ClientId = 1,
                    Origin = "http://localhost:3000"
                }
            });

            modelBuilder.Entity<ClientScope>().HasData(new List<ClientScope>()
            {
                new ClientScope()
                {
                    ClientScopeId = 1,
                    Scope = "openid",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 2,
                    Scope = "profile",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 3,
                    Scope = "apolloslibraryapi",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 4,
                    Scope = "role",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 5,
                    Scope = "username",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 6,
                    Scope = "email",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 7,
                    Scope = "offline_access",
                    ClientId = 1,
                },
                new ClientScope()
                {
                    ClientScopeId = 8,
                    Scope = "IdentityServerApi",
                    ClientId = 1,
                },
            });

            modelBuilder.Entity<ClientSecret>().HasData(new List<ClientSecret>()
            {
                new ClientSecret()
                {
                    ClientSecretId = 1,
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "apolloslibrarywebsite",
                    Expiration = null,
                    Type = "SharedSecret",
                    Value = "979eb386dc9a387d614b72902e44f5cb295636d71f829d2afccff401eb794bd6",
                    ClientId = 1,
                },
            });

            modelBuilder.Entity<ClientRedirectUri>().HasData(new ClientRedirectUri()
            {
                ClientId = 1,
                ClientRedirectUriId = 1,
                RedirectUri = "http://localhost:3000/callback"
            });

            modelBuilder.Entity<IdentityResource>().HasData(new List<IdentityResource>()
            {
                new IdentityResource()
                {
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "openid",
                    DisplayName = "Opend ID",
                    Emphasize = false,
                    Enabled = true,
                    IdentityResourceId = 1,
                    Name = "openid",
                    NonEditable = false,
                    Required = true,
                    ShowInDiscoveryDocument = true,
                },
                new IdentityResource()
                {
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "User claims",
                    DisplayName = "User Claims",
                    Emphasize = false,
                    Enabled = true,
                    IdentityResourceId = 2,
                    Name = "claims",
                    NonEditable = false,
                    Required = true,
                    ShowInDiscoveryDocument = true,
                },
                new IdentityResource()
                {
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "User Profile",
                    DisplayName = "User Profile",
                    Emphasize = false,
                    Enabled = true,
                    IdentityResourceId = 3,
                    Name = "profile",
                    NonEditable = false,
                    Required = true,
                    ShowInDiscoveryDocument = true,
                },
                new IdentityResource()
                {
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "Username",
                    DisplayName = "Username",
                    Emphasize = false,
                    Enabled = true,
                    IdentityResourceId = 4,
                    Name = "username",
                    NonEditable = false,
                    Required = true,
                    ShowInDiscoveryDocument = true,
                },
                new IdentityResource()
                {
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "User Role",
                    DisplayName = "User Role",
                    Emphasize = false,
                    Enabled = true,
                    IdentityResourceId = 5,
                    Name = "role",
                    NonEditable = false,
                    Required = true,
                    ShowInDiscoveryDocument = true,
                },
                new IdentityResource()
                {
                    Created = LocalDateTime.FromDateTime(DateTime.Now),
                    Description = "User Email",
                    DisplayName = "User Email",
                    Emphasize = false,
                    Enabled = true,
                    IdentityResourceId = 6,
                    Name = "emailaddress",
                    NonEditable = false,
                    Required = true,
                    ShowInDiscoveryDocument = true,
                },
            });
        }
    }
}
