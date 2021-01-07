using Application.StudentJob.Commonds.DeleteJob;
using Application.StudentJob.Commonds.UpSrtJob;
using Application.StudentJob.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CisEng.Controllers
{ 
    /// <summary>
    /// Manage Student Job
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class JobController : BaseController
    {
        /// <summary>
        /// Update and Insert Job
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpSrtJob([FromBody] UpSrtJobCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
        /// <summary>
        /// Get Job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<JobDto>> GetJob(int id)
        {
            var entityDto = await Mediator.Send(new GetJobQuery() { Id = id });
            return Ok(entityDto);
        }
        /// <summary>
        /// Get All Job
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<JobDto>> GetAllJob(int studentId)
        {
            var entityDto = await Mediator.Send(new GetAllJobQuery() { StudentId = studentId });
            return Ok(entityDto);
        }
        /// <summary>
        /// Delete Job
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteJob(int id)
        {
            await Mediator.Send(new DeleteJobCommond() { Id = id });
            return Ok();
        }
    }
}
