using System.ComponentModel.DataAnnotations;

namespace InnoEvents.DTOs
{
    public class Event
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

    }
}
