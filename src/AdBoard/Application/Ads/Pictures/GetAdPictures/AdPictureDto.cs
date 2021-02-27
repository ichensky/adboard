using Domain.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.Pictures.GetAdPictures
{
    public class AdPictureDto
    {
        public Guid Id { get; set; }

        public string? GoogleId { get; set; }

        public string? Description { get; set; }

        public int Order { get; set; }
    }
}
