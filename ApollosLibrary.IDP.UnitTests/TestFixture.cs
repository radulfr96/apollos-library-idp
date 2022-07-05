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

namespace ApollosLibrary.IDP.Application.UnitTests
{
    public class TestFixture
    {
        public IServiceCollection ServiceCollection { get; private set; }
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
            services.AddDbContext<ApollosLibraryIDPContext>(opt =>
            {
                opt.UseInMemoryDatabase("ApollosLibraryTestIDPDB");
            });

            services.AddTransient<IUserUnitOfWork>(p => {
                return new UserUnitOfWork(p.GetRequiredService<ApollosLibraryIDPContext>());
            });

            localConfig.Bind(_configuration);

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(DeactivateUserCommandHandler).GetTypeInfo().Assembly);

            ServiceCollection = services;
        }

        public Configuration Configuration
        {
            get
            {
                return _configuration;
            }
        }
    }
}
