using FluentValidation;
using System.Text.RegularExpressions;

namespace BaseBackEnd.Security.API.ViewModels.Validators.Base
{
    public static class DefaultValitations
    {
        public static IRuleBuilderOptions<T, TElement> NotEmptyWithDefaultMessage<T, TElement>(this IRuleBuilder<T, TElement> ruleBuilder, string message = "{PropertyName} should be provided")
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage(message);
        }

        public static IRuleBuilderOptions<T, string> LengthWithDefaultMessage<T>(this IRuleBuilder<T, string> ruleBuilder, int min, int max, string message = "Length of {PropertyName} should be {MinLength} to {MaxLength}")
        {
            return ruleBuilder
                .Length(min, max)
                .WithMessage(message);
        }

        public static IRuleBuilderOptions<T, string> MatchesWithDefaultMessage<T>(this IRuleBuilder<T, string> ruleBuilder, Regex regex, string message = "{PropertyName} is not valid")
        {
            return ruleBuilder
                .Matches(regex)
                .WithMessage(message);
        }
    }
}
