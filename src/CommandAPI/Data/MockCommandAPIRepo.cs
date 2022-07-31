using CommandAPI.Models;

using System.Collections.Generic;
using System.Linq;

namespace CommandAPI.Data
{
    public class MockCommandAPIRepo : ICommandAPIRepo
    {
        private List<Command> commands = new List<Command>
        {
            new Command
            {
                Id = 0,
                HowTo = "How to generate a migration",
                CommandLine = "dotnet ef migrations add <Name of Migration>",
                Platform = ".Net Core EF"
            },
            new Command
            {
                Id = 1,
                HowTo = "Run Migrations",
                CommandLine = "dotnet ef database update",
                Platform = ".Net Core EF"
            },
            new Command
            {
                Id = 2,
                HowTo = "List active migrations",
                CommandLine = "dotnet ef migrations list",
                Platform = ".Net Core EF"
            }
        };

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
            return commands;
        }

        public Command GetCommandById(int id)
        {
            var command = commands.SingleOrDefault(c => c.Id == id);

            return command;
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
