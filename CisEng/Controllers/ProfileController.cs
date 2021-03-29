using Application.StudentProfile.Command.UpIntProfile;
using Application.StudentProfile.Queries.GetProfileById;
using Application.StudentProfile.Queries.SearchProfile;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CisEng.Controllers
{
    /// <summary>
    /// Manage Student Profile
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProfileController : BaseController
    {
        /// <summary>
        /// Update and Insert Profile
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpSrtProfile([FromBody] UpIntProfileCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
        /// <summary>
        /// Get Profile
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProfileDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<ProfileDto>> GetProfile(int studentId)
        {
            var entityDto = await Mediator.Send(new GetProfileQuery() { StudentId = studentId });
            return Ok(entityDto);
        }
        /// <summary>
        /// Get Profiles
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ProfileDto>))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<IEnumerable<ProfileDto>>> GetProfiles(string text)
        {
            var entityDtos = await Mediator.Send(new SearchQuery() {Text=text});
            return Ok(entityDtos);
        }
    }
}
