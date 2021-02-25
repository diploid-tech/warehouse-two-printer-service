using System;
using System.Globalization;
using Akka.Actor;
using Avanti.WarehouseTwoPrinterService.Order;
using Avanti.WarehouseTwoPrinterService.Order.Api;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace Avanti.WarehouseTwoPrinterServiceTests.Order.Api
{
    public partial class PrivateApiControllerSpec
    {
        public class When_PostOrder_Request_Is_Received : PrivateApiControllerSpec
        {
            private readonly PrivateApiController.PostOrderRequest request = new()
            {
                Id = "1-1",
                OrderId = 1,
                OrderDate = DateTimeOffset.Parse("2020-07-01T19:00:00Z", CultureInfo.InvariantCulture),
                Lines = new[]
                {
                    new PrivateApiController.PostOrderRequest.OrderLine { ProductId = 5, Amount = 1, Description = "x" },
                    new PrivateApiController.PostOrderRequest.OrderLine { ProductId = 7, Amount = 5, Description = "y" }
                }
            };

            [Fact]
            public async void Should_Return_200_When_Stored()
            {
                progPrinterActor.SetResponseForRequest<PrinterActor.ExecuteJob>(request =>
                    new PrinterActor.JobCompleted());

                IActionResult result = await Subject.PostOrder(request);

                result.Should().BeOfType<OkResult>();

                progPrinterActor.GetRequest<PrinterActor.ExecuteJob>()
                    .Should().BeEquivalentTo(
                        new PrinterActor.ExecuteJob
                        {
                            Id = "1-1",
                            OrderId = 1,
                            OrderDate = DateTimeOffset.Parse("2020-07-01T19:00:00Z", CultureInfo.InvariantCulture),
                            Lines = new[]
                            {
                                new PrinterActor.ExecuteJob.OrderLine { ProductId = 5, Amount = 1, Description = "x" },
                                new PrinterActor.ExecuteJob.OrderLine { ProductId = 7, Amount = 5, Description = "y" }
                            }
                        });
            }

            [Fact]
            public async void Should_Return_500_When_Failed_To_Store()
            {
                progPrinterActor.SetResponseForRequest<PrinterActor.ExecuteJob>(request =>
                    new Failure());

                IActionResult result = await Subject.PostOrder(request);

                result.Should().BeOfType<StatusCodeResult>()
                    .Which.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
