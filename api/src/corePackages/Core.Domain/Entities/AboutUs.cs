using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class AboutUs : Entity
    {
        public string TitleKey { get; set; }
        public string Title { get; set; }
        public string ContentKey { get; set; }
        public string Content { get; set; }

        public AboutUs()
        {

        }

        public AboutUs(Guid id, string contentKey, string content, string titleKey, string title)
        {
            Id = id;
            ContentKey = contentKey;
            Content = content;
            TitleKey = titleKey;
            Title = title;
        }
    }
}
