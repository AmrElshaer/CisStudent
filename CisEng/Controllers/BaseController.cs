using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CisEng.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController:ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator!=null ?_mediator: HttpContext.RequestServices.GetService<IMediator>();
    }
}
