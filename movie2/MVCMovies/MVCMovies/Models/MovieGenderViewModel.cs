using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVCMovies.Models
{
    public class MovieGenderViewModel
    {
        public List<Movie>? Movies { get; set; }
        public SelectList? Genders { get; set; }
        public string? GenderTitle { get; set; }
        public string? SearchString { get; set; }


    }
}
