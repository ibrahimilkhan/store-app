using System;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using StoreApp.Infrastructure.Resolver;

namespace StoreApp.Infrastructure.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<ProductDtoForInsertion, Product>();
        CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

        CreateMap<Product, ProductDtoForView>()
            .ForMember(dest => dest.CategoryName,
                       opt => opt.MapFrom<CategoryNameResolver>());
    }
}