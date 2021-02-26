using Application.Configuration.Commands;
using Application.UserProfiles;
using AutoMapper;
using Domain.Ads;
using Domain.Core;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Ads.EditAd
{
    public class EditAdCommandHandler : ICommandHandler<EditAdCommand, EditAdDto>
    {
        private readonly IAdRepository adRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EditAdCommandHandler(
            IAdRepository adRepository,
            IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.adRepository = adRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<EditAdDto> Handle(EditAdCommand request, CancellationToken cancellationToken)
        {
            var ad = await adRepository.GetAsync(new TypedIdValueObject(request.AdId));

            ad.UpdateAdByUser(new TypedIdValueObject(request.UserId), new Name(request.Name),
            new ShortDescription(request.ShortDescription), new Description(request.Description),
            new Keywords(request.Keywords), new YoutubeUrl(request.YoutubeUrl));

            adRepository.Update(ad);

            await unitOfWork.SaveChangesAsync(cancellationToken);

            return mapper.Map<EditAdDto>(ad);
        }
    }
}
