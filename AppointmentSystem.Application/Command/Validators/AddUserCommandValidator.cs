using AppointmentSystem.Application.Command.Model;
using AppointmentSystem.Core.Interfaces;
using FluentValidation;

namespace AppointmentSystem.Application.Command.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userService;

        public CreateUserCommandValidator(IUserRepository userService)
        {
            _userService = userService;
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }
        public void ApplicationValidationRule()
        {
            RuleFor(x => x.Email)
                    .NotEmpty().WithMessage("Email is required.")
                    .EmailAddress().WithMessage("Invalid email format.");
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"\d").WithMessage("Password must contain at least one digit.")
                .Matches(@"[!@#$%^&*()_+\-=\[\]{};':\""\\|,.<>\/?]").WithMessage("Password must contain at least one special character.");
        }
        public void ApplyCustomerValidationRule()
        {
            RuleFor(X => X.Email).MustAsync(async (model, key, CancellationToken) => !await _userService.IsAlreadyExist(key))
                               .WithMessage("The email is already exist");
        }
    }
}
