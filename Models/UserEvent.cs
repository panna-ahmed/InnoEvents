using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoEvents.Models
{
    [PrimaryKey("UserId", "EventId")]
    public class UserEvent
    {        
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int EventId { get; set; }

        [ForeignKey("EventId")]
        public virtual Event Event { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
