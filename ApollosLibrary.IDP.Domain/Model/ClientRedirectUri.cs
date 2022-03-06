using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientRedirectUri
    {
        [Key]
        public int ClientRedirectUriId { get; set; }
        public string RedirectUri { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
