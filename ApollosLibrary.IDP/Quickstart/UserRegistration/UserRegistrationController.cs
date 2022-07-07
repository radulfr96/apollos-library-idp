using IdentityServer4.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

using ApollosLibrary.IDP.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net.Mail;
using System.Text;
using Microsoft.Extensions.Configuration;
using NodaTime;
using ApollosLibrary.IDP.Application.Interfaces;

namespace ApollosLibrary.IDP.UserRegistration
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly IEmailService _emailService;

        public UserRegistrationController(
            IUserService userService
            , IIdentityServerInteractionService interactionService
            , IConfiguration config
            , IEmailService emailService)
        {
            _config = config;
            _userService = userService;
            _interactionService = interactionService;
            _emailService = emailService;
        }

        [HttpGet]
        public IActionResult RegisterUser(string returnUrl)
        {
            var vm = new RegisterUserViewModel()
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var existingUser = await _userService.GetUserByUsername(model.Username);

            if (existingUser != null)
            {
                ModelState.AddModelError("username", "Username is not unique please try another");
                return View(model);
            }

            existingUser = await _userService.GetUserByEmail(model.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError("email", "Email is not unique please try another");
                return View(model);
            }

            var userId = Guid.NewGuid();

            var user = new Domain.Model.User()
            {
                CreatedBy = userId,
                CreatedDate = LocalDateTime.FromDateTime(DateTime.Now),
                IsActive = false,
                Subject = Guid.NewGuid().ToString(),
                UserId = userId,
                Username = model.Username,
                UserClaims = new List<Domain.Model.UserClaim>()
                {
                    new Domain.Model.UserClaim()
                    {
                        UserClaimId = Guid.NewGuid(),
                        Type = "emailaddress",
                        Value = model.Email,
                    },
                    new Domain.Model.UserClaim()
                    {
                        UserClaimId = Guid.NewGuid(),
                        Type = "role",
                        Value = "standarduser"
                    }
                },
            };

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var codeData = new byte[128];
                randomNumberGenerator.GetBytes(codeData);
                user.SecurityCode = Convert.ToBase64String(codeData);
            }

            user.SecurityCodeExpirationDate = LocalDateTime.FromDateTime(DateTime.Now.AddHours(1));

            await _userService.AddUser(user, model.Password);

            MailMessage message = new MailMessage("noreply@apolloslibrary.com", model.Email);

            var link = Url.ActionLink("ActivateUser", "UserRegistration", new { securityCode = user.SecurityCode });

            string mailbody = $"Please click the following link to activate your account: <a href='/{link}'>{link}</a";
            await _emailService.SendEmail("noreply@apolloslibrary.com", model.Email, "My Library Password Reset", mailbody);

            return View("ActivationCodeSent");
        }

        [HttpGet]
        public async Task<IActionResult> ActivateUser(string securityCode)
        {
            if (await _userService.ActivateUser(securityCode))
            {
                ViewData["Message"] = "Your account was successfully activated.  ";
            }
            else
            {
                ViewData["Message"] = "Your account couldn't be activated, " +
                    "please contact your administrator.";
            }

            ViewBag.FrontEndURL = _config.GetValue<string>("FrontEndURL");

            return View();
        }
    }
}
