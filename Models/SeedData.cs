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
            Console.WriteLine("seed initialize");
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    Console.WriteLine("movies exist in DB");
                    return;   // DB has been seeded
                }

                Console.WriteLine("movies don't exist in DB");
                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "The Chosen",
                        ReleaseDate = DateTime.Parse("2017-12-24"),
                        Genre = "Historical Drama",
                        Price = 1.00M,
                        Rating = "TV-PG",
                        ImageUrl = "https://i2.wp.com/www.kevinhalloran.net/wp-content/uploads/2020/05/maxresdefault.jpg"
                    },

                    new Movie
                    {
                        Title = "Ephraim's Rescue",
                        ReleaseDate = DateTime.Parse("2013-5-31"),
                        Genre = "Historical Drama",
                        Price = 15.99M,
                        Rating = "PG",
                        ImageUrl = "https://resizing.flixster.com/EVwsQg_QPQXWjb0_NXSQz1OZOLQ=/300x300/v2/https://flxt.tmsimg.com/assets/p9975618_v_h9_aa.jpg"
                    },

                    new Movie
                    {
                        Title = "Meet the Mormons",
                        ReleaseDate = DateTime.Parse("2014-10-10"),
                        Genre = "Documentary",
                        Price = 1.85M,
                        Rating = "PG",
                        ImageUrl = "https://static.tumblr.com/qur1lcd/PXWnak3kc/social_image.jpg"
                    },

                    new Movie
                    {
                        Title = "The Cokeville Miracle",
                        ReleaseDate = DateTime.Parse("2015-6-5"),
                        Genre = "Historical Drama",
                        Price = 8.87M,
                        Rating = "PG-13",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/f/ff/Thecokevillemiracleposter.jpg/220px-Thecokevillemiracleposter.jpg"
                    },

                    new Movie
                    {
                        Title = "The Best Two Years",
                        ReleaseDate = DateTime.Parse("2003-1-1"),
                        Genre = "Comedy",
                        Price = 19.65M,
                        Rating = "PG",
                        ImageUrl = "https://images-na.ssl-images-amazon.com/images/I/515H97tpKAL._AC_.jpg"
                    },

                    new Movie
                    {
                        Title = "God's Not Dead",
                        ReleaseDate = DateTime.Parse("2014-3-21"),
                        Genre = "Inspirational",
                        Price = 5.00M,
                        Rating = "PG",
                        ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/cf/God%27s_Not_Dead.jpg"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}