using System;
using System.Collections.Generic;

namespace EventManagementSystem.Models
{
    public partial class Event
    {
        public Event()
        {
            EventRegistrations = new HashSet<EventRegistration>();
        }

        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Location { get; set; }
        public int? MaxAttendees { get; set; }
        public decimal? RegistrationFee { get; set; }
        public int? OrganizerId { get; set; }

        public virtual Organizer? Organizer { get; set; }
        public virtual ICollection<EventRegistration> EventRegistrations { get; set; }
    }
}
