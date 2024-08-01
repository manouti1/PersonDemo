using Microsoft.EntityFrameworkCore;
using PersonalInformationFormApp.Data;
using PersonalInformationFormApp.Models;

namespace PersonalInformationFormApp.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public readonly PersonDbContext dbContext;
        public PersonRepository(PersonDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SavePerson(Person p)
        {
            await this.dbContext.People.AddAsync(p);
            await this.dbContext.SaveChangesAsync();
        }

        public async Task DeletePerson(int id)
        {
            var person = this.dbContext.People.Find(id);
            if (person != null)
            {
                this.dbContext.People.Remove(person);
                await this.dbContext.SaveChangesAsync();
            }
        }

        public async Task<Person> GetPersonById(int id)
        {
            return await this.dbContext.People.FindAsync(id);
        }

        public async Task UpdatePerson(Person person)
        {
            var existing = this.dbContext.People.Find(person.Id);
            if (existing != null)
            {
                existing.Name = person.Name;
                existing.EmailAddress = person.EmailAddress;
                existing.Gender = person.Gender;
                existing.IsAcknowledged = person.IsAcknowledged;
                existing.IsCurrentlyWorking = person.IsCurrentlyWorking;
                existing.CompanyName = person.CompanyName;

                this.dbContext.Entry(existing).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        public async Task<IEnumerable<Person>> GetAll()
        {
            return await this.dbContext.People.ToListAsync();
        }
    }
}
