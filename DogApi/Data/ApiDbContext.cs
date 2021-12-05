using DogApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogApi.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext>options) : base(options)
        {

        }

        public DbSet<Dog> Dogs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            builder.Entity<Dog>(entity => {
                entity.HasIndex(e => e.Name).IsUnique();
            });

            builder.Entity<Dog>().HasData(
                new Dog
                {
                    Id = 1,
                    Name = "Neo",
                    Color = "red & amber",
                    Tail_length = 22,
                    Weight = 32
                },
                  new Dog
                  {
                      Id = 2,
                      Name = "Geo",
                      Color = "white & amber",
                      Tail_length = 40,
                      Weight = 20
                  },
                    new Dog
                    {
                        Id = 3,
                        Name = "Rio",
                        Color = "black & white",
                        Tail_length = 28,
                        Weight = 37
                    },
                      new Dog
                      {
                          Id = 4,
                          Name = "Dj",
                          Color = "white",
                          Tail_length = 10,
                          Weight = 19
                      },
                     new Dog
                     {
                         Id = 5,
                         Name = "Jessy",
                         Color = "black",
                         Tail_length = 17,
                         Weight = 5
                     },
                      new Dog
                      {
                          Id = 6,
                          Name = "Dory",
                          Color = "gray",
                          Tail_length = 12,
                          Weight = 16
                      },
                       new Dog
                       {
                           Id = 7,
                           Name = "Nora",
                           Color = "gold",
                           Tail_length = 32,
                           Weight = 30
                       },
                        new Dog
                        {
                            Id = 8,
                            Name = "Pedro",
                            Color = "gray & white",
                            Tail_length = 47,
                            Weight = 4
                        },
                         new Dog
                         {
                             Id = 9,
                             Name = "Pongo",
                             Color = "yellow",
                             Tail_length = 37,
                             Weight = 16
                         },
                          new Dog
                          {
                              Id = 10,
                              Name = "Z",
                              Color = "white",
                              Tail_length = 47,
                              Weight = 10
                          }
                );
        }
    }
}
