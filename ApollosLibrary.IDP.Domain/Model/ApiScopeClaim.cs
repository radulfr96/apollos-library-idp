using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiScopeClaim
    {
        [Key]
        public int ApiScopeClaimId { get; set; }
        public string Type { get; set; }

        public int ScopeId { get; set; }
        public ApiScope Scope { get; set; }
    }
}
