using AutoMapper;

using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            // Source ➤ Target (be careful about the notation on write operations).
            CreateMap<Command, CommandReadDto>(); // GET mapping
            CreateMap<CommandCreateDto, Command>(); // POST mapping
            CreateMap<CommandUpdateDto, Command>(); // PUT mapping
            CreateMap<Command, CommandUpdateDto>(); // PATCH mapping
        }
    }
}
