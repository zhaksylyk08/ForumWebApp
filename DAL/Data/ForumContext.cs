using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

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
        public DbSet<UserCommunity> UserCommunities { get; set; }

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

            modelBuilder.Entity<UserCommunity>().HasKey(uc => new { uc.UserId, uc.CommunityId });

            modelBuilder.Entity<UserCommunity>()
                .HasOne<User>(uc => uc.User)
                .WithMany(u => u.SubscribedCommunities)
                .HasForeignKey(uc => uc.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserCommunity>()
                .HasOne<Community>(uc => uc.Community)
                .WithMany(u => u.Members)
                .HasForeignKey(uc => uc.CommunityId)
                .OnDelete(DeleteBehavior.Restrict);

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
