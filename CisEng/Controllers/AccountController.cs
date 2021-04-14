using System.Threading.Tasks;
using Application.Account.Commands.Login;
using Application.Account.Commands.Register;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CisEng.models;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using Application.Account.Commands.ResetPassword;

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

           var result=  await Mediator.Send(command);
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors);
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
        /// <summary>
        /// Confirm email for user
        /// </summary>
        ///<param name="emailConfirmationCommond"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> EmailConfirmation(EmailConfirmationCommond emailConfirmationCommond)
        {
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(emailConfirmationCommond.Token);
            emailConfirmationCommond.Token = Encoding.UTF8.GetString(codeDecodedBytes);
            await this.Mediator.Send(emailConfirmationCommond);
            return Ok();
        }
        /// <summary>
        /// Forget Password
        /// </summary>
        ///<param name="resetPassword"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ResetPasswordCommond resetPassword)
        {
            await Mediator.Send(resetPassword);
            return Ok();
        }
        /// <summary>
        /// Change Password
        /// </summary>
        ///<param name="changePassword"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommond changePassword)
        {
            var codeDecodedBytes = WebEncoders.Base64UrlDecode(changePassword.Token);
            changePassword.Token  = Encoding.UTF8.GetString(codeDecodedBytes);
            var result= await Mediator.Send(changePassword);
            if (result.Succeeded) return Ok();
            return BadRequest(result.Errors);
        }
    }
}