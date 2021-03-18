using Application.ResponseToResponse.Commonds;
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
    public class ResposneToRespController : BaseController
    {
        /// <summary>
        ///  Insert ResponseToResponse
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> InsertResponseToComment([FromBody] CreateResToResCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
    }
}
