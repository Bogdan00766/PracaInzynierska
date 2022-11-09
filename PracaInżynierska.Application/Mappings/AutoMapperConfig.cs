using AutoMapper;
using PracaInżynierska.Application.Dto;
using PracaInżynierska.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracaInżynierska.Application.Mappings
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
           })
           .CreateMapper();
    }
}
