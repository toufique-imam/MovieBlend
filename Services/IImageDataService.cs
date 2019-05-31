using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public interface IImageDataService
    {
        Image Getdatabyid(Guid id);
        Task<Image[]> GetIncompleteItemsAsync();
        Task<bool> AddImageDataAsync(Image Imagedata);
        Task<Image> GetDataByIdAsync(Guid id);
    }
}
