using Akka.Actor;
using Avanti.Core.Unittests;
using Avanti.WarehouseTwoPrinterService.Order;

namespace Avanti.WarehouseTwoPrinterServiceTests.Order
{
    public partial class PrinterActorSpec : WithSubject<IActorRef>
    {
        private PrinterActorSpec()
        {
            Subject = Sys.ActorOf(Props.Create<PrinterActor>());
        }
    }
}
