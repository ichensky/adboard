using Application.Configuration.Commands;
using AutoMapper;
using Domain.Core;
using Domain.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.UserProfiles.CreateUserProfile
{
    public class CreateUserProfileCommandHandler : ICommandHandler<CreateUserProfileCommand, UserProfileDto>
    {
        private readonly IUserProfileRepository userProfileRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateUserProfileCommandHandler(
            IUserProfileRepository userProfileRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.userProfileRepository = userProfileRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UserProfileDto> Handle(CreateUserProfileCommand request, CancellationToken cancellationToken)
        {
            var userProfile  = UserProfile.CreateUserProfile(new TypedIdValueObject(request.AspNetUsersId), 
                new Name(request.FirstName, request.LastName), new Picture(request.Picture));

            await userProfileRepository.AddAsync(userProfile);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<UserProfileDto>(userProfile);
        }
    }
}
