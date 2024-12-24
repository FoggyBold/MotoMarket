using System.ComponentModel.DataAnnotations;

namespace MotoVarket.Identity.Adapter.Features.UserController.DtoModels
{
    public sealed record LoginDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Login { get; init; }

        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; init; }
    }
}
