using BaseBackEnd.Domain.ViewModel.UserVms;
using FluentValidation;
using System.Text.RegularExpressions;

namespace BaseBackEnd.Service.Validator.Security
{
    public class UserAuthInputVmValidator : AbstractValidator<UserAuthInputVm>
    {
        public UserAuthInputVmValidator()
        {
            RuleFor(u => u.Login)
                .NotEmpty()
                .WithMessage("{PropertyName} should be provided");

            RuleFor(u => u.Login)
                .Length(3, 30)
                .WithMessage("Length of {PropertyName} should be {MinLength} to {MaxLength}");

            RuleFor(u => u.Login)
                .Matches(new Regex("^[aA-zZ0-9_-]+$"))
                .WithMessage("{PropertyName} is not valid");

            RuleFor(u => u.Password)
                .NotEmpty()
                .WithMessage("{PropertyName} should be provided");

            RuleFor(u => u.Password)
                .Length(3, 30)
                .WithMessage("Length of {PropertyName} should be {MinLength} to {MaxLength}");
        }
    }
}
