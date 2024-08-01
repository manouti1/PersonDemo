using Microsoft.EntityFrameworkCore;
using PersonalInformationFormApp.Models;

namespace PersonalInformationFormApp.Data
{
    public class PersonDbContext : DbContext
    {
        public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options) { }
        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
