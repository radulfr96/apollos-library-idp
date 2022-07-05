using ApollosLibrary.IDP.Application.Exceptions;
using ApollosLibrary.IDP.Infrastructure.Interfaces;
using ApollosLibrary.IDP.UnitOfWork.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ApollosLibrary.IDP.Application.User.Commands.DeleteUserCommand
{
    public class DeactivateUserCommand : IRequest<DeactivateUserCommandDto>
    {
        public Guid UserId { get; set; }
        public bool SelfDeactive { get; set; }
    }

    public class DeactivateUserCommandHandler : IRequestHandler<DeactivateUserCommand, DeactivateUserCommandDto>
    {
        private readonly IUserUnitOfWork _userUnitOfWork;
        private readonly IUserService _userService;

        public DeactivateUserCommandHandler(IUserUnitOfWork userUnitOfWork, IUserService userService)
        {
            _userUnitOfWork = userUnitOfWork;
            _userService = userService;
        }

        public async Task<DeactivateUserCommandDto> Handle(DeactivateUserCommand command, CancellationToken cancellationToken)
        {
            var response = new DeactivateUserCommandDto();

            var userId = command.UserId;

            if (command.SelfDeactive)
            {
                userId = _userService.GetUserId();
            }

            var user = await _userUnitOfWork.UserDataLayer.GetUser(userId);

            if (user == null)
            {
                throw new UserNotFoundException($"Unable to delete user with id [{userId}]");
            }

            user.IsActive = false;

            await _userUnitOfWork.Save();

            return response;
        }
    }
}
