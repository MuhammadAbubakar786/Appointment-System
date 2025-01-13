using AppointmentSystem.Core.Bases;
using AppointmentSystem.Core.DTOs;
using MediatR;

namespace AppointmentSystem.Application.Command.LoginPageContent.Model
{
    public class GetLoginFromQuery : IRequest<Response<LoginFormLabelDTOs>>;
}
