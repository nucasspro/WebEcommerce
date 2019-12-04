using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class Slide : DomainEntity<int>
    {
        public Slide()
        {
        }

        public Slide(string name, string description, string image, string url, 
            int? displayOrder, bool status, string content, string groupAlias)
        {
            Name = name;
            Description = description;
            Image = image;
            Url = url;
            DisplayOrder = displayOrder;
            Status = status;
            Content = content;
            GroupAlias = groupAlias;
        }

        public string Name { set; get; }
        public string Description { set; get; }
        public string Image { set; get; }
        public string Url { set; get; }
        public int? DisplayOrder { set; get; }
        public bool Status { set; get; }
        public string Content { set; get; }
        public string GroupAlias { get; set; }
    }
}