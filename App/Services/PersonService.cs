using App.DTOs.Validations;
using App.DTOS;
using App.Services.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Repositories;

namespace App.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;
    
    public PersonService(IMapper mapper, IPersonRepository personRepository)
    {
        _mapper = mapper;
        _personRepository = personRepository;
    }
    
    public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
    {
        if (personDTO == null)
            return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

        var result = new PersonDTOValidator().Validate(personDTO);

        if(!result.IsValid)
            return ResultService.RequestError<PersonDTO>("Problemas de validação", result);

        var person = _mapper.Map<Person>(personDTO);

        var data = await _personRepository.CreateAsync(person);

        return ResultService.Ok(_mapper.Map<PersonDTO>(data));

    }
    
}
