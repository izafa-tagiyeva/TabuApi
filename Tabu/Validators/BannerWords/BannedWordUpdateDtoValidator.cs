using FluentValidation;
using Tabu.DTOs.BannerWords;

namespace Tabu.Validators.BannerWords
{
    public class BannedWordUpdateDtoValidator : AbstractValidator<BannedWordUpdateDto>
    {
        public BannedWordUpdateDtoValidator()
        {
            RuleFor(x => x.Text)
                 .NotEmpty()
                 .WithMessage("Text can not be empty !")
                 .NotNull()
                 .WithMessage("Text can not be null!")
                 .MaximumLength(32)
                 .WithMessage("Text length can not be more than 32");
            RuleFor(x => x.WordId)
                 .GreaterThan(0)
                 .WithMessage("WordId must be greater than 0!");
        }
    }
}
