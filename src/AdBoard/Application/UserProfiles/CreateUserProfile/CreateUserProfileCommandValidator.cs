using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.CreateUserProfile
{
    public class CreateUserProfileCommandValidator : AbstractValidator<CreateUserProfileCommand>
    {
        public CreateUserProfileCommandValidator()
        {
            RuleFor(x => x.AspNetUsersId).NotEmpty();
            RuleFor(x => x.Picture).NotEmpty().MaximumLength(1024);
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(30);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(30);
        }
    }
}
