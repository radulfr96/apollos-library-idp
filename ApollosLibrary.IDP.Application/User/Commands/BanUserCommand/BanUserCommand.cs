using ApollosLibrary.IDP.Application.Exceptions;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.User.Commands.BanUserCommand
{
    public class BanUserCommand : IRequest<BanUserCommandDto>
    {
        public Guid UserId { get; set; }
    }

    public class BanUserCommandHandler : IRequestHandler<BanUserCommand, BanUserCommandDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IUserService _userService;

        public BanUserCommandHandler(IUserUnitOfWork userUnitOfWork, IUserService userService)
        {
            _userUnitOfWork = userUnitOfWork;
            _userService = userService;
        }

        public async Task<BanUserCommandDto> Handle(BanUserCommand command, CancellationToken cancellationToken)
        {
            var response = new BanUserCommandDto();

            if (_userService.GetUserId() == command.UserId)
            {
                throw new UserCannotSelfBanException("You cannot ban yourself.");
            }

            var user = await _userUnitOfWork.UserDataLayer.GetUser(command.UserId);

            if (user == null)
            {
                throw new UserNotFoundException($"Unable to ban user with id [{command.UserId}]");
            }

            user.IsActive = false;
            user.IsBanned = true;

            await _userUnitOfWork.Save();

            return response;
        }
    }
}
