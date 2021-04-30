using Application.StudentMessage;
using Application.StudentMessage.Commonds;
using Application.StudentMessage.Queries.GetMessages;
using Application.StudentMessage.Queries.GetUnSeeMessages;
using Infrastructure.Hubs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisEng.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    public class ChatController : BaseController
    {
        
        /// <summary>
        /// Send Message
        /// </summary>
        /// <param name="messageDto"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SendRequest([FromBody]  ChatMessageDto messageDto)
        {
            messageDto.CreateDate = DateTime.Now;
            var entityId=await  Mediator.Send(new SendMessageCommond() {MessageDto=messageDto });
            return Ok(entityId);
        }
        /// <summary>
        /// Get all messages for user conversation
        /// </summary>
        /// <param name="fromSTD"></param>
        /// <param name="toSTD"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetMessages(int fromSTD,int toSTD)
        {
            var messages = await Mediator.Send(new GetMessagesQueries() {SendSTDId=fromSTD,RecieveSTDId=toSTD});
            return Ok(messages);
        }
        /// <summary>
        /// Get missmessages that user didnot see
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> GetMissMessages(int userId)
        {
            var messages = await Mediator.Send(new GetUnSeeMessageQueries() {UserId=userId });
            return Ok(messages);
        }
    }
}
