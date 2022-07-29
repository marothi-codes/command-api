using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

using CommandAPI.Data;
using CommandAPI.Models;

namespace CommandAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;

        public CommandsController(ICommandAPIRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Command>> Get()
        {
            return Ok(_repository.GetAllCommands());
        }

        [HttpGet("{id}")]
        public ActionResult<Command> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);

            if (command == null)
                return NotFound();

            return Ok(command);
        }
    }
}
