using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiScopeProperty
    {
        [Key]
        public int ApiScopePropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public int ScopeId { get; set; }
        public ApiScope Scope { get; set; }
    }
}
