using AutoMapper;

using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace CommandAPI
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommandAPIRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET: ~/api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> Get()
        {
            var commands = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commands));
        }

        // GET: ~/api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var command = _repository.GetCommandById(id);

            if (command == null)
                return NotFound();

            return Ok(_mapper.Map<CommandReadDto>(command));
        }

        // POST: ~/api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> PostCommand(CommandCreateDto dto)
        {
            var commandModel = _mapper.Map<Command>(dto);
            _repository.CreateCommand(commandModel);
            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(
                nameof(GetCommandById),
                new { id = commandReadDto.Id },
                commandReadDto
            );
        }
    }
}
