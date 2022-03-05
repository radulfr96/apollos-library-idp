﻿using ApollosLibrary.IDP.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.DataLayer
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
        Task<Model.User> GetUserByUsername(string username);

        /// <summary>
        /// Used to get a user by their email
        /// </summary>
        /// <param name="email">The users email</param>
        /// <returns>The user with the email</returns>
        Task<Model.User> GetUserByEmail(string email);

        /// <summary>
        /// Used to get a user by their email without their claims
        /// </summary>
        /// <param name="email">the users email</param>
        /// <returns>The users record</returns>
        Task<Model.User> GetUserByEmailUserOnly(string email);

        /// <summary>
        /// Used to get a user by their id
        /// </summary>
        /// <param name="id">The id of the user to be retreived</param>
        /// <returns>The user with the id</returns>
        Task<Model.User> GetUser(Guid id);

        /// <summary>
        /// Retreives all users
        /// </summary>
        /// <returns>The list of users</returns>
        Task<List<Model.User>> GetUsers();

        /// <summary>
        /// Used to add a new user
        /// </summary>
        /// <param name="user">The user to be added</param>
        Task AddUser(Model.User user);

        Task<Model.User> GetUserBySubject(string subject);

        Task<List<UserClaim>> GetUserClaimsBySubject(string subject);

        Task<Model.User> GetUserBySecurityCode(string securityCode);
    }
}
