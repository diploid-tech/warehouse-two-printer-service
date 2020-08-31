using Akka.Actor;
using Akka.DI.Core;
using Avanti.Core.Microservice.Actors;

namespace Avanti.WarehouseTwoPrinterService.Order
{
    public class PrinterActorProvider : BaseActorProvider<PrinterActor>
    {
        public PrinterActorProvider(ActorSystem actorRefFactory) =>
            ActorRef = actorRefFactory.ActorOf(actorRefFactory.DI().Props<PrinterActor>(), "printer-actor");
    }
}
