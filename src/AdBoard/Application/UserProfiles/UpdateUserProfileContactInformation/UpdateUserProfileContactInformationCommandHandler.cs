using Application.Configuration.Commands;
using Application.UserProfiles.CreateUserProfile;
using AutoMapper;
using Domain.Core;
using Domain.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserProfiles.UpdateUserProfileContactInformation
{
    public class UpdateUserProfileContactInformationCommandHandler : ICommandHandler<UpdateUserProfileContactInformationCommand, UserProfileDto>
    {
        private readonly IAdRepository userProfileRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UpdateUserProfileContactInformationCommandHandler(
            IAdRepository userProfileRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.userProfileRepository = userProfileRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(UpdateUserProfileContactInformationCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await userProfileRepository.GetAsync(new TypedIdValueObject(request.UserProfileId));
            userProfile.UpdateUserProfile(new ContactInformation(request.PhoneNumber, request.Telegram, request.Instagram));

            var updated = userProfileRepository.Update(userProfile);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserProfileDto>(updated);
        }
    }
}
