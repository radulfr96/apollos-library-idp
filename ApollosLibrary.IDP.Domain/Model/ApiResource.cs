using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiResource
    {
        [Key]
        public int ApiResourceId { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string AllowedAccessTokenSigningAlgorithms { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public LocalDateTime Created { get; set; }
        public LocalDateTime? Updated { get; set; }
        public LocalDateTime? LastAccessed { get; set; }
        public bool NonEditable { get; set; }

        public ICollection<ApiResourceClaim> ApiResourceClaims { get; set; }
        public ICollection<ApiResourceProperty> ApiResourceProperties { get; set; }
        public ICollection<ApiResourceScope> ApiResourceScopes { get; set; }
        public ICollection<ApiResourceSecret> ApiResourceSecrets { get; set; }
    }
}
