using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class BlogTag : DomainEntity<int>
    {
        public BlogTag()
        {

        }
        public BlogTag(int blogId, string tagId)
        {
            BlogId = blogId;
            TagId = tagId;
        }

        public int BlogId { set; get; }
        public virtual Blog Blog { set; get; }

        public string TagId { set; get; }
        public virtual Tag Tag { set; get; }
    }
}