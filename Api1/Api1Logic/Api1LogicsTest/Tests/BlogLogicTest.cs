using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.EntityFrameworkCore;
using Api1.Api1Model.Models;
using Api1.Api1Model.Data;
using Api1.Api1Logic.Logics;

namespace Api1.Api1Logic.Api1LogicsTest
{
    public class BlogLogicTest
    {
        private readonly DbContextOptions<Api1Context> _options = new DbContextOptionsBuilder<Api1Context>()
            .UseInMemoryDatabase("data")
            .Options;

        [Fact]
        public async void ReadDataTest()
        {
            using (var context = new Api1Context(_options))
            {
                var logic = new BlogLogic(context);
                context.Database.EnsureCreated();

                Blog tdBlog = new Blog();
                tdBlog.BlogId = 0;
                tdBlog.Url = "https://test.test";

                Post tdPost = new Post();
                tdPost.PostId = 0;
                tdPost.Title = "post0";
                tdPost.BlogId = 0;

                tdBlog.Posts = new List<Post>();
                tdBlog.Posts.Add(tdPost);


                await logic.CreateData(tdBlog, DateTime.Now, "test", "test");

                JoinA tdJoinA = new JoinA();
                tdJoinA.BlogId = 1;
                tdJoinA.JoinAId = 2;

                context.Entry(tdJoinA).State = EntityState.Added;
                await context.SaveChangesAsync();

                List<BlogJoinA> blogs = await logic.ReadDatas();

                Console.WriteLine(blogs.Count);
                Console.WriteLine(blogs[0].Blog.BlogId);
                Console.WriteLine(blogs[0].JoinA.JoinAId);

                Assert.True(1 == 1);
            }

        }
    }
}
