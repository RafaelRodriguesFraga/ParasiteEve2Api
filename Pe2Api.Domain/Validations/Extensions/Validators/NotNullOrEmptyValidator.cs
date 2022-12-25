using FluentValidation;
using FluentValidation.Validators;

namespace Pe2Api.Domain.Validations.Extensions.Validators
{
    public class NotNullOrEmptyValidator<TClass, TProperty> : PropertyValidator<TClass, TProperty>, INotNullOrEmptyValidator
    {
        public override string Name => "NotNullOrEmptyValidator";

        public override bool IsValid(ValidationContext<TClass> context, TProperty value)
        {
            return !string.IsNullOrEmpty(value?.ToString());
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return Localized(errorCode, Name);
        }
    }

    public interface INotNullOrEmptyValidator : IPropertyValidator { }
}
