using Domain.Entities;
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
}
