using NUShop.Infrastructure.Shared;

namespace NUShop.Data.Entities
{
    public class Footer : DomainEntity<string>
    {
        public Footer()
        {

        }
        public Footer(string content)
        {
            Content = content;
        }

        public string Content { set; get; }
    }
}
