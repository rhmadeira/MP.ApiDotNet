using App.DTOS;
using AutoMapper;
using Domain.Entities;

namespace App.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Person, PersonDTO>();
    }
    
}
