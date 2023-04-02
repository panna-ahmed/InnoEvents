using System.ComponentModel.DataAnnotations;

namespace InnoEvents.DTOs
{
    public class Event
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public string Location { get; set; }
        public DateTime? Time { get; set; }

        public int ContactUserId { get; set; }

        public User ContactUser { get; set; }
    }
}
