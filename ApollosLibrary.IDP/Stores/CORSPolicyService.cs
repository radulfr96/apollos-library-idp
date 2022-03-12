using ApollosLibrary.IDP.Domain.Model;
using IdentityServer4.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Stores
{
    public class CORSPolicyService : ICorsPolicyService
    {
        private readonly ApollosLibraryIDPContext _context;

        public CORSPolicyService(ApollosLibraryIDPContext context)
        {
            _context = context;
        }

        public async Task<bool> IsOriginAllowedAsync(string origin)
        {
            var result = true;

            //var allowedOrigins = await _context.ClientCorsOrigins
            //                                .Select(o => o.Origin)
            //                                .Distinct()
            //                                .ToListAsync();
            //if (allowedOrigins.Any())
            //{
            //    result = allowedOrigins.Contains(origin);
            //}
            return result;
        }
    }
}
