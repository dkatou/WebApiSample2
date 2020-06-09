using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Api1.Api1Model.Models;
using Api1.Api1Model.Data;
using Common.CommonLogic.Logics;

namespace Api1.Api1Logic.Logics
{
    public class BlogJoinA
    {
        public Blog Blog { get; set; }
        public JoinA JoinA { get; set; }
    }
    public class BlogLogic
    {
        private readonly Api1Context _context;

        public BlogLogic(Api1Context context)
        {
            _context = context;
        }

        public async Task<List<BlogJoinA>> ReadDatas()
        {
            var blog = _context.Blog
                .GroupJoin(
                    _context.JoinA,
                    b => b.BlogId,
                    j => j.BlogId,
                    (b, j) => new
                    {
                        b = b,
                        j = j
                    }
                )
                .SelectMany(
                    x => x.j.DefaultIfEmpty(),
                    (x, j) => new BlogJoinA
                    {
                        Blog = x.b,
                        JoinA = j
                    }
                );


            return await blog.ToListAsync();
        }
        public async Task<Blog> ReadData(int id)
        {
            var blog = _context.Blog
                .Include(blog => blog.Posts)
                    .ThenInclude(post => post.PostChilds)
                .Include(blog => blog.Notes)
                .Include(blogs => blogs.Viewers);
            return await blog.FirstOrDefaultAsync(blog => blog.BlogId == id);
        }

        public async Task UpdateData(Blog blog, DateTime tsStamp, string usStamp, string asStamp)
        {
            PostLogic postLogic = new PostLogic(_context);

            blog.SetBaseData(tsStamp, usStamp, asStamp);
            _context.Entry(blog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                await postLogic.UpdataData(blog.Posts, tsStamp, usStamp, asStamp);
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }

        public async Task CreateData(Blog blog, DateTime tsStamp, string usStamp, string asStamp)
        {
            PostLogic postLogic = new PostLogic(_context);

            blog.SetBaseData(tsStamp, usStamp, asStamp);
            _context.Entry(blog).State = EntityState.Added;

            await _context.SaveChangesAsync();
            await postLogic.CreateData(blog.Posts, tsStamp, usStamp, asStamp);
        }

        public async Task<Blog> DeleteData(int id)
        {
            var blog = await _context.Blog.FindAsync(id);

            _context.Blog.Remove(blog);
            await _context.SaveChangesAsync();

            PostLogic postLogic = new PostLogic(_context);
            await postLogic.DeleteData(id);

            return blog;
        }

        public bool BlogExists(int id)
        {
            return _context.Blog.Any(e => e.BlogId == id);
        }
    }
}
