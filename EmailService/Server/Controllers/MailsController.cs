using AutoMapper;
using EmailSender.Application.Interfaces;
using EmailSender.Application.Mails.Commands.CreateMail;
using EmailSender.Application.Mails.Queries.GetAllMail;
using Microsoft.AspNetCore.Mvc;

namespace EmailSender.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MailsController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMailContext _dbContext;

        public MailsController(
           IMapper mapper, IMailContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        /// <summary>
        /// Send mail
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST api/mails/
        /// </remarks>
        /// <returns>Returns email id</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<string>> CreateMail([FromBody] CreateMailDto createMailDto)
        {
            var command = _mapper.Map<CreateMailCommand>(createMailDto);
            var userId = await Mediator.Send(command);
            return Ok(userId);
        }

        /// <summary>
        /// Get all sent emails
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET api/mails/
        /// </remarks>
        /// <returns>Returns MailListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<MailListVm>> GetAllMails()
        {
            var query = new GetAllMailQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}

