using Microsoft.AspNetCore.Mvc;
using ApollosLibrary.IDP.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using ApollosLibrary.IDP.Application.Interfaces;

namespace ApollosLibrary.IDP.PasswordReset
{
    public class PasswordResetController : Controller
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        private readonly IEmailService _emailService;

        public PasswordResetController(IUserService userService, IConfiguration config, IEmailService emailService)
        {
            _emailService = emailService;
            _userService = userService;
            _config = config;
        }

        [HttpGet]
        public IActionResult RequestPasswordReset()
        {
            var vm = new PasswordResetRequestViewModel();
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> RequestPasswordReset(PasswordResetRequestViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var securityCode = await _userService.InitiatePasswordResetRequest(model.Email);

            var link = $"{HttpContext.Request.Host.Host}{Url.Action("ResetPassword", "PasswordReset", new { securityCode })}";
            string mailbody = $"Please click the following link to reset your password: <a href='/{link}'>{link}</a";
            await _emailService.SendEmail("noreply@apolloslibrary.com", model.Email, "Apollo's Library Password Reset", mailbody);

            return View("PasswordResetRequestSent");
        }

        [HttpGet]
        public IActionResult ResetPassword(string securityCode)
        {
            var vm = new ResetPasswordViewModel()
            {
                SecurityCode = securityCode
            };
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await _userService.SetPassword(model.SecurityCode, model.Password))
            {
                var frontEndURL = _config.GetValue<string>("FrontEndURL");

                ViewData["Message"] = "Your password was successfully changed.  " +
                    "Click <a href=\"" + frontEndURL + "\">here<a/> to return to the homepage";
            }
            else
            {
                ViewData["Message"] = "Your password couldn't be changed, please" +
                    " contact your administrator.";
            }

            return View("ResetPasswordResult");
        }
    }
}
