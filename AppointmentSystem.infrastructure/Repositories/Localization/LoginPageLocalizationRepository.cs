using AppointmentSystem.Application;
using AppointmentSystem.Core.Interfaces;
using Microsoft.Extensions.Localization;

namespace AppointmentSystem.infrastructure.Repositories.Localization
{
    public class LoginPageLocalizationRepository : ILoginPageLocalizationRepository
    {

        private readonly IStringLocalizer<SharedResources> _sharedLocalizer;
        public LoginPageLocalizationRepository(IStringLocalizer<SharedResources> sharedLocalizer)
        {
            _sharedLocalizer = sharedLocalizer;
        }
        public async Task<Dictionary<string, string>> GetLocalizedLoginPageFormLabelsAsync(CancellationToken cancellationToken)
        {
            var x = _sharedLocalizer["UserNameLabel"];
            return await Task.FromResult(new Dictionary<string, string>
            {
                { "UserName", _sharedLocalizer["UserNameLabel"] },
                { "Password", _sharedLocalizer["PasswordLabel"] },
                { "Email", _sharedLocalizer["EmailLabel"] },
                { "LoginPageHeadline", _sharedLocalizer["LoginHeadline"] }
            }
        );
        }
    }
}