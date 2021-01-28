using Domain.Core;

namespace Domain.Ads.Ad.Pictures
{
    public class Picture : Entity
    {
        private readonly string? googleId;
        private Description? description;
        private int order;

        public Picture(string? googleId, Description? description, int order)
        {
            this.googleId = googleId;
            this.description = description;
            this.order = order;
        }

        public void ChangeOrder(int order) => this.order = order;

        public void ChangeDescription(Description description) => this.description = description;

        public string? GoogleId => googleId;

        public int Order => order;

        public Description? Description => description;
    }
}
