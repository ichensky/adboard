using Domain.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.EditAd
{
    public class EditAdDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string ShortDescription { get; set; }

        public string? Keywords { get; set; }

        public string? YoutubeUrl { get; set; }

        public DateTime? PublishDate { get; set; }

        public PublishStatus PublishStatus { get; set; }
    }
}
