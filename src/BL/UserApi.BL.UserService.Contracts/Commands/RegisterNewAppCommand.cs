using MediatR;
using UserServiceContracts.Dto;

namespace UserServiceContracts.Commands
{
    public class RegisterNewAppCommand: IRequest<bool>
    {
        public NewAppDto Dto { get; set; }
    }
}
