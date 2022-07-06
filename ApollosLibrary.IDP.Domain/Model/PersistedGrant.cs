using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class PersistedGrant
    {
        [Key]
        public string PersistedGrantKey { get; set; }
        public string Type { get; set; }
        public string SubjectId { get; set; }
        public string SessionId { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public LocalDateTime CreationTime { get; set; }
        public LocalDateTime? Expiration { get; set; }
        public LocalDateTime? ConsumedTime { get; set; }
        public string Data { get; set; }
    }
}
