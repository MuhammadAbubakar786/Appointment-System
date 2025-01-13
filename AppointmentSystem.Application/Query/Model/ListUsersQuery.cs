using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.Entities;
using MediatR;

namespace AppointmentSystem.Application.Query.Model
{
    public class ListUsersQuery : IRequest<Response<IEnumerable<UserEntity>>>
    {
    }
}
