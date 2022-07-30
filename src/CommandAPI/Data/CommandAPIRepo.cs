using System.Collections.Generic;
using System.Linq;

using CommandAPI.Models;

namespace CommandAPI.Data
{
    public class CommandAPIRepo : ICommandAPIRepo
    {
        private readonly CommandContext _context;

        public CommandAPIRepo(CommandContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command command)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}
