using MediatR;

namespace UserServiceContracts.Commands
{
    public class DeleteAppRegistrationCommand : IRequest<bool>
    {
        public DeleteAppRegistrationCommand(string token)
        {
            Token = token;
        }

        public string Token { get; set; }
    }
}
