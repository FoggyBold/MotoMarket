using MotoMarket.Storage.PostgreSQL.Enums;
using System.ComponentModel.DataAnnotations;

namespace MotoVarket.Identity.Adapter.Features.UserController.DtoModels
{
    public class RegistrDto
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

        /// <summary>
        /// Роль
        /// </summary>
        [Required]
        public UserRole Role { get; set; }

        /// <summary>
        /// Номер телефона
        /// </summary>
        [Required]
        [StringLength(11)]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Email почта
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        /// <summary>
        /// Имя пользователя
        /// </summary>
        [Required]
        [StringLength(255)]
        public string Nikname { get; set; }
    }
}
