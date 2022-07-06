using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientSecret
    {
        [Key]
        public int ClientSecretId { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }
        public LocalDateTime? Expiration { get; set; }
        public string Type { get; set; }
        public LocalDateTime Created { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
