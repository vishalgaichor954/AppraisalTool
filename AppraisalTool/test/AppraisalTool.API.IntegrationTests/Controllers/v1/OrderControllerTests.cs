using AppraisalTool.API.IntegrationTests.Base;
using AppraisalTool.Application.Features.Orders.GetOrdersForMonth;
using AppraisalTool.Application.Responses;
using Newtonsoft.Json;
using Shouldly;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace AppraisalTool.API.IntegrationTests.Controllers.v1
{
    [Collection("Database")]
    public class OrderControllerTests : IClassFixture<CustomWebApplicationFactory>
    { 
        private readonly CustomWebApplicationFactory _factory;
        public OrderControllerTests(CustomWebApplicationFactory factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_OrdersForMonth_ReturnsSuccessResult()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("/api/v1/order?date=2021-08-26&page=1&size=3");

            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<PagedResponse<IEnumerable<OrdersForMonthDto>>>(responseString);

            result.Data.ShouldBeOfType<List<OrdersForMonthDto>>();
            result.Succeeded.ShouldBe(true);
            result.Errors.ShouldBeNull();
        }
    }
}
