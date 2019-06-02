using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Data;
using MovieBlend.Models;
using Microsoft.EntityFrameworkCore;
using Humanizer;
namespace MovieBlend.Services{
    public class PostdataService : IPostDataService{
        private readonly ApplicationDbContext _contextMV;
        public PostdataService(ApplicationDbContext context){
            _contextMV=context;
        }

        public async Task<MovieData[]> GetIncompleteItemsAsync_Movie()
        {
            return await _contextMV.PostData
                .Where(x=>x.Catagoryx==Catagory.Movie && x._Privacy==Privacy.Public)
                .ToArrayAsync();
        }
        public async Task<MovieData[]> GetIncompleteItemsAsync_TV()
        {
            return await _contextMV.PostData
                .Where(x=>x.Catagoryx==Catagory.Tv && x._Privacy==Privacy.Public)
                .ToArrayAsync();
        }
        public async Task<MovieData[]> GetIncompleteItemsAsync_Private(String id)
        {
            return await _contextMV.PostData
                .Where(x=>x._Privacy==Privacy.Private && x.PosterId==id)
                .ToArrayAsync();
        }
        public MovieData Getdatabyid(String id)
        {
            var xx = _contextMV.PostData.FirstOrDefault(x => x.Catagoryx == Catagory.Movie && x.Id.ToString() == id);

            return xx;
        }

        public async Task<bool> AddPostDataAsync(MovieData movieData)
        {
            
            _contextMV.PostData.Add(movieData);
            var saveres = await _contextMV.SaveChangesAsync();
            return saveres == 1;
        }

        public async Task<MovieData[]> GetIncompleteItemsAsync_MyPost(string id)
        {
            return await _contextMV.PostData
               .Where(x => x.PosterId == id)
               .ToArrayAsync();
        }
    }
}