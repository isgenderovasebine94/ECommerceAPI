using FluentValidation;
using EcommerceAPI.Entities.Dtos.Categories;


namespace EcommerceAPI.Validators.Categories
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(p => p.Name).MinimumLength(3).WithMessage("3-den boyuk ad daxil edin")
                .MaximumLength(30).WithMessage("30-dan kicik ad daxil edin")
                .Must(StartWithA).WithMessage("A ile basliyan cat daxil edin");
        }
        public bool StartWithA(string name)
        {
            return name.StartsWith('A');
        }
    }

   
}
