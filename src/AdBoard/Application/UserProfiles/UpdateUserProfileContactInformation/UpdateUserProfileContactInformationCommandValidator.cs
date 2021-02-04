using Application.UserProfiles.CreateUserProfile;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UserProfiles.UpdateUserProfileContactInformation
{
    public class UpdateUserProfileContactInformationCommandValidator : AbstractValidator<UpdateUserProfileContactInformationCommand>
    {
        public UpdateUserProfileContactInformationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Instagram).MaximumLength(30);
            RuleFor(x => x.Telegram).MaximumLength(30);
            RuleFor(x => x.PhoneNumber).MaximumLength(20);
        }
    }
}
