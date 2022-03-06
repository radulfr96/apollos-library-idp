using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace ApollosLibrary.IDP.Domain.Model
{
    public class DeviceCode
    {
        [Key]
        public string DeviceCodeId { get; set; }
        public string UserCode { get; set; }
        public string SubjectId { get; set; }
        public string SessionId { get; set; }
        public string ClientId { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime Expiration { get; set; }
        public string Data { get; set; }
    }
}
