using FluentValidation;
using Pe2Api.Domain.Validations.Extensions.Validators;

namespace Pe2Api.Domain.Validations.Extensions
{
    public static class ValidationExtensions
    {
      
        public static IRuleBuilderOptions<TClass, TProperty> NotNullOrEmpty<TClass, TProperty>(this IRuleBuilder<TClass, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new NotNullOrEmptyValidator<TClass, TProperty>());
        }
    }
}
