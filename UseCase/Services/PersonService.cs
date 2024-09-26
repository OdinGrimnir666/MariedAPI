using Core.Models;
using Infrastructure.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class PersonService(IMarriedContext _marriedContext) : IPersonService
{
    public async Task AddPersonAsync(List<Person> persons)
    {
        await _marriedContext.Person.AddRangeAsync(persons);
        await _marriedContext.SaveChangesAsync();
    }

    public async Task<List<Person>> GetPersonAsync()
    {
        return await _marriedContext.Person.AsNoTracking().ToListAsync();
    }

    public async Task DeletePersonAsync(string id)
    {
        var person = await _marriedContext.Person.FindAsync(id);
        _marriedContext.Person.Remove(person);
        await _marriedContext.SaveChangesAsync();

    }

    public async Task<Person> UpdatePersonAsync(Person person)
    {
        var personContext = await _marriedContext.Person.FindAsync(person.Id);
        personContext.Update(person);
        await _marriedContext.SaveChangesAsync();
        return personContext;
    }
}
