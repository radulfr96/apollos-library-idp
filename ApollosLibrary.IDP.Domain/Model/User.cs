using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class User
    {
        [Key]
        public Guid UserId { get; set; }
        public string Subject { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public bool IsBanned { get; set; }
        public string SecurityCode { get; set; }
        public LocalDateTime? SecurityCodeExpirationDate { get; set; }
        public LocalDateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public LocalDateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }

        public ICollection<UserClaim> UserClaims { get; set; }
    }
}
