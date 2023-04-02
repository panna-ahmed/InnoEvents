using System.ComponentModel.DataAnnotations;

namespace InnoEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public string Location { get; set; }
        public DateTime? Time { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int ContactUserId { get; set; }

        public virtual IList<UserEvent> EventUsers { get; set; }

    }
}
