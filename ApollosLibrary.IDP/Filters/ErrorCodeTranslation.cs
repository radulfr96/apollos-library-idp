using ApollosLibrary.IDP.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApollosLibrary.WebApi.Filters
{
    public class ErrorCodeTranslation
    {
        private readonly static Dictionary<int, string> _errorCodes = new ();

        public static void Initialise()
        {
        }

        public static string  GetErrorMessageFromCode(int errorCodeID)
        {
            _errorCodes.TryGetValue(errorCodeID, out string message);
            return message;
        }
    }
}
