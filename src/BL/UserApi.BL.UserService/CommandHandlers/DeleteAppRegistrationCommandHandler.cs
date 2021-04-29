using MediatR;
using System.Threading;
using System.Threading.Tasks;
using UserApi.BL.Contracts.Commands;
using UserApi.DAL.Repository.Abstraction;

namespace UserApi.BL.UserService.CommandHandlers
{
    public class DeleteAppRegistrationCommandHandler : IRequestHandler<DeleteAppRegistrationCommand, bool>
    {
        private readonly IUserRepository _userRepository;

        public DeleteAppRegistrationCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> Handle(DeleteAppRegistrationCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.Delete(request.Token);
        }
    }
}
