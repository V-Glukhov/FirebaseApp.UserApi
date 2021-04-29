using MediatR;

namespace UserApi.BL.Contracts.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteAppRegistrationCommand : IRequest<bool>
    {
        public DeleteAppRegistrationCommand(string token)
        {
            Token = token;
        }

        /// <summary>
        /// 
        /// </summary>
        public string Token { get; set; }
    }
}
