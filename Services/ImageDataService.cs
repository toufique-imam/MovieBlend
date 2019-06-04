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
    public class ImagedataService : IImageDataService
    {
        private readonly ApplicationDbContext _contextimg;
        public ImagedataService(ApplicationDbContext context)
        {
            _contextimg = context;
        }

        public async Task<Image[]> GetIncompleteItemsAsync()
        {
            return await _contextimg.Images
                .ToArrayAsync();
        }
        public Image Getdatabyid(Guid id)
        {
            var xx = _contextimg.Images.FirstOrDefault(x => x.Id == id);
            return xx;
        }

        public async Task<bool> AddImageDataAsync(Image Imagedata)
        {

            _contextimg.Images.Add(Imagedata);
            var saveres = await _contextimg.SaveChangesAsync();
            return saveres == 1;
        }

        public async Task<Image> GetDataByIdAsync(Guid id)
        {
           
            var xx = await _contextimg.Images.FirstAsync(x=>x.Id==id);
            return xx;
        
        }
    }
}