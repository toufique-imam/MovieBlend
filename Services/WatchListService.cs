using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieBlend.Data;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public class WatchListService : IWatchListService
    {
        private ApplicationDbContext _WatchlistDatabase;
        public WatchListService(ApplicationDbContext dbContext)
        {
            _WatchlistDatabase = dbContext;
        }
        public async Task<bool> AddWatchListDataAsync(WatchListModel Data)
        {
            _WatchlistDatabase.WatchLists.Add(Data);
            var saveres = await _WatchlistDatabase.SaveChangesAsync();
            return saveres == 1;
        }

        public async Task<bool> Delete(WatchListModel Data)
        {

            _WatchlistDatabase.WatchLists.Remove(Data);
            var saveres = await _WatchlistDatabase.SaveChangesAsync();
            return saveres == 1;
        }

        

        public WatchListModel Getdatabyid(string Model_ID)
        {
            var xx = _WatchlistDatabase.WatchLists.FirstOrDefault(x => x.Id == Model_ID);
            return xx;
        }

        public async Task<WatchListModel> GetDataByIdAsync(string Model_ID)
        {
            var xx = await _WatchlistDatabase.WatchLists.FirstOrDefaultAsync(x => x.Id == Model_ID);
            return xx;
        }

        public async Task<WatchListModel[]> GetIncompleteItemsAsync(string User_ID)
        { 
            return await _WatchlistDatabase.WatchLists.Where(x => x.userId == User_ID).ToArrayAsync();
        }

        public async Task<bool> HasData(string enitiy_id)
        {
            var xx = await GetDataByIdAsync(enitiy_id);
            if (xx != null && xx.Id == enitiy_id) return true;
            return false;
        }
    }
}
