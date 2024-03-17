using App.DTOs;
using App.DTOS;
using Domain.FiltersDb;

namespace App.Services.Interfaces;

public interface IPersonService
{
    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO person);
    Task<ResultService<ICollection<PersonDTO>>> GetAsync();
    Task<ResultService<PersonDTO>> GetByIdAsync(int id);
    Task<ResultService<PersonDTO>> UpdetateAsync(PersonDTO person);
    Task<ResultService> DeleteAsync(int id);
    Task<ResultService<PagedBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilter);
}
