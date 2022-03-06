using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientGrantType
    {
        [Key]
        public int ClientGrantTypeId { get; set; }
        public string GrantType { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
