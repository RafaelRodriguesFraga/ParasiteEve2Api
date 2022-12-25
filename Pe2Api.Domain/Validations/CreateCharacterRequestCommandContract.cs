using FluentValidation;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Validations.Extensions;

namespace Pe2Api.Domain.Validations
{
    public class CreateCharacterRequestCommandContract : AbstractValidator<CreateCharacterRequestCommand>
    {
        public CreateCharacterRequestCommandContract()
        {
            RuleFor(x => x.Name)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.Age)
                .NotNull()
                .WithMessage("Cannot be null")
                .GreaterThan(0)
                .WithMessage("Must be greater than zero");

            RuleFor(x => x.ImageUrl)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.HairColor)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.EyeColor)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.Occupation)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");
        }
    }
}
