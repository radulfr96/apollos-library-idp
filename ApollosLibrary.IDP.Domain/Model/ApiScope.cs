using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiScope
    {
        [Key] 
        public int ApiScopeId { get; set; }
        public bool Enabled { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public bool Required { get; set; }
        public bool Emphasize { get; set; }
        public bool ShowInDiscoveryDocument { get; set; }

        public ICollection<ApiScopeClaim> ApiScopeClaims { get; set; }
        public ICollection<ApiScopeProperty> ApiScopeProperties { get; set; }
    }
}
