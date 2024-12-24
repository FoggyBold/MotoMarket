using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoMarket.Storage.PostgreSQL.Context;
using MotoVarket.Identity.Adapter.Features.UserController.DtoModels;
using MotoVarket.Identity.Adapter.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MotoVarket.Identity.Adapter.Features.UserController.Commands
{
    public class LoginCommand : IRequest<bool>
    {
        /// <summary>
        /// Тело запроса
        /// </summary>
        [FromForm]
        [Required]
        public LoginDto Body { get; init; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        private readonly MainDBContext _dataContext;
        private readonly IIdentityService _identityService;

        public LoginCommandHandler(
            MainDBContext dataContext,
            IIdentityService identityService)
        {
            _dataContext = dataContext;
            _identityService = identityService;
        }

        public async Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = await _dataContext.Users.FirstOrDefaultAsync(u => u.Login == request.Body.Login);

            if (user == null)
                return false;

            return _identityService.VerifyPassword(request.Body.Password, user.PasswordHash);
        }
    }
}
