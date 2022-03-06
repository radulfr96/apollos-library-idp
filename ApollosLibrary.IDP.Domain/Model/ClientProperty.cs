using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientProperty
    {
        [Key]
        public int ClientPropertyId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
