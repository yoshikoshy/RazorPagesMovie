using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace RazorPagesMovie.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<RazorPagesMovieContext>>()))
                {
                //Look for any movies.
                if (context.Movie.Any())
                {
                    return; //db has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Rush Hour",
                        ReleaseDate = DateTime.Parse("1998-9-18"),
                        Genre = "Action",
                        Price = 7.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "Frozen",
                        ReleaseDate = DateTime.Parse("2013-11-27"),
                        Genre = "Fantasy",
                        Price = 9.99M,
                        Rating = "PG"
                    },
                    new Movie
                    {
                        Title = "Ad Astra",
                        ReleaseDate = DateTime.Parse("2019-9-18"),
                        Genre = "Drama",
                        Price = 14.99M,
                        Rating = "R"
                    },
                    new Movie
                    {
                        Title = "A Quiet Place",
                        ReleaseDate = DateTime.Parse("2018-4-6"),
                        Genre = "Drama",
                        Price = 12.99M,
                        Rating = "R"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
