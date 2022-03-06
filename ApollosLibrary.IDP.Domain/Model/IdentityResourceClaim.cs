using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class IdentityResourceClaim
    {
        [Key]
        public int IdentityResourceClaimId { get; set; }
        public string Type { get; set; }
        public int IdentityResourceId { get; set; }

        public IdentityResource IdentityResource { get; set; }
    }
}
