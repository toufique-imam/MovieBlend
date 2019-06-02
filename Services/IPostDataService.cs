using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public interface IPostDataService
    {
        MovieData Getdatabyid(String id);
        Task<MovieData[]> GetIncompleteItemsAsync_Movie();
        Task<MovieData[]> GetIncompleteItemsAsync_TV();
        Task<MovieData[]> GetIncompleteItemsAsync_Private(String id);
        Task<MovieData[]> GetIncompleteItemsAsync_MyPost(String id);
        Task<bool> AddPostDataAsync(MovieData movieData);
    }
}
