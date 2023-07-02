using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator =>
            _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

    }
}
