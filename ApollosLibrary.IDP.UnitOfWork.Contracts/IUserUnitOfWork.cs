using ApollosLibrary.IDP.DataLayer;
using ApollosLibrary.IDP.DataLayer.Contracts;
using System;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.UnitOfWork.Contracts
{
    /// <summary>
    /// Used to perform units of work for users
    /// </summary>
    public interface IUserUnitOfWork
    {
        /// <summary>
        /// Data layer for users
        /// </summary>
        IUserDataLayer UserDataLayer { get; }

        /// <summary>
        /// Used to begin a transaction
        /// </summary>
        Task Begin();

        /// <summary>
        /// Used to save data changes
        /// </summary>
        Task Save();

        /// <summary>
        /// Used to commit changes
        /// </summary>
        Task Commit();
    }
}
