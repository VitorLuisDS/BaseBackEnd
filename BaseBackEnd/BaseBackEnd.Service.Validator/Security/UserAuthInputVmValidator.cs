using BaseBackEnd.Domain.ViewModel.UserVms;
using FluentValidation;

namespace BaseBackEnd.Service.Validator.Security
{
    public class UserAuthInputVmValidator : AbstractValidator<UserAuthInputVm>
    {
        public UserAuthInputVmValidator()
        {
            RuleFor(u => u.Login)
                .NotEmptyWithDefaultMessage();

            RuleFor(u => u.Login)
                .LengthWithDefaultMessage(3, 30);

            RuleFor(u => u.Login)
                .MatchesWithDefaultMessage(RegexPatterns.ValidLoginPattern);

            RuleFor(u => u.Password)
                .NotEmptyWithDefaultMessage();

            RuleFor(u => u.Password)
                .LengthWithDefaultMessage(3, 30);
        }
    }
}
