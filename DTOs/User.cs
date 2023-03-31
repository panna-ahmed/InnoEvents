using System.ComponentModel.DataAnnotations;

namespace InnoEvents.DTOs
{
    public class User
    {
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
