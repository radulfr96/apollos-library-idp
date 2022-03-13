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
            origin = origin.ToLowerInvariant();

            var query = from o in _context.ClientCorsOrigins
                        where o.Origin == origin
                        select o;

            var isAllowed = await query.AnyAsync();

            return isAllowed;
        }
    }
}
