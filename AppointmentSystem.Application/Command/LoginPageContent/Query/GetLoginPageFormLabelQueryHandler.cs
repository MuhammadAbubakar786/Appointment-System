using AppointmentSystem.Application.Command.LoginPageContent.Model;
using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.DTOs;
using AppointmentSystem.Core.Interfaces;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Command.LoginPageContent.Handler
{
    public class GetLoginPageFormLabelQueryHandler : ResponseHandler, IRequestHandler<GetLoginFromQuery, Response<LoginFormLabelDTOs>>
    {
        private readonly ILoginPageLocalizationRepository _loginPageLocalizationRepository;
        private readonly IMapper _mapper;
        public GetLoginPageFormLabelQueryHandler(ILoginPageLocalizationRepository loginPageLocalizationRepository, IMapper mapper)
        {
            _loginPageLocalizationRepository = loginPageLocalizationRepository;
            _mapper = mapper;
        }

        public async Task<Response<LoginFormLabelDTOs>> Handle(GetLoginFromQuery request, CancellationToken cancellationToken)
        {
            var response = await _loginPageLocalizationRepository.GetLocalizedLoginPageFormLabelsAsync(cancellationToken);
            var loginFormLabelDTOs = _mapper.Map<LoginFormLabelDTOs>(response);
            return Success(loginFormLabelDTOs);
        }
    }
}
