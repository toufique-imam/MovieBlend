using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieBlend.Data;
using MovieBlend.Models;
using Microsoft.EntityFrameworkCore;
using Humanizer;
namespace MovieBlend.Services{
    public class CommentDataService : ICommentDataService{
        private readonly ApplicationDbContext _contextCom;
        public CommentDataService(ApplicationDbContext context){
            _contextCom=context;
        }

        public async Task<Comment[]> GetIncompleteItemsAsync(Guid mid)
        {
            return await _contextCom.Comments
                .Where(x=>x.BlogPostID==mid)
                .ToArrayAsync();
        }
        public Comment Getdatabyid(Guid cid)
        {
            var xx = _contextCom.Comments.FirstOrDefault(x =>x.ID == cid);
            return xx;
        }

        public async Task<bool> AddCommentDataAsync(Comment commentdata)
        {
            _contextCom.Comments.Add(commentdata);
            var saveres = await _contextCom.SaveChangesAsync();
            return saveres == 1;
        }
    }
}