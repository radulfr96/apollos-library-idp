using ApollosLibrary.IDP.Application.Exceptions;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.User.Queries.GetUsernameQuery
{
    public class GetUsernameQuery : IRequest<GetUsernameQueryDto>
    {
        public Guid UserId { get; set; }
    }

    public class GetUsernameQueryHandler : IRequestHandler<GetUsernameQuery, GetUsernameQueryDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;

        public GetUsernameQueryHandler(IUserUnitOfWork userUnitOfWork)
        {
            _userUnitOfWork = userUnitOfWork;
        }

        public async Task<GetUsernameQueryDto> Handle(GetUsernameQuery query, CancellationToken cancellationToken)
        {
            var response = new GetUsernameQueryDto();

            var user = await _userUnitOfWork.UserDataLayer.GetUser(query.UserId);

            if (user == null)
            {
                throw new UserNotFoundException($"Unable to find user with id [{query.UserId}]");
            }

            response.Username = user.Username;
            return response;
        }
    }
}