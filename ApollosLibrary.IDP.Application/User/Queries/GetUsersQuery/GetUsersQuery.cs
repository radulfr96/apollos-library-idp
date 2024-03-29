﻿using MediatR;
using ApollosLibrary.IDP.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ApollosLibrary.IDP.Application.DTOs;
using ApollosLibrary.IDP.UnitOfWork.Contracts;

namespace ApollosLibrary.IDP.Application.User.Queries.GetUsersQuery
{
    public class GetUsersQuery : IRequest<GetUsersQueryDto>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, GetUsersQueryDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public GetUsersQueryHandler(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<GetUsersQueryDto> Handle(GetUsersQuery query, CancellationToken cancellationToken)
        {
            var response = new GetUsersQueryDto();

            var users = await _userUnitOfWork.UserDataLayer.GetUsers();

            if (users.Count == 0)
            {
                return response;
            }

            response.Users = users.Select(u => new UserDTO()
            {
                UserID = u.UserId,
                IsActive = u.IsActive ? "Active" : "Inactive",
                Username = u.Username,
                IsBanned = u.IsBanned ? "Yes" : "No",
                Email = u.UserClaims.FirstOrDefault(c => c.Type == "emailaddress")?.Value,
            }).ToList();

            return response;
        }
    }
}
