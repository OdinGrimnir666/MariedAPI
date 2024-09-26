using Core.Models;

namespace Infrastructure.Intefaces;

public interface IPersonService
{
    Task AddPersonAsync(List<Person> persons);
    Task<List<Person>> GetPersonAsync();
    Task DeletePersonAsync(string id);
    Task<Person> UpdatePersonAsync(Person person);


}