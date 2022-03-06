using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
