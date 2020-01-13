using System;
using System.ComponentModel.DataAnnotations;

namespace GigHub.Models
{
    public class Notification
    {
        protected Notification()
        {

        }

        public Notification(NotificationType type,Gig gig)
        {
            if (gig == null)
                throw new ArgumentNullException();
            Type = type;
            Gig = gig;
            DateTime = DateTime.Now;
        }


        public int Id { get; private set; }

        public DateTime DateTime { get; private set; }

        public NotificationType Type { get; private set; }

        public DateTime? OrginalDateTime { get; set; }

        public string OrginalVenue { get; set; }

        [Required]
        public Gig Gig { get; private set; }
    }
}