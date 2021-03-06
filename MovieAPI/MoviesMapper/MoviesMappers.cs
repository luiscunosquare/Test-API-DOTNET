using AutoMapper;
using MovieAPI.Models;
using MovieAPI.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.MoviesMapper
{
    public class MoviesMappers : Profile
    {
        public MoviesMappers()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
