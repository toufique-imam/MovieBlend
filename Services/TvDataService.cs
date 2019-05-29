using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Data;
using MovieBlend.Models;
using Microsoft.EntityFrameworkCore;
using Humanizer;
namespace MovieBlend.Services
{
    public class TvdataService : ITvDataService
    {
        private readonly ApplicationDbContext _contexttv;
        public TvdataService(ApplicationDbContext context)
        {
            _contexttv = context;
        }

        public async Task<bool> AddTVDataAsync(MovieData movieData)
        {
            
            _contexttv.Movies.Add(movieData);
            var saveres = await _contexttv.SaveChangesAsync();
            return saveres == 1;
        }

        public MovieData Getdatabyid(string id)
        {
            var xx = _contexttv.Movies.FirstOrDefault(x => x.Catagoryx == Catagory.Tv && x.Id.ToString() == id);
            return xx;
        }

        public async Task<MovieData[]> GetIncompleteItemsAsync()
        {
            return await _contexttv.Movies
                .Where(x => x.Catagoryx==Catagory.Tv)
                .ToArrayAsync();
        }
    }
}