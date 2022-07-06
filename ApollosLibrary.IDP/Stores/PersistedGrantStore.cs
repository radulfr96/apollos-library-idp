using ApollosLibrary.IDP.Domain.Model;
using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Stores
{
    public class PersistedGrantStore : IPersistedGrantStore
    {
        private readonly ApollosLibraryIDPContext _context;
        private readonly IMapper _mapper;

        public PersistedGrantStore(ApollosLibraryIDPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdentityServer4.Models.PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            var grants = await _context.PersistedGrants.Where(g =>
                (string.IsNullOrEmpty(filter.SubjectId) || g.SubjectId == filter.SubjectId)
                && (string.IsNullOrEmpty(filter.SessionId) || g.SessionId == filter.SessionId)
                && (string.IsNullOrEmpty(filter.ClientId) || g.ClientId == filter.ClientId)
                && (string.IsNullOrEmpty(filter.Type) || g.Type == filter.Type)
            ).ToListAsync();


            return _mapper.Map<List<Domain.Model.PersistedGrant>, List<IdentityServer4.Models.PersistedGrant>>(grants);
        }

        public async Task<IdentityServer4.Models.PersistedGrant> GetAsync(string key)
        {
            var grant = await _context.PersistedGrants.FirstOrDefaultAsync();

            return _mapper.Map<IdentityServer4.Models.PersistedGrant>(grant);
        }

        public async Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            var grants = await _context.PersistedGrants.Where(g =>
                (string.IsNullOrEmpty(filter.SubjectId) || g.SubjectId == filter.SubjectId)
                && (string.IsNullOrEmpty(filter.SessionId) || g.SessionId == filter.SessionId)
                && (string.IsNullOrEmpty(filter.ClientId) || g.ClientId == filter.ClientId)
                && (string.IsNullOrEmpty(filter.Type) || g.Type == filter.Type)
            ).ToListAsync();

            _context.RemoveRange(grants);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(string key)
        {
            var grant = await _context.PersistedGrants.FirstOrDefaultAsync();

            _context.Remove(grant);
            await _context.SaveChangesAsync();
        }

        public async Task StoreAsync(IdentityServer4.Models.PersistedGrant grant)
        {
            await _context.AddAsync(new Domain.Model.PersistedGrant()
            {
                ClientId = grant.ClientId,
                ConsumedTime = LocalDateTime.FromDateTime(grant.ConsumedTime.Value),
                CreationTime = LocalDateTime.FromDateTime(grant.CreationTime),
                Data = grant.Data,
                Description = grant.Description,
                Expiration = LocalDateTime.FromDateTime(grant.Expiration.Value),
                PersistedGrantKey = grant.Key,
                SessionId = grant.SessionId,
                SubjectId = grant.SubjectId,
                Type = grant.Type,
            });
            await _context.SaveChangesAsync();
        }
    }
}
