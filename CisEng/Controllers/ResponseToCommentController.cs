using Application.ResponsToComment.Commonds;
using MediatR;
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
    public class ResponseToCommentController : BaseController
    {

        /// <summary>
        ///  Insert ResponseToComment
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> InsertResponseToComment([FromBody] CreateRespontCommentCommond command)
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
            await Mediator.Send(new DeleteRespontCommentCommond() { Id = id });
            return Ok();
        }
    }
}
