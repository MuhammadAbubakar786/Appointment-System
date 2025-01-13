using AppointmentSystem.Core.Bases;
using MediatR;

namespace AppointmentSystem.Application.Command.Model
{
    public class EditUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
