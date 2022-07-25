using Microsoft.EntityFrameworkCore;
using StudyCircle.API.Models;

namespace StudyCircle.API.DataAccess
{
    public class StudyContext : DbContext
    {
        public StudyContext(DbContextOptions<StudyContext> options):base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(user => user.Subjects)
                .WithOne(topic => topic.UserAccount)
                .HasForeignKey(u => u.UserId);

            modelBuilder.Entity<StudyTopic>()
                .HasOne(subject => subject.UserAccount)
                .WithMany(user => user.Subjects);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<StudyTopic> StudyTopic { get; set; }
    }
}
