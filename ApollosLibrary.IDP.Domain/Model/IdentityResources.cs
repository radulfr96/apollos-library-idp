using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class IdentityResources
    {
        [Key]
        public int IdentityResourcesId { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }
        public LocalDateTime Created { get; set; }
        public LocalDateTime? Updated { get; set; }
        public bool NonEditable { get; set; }

        public ICollection<IdentityResourceClaim> IdentityResourceClaims { get; set; }
        public ICollection<IdentityResourceProperty> IdentityResourceProperties { get; set; }
    }
}
