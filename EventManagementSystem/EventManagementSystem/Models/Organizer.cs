using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public partial class Organizer
    {
        public Organizer()
        {
            Events = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string PasswordHash { get; set; } = null!;
        public string Role { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
