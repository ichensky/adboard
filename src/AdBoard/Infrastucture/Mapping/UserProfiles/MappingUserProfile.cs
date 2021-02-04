using Application.UserProfiles;
using AutoMapper;
using Domain.UserProfiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastucture.Mapping.UserProfiles
{
    public class MappingUserProfile : Profile
    {
        public MappingUserProfile()
        {
            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(x => x.Id, y => y.MapFrom(z => z.Id.Value))
                .ForMember(x => x.FirstName, y => y.MapFrom(z => z.Name.FirstName))
                .ForMember(x => x.LastName, y => y.MapFrom(z => z.Name.LastName))
                .ForMember(x => x.Instagram, y => y.MapFrom(z => z.ContactInformation.Instagram))
                .ForMember(x => x.PhoneNumber, y => y.MapFrom(z => z.ContactInformation.PhoneNumber))
                .ForMember(x => x.Telegram, y => y.MapFrom(z => z.ContactInformation.Telegram))
                .ForMember(x => x.Picture, y => y.MapFrom(z => z.Picture.Value));
        }
    }
}
