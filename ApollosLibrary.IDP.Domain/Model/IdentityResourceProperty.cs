using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class IdentityResourceProperty
    {
        [Key]
        public int IdentityResourcePropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int IdentityResourceId { get; set; }

        public IdentityResource IdentityResource { get; set; }
    }
}
