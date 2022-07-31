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
            CreateMap<Command, CommandReadDto>();

            CreateMap<CommandCreateDto, Command>();
        }
    }
}
