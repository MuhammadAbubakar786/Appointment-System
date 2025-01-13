using AppointmentSystem.Application.Command.Model;
using AppointmentSystem.Application.Query.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : AppBaseController
    {
        private readonly ISender sender;
        public UserController(ISender _sender)
        {
            sender = _sender;
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand user)
        {
            return NewResult(await sender.Send(user));

        }
        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] EditUserCommand user)
        {
            return NewResult(await sender.Send(user));
        }
        [HttpGet]
        [Route("ListUsers")]
        public async Task<IActionResult> ListUsers()
        {
            return NewResult(await sender.Send(new ListUsersQuery()));
        }
        [HttpGet]
        [Route("ListUsers/{UserEmail}")]
        public async Task<IActionResult> ListUsers(string UserEmail)
        {
            return NewResult(await sender.Send(new GetUserByEmailQuery(UserEmail)));
        }
        [HttpDelete]
        [Route("DeleteUser/{UserId}")]
        public async Task<IActionResult> DeleteUser(int UserId)
        {
            return NewResult(await sender.Send(new DeleteUserCommand(UserId)));
        }

    }
}
