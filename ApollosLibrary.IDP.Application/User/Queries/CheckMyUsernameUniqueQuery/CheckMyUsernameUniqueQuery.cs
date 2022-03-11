﻿using ApollosLibrary.IDP.Infrastructure.Interfaces;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.User.Queries.CheckMyUsernameUnique
{
    public class CheckMyUsernameUniqueQuery: IRequest<CheckMyUsernameUniqueQueryDto>
    {
        public string Username { get; set; }
    }

    public class CheckMyUsernameUniqueHandler : IRequestHandler<CheckMyUsernameUniqueQuery, CheckMyUsernameUniqueQueryDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IUserService _userService;

        public CheckMyUsernameUniqueHandler(IUserUnitOfWork userUnitOfWork, IUserService userService)
        {
            _userUnitOfWork = userUnitOfWork;
            _userService = userService;
        }

        public async Task<CheckMyUsernameUniqueQueryDto> Handle(CheckMyUsernameUniqueQuery query, CancellationToken cancellationToken)
        {
            var response = new CheckMyUsernameUniqueQueryDto();

            var userWithUsername = await _userUnitOfWork.UserDataLayer.GetUserByUsername(query.Username);

            if (userWithUsername != null && _userService.GetUserId() != userWithUsername.UserId)
            {
                response.IsUnique = false;
            } 
            else
            {
                response.IsUnique = true;
            }

            return response;
        }
    }
}
