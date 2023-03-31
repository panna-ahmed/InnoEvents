using System.ComponentModel.DataAnnotations.Schema;

namespace InnoEvents.DTOs
{
    public class UserEvent
    {
        public int UserId { get; set; }
        
        public int EventId { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
