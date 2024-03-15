using Domain.Entities;
using Domain.FiltersDb;
using Domain.Repositories;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.Repositories;

public class PersonRepository : IPersonRepository
{
    private readonly AppDbContext _context;

    public PersonRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<Person> CreateAsync(Person person)
    {
        _context.Add(person);
        await _context.SaveChangesAsync();
        return person;
    }
    
    public async Task DeleteAsync(Person person)
    {
        _context.Remove(person);
        await _context.SaveChangesAsync();
    }
    
    public async Task UpdateAsync(Person person)
    {
        _context.Update(person);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Person> GetByIdAsync(int id)
    {
        return await _context.People.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<IEnumerable<Person>> GetPeopleAsync()
    {
        return await _context.People.ToListAsync();
    }

    public async Task<int> GetIdByDocumentAsync(string document)
    {
        var query = _context.People.AsQueryable();

        query = query.Where(x => x.Document == document);

        var sql = query.ToQueryString();
        var person = query.FirstOrDefault();
        if (person == null)
        {
            return 0;
        }
        return person.Id;
       
    }

    public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb filter)
    {
        var people = await _context.People.ToListAsync();

        if (string.IsNullOrEmpty(filter.Name) == false)
        {
            people = people.Where(x => x.Name.Contains(filter.Name)).ToList();
        }

        return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(people.AsQueryable(), filter);

    }
}
