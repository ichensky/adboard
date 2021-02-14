using Application.Configuration.Commands;
using Application.UserProfiles;
using AutoMapper;
using Domain.Ads.Ad;
using Domain.Core;
using Domain.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Ads.CreateAd
{
    public class CreateAdCommandHandler : ICommandHandler<CreateAdCommand, AdDto>
    {
        private readonly IUserProfileRepository userProfileRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateAdCommandHandler(
            IUserProfileRepository userProfileRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.userProfileRepository = userProfileRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AdDto> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var ad = Ad.CreateAd(UserProfile. request.AspNetUsersId);
            var userProfile = UserProfile.CreateUserProfile(new TypedIdValueObject(request.AspNetUsersId),
                new Name(request.FirstName, request.LastName), new Picture(request.Picture));

            await userProfileRepository.AddAsync(userProfile);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserProfileDto>(userProfile);
        }
    }
}
