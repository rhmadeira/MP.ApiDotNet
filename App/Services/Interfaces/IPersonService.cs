using App.DTOS;

namespace App.Services.Interfaces;

internal interface IPersonService
{

    Task<ResultService<PersonDTO>> CreateAsync(PersonDTO person);

}
