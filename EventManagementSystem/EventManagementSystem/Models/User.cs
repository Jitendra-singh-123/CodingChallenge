using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public partial class User
    {
        public User()
        {
            EventRegistrations = new HashSet<EventRegistration>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FullName { get; set; }
        public string? PhoneNumber { get; set; }
        public string Role { get; set; } = null!;

        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}
