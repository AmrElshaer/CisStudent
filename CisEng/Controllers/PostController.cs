using Application.StudentPost.Commonds.DeletePost;
using Application.StudentPost.Commonds.UpSrtPost;
using Application.StudentPost.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Collections.Generic;
using Application.StudentLikes.Commonds;

namespace CisEng.Controllers
{
    /// <summary>
    /// Manage User Post
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class PostController : BaseController
    {
        /// <summary>
        /// Update and Insert Post
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpSrtPost([FromBody] UpSrtPostCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
       
        /// <summary>
        /// Get Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PostDto>> GetPost(int id)
        {
            var entityDto = await Mediator.Send(new GetPostQuery() { Id =id });
            return Ok(entityDto);
        }
        /// <summary>
        /// Get All Post
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PostDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<PostDto>> GetAllPost(int studentId)
        {
            var entityDto = await Mediator.Send(new GetAllPostQuery() { StudentId=studentId });
            return Ok(entityDto);
        }
        /// <summary>
        /// Get All StudentsPosts
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<PostDto>))]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult<PostDto>> GetStudentsPosts()
        {
            var entityDto = await Mediator.Send(new GetStudentsPostsQuery());
            return Ok(entityDto);
        }
        /// <summary>
        /// Delete Post
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeletePost(int id)
        {
            await Mediator.Send(new DeletePostCommond() { Id = id });
            return Ok();
        }
    }
}
