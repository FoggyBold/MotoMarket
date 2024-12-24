using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MotoMarket.Storage.PostgreSQL.Context;
using MotoMarket.Storage.PostgreSQL.Entities;
using MotoVarket.Identity.Adapter.Features.UserController.DtoModels;
using MotoVarket.Identity.Adapter.Helpers;
using MotoVarket.Identity.Adapter.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MotoVarket.Identity.Adapter.Features.UserController.Commands
{
    public class RegistrCommand : IRequest
    {
        [Required]
        public RegistrDto Body { get; set; }
    }

    public class CustomerValidator : AbstractValidator<RegistrCommand>
    {
        public CustomerValidator()
        {
            RuleFor(model => model.Body)
                .NotNull();

            RuleFor(model => model.Body.Email)
                .Must(RegexValidatorHelper.IsValidEmail)
                .WithMessage("Неверный формат адреса электронной почты.");

            RuleFor(model => model.Body.PhoneNumber)
                .Must(RegexValidatorHelper.IsValidPhoneNumber)
                .WithMessage("Неверный формат номера телефона.");
        }
    }

    public class RegistrCommandHandler : IRequestHandler<RegistrCommand>
    {
        private readonly MainDBContext _dataContext;
        private readonly IIdentityService _identityService;

        public RegistrCommandHandler(
            MainDBContext dataContext,
            IIdentityService identityService)
        {
            _dataContext = dataContext;
            _identityService = identityService;
        }

        public async Task Handle(RegistrCommand request, CancellationToken cancellationToken)
        {
            var userBd = await _dataContext.Users.FirstOrDefaultAsync(u => u.Login == request.Body.Login);

            if (userBd != null)
            {
                throw new Exception("Пользователь с таким логином уже существует");
            }

            var user = new User
            {
                Email = request.Body.Email,
                Login = request.Body.Login,
                Nikname = request.Body.Nikname,
                PasswordHash = _identityService.HashPassword(request.Body.Password),
                PhoneNumber = request.Body.PhoneNumber,
                Role = request.Body.Role
            };

            _dataContext.Add(user);
            await _dataContext.SaveChangesAsync(cancellationToken);
        }
    }
}
