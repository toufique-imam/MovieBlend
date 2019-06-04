using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Models;
using MovieBlend.Data;
using Microsoft.EntityFrameworkCore;

namespace MovieBlend.Services
{
    public class ApiDataService : IApiDataService
    {
        private readonly ApplicationDbContext _apicontext;
        public ApiDataService(ApplicationDbContext applicationDb)
        {
            _apicontext = applicationDb;
        }
        public async Task<bool> AddApiDataAsync(ApiCommonData apiData)
        {
            var has=await _apicontext.ApiData.ContainsAsync(apiData);
            if(has)return has;
            //var xx = await GetApidatabyid(apiData.id);
            //if (xx != null && xx.id == apiData.id) return true;
            _apicontext.ApiData.Add(apiData);
            return await _apicontext.SaveChangesAsync()==1;
        }

        public async Task<bool> DeleteApiData(ApiCommonData apiData)
        {
         
            _apicontext.ApiData.Remove(apiData);
            return await _apicontext.SaveChangesAsync() == 1;
           // throw new NotImplementedException();
        }

        public async Task<ApiCommonData> GetApidatabyid(String id)
        {
            var xx = await _apicontext.ApiData.FirstAsync(x => x.id.ToString() == id);
            return xx;
        }

        public Task<ApiCommonData[]> GetIncompleteItemsAsync_Private_Api(string id)
        {
            throw new NotImplementedException();
        }
    }
}
