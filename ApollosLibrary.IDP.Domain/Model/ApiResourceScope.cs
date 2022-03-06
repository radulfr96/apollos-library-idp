using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiResourceScope
    {
        [Key]
        public int ApiResourceScopeId { get; set; }
        public string Scope { get; set; }
        public int ApiResourceId { get; set; }

        public ApiResource ApiResource { get; set; }
    }
}
