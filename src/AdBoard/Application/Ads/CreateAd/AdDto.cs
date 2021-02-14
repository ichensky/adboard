using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.CreateAd
{
    public class AdDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ShortDescription { get; set; }

        public string Keywords { get; set; }

        public string Picture { get; set; }

        public string YoutubeUrl { get; set; }
    }
}
