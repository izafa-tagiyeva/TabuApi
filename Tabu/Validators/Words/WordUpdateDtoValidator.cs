using FluentValidation;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordUpdateDtoValidator : AbstractValidator<WordUpdateDto>
    {
        public WordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
               .NotEmpty()
               .WithMessage("Text can not be empty!")
               .NotNull()
               .WithMessage("Text can not be null !")
               .MaximumLength(32)
               .WithMessage("Text length can not be more than 32!");
            RuleFor(x => x.LanguageCode)
                .NotEmpty()
                .WithMessage("LanguageCode can not be empty!")
                .NotEmpty()
                .WithMessage("LanguageCode can not be null !")
                .MaximumLength(2)
                .WithMessage("LanguageCode length can not be more than 2!");

        }
    }
}
