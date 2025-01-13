namespace AppointmentSystem.Application.Command
{

    //public record AddUserCommand(UserEntity user) : IRequest<Result<UserEntity>>;
    ////public record UpdateUserCommand(int UserId, UserEntity User) : IRequest<Result<UserEntity>>;

    //public class AddUserCommandHandler : IRequestHandler<AddUserCommand, Result<UserEntity>>/*, IRequestHandler<UpdateUserCommand, Result<UserEntity>>*/
    //{
    //    private readonly IUserRepository _userRepository;
    //    public AddUserCommandHandler(IUserRepository userRepository)
    //    {
    //        _userRepository = userRepository;
    //    }
    //public async Task<Result<UserEntity>> Handle(AddUserCommand request, CancellationToken cancellationToken)
    //{
    //    return await _userRepository.CreateUser(request.user);
    //}

    //public async Task<Result<UserEntity>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    //{
    //    return await _userRepository.UpdateUser(request.UserId, request.User);
    //}
}
