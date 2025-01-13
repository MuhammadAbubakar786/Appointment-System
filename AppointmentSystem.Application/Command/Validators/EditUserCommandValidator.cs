using AppointmentSystem.Application.Command.Model;
using AppointmentSystem.Core.Interfaces;
using FluentValidation;

namespace AppointmentSystem.Application.Command.Validators
{
    public class EditUserCommandValidator : AbstractValidator<EditUserCommand>
    {
        private readonly IUserRepository userRepository;

        public EditUserCommandValidator(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
            ApplicationValidationRule();
            ApplyCustomerValidationRule();
        }

        public void ApplicationValidationRule()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("The Name Can Not Be Empty")
                              .NotNull().WithMessage("The Name Can Not Be Null")
                              .MaximumLength(50).WithMessage("Max Lenght Is 50 ");
            RuleFor(x => x.Email)
                   .NotEmpty().WithMessage("Email is required.")
                   .EmailAddress().WithMessage("Invalid email format.");
        }
        public void ApplyCustomerValidationRule()
        {
            RuleFor(X => X.Email).MustAsync(async (model, key, CancellationToken) => !await userRepository.IsAlreadyExistSelfExcluded(key, model.Id))
                               .WithMessage("The Email Is Already Exist");
        }
    }
}
