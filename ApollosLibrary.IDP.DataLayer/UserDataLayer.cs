using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Domain.Model;
using ApollosLibrary.IDP.DataLayer.Contracts;
using NodaTime;

namespace ApollosLibrary.IDP.DataLayer
{
    public class UserDataLayer : IUserDataLayer
    {
        private ApollosLibraryIDPContext _context;

        public UserDataLayer(ApollosLibraryIDPContext context)
        {
            _context = context;
        }

        public async Task AddUser(Domain.Model.User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<Domain.Model.User> GetUser(Guid id)
        {
            return await _context.Users
                                 .Include(u => u.UserClaims)
                                 .FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<List<Domain.Model.User>> GetUsers()
        {
            return await _context.Users
                    .Include(u => u.UserClaims)
                    .ToListAsync();
        }

        public async Task<Domain.Model.User> GetUserBySubject(string subject)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Subject == subject);
        }

        public async Task<Domain.Model.User> GetUserByUsername(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (user != null)
            {
                user.UserClaims = await _context.UserClaims.Where(u => u.UserId == user.UserId).ToListAsync();
                user.UserClaims.Add(new UserClaim() { User = user, Value = username, Type = "username" });
                user.UserClaims.Add(new UserClaim() { User = user, Value = user.UserId.ToString(), Type = "userid" });
            }

            return user;
        }

        public async Task<Domain.Model.User> GetUserByEmail(string email)
        {
            var emailClaim = await _context.UserClaims.Where(u => u.Value == email && u.Type == "emailaddress").FirstOrDefaultAsync();

            if (emailClaim == null)
                return null;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == emailClaim.UserId);

            if (user != null)
            {
                user.UserClaims = await _context.UserClaims.Where(u => u.UserId == user.UserId).ToListAsync();
                user.UserClaims.Add(new UserClaim() { User = user, Value = user.Username, Type = "username" });
                user.UserClaims.Add(new UserClaim() { User = user, Value = user.UserId.ToString(), Type = "userid" });
            }

            return user;
        }

        public async Task<Domain.Model.User> GetUserByEmailUserOnly(string email)
        {
            var emailClaim = await _context.UserClaims.Where(u => u.Value == email && u.Type == "emailaddress").FirstOrDefaultAsync();

            if (emailClaim == null)
                return null;

            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId == emailClaim.UserId);

            return user;
        }

        public async Task<List<UserClaim>> GetUserClaimsBySubject(string subject)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Subject == subject);

            if (user == null)
                return new List<UserClaim>();

            var claims = await _context.UserClaims.Where(u => u.User.Subject == subject).ToListAsync();
            claims.Add(new UserClaim() { User = user, Value = user.Username, Type = "username" });
            claims.Add(new UserClaim() { User = user, Value = user.UserId.ToString(), Type = "userid" });

            return claims;
        }

        public async Task<Domain.Model.User> GetUserBySecurityCode(string securityCode)
        {
            var currentDate = LocalDateTime.FromDateTime(DateTime.Now);

            return await _context.Users.FirstOrDefaultAsync(u => u.SecurityCode == securityCode && u.SecurityCodeExpirationDate >= currentDate);
        }
    }
}