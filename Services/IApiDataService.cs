using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Data;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public interface IApiDataService
    {
        Task<ApiCommonData> GetApidatabyid(string id);
        Task<ApiCommonData[]> GetIncompleteItemsAsync_Private_Api(string id);
        Task<bool> AddApiDataAsync(ApiCommonData apiData);
        Task<bool> DeleteApiData(ApiCommonData apiData);
    }
}
