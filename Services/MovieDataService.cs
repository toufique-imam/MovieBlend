using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Data;
using MovieBlend.Models;
using Microsoft.EntityFrameworkCore;
using Humanizer;
namespace MovieBlend.Services{
    public class MoviedataService : IMovieDataService{
        private readonly ApplicationDbContext _contextMV;
        public MoviedataService(ApplicationDbContext context){
            _contextMV=context;
        }

        public async Task<MovieData[]> GetIncompleteItemsAsync()
        {
            return await _contextMV.Movies
                .Where(x=>x.Catagoryx==Catagory.Movie)
                .ToArrayAsync();
        }
        public MovieData Getdatabyid(String id)
        {
            var xx = _contextMV.Movies.FirstOrDefault(x => x.Catagoryx == Catagory.Movie && x.Id.ToString() == id);

            return xx;
        }

        public async Task<bool> AddMovieDataAsync(MovieData movieData)
        {
            
            _contextMV.Movies.Add(movieData);
            var saveres = await _contextMV.SaveChangesAsync();
            return saveres == 1;
        }
    }
}