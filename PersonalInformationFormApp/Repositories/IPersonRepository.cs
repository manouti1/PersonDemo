using PersonalInformationFormApp.Models;

namespace PersonalInformationFormApp.Repositories
{
    public interface IPersonRepository
    {
        Task<IEnumerable<Person>> GetAll();
        Task<Person> GetPersonById(int id);
        Task DeletePerson(int id);
        Task SavePerson(Person p);
        Task UpdatePerson(Person person);
    }
}
