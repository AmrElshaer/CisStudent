using Application.StudentTraining.Commonds.DeleteTraining;
using Application.StudentTraining.Commonds.UpSrtTraining;
using Application.StudentTraining.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CisEng.Controllers
{

    /// <summary>
    /// Manage Student Training
    /// </summary>
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TrainingController : BaseController
    {
        /// <summary>
        /// Update and Insert Training
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<int>> UpSrtTraining([FromBody] UpSrtTrainingCommond command)
        {
            var entityId = await Mediator.Send(command);
            return Ok(entityId);
        }
        /// <summary>
        /// Get Training
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainingDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TrainingDto>> GetTraining(int id)
        {
            var entityDto = await Mediator.Send(new GetTrainingQuery() { Id = id });
            return Ok(entityDto);
        }
        /// <summary>
        /// Get All Training
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TrainingDto))]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TrainingDto>> GetAllTraining(int studentId)
        {
            var entityDto = await Mediator.Send(new GetAllTrainingQuery() { StudentId = studentId });
            return Ok(entityDto);
        }
        /// <summary>
        /// Delete Training
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteTraining(int id)
        {
            await Mediator.Send(new DeleteTrainingCommond() { Id = id });
            return Ok();
        }
    }
}
