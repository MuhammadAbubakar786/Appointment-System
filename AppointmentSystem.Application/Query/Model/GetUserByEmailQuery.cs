using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.Entities;
using MediatR;

namespace AppointmentSystem.Application.Query.Model
{
    public class GetUserByEmailQuery : IRequest<Response<UserEntity>>
    {
        public string Useremail { get; set; } = null!;
        public GetUserByEmailQuery(string email)
        {
            Useremail = email;
        }
    }
}
