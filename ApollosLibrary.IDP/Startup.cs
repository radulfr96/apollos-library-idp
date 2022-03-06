﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using AutoMapper;
using IdentityServerHost.Quickstart.UI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using ApollosLibrary.IDP.Services;
using ApollosLibrary.IDP.Stores;
using ApollosLibrary.IDP.UnitOfWork;
using System.Reflection;
using MediatR;
using ApollosLibrary.IDP.User.Queries.GetUserQuery;
using ApollosLibrary.IDP.Domain.Model;

namespace ApollosLibrary.IDP
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public IWebHostEnvironment Environment { get; }

        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // uncomment, if you want to add an MVC-based UI
            services.AddControllersWithViews();

            services.AddMediatR(typeof(GetUserQuery).GetTypeInfo().Assembly);

            services.AddDbContext<ApollosLibraryIDPContext>(options => options.UseSqlServer(Configuration.GetSection("ConnectionString").Value));
            var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;

            services.AddScoped<IUserService>(provider =>
            {
                return new UserService(new UserUnitOfWork(provider.GetRequiredService<ApollosLibraryIDPContext>()), new PasswordHasher<Domain.Model.User>());
            });

            services.AddScoped<IMapper>(opt =>
            {
                return new Mapper(AutoMapper.Configuration());
            });

            services.AddTransient<IUserUnitOfWork, UserUnitOfWork>();

            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            });

            // not recommended for production - you need to store your key material somewhere secure
            builder.AddDeveloperSigningCredential();

            builder
                .AddResourceStore<ResourceStore>()
                .AddClientStore<ClientStore>()
                .AddDeviceFlowStore<DeviceFlowStore>()
                .AddPersistedGrantStore<PersistedGrantStore>()
                .AddProfileService<ProfileService>();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseCors(options =>
            {
                options
                .AllowAnyOrigin()
                .AllowAnyHeader();
            });

            app.UseIdentityServer();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
