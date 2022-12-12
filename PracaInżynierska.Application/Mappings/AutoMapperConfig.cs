using AutoMapper;
using PracaInzynierska.Application.Dto;
using PracaInzynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInzynierska.Application.Mappings
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize()
           => new MapperConfiguration(cfg =>
           {
               cfg.CreateMap<UserDto, User>();
               cfg.CreateMap<User, UserDto>();
               cfg.CreateMap<Category, CategoryDto>();
               cfg.CreateMap<CategoryDto, Category>();
               cfg.CreateMap<AssetType, AssetTypeDto>();
               cfg.CreateMap<FinancialChange, FinancialChangeDto>();
               cfg.CreateMap<FinancialChangeDto, FinancialChange>();
           })
           .CreateMapper();
    }
}
