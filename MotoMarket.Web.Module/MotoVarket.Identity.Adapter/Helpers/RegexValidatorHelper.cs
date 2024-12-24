using System.Text.RegularExpressions;

namespace MotoVarket.Identity.Adapter.Helpers
{
    public class RegexValidatorHelper
    {
        // Регулярное выражение для проверки адреса электронной почты
        private static readonly Regex EmailRegex = new Regex(
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Регулярное выражение для проверки номера телефона (только цифры)
        private static readonly Regex PhoneRegex = new Regex(
            @"^\d+$",
            RegexOptions.Compiled);

        /// <summary>
        /// Проверяет, является ли строка допустимым адресом электронной почты.
        /// </summary>
        /// <param name="email">Адрес электронной почты для проверки.</param>
        /// <returns>True, если адрес электронной почты допустим; иначе - false.</returns>
        public static bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            return EmailRegex.IsMatch(email);
        }

        /// <summary>
        /// Проверяет, является ли строка допустимым номером телефона (состоящим только из цифр).
        /// </summary>
        /// <param name="phone">Номер телефона для проверки.</param>
        /// <returns>True, если номер телефона допустим; иначе - false.</returns>
        public static bool IsValidPhoneNumber(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            return PhoneRegex.IsMatch(phone);
        }
    }
}
