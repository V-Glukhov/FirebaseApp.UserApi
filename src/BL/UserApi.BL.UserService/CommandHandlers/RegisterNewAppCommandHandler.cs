using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using UserApi.BL.Contracts.Commands;
using UserApi.DAL.Models;
using UserApi.DAL.Repository.Abstraction;

namespace UserApi.BL.UserService.CommandHandlers
{
    public class RegisterNewAppCommandHandler : IRequestHandler<RegisterNewAppCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<RegisterNewAppCommandHandler> _logger;
        private readonly IMapper _mapper;

        public RegisterNewAppCommandHandler(IUserRepository userRepository,
            ILogger<RegisterNewAppCommandHandler> logger,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<bool> Handle(RegisterNewAppCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("RegisterNewAppCommandHandler started");

            return await _userRepository.Add(_mapper.Map<User>(request.Dto));
        }
    }
}
