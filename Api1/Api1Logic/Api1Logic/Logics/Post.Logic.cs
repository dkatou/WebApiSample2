using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api1.Api1Model.Models;
using Api1.Api1Model.Data;

namespace Api1.Api1Logic.Logics
{
    public class PostLogic
    {
        private readonly Api1Context _context;

        public PostLogic(Api1Context context)
        {
            _context = context;
        }

        public async Task CreateData(List<Post> posts, DateTime tsStamp, string usStamp, string asStamp)
        {
            posts.ForEach(post =>
            {
                post.SetBaseData(tsStamp, usStamp, asStamp);
                _context.Entry(post).State = EntityState.Added;
            });

            await _context.SaveChangesAsync();
        }

        public async Task UpdataData(List<Post> posts, DateTime tsStamp, string usStamp, string asStamp)
        {
            posts.ForEach(post =>
            {
                post.SetBaseData(tsStamp, usStamp, asStamp);
                _context.Entry(post).State = EntityState.Modified;
            });

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }        
        }

        public async Task DeleteData(int id)
        {
            Post[] posts = await _context.Post.Where(k => k.BlogId == id).ToArrayAsync();
            _context.Post.RemoveRange(posts);
            await _context.SaveChangesAsync();
        }
    }
}