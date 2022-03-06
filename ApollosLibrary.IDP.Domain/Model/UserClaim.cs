using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class UserClaim
    {
        [Key]
        public Guid UserClaimId { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
