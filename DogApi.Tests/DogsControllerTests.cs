using AutoMapper;
using DogApi.Configurations;
using DogApi.Controllers;
using DogApi.Data;
using DogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace DogsApi.Tests
{

    public class DogsControlerTests
    {
        private readonly IMapper _mapper;

        public DogsControlerTests()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MapperInitilizer());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            var options = new DbContextOptionsBuilder<ApiDbContext>()
      .UseInMemoryDatabase(databaseName: "DogsDb")
      .Options;


            // Insert seed data into the database using one instance of the context
            using (var context = new ApiDbContext(options))
            {
                context.Dogs.Add(new Dog
                {
                    Id = 1,
                    Name = "Neo",
                    Color = "red & amber",
                    Tail_length = 22,
                    Weight = 32
                });
                context.Dogs.Add(new Dog
                {
                    Id = 2,
                    Name = "Geo",
                    Color = "white & amber",
                    Tail_length = 40,
                    Weight = 20
                });
                context.Dogs.Add(new Dog
                {
                    Id = 3,
                    Name = "Rio",
                    Color = "black & white",
                    Tail_length = 28,
                    Weight = 37
                });

                context.SaveChanges();
            }

        }



        [Fact]
        public async Task GetDogs_Id_desc_returns_3()
        {
            // If i call the GetDogs method, should return dogs in desc order according to the Id attribute
            // the first element would be the one with Id of 3

            var options = new DbContextOptionsBuilder<ApiDbContext>()
           .UseInMemoryDatabase(databaseName: "DogsDb")
           .Options;


            using (var _dbContext = new ApiDbContext(options))
            {
                var controller = new DogsController(_dbContext, _mapper);
                var result = (await controller.GetDogs(1, 10, "Id", "desc")) as OkObjectResult;

                Assert.NotNull(result);
                IEnumerable<Dog> dogs = result.Value as IEnumerable<Dog>;

                var enumerator = dogs.GetEnumerator();
                enumerator.MoveNext();

                Assert.Equal(3, enumerator.Current.Id);

            }

        } 
        
        [Fact]
        public async Task GetDogs_Id_asc_returns_1()
        {
            // If i call the GetDogs method, should return dogs in asc order according to the Id attribute
            // the first element would be the one with Id of 1

            var options = new DbContextOptionsBuilder<ApiDbContext>()
           .UseInMemoryDatabase(databaseName: "DogsDb")
           .Options;


            using (var _dbContext = new ApiDbContext(options))
            {
                var controller = new DogsController(_dbContext, _mapper);
                var result = (await controller.GetDogs(1, 10, "Id", "asc")) as OkObjectResult;

                Assert.NotNull(result);
                IEnumerable<Dog> dogs = result.Value as IEnumerable<Dog>;

                var enumerator = dogs.GetEnumerator();
                enumerator.MoveNext();

                Assert.Equal(1, enumerator.Current.Id);

            }

        }



        [Fact]
        public async Task Post_dog_returnsStatus_201()
        {
             

            var options = new DbContextOptionsBuilder<ApiDbContext>()
           .UseInMemoryDatabase(databaseName: "DogsDb")
           .Options;


            using (var _dbContext = new ApiDbContext(options))
            {
                var controller = new DogsController(_dbContext, _mapper);
                var result = (await controller.Post(new CreateDog
                {                    
                    Name = "Test",
                    Color = "black",
                    Tail_length = 28,
                    Weight = 37
                }) as StatusCodeResult);

                Assert.Equal("201",result.StatusCode.ToString());
                 

            }

        }


    }
}
