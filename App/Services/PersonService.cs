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

        if (!result.IsValid)
            return ResultService.RequestError<PersonDTO>("Problemas de validação", result);

        var person = _mapper.Map<Person>(personDTO);
        var data = await _personRepository.CreateAsync(person);
        var dto = _mapper.Map<PersonDTO>(data);
        //O motivo de passar o dto e não o person em si é para que o id seja preenchido no objeto de retorno, poise ele é gerado no banco
        return ResultService.Ok(dto);
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);
        if (person == null)
        {
            return ResultService.Fail<PersonDTO>("Pessoa não encontrada");
        }
        await _personRepository.DeleteAsync(person);
        return ResultService.Ok();
    }

    public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
    {

        var list = await _personRepository.GetPeopleAsync();
        var people = _mapper.Map<ICollection<PersonDTO>>(list);

        return ResultService.Ok(people);
    }

    public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
    {
        var dbperson = await _personRepository.GetByIdAsync(id);
        var person = _mapper.Map<PersonDTO>(dbperson);

        return ResultService.Ok(person);
    }

    public async Task<ResultService<PersonDTO>> UpdetateAsync(PersonDTO personDTO)
    {
        if (personDTO == null)
            return ResultService.Fail<PersonDTO>("Objeto deve ser informado");

        var validate = new PersonDTOValidator().Validate(personDTO);
        if (!validate.IsValid)
            return ResultService.RequestError<PersonDTO>("Problemas de validação", validate);

        var person = await _personRepository.GetByIdAsync(personDTO.Id);
        if (person == null)
            return ResultService.Fail<PersonDTO>("Pessoa não encontrada");

        person =_mapper.Map(personDTO, person);
        await _personRepository.UpdateAsync(person);

        return ResultService.Ok(personDTO);
    }
}
