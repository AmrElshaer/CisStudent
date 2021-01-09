using Application.StudentFollow.Commonds;
using Application.StudentFollow.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CisEng.Controllers
{
    /// <summary>
    /// Manage student Follow
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class FollowController : BaseController
    {
        /// <summary>
        /// Update and Insert Follow
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpSrtFollow([FromBody] UpSertFollowCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
        /// <summary>
        /// Check that have follow
        /// </summary>
        /// <param name="haveFollowQuery"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> HaveFollow(HaveFollowQuery haveFollowQuery)
        {
            var entityDto = await Mediator.Send(haveFollowQuery);
            return Ok(entityDto);
        }
        /// <summary>
        /// Delete Follow
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteFollow(int id)
        {
            await Mediator.Send(new DeleteFollowCommond() { Id = id });
            return Ok();
        }
    }
}
