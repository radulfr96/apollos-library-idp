using System;
using System.Collections.Generic;

namespace ApollosLibrary.IDP.Application.DTOs
{

    #nullable disable

    /// <summary>
    /// Data transfer object used to transfer users
    /// </summary>
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string IsActive { get; set; }
        public string Email { get; set; }
        public string IsBanned { get; set; }

        public UserDTO()
        {
        }
    }
}
