using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(string from, string to, string subject, string htmlContent, string plainTextContent = null);
    }
}
