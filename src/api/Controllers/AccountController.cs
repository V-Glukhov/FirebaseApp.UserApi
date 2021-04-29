using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UserApi.BL.Contracts.Commands;
using UserApi.Models;

namespace UserApi.Controllers
{
    /// <summary>
    /// Контроллер для работы мобильных клиентов
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("/api/[controller]/v{version:apiVersion}")]
    public class AccountController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public AccountController(
            IMediator mediator, 
            IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        /// <summary>
        /// Метод регистрации мобильного приложения в системе
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([Required] RegisterModel model) => 
            await _mediator.Send(_mapper.Map<RegisterNewAppCommand>(model))
                ? Ok()
                : BadRequest();

        /// <summary>
        /// Метод удаления регистрации мобильного приложения из системы
        /// </summary>
        /// <param name="token">токен Firebase</param>
        /// <returns></returns>
        [HttpDelete]
        [AllowAnonymous]
        public async Task<IActionResult> Delete([Required] string token) => 
            await _mediator.Send(new DeleteAppRegistrationCommand(token))
                ? Ok()
                : BadRequest();
    }
}
