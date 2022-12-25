using FluentValidation;
using Pe2Api.Domain.Commands.Request;
using Pe2Api.Domain.Validations.Extensions;

namespace Pe2Api.Domain.Validations
{
    public class CreateArmorRequestCommandContract : AbstractValidator<CreateArmorRequestCommand>
    {
        public CreateArmorRequestCommandContract()
        {
            RuleFor(x => x.Name)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.Hp)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.Mp)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.ImageUrl)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.Attachments)
                .NotNull()
                .WithMessage("Cannot be null")
                .GreaterThan(0)
                .WithMessage("Must be greater than zero");

            RuleFor(x => x.SpecialFeatures)
                .NotNull()
                .WithMessage("Cannot be null");

            RuleFor(x => x.Price)
               .NotNull()
               .WithMessage("Cannot be null")
               .GreaterThan(0)
               .WithMessage("Must be greater than zero");

            RuleFor(x => x.EndgamePrice)
               .NotNull()
               .WithMessage("Cannot be null")
               .GreaterThan(0)
               .WithMessage("Must be greater than zero");

            RuleFor(x => x.Description)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.AlternativeDescription)
                .NotNullOrEmpty()
                .WithMessage("Cannot be null or empty");

            RuleFor(x => x.Locations)
                .NotNull()
                .WithMessage("Cannot be null");

            RuleFor(x => x.ScavengerNightmareMode)
                .NotNull()
                .WithMessage("Cannot be null");
        }
    }
}
