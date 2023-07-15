using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizApp.Application.Users.Commands;

namespace QuizApp.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] AuthenticateUserCommand command)
        {
            var rs = await _mediator.Send(command);
            return Ok(rs);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Resgister([FromBody] RegisterUserCommand command)
        {
            var rs = await _mediator.Send(command);
            return Ok(rs);
        }
    }
}
