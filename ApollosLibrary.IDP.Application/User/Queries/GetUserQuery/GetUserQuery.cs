﻿using ApollosLibrary.IDP.Application.Exceptions;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using MediatR;

namespace ApollosLibrary.IDP.Application.User.Queries.GetUserQuery
{
    public class GetUserQuery : IRequest<GetUserQueryDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserQueryDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public GetUserQueryHandler(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<GetUserQueryDto> Handle(GetUserQuery query, CancellationToken cancellationToken)
        {
            var response = new GetUserQueryDto();

            var user = await _userUnitOfWork.UserDataLayer.GetUser(query.UserId);

            if (user == null)
            {
                throw new UserNotFoundException($"Unable to find user with id [{query.UserId}]");
            }

            response.IsActive = user.IsActive ? "Active" : "Inactive";
            response.IsBanned = user.IsBanned;
            response.UserID = user.UserId;
            response.Username = user.Username;
            response.UserRoles = user.UserClaims.Where(u => u.Type == "role").Select(u => u.Value).ToList();
            response.Roles = new List<string>()
            {
                "moderator",
                "administrator",
                "freeaccount",
                "paidaccount"
            };

            return response;
        }
    }
}
