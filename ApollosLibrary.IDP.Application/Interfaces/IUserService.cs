using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Infrastructure.Interfaces
{
    public interface IUserService
    {
        Task<Domain.Model.User> GetUserByUsername(string username);

        Task<Domain.Model.User> GetUserByEmail(string username);

        Task<bool> ValidateCredentials(string username, string password);

        Task<List<Domain.Model.UserClaim>> GetUserClaimsBySubject(string subject);

        Guid GetUserId();

        Task<bool> IsUserActive(string subject);

        Task<bool> ActivateUser(string securityCode);

        Task AddUser(Domain.Model.User user, string password);

        Task<string> InitiatePasswordResetRequest(string email);

        Task<bool> SetPassword(string securityCode, string password);

    }
}
