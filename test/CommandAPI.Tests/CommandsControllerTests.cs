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

        // CommandsController.Get() Tests.
        [Fact]
        public void Get_Return200OK_WhenDbIsEmpty()
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

        [Fact]
        public void Get_ReturnsOneItem_WhenDbHasOneResource()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));
            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = result.Result as OkObjectResult;
            var commands = okResult.Value as List<CommandReadDto>;
            Assert.Single(commands);
        }

        [Fact]
        public void Get_Returns200OK_WhenDbHasOneResource()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));

            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void Get_ReturnsCorrectType_WhenDbHasOneResource()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetAllCommands()).Returns(GetCommands(1));

            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.Get();

            // Assert
            Assert.IsType<ActionResult<IEnumerable<CommandReadDto>>>(result);
        }

        // CommandsController.GetCommandById(int id) tests
        [Fact]
        public void GetCommandById_Returns404NotFound_WhenNonExistentIdIsProvided()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetCommandById(0)).Returns(() => null);

            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.GetCommandById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetCommandById_Return200OK_WhenValidIdIsProvided()
        {
            // Arrange
            mockRepo
                .Setup(repo => repo.GetCommandById(1))
                .Returns(
                    new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    }
                );

            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.GetCommandById(1);

            // Assert
            Assert.IsType<OkObjectResult>(result.Result);
        }

        [Fact]
        public void GetCommandById_ReturnsCorrectType_WhenValidIdIsProvided()
        {
            // Arrange
            mockRepo
                .Setup(repo => repo.GetCommandById(1))
                .Returns(
                    new Command
                    {
                        Id = 1,
                        HowTo = "mock",
                        Platform = "Mock",
                        CommandLine = "Mock"
                    }
                );

            var controller = new CommandsController(mockRepo.Object, mapper);

            // Act
            var result = controller.GetCommandById(1);

            // Assert
            Assert.IsType<ActionResult<CommandReadDto>>(result);
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
