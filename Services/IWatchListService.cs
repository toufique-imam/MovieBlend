using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Models;
namespace MovieBlend.Services
{
    public interface IWatchListService
    {
        WatchListModel Getdatabyid(string Model_ID);
        Task<WatchListModel[]> GetIncompleteItemsAsync(string User_ID);
        Task<bool> AddWatchListDataAsync(WatchListModel Data);
        Task<WatchListModel> GetDataByIdAsync(string Model_ID);
        Task<bool> Delete(WatchListModel Data);
        Task<bool> HasData(String enitiy_id);
        
    }
}
