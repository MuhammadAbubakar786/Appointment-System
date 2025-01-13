using AppointmentSystem.Application.Command.LoginPageContent.Model;
using Microsoft.AspNetCore.Mvc;

namespace Appointment_System.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginPageLocalizationController : AppBaseController
    {
        [HttpGet]
        [Route("GetLoginPageFormLabelLocalization")]
        public async Task<IActionResult> GetLoginPageFormLabelLocalization()
        {
            return NewResult(await _mediator.Send(new GetLoginFromQuery()));
        }
    }
}
