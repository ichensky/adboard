﻿using Domain.Ads;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ads.ListMyAds
{
    public class MyAdDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public DateTime? PublishDate { get; set; }

        public PublishStatus PublishStatus { get; set; }
    }
}
