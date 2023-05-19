using BookStore.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Models.Book;
using BookStore.Data.Entity;
using BookStore.Models.Comment;

namespace BookStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserModel>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<BookEventEntity> BookEvents { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }

         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<CommentEntity>().HasOne(m => m.BookEvent)
            .WithMany(am => am.Comments).HasForeignKey(m => m.BookEventId)
            .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<CommentEntity>().HasOne(a => a.User)
            .WithMany(at => at.Comments).HasForeignKey(a => a.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(modelBuilder);

        }
    }
   
}
