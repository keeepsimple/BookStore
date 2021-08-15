using BookStore.Models.BaseEntities;
using BookStore.Models.Common;
using BookStore.Models.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Data
{
    public class BookStoreContext : IdentityDbContext<User>
    {
        public BookStoreContext() : base("BookStoreCnn")
        {
        }

        static BookStoreContext()
        {
            Database.SetInitializer<BookStoreContext>(new DbInitializer());
        }

        public static BookStoreContext Create()
        {
            return new BookStoreContext();
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>()
                .HasMany(x => x.Authors)
                .WithMany(a => a.Books)
                .Map(m =>
                    {
                        m.MapLeftKey("BookId");
                        m.MapRightKey("AuthorId");
                        m.ToTable("BookAuthor", "Common");
                    });
        }

        public override int SaveChanges()
        {
            BeforeSaveChanges();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync()
        {
            BeforeSaveChanges();
            return await base.SaveChangesAsync();
        }

        private void BeforeSaveChanges()
        {
            var entities = this.ChangeTracker.Entries();
            foreach (var entry in entities)
            {
                if (entry.Entity is IBaseEntity entityBase)
                {
                    switch (entry.State)
                    {
                        case EntityState.Modified: entityBase.UpdatedAt = DateTime.Now; break;
                        case EntityState.Added:
                            entityBase.UpdatedAt = DateTime.Now;
                            entityBase.InsertedAt = DateTime.Now;
                            break;
                    }
                }
            }
        }
    }
}
