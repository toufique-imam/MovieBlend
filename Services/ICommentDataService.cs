using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieBlend.Models;

namespace MovieBlend.Services
{
    public interface ICommentDataService
    {
        Comment Getdatabyid(Guid id);
        Task<Comment[]> GetIncompleteItemsAsync(Guid mid);
        Task<bool> AddCommentDataAsync(Comment commentdata);
    }
}
