using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ApiResourceProperty
    {
        [Key]
        public int ApiResourcePropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ApiResourceId { get; set; }

        public ApiResource ApiResource { get; set; }
    }
}
