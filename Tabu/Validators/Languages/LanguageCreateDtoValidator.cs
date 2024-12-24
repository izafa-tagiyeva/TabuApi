using FluentValidation;
using Tabu.DTOs.Languages;

namespace Tabu.Validators.Languages
{
    public class LanguageCreateDtoValidator : AbstractValidator<LanguageCreateDto> 
    {
        public LanguageCreateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Code can not be empty or null!")
                .MaximumLength(2)
                    .WithMessage("Code's length can not be more than 2!");

            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Name can not be null or empty!")
                .MaximumLength(64)
                    .WithMessage("Name's length can not be more than 64!");


            RuleFor(x => x.Icon)
          .NotNull()
          .NotEmpty()
              .WithMessage("Icon can not be null or empty!")
          .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
              .WithMessage("Icon value must be a link")
          .MaximumLength(128)
              .WithMessage("Icon length can not be more than 128!");
        }
    }
}
