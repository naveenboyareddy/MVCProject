using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly1.Models;
using Vidly1.Dtos;

namespace Vidly1.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, customer>().ForMember(c => c.id, opt => opt.Ignore());
            Mapper.CreateMap<Movie, MovieDtos>();
            Mapper.CreateMap<MovieDtos, Movie>().ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}