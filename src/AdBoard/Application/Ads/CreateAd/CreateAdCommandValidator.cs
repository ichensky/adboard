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
            RuleFor(x => x.Picture).NotEmpty().MaximumLength(1024);
            RuleFor(x => x.).NotEmpty().MaximumLength(30);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(30);
        }
    }
}
