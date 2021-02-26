using Domain.Core;
using System;

namespace Domain.Ads.Pictures
{
    public class Picture : Entity
    {
        private readonly string? googleId;
        private Description? description;
        private int order;
        private DateTime creationDate;
        private readonly TypedIdValueObject id;
        private readonly Ad ad;

        private Picture() {
            // For EF
        }
        public Picture(Ad ad, string? googleId, Description? description, int order, DateTime creationDate)
        {
            this.googleId = googleId;
            this.description = description;
            this.order = order;
            this.creationDate = creationDate;
            this.id = new TypedIdValueObject(Guid.NewGuid());
            this.ad = ad;
        }

        public void ChangeOrder(int order) => this.order = order;

        public void ChangeDescription(Description description) => this.description = description;

        public string? GoogleId => googleId;

        public int Order => order;

        public Description Description => description;

        public DateTime CreationDate { get => creationDate; }

        public TypedIdValueObject Id => id;

        public Ad Ad => ad;
    }
}
