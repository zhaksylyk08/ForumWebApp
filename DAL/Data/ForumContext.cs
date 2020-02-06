using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class ForumContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ForumContext(DbContextOptions<ForumContext> options)
            : base(options)
        {

        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany<Post>(u => u.Posts)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Post>()
                .HasMany<Comment>(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            modelBuilder.Entity<User>()
                .HasMany<Comment>(u => u.Comments)
                .WithOne(c => c.Author)
                .HasForeignKey(c => c.AuthorId);

            modelBuilder.Entity<Community>()
                .HasMany<Post>(c => c.Posts)
                .WithOne(p => p.Community)
                .HasForeignKey(p => p.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>()
                .HasMany<Community>(category => category.Communities)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
