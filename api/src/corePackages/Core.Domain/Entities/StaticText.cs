using Core.Domain.Entities.Base;

namespace Core.Domain.Entities
{
    public class StaticText : Entity
    {
        public string DescriptionKey { get; set; }
        public string? Description { get; set; }

        public StaticText()
        {

        }

        public StaticText(Guid id, string descriptionKey, string? description)
        {
            Id = id;
            DescriptionKey = descriptionKey;
            Description = description;
        }
    }
}
