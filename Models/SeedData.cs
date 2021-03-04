using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Chosen",
                        ReleaseDate = DateTime.Parse("2017-12-24"),
                        Genre = "Historical Drama",
                        Price = 0.00M,
                        Rating = "TV-PG"
                    },

                    new Movie
                    {
                        Title = "Ephraim's Rescue",
                        ReleaseDate = DateTime.Parse("2013-5-31"),
                        Genre = "Historical Drama, Adventure",
                        Price = 15.99M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = "Documentary",
                        Price = 1.85M,
                        Rating = "PG"
                    },

                    new Movie
                    {
                        Title = "The Cokeville Miracle",
                        ReleaseDate = DateTime.Parse("2015-6-5"),
                        Genre = "Historical Drama",
                        Price = 8.87M,
                        Rating = "PG-13"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}