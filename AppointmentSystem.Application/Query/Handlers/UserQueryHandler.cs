using AppointmentSystem.Application.Query.Model;
using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.Entities;
using AppointmentSystem.Core.Interfaces;
using MediatR;

namespace AppointmentSystem.Application.Query.Handlers
{
    public class UserQueryHandler : ResponseHandler, IRequestHandler<GetUserByEmailQuery, Response<UserEntity>>,
                                                     IRequestHandler<ListUsersQuery, Response<IEnumerable<UserEntity>>>
    {
        private readonly IUserRepository userRepository;
        public UserQueryHandler(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<Response<UserEntity>> Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
        {
            var user = await userRepository.GetUserByEmailAsync(request.Useremail);
            if (user is null) return NotFound<UserEntity>(ResponseMessages.NoRecordsFound);
            return Success(user);
        }

        public async Task<Response<IEnumerable<UserEntity>>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await userRepository.ListUsers();
            return Success(users);
        }
    }
}
