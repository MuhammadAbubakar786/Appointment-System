using AppointmentSystem.Core.Bases;
using MediatR;

namespace AppointmentSystem.Application.Command.Model
{
    public class CreateUserCommand : IRequest<Response<string>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }
}
