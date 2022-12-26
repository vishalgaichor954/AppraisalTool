using AppraisalTool.Api.Controllers.v1;
using AppraisalTool.Application.Contracts.Persistence;
using AppraisalTool.Application.Features.Menu.Command.CreateMenuCommand;
using AppraisalTool.Application.Features.Menu.Command.UpdateMenuCommand;
using AppraisalTool.Application.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AppraisalTool.API.UnitTests.Controllers.v1
{
    public class MenuControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<MenuController>> _logger;
        private readonly Mock<IMenuRepository> _menrepository;

        public MenuControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _logger = new Mock<ILogger<MenuController>>();
            _menrepository = new Mock<IMenuRepository>();
        }
        [Fact]
        public async Task AddMenu()
        {
            
            var controller = new MenuController(_mediator.Object, _logger.Object, _menrepository.Object);
            var createmenu = new CreateMenuCommand
            {
                MenuText = "text",
                MenuClass = "text",
                MenuIcon = "text",
                MenuAction = "text",
                MenuController = "text",
                MenuFlag = "text",
                MenuLink = "text"
            };
            var result = await controller.AddMenu(createmenu);
           
            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
          
        }
        [Fact]
        public async Task GetMenuById()
        {
            var controller = new MenuController(_mediator.Object, _logger.Object, _menrepository.Object);
            
            var result = await controller.GetMenuById(1);

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
        }

        [Fact]
        public async Task GetAllMenuList()
        {
            var controller = new MenuController(_mediator.Object, _logger.Object, _menrepository.Object);

            var result = await controller.GetAllMenuList();

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
        }
        [Fact]
        public async Task UpdateMenu()
        {
            var controller = new MenuController(_mediator.Object, _logger.Object, _menrepository.Object);
            var updateMenuCommand = new UpdateMenuCommand
            {
                Menu_Id = 1,
                MenuAction = "text",
                MenuClass = "text",
                MenuController = "text",
                MenuFlag = "text",
                MenuIcon = "text",
                MenuLink = "text",
                MenuText = "text"
            };
            var result = await controller.UpdateMenu(updateMenuCommand);

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
        }

        [Fact]
        public async Task RemoveAsync()
        {
            var controller = new MenuController(_mediator.Object, _logger.Object, _menrepository.Object);

            var result = await controller.RemoveAsync(1);

            result.ShouldBeOfType<OkObjectResult>();
            var okObjectResult = result as OkObjectResult;
            okObjectResult.StatusCode.ShouldBe(200);
        }

    }
}
