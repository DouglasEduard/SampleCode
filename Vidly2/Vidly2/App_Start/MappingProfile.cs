using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly2.Models;
using Vidly2.DTOs;

namespace Vidly2.App_Start
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>();

            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>();

            Mapper.CreateMap<MembershipTypeDto, MembershipType>();
            Mapper.CreateMap<MembershipType, MembershipTypeDto>();

            Mapper.CreateMap<GenreDto, Genre>();
            Mapper.CreateMap<Genre, GenreDto>();
        }
    }
}