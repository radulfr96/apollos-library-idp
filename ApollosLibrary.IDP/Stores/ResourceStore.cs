﻿using ApollosLibrary.IDP.Domain.Model;
using AutoMapper;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Stores
{
    public class ResourceStore : IResourceStore
    {
        private readonly ApollosLibraryIDPContext _context;
        private readonly IMapper _mapper;

        public ResourceStore(ApollosLibraryIDPContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            var apiResourceEntities = await _context.ApiResources.Where(a => apiResourceNames.Contains(a.Name)).ToListAsync();

            return _mapper.Map<List<Domain.Model.ApiResource>, List<IdentityServer4.Models.ApiResource>>(apiResourceEntities);
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var resourceIds = await _context.ApiResourceScopes.Where(a => scopeNames.Contains(a.Scope)).Select(a => a.ApiResourceId).Distinct().ToListAsync();

            var apiResourceEntities = await _context.ApiResources.Where(a => resourceIds.Contains(a.ApiResourceId)).ToListAsync();

            return _mapper.Map<List<Domain.Model.ApiResource>, List<IdentityServer4.Models.ApiResource>>(apiResourceEntities);
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            var apiScopes = await _context.ApiScopes.Where(a => scopeNames.Contains(a.Name)).ToListAsync();

            return _mapper.Map<List<Domain.Model.ApiScope>, List<IdentityServer4.Models.ApiScope>>(apiScopes);
        }

        public async Task<IEnumerable<IdentityServer4.Models.IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var identityResources = await _context.IdentityResources.Where(i => scopeNames.Contains(i.Name)).ToListAsync();

            return _mapper.Map<List<Domain.Model.IdentityResource>, List<IdentityServer4.Models.IdentityResource>>(identityResources);
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            var identityResources = await _context.IdentityResources.ToListAsync();

            var apiResources = await _context.ApiResources.ToListAsync();

            var apiScopes = await _context.ApiScopes.ToListAsync();

            return new Resources()
            {
                ApiResources = _mapper.Map<List<Domain.Model.ApiResource>, List<IdentityServer4.Models.ApiResource>>(apiResources),
                IdentityResources = _mapper.Map<List<Domain.Model.IdentityResource>, List<IdentityServer4.Models.IdentityResource>>(identityResources),
                ApiScopes = _mapper.Map<List<Domain.Model.ApiScope>, List<IdentityServer4.Models.ApiScope>>(apiScopes),
            };
        }
    }
}
