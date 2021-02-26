using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.EditAd
{
    public class EditAdCommandValidator : AbstractValidator<EditAdCommand>
    {
        public EditAdCommandValidator()
        {
            RuleFor(x => x.AdId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ShortDescription).NotEmpty().MaximumLength(160);
            RuleFor(x => x.Description).MaximumLength(800);
            RuleFor(x => x.YoutubeUrl).MaximumLength(1024);
            RuleFor(x => x.Keywords).MaximumLength(120);
        }
    }
}
