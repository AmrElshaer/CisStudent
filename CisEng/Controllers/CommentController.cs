using Application.Comments;
using Application.Comments.Commonds;
using Application.Comments.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace CisEng.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CommentController : BaseController
    {
        /// <summary>
        ///  Insert Comment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> InsertComment([FromBody] CreateCommentCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
        /// <summary>
        /// Delete Comment
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCommentCommond() { Id = id });
            return Ok();
        }
        /// <summary>
        /// Get All Comments for specific comment
        /// </summary>
        /// <param name="getComments"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<CommentDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Get(int commentId)
        {
            var resuilt= await Mediator.Send(new GetComments() { CommentId = commentId });
            return Ok(resuilt);
        }
    }
}
