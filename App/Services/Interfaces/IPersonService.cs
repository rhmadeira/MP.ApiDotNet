using App.DTOS;

namespace App.Services.Interfaces;

public interface IPersonService
{

    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO person);

}
