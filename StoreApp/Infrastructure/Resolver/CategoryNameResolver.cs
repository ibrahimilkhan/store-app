using System;
using AutoMapper;
using Entities.Dtos;
using Entities.Models;
using Repositories;
using Services.Contracts;
using Services.Managers;

namespace StoreApp.Infrastructure.Resolver;

public class CategoryNameResolver : IValueResolver<Product, ProductDtoForView, string>
{
    private readonly IServiceManager _manager;

    public CategoryNameResolver(IServiceManager manager)
    {
        _manager = manager;
    }

    public string Resolve(Product source, ProductDtoForView destination, string destMember, ResolutionContext context)
    {
        int id = source.CategoryId ?? 0;
        var category = _manager.CategoryService.GetCategory(id, false);
        return category?.Name ?? "";
    }
}
