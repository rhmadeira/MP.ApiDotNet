using App.DTOs;
using App.DTOS;
using AutoMapper;
using Domain.Entities;

namespace App.Mappings;

public class DomainToDtoMapping : Profile
{
    public DomainToDtoMapping()
    {
        CreateMap<Person, PersonDTO>();
        CreateMap<Product, ProductDTO>();
        CreateMap<Purchase, PurchaseDTO>();
        CreateMap<Purchase, PurchaseDetailsDTO>()
            .ForMember(dest => dest.Person, opt => opt.Ignore())
            .ForMember(dest => dest.Product, opt => opt.Ignore())
            .ConstructUsing((model, context) =>
            {
                var dto = new PurchaseDetailsDTO
                {
                    Id = model.Id,
                    Product = model.Product.Name,
                    Person = model.Person.Name,
                    Date = model.Date,
                };
                return dto;
            });
    }
    
}
