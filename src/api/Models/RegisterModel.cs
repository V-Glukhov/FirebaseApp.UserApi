using System.ComponentModel.DataAnnotations;
using UserApi.Models.Enums;

namespace UserApi.Models
{
    /// <summary>
    /// Модель для регистрации мобильного предложения
    /// </summary>
    public class RegisterModel
    {
        /// <summary>
        /// токен Firebase
        /// </summary>
        [Required]
        public string Token { get; set; }

        /// <summary>
        /// номер телефона пользователя, использующего данное мобильное приложение
        /// </summary>
        [Required]
        public string Phone { get; set; }

        /// <summary>
        /// версия мобильного приложения
        /// </summary>
        [EnumDataType(typeof(SupportedVersions))]
        public SupportedVersions Version { get; set; }
    }
}
