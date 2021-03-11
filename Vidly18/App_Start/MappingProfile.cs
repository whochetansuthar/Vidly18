using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using Vidly18.Dtos;
using Vidly18.Models;

namespace Vidly18.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //dtos to domain
            Mapper.CreateMap<CustomerDto,Customer>();
            Mapper.CreateMap<MovieDto,Movie>();

            //domain to dtos
            Mapper.CreateMap<Customer,CustomerDto>();
            Mapper.CreateMap<Movie,MovieDto>();
            Mapper.CreateMap<MembershipType,MembershipTypeDto>();
            Mapper.CreateMap<Genre,GenreDto>();
        }
    }
}