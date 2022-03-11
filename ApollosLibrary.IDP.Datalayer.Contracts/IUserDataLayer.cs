using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.DataLayer.Contracts
{
    /// <summary>
    /// Used to handle data storage of users
    /// </summary>
    public interface IUserDataLayer
    {
        /// <summary>
        /// Used to get a user by their username
        /// </summary>
        /// <param name="username">The users username</param>
        /// <returns>The user with the username</returns>
        Task<Domain.Model.User> GetUserByUsername(string username);

        /// <summary>
        /// Used to get a user by their email
        /// </summary>
        /// <param name="email">The users email</param>
        /// <returns>The user with the email</returns>
        Task<Domain.Model.User> GetUserByEmail(string email);

        /// <summary>
        /// Used to get a user by their email without their claims
        /// </summary>
        /// <param name="email">the users email</param>
        /// <returns>The users record</returns>
        Task<Domain.Model.User> GetUserByEmailUserOnly(string email);

        /// <summary>
        /// Used to get a user by their id
        /// </summary>
        /// <param name="id">The id of the user to be retreived</param>
        /// <returns>The user with the id</returns>
        Task<Domain.Model.User> GetUser(Guid id);

        /// <summary>
        /// Retreives all users
        /// </summary>
        /// <returns>The list of users</returns>
        Task<List<Domain.Model.User>> GetUsers();

        /// <summary>
        /// Used to add a new user
        /// </summary>
        /// <param name="user">The user to be added</param>
        Task AddUser(Domain.Model.User user);

        Task<Domain.Model.User> GetUserBySubject(string subject);

        Task<List<Domain.Model.UserClaim>> GetUserClaimsBySubject(string subject);

        Task<Domain.Model.User> GetUserBySecurityCode(string securityCode);
    }
}
