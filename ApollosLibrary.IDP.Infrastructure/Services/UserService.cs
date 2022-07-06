using ApollosLibrary.IDP.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using NodaTime;

namespace ApollosLibrary.IDP.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IUserUnitOfWork _unitOfWork;
        private readonly IPasswordHasher<Domain.Model.User> _passwordHasher;
        private readonly HttpContext _httpContext;

        public UserService(IHttpContextAccessor httpContextAccessor, IUserUnitOfWork unitOfWork, IPasswordHasher<Domain.Model.User> passwordHasher)
        {
            _unitOfWork = unitOfWork;
            _passwordHasher = passwordHasher;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public Guid GetUserId()
        {
            return Guid.Parse(_httpContext.User.Claims.FirstOrDefault(c => c.Type == "userid").Value);
        }

        public async Task<Domain.Model.User> GetUserByUsername(string username)
        {
            return await _unitOfWork.UserDataLayer.GetUserByUsername(username);
        }

        public async Task<Domain.Model.User> GetUserByEmail(string email)
        {
            return await _unitOfWork.UserDataLayer.GetUserByEmail(email);
        }

        public async Task<bool> ValidateCredentials(string email, string password)
        {
            var result = false;

            var user = await GetUserByEmail(email);

            if (user == null)
                return result;

            if ((!user.IsActive) || user.IsBanned)
                return result;

            result = _passwordHasher.VerifyHashedPassword(user, user.Password, password) == PasswordVerificationResult.Success;

            return result;
        }

        public async Task<List<Domain.Model.UserClaim>> GetUserClaimsBySubject(string subject)
        {
            return await _unitOfWork.UserDataLayer.GetUserClaimsBySubject(subject);
        }

        public async Task<bool> IsUserActive(string subject)
        {
            var user = await GetUserBySubject(subject);

            if (user == null)
            {
                return false;
            }

            return user.IsActive;
        }

        public async Task<Domain.Model.User> GetUserBySubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentNullException(nameof(subject));
            }

            return await _unitOfWork.UserDataLayer.GetUserBySubject(subject);
        }

        public async Task AddUser(Domain.Model.User user, string password)
        {
            user.Password = _passwordHasher.HashPassword(user, password);
            await _unitOfWork.UserDataLayer.AddUser(user);
            await _unitOfWork.Save();
        }

        public async Task<bool> ActivateUser(string securityCode)
        {
            var user = await _unitOfWork.UserDataLayer.GetUserBySecurityCode(securityCode);

            if (user == null)
            {
                return false;
            }

            user.IsActive = true;
            user.SecurityCode = null;

            await _unitOfWork.Save();

            return true;
        }

        public async Task<string> InitiatePasswordResetRequest(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            var user = await _unitOfWork.UserDataLayer.GetUserByEmailUserOnly(email);

            if (user == null)
            {
                throw new Exception($"User with email address {email} can't be found.");
            }

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var securityCodeData = new byte[128];
                randomNumberGenerator.GetBytes(securityCodeData);
                user.SecurityCode = Convert.ToBase64String(securityCodeData);
            }

            user.SecurityCodeExpirationDate = LocalDateTime.FromDateTime(DateTime.Now.AddHours(1));

            await _unitOfWork.Save();
            return user.SecurityCode;
        }

        public async Task<bool> SetPassword(string securityCode, string password)
        {
            if (string.IsNullOrWhiteSpace(securityCode))
            {
                throw new ArgumentNullException(nameof(securityCode));
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            var user = await _unitOfWork.UserDataLayer.GetUserBySecurityCode(securityCode);

            if (user == null)
            {
                return false;
            }

            if (!user.IsActive)
            {
                user.IsActive = true;
            }

            user.SecurityCode = null;
            // hash & salt the password
            user.Password = _passwordHasher.HashPassword(user, password);

            await _unitOfWork.Save();
            return true;

        }
    }
}
