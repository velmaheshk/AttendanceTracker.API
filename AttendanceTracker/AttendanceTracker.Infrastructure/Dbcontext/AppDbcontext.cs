
using Microsoft.EntityFrameworkCore;
using AttendanceTracker.Domain;
using AttendanceTracker.Domain.Entity;

namespace AttendanceTracker.Infrastructure
{
    public class AppDbcontext : DbContext
    {
        public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options) { }
        public DbSet<Role> Role { get; set; }
        public DbSet<Attendance> Attendance { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserDetails> UserDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationship 1: Student
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.user)                         //Navigation Property present in the Attendence Entries  model class
                .WithMany(u => u.Attendances)                // Navigation property present in the User model class 
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Relationship 2: Recorded By
            modelBuilder.Entity<User>()
                .HasOne(a => a.Role)                 //Navigation Property present in the Attendence Entries  model class
                .WithMany(u => u.Users)        // Navigation property present in the User model class 
                .HasForeignKey(a => a.RoleID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserDetails>()
                .HasOne(a => a.user)
                .WithMany(u => u.UserDetails)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.user)
                .WithMany(u => u.Attendances)
                .HasForeignKey(a => a.UserID)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}