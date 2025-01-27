﻿using FluentValidation;
using Tabu.DTOs.Words;

namespace Tabu.Validators.Words
{
    public class WordCreateDtoValidator : AbstractValidator<WordCreateDto>
    {
        public WordCreateDtoValidator()
        {
            RuleFor(x => x.Text)
                .NotEmpty()
                .WithMessage("Text can not be empty!")
                .NotNull()
                .WithMessage("Text can not be null !")
                .MaximumLength(32)
                .WithMessage("Text length can not be more than 32!");
            RuleForEach(x => x.BannerWords)
                .NotEmpty()
                .WithMessage("LanguageCode can not be empty!")
                .NotEmpty()
                .WithMessage("LanguageCode can not be null !")
                .MinimumLength(2)
                .WithMessage("LanguageCode length can not be less than 2!");
            RuleFor(x => x.BannerWords)
                .Must(x => x.Count == 6);
        }
    }
}
