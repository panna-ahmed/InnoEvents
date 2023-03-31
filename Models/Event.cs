﻿using System.ComponentModel.DataAnnotations;

namespace InnoEvents.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public virtual IList<UserEvent> EventUsers { get; set; }

    }
}