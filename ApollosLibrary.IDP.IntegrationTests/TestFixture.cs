using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Respawn;
using System.IO;
using Microsoft.EntityFrameworkCore;
using ApollosLibrary.IDP.UnitOfWork;
using MediatR;
using Respawn.Graph;
using System.Reflection;
using ApollosLibrary.IDP.Domain.Model;
using ApollosLibrary.IDP.Application;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using ApollosLibrary.IDP.Application.User.Commands.DeleteUserCommand;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using ApollosLibrary.IDP.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace ApollosLibrary.IDP.IntegrationTests
{
    public class TestFixture : IDisposable
    {
        public IServiceCollection ServiceCollection { get; private set; }
        private readonly ApollosLibraryIDPContext _context;
        private readonly Configuration _configuration;

        public TestFixture()
        {
            var services = new ServiceCollection();

            var localConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _configuration = new Configuration();
            services.AddHttpContextAccessor();
            var connectionString = localConfig.GetSection("ConnectionString").Value;
            var conn = connectionString.Replace("{UniqueId}", DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss"));

            services.AddDbContext<ApollosLibraryIDPContext>(opt =>
            {
                opt.UseSqlServer(conn);
            });

            var provider = services.BuildServiceProvider();
            _context = provider.GetRequiredService<ApollosLibraryIDPContext>();

            _context.Database.EnsureCreated();

            services.AddTransient<IUserUnitOfWork>(p =>
            {
                return new UserUnitOfWork(p.GetRequiredService<ApollosLibraryIDPContext>());
            });

            services.AddSingleton<IUserService>(p =>
            {
                return new UserService(p.GetRequiredService<IHttpContextAccessor>(), new UserUnitOfWork(p.GetRequiredService<ApollosLibraryIDPContext>()), new PasswordHasher<User>());
            });

            localConfig.Bind(_configuration);

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(DeactivateUserCommandHandler).GetTypeInfo().Assembly);

            ServiceCollection = services;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
