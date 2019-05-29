using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public interface IMovieDataService
    {
        MovieData Getdatabyid(String id);
        Task<MovieData[]> GetIncompleteItemsAsync();
        Task<bool> AddMovieDataAsync(MovieData movieData);
    }
}
