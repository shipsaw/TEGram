using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Photo>()
                .Property(p => p.CreatedDate)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("GETUTCDATE()");

            //builder.Entity<User>()
            //    .HasMany(u => u.UserLikes)
            //    .WithMany(u => u.PhotoLikes)
            //    .UsingEntity(j => j.ToTable("PhotoUser"));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
