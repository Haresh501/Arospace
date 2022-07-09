using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CoreService.Repository;
using Microsoft.AspNetCore.Mvc;
using CoreService.Models;

//comment added to check function
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        IPostRepository postRepository;

        public AdminController(IPostRepository _postRepository)
        {
            postRepository  = _postRepository;
        }

        [HttpPost]
        [Route("AddPost")]
        public async Task<ObjectResult> AddPost([FromBody]Post post)
        {
            ObjectResult objectResult;
            var postId = await this.postRepository.AddPost(post);
            if(postId > 0)
            {
                objectResult =new ObjectResult(postId);
                objectResult.StatusCode = (int)HttpStatusCode.OK;
                return objectResult;
            }
            else
            {
                objectResult =new ObjectResult("Record Not Inserted");
                objectResult.StatusCode = (int)HttpStatusCode.BadRequest;
                return objectResult;
            }
        }

        [HttpPut]
        [Route("UpdatePost")]
        public async Task<ObjectResult> UpdatePost([FromBody] Post post)
        {
            ObjectResult objResult;
            var postId = await this.postRepository.UpdatePost(post);
            if(postId > 0)
            {
                objResult =new ObjectResult(postId);
                objResult.StatusCode = (int)HttpStatusCode.OK;
                return objResult;
            }
            else
            {
                objResult = new ObjectResult(postId);
                objResult.StatusCode = (int)HttpStatusCode.BadRequest;
                return objResult;
            }
            //return objResult;
        }

        [HttpDelete]
        [Route("DeletePost")]
        public async Task<ObjectResult> DeletePost(int? postId)
        {
            ObjectResult objResult;
            var pId = await this.postRepository.DeletePost(postId);

            if(pId > 0)
            {
                objResult = new ObjectResult(pId);
                objResult.StatusCode = (int)HttpStatusCode.OK;
                return objResult;

            }
            else
            {
                objResult = new ObjectResult("Not Deleted");
                objResult.StatusCode = (int)HttpStatusCode.BadRequest;
                return objResult;
            }
        }

        [HttpPost]
        [Route("AddCategories")]
        public async Task<ObjectResult> AddCategories([FromBody] Category category)
        {
            ObjectResult objectResult;
            var catId = await this.postRepository.AddCategory(category);
            if (catId > 0)
            {
                objectResult = new ObjectResult(catId);
                objectResult.StatusCode = (int)HttpStatusCode.OK;
                return objectResult;
            }
            else
            {
                objectResult = new ObjectResult("Record Not Inserted");
                objectResult.StatusCode = (int)HttpStatusCode.BadRequest;
                return objectResult;
            }
        }

        // GET: api/<PostController>
        [HttpGet]
        [Route("GetCategories")]
        public async Task<ObjectResult> GetCategories()
        {
            ObjectResult objResult;
            var categories = await postRepository.GetCategories();
                if (categories != null)
                {
                    objResult = new ObjectResult(categories);
                    objResult.StatusCode = (int)HttpStatusCode.OK;
                    return objResult;
                }
                else
                {
                    objResult = new ObjectResult("No Data Found");
                    objResult.StatusCode = (int)HttpStatusCode.NotFound;
                    return objResult;
                }
        }

        [HttpGet]
        [Route("GetPosts")]
        public async Task<ObjectResult> GetPosts()
        {
            ObjectResult objResult;

            var lstPost = await this.postRepository.GetPosts();
            if(lstPost != null)
            {
                objResult = new ObjectResult(lstPost);
                objResult.StatusCode = (int)HttpStatusCode.OK;
                return objResult;
            }
            else
            {
                objResult = new ObjectResult("No Data Fount");
                objResult.StatusCode = (int)HttpStatusCode.NotFound;
                return objResult;
            }
        }
    }
}
