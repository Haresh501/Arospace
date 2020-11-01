using CoreService.Entities;
using CoreService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreService.Repository
{
    public interface IPostRepository
    {
        Task<List<Category>> GetCategories();
        Task<List<PostViewModel>> GetPosts();
        Task<PostViewModel> GetPost(int? postId);
        Task<int> AddPost(Post post);
        Task<int> AddCategory(Category category);
        Task<int> DeletePost(int? postId);
        Task<int> UpdatePost(Post post);
    }
}
