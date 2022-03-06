using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class ClientScope
    {
        [Key]
        public int ClientScopeId { get; set; }
        public string Scope { get; set; }
        public int ClientId { get; set; }

        public Client Client { get; set; }
    }
}
