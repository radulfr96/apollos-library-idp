using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientCorsOrigin
    {
        [Key]
        public int ClientCorsOriginId { get; set; }
        public string Origin { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
