using CoreService.Entities;
using CoreService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace CoreService.Repository
{
    public class PostRepository : IPostRepository
    {
        BlogDBContext _db;
        public PostRepository(BlogDBContext db)
        {
            _db = db;
        }
        public async Task<int> AddPost(Post post)
        {
            if(_db !=null)
            {
                await _db.Post.AddAsync(post);
                await _db.SaveChangesAsync();
                return post.PostId;
            }

            return 0;
        }

        public async Task<int> AddCategory(Category category)
        {
            if (_db != null)
            {
                await _db.Category.AddAsync(category);
                await _db.SaveChangesAsync();
                return category.Id;
            }

            return 0;
        }

        public async Task<int> DeletePost(int? postId)
        {
            int result = 0;
            if(_db != null)
            {
                var post = _db.Post.FirstOrDefaultAsync(x => x.PostId == postId);
                if(post != null)
                {
                    _db.Post.Remove(post.Result);
                    result = await _db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }

        public async Task<List<Category>> GetCategories()
        {
            if(_db !=null)
            {
                return await _db.Category.ToListAsync();
            }
            return null;
        }

        public async Task<List<PostViewModel>> GetPosts()
        {
            if(_db !=null)
            {
                return await (from p in _db.Post
                              from c in _db.Category
                              where p.CategoryId == c.Id
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Name,
                                  CreatedDate = p.CreatedDate,
                                  Description = p.Description
                              }

                              ).ToListAsync();
            }
            return null;
        }

        public async Task<PostViewModel> GetPost(int? postId)
        {
            if(_db != null)
            {
                return await (from p in _db.Post
                              from c in _db.Category
                              where p.PostId == postId
                              select new PostViewModel
                              {
                                  PostId = p.PostId,
                                  Title = p.Title,
                                  CategoryId = c.Id,
                                  CategoryName = c.Name,
                                  CreatedDate = p.CreatedDate,
                                  Description = p.Description

                              }
                              ).FirstOrDefaultAsync();
            }

            return null;
        }

        public async Task<int> UpdatePost(Post post)
        {
            var result = 0;
            if(_db != null)
            {
                _db.Post.Update(post);
                result= await _db.SaveChangesAsync();
                return result;
            }
            return result;
        }
    }
}
