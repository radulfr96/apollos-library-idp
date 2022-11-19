// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
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
using ApollosLibrary.IDP.Domain.Model;
using ApollosLibrary.IDP.Interfaces;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using ApollosLibrary.IDP.Application.User.Queries.GetUserQuery;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using ApollosLibrary.IDP.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using IdentityServer4;
using ApollosLibrary.IDP.Filters;
using ApollosLibrary.IDP.Application.Interfaces;
using ApollosLibrary.IDP.Infrastructure.Services;
using System.Security.Cryptography.X509Certificates;
using System;
using Azure.Identity;
using Azure.Security.KeyVault.Certificates;

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
            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(GetUserQuery).GetTypeInfo().Assembly);
            services.AddSingleton<IDateTimeService, DateTimeService>();

            services.AddDbContext<ApollosLibraryIDPContext>(options => options.UseNpgsql(Configuration["db-idp"], o => o.UseNodaTime()));
            services.AddScoped<DbContext, ApollosLibraryIDPContext>();
            services.AddScoped<IEmailService, SendGridEmailService>();
            services.AddScoped<ApiExceptionFilterAttribute>();
            services.AddScoped<AdministratorFilterAttribute>();

            services.AddScoped<IUserService>(provider =>
            {
                return new UserService(provider.GetRequiredService<IHttpContextAccessor>(), new UserUnitOfWork(provider.GetRequiredService<ApollosLibraryIDPContext>()), new PasswordHasher<Domain.Model.User>());
            });

            services.AddScoped<IMapper>(opt =>
            {
                return new Mapper(AutoMapper.Configuration());
            });

            services.AddTransient<IUserUnitOfWork, UserUnitOfWork>();
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            services.AddLocalApiAuthentication();

            var client = new CertificateClient(new Uri(Configuration["KEY_VAULT"]), new DefaultAzureCredential());
            X509Certificate2 certificate = client.DownloadCertificate("TokenCertificate");

            var builder = services.AddIdentityServer(options =>
            {
                // see https://identityserver4.readthedocs.io/en/latest/topics/resources.html
                options.EmitStaticAudienceClaim = true;
            })
            .AddSigningCredential(certificate);

            builder
                .AddResourceStore<ResourceStore>()
                .AddClientStore<ClientStore>()
                .AddDeviceFlowStore<DeviceFlowStore>()
                .AddPersistedGrantStore<PersistedGrantStore>()
                .AddProfileService<ProfileService>()
                .AddCorsPolicyService<CORSPolicyService>();

            services.AddSwaggerGen(c =>
            {
                // configure SwaggerDoc and others

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });
        }

        public void Configure(IApplicationBuilder app, DbContext dbContext)
        {
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            dbContext.Database.Migrate();

            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseIdentityServer();

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllers();
            });
        }
    }
}
