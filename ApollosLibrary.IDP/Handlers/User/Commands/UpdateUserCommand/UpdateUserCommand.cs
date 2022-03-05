﻿using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Exceptions;
using ApollosLibrary.IDP.DTOs;
using ApollosLibrary.IDP.UnitOfWork;
using ApollosLibrary.IDP.Services;
using ApollosLibrary.IDP.Interfaces;
using ApollosLibrary.IDP.Functions;

namespace ApollosLibrary.IDP.User.Commands.UpdateUserCommand
{
    public class UpdateUserCommand : IRequest<UpdateUserCommandDto>
    {
        public Guid UserID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmationPassword { get; set; }
        public List<RoleDTO> Roles { get; set; } = new List<RoleDTO>();
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserCommandDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IUserService _userService;
        private readonly IDateTimeService _dateTimeService;
        private readonly Hasher _hasher;
        private readonly ILogger _logger;

        public UpdateUserCommandHandler(IUserUnitOfWork userUnitOfWork, IUserService userService, IDateTimeService dateTimeService, ILogger<UpdateUserCommandHandler> logger)
        {
            _userUnitOfWork = userUnitOfWork;
            _userService = userService;
            _dateTimeService = dateTimeService;
            _hasher = new Hasher();
            _logger = logger;
        }

        public async Task<UpdateUserCommandDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var response = new UpdateUserCommandDto();

            var userWithUsername = await _userUnitOfWork.UserDataLayer.GetUserByUsername(request.Username);

            if (userWithUsername != null && request.UserID != userWithUsername.UserId)
            {
                throw new UsernameTakenException("Username is already taken");
            }

            var user = await _userUnitOfWork.UserDataLayer.GetUser(request.UserID);

            if (user == null)
            {
                _logger.LogWarning($"Unable to find as user with id [ {request.UserID} ]");
                throw new UserNotFoundException("Update unsuccessful user not found");
            }

            user.Username = request.Username;

            if (!string.IsNullOrEmpty(request.Password))
            {
                user.Password = _hasher.HashPassword(request.Password);
            }

            user.ModifiedBy = _userService.GetUserId();
            user.ModifiedDate = _dateTimeService.Now;

            await _userUnitOfWork.Save();

            return response;
        }
    }
}
