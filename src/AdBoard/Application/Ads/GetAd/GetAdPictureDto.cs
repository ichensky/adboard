using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.GetAd
{
    public class GetAdPictureDto
    {
        public Guid Id { get; set; }

        public string GoogleId { get; set; }

        public string Name { get; set; }

        public int OrderId { get; set; }
    }
}
