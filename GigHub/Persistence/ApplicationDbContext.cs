using GigHub.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHub.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<Following> Followings { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(x => x.Gig)
                .WithMany(x=>x.Attendances)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
               .HasMany(x => x.Followers)
               .WithRequired(x => x.Followee)
               .WillCascadeOnDelete(false);


            modelBuilder.Entity<ApplicationUser>()
               .HasMany(x => x.Followees)
               .WithRequired(x => x.Follower)
               .WillCascadeOnDelete(false);


            modelBuilder.Entity<UserNotification>()
               .HasRequired(x => x.User)
               .WithMany(x=>x.UserNotifications)
               .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}