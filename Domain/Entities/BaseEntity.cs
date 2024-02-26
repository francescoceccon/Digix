using Domain.Enums;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public abstract class BaseEntity
    {
        [JsonIgnore]
        public Guid Id { get { return Guid.NewGuid(); } private set { } }
        public DateTime UpdateAt { get; set; }
        public DateTime CreateAt { get; set; }
        public Status Status { get; set; }
    }
}
