using AutoMapper;

using CommandAPI.Dtos;
using CommandAPI.Models;

namespace CommandAPI.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandReadDto>();

            // Source ➤ Target (Mappings for write operations).
            CreateMap<CommandCreateDto, Command>();
        }
    }
}
