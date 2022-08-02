using AutoMapper;

using CommandAPI.Controllers;
using CommandAPI.Data;
using CommandAPI.Dtos;
using CommandAPI.Models;
using CommandAPI.Profiles;

using Microsoft.AspNetCore.Mvc;

using Moq;

using System;
using System.Collections.Generic;

using Xunit;

namespace CommandAPI.Tests
{
    public class CommandsControllerTests : IDisposable
    {
        Mock<ICommandAPIRepo> mockRepo;
        CommandsProfile realProfile;
        MapperConfiguration config;
        IMapper mapper;

        public CommandsControllerTests()
        {
            mockRepo = new Mock<ICommandAPIRepo>();
            realProfile = new CommandsProfile();
            config = new MapperConfiguration(cfg => cfg.AddProfile(realProfile));
            mapper = new Mapper(config);
        }

        public void Dispose()
        {
            mockRepo = null;
            mapper = null;
            config = null;
            realProfile = null;
        }

        [Fact]
        public void GetCommands_Return200OK_WhenDbIsEmpty()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(0));
            // An instance of the CommandsController class is needed.
            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        private List<Command> GetCommands(int num)
        {
            var commands = new List<Command>();

            if (num > 0)
            {
                commands.Add(
                    new Command
                    {
                        Id = 0,
                        HowTo = "How to generate a migration",
                        CommandLine = "dotnet ef migrations add <Name of Migration>",
                        Platform = ".Net Core EF"
                    }
                );
            }

            return commands;
        }
    }
}
