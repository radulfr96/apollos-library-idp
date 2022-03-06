using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class IdentityResource
    {
        [Key]
        public int IdentityResourceId { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool NonEditable { get; set; }

        public ICollection<IdentityResourceClaim> IdentityResourceClaims { get; set; }
        public ICollection<IdentityResourceProperty> IdentityResourceProperties { get; set; }
    }
}
