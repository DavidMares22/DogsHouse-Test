using AutoMapper;
using DogApi.Data;
using DogApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DogsController : ControllerBase
    {

        private ApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public DogsController(ApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // GET: /dogs
        [HttpGet]
        public async Task<IActionResult> GetDogs(int? pageNumber, int? pageSize, string? attribute, string? order)
        {

            int currentPageNumber = pageNumber ?? 1;
            int currentPageSize = pageSize ?? 5;
            string sortAttribute = attribute ?? String.Empty;
            string sortOrder = order ?? "desc";

            try
            {

                List<Dog> Dogs = await _dbContext.Dogs.ToListAsync();
                                  
                var results = Dogs.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize);

                switch (sortAttribute.ToLower())
                {
                    case "color":
                        results = sortOrder=="desc"? results.OrderByDescending(c => c.Color): results.OrderBy(c => c.Color);
                        break;
                    case "name":
                        results = sortOrder == "desc" ? results.OrderByDescending(c => c.Name): results.OrderBy(c => c.Name);
                        break;
                    case "weight":
                        results = sortOrder == "desc" ? results.OrderByDescending(c => c.Weight) : results.OrderBy(c => c.Weight);
                        break;
                    case "tail_length":
                        results = sortOrder == "desc" ? results.OrderByDescending(c => c.Tail_length) : results.OrderBy(c => c.Tail_length);
                        break;
                    default:
                        results = sortOrder == "desc" ? results.OrderByDescending(c => c.Id) : results.OrderBy(c => c.Id);
                        break;
                }
                return Ok(results);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }

       

        // POST api/<DogsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateDog createDog)
        {

            try
            {
                var dog = _mapper.Map<Dog>(createDog);
                await _dbContext.Dogs.AddAsync(dog);
                await _dbContext.SaveChangesAsync();
                return StatusCode(201);    
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Server Error. Please try again later");
            }
        }
 
    }
}
