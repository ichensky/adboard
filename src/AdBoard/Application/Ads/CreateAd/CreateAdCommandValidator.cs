using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.CreateAd
{
    public class CreateAdCommandValidator : AbstractValidator<CreateAdCommand>
    {
        public CreateAdCommandValidator()
        {
            RuleFor(x => x.UsersProfileId).NotEmpty();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ShortDescription).NotEmpty().MaximumLength(160);
            RuleFor(x => x.Description).MaximumLength(800);
            RuleFor(x => x.YoutubeUrl).MaximumLength(1024);
            RuleFor(x => x.Keywords).MaximumLength(120);
        }
    }
}
