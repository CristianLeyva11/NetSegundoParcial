using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MVCMovies.Data;
using MVCMovies.Models;
using System;
using System.Linq;


namespace MvcMovies.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MVCMoviesContext(
        serviceProvider.GetRequiredService<
                DbContextOptions<MVCMoviesContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "When Harry Met Sally",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Gender = "Romantic Comedy",
                    Price = 7.99M,
                    Rating = "A"
                },
                new Movie
                {
                    Title = "Ghostbusters ",
                    ReleaseDate = DateTime.Parse("1984-3-13"),
                    Gender = "Comedy",
                    Price = 8.99M,
                    Rating = "A"
                },
                new Movie
                {
                    Title = "Ghostbusters 2",
                    ReleaseDate = DateTime.Parse("1986-2-23"),
                    Gender = "Comedy",
                    Price = 9.99M,
                    Rating = "A"
                },
                new Movie
                {
                    Title = "Rio Bravo",
                    ReleaseDate = DateTime.Parse("1959-4-15"),
                    Gender = "Western",
                    Price = 3.99M,
                    Rating = "A"
                }
            );
            context.SaveChanges();
        }
    }
}