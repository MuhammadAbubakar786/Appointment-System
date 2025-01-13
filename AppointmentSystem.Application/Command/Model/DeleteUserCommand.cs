using AppointmentSystem.Core.Bases;
using MediatR;

namespace AppointmentSystem.Application.Command.Model
{
    public class DeleteUserCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteUserCommand(int userId)
        {
            Id = userId;
        }
    }
}
