using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        public int Id { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType Type { get; set; }

        public DateTime? OrginalDateTime { get; set; }

        public string OrginalVenue { get; set; }

        [Required]
        public Gig Gig { get; set; }
    }
}