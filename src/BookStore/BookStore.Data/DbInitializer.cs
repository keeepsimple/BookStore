using BookStore.Models.Common;
using BookStore.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Data
{
    internal class DbInitializer : DropCreateDatabaseIfModelChanges<BookStoreContext>
    {
        protected override void Seed(BookStoreContext context)
        {
            base.Seed(context);
            var categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 01",
                    Description = "This is category 01"
                }, 
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 02",
                    Description = "This is category 02"
                }, 
                new Category()
                {
                    Id = Guid.NewGuid(),
                    Name = "Category 03",
                    Description = "This is category 03"
                }
            };
            context.Categories.AddRange(categories);

            var publishers = new List<Publisher>()
            {
                new Publisher
                {
                    Id = Guid.NewGuid(),
                    Name = "Publisher 01",
                    Description = "This is publisher 01"
                },
                new Publisher
                {
                    Id = Guid.NewGuid(),
                    Name = "Publisher 03",
                    Description = "This is publisher 03"
                },
                new Publisher
                {
                    Id = Guid.NewGuid(),
                    Name = "Publisher 03",
                    Description = "This is publisher 03"
                }
            };
            context.Publishers.AddRange(publishers);

            var book1 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Book 01",
                Summary = "This is book 01",
                ImageUrl = "book01.jpg",
                Price = 10M,
                Quantity = 100,
                IsActive = true,
                Category = categories.Single(c=>c.Name == categories[0].Name),
                Publisher = publishers.Single(p=>p.Name == publishers[0].Name)
            };

            var book2 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Book 02",
                Summary = "This is book 02",
                ImageUrl = "book02.jpg",
                Price = 20M,
                Quantity = 200,
                IsActive = true,
                Category = categories.Single(c => c.Name == categories[1].Name),
                Publisher = publishers.Single(p => p.Name == publishers[1].Name)
            };

            var book3 = new Book
            {
                Id = Guid.NewGuid(),
                Title = "Book 03",
                Summary = "This is book 03",
                ImageUrl = "book03.jpg",
                Price = 30M,
                Quantity = 300,
                IsActive = true,
                Category = categories.Single(c => c.Name == categories[3].Name),
                Publisher = publishers.Single(p => p.Name == publishers[3].Name)
            };

            var authors = new List<Author>()
            {
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Author 01",
                    Description = "This is Author 01",
                    Books = new List<Book>(){book1, book2}
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Author 02",
                    Description = "This is Author 02",
                    Books = new List<Book>(){book3}
                },
                new Author
                {
                    Id = Guid.NewGuid(),
                    Name = "Author 03",
                    Description = "This is Author 03",
                    Books = new List<Book>(){book1, book2, book3}
                }
            };
            context.Authors.AddRange(authors);

            var reviews = new List<Review>()
            {
                new Review
                {
                    Id = Guid.NewGuid(),
                    Name = "Reviewer 01",
                    Content = "This is reviewer 01",
                    IsActive = true,
                    BookId = book1.Id
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    Name = "Reviewer 02",
                    Content = "This is reviewer 02",
                    IsActive = true,
                    BookId = book2.Id
                },
                new Review
                {
                    Id = Guid.NewGuid(),
                    Name = "Reviewer 03",
                    Content = "This is reviewer 03",
                    IsActive = true,
                    BookId = book3.Id
                }
            };
            context.Reviews.AddRange(reviews);

            context.SaveChanges();
        }

        public static void InitializeIdentity(BookStoreContext db)
        {
            var userManager = new UserManager<User>(new UserStore<User>(db));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            const string name = "admin@example.com";
            const string password = "Admin@123456";
            const string roleName = "Admin";

            //Create Role Admin if it does not exist
            var role = roleManager.FindByName(roleName);
            if (role == null)
            {
                role = new IdentityRole(roleName);
                var roleResult = roleManager.Create(role);
            }

            var user = userManager.FindByName(name);
            if (user == null)
            {
                user = new User { UserName = name, Email = name };
                var result = userManager.Create(user, password);
                result = userManager.SetLockoutEnabled(user.Id, false);
            }

            // Add user admin to Role Admin if not already added
            var rolesForUser = userManager.GetRoles(user.Id);
            if (!rolesForUser.Contains(role.Name))
            {
                var result = userManager.AddToRole(user.Id, role.Name);
            }
        }
    }
}