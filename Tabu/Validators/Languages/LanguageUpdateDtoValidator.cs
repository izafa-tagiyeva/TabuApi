using FluentValidation;
using Tabu.DTOs.Languages;
namespace Tabu.Validators.Languages
{
    public class LanguageUpdateDtoValidator : AbstractValidator<LanguageUpdateDto>
    {
        public LanguageUpdateDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Name CANNOT BE EMPTY OR NULL")
                .MaximumLength(64)
                    .WithMessage("Name length can not be more than 64!");

            RuleFor(x => x.Icon)
                .NotNull()
                .NotEmpty()
                    .WithMessage("Icon bosh ola bilmez")
                .Matches("^http(s)?://([\\w-]+.)+[\\w-]+(/[\\w- ./?%&=])?$")
                    .WithMessage("Icon deyeri link olmalidir")
                .MaximumLength(128)
                    .WithMessage("Icon length can not be more than 128!");
        }
    }
}
