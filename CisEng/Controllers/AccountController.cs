using System.Threading.Tasks;
using Application.Account.Commands.Login;
using Application.Account.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CisEng.models;

namespace CisEng.Controllers
{
    /// <summary>
    /// Manage Authentication
    /// </summary>
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        /// <summary>
        /// Register User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Register([FromBody]RegisterCommand command)
        {

            await Mediator.Send(command);
            return NoContent();
        }
        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtToken))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<JwtToken>> Login([FromBody]LoginCommand command)
        {
               var result= await Mediator.Send(command);
               return Ok(new JwtToken{ Token = result.token,Image=result.image });
            
        }

    }
}