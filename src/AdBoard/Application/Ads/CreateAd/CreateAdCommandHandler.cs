using Application.Configuration.Commands;
using Application.UserProfiles;
using AutoMapper;
using Domain.Ads;
using Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Ads.CreateAd
{
    public class CreateAdCommandHandler : ICommandHandler<CreateAdCommand, AdDto>
    {
        private readonly IAdRepository adRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CreateAdCommandHandler(
            IAdRepository adRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.adRepository = adRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<AdDto> Handle(CreateAdCommand request, CancellationToken cancellationToken)
        {
            var ad = Ad.CreateAd(new TypedIdValueObject(request.UsersProfileId), new Name(request.Name),
                new ShortDescription(request.ShortDescription), new Description(request.Description),
                new Keywords(request.Keywords), new YoutubeUrl(request.Name));

            adRepository.Add(ad);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<AdDto>(ad);
        }
    }
}
