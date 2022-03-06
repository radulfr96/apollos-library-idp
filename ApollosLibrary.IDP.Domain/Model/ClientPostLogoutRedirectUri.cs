using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientPostLogoutRedirectUri
    {
        [Key]
        public int ClientPostLogoutRedirectUriId { get; set; }
        public string PostLogoutRedirectUri { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
