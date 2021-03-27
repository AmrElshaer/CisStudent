using Application.StudentLikes.Commonds;
using Application.StudentLikes.Queries;
using Application.StudentPost.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisEng.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ReactionsController : BaseController
    {
        /// <summary>
        /// Update and Insert Reaction
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpSrtReaction([FromBody] UpdateReactionCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
        /// <summary>
        /// Get All Reactions For post
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<LikeDto>))]
        [ProducesDefaultResponseType]
        [AllowAnonymous]
        public async Task<ActionResult<PostDto>> GetReactions(int postId)
        {
            var reactions = await Mediator.Send(new GetReationsQuery() { PostId=postId});
            return Ok(reactions);
        }
       /// <summary>
       /// Remove Reaction
       /// </summary>
       /// <param name="postId"></param>
       /// <param name="studentId"></param>
       /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteReaction(int postId,int studentId)
        {
            await Mediator.Send(new RemoveReactionCommond() {PostId=postId,StudentId=studentId });
            return Ok();
        }
    }
}
