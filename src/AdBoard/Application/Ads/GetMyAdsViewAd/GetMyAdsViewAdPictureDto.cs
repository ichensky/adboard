using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.GetMyAdsViewAd
{
    public class GetMyAdsViewAdPictureDto
    {
        public Guid Id { get; set; }

        public string GoogleId { get; set; }

        public string Name { get; set; }

        public int OrderId { get; set; }
    }
}
