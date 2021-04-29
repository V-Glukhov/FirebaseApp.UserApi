using UserApi.DAL.Models.Enums;

namespace UserApi.DAL.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class User
    {
        /// <summary>
        /// токен Firebase
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// номер телефона пользователя, использующего данное мобильное приложение
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// версия мобильного приложения
        /// </summary>
        public SupportedVersions Version { get; set; }
    }
}
