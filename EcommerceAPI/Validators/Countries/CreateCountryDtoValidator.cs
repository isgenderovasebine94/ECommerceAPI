using EcommerceAPI.Entities.Dtos.Countries;
using FluentValidation;

namespace EcommerceAPI.Validators.Countries
{
    public class CreateCountryDtoValidator:AbstractValidator<CreateCountryDto>
    {
        public CreateCountryDtoValidator()
        {
            RuleFor(c => c.Name).MinimumLength(3).MaximumLength(200);
        }
    }
}
