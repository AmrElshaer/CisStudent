using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CisEng.Data;
using CisEng.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CisEng.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrivatePostController : ControllerBase
    {
        private readonly AppDbContext _appDb;
        private readonly FollowusController followusController;
        private readonly  PostsController postsController;
        public PrivatePostController(AppDbContext appDb)
        {
            _appDb = appDb;
            followusController = new FollowusController(_appDb);
            postsController = new PostsController(_appDb);
        }

      

        [HttpGet("{id}")]
        public IEnumerable<Posts> Getallprivatepost(string id)
        {
          var allfriends=  followusController.allfriendsforprivate(id);
            if (allfriends!=null)
            {
 foreach (var item in allfriends)
            {
                if (item.sender!=id)
                {
                    var posts = postsController.privatePosts(item.sender);
                    if (posts !=null)
                    {
                        foreach (var post in posts)
                        {
                            yield return post;
                        }
                     
                    }
                        else
                        {
                            yield return new Posts();
                        }
                    
                }
                else
                {
                    var posts =  postsController.privatePosts(item.recever);
                    if (posts != null)
                    {
                        foreach (var post in posts)
                        {
                            yield return post;

                        }
                       
                    }
                       yield return new Posts();
                    }
            }
            }
           
           
        }
    }
}