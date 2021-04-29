using UserApi.BL.Contracts.Dto.Enums;

namespace UserApi.BL.Contracts.Dto
{
    public class NewAppDto
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
