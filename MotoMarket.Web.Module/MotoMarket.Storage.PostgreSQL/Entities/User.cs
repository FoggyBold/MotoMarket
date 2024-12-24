using MotoMarket.Storage.PostgreSQL.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotoMarket.Storage.PostgreSQL.Entities
{
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnUser { get; set; }

        /// <summary>
        /// Логин
        /// </summary>
        [StringLength(255)]
        public string Username { get; set; }

        /// <summary>
        /// Hash пароля
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// Роль
        /// </summary>
        public UserRole Role { get; set; }
    }
}
