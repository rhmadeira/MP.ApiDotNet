﻿using Domain.Entities;
using Domain.FiltersDb;

namespace Domain.Repositories;

public interface IPersonRepository
{
    Task<Person> GetByIdAsync(int id);
    Task<IEnumerable<Person>> GetPeopleAsync();
    Task<Person> CreateAsync(Person person);
    Task UpdateAsync(Person person);
    Task DeleteAsync(Person person);
    Task<int> GetIdByDocumentAsync(string document);
    Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb filter);
}
