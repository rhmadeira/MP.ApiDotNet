﻿using App.DTOS;
using AutoMapper;
using Domain.Entities;

namespace App.Mappings;

public class DtoToDomainMapping : Profile
{

    public DtoToDomainMapping()
    {
        CreateMap<PersonDTO, Person>();
    }
    
}