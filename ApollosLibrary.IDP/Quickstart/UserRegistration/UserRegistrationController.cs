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

namespace ApollosLibrary.IDP.UserRegistration
{
    public class UserRegistrationController : Controller
    {
        private readonly IUserService _userService;
        private readonly IIdentityServerInteractionService _interactionService;

        public UserRegistrationController(IUserService userService, IIdentityServerInteractionService interactionService)
        {
            _userService = userService;
            _interactionService = interactionService;
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

            var userId = Guid.NewGuid();

            var user = new Domain.Model.User()
            {
                CreatedBy = userId,
                CreatedDate = DateTime.Now,
                IsActive = false,
                Subject = Guid.NewGuid().ToString(),
                UserId = userId,
                Username = model.Username,
                UserClaims = new List<Domain.Model.UserClaim>()
                {
                    new Domain.Model.UserClaim()
                    {
                        UserClaimId = Guid.NewGuid(),
                        Type = "sub",
                        Value = "UnpaidAccount",
                    },
                    new Domain.Model.UserClaim()
                    {
                        UserClaimId = Guid.NewGuid(),
                        Type = "emailaddress",
                        Value = model.Email,
                    }
                },
            };

            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var codeData = new byte[128];
                randomNumberGenerator.GetBytes(codeData);
                user.SecurityCode = Convert.ToBase64String(codeData);
            }

            user.SecurityCodeExpirationDate = DateTime.Now.AddHours(1);

            await _userService.AddUser(user, model.Password);

            MailMessage message = new MailMessage("noreply@apolloslibrary.com", model.Email);

            var link = Url.ActionLink("ActivateUser", "UserRegistration", new { securityCode = user.SecurityCode });

            string mailbody = $"Please click the following link to activate your account: <a href='/{link}'>{link}</a";
            message.Subject = "My Library Password Reset";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("127.0.0.1", 25); //smtp    
            //client.EnableSsl = true;
            client.UseDefaultCredentials = true;

            client.Send(message);

            Debug.WriteLine(link);

            return View("ActivationCodeSent");
        }

        [HttpGet]
        public async Task<IActionResult> ActivateUser(string securityCode)
        {
            if (await _userService.ActivateUser(securityCode))
            {
                ViewData["Message"] = "Your account was successfully activated.  " +
                    "Navigate to your client application to log in.";
            }
            else
            {
                ViewData["Message"] = "Your account couldn't be activated, " +
                    "please contact your administrator.";
            }

            return View();
        }
    }
}
