using MediatR;
using UserApi.BL.Contracts.Dto;

namespace UserApi.BL.Contracts.Commands
{
    public class RegisterNewAppCommand : IRequest<bool>
    {
        public NewAppDto Dto { get; set; }
    }
}
