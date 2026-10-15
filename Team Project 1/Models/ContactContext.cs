using Microsoft.EntityFrameworkCore;

namespace Team_Project_1.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {
        }
        public DbSet<Contact> Contacts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Family" },
                new Category { CategoryId = 2, Name = "Friend" },
                new Category { CategoryId = 3, Name = "Work" }
            );

            modelBuilder.Entity<Contact>().HasData(
                new Contact
                {
                    ContactId = 1,
                    FirstName = "Claire",
                    LastName = "Koenigs",
                    Phone = "1111111111",
                    Email = "claire.koenigs@southeasttech.edu",
                    CategoryId = 1,
                    DateAdded = new DateTime(2026, 10, 03),
                },
                new Contact
                {
                    ContactId = 2,
                    FirstName = "Chris",
                    LastName = "Mejia",
                    Phone = "2222222222",
                    Email = "chris.mejia@southeasttech.edu",
                    CategoryId = 2,
                    DateAdded = new DateTime(2026, 09, 18),
                },
                new Contact
                {
                    ContactId = 3,
                    FirstName = "Huda",
                    LastName = "Judeh",
                    Phone = "3333333333",
                    Email = "huda.judeh@southeasttech.edu",
                    CategoryId = 3,
                    Organization = "Southeast Tech",
                    DateAdded = new DateTime(2026, 10, 01),
                });
        }
    }
}
