using ApollosLibrary.IDP.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Infrastructure.Services
{
    public class SendGridEmailService : IEmailService
    {
        private readonly SendGridClient _client;
        private readonly IConfiguration _configuration;

        public SendGridEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
            var apiKey = _configuration.GetRequiredSection("SendGridKey").Value;
            _client = new SendGridClient(apiKey);
        }

        public async Task SendEmail(string from, string to, string subject, string htmlContent, string plainTextContent = null)
        {
            if (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")?.ToLower() != "production")
            {
                to = _configuration.GetRequiredSection("AdminEmail").Value;
            }

            var msg = MailHelper.CreateSingleEmail(new EmailAddress(from), new EmailAddress(to), subject, plainTextContent, htmlContent);
            var response = await _client.SendEmailAsync(msg);
        }
    }
}
