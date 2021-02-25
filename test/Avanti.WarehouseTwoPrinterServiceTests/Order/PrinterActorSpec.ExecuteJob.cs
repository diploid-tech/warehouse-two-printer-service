using System;
using System.Globalization;
using Akka.Actor;
using Avanti.WarehouseTwoPrinterService.Order;
using Xunit;

namespace Avanti.WarehouseTwoPrinterServiceTests.Order
{
    public partial class PrinterActorSpec
    {
        public class When_Execute_Job : PrinterActorSpec
        {
            private readonly PrinterActor.ExecuteJob input = new()
            {
                Id = "1-1",
                OrderId = 1,
                OrderDate = DateTimeOffset.Parse("2020-07-01T19:00:00Z", CultureInfo.InvariantCulture),
                Lines = new[]
                {
                    new PrinterActor.ExecuteJob.OrderLine { ProductId = 5, Amount = 1, Description = "x" },
                    new PrinterActor.ExecuteJob.OrderLine { ProductId = 7, Amount = 5, Description = "y" }
                }
            };

            [Fact]
            public void Should_Return_Completed()
            {
                Subject.Tell(input);

                Kit.ExpectMsg<PrinterActor.JobCompleted>();
            }
        }
    }
}
