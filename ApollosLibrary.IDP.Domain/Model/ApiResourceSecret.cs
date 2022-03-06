using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiResourceSecret
    {
        [Key]
        public int ApiResourceSecretId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public DateTime? Expiration { get; set; }
        public string Type { get; set; }
        public DateTime Created { get; set; }
        public int ApiResourceId { get; set; }

        public ApiResource ApiResource { get; set; }
    }
}
