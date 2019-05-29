using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public interface ITvDataService
    {
        Task<MovieData[]> GetIncompleteItemsAsync();
        Task<bool> AddTVDataAsync(MovieData movieData);
        MovieData Getdatabyid(String id);
    }
}
