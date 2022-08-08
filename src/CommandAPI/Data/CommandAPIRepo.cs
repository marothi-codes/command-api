using CommandAPI.Models;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

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
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            _context.Commands.Remove(command);
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.AsNoTracking().ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command)
        {
            // TODO: Implement the update operation for other ORM types
            // NOTE: EntityFrameworkCore does not require an explicit implementation
            // since it already change tracking unless otherwise specified.
        }
    }
}
