using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto>
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
