using AutoMapper;
using certificacaoaspnet.Dtos;
using certificacaoaspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace certificacaoaspnet.App_Start
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Customer, CustomerDto>();
            Mapper.CreateMap<CustomerDto, Customer>().ForMember(m => m.Id, x => x.Ignore());
            Mapper.CreateMap<Movie, MovieDto>();
            Mapper.CreateMap<MovieDto, Movie>().ForMember(m => m.Id, x => x.Ignore());

            Mapper.CreateMap<MembershipType, MembershipTypeDto>();
            Mapper.CreateMap<Genres, GenresDto>();
        }
    }
}