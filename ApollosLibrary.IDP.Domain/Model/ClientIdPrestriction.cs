using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientIdPrestriction
    {
        [Key]
        public int ClientIdPrestrictionId { get; set; }
        public string Provider { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
