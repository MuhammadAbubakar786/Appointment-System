using AppointmentSystem.Application.Command.Model;
using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.Entities;
using AppointmentSystem.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Command.Handlers
{
    public class UserCommandHandler : ResponseHandler, IRequestHandler<CreateUserCommand, Response<string>>,
                                                       IRequestHandler<EditUserCommand, Response<string>>,
                                                       IRequestHandler<DeleteUserCommand, Response<string>>

    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<string>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = new UserEntity
            {
                Password = request.Password,
                PhoneNumber = request.Phone,
                UserEmail = request.Email,
                UserName = request.UserName,
            };
            var response = await _userRepository.CreateUser(userEntity);
            if (response == ResponseMessages.Success)
                return Created(ResponseMessages.CreatedSuccessfully);
            else return BadRequest<string>();
        }
        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var getUser = await _userRepository.GetUserByIdAsync(request.Id);
            if (getUser is null) return NotFound<string>("The User Not Exist");
            //var userMapping = _mapper.Map<UserEntity>(request);
            var userMapping = _mapper.Map(request, getUser);
            var response = await _userRepository.UpdateUser(userMapping);
            if (response == ResponseMessages.Success) return Success(ResponseMessages.UpdatedSuccessfully);
            return BadRequest<string>(ResponseMessages.SomethingWentWrong);
        }
        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var getUser = await _userRepository.GetUserByIdAsync(request.Id);
            if (getUser is null) return NotFound<string>(ResponseMessages.NoRecordsFound);
            var response = await _userRepository.DeleteUser(getUser);
            if (response == ResponseMessages.Success)
                return Success(ResponseMessages.DeletedSuccessfully);
            return BadRequest<string>(ResponseMessages.SomethingWentWrong);
        }
    }

}
