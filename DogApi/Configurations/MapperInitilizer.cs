using AutoMapper;
using DogApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Configurations
{
    public class MapperInitilizer: Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Dog, CreateDog>().ReverseMap();
          
        }
    }
}
