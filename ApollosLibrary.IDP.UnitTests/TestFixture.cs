﻿using Microsoft.Extensions.DependencyInjection;
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
using ApollosLibrary.IDP.User.Commands.DeleteUserCommand;
using Respawn.Graph;
using System.Reflection;
using ApollosLibrary.IDP.Domain.Model;

namespace ApollosLibrary.IDP.UnitTests
{
    public class TestFixture
    {
        public IServiceCollection ServiceCollection { get; private set; }
        private readonly ApollosLibraryIDPContext _context;
        private readonly Configuration _configuration;
        private readonly Checkpoint _checkpoint;

        public TestFixture()
        {
            var services = new ServiceCollection();

            var localConfig = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            _configuration = new Configuration();

            var optionsBuilder = new DbContextOptionsBuilder<ApollosLibraryIDPContext>();
            optionsBuilder.UseSqlServer(localConfig.GetSection("ConnectionString").Value);

            services.AddHttpContextAccessor();
            services.AddDbContext<ApollosLibraryIDPContext>(opt =>
            {
                opt.UseSqlServer(localConfig.GetSection("ConnectionString").Value);
            });
            _context = new ApollosLibraryIDPContext(optionsBuilder.Options);

            services.AddTransient<IUserUnitOfWork>(p => {
                return new UserUnitOfWork(p.GetRequiredService<ApollosLibraryIDPContext>());
            });

            localConfig.Bind(_configuration);

            services.AddHttpContextAccessor();

            services.AddMediatR(typeof(DeleteUserCommandHandler).GetTypeInfo().Assembly);

            _checkpoint = new Checkpoint
            {
                SchemasToInclude = new string[] { "Author", "Book", "Genre", "Publisher" },
                TablesToInclude = new Table[] { "Author", "Book", "Genre", "BookAuthor", "BookGenre", "Publisher" },
            };

            ServiceCollection = services;
        }

        public Configuration Configuration
        {
            get
            {
                return _configuration;
            }
        }

        public void ResetCheckpoint()
        {
            _checkpoint.Reset(_configuration.ConnectionString).Wait();
        }
    }
}
