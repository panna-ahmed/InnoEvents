using System.ComponentModel.DataAnnotations;

namespace InnoEvents.DTOs
{
    public class CreateEvent
    {
        [StringLength(200)]
        public string Name { get; set; }
        public int ContactUserId { get; set; }
        public string Location { get; set; }
        public DateTime? Time { get; set; }
    }
}
