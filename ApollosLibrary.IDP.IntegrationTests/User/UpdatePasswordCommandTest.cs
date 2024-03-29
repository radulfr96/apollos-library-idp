﻿using Bogus;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using ApollosLibrary.IDP.Domain.Model;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using ApollosLibrary.IDP.Application.User.Commands.UpdatePasswordCommand;
using Microsoft.EntityFrameworkCore;
using NodaTime;

namespace ApollosLibrary.IDP.IntegrationTests
{
    [Collection("IntegrationTestCollection")]
    public class UpdatePasswordCommandTest : TestBase
    {
        private readonly IDateTimeService _dateTime;
        private readonly ApollosLibraryIDPContext _context;
        private readonly IMediator _mediatr;
        private readonly IHttpContextAccessor _contextAccessor;

        public UpdatePasswordCommandTest(TestFixture fixture) : base(fixture)
        {
            var services = fixture.ServiceCollection;

            var mockDateTimeService = new Mock<IDateTimeService>();
            mockDateTimeService.Setup(d => d.Now).Returns(LocalDateTime.FromDateTime(new DateTime(2021, 02, 07)));
            _dateTime = mockDateTimeService.Object;
            services.AddSingleton(mockDateTimeService.Object);

            var provider = services.BuildServiceProvider();
            _mediatr = provider.GetRequiredService<IMediator>();
            _context = provider.GetRequiredService<ApollosLibraryIDPContext>();
            _contextAccessor = provider.GetRequiredService<IHttpContextAccessor>();
        }

        [Fact]
        public async Task WhenUpdatePassword_PasswordUpdated()
        {
            var userID = Guid.NewGuid();

            var httpContext = new TestHttpContext
            {
                User = new TestPrincipal(new Claim[]
                {
                    new Claim("userid", userID.ToString()),
                })
            };

            _contextAccessor.HttpContext = httpContext;

            var password = new Faker().Random.AlphaNumeric(50);

            var hasher = new PasswordHasher<Domain.Model.User>();
            var user = new User()
            {
                CreatedBy = userID,
                CreatedDate = LocalDateTime.FromDateTime(DateTime.Parse("2021-01-02")),
                IsActive = true,
                Subject = Guid.NewGuid().ToString(),
                UserId = userID,
                Username = new Faker().Internet.UserName(),
            };
            var oldPasswordHash = hasher.HashPassword(user, password);
            user.Password = oldPasswordHash;

            var conn = _context.Database.GetDbConnection();
            _context.Users.Add(user);
            _context.SaveChanges();

            var savedUser = _context.Users.FirstOrDefault(p => p.UserId == userID);

            var newPassword = new Faker().Random.AlphaNumeric(50);

            var command = new UpdatePasswordCommand()
            {
                CurrentPassword = password,
                NewPassword = newPassword,
            };

            await _mediatr.Send(command);

            var updatedUser = _context.Users.FirstOrDefault(p => p.UserId == userID);
            var validateChangeResult = hasher.VerifyHashedPassword(updatedUser, updatedUser.Password, newPassword);

            validateChangeResult.Should().BeOneOf(PasswordVerificationResult.Success);
            updatedUser.ModifiedBy.Should().Be(userID);
            updatedUser.ModifiedDate.Should().NotBeNull();
        }
    }
}
