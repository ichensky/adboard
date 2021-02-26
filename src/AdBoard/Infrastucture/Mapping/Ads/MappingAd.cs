using Application.Ads.CreateAd;
using Application.Ads.EditAd;
using AutoMapper;
using Domain.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Mapping.Ads
{
    public class MappingAd : Profile
    {
        public MappingAd()
        {
            CreateMap<Ad, AdDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.Value))
                .ForMember(x => x.Name, y => y.MapFrom(z => z.Name.Value))
                .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription.Value))
                .ForMember(x => x.Description, y => y.MapFrom(z => z.Description.Value))
                .ForMember(x => x.Keywords, y => y.MapFrom(z => z.Keywords.Value))
                .ForMember(x => x.YoutubeUrl, y => y.MapFrom(z => z.YoutubeUrl.Value));

            CreateMap<Ad, EditAdDto>()
               .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.Value))
               .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserProfilesId.Value))
               .ForMember(x => x.Name, y => y.MapFrom(z => z.Name.Value))
               .ForMember(x => x.ShortDescription, y => y.MapFrom(z => z.ShortDescription.Value))
               .ForMember(x => x.Description, y => y.MapFrom(z => z.Description.Value))
               .ForMember(x => x.Keywords, y => y.MapFrom(z => z.Keywords.Value))
               .ForMember(x => x.YoutubeUrl, y => y.MapFrom(z => z.YoutubeUrl.Value))
               .ForMember(x => x.PublishDate, y => y.MapFrom(z => z.Publish.PublishDate))
               .ForMember(x => x.PublishStatus, y => y.MapFrom(z => z.Publish.PublishStatus));
        }
    }
}
